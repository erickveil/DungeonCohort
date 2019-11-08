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
    class JsonLootHoard
    {
        public string name;
        public string source;
        public int page;
        public int mincr;
        public int maxcr;

        public JsonLootCoins coins;

        public List<JsonLootHordeTableEntry> table =
            new List<JsonLootHordeTableEntry>();

        public RandomTable<LootTableResult> AsRollableTable()
        {
            var lootTable = new RandomTable<LootTableResult>();
            foreach (var record in table)
            {
                var tableEntry = new LootTableResult();

                tableEntry.CP = coins.rollCp();
                tableEntry.SP = coins.rollSp();
                tableEntry.EP = coins.rollEp();
                tableEntry.GP = coins.rollGp();
                tableEntry.PP = coins.rollPp();

                lootTable.AddItem(tableEntry);
            }
            return lootTable;
        }


    }
}
