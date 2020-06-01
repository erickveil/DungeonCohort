using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCohort.JsonLoading;
using Darkmoor;

namespace DungeonCohort
{
    class TreasureFactory
    {
        JsonLootLoader _lootLoader;

        public TreasureFactory()
        {
            _lootLoader = JsonLootLoader.Instance;
        }

        public LootTableResult GetIndividualTreasure(int tier, 
            MagicItemPermissions allowedItems)
        {
            var lootTable = _lootLoader.GetIndividualLootTable(tier);
            LootTableResult loot = lootTable.GetResult();
            loot.PurgeResults(allowedItems);
            _addSpellsToScrolls(loot);
            return loot;
        }
        public LootTableResult GetIndividualTreasure(int tier)
        {
            var lootTable = _lootLoader.GetIndividualLootTable(tier);
            LootTableResult loot = lootTable.GetResult();
            var allowedItems = new MagicItemPermissions();
            loot.PurgeResults(allowedItems);
            _addSpellsToScrolls(loot);
            return loot;
        }

        public LootTableResult GetTreasureHoard(int tier,
            MagicItemPermissions allowedItems, bool isSpellbooksInHorde)
        {
            var lootTable = _lootLoader.GetHordeLootTable(tier, isSpellbooksInHorde);
            LootTableResult loot = lootTable.GetResult();
            loot.PurgeResults(allowedItems);
            _addSpellsToScrolls(loot);
            return loot;
        }

        public MagicItems GetMagicItem(int tier, MagicItemPermissions allowedItems)
        {
            // TODO: Chose a valid type and result based on tier/allowedItems
            var typeTable = new RandomTable<string>();
            typeTable.AddItem("A");
            typeTable.AddItem("B");
            typeTable.AddItem("C");
            typeTable.AddItem("D");
            typeTable.AddItem("E");
            typeTable.AddItem("F");
            typeTable.AddItem("G");
            typeTable.AddItem("H");
            typeTable.AddItem("I");

            string type = typeTable.GetResult();
            var lootTable = _lootLoader.GetMagicItemTable(type);
            MagicItems item = lootTable.GetResult();
            return item;
        }

        private void _addSpellsToScrolls(LootTableResult loot)
        {
            foreach (var item in loot.MagicItemList)
            {
                JsonSpell spell = 
                    JsonSpellLoader.GetScrollSpell(item.name);
                if (spell is null) { continue; }
                item.scrollSpell = spell;
            }

        }
    }
}
