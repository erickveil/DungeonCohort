using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class Descriptors
    {

        public static string Color()
        {
            var table = new RandomTable<string>();

            table.AddItem("red");
            table.AddItem("orange");
            table.AddItem("yellow");
            table.AddItem("green");
            table.AddItem("blue");
            table.AddItem("purple");
            table.AddItem("black");
            table.AddItem("white");
            table.AddItem("grey");

            return table.GetResult();
        }

        public static string UnusualObjectDescriptor()
        {
            var table = new RandomTable<string>();

            table.AddItem("Shimmering");
            table.AddItem("Glowing");
            table.AddItem("Smoking");
            table.AddItem("Humming");
            table.AddItem("Guilded");
            table.AddItem("Crystaline");
            table.AddItem("Strange-metal");
            table.AddItem("Vibrating");
            table.AddItem("Demonic");
            table.AddItem("Rune-etched");
            table.AddItem(Color() + " Glass");
            table.AddItem("Floating");
            table.AddItem("Unnerving");
            table.AddItem("Fiendish");
            table.AddItem("Calming");
            table.AddItem("Alien");
            table.AddItem("Etched");
            table.AddItem("Spiked");
            table.AddItem("Enamled");
            table.AddItem("Unholy");
            table.AddItem("Holy");
            table.AddItem("Throbbing");
            table.AddItem("Tingling");
            table.AddItem("Wooshing");
            table.AddItem("Gem-encrusted");
            table.AddItem("Golden");
            table.AddItem("Silver");
            table.AddItem("Sparkeling");
            table.AddItem("Cold iron");
            table.AddItem("Beleful");

            return table.GetResult();
        }
    }
}
