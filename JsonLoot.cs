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


        public RandomTable<LootTableResult> GetIndividualLootTable(int tier)
        {
            if (tier < 1) { tier = 1; }
            if (tier > 4) { tier = 4; }
            int tableIndex = tier - 1;
            return individual[tableIndex].AsRollableTable();
        }
        
    }
}
