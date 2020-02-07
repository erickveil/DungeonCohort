using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class Quests
    {

        public static string CreateQuest()
        {
            var table = new RandomTable<string>();

            table.AddItem("Kill target");
            table.AddItem("Capture target");
            table.AddItem("Deliver item/message");
            table.AddItem("Escort/guard");
            table.AddItem("Bring back item");
            table.AddItem("Bring back multiple items");
            table.AddItem("Kill multiple targets");
            table.AddItem("Convince NPC");
            table.AddItem("Withstand waves of attackers");
            table.AddItem("Secure location");
            table.AddItem("Clear dungeon/area");
            table.AddItem("Destroy/sabotage target");
            table.AddItem("Destroy item");
            table.AddItem("Investigate: " + InvestigationType());
            table.AddItem("Rescue");

            return table.GetResult();
        }

        public static string InvestigationType()
        {
            var table = new RandomTable<string>();

            table.AddItem("Murder");
            table.AddItem("Missing person");
            table.AddItem("Theft");
            table.AddItem("Person of interest");
            table.AddItem("Embezzlement");
            table.AddItem("Target strength");
            table.AddItem("Obtain plans");
            table.AddItem("Lair/dungeon location");

            return table.GetResult();
        }
    }
}
