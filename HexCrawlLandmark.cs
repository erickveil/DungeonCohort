using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class HexCrawlLandmark
    {
        public string Location;
        public string LandmarkType;
        public bool IsRuins;
        public bool IsNatural;
        public string Landmark;

        public void Init()
        {
            Location = ChooseLandmarkLocatoin();
            IsRuins = ChooseIsRuins();
            LandmarkType = ChooseLandmarkType();
            
            switch (LandmarkType)
            {
                case "Settlement":
                    Landmark = ChooseSettlement();
                    IsNatural = false;
                    break;
                case "Stronghold":
                    Landmark = ChooseStronghold();
                    IsNatural = false;
                    break;
                case "Signpost":
                    Landmark = ChooseSignpost();
                    IsNatural = false;
                    break;
                case "Obstacle":
                    Landmark = ChooseObstacle();
                    IsNatural = true;
                    break;
                case "Natural":
                    Landmark = ChooseNaturalLandmark();
                    IsNatural = true;
                    break;
                case "Ancient":
                    Landmark = ChooseAncientLandmark();
                    IsNatural = false;
                    break;
                case "Modern":
                    Landmark = ChooseModernLandmark();
                    IsNatural = false;
                    break;
                case "Mystical":
                    Landmark = ChooseMysticalLandmark();
                    IsNatural = true;
                    break;
                default:
                    Landmark = "Unknown landmark type: " + LandmarkType;
                    break;
            }
        }

        public override string ToString()
        {
            string ruined = (IsRuins && !IsNatural) ? "Ruined " : "";
            return LandmarkType + ": " + ruined + Landmark + ", " + Location; 

        }

        public static string ChooseLandmarkLocatoin()
        {
            var table = new RandomTable<string>();

            table.AddItem("On path");
            table.AddItem("Off of path");
            table.AddItem("In sight of path");
            table.AddItem("Audible range of path (sounds reach party)");
            table.AddItem("Olfactory range of path (smells reach party)");

            return table.GetResult();
        }

        public static bool ChooseIsRuins()
        {
            var dice = Dice.Instance;
            return dice.Roll(1, 6) <= 3;
        }

        public static string ChooseLandmarkType()
        {
            var table = new RandomTable<string>();

            table.AddItem("Settlement");
            table.AddItem("Stronghold");
            table.AddItem("Signpost");
            table.AddItem("Obstacle");
            table.AddItem("Natural");
            table.AddItem("Ancient");
            table.AddItem("Modern");
            table.AddItem("Mystical");

            return table.GetResult();
        }

        public static string ChooseSettlement()
        {
            var table = new RandomTable<string>();

            table.AddItem("Hermit hovel");
            table.AddItem("Scattered huts");
            table.AddItem("Farm");
            table.AddItem("Mine");
            table.AddItem("Small Village");
            table.AddItem("Lair");
            table.AddItem("Dungeon");

            return table.GetResult();
        }

        public static string ChooseStronghold()
        {
            var table = new RandomTable<string>();

            table.AddItem("Keep");
            table.AddItem("Tower");
            table.AddItem("Temple");
            table.AddItem("Establishment");
            table.AddItem("Barbarian Camp");
            table.AddItem("Bard Theater");
            table.AddItem("Druid Grove");
            table.AddItem("Fighter Fortress");
            table.AddItem("Monk Monestary");
            table.AddItem("Paladin Cahapel");
            table.AddItem("Ranger Lodge");
            table.AddItem("Rogue Tavern");
            table.AddItem("Sorcerer Sanctum");
            table.AddItem("Warlock Fane");
            table.AddItem("Wizard Library");
            table.AddItem("Castle");
            table.AddItem("Fort");
            table.AddItem("Outpost");
            table.AddItem("Dwarven Hold");
            table.AddItem("Elven Glade");
            table.AddItem("Halfling Hole");
            table.AddItem("Gnome Garden");
            table.AddItem("Bandit Hideout");
            table.AddItem("Planar Gate");
            table.AddItem("Pyramid");

            return table.GetResult();
        }

        public static string ChooseSignpost()
        {
            var table = new RandomTable<string>();

            table.AddItem("Wooden signpost");
            table.AddItem("Stick stuck in ground");
            table.AddItem("Ancient stone marker");
            table.AddItem("Ranger marks");
            table.AddItem("Bandit marks");

            return table.GetResult();
        }

        public static string ChooseObstacle()
        {
            var table = new RandomTable<string>();

            // Natural
            table.AddItem("Rising cliff");
            table.AddItem("Cliff edge");
            table.AddItem("Gorge crosses path");
            table.AddItem("Thick underbrush");
            table.AddItem("Razorvine");
            table.AddItem("River");
            table.AddItem("Small lake");

            // Constructed
            table.AddItem("Wall");

            return table.GetResult();
        }

        public static string ChooseNaturalLandmark()
        {
            var table = new RandomTable<string>();

            table.AddItem("Tor");
            table.AddItem("Hill");
            table.AddItem("Gorge floor");
            table.AddItem("Mushroom circle");
            table.AddItem("Valley floor");
            table.AddItem("Hill crest chain");
            table.AddItem("Stone spires");
            table.AddItem(ChooseObstacle());
            table.AddItem("Copse");
            table.AddItem("Line of trees");
            table.AddItem("Great tree");
            table.AddItem("Cave");
            table.AddItem("Sinkhole");
            table.AddItem(ChooseLandmarkSize() + " Boulder");
            
            return table.GetResult();
        }

        public static string ChooseLandmarkSize()
        {
            var table = new RandomTable<string>();

            table.AddItem("Colossal");
            table.AddItem("Huge");
            table.AddItem("Large");
            table.AddItem("Medium");

            return table.GetResult();
        }

        public static string ChooseAncientLandmark()
        {
            var table = new RandomTable<string>();

            table.AddItem("Solitary great column");
            table.AddItem(ChooseLandmarkSize() + " " + ChooseStatueSubject() + " Statue");
            table.AddItem("Godstone");
            table.AddItem("Burial Mound");
            table.AddItem("Meinhir");
            table.AddItem("Henge");
            table.AddItem("Foundation");
            table.AddItem("Rubble");
            table.AddItem("Battle site");

            return table.GetResult();
        }

        public static string ChooseStatueSubject()
        {
            var table = new RandomTable<string>();

            table.AddItem("Historical figure");
            table.AddItem("Deity");
            table.AddItem(ChooseCreatureType());

            return table.GetResult();
        }

        public static string ChooseCreatureType()
        {
            var table = new RandomTable<string>();

            table.AddItem("Animal");
            table.AddItem("Monster");
            table.AddItem("Humanoid");

            return table.GetResult();
        }

        public static string ChooseModernLandmark()
        {
            var table = new RandomTable<string>();

            table.AddItem("Bridge");
            table.AddItem("Settlement");
            table.AddItem(ChooseStronghold());
            table.AddItem("Recent battle site: " + ChooseBattleType());
            table.AddItem("Communal campsite");

            return table.GetResult();
        }

        public static string ChooseBattleType()
        {
            var table = new RandomTable<string>();

            table.AddItem("Warfare");
            table.AddItem("NPC party vs. Monsters");
            table.AddItem("Ambushed travelers");
            table.AddItem("Single combat");

            return table.GetResult();
        }

        public static string ChooseMysticalLandmark()
        {
            var table = new RandomTable<string>();

            table.AddItem("Circling birds");
            table.AddItem("Lights in the sky");
            table.AddItem("Will-o-whisps");
            table.AddItem("Visions");
            table.AddItem("Dreams");
            table.AddItem("A feeling");
            table.AddItem("An odd wind blows");
            table.AddItem("Divine voice");
            table.AddItem("Gate");
            table.AddItem("Deja vu");
            table.AddItem("Teleportation circle");

            return table.GetResult();
        }

    }
}
