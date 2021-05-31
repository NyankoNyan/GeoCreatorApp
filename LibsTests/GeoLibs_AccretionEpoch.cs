using NUnit.Framework;
using GeoLibs;
using System.Collections.Generic;

namespace LibsTests
{
    [TestFixture]
    public class GeoLibs_AccretionEpoch
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestMainInterface()
        {
            MaterialCollection materialCollection = new MaterialCollection();
            AccretionEpoch accretionEpoch = new AccretionEpoch() {
                materialCollection = materialCollection
            };
            const int resX = 128;
            const int resY = 128;
            accretionEpoch.generationsParams.Add( new AccretionEpoch.GenerationParams() {
                name = "Stone layer 1",
                material = "Stone",
                resolutionX = resX,
                resolutionY = resY,
                source = new PerlinNoise( offsetZ: 0 )
            } );
            accretionEpoch.generationsParams.Add( new AccretionEpoch.GenerationParams() {
                name = "Iron layer",
                material = "RawIron",
                resolutionX = resX,
                resolutionY = resY,
                source = new PerlinNoise( offsetZ: 1 )
            } );
            accretionEpoch.generationsParams.Add( new AccretionEpoch.GenerationParams() {
                name = "Stone layer 2",
                material = "Stone",
                resolutionX = resX,
                resolutionY = resY,
                source = new PerlinNoise( offsetZ: 2 )
            } );
            List<Layer> layers = accretionEpoch.GenerateLayers();
            Assert.IsNotNull( layers );
        }
    }
}