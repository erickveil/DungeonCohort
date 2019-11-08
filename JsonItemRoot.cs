using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DungeonCohort
{
    class JsonItemRoot
    {
        public JObject _meta;

        public List<JsonItem> item = new List<JsonItem>();

        public JArray itemGroup;
    }
}
