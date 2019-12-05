using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class EncounterComponent
    {
        public Ancestry Monster;
        public int Qty;

        public string AsString()
        {
            string name = Monster.GetCompositeName();
            // TODO: Random names pluralize?
            return Qty.ToString() + " " + Monster.GetCompositeName()
                + " (CR " + Monster.CR + ")"
                ;
        }
    }
}
