using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class EldTables
    {
        public enum EldBiome {LightForest, DeepForest, Tundra, Hills, 
            Mountain, Dungeon, Village };

        public string Encounter(EldBiome location, int lvl)
        {
            var table = new RandomTable<EldUnit>();

            if (location == EldBiome.LightForest)
            {
                table.AddItem(Intelligent(EldBiome.LightForest), 6);
                table.AddItem(Undead(EldBiome.LightForest), 5);
                table.AddItem(Beast(EldBiome.LightForest), 10);
                table.AddItem(Planar(EldBiome.LightForest), 4);
            }
            else if (location == EldBiome.DeepForest)
            {
                table.AddItem(Intelligent(EldBiome.DeepForest), 4);
                table.AddItem(Undead(EldBiome.DeepForest), 6);
                table.AddItem(Beast(EldBiome.DeepForest), 18);
                table.AddItem(Planar(EldBiome.DeepForest), 2);

            }
            else if (location == EldBiome.Tundra)
            {
                table.AddItem(Intelligent(EldBiome.Tundra), 4);
                table.AddItem(Undead(EldBiome.Tundra), 2);
                table.AddItem(Beast(EldBiome.Tundra), 8);
                table.AddItem(Planar(EldBiome.Tundra), 1);

            }
            else if (location == EldBiome.Hills)
            {
                table.AddItem(Intelligent(EldBiome.Hills), 8);
                table.AddItem(Undead(EldBiome.Hills), 2);
                table.AddItem(Beast(EldBiome.Hills), 4);
                table.AddItem(Planar(EldBiome.Hills), 1);
                table.AddItem(HillOrcs(), 2);
                table.AddItem(Hobgoblins(), 2);

            }
            else if (location == EldBiome.Mountain)
            {
                table.AddItem(Intelligent(EldBiome.Mountain), 4);
                table.AddItem(Undead(EldBiome.Mountain), 1);
                table.AddItem(Beast(EldBiome.Mountain), 8);
                table.AddItem(Planar(EldBiome.Mountain), 2);

            }
            else if (location == EldBiome.Dungeon)
            {
                table.AddItem(Intelligent(EldBiome.Dungeon), 2);
                table.AddItem(Undead(EldBiome.Dungeon), 8);
                table.AddItem(Beast(EldBiome.Dungeon), 1);
                table.AddItem(Planar(EldBiome.Dungeon), 4);
            }
            else 
            {
                table.AddItem(Intelligent(EldBiome.Village), 8);
                table.AddItem(Undead(EldBiome.Village), 2);
                table.AddItem(Beast(EldBiome.Village), 4);
                table.AddItem(Planar(EldBiome.Village), 1);
                table.AddItem(Orcs(), 2);
            }

            var result = table.GetResult();
            string motivation = Motivation(result.Type);
            string encounterStr = result.ToString(lvl) + " - " + motivation;
            if (encounterStr.Contains("; "))
            {
                encounterStr += "\n" + Encounter(location, lvl);
            }
            return encounterStr;
        }


        public string Motivation(string type)
        {
            var table = new RandomTable<string>();

            if (type == "Beast")
            {
                table.AddItem("Sleeping", 1);
                table.AddItem("Dying", 1);
                table.AddItem("Feeding young/Nesting", 2);
                table.AddItem("Eating/Being eaten; ", 2);
                table.AddItem("Patrolling", 3);
                table.AddItem("Walking", 3);
                table.AddItem("Territorial display", 4);
                table.AddItem("In Combat; ", 4);
                table.AddItem("Wounded", 5);
                table.AddItem("Walking", 5);
                table.AddItem("Territorial display", 4);
                table.AddItem("Rest/Relax/Nest", 4);
                table.AddItem("Fleeing/Pursuit; ", 3);
                table.AddItem("Hunting/Gathering", 3);
                table.AddItem("Shadowing/Stalking", 1);

                table.AddItem(AlteredState(), 1);

                table.AddItem("Defecating", 1);
            }
            else if (type == "Intelligent")
            {
                table.AddItem("Art", 1);
                table.AddItem("Meditating", 1);
                table.AddItem("Ritual", 2);
                table.AddItem("Wounded", 2);
                table.AddItem("Diplomacy", 3);
                table.AddItem("Laboring", 3);
                table.AddItem("Lost/Searching", 4);
                table.AddItem("Fleeing/Pursuit; ", 4);
                table.AddItem("In Combat; ", 5);
                table.AddItem("Walking", 5);
                table.AddItem("Patrolling", 4);

                table.AddItem(AlteredState(), 4);

                table.AddItem("Hunting/Gathering", 3);
                table.AddItem("Competing", 3);
                table.AddItem("Resting/Camp", 1);
                table.AddItem("Sleeping", 1);
                table.AddItem("Shadowing/Stalking", 1);
            }
            else
            {
                table.AddItem("Appear Dead/Deactivated", 1);
                table.AddItem("Patrolling", 1);
                table.AddItem("Walking", 2);
                table.AddItem("Standing", 2);
                table.AddItem("Guarding", 3);
                table.AddItem("Imitating life", 3);
                table.AddItem("Appear dead/Deactivated", 4);
                table.AddItem("Pursuit; ", 4);
                table.AddItem("In Combat; ", 5);
                table.AddItem("Walking", 5);
                table.AddItem("Patrolling", 4);

                table.AddItem(AlteredState(), 4);

                table.AddItem("Eating/Refueling", 3);
                table.AddItem("Standing", 3);
                table.AddItem("Walking", 1);
                table.AddItem("Guarding", 1);
            }

            return table.GetResult();
        }

        public string AlteredState()
        {
            var table = new RandomTable<string>();

            table.AddItem("Enlarged");
            table.AddItem("Drugged");
            table.AddItem("Poisoned");
            table.AddItem("Bound and Gagged");
            table.AddItem("Hasted");
            table.AddItem("Enraged");
            table.AddItem("Paralyzed");
            table.AddItem("Asleep");
            table.AddItem("Exhausted");
            table.AddItem("Invisible");
            table.AddItem("Dead");
            table.AddItem("Dying");

            return table.GetResult();
        }

        public EldUnit Beast(EldBiome biome)
        {
            var table = new RandomTable<EldUnit>();
            if (biome == EldBiome.LightForest)
            {
                table.AddItem(new EldUnit("Giant Wolf Spider", "1/4"));
                table.AddItem(new EldUnit("Velociraptor", "1/4"));
                table.AddItem(new EldUnit("Wolf", "1/4"));
                table.AddItem(new EldUnit("Giant Hyena", "1"));
                table.AddItem(new EldUnit("Snow Leopard", "1"));
                table.AddItem(new EldUnit("Giant Elk", "2"));
            }
            else if (biome == EldBiome.DeepForest)
            {
                table.AddItem(new EldUnit("Demetrodon", "1/4"));
                table.AddItem(new EldUnit("Ape", "1/2"));
                table.AddItem(new EldUnit("Brown Bear", "1"));
                table.AddItem(new EldUnit("Giant Raven", "1"));
                table.AddItem(new EldUnit("Su-Monster", "1"));
                table.AddItem(new EldUnit("Giant Boar", "1"));
            }
            else if (biome == EldBiome.Tundra)
            {
                table.AddItem(new EldUnit("Wild Dog", "0"));
                table.AddItem(new EldUnit("Giant Wasp", "1/2"));
                table.AddItem(new EldUnit("Deinonychus", "1"));
                table.AddItem(new EldUnit("Ice Spider", "1"));
                table.AddItem(new EldUnit("Young Winter Wolf", "1"));
                table.AddItem(new EldUnit("Ice Spider Queen", "2"));
            }
            else if (biome == EldBiome.Hills)
            {
                table.AddItem(new EldUnit("Giant Lizard", "1/4"));
                table.AddItem(new EldUnit("Clawfoot", "1"));
                table.AddItem(new EldUnit("Dire Wolf", "1"));
                table.AddItem(new EldUnit("Giant Vulture", "1"));
                table.AddItem(new EldUnit("Young Winter Wolf", "1"));
                table.AddItem(new EldUnit("Allosaurus", "2"));
            }
            else if (biome == EldBiome.Mountain)
            {
                table.AddItem(new EldUnit("Giant Bat", "1/4"));
                table.AddItem(new EldUnit("Pteranodon", "1/4"));
                table.AddItem(new EldUnit("Giant Goat", "1/2"));
                table.AddItem(new EldUnit("Giant Eagle", "1"));
                table.AddItem(new EldUnit("Craig Cat", "1"));
                table.AddItem(new EldUnit("Cave Bear", "2"));
            }
            else if (biome == EldBiome.Dungeon)
            {
                table.AddItem(new EldUnit("Giant Fire Beetle", "0"));
                table.AddItem(new EldUnit("Stirge", "1/8"));
                table.AddItem(new EldUnit("Giant Centipede", "1/4"));
                table.AddItem(new EldUnit("Darkmantle", "1/2"));
                table.AddItem(new EldUnit("Giant Spider", "1"));
                table.AddItem(new EldUnit("Carrion Crawler", "2"));
            }
            else if (biome == EldBiome.Village)
            {
                table.AddItem(new EldUnit("Mastiff", "1/8"));
                table.AddItem(new EldUnit("Giant Rat", "1/8"));
                table.AddItem(new EldUnit("Wolf", "1/4"));
                table.AddItem(new EldUnit("Giant Wolf Spider", "1/4"));
                table.AddItem(new EldUnit("Giant Centipede", "1/4"));
                table.AddItem(new EldUnit("Aurochs", "2"));
            }

            var result = table.GetResult();
            result.Type = "Beast";
            return result;
        }


        public EldUnit Intelligent(EldBiome biome)
        {
            var table = new RandomTable<EldUnit>();
            if (biome == EldBiome.LightForest)
            {
                table.AddItem(Cultists());
                table.AddItem(new EldUnit("Goblin", "1/4"));
                table.AddItem(Adventurers());
                table.AddItem(new EldUnit("Bugbear", "1"));
                table.AddItem(new EldUnit("Yuan-ti pureblood", "1"));
                table.AddItem(new EldUnit("Wererat", "2"));
            }
            else if (biome == EldBiome.DeepForest)
            {
                table.AddItem(new EldUnit("Drow", "1/4"));
                table.AddItem(Gnoll());
                table.AddItem(Adventurers());
                table.AddItem(ForestOrcs(), 2);
                table.AddItem(Gnoll());
            }
            else if (biome == EldBiome.Tundra)
            {
                table.AddItem(Savages(), 2);
                table.AddItem(Adventurers());
                table.AddItem(Bandits(), 2);
                table.AddItem(Blacktalons());
            }
            else if (biome == EldBiome.Hills)
            {
                table.AddItem(Hobgoblins(), 2);
                table.AddItem(Adventurers());
                table.AddItem(HillOrcs());
                table.AddItem(new EldUnit("Ogre", "2"));
            }
            else if (biome == EldBiome.Mountain)
            {
                table.AddItem(new EldUnit("Kobold", "1/8"));
                table.AddItem(new EldUnit("Half Ogre", "1"));
                table.AddItem(Adventurers());
                table.AddItem(MountainOrcs(), 2);
                table.AddItem(new EldUnit("Werebat", "2"));
            }
            else if (biome == EldBiome.Dungeon)
            {
                table.AddItem(new EldUnit("Goblin", "1/4"));
                table.AddItem(Adventurers());
                table.AddItem(new EldUnit("Meazel", "1"));
                table.AddItem(Orcs());
                table.AddItem(new EldUnit("Quaggoth", "2"));
            }
            else if (biome == EldBiome.Village)
            {
                table.AddItem(Savages());
                table.AddItem(Orcs());
                table.AddItem(Adventurers());
                table.AddItem(Hobgoblins());
                table.AddItem(new EldUnit("Goblin", "1/4"));
                table.AddItem(new EldUnit("Bugbear", "2"));
            }

            var result = table.GetResult();
            result.Type = "Intelligent";
            return result;
        }

        public EldUnit Planar(EldBiome biome)
        {
            var table = new RandomTable<EldUnit>();
            if (biome == EldBiome.LightForest)
            {
                table.AddItem(new EldUnit("Chwinga", "0"));
                table.AddItem(new EldUnit("Mud Mephit", "1/4"));
                table.AddItem(Devils(), 2);
                table.AddItem(Yugoloths());
                table.AddItem(new EldUnit("Darkling", "1/2"));
                table.AddItem(new EldUnit("Darkling Elder", "2"));
            }
            else if (biome == EldBiome.DeepForest)
            {
                table.AddItem(new EldUnit("Firenewt Warrior", "1/2"));
                table.AddItem(new EldUnit("Ice Mephit", "1/2"));
                table.AddItem(new EldUnit("Fire Snake", "1"));
                table.AddItem(new EldUnit("Firenewt Warlock", "1"));
                table.AddItem(new EldUnit("Dryad", "1"));
                table.AddItem(new EldUnit("Meenlock", "2"));
                table.AddItem(Yugoloths());
            }
            else if (biome == EldBiome.Tundra)
            {
                table.AddItem(new EldUnit("Dust Mephit", "1/2"));
                table.AddItem(new EldUnit("Ice Mephit", "1/2"),2);
                table.AddItem(new EldUnit("Aesir Raider (Guard)", "1/8"));
                table.AddItem(new EldUnit("Firenewt Warrior", "1/2"));
                table.AddItem(new EldUnit("Githzerai Monk", "2"));
                table.AddItem(Yugoloths());
            }
            else if (biome == EldBiome.Hills)
            {
                table.AddItem(new EldUnit("Ice Mephit", "1/2"));
                table.AddItem(new EldUnit("Vargouille", "1"));
                table.AddItem(Demons(), 2);
                table.AddItem(Yugoloths());
                table.AddItem(new EldUnit("Shadow Mastiff", "2"),2);
            }
            else if (biome == EldBiome.Mountain)
            {
                table.AddItem(new EldUnit("Smoke Mephit", "1/4"));
                table.AddItem(new EldUnit("Ice Mephit", "1/2"));
                table.AddItem(new EldUnit("Magma Mephit", "1/2"));
                table.AddItem(Demons(), 3);
                table.AddItem(Yugoloths());
            }
            else if (biome == EldBiome.Dungeon)
            {
                table.AddItem(Fiends(), 2);
                table.AddItem(new EldUnit("Slaad Tadpole", "1/8"));
                table.AddItem(new EldUnit("Chaosling", "1/4"), 2);
                table.AddItem(new EldUnit("Gargoyle", "2"));
            }
            else if (biome == EldBiome.Village)
            {
                table.AddItem(new EldUnit("Chwinga", "0"));
                table.AddItem(new EldUnit("Firenewt Warrior", "0"));
                table.AddItem(new EldUnit("Darkling", "1/2"));
                table.AddItem(Demons());
                table.AddItem(Devils());
                table.AddItem(Yugoloths());
                table.AddItem(new EldUnit("Githzerai Monk", "2"));
            }

            var result = table.GetResult();
            result.Type = "Intelligent";
            return result;
        }

        public EldUnit Fiends()
        {
            var table = new RandomTable<EldUnit>();

            table.AddItem(Devils());
            table.AddItem(Demons());
            table.AddItem(Yugoloths());

            return table.GetResult();

        }

        public EldUnit Undead(EldBiome biome)
        {
            var table = new RandomTable<EldUnit>();
            if (biome == EldBiome.LightForest)
            {
                table.AddItem(new EldUnit("Gnoll Witherling", "1/4"));
                table.AddItem(new EldUnit("Skeleton", "1/4"), 2);
                table.AddItem(new EldUnit("Zombie", "1/4"), 2);
                table.AddItem(new EldUnit("Will-o-wisp", "2"));
            }
            else if (biome == EldBiome.DeepForest)
            {
                table.AddItem(new EldUnit("Gnoll Witherling", "1/4"), 2);
                table.AddItem(new EldUnit("Skeleton", "1/4"), 1);
                table.AddItem(new EldUnit("Shadow", "1/2"), 2);
                table.AddItem(new EldUnit("Will-o-wisp", "2"));
            }
            else if (biome == EldBiome.Tundra)
            {
                table.AddItem(new EldUnit("Skeleton", "1/4"), 2);
                table.AddItem(new EldUnit("Zombie", "1/4"), 1);
                table.AddItem(new EldUnit("Show Maiden", "1"));
                table.AddItem(new EldUnit("Ghoul", "1"));
                table.AddItem(new EldUnit("Ghast", "2"));
            }
            else if (biome == EldBiome.Hills)
            {
                table.AddItem(new EldUnit("Shadow", "1/2"), 2);
                table.AddItem(new EldUnit("Ghoul", "1"), 3);
                table.AddItem(new EldUnit("Ogre Skeleton", "2"));
            }
            else if (biome == EldBiome.Mountain)
            {
                table.AddItem(new EldUnit("Skeleton", "1/4"), 1);
                table.AddItem(new EldUnit("Shadow", "1/2"), 2);
                table.AddItem(new EldUnit("Specter", "1"), 2);
                table.AddItem(new EldUnit("Ogre Zombie", "2"));
            }
            else if (biome == EldBiome.Dungeon)
            {
                table.AddItem(new EldUnit("Crawling Claw", "0"));
                table.AddItem(new EldUnit("Skeleton", "1/4"), 1);
                table.AddItem(new EldUnit("Zombie", "1/4"), 1);
                table.AddItem(new EldUnit("Shadow", "1/2"), 1);
                table.AddItem(new EldUnit("Ghoul", "1"), 1);
                table.AddItem(new EldUnit("Ghast", "2"));
            }
            else if (biome == EldBiome.Village)
            {
                table.AddItem(new EldUnit("Skeleton", "1/4"), 1);
                table.AddItem(new EldUnit("Zombie", "1/4"), 3);
                table.AddItem(new EldUnit("Ghoul", "1"), 1);
                table.AddItem(new EldUnit("Ghast", "2"));
            }

            var result = table.GetResult();
            result.Type = "Undead";
            return result;
        }

        public EldUnit Demons()
        {
            var table = new RandomTable<EldUnit>();

            table.AddItem(new EldUnit("Manes", "1/8"));
            table.AddItem(new EldUnit("Abyssal Wretch", "1/4"));
            table.AddItem(new EldUnit("Dretch", "1/4"));
            table.AddItem(new EldUnit("Maw Demon", "1"));
            table.AddItem(new EldUnit("Quasit", "1"));
            table.AddItem(new EldUnit("Rutterkin", "2"));

            return table.GetResult();
        }

        public EldUnit Devils()
        {
            var table = new RandomTable<EldUnit>();

            table.AddItem(new EldUnit("Lemure", "0"));
            table.AddItem(new EldUnit("Nupperibo", "1/2"));
            table.AddItem(new EldUnit("Imp", "1"));
            table.AddItem(new EldUnit("Spined Devil", "2"));

            return table.GetResult();
        }

        public EldUnit Yugoloths()
        {
            var table = new RandomTable<EldUnit>();

            table.AddItem(new EldUnit("Octoloth", "0"));
            table.AddItem(new EldUnit("Thrall", "1/8"));
            table.AddItem(new EldUnit("Illacme", "1/4"));
            table.AddItem(new EldUnit("Drudge", "1/2"));
            table.AddItem(new EldUnit("Quisling", "1"));
            table.AddItem(new EldUnit("Apostath", "2"));

            return table.GetResult();
        }

        public EldUnit Savages()
        {
            var table = new RandomTable<EldUnit>();

            table.AddItem(new EldUnit("Commoner", "0"));
            table.AddItem(new EldUnit("Tribal Warrior", "1/8"), 6);
            table.AddItem(new EldUnit("Scout", "1/2"));
            table.AddItem(new EldUnit("Spy", "1"));
            table.AddItem(new EldUnit("Berzerker", "2"));
            table.AddItem(new EldUnit("Druid", "2"));

            var res = table.GetResult();
            res.Name = "Savage " + res.Name;
            return res;
        }

        public EldUnit Gnoll()
        {
            var table = new RandomTable<EldUnit>();

            table.AddItem(new EldUnit("Gnoll", "1/2"), 3);
            table.AddItem(new EldUnit("Gnoll Hunter", "1/2"));
            table.AddItem(new EldUnit("Gnoll Flesh Gnawer", "1"));
            table.AddItem(new EldUnit("Gnoll Pack Lord", "2"));

            return table.GetResult();
        }

        public EldUnit Cultists()
        {
            var die = Dice.Instance;
            var table = new RandomTable<EldUnit>();

            table.AddItem(new EldUnit("Commoner", "0"));
            table.AddItem(new EldUnit("Cultists", "1/8"), 3);
            var group = new EldUnit("Cultist with Commoners", "1/8");
            group.NumAppearing = die.Roll(1, 8) + 2;
            table.AddItem(group);
            table.AddItem(new EldUnit("Cult Fanatic", "2"));

            var res = table.GetResult();
            res.Name = "Cultist " + res.Name;
            return res;
        }

        public EldUnit Bandits()
        {
            var die = Dice.Instance;
            var table = new RandomTable<EldUnit>();

            table.AddItem(new EldUnit("Bandit", "1/8"), 3);
            var group = new EldUnit("Apprentice Wizard and guards", "1/4");
            group.NumAppearing = die.Roll(1, 4) + 1;
            table.AddItem(group);
            table.AddItem(new EldUnit("Night Blade", "1/2"));
            table.AddItem(new EldUnit("Spy", "1"));

            var res = table.GetResult();
            res.Name = "Outlaw " + res.Name;
            return res;
        }

        public EldUnit Blacktalons()
        {
            var die = Dice.Instance;
            var table = new RandomTable<EldUnit>();

            table.AddItem(new EldUnit("Bandit", "1/8"));
            table.AddItem(new EldUnit("Guard", "1/8"));
            table.AddItem(new EldUnit("Apprentice Wizard", "1/4"));
            var group = new EldUnit("Apprentice Wizard and guards", "1/4");
            group.NumAppearing = die.Roll(1, 4) + 1;
            table.AddItem(group);
            table.AddItem(new EldUnit("Night Blade", "1/2"));
            table.AddItem(new EldUnit("Scout", "1/2"));
            table.AddItem(new EldUnit("Thug", "1/2"));
            table.AddItem(new EldUnit("Evil Mage", "1"));
            table.AddItem(new EldUnit("Spy", "1"));
            table.AddItem(new EldUnit("Bandit Captain", "2"));

            var res = table.GetResult();
            res.Name = "Blacktalon " + res.Name;
            return res;
        }

        public EldUnit Hobgoblins()
        {
            var table = new RandomTable<EldUnit>();

            table.AddItem(new EldUnit("Hobgoblin", "1/2"), 5);
            table.AddItem(new EldUnit("Hobgoblin Iron Shadow", "2"));

            return table.GetResult();

        }

        public EldUnit Orcs()
        {
            var table = new RandomTable<EldUnit>();

            table.AddItem(ForestOrcs(), 2);
            table.AddItem(HillOrcs(), 3);
            table.AddItem(MountainOrcs());

            return table.GetResult();
        }

        public EldUnit ForestOrcs()
        {
            var table = new RandomTable<EldUnit>();

            table.AddItem(new EldUnit("Forest Orc", "1/2"), 5);
            table.AddItem(new EldUnit("Forest Orc Claw", "2"));

            return table.GetResult();
        }

        public EldUnit HillOrcs()
        {
            var table = new RandomTable<EldUnit>();

            table.AddItem(new EldUnit("Hill Orc", "1/2"), 4);
            table.AddItem(new EldUnit("Hill Orc Nurtured One", "1/2"));
            table.AddItem(new EldUnit("Hill Orc Eye", "2"));

            return table.GetResult();
        }

        public EldUnit MountainOrcs()
        {
            var table = new RandomTable<EldUnit>();

            table.AddItem(new EldUnit("Mountain Orc", "1/2"), 3);
            table.AddItem(new EldUnit("Mountain Orog", "2"), 2);
            table.AddItem(new EldUnit("Ogre", "2"));

            return table.GetResult();
        }

        public EldUnit Adventurers()
        {
            var table = new RandomTable<EldUnit>();
            table.AddItem(new EldUnit("Bamvo (Orc Warrior)", "1"));
            table.AddItem(new EldUnit("Baxter (Thief)", "1"));
            table.AddItem(new EldUnit("Benedict (Fighter/Thief - Bandit)", "1"));
            table.AddItem(new EldUnit("Benjamin (Figher - Guild)", "1"));
            table.AddItem(new EldUnit("Claire (Wizard)", "1"));
            table.AddItem(new EldUnit("Eunice (Wizard)", "1"));
            table.AddItem(new EldUnit("Jenny (Figher - Guild)", "1"));
            table.AddItem(new EldUnit("Joni (Ranger)", "1"));
            table.AddItem(new EldUnit("Neville (Fighter)", "1"));
            table.AddItem(new EldUnit("'Six' (Imp)", "1"));
            table.AddItem(new EldUnit("Travis (Fighter - Ex Guild)", "1"));
            table.AddItem(new EldUnit("Wild Eye (Barbarian)", "1"));

            table.AddItem(new EldUnit("Charlie (Thief)"));
            table.AddItem(new EldUnit("Bryan (Cleric)"));
            table.AddItem(new EldUnit("Trevor (Fighter)"));
            table.AddItem(new EldUnit("Ada (Wizard)"));
            table.AddItem(new EldUnit("Jack The Jewler (Thief)"));
            table.AddItem(new EldUnit("Audry (Fighter)"));
            table.AddItem(new EldUnit("Alphonse (Thief - bandit)"));
            table.AddItem(new EldUnit("Ivan Blackhand (Fighter - Guild)"));
            table.AddItem(new EldUnit("Horatio (Thief - Guild)"));
            table.AddItem(new EldUnit("Ruben (Fighter - Guild)"));
            table.AddItem(new EldUnit("Tabitha (Monk)"));
            table.AddItem(new EldUnit("Gretchen (Wizard)"));
            table.AddItem(new EldUnit("Marcia (Wizard)"));
            table.AddItem(new EldUnit("Ulysses (Fighter)"));
            table.AddItem(new EldUnit("Dale (Cleric)"));
            table.AddItem(new EldUnit("Luther (Sorcerer)"));
            table.AddItem(new EldUnit("Jus (Druid)"));
            table.AddItem(new EldUnit("Ssa (Ranger - Lizardfolk)"));
            table.AddItem(new EldUnit("Horoch (Ranger - Lizardfolk)"));
            table.AddItem(new EldUnit("Golok (Orc)"));
            table.AddItem(new EldUnit("Bokel (Orc)"));
            table.AddItem(new EldUnit("Orin (Orc Eye)"));
            table.AddItem(new EldUnit("Zulok (Orc)"));
            table.AddItem(new EldUnit("Rocky (Imp)"));
            table.AddItem(new EldUnit("Felor and Blix (Firenewts)"));
            table.AddItem(new EldUnit("Skletch (Firenewt)"));
            table.AddItem(new EldUnit("Furss (Firenewt)"));
            table.AddItem(new EldUnit("Jelex (Firenewt)"));

            return table.GetResult();
        }
    }

}
