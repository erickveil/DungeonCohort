using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCohort
{
    class MagicItems
    {
        public string name;

        // TODO: These need to be set!
        public string rarity;
        public string type; // major/minor

        public JsonSpell scrollSpell = null;

        public override string ToString()
        {
            if (!(scrollSpell is null))
            {
                return name + " - " + scrollSpell.ToString();
            }

            return name;
        }

        public MagicItems Copy()
        {
            var copy = new MagicItems();
            copy.name = name;
            copy.rarity = rarity;
            copy.type = type;
            // NOTE: does not copy the spell object, as this is most often unique.
            return copy;
        }

    }
}
