using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DungeonCohort
{
    class JsonMagicVariantsInherits
    {
        public string genericBonus;
        public string tier;
        public string rarity;
        public string source;
        public int page;
        public string nameSuffix;
        public JArray entries;
        public JArray lootTables;
    }
}
