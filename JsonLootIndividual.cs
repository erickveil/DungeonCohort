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

        /// <summary>
        /// Returns a table to roll for individual loot on.
        /// The coin results are generated with the table, so you should 
        /// re-create the table each time you roll on it.
        /// </summary>
        /// <returns></returns>
        public RandomTable<LootTableResult> AsRollableTable()
        {
            var lootTable = new RandomTable<LootTableResult>();
            foreach (var record in table)
            {
                var weight = (uint)(record.max - record.min + 1);

                var tableEntry = new LootTableResult();
                JsonLootCoins coinData = record.coins;

                tableEntry.CP = coinData.rollCp();
                tableEntry.SP = coinData.rollSp();
                tableEntry.EP = coinData.rollEp();
                tableEntry.GP = coinData.rollGp();
                tableEntry.PP = coinData.rollPp();

                lootTable.AddItem(tableEntry, weight);
            }
            return lootTable;
        }


    }
}
