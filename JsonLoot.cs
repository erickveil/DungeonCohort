using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DungeonCohort
{
    class JsonLoot
    {
        public List<JsonLootGemstones> gemstones = 
            new List<JsonLootGemstones>();
    }
}
