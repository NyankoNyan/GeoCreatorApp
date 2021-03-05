namespace GeoLibs
{
    public abstract class Noise
    {
        public double scale, offsetX, offsetY;
        public abstract double Generate(double x, double y);
    }
}
