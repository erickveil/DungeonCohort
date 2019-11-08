using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
