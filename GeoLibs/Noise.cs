namespace GeoLibs
{
    public abstract class Noise:IByCoordSource
    {
        public double scale, offsetX, offsetY;
        public abstract double Generate(double x, double y);

        public double GetValue(double x, double y)
        {
            return Generate( x, y );
        }
    }
}
