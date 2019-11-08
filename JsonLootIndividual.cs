using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DungeonCohort
{
    class JsonLootIndividual
    {
        public string name;
        public string source;
        public int page;
        public int mincr;
        public int maxcr;

        public List<JsonLootIndividualCoins> table = 
            new List<JsonLootIndividualCoins>();
    }
}
