using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class OddRooms
    {
        public static string GetOddRoomType()
        {
            var table = new RandomTable<string>();

            table.AddItem(GetFlavor() + " " + GetFutureTechRoom());
            table.AddItem(GetAlienRoom());
            table.AddItem(GetWeirdArchitecture());
            table.AddItem(GetElementalRooms());

            return table.GetResult();
        }

        public static string GetFlavor()
        {
            var table = new RandomTable<string>();

            table.AddItem("Biological");
            table.AddItem("Mechanical");
            table.AddItem("I-Tech");
            table.AddItem("Crystaline");
            table.AddItem("Arcanum");
            table.AddItem("Cog-punk");
            table.AddItem("Solar Punk");
            table.AddItem("Infernal");
            table.AddItem("Celestial");
            table.AddItem("Fey");
            table.AddItem("Eldritch");
            table.AddItem("Galaxy-Punk");

            return table.GetResult();
        }

        public static string GetFutureTechRoom()
        {
            var table = new RandomTable<string>();

            table.AddItem("Memory Harvester");
            table.AddItem("Conciousness Transfer");
            table.AddItem("Medical Bay");
            table.AddItem("Control Room");
            table.AddItem("Centrifuge");
            table.AddItem("Pump and valves");
            table.AddItem("Waste disposal");
            table.AddItem("Sleep Pods");
            table.AddItem("Power Generator");
            table.AddItem("Study Pods");
            table.AddItem("Data Repository");
            table.AddItem("AI Computer");
            table.AddItem("Engine Room");
            table.AddItem("Hydroponics");
            table.AddItem("Fluid Flusher");
            table.AddItem("Species Tanks");
            table.AddItem("Cloning Facility");
            table.AddItem("Automaton Recharge Bay");
            table.AddItem("Transport Bay");
            table.AddItem("Dissection Lab");
            table.AddItem("Hyperdrive");
            table.AddItem("Gate");
            table.AddItem("Teleporter");
            table.AddItem("Transport Tube");
            table.AddItem("Life Support");
            table.AddItem("Gunnery");
            table.AddItem("Communications");
            table.AddItem("Security Station");
            table.AddItem("Sensors");
            table.AddItem("Geological Study");
            table.AddItem("Organic Plant Study");
            table.AddItem("Holodeck");

            return table.GetResult();
        }

        public static string GetAlienRoom()
        {
            var table = new RandomTable<string>();

            table.AddItem("Egg Room");
            table.AddItem("Blood Cistern");
            table.AddItem("Mushroom");

            return table.GetResult();
        }

        public static string GetWeirdArchitecture()
        {
            var table = new RandomTable<string>();

            table.AddItem("Sphere room with concave floor");
            table.AddItem("Bridge over chasm");
            table.AddItem("Bridge over fluid");
            table.AddItem("Platform jumper");
            table.AddItem("Jungle gym");


            return table.GetResult();
        }

        public static string GetElementalRooms()
        {
            var table = new RandomTable<string>();

            table.AddItem("Slime room");
            table.AddItem("Walk-in-Oven");
            table.AddItem("Air Pit");
            table.AddItem("Lightning Cage");
            table.AddItem("Blinding radiance");
            table.AddItem("Flickering shadows");
            table.AddItem("Steam room");
            table.AddItem("Vacuum");
            table.AddItem("Wind-tunnel");
            table.AddItem("Frozen Room");

            return table.GetResult();
        }

    }
}
