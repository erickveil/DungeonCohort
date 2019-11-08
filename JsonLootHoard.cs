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

        private Dice _dice;

        private JsonLoot _hoardItemSource;

        public JsonLootHoard()
        {
            _dice = Dice.Instance;
        }

        public void Init(JsonLoot hoardItemSource)
        {
            _hoardItemSource = hoardItemSource;
        }

        public RandomTable<LootTableResult> AsRollableTable()
        {
            var lootTable = new RandomTable<LootTableResult>();
            foreach (var record in table)
            {
                var tableEntry = new LootTableResult();
                var weight = (uint)(record.max - record.min + 1);

                tableEntry.CP = coins.rollCp();
                tableEntry.SP = coins.rollSp();
                tableEntry.EP = coins.rollEp();
                tableEntry.GP = coins.rollGp();
                tableEntry.PP = coins.rollPp();

                tableEntry = _addGemsToHord(tableEntry, record.gems);

                lootTable.AddItem(tableEntry, weight);
            }
            return lootTable;
        }

        private LootTableResult _addGemsToHord(LootTableResult source, 
            JsonLootHordeTableEntryStuff gemData)
        {
            if (gemData is null) { return source; }

            int numGems = _dice.Roll(gemData.amount);
            string type = gemData.type;

            var gemstoneTable = _hoardItemSource.GetGemstoneTable(type);
            var gemCache = gemstoneTable.GetResult();
            gemCache.qty = numGems;
            source.Gems = gemCache;

            return source;
        }


    }
}
