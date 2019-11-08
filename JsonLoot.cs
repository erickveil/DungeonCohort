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
    class JsonLoot
    {
        public List<JsonLootGemstones> gemstones = 
            new List<JsonLootGemstones>();

        public List<JsonLootArt> artobjects =
            new List<JsonLootArt>();

        public List<JsonLootIndividual> individual =
            new List<JsonLootIndividual>();

        public List<JsonLootHoard> hoard =
            new List<JsonLootHoard>();

        public List<JsonLootMagicitems> magicitems =
            new List<JsonLootMagicitems>();

        public void Init()
        {
            foreach (var hoardData in hoard) { hoardData.Init(this); }
        }

        public RandomTable<LootTableResult> GetIndividualLootTable(int tier)
        {
            if (tier < 1) { tier = 1; }
            if (tier > 4) { tier = 4; }
            int tableIndex = tier - 1;
            return individual[tableIndex].AsRollableTable();
        }

        public RandomTable<LootTableResult> GetHordeLootTable(int tier)
        {
            if (tier < 1) { tier = 1; }
            if (tier > 4) { tier = 4; }
            int tableIndex = tier - 1;
            return hoard[tableIndex].AsRollableTable();
        }

        public RandomTable<Gemstones> GetGemstoneTable(string type)
        {
            foreach (var gemData in gemstones)
            {
                if (type != gemData.type) { continue; }
                return gemData.AsRollableTable();
            }
            Console.WriteLine("Could not find gem table for type: " + type);
            return gemstones[0].AsRollableTable();
        }
        
    }
}
