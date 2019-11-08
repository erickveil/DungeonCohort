using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Darkmoor;

namespace DungeonCohort
{
    class JsonLootIndividual
    {
        public string name;
        public string source;
        public int page;
        public int mincr;
        public int maxcr;

        public List<JsonLootIndividualCoins> table = 
            new List<JsonLootIndividualCoins>();

        public RandomTable<LootTable> AsRollableTable()
        {
            RandomTable<LootTable> table;
            foreach (var record in table)
            {
                int weight = record.max - record.min + 1;
            }
            return table;
        }


    }
}
