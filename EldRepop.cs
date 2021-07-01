using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class EldRepop
    {

        public static string GetFaction()
        {
            var table = new RandomTable<string>();

            table.AddItem("Outlaws");
            table.AddItem("Goblins");
            table.AddItem("Draugr (Ancient Undead)");
            table.AddItem("Necromancers");
            table.AddItem("Gargoyles");
            table.AddItem("Storm Heralds");
            table.AddItem("Flamelords");
            table.AddItem("Yugoloths");
            table.AddItem("Demons");
            table.AddItem("Devils");
            table.AddItem("Dungeon Fauna");
            table.AddItem("Insects");
            table.AddItem("Unseelie");
            table.AddItem("Eldritch Horrors");
            table.AddItem("Cults");
            table.AddItem("Adventuring Parties");
            table.AddItem("Ironbound");
            table.AddItem("Rangers");
            table.AddItem("Gangrel");
            table.AddItem("Hobgoblins");
            table.AddItem("Thraxian");

            return table.GetResult();
        }

        public static string WhatsGoingOn()
        {
            var table = new RandomTable<string>();

            table.AddItem("Traders arrived to peddle wares");
            table.AddItem("Visiting Ambassadors from " + GetFaction());
            table.AddItem("Under siege from " + GetFaction());
            table.AddItem("Preparing to march on an enemy");
            table.AddItem("At war, most soldiers out to battle elsewhere.");
            table.AddItem("Hunting party returns with kill.");
            table.AddItem("Recently sacked, workmen repairing structures");
            table.AddItem("Rival adventuring party claims treasures");
            table.AddItem("Rival adventuring party captured");
            table.AddItem("Important person captured");
            table.AddItem("Celebrating holiday");
            table.AddItem("Celebrating victory over " + GetFaction());
            table.AddItem("Important object stolen");
            table.AddItem("Great feast");
            table.AddItem("Religious ritual");
            table.AddItem("Army returning defeated");
            table.AddItem("Army returning victorious with spoils");
            table.AddItem("Searching for a spy / traitor");
            table.AddItem("Duel/gladitorial combat spectacle");
            table.AddItem("Activating new magic weapon");
            table.AddItem("Disaster - magical effects on all");
            table.AddItem("Contageous Plague");
            table.AddItem("Important wedding");
            table.AddItem("Harvest");

            return table.GetResult();
        }
    }
}
