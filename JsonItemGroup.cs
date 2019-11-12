using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class JsonItemGroup
    {
        public string name;
        public string type;
        public float weight;
        public string tier;
        public string rarity;
        public string source;
        public int page;
        public List<string> items = new List<string>();
        public List<string> lootTables = new List<string>();

        public string ChooseGroupItemName()
        {
            var table = new RandomTable<string>();

            foreach (string name in items) { table.AddItem(name); }
            return table.GetResult();
        }
    }
}
