using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return loot;
        }

        public LootTableResult GetTreasureHoard(int tier,
            MagicItemPermissions allowedItems)
        {
            var lootTable = _lootLoader.GetHordeLootTable(tier);
            LootTableResult loot = lootTable.GetResult();
            loot.PurgeResults(allowedItems);
            return loot;

        }
    }
}
