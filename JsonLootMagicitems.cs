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
        public List<JsonLootMagicitemsTable> table = 
            new List<JsonLootMagicitemsTable>();

        private JsonItemRoot _itemResource;

        public void Init(JsonItemRoot itemResource)
        {
            _itemResource = itemResource;
        }

        public RandomTable<MagicItems> AsRollableTable()
        {
            var itemTable = new RandomTable<MagicItems>();
            foreach (var entry in table)
            {
                uint weight = (uint)(entry.max - entry.min + 1);
                var item = new MagicItems();

                // TODO: fill out magic item object with item json data held in jsonItemRoot
                item.name = entry.item;

                itemTable.AddItem(item, weight); 
            }
            return itemTable;
        }

    }
}
