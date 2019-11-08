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
            _lootObj.Init();

            Console.WriteLine("Loaded " + filename);
        }

        public RandomTable<LootTableResult> GetIndividualLootTable(int tier)
        {
            return _lootObj.GetIndividualLootTable(tier);
        }

        public RandomTable<LootTableResult> GetHordeLootTable(int tier)
        {
            return _lootObj.GetHordeLootTable(tier);
        }

        public RandomTable<Gemstones> GetGemstoneTable(string type)
        {
            return _lootObj.GetGemstoneTable(type);
        }

        public RandomTable<ArtObjects> GetArtTable(string type)
        {
            return _lootObj.GetArtTable(type);
        }
    }
}
