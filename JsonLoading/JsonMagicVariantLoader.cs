using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DungeonCohort
{
    class JsonMagicVariantLoader
    {
        public JsonMagicVariantRoot Root;

        public void LoadMagicVariantJsonData()
        {
            string filename = "magicvariants.json";
            string jsonData;
            try { jsonData = File.ReadAllText(filename); }
            catch (Exception)
            {
                Console.WriteLine("Could not load " + filename);
                return;
            }

            Root = 
                JsonConvert.DeserializeObject<JsonMagicVariantRoot>(jsonData);
            Console.WriteLine("Loaded " + filename);
        }
    }
}
