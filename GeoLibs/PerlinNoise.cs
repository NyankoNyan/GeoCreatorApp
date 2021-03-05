namespace GeoLibs
{
    public class PerlinNoise : Noise
    {
        public double offsetZ, persistence;
        public int octaves;

        private static Perlin perlinMath;

        static PerlinNoise()
        {
            perlinMath = new Perlin();
        }
        public override double Generate(double x, double y)
        {
            return Clamp( perlinMath.OctavePerlin( x * scale + offsetX, y * scale + offsetY, offsetZ, octaves, persistence ) );
        }

        private static double Clamp(double val)
        {
            if (val < 0) {
                return 0;
            } else if (val > 1.0) {
                return 1.0;
            }
            return val;
        }
    }
}
