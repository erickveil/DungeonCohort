using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class JsonLootCoins
    {
        public string cp;
        public string sp;
        public string ep;
        public string gp;
        public string pp;

        private Dice _dice;

        public JsonLootCoins ()
        {
            _dice = Dice.Instance;
        }

        public int rollCp()
        {
            if (cp is null || cp == "") { return 0; }
            return _dice.Roll(cp);
        }

        public int rollSp()
        {
            if (sp is null || sp == "") { return 0; }
            return _dice.Roll(sp);
        }

        public int rollEp()
        {
            if (ep is null || ep == "") { return 0; }
            return _dice.Roll(ep);
        }

        public int rollGp()
        {
            if (gp is null || gp == "") { return 0; }
            return _dice.Roll(gp);
        }

        public int rollPp()
        {
            if (pp is null || pp == "") { return 0; }
            return _dice.Roll(pp);
        }
    }
}
