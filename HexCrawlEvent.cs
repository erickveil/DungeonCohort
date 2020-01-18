using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class HexCrawlEvent
    {
        public string CurrentEvent;

        public void Init()
        {
            CurrentEvent = ChooseEvent();
        }

        public override string ToString()
        {
            return CurrentEvent;
        }

        public static string ChooseEvent()
        {
            var table = new RandomTable<string>();

            table.AddItem("Monster encounter");
            table.AddItem(ChooseSpecialEncounter());

            return table.GetResult();
        }

        public static string ChooseSpecialEncounter()
        {
            var table = new RandomTable<string>();

            table.AddItem("Abandoned camp", 2);
            table.AddItem("Travelers: " + ChooseTravelers());
            table.AddItem("Marching army");
            table.AddItem("Battle: " + ChooseBattleType());
            table.AddItem("Fire");
            table.AddItem("Flood");
            table.AddItem("Camp (tents): " + ChooseCampDwellers());
            table.AddItem("Smouldering remains of a funeral pyre");
            table.AddItem("Dead body hanging form tree");
            table.AddItem("Wandering riding horse with saddle. Looks injured and tired.");
            table.AddItem("Naked virgin on altar surrounded by cultists");
            table.AddItem("Escaped prisoner being chased");
            table.AddItem("Thugs digging up stolen treasure");
            table.AddItem("Animal herd");

            // challenges

            return table.GetResult();

        }

        public static string ChooseCampDwellers()
        {
            var table = new RandomTable<string>();

            table.AddItem("Abandoned");
            table.AddItem("Bandits");
            table.AddItem("Army");
            table.AddItem("NPC party");
            table.AddItem(ChooseTravelers());

            return table.GetResult();
        }

        public static string ChooseTravelers()
        {
            var table = new RandomTable<string>();

            table.AddItem("Merchant caravan");
            table.AddItem("Pilgrims (can offer healing)");
            table.AddItem("Huntsmen");
            table.AddItem("Trappers");
            table.AddItem("Lost individual");
            table.AddItem("NPC party");
            table.AddItem("NPC on a quest");
            table.AddItem("Injured");
            table.AddItem("Family settlers with covered wagon");
            table.AddItem("Unconcious, tied up (victem of bandits)");
            table.AddItem("Gypsies with wagon");
            table.AddItem("Diseased - skin sores");
            table.AddItem("Lunatic shouting random sentances");
            table.AddItem("Beggar - asks for coin or food");
            table.AddItem("Guard patrol");

            return table.GetResult();
        }

        public static string ChooseBattleType()
        {
            var table = new RandomTable<string>();

            table.AddItem("Warfare");
            table.AddItem("NPC party vs. Monsters");
            table.AddItem("Ambushed travelers (" + ChooseTravelers() + ")");
            table.AddItem("Single combat");
            table.AddItem("Mage duel");

            return table.GetResult();
        }
    }
}
