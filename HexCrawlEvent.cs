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

            table.AddItem("Abandoned camp", 2);
            table.AddItem("NPC camp");
            table.AddItem("Monster encounter", 16);
            table.AddItem("Travelers: " + ChooseTravelers());
            table.AddItem("Marching army");
            table.AddItem("Battle: " + ChooseBattleType());
            table.AddItem("Fire");
            table.AddItem("Flood");
            // special encounters
            // challenges

            return table.GetResult();
        }

        public static string ChooseTravelers()
        {
            var table = new RandomTable<string>();

            table.AddItem("Merchant caravan");
            table.AddItem("Pilgrimage");
            table.AddItem("Huntsmen");
            table.AddItem("Trappers");
            table.AddItem("Lost individual");
            table.AddItem("NPC party");
            table.AddItem("NPC on a quest");
            table.AddItem("Injured");
            table.AddItem("Family settlers");

            return table.GetResult();
        }

        public static string ChooseBattleType()
        {
            var table = new RandomTable<string>();

            table.AddItem("Warfare");
            table.AddItem("NPC party vs. Monsters");
            table.AddItem("Ambushed travelers (" + ChooseTravelers() + ")");
            table.AddItem("Single combat");

            return table.GetResult();
        }
    }
}
