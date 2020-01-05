using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Darkmoor;
using DungeonCohort.JsonLoading;

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

        public RandomTable<LootTableResult> AsRollableTable(int tier)
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
                tableEntry = _addArtToHoard(tableEntry, record.artobjects);
                tableEntry = _addMagicItemsToHoard(tableEntry, 
                    record.magicitems);
                tableEntry = _addSpellbookToHoard(tableEntry, tier);

                tableEntry.SetContainer(tier);

                lootTable.AddItem(tableEntry, weight);
            }
            return lootTable;
        }

        private LootTableResult _addSpellbookToHoard(LootTableResult baseEntry, int tier)
        {
            var dice = Dice.Instance;
            bool isHasBook = dice.Roll(1, 100) <= 15;
            if (!isHasBook) { return baseEntry; }
            var spellbook = new MagicItems();
            spellbook.InitAsWizardSpellbook(tier);
            baseEntry.MagicItemList.Add(spellbook);
            return baseEntry;
        }

        private LootTableResult _addGemsToHord(LootTableResult baseEntry, 
            JsonLootHordeTableEntryStuff gemData)
        {
            if (gemData is null) { return baseEntry; }

            int numGems = _dice.Roll(gemData.amount);
            string type = gemData.type;

            var gemstoneTable = _hoardItemSource.GetGemstoneTable(type);
            var gemCache = gemstoneTable.GetResult();
            gemCache.qty = numGems;
            baseEntry.Gems = gemCache;

            return baseEntry;
        }

        private LootTableResult _addArtToHoard(LootTableResult baseEntry, 
            JsonLootHordeTableEntryStuff artData)
        {
            if (artData is null) { return baseEntry; }

            int numItems = _dice.Roll(artData.amount);
            string type = artData.type;
            var artTable = _hoardItemSource.GetArtTable(type);

            for (int i = 0; i < numItems; ++i)
            {
                var artObject = artTable.GetResult();
                baseEntry.ArtList.Add(artObject);
            }

            return baseEntry;
        }

        private LootTableResult _addMagicItemsToHoard(LootTableResult baseEntry,
            JsonLootHordeTableEntryStuff magicData)
        {
            if (magicData is null) { return baseEntry; }

            int numItems = _dice.Roll(magicData.amount);
            string type = magicData.type;
            var magicItemTable = _hoardItemSource.GetMagicItemTable(type);

            for (int i = 0; i < numItems; ++i)
            {
                // sometimew we customise an item after it's been saved.
                // so we want a copy of that item.
                var magicItem = magicItemTable.GetResult();
                baseEntry.MagicItemList.Add(magicItem.Copy());
            }

            return baseEntry;
        }


    }
}
