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

        public PerlinNoise(double scale = 1, double offsetX = 0, double offsetY = 0, double offsetZ = 0, int octaves = 1, double persistence = 0.5)
        {
            this.scale = scale;
            this.offsetX = offsetX;
            this.offsetY = offsetY;
            this.offsetZ = offsetZ;
            this.octaves = octaves;
            this.persistence = persistence;
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
