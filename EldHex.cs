using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class EldHex
    {
        public static string HexLocations()
        {
            var table = new RandomTable<string>();
            table.AddItem("Orc outpost");
            table.AddItem("Bandit stash");
            table.AddItem("Ore Vein");
            table.AddItem("Gemstone cave");
            table.AddItem("Ranger Markings");
            table.AddItem("Bandit Markings");
            var nestTable = new RandomTable<string>();
            nestTable.AddItem("Abandoned");
            nestTable.AddItem("Babies Only");
            nestTable.AddItem("Babies with Adult");
            table.AddItem(NestAnimal() + " nest (" + nestTable.GetResult() + ")");
            table.AddItem("Cabin ruins");
            table.AddItem("Babbling Brook");
            var ageTable = new RandomTable<string>();
            ageTable.AddItem("Old");
            ageTable.AddItem("Recent");
            table.AddItem(ageTable.GetResult() + " Battlefield");
            table.AddItem("Traces of an old road");
            table.AddItem("Trail");
            table.AddItem("Cave entrance");
            table.AddItem("Ancient Statue: " + HexCrawlLandmark.ChooseStatueSubject());
            table.AddItem("Fountain");
            table.AddItem("Skeleton");
            table.AddItem("Hidden Treasure");
            table.AddItem("Savage Encampment");
            table.AddItem("Abandoned Campsite (" + ageTable.GetResult() + ")");
            table.AddItem("Discarded item");
            table.AddItem("Fountain");
            table.AddItem("Altar emblazoned with: " + EldMagicItemGen.symbology());
            table.AddItem("Rain Cistern");
            table.AddItem("Floating Stones");
            table.AddItem("Shallow Grave with a makeshift tombstone");
            table.AddItem("Burial Mound");
            table.AddItem("Floating menhir / stones");
            table.AddItem("Barrow");
            table.AddItem("Cairn");
            table.AddItem("Dungeon Entrance: " + DungeonEntrances());
            table.AddItem("Ruin: " + HexCrawlLandmark.ChooseStronghold());
            table.AddItem("River Fjord");
            table.AddItem("River with Bridge");
            table.AddItem("Recently abandoned cabin");
            table.AddItem("Tower");
            table.AddItem("Frozen Lake (circumvent and lose time, or risk crossing and breaking ice)");

            var hexLandmark = new HexCrawlLandmark();
            hexLandmark.Init();
            table.AddItem(hexLandmark.ToString(), 5);

            return table.GetResult();
        }

        public static string HexEvent(int tier, AncestryIndex ancestryIndex)
        {
            var table = new RandomTable<string>();

            table.AddItem("Bandit Ambush");
            table.AddItem("Battle: " + Battle() + " (" + WarringFactions() + " vs " + WarringFactions() + ")");
            table.AddItem("Flora: " + Flora());
            table.AddItem("Camp: " + Camp(tier, ancestryIndex));
            table.AddItem("Traveling Merchant: " + Merchant());
            table.AddItem("Weather Change: " + Weather());
            table.AddItem("Ritual");
            table.AddItem("A discarded trinket or treasure");
            table.AddItem("Quicksand/sinkhole");
            table.AddItem("Astronomical Event: " + AstronomicalEvent());
            table.AddItem("Site of an execution");
            table.AddItem("Allergic reaction to something in area");
            table.AddItem("Earthquake or avalanche");
            table.AddItem("Scene of a murder");
            table.AddItem("Area flooded (possible problem present) +1 watch to go around or risk going through");
            table.AddItem("Horse/Pack Animal/Hireling becomes pregnant or ill");
            table.AddItem("PC lost an item");
            table.AddItem("Find strange trash, such as wagon wheel or chest of clothing");
            table.AddItem("Unlucky omen: " + BadOmens());
            table.AddItem("Curious non-dangerous creature approaches: " + Animal());
            table.AddItem("Discover insect hive");
            table.AddItem("Disturb insect hive");
            table.AddItem("Animal in trap: " + Animal());
            table.AddItem("Hole in boot -step ina mud puddle");
            table.AddItem("Rancher and herd/Shepherd and flock: " + DomesticAnimal());
            table.AddItem("Animal Tracks: " + Tracks(tier, ancestryIndex));
            table.AddItem("Animal Herd: " + HerdAnimal());
            table.AddItem("Fire");
            table.AddItem("Volcanic activity");

            return table.GetResult();
        }

        public static string BadOmens()
        {
            var table = new RandomTable<string>();

            table.AddItem("Cat lies dead and smells of rot");
            table.AddItem("Moss grows on south side of a tree or rock");
            table.AddItem("Black bird files widdershins overhead");
            table.AddItem("Black flies cloud over puddle of muddy water");
            table.AddItem("Blade tree leaves curl at their tips");
            table.AddItem("Old hangman's noose hangs over path");
            table.AddItem("Bones found arranged in a triangle");
            table.AddItem("Smell of sulfur");
            table.AddItem("Sun/moon appears red when a cloud covers it");
            table.AddItem("Bad star appears in the sky");
            table.AddItem("The call of a blue owl is heard");
            table.AddItem("Snake found biting its tail");
            table.AddItem("Animal found, starved to death");
            table.AddItem("Unseasonal bloom of a tree");
            table.AddItem("Ghostly lights bob in the distance");
            table.AddItem("Copper piece found tails up");
            table.AddItem("Mold growth covers tree trunk");

            return table.GetResult();
        }

        public static string WarringFactions()
        {
            var table = new RandomTable<string>();

            table.AddItem("Blacktalons");
            table.AddItem("Forest Orcs");
            table.AddItem("Hill Orcs");
            table.AddItem("Mountain Orcs");
            table.AddItem("Hobgoblins");
            table.AddItem("Brigands");
            table.AddItem("Savages");
            table.AddItem("Necromancer");
            table.AddItem("Draugr");

            return table.GetResult();
        }

        public static string DungeonEntrances()
        {
            var table = new RandomTable<string>();

            table.AddItem("A wide cave mouth descends into the ground. Bones litter the outside.");
            table.AddItem("An old mine entrance, the outbuildings all in disarray.");
            table.AddItem("A circular opening in the ground, ringed in old, mossy stone, descends into darkness. ");
            table.AddItem("A trapdoor in the foundation of an old ruins.");
            table.AddItem("The stone of the hillside is carved to look like a giant dragons head, with a double doors set into it’s open mouth.");
            table.AddItem("A free-standing stone archway of ancient construction is broken, the pieces laying covered in moss and growth on the ground around it. Reconstructing it activates a gate into the dungeon.");
            table.AddItem("A cave mouth barred by a wooden door built to take up the entrance.");
            table.AddItem("The roots of a large tree part to form a dark hollow under the trunk. Ancient stone stairs spiral down directly inside.");
            table.AddItem("A single tower still stands, surrounded by the rubble that is all that is left of very old ruins. The upper levels are bare and unremarkable, but the stairs spiral down into the earth.");
            table.AddItem("A solid orc outpost sits atop an orc dungeon. Might still be occupied and guarded or might have been abandoned and taken over by new residents.");
            table.AddItem("A dark elf outpost set into the side of a rocky cliff face. Beyond is a dungeon, and the entrance to the Underdark.");
            table.AddItem("A stone bunker with a locked, iron door contains stairs that lead down into the dungeon.");

            return table.GetResult();
        }

        public static string Tracks(int tier, AncestryIndex ancestryIndex)
        {
            var table = new RandomTable<string>();

            table.AddItem("Footprints");
            table.AddItem("Disturbed foliage");
            table.AddItem("Droppings");
            table.AddItem("Vomit");
            table.AddItem("Discarded meal");
            table.AddItem("Dermal Shedding");
            table.AddItem("Scent");
            table.AddItem("Spotted in distance");
            table.AddItem("Hear call");


            var sourceTable = new RandomTable<string>();
            sourceTable.AddItem("NPC: " + Npc(tier, ancestryIndex));
            sourceTable.AddItem("Party: " + AdventurerParty(tier, ancestryIndex));
            sourceTable.AddItem("Roll Encounter", 2);
            sourceTable.AddItem("Animal: " + Animal(), 4);

            return "Source: " + sourceTable.GetResult() + "\nTrack type: " + table.GetResult();
        }

        public static string Npc(int tier, AncestryIndex ancestryIndex)
        {
            var table = new RandomTable<string>();

            var eldTables = new EldTables();

            bool isStdRace = false;
            var die = Dice.Instance;
            bool isGood = die.Roll(1, 6) <= 3;
            AlignmentValue align = isGood ? AlignmentValue.ALIGN_GOOD : AlignmentValue.ALIGN_EVIL;
            Character npc = ancestryIndex.GetRandomNPC(tier, 
                align, isStdRace);

            string npcName = npc.GetFullIdentifier();
            string alignment = npc.GetAlignmentString();
            string cr = npc.Ancestry.CR;
            string genericNpc = npcName + " (" + cr + ")\n" + alignment;

            table.AddItem(eldTables.Adventurers().ToString(), 4);
            table.AddItem(genericNpc);

            return table.GetResult();
        }

        public static string AdventurerParty(int tier, AncestryIndex ancestryIndex)
        {
            var die = Dice.Instance;
            int numAppearing = die.Roll(1, 3) + 1;
            string result = "";
            for (int i = 0; i < numAppearing; ++i)
            {
                result += Npc(tier, ancestryIndex) + "\n";
            }

            return result;
        }

        public static string AstronomicalEvent()
        {
            var table = new RandomTable<string>();

            table.AddItem("Falling star");
            table.AddItem("Commet appears");
            table.AddItem("Eclipse");
            table.AddItem("Blood moon");
            table.AddItem("Meteor shower");
            table.AddItem("New constellation appears");
            table.AddItem("Constellation dissappears");
            table.AddItem("48 Hours of darkness");
            table.AddItem("Northern Lights");
            table.AddItem("Commet crashes into sun");
            table.AddItem("Solar flare up");
            table.AddItem("Planetary conjunction");
            table.AddItem("Ill-portent planet passes through constelation");

            return table.GetResult();
        }

        public static string Weather()
        {
            var table = new RandomTable<string>();

            table.AddItem("Thick Fog");
            table.AddItem("Buckets of hard rain");
            table.AddItem("Thunderstorm");
            table.AddItem("Snow");
            table.AddItem("Hail");
            table.AddItem("Drizzle");
            table.AddItem("Ash falls from the red sky and the air smells like smoke");
            table.AddItem("Biting, Freezing wind");
            table.AddItem("Steady downpour");
            table.AddItem("Blizzard");
            table.AddItem("Ice storm");
            table.AddItem("Firestorm");
            table.AddItem("Blood red rain");
            table.AddItem("Black rain");

            return table.GetResult();
        }

        public static string Merchant()
        {
            var table = new RandomTable<string>();

            table.AddItem("Trade Goods", 4);
            table.AddItem("Caravan", 4);
            table.AddItem("Weapons", 4);
            table.AddItem("Alchemist", 4);
            table.AddItem("Snake Oil", 4);
            table.AddItem("Doctor", 4);
            table.AddItem("Slaver");
            table.AddItem("Minor Magic Items");
            table.AddItem("Cursed Items", 2);

            return table.GetResult();
        }

        public static string Camp(int tier, AncestryIndex ancestryIndex)
        {
            var ageTable = new RandomTable<string>();

            ageTable.AddItem("Old and cold");
            ageTable.AddItem("Days old");
            ageTable.AddItem("Smoking embers");
            ageTable.AddItem("Occupied");

            var table = new RandomTable<string>();
            table.AddItem("Orcs");
            table.AddItem("Hobgoblins");
            table.AddItem("Bandits");
            table.AddItem("Ranger");
            table.AddItem("Adventurers: " + AdventurerParty(tier, ancestryIndex));

            return ageTable.GetResult() + " - " + table.GetResult();
        }

        public static string Lotus()
        {
            string found = "Lotus: White";
            var die = Dice.Instance;
            bool isMore = die.Roll(1, 6) == 1;
            var uncommonTable = new RandomTable<string>();
            uncommonTable.AddItem(", Gold");
            uncommonTable.AddItem(", Yellow");
            var rareTable = new RandomTable<string>();
            rareTable.AddItem(", Blue");
            rareTable.AddItem(", Purple");

            if (isMore)
            {
                found += uncommonTable.GetResult();
                isMore = die.Roll(1, 6) == 1;
                if (isMore)
                {
                    found += rareTable.GetResult();
                    isMore = die.Roll(1, 6) == 1;
                    if (isMore)
                    {
                        found += ", Black";
                    }
                }
            }
            return found;
        }

        public static string Mushrooms()
        {
            var table = new RandomTable<string>();

            table.AddItem("Final Meal");
            table.AddItem("Corpsefriends (growing on a corpse)");
            table.AddItem("Ancelium", 2);
            table.AddItem("Mycorbid", 4);
            table.AddItem("Grenwit", 8);
            table.AddItem("Grey Wart", 8);
            table.AddItem("Gludagger", 4);
            table.AddItem("Faerie (ring)", 2);
            table.AddItem("Manticore's Mane");
            table.AddItem("False Violet");

            table.AddItem("Shrieker");
            table.AddItem("Violet Fungus");
            table.AddItem("Gas Spore");

            return "Mushroom: " + table.GetResult();
        }

        public static string DangerousFlora()
        {
            var table = new RandomTable<string>();

            table.AddItem("Tri-flower Frond");
            table.AddItem("Mantrap");
            table.AddItem("Assassin Vine");
            table.AddItem("Carnivorous Flower");
            table.AddItem("Corpse Flower");

            return table.GetResult();
        }

        public static string Flora()
        {
            var table = new RandomTable<string>();

            table.AddItem(Lotus());
            table.AddItem(Mushrooms());
            table.AddItem(DangerousFlora());
            table.AddItem("Psionic Crystal Growth");

            return table.GetResult();
        }

        public static string NestAnimal()
        {
            var table = new RandomTable<string>();

            table.AddItem("Dire Wolf");
            table.AddItem("Arctotherium (Giant Bear)");
            table.AddItem("Daeodon (Giant 'Pig')");
            table.AddItem("Dolktann (Wooly Saber-toothed Cat)");
            table.AddItem("Giant Bat");
            table.AddItem("Giant Eagle");
            table.AddItem("Winter Wolf");
            table.AddItem("Highland Sheep (Mouflon)");
            table.AddItem("Red Fox");
            table.AddItem("Pallas Cat");
            table.AddItem("Forest Cat");
            table.AddItem("Snow Lynx");
            table.AddItem("Sith Cat");
            table.AddItem("Snow Lynx");
            table.AddItem("Nuralagus (Large Rabbit)");
            table.AddItem("Raven");
            table.AddItem("Bat");
            table.AddItem("Blue Weasle");
            table.AddItem("Badger");
            table.AddItem("Eagle");
            table.AddItem("Giant Fire Beetle");
            table.AddItem("Goat");
            table.AddItem("Owl");
            table.AddItem("Blue Weasel");
            table.AddItem("Stirge");
            table.AddItem("Boar");
            table.AddItem("Elk");
            table.AddItem("Wolf");
            table.AddItem("Hare");
            table.AddItem("Brown Bear");
            table.AddItem("Giant Raven");
            table.AddItem("Giant Spider");
            table.AddItem("Ice Spider");
            table.AddItem("Show Leopard");
            table.AddItem("Giant Boar");

            return table.GetResult();
        }

        public static string DomesticAnimal()
        {
            var table = new RandomTable<string>();

            table.AddItem("Dog");
            table.AddItem("Mastiff");
            table.AddItem("Sheep");
            table.AddItem("Ox");
            table.AddItem("Goat");
            table.AddItem("Cat");
            table.AddItem("Riding Horse");
            table.AddItem("Draft Horse");
            table.AddItem("Donkey");
            table.AddItem("Mule");
            table.AddItem("Pig");
            table.AddItem("Chicken");
            table.AddItem("Falcon");
            table.AddItem("Cattle");

            return "Domestic " + table.GetResult();
        }

        public static string HerdAnimal()
        {
            var table = new RandomTable<string>();

            table.AddItem("Dire Wolf");
            table.AddItem("Wolf");
            table.AddItem("Auroch");
            table.AddItem("Giant Reindeer");
            table.AddItem("Reindeer");
            table.AddItem("Wooly Mammoth");
            table.AddItem("Giant Goat");
            table.AddItem("Giant Bat");
            table.AddItem("Bat");
            table.AddItem("Winter Wolf");
            table.AddItem("Highland Sheep (Mouflon)");
            table.AddItem("Goat");
            table.AddItem("Deer");
            table.AddItem("Pony");
            table.AddItem("Horse");
            table.AddItem("Elk");
            table.AddItem("");
            return table.GetResult();
        }

        public static string Animal()
        {
            var table = new RandomTable<string>();

            table.AddItem(HerdAnimal());
            table.AddItem(NestAnimal());
            table.AddItem(DomesticAnimal());

            return table.GetResult();
        }

        public static string Battle()
        {
            var table = new RandomTable<string>();

            table.AddItem("Column on the March");
            table.AddItem("Encamped Forces");
            table.AddItem("Impending Ambush");
            table.AddItem("Forming Lines");
            table.AddItem("Engaged in Battle");
            table.AddItem("Recently Fought");
            table.AddItem("Scavengers Picking");
            table.AddItem("Stripped bodies");
            table.AddItem("Old Battlefield");

            return table.GetResult();
        }

    } // end class
} // end namespace
