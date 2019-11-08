using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DungeonCohort
{
    class JsonLootHoard
    {
        public string name;
        public string source;
        public int page;
        public int mincr;
        public int maxcr;

        public JsonLootCoins coins;

        public List<JsonLootHordeTableEntry> table =
            new List<JsonLootHordeTableEntry>();


    }
}
