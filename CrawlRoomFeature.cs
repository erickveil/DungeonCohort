using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class CrawlRoomFeature
    {
        public string Descriptor = "";

        public void Init()
        {
            var table = new RandomTable<string>();

            table.AddItem("", 80);
            table.AddItem("Flooded");
            table.AddItem("Cobwebed");
            table.AddItem("Cracked");
            table.AddItem("Dripping");
            table.AddItem("Damp");
            table.AddItem("Bloody");
            table.AddItem("Dung-covered");
            table.AddItem("Dusty");
            table.AddItem("Fungal");
            table.AddItem("Moldy");
            table.AddItem("Leaf-strewn");
            table.AddItem("Straw-covered");
            table.AddItem("Scratched up");
            table.AddItem("Empty");
            table.AddItem("Cussioned");
            table.AddItem("Painted");
            table.AddItem("Steamy");
            table.AddItem("Frosty");
            table.AddItem("Flowery");
            table.AddItem("Musty");
            table.AddItem("Unnaturally Angled");
            table.AddItem("Foul-smelling");
            table.AddItem("Recently occupied");
            table.AddItem("Smoky");
            table.AddItem("Throbing");
            table.AddItem("Ruined");
            table.AddItem("Rumbling");
            table.AddItem("Slanted");
            table.AddItem("Disheveled");
            table.AddItem("Ransacked");
            table.AddItem("Hot");
            table.AddItem("Freezing");

            Descriptor = table.GetResult();
        }
    }
}
