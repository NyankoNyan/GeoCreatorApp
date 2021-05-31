using System;

namespace GeoLibs
{
    public class ValueLayer<T> : Layer
    {
        public double toIntMultiplication = 1;
        private T[,] storage;

        public ValueLayer(LayerInfo layerInfo)
        {
            this.layerInfo = layerInfo;
            CreateStorage();
        }

        public override int GetValue(double x, double y) => Convert.ToInt32( GetLayerValue( x, y ) );

        public void SetValue(int x, int y, T value) => storage[x, y] = value;

        public T GetLayerValue(double x, double y)
        {
            int xi = (int)( layerInfo.resolutionX * x );
            if (xi < 0) {
                xi = 0;
            } else if (xi >= layerInfo.resolutionX) {
                xi = layerInfo.resolutionX - 1;
            }
            int yi = (int)( layerInfo.resolutionY * y );
            if (yi < 0) {
                yi = 0;
            } else if (yi >= layerInfo.resolutionY) {
                yi = layerInfo.resolutionY - 1;
            }
            return storage[xi, yi];
        }

        private void CreateStorage()
        {
            storage = new T[layerInfo.resolutionX, layerInfo.resolutionY];
        }
    }
}
