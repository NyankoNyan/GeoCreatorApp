using System.Collections.Generic;

namespace GeoLibs
{
    public class MaterialCollection
    {
        private Dictionary<string, int> names = new Dictionary<string, int>();
        private int counter = 0;
        public int GetMaterial(string name)
        {
            if (!names.TryGetValue( name, out int id )) {
                id = ++counter;
                names.Add( name, id );
            }
            return id;
        }
    }
}
