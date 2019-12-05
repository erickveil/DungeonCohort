using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("Could not find magicVariant by name: " + name);
            return null;
        }
    }
}
