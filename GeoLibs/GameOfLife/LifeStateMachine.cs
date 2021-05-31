using System;
using System.Collections.Generic;
using System.Text;

using MyCell = GeoLibs.GameOfLife.Cell<GeoLibs.GameOfLife.PhysicComponent, GeoLibs.GameOfLife.LogicComponent>;

namespace GeoLibs.GameOfLife
{
    public struct Vector2D
    {
        public double x, y;
        public double this[int index]
        {
            get {
                switch (index) {
                    case 0:
                        return x;
                    case 1:
                        return y;
                    default:
                        throw new System.ArgumentOutOfRangeException();
                }
            }
            set {
                switch (index) {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;
                    default:
                        throw new System.ArgumentOutOfRangeException();
                }
            }
        }

        public static Vector2D operator +(Vector2D a, Vector2D b) => new Vector2D() { x = a.x + b.x, y = a.y + b.y };
        public static Vector2D operator -(Vector2D a, Vector2D b) => new Vector2D() { x = a.x - b.x, y = a.y - b.y };
        public static Vector2D operator -(Vector2D a) => new Vector2D() { x = -a.x, y = -a.y };
        public static Vector2D operator *(Vector2D a, double b) => new Vector2D() { x = a.x * b, y = a.y * b };
        public static Vector2D operator *(double a, Vector2D b) => b * a;
        public double sqrLength => x * x + y * y;
        public double length => Math.Sqrt( sqrLength );
        public Vector2D normalize
        {
            get {
                double len = length;
                return new Vector2D() { x = x / len, y = y / len };
            }
        }
    }

    public struct Cell<PComp, LComp>
    {

        public Vector2D coord;
        public double radius;
        public double x { get => coord.x; set => coord.x = value; }
        public double y { get => coord.y; set => coord.y = value; }
        public PComp physicComponent;
        public LComp logicComponent;
    }
    public struct PhysicComponent
    {
        public Vector2D speed;
        public double pressure;
        public double mass;
    }
    public struct LogicComponent
    {
        public enum Building
        {
            Forest,
            Field,
            Houses,
            Market,
            Craft,
            Noble
        }
        public Building building;
        public float size;
    }
    public interface IRule<PComp, LComp>
    {
        Cell<PComp, LComp> InitializeCell(Vector2D coord, double radius, Random random);
    }
    public class Rules : IRule<PhysicComponent, LogicComponent>
    {
        public MyCell InitializeCell(Vector2D coord, double radius, Random random)
        {
            MyCell cell = new MyCell { coord = coord, radius = radius };
            double choise = random.NextDouble();
            if (choise < 0.6) {
                cell.logicComponent.building = LogicComponent.Building.Forest;
            } else if (choise < 0.98) {
                cell.logicComponent.building = LogicComponent.Building.Field;
            } else {
                cell.logicComponent.building = LogicComponent.Building.Houses;
                cell.logicComponent.size = 1;
            }
            cell.physicComponent.mass = 1;
            return cell;
        }
    }

    public class LifeStateMachine
    {

        #region Core functions

        public enum CoreType
        {
            Const, Linear, Gauss
        }

        private static readonly double _gaussCoef = Math.Sqrt( 2.0 * Math.PI );// For normal gauss distribution with maximum in (0;1)
        private static readonly double _gaussSigma = 1.0 / _gaussCoef;
        private static readonly double gaussCoef1 = -1.0 / 2.0f * _gaussSigma * _gaussSigma;
        private static readonly double gaussCoef2 = _gaussSigma * _gaussCoef;

        private double GaussCore(double x) => Math.Exp( x * x * gaussCoef1 ) / gaussCoef2;

        private double LinearCore(double x) => 1.0 - Math.Abs( x );

        private double ConstCore(double x) => 0.5;

        #endregion

        #region Settings

        public int baseCellsCount = 100;
        public double baseRadius = 0.1;
        public Vector2D workspaceBegin = new Vector2D() { x = 0, y = 0 };
        public Vector2D workspaceSize = new Vector2D() { x = 1, y = 1 };
        public CoreType coreType = CoreType.Gauss;
        public Random random = new Random( 0 );
        public Rules rules = new Rules();
        public int averageCellsInGridCell = 3;
        public double fixedTimeStep = 0;
        public double dynamicTimeStepLimit = 1;
        public double SIRPSLimit = 0.3;
        public double borderForce = 1;
        public double borderDistance = 0.1;

        #endregion

        #region State

        private double maxRadius;
        private double minRadius;
        private double maxSIRPS; // SIPRS - speed in raduises per step
        private List<MyCell> cells;

        #endregion

        #region Near supports
        private class StaticCell
        {
            public List<int> CellIndices = new List<int>();
        }
        private int gridSizeX, gridSizeY;
        private StaticCell[,] staticGrid;
        #endregion

        public void Initialize()
        {
            cells = new List<MyCell>( baseCellsCount );
            for (int cellId = 0; cellId < cells.Count; cellId++) {
                cells[cellId] = rules.InitializeCell(
                    new Vector2D() {
                        x = workspaceBegin.x + workspaceSize.x * random.NextDouble(),
                        y = workspaceBegin.y + workspaceSize.y * random.NextDouble()
                    },
                    baseRadius,
                    random
                );
            }

            InitializeGrid();
        }

        public void PhysicStep()
        {
            for (int cellId = 0; cellId < cells.Count; cellId++) {
                var cell = cells[cellId];
                cell.physicComponent.pressure = 0;
                cell.physicComponent.speed = new Vector2D();
                foreach (int nearCellId in GetNearCells( cell )) {
                    if (nearCellId < cellId) {
                        var nearCell = cells[nearCellId];
                        double averageForce = ( GetForce( cell, nearCell ) + GetForce( nearCell, cell ) ) / 2.0;
                        cell.physicComponent.pressure += averageForce;
                        nearCell.physicComponent.pressure += averageForce;
                        Vector2D normal = ( nearCell.coord - cell.coord ).normalize;
                        cell.physicComponent.speed += averageForce / cell.physicComponent.mass * normal;
                        nearCell.physicComponent.speed -= averageForce / nearCell.physicComponent.mass * normal;
                        cells[nearCellId] = nearCell;
                    }
                }
                cells[cellId] = cell;
            }

            maxSIRPS = 0;
            foreach (var cell in cells) {
                maxSIRPS = Math.Max( cell.physicComponent.speed.length / cell.radius, maxSIRPS );
            }

            CalcMaxMinRadiuses();

            double timeStep = GetTimeStep();

            for (int cellId = 0; cellId < cells.Count; cellId++) {
                var cell = cells[cellId];
                cell.coord += cell.physicComponent.speed * timeStep;
                cells[cellId] = cell;
            }
        }
        public void LifeStep()
        {

        }

        #region Grid methods

        private void InitializeGrid()
        {
            double aspect = workspaceSize.x / workspaceSize.y;
            gridSizeY = (int)Math.Sqrt( averageCellsInGridCell * aspect / cells.Count );
            if (gridSizeY < 1) {
                gridSizeY = 1;
            }
            gridSizeX = (int)( aspect * gridSizeY );
            if (gridSizeX < 1) {
                gridSizeX = 1;
            }

            staticGrid = new StaticCell[gridSizeX, gridSizeY];

            for (int gx = 0; gx < gridSizeX; gx++) {
                for (int gy = 0; gy < gridSizeY; gy++) {
                    staticGrid[gx, gy] = new StaticCell();
                }
            }

            for (int cellId = 0; cellId < cells.Count; cellId++) {
                int gx, gy;
                (gx, gy) = GetGridCell( cells[cellId].coord );
                staticGrid[gx, gy].CellIndices.Add( cellId );
            }
        }
        private (int, int) GetGridCell(Vector2D coord)
        {
            return (GetGridCellCoord( coord, 0, gridSizeX ), GetGridCellCoord( coord, 1, gridSizeY ));
        }

        private int GetGridCellCoord(Vector2D coord, int axis, int gridSize)
        {
            int val = (int)( ( coord[axis] - workspaceBegin[axis] ) / workspaceSize[axis] * gridSize );
            if (val < 0) {
                val = 0;
            } else if (val >= gridSize) {
                val = gridSize - 1;
            }
            return val;
        }

        private IEnumerable<int> GetNearCells(MyCell cell)
        {
            Vector2D radius2 = new Vector2D() { x = maxRadius, y = maxRadius };
            (int minX, int minY) = GetGridCell( cell.coord - radius2 );
            (int maxX, int maxY) = GetGridCell( cell.coord + radius2 );
            for (int gx = minX; gx <= maxX; gx++) {
                for (int gy = minY; gy <= maxY; gy++) {
                    foreach (var cellId in staticGrid[gx, gy].CellIndices) {
                        MyCell otherCell = cells[cellId];
                        double maxRadius = Math.Max( cell.radius, otherCell.radius );
                        if (maxRadius * maxRadius >= ( cell.coord - otherCell.coord ).sqrLength) {
                            yield return cellId;
                        }
                    }
                }
            }
        }

        #endregion

        private void CalcMaxMinRadiuses()
        {
            maxRadius = 0;
            minRadius = cells[0].radius;
            foreach (var cell in cells) {
                if (cell.radius > maxRadius) {
                    maxRadius = cell.radius;
                }
                if (cell.radius < minRadius) {
                    minRadius = cell.radius;
                }
            }

        }

        private double GetCore(double x)
        {
            switch (coreType) {
                case CoreType.Const:
                    return ConstCore( x );
                case CoreType.Linear:
                    return LinearCore( x );
                case CoreType.Gauss:
                    return GaussCore( x );
                default:
                    throw new NotImplementedException();
            }
        }

        private double GetForce(MyCell cell1, MyCell cell2)
        {
            double coreValue = GetCore( ( cell2.coord - cell1.coord ).length / cell1.radius );
            double pressure = cell1.physicComponent.mass * coreValue;
            return pressure;
        }

        private double GetTimeStep()
        {
            if (fixedTimeStep > 0) {
                return fixedTimeStep;
            }

            double timeStep = SIRPSLimit / maxSIRPS;

            timeStep = Math.Min( timeStep, dynamicTimeStepLimit );

            return timeStep;
        }

        private Vector2D BorderForce(MyCell cell)
        {
            if(cell.x < workspaceBegin.x + borderDistance) {

            }
            if(cell.x > workspaceBegin.x + workspaceSize.x - borderDistance) {

            }
        }
    }
}
