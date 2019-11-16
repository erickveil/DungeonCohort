using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCohort
{
    class Encounter
    {
        public List<EncounterComponent> MemberList = new List<EncounterComponent>();

        public string AsString()
        {
            string output = "";
            foreach (var member in MemberList)
            {
                output += member.AsString() + "\n";
            }
            output += "Total xp: " + GetTotalXpv().ToString();

            return output;
        }

        public int GetTotalXpv()
        {
            int xpv = 0;
            foreach (var member in MemberList)
            {
                var xp = member.Monster.GetXpValue();
                xp = xp * member.Qty;
                xpv += xp;
                
            }
            return xpv;
        }
    }
}
