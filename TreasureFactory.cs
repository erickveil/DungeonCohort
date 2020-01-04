using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCohort.JsonLoading;

namespace DungeonCohort
{
    class TreasureFactory
    {
        JsonLootLoader _lootLoader;
        JsonSpellLoader _spellLoader;

        public TreasureFactory()
        {
            _lootLoader = JsonLootLoader.Instance;
            _spellLoader = new JsonSpellLoader();
            _spellLoader.LoadAllSpells();
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
            MagicItemPermissions allowedItems)
        {
            var lootTable = _lootLoader.GetHordeLootTable(tier);
            LootTableResult loot = lootTable.GetResult();
            loot.PurgeResults(allowedItems);
            _addSpellsToScrolls(loot);
            return loot;
        }

        private void _addSpellsToScrolls(LootTableResult loot)
        {
            foreach (var item in loot.MagicItemList)
            {
                JsonSpell spell = 
                    JsonSpellLoader.GetScrollSpell(item.name, _spellLoader);
                if (spell is null) { continue; }
                item.scrollSpell = spell;
            }

        }
    }
}
