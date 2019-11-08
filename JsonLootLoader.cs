using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Darkmoor;

namespace DungeonCohort
{

    class JsonLootLoader
    {
        JsonLoot _lootObj;

        public void LoadLootJsonData()
        {
            string filename = "loot.json";
            string jsonData;
            try { jsonData = File.ReadAllText(filename); }
            catch (Exception)
            {
                Console.WriteLine("Could not load loot json data.");
                return;
            }

            // load the easy items
            _lootObj = JsonConvert.DeserializeObject<JsonLoot>(jsonData);

            Console.WriteLine("Loaded " + filename);
        }

        public RandomTable<LootTableResult> GetIndividualLootTable(int tier)
        {
            return _lootObj.GetIndividualLootTable(tier);
        }
    }
}
