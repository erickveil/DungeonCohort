using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class CrawlRoomIllumintion
    {
        public enum LightLevel { MagicalDarkness, Dark, Dim, Light };
        public LightLevel Level;
        public string Source;

        public void InitForRoom()
        {
            var levelTable = new RandomTable<LightLevel>();
            levelTable.AddItem(LightLevel.Dark, 16);
            levelTable.AddItem(LightLevel.Dim, 8);
            levelTable.AddItem(LightLevel.Light, 4);
            levelTable.AddItem(LightLevel.MagicalDarkness);

            var sourceTable = new RandomTable<string>();
            sourceTable.AddItem("Torch");
            sourceTable.AddItem("Candles");
            sourceTable.AddItem("Wax blobs");
            sourceTable.AddItem("Oil lantern");
            sourceTable.AddItem("Floating, glowing glass spheres");
            sourceTable.AddItem("Chandelier");
            sourceTable.AddItem("Candelabra");
            sourceTable.AddItem("Errie, glowing mold");
            sourceTable.AddItem("Spell");
            sourceTable.AddItem("Brazier");
            sourceTable.AddItem("Fireplace");
            sourceTable.AddItem("Firepit");

            Level = levelTable.GetResult();
            Source = sourceTable.GetResult();
        }

        public void InitForHall()
        {
            var levelTable = new RandomTable<LightLevel>();
            levelTable.AddItem(LightLevel.Dark, 8);
            levelTable.AddItem(LightLevel.Dim, 4);
            levelTable.AddItem(LightLevel.Light, 2);
            levelTable.AddItem(LightLevel.MagicalDarkness);

            var sourceTable = new RandomTable<string>();
            sourceTable.AddItem("Torch");
            sourceTable.AddItem("Candles");
            sourceTable.AddItem("Wax blobs");
            sourceTable.AddItem("Oil lantern");
            sourceTable.AddItem("Errie, glowing mold");
            sourceTable.AddItem("Spell");

            Level = levelTable.GetResult();
            Source = sourceTable.GetResult();

        }

        public string AsString()
        {
            string level;
            switch (Level)
            {
                case LightLevel.Dark:
                    level = "DARK";
                    break;
                case LightLevel.Dim:
                    level = "DIM";
                    break;
                case LightLevel.Light:
                    level = "LIGHT";
                    break;
                default:
                    level = "MAGICAL DARKNESS";
                    break;
            }

            return level + " - " + Source;
        }
    }
}
