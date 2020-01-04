using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DungeonCohort
{
    class JsonMagicVariantRoot
    {
        public List<JsonMagicVariants> variant = new List<JsonMagicVariants>();

        public JsonMagicVariants GetVariantByName(string name)
        {
            foreach (var variantData in variant)
            {
                if (variantData.name != name) { continue; }
                return variantData;
            }
            //Console.WriteLine("Could not find magicVariant by name: " + name);
            // We're going to make one up so it's not excluded and I don't
            // have to navigate json that wasn't built with my use in mind.

            // remove some formatting
            name = _removeSubstring("{@item ", name);
            name = _removeSubstring("}", name);

            var newVariant = new JsonMagicVariants();
            newVariant.name = name;
            newVariant.type = "";
            newVariant.requires = new JArray();

            var inherits = new JsonMagicVariantsInherits();
            inherits.entries = new JArray();
            inherits.lootTables = new JArray();

            newVariant.inherits = inherits;
            
            return newVariant;
        }

        private string _removeSubstring(string needle, string haystack)
        {
            int index = haystack.IndexOf(needle);
            string cleanString = (index < 0)
                ? haystack
                : haystack.Remove(index, needle.Length);
            return cleanString;
        }

    }
}
