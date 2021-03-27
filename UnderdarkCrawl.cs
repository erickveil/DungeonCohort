using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Darkmoor;

namespace DungeonCohort
{
    class UnderdarkCrawl
    {
        public static string RollHex()
        {
            string result = ""; 
            result += Layout() + "\n";
            result += Biome() + "\n";
            result += Features();

            return result;
        }

        public static string Biome()
        {
            var table = new RandomTable<string>();

            table.AddItem("Underdark Sea");
            table.AddItem("Limestone");
            table.AddItem("Dead");
            table.AddItem("Fungus Forest");
            table.AddItem("Rootwood Forest");
            table.AddItem("Stalagmite/Column Forest");
            table.AddItem("Volcanic");

            return table.GetResult();
        }

        public static string Layout()
        {
            var table = new RandomTable<string>();

            table.AddItem("Great Cavern");
            table.AddItem("Labrynth of Tunnels");
            table.AddItem("Major Tunnel");
            table.AddItem("Great Rift");
            table.AddItem("Cave Network");
            table.AddItem("Cavern Network");
            table.AddItem("Narrow, Winding Tunnel");

            return table.GetResult();
        }

        public static string Features()
        {
            var table = new RandomTable<string>();

            table.AddItem("Waterfall");
            table.AddItem("Sinkhole");
            table.AddItem("Chasm");
            table.AddItem("Chasm with Bridge");
            table.AddItem("Underground River");
            table.AddItem(Denezins() + " Stronghold lead by " + Leader());
            table.AddItem(Denezins() + " Outpost");
            table.AddItem("Dungeon: " + Dungeon());
            table.AddItem(Denezins() + " Town: " + Towns());
            table.AddItem(Denezins() + " City: " + Towns());
            table.AddItem(Leader() + " Tower with " + Denezins());
            table.AddItem("Cliff Face");
            table.AddItem("Giant Bones");
            table.AddItem("Primordial Monster Lair");
            table.AddItem(Ore() + " Mines Operated by " + Denezins());
            table.AddItem("Gas: " + Gas());
            table.AddItem("Underground Lake");
            table.AddItem(Hive() + " Hive");
            table.AddItem("Gate: " + Gate());
            table.AddItem("Trade Route: " + Denezins());
            table.AddItem(Leader() + " Temple with " + Denezins());
            table.AddItem("Tomb of " + " Leader");
            table.AddItem("Undead " + Denezins() + " Catacombs");
            table.AddItem("Cistern built by " + Denezins());
            table.AddItem("Oasis");
            table.AddItem("Inn: Owned by " + Leader() + ", Patrons: " + Denezins() + ", " + Denezins() + ", and " + Denezins()); ;
            table.AddItem("Camp: " + Camp());
            table.AddItem("Ore Vein: " + Ore());
            table.AddItem("Gem Deposit: " + Gems());
            table.AddItem("Lava River");
            table.AddItem("Lava Lake");
            table.AddItem("Unstable Fault Hazard");
            table.AddItem("Ancient Monumant of " + Leader());
            table.AddItem("Ruins: " + Ruins());
            table.AddItem("Ooze covered caves");
            // trick/trap

            var trick = new CrawlRoomTrick();
            trick.InitAsTrick();
            table.AddItem(trick.ToString());

            var feature = new CrawlRoomTrick();
            feature.InitAsFeature();
            table.AddItem(feature.ToString());

            var trap = new CrawlRoomTrap();
            trap.InitTrap(tier: 1);
            table.AddItem(trap.ToString());

            return table.GetResult();
        }

        public static string Gate()
        {
            var table = new RandomTable<string>();

            table.AddItem("Plane of Earth");
            table.AddItem("Pandemonium");
            table.AddItem("The Abyss");
            table.AddItem("Lower Plane");
            table.AddItem("Plane of Shadow");
            table.AddItem("Feywild (Unseelie)");
            table.AddItem("Negative Energy Plane");
            table.AddItem("Plane of Fire");
            table.AddItem("Plane of Magma");
            table.AddItem("Plane of Salt");
            table.AddItem("Plane of Dust");
            table.AddItem("Plane of Ash");

            return table.GetResult();
        }

        public static string Hive()
        {
            var table = new RandomTable<string>();

            table.AddItem("Giant Ant");
            table.AddItem("Giant Fire Beetle");
            table.AddItem("Ankheg");
            table.AddItem("Giant Centipede");
            table.AddItem("Giant Scorpion");

            return table.GetResult();
        }

        public static string Gas()
        {
            return CrawlRoomTrap.ChooseGasType();
        }

        public static string Gems()
        {
            var table = new RandomTable<string>();

            table.AddItem("Amathyst");
            table.AddItem("Quartz");
            table.AddItem("Salt");
            table.AddItem("Emerald");
            table.AddItem("Ruby");
            table.AddItem("Diamond");
            table.AddItem("Obsidian");
            table.AddItem("Saphire");
            table.AddItem("Jade");

            return table.GetResult();
        }

        public static string Ore()
        {
            var table = new RandomTable<string>();

            table.AddItem("Tin");
            table.AddItem("Lead");
            table.AddItem("Copper");
            table.AddItem("Silver");
            table.AddItem("Gold");
            table.AddItem("Coal");
            table.AddItem("Granite");
            table.AddItem("Marble");

            return table.GetResult();
        }

        public static string Towns()
        {
            var table = new RandomTable<string>();

            table.AddItem("Cavern with buildings on floor");
            table.AddItem("Port on river");
            table.AddItem("Port on sea");
            table.AddItem("Cavern with buildings in/on walls");
            table.AddItem("Multiple caves with buildings");
            table.AddItem("Dungeon layout with chambers off main halls");
            table.AddItem("Hollowed giant stalagtite");
            table.AddItem("Hollowed giant stalagmite");

            return table.GetResult();
        }

        public static string Denezins()
        {
            var table = new RandomTable<string>();

            table.AddItem("Dark Elf");
            table.AddItem("Deep Dwarf");
            table.AddItem("Troglodyte");
            table.AddItem("Goblin");
            table.AddItem("Quaggoth");
            table.AddItem("Orc");
            table.AddItem("Hobgoblin");
            table.AddItem("Bugbear");
            table.AddItem("Ettercap");
            table.AddItem("Gargoyle");
            table.AddItem("Kuoa Toa");
            table.AddItem("Dwarf");
            table.AddItem("Kobold");
            table.AddItem("Fiend");
            table.AddItem("Undead");
            table.AddItem("Giant");
            table.AddItem("Illithid");
            table.AddItem("Myconid");
            table.AddItem("Modron");
            table.AddItem("Subhuman");
            table.AddItem("Cloaker");
            table.AddItem("Dao");

            return table.GetResult();
        }

        public static string Leader()
        {
            var table = new RandomTable<string>();

            table.AddItem(Denezins() + " Wizard");
            table.AddItem(Denezins() + " Necromancer");
            table.AddItem(Denezins() + " Warrior King");
            table.AddItem(Denezins() + " Heirophant");
            table.AddItem(Denezins());
            table.AddItem(Denezins() + " Petulant Child");
            table.AddItem(Denezins() + " Merchant Prince");
            table.AddItem("Dragon");
            table.AddItem("Lich");
            table.AddItem("Eldritch Horror");

            return table.GetResult();
        }

        public static string Ruins()
        {
            var table = new RandomTable<string>();

            table.AddItem("Stronghold, built by " + Denezins());
            table.AddItem(Denezins() + " Outpost");
            table.AddItem("Town: " + Towns() + ". Built by " + Denezins());
            table.AddItem("City: " + Towns() + ". Built by " + Denezins());
            table.AddItem("Tower, occupied by " + Leader());
            table.AddItem("Mine (dry)");
            table.AddItem("Temple of " + Leader());

            return "Ruined " + table.GetResult();
        }

        public static string Camp()
        {
            var table = new RandomTable<string>();

            table.AddItem("Long Abandoned");
            table.AddItem("Recently Abandoned");
            table.AddItem("Hastily Abandoned (gear left behind)");
            table.AddItem("Occupied: " + Denezins());

            return table.GetResult();
        }

        public static string Dungeon()
        {
            var table = new RandomTable<string>();

            table.AddItem("Lair of " + Denezins());
            table.AddItem("Vault for Treasure or Artifact");
            table.AddItem("Gate Complex: " + Gate());
            table.AddItem("Temple Complex");
            table.AddItem("Wizard Lair");
            table.AddItem("Monster Lair");
            table.AddItem("Death Trap");

            return table.GetResult();
        }
    }
}
