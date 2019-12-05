using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DungeonCohort
{

    class JsonLootMagicitemsTableEntryChose
    {
        public List<string> fromGroup = new List<string>();
        public List<string> fromGeneric = new List<string>();

        public string GetIdFromGroup()
        {
            return fromGroup[0];
        }
    }

    class JsonLootMagicitemsTableEntry
    {
        public int min;
        public int max;
        public string item;
        public JsonLootMagicitemsTableEntryChose choose;

        public string GetItemId()
        {
            if (!(item is null)) { return item; }
            if (choose.fromGroup.Count != 0) { return choose.fromGroup[0]; }
            if (choose.fromGeneric.Count != 0) { return choose.fromGeneric[0]; }
            Console.WriteLine("Could not determine ID.");
            return null;
        }

        public bool IsBasicItem()
        {
            return !(item is null);
        }

        public bool IsGroupItem()
        {
            return choose.fromGroup.Count != 0;
        }

        public bool IsGenericItem()
        {
            return choose.fromGeneric.Count != 0;
        }
    }
}
