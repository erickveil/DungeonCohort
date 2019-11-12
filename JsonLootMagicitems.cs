using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class JsonLootMagicitems
    {
        public string name;
        public string source;
        public int page;
        public string type;
        public List<JsonLootMagicitemsTableEntry> table = 
            new List<JsonLootMagicitemsTableEntry>();

        private JsonItemRoot _itemResource;

        public void Init(JsonItemRoot itemResource)
        {
            _itemResource = itemResource;
        }

        public RandomTable<MagicItems> AsRollableTable()
        {
            var itemTable = new RandomTable<MagicItems>();
            foreach (JsonLootMagicitemsTableEntry entry in table)
            {
                uint weight = (uint)(entry.max - entry.min + 1);

                JsonItem itemData = _itemResource.GetItemById(entry.GetItemId());
                MagicItems magicItem = itemData.AsMagicItem();

                itemTable.AddItem(magicItem, weight); 
            }
            return itemTable;
        }

    }
}
