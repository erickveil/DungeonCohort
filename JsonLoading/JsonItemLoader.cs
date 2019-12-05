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

        internal JsonItemRoot ItemObj { get => _itemObj; set => _itemObj = value; }

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

            ItemObj = JsonConvert.DeserializeObject<JsonItemRoot>(jsonData);

            Console.WriteLine("Loaded " + filename);
        }


    }
}
