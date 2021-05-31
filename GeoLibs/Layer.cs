namespace GeoLibs
{
    public abstract class Layer
    {
        public LayerInfo layerInfo;
        public abstract int GetValue(double x, double y);
    }
}
