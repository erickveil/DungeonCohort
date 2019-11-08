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
    class JsonItemLoader
    {
        JsonItemRoot _itemObj;

        public void LoadItemJsonData()
        {
            string filename = "items.json";
            string jsonData;
            try { jsonData = File.ReadAllText(filename); }
            catch (Exception)
            {
                Console.WriteLine("Could not load " + filename);
                return;
            }

            _itemObj = JsonConvert.DeserializeObject<JsonItemRoot>(jsonData);

            Console.WriteLine("Loaded " + filename);
        }


    }
}
