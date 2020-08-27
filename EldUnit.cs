using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class EldUnit
    {
        public string Name;
        public string CR;
        public int NumAppearing = -1;
        public string Type;

        public EldUnit(string name, string cr)
        {
            Name = name;
            CR = cr;
        }

        public EldUnit(string name, string cr, int lvl)
        {
            Name = name;
            CR = cr;
            NumAppearing = CalcNumAppearing(lvl);
        }

        public string ToString(int lvl)
        {
            if (NumAppearing < 1) { NumAppearing = CalcNumAppearing(lvl); }
            return NumAppearing.ToString() + " " + Name;
        }

        public int CalcNumAppearing(int lvl)
        {
            var die = Dice.Instance;
            if (lvl == 1)
            {
                switch(CR)
                {
                    case "0":
                        return die.Roll(1, 8) + 5;
                    case "1/8":
                        return die.Roll(1, 4) + 2;
                    case "1/4":
                        return die.Roll(1, 2) + 1;
                    case "1/2":
                        return die.Roll(1, 2);
                    case "1":
                        return 1;
                    default:
                        return 1;
                }
            }
            else
            {
                switch(CR)
                {
                    case "0":
                        return die.Roll(1, 10) + 9;
                    case "1/8":
                        return die.Roll(1, 6) + 4;
                    case "1/4":
                        return die.Roll(1, 4) + 2;
                    case "1/2":
                        return die.Roll(1, 2) + 2;
                    case "1":
                        return die.Roll(1, 2);
                    default:
                        return 1;
                }
            }
        }
    }
    
}
