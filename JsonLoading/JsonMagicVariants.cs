using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DungeonCohort
{
    class JsonMagicVariants
    {
        public string name;
        public string type;
        public JArray requires;
        public JsonMagicVariantsInherits inherits;
    }
}
