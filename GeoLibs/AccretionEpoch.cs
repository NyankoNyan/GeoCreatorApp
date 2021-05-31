using System.Collections.Generic;

namespace GeoLibs
{
    public class AccretionEpoch : Epoch, ITreeAccess
    {
        public struct GenerationParams
        {
            public string name;
            public int resolutionX, resolutionY;
            public string material;
            public IByCoordSource source;
        }
        public List<GenerationParams> generationsParams = new List<GenerationParams>();
        private List<Layer> layers;

        #region ITreeAccess
        int ITreeAccess.Id => throw new System.NotImplementedException();

        string ITreeAccess.Name => throw new System.NotImplementedException();

        string ITreeAccess.Type => throw new System.NotImplementedException();

        int ITreeAccess.ChildrenCount => throw new System.NotImplementedException();

        IEnumerable<ITreeAccess> ITreeAccess.Children => throw new System.NotImplementedException();
        #endregion

        private void CreateAccretionLayers()
        {
            layers = new List<Layer>();
            foreach (GenerationParams generationParams in generationsParams) {
                ValueLayer<float> layer = new ValueLayer<float>( new LayerInfo() {
                    material = materialCollection.GetMaterial( generationParams.material ),
                    name = generationParams.name,
                    resolutionX = generationParams.resolutionX,
                    resolutionY = generationParams.resolutionY
                } );
                for (int x = 0; x < generationParams.resolutionX; x++) {
                    for (int y = 0; y < generationParams.resolutionY; y++) {
                        layer.SetValue( x, y, (float)generationParams.source.GetValue( x / generationParams.resolutionX, y / generationParams.resolutionY ) );
                    }
                }
                layers.Add( layer );
            }
        }

        public List<Layer> GenerateLayers()
        {
            CreateAccretionLayers();
            return layers;
        }
    }
}
