using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Darkmoor;

namespace DungeonCohort
{
    class EldQuests
    {
        public static string EldRandomQuest()
        {
            var table = new RandomTable<string>();

            string creature = EldCreature();
            string furnishing = GeneralFurnishingsAndAppointments();
            string item = UtensilsAndPersonalItems();
            string location = EldQuestLocation();
            var eldTables = new EldTables();
            string npc = eldTables.Adventurers().Name;

            var macguffinTable = new RandomTable<string>();
            macguffinTable.AddItem(furnishing);
            macguffinTable.AddItem(item);
            string macguffin = macguffinTable.GetResult();

            var subjectTable = new RandomTable<string>();
            subjectTable.AddItem(macguffin);
            subjectTable.AddItem(location);
            var subject = subjectTable.GetResult();

            var victimTable = new RandomTable<string>();
            victimTable.AddItem(npc);
            victimTable.AddItem(creature);
            string victim = victimTable.GetResult();

            var lostTable = new RandomTable<string>();
            lostTable.AddItem(macguffin);
            lostTable.AddItem(eldTables.Adventurers().Name);
            string lost = lostTable.GetResult();

            var deliveryTable = new RandomTable<string>();
            deliveryTable.AddItem(macguffin);
            deliveryTable.AddItem(creature);
            string delivery = deliveryTable.GetResult();

            var dangerTable = new RandomTable<string>();
            dangerTable.AddItem(npc);
            dangerTable.AddItem(location);
            string danger = dangerTable.GetResult();

            table.AddItem("Find " + macguffin + " at " + location + " and return to " + npc);
            table.AddItem("Observe " + npc + " at " + location);
            table.AddItem("Talk to " + npc + " about " + subject);
            table.AddItem("Sell " + macguffin + " to " + npc);
            table.AddItem("Buy " + macguffin + " from " + npc);
            table.AddItem("Steal " + macguffin + " from " + victim);
            table.AddItem("Find " + lost + " at " + location);
            table.AddItem("Escort " + npc + " to " + location);
            table.AddItem("Protect " + npc + " as they explore " + location);
            table.AddItem("Deliver " + delivery + " to " + npc);
            table.AddItem("Capture " + victim + " at " + location);
            table.AddItem("Stop " + npc + " from killing " + victim);
            table.AddItem("Destroy " + macguffin + " at " + location);
            table.AddItem("Defend " + location + " against " + victim);
            table.AddItem("Rescue " + npc + " from " + location);
            table.AddItem("Save " + victim + " from " + danger);
            table.AddItem("Help " + npc + " kill " + eldTables.Adventurers().Name);
            table.AddItem("Kill " + victim + " and reclaim " + macguffin);
            table.AddItem("Slay " + creature + " at " + location);

            var investigationTable = new RandomTable<string>();
            investigationTable.AddItem("Investigate Murder of " + npc + " at " + location);
            investigationTable.AddItem("Investigate " + npc + " missing from " + location);
            investigationTable.AddItem("Investigate theft of " + macguffin + " from " + location);
            investigationTable.AddItem("Investigate enemy strength at " + location);
            investigationTable.AddItem("Obtain plans from " + victim  + " at " + location);
            investigationTable.AddItem("Map out " + location);
            string investigation = investigationTable.GetResult();

            table.AddItem(investigation);

            return table.GetResult();
        }

        public static string SpecificAdventures()
        {
            var table = new RandomTable<string>();

            table.AddItem("Find the survivors that ventured out to the Ruins of Randchadt. They haven’t reported back in days and the weather has been calm the entire time.");
            table.AddItem("Something about the Farmer is off. Note his routine for the next 48 hours and share what you find with the Guard.");
            table.AddItem("Learn what you can from Katala about what lies beneath The Dead Circle.");
            table.AddItem("A man at Crumblestone Bridge awaits anyone willing to sell a child’s tooth or a Winter Wolf’s paw. Meet him and make note of what he offers.");
            table.AddItem("A young Dark Elf has secrets to sell to the highest bidder. Take out the competition and win her favor.");
            table.AddItem("Steal an apple from the tree that grows outside Kiraye Ka and get it to Six.");
            table.AddItem("Find the Golden Wolf that ate Ada’s glasses at Breen the Frozen Lake.");
            table.AddItem("Escort the village Elder as she makes her pilgrimage to the Sacrificial Altar and performs her offering to Mitra.");
            table.AddItem("Serve as protection for the Pixies as they try to save their sister from the Copper Hill Mines.");
            table.AddItem("Take the Ancient Sapphire Scrolls from the Canto Shrine to the Castellan of Raptorclaw Keep without The Guild finding out.");
            table.AddItem("The people of Viehdorf Hamlet need help capturing an infected Giant Stag stalking around Darkpine Woods.");
            table.AddItem("Bandits plan to stage “an accident” at the Greenfield Hamlet Market to kill a member of the Blacktalons and must be stopped.");
            table.AddItem("Slaves have found a map detailing the treasures of the Copper Hill Mines and it must be destroyed.");
            table.AddItem("Defend Hemhill Hamlet from Savages being controlled by a Bugbear. ");
            table.AddItem("Save an Infant Savage from the Orc Eye before she sacrifices it to Lucifax at the Sacrificial Altar.");
            table.AddItem("Help Benda Keeper defend the Stadschmieden Inn from Undead for three nights until the Blacktalons arrive.");
            table.AddItem("Aid the Bandits in killing the Guild Caravan Master without the Guildmaster finding out so they can sell him false route maps.");
            table.AddItem("Reclaim the Fire King’s Barrow from Gozul the Worm before the snowstorm arrives.");
            table.AddItem("Ice Spider swarms are ravaging the Hemhill crops. Find their Nest and kill them all.");

            return table.GetResult();
        }

        public static string GeneralQuestGiver()
        {
            var table = new RandomTable<string>();

            var die = Dice.Instance;
            int d12 = die.Roll(1, 12);
            int d24 = die.Roll(2, 12);
            int d6 = die.Roll(1, 6);

            var nonhuman = new RandomTable<string>();
            nonhuman.AddItem("Elf from the Fey Realm");
            nonhuman.AddItem("Dwarf from Waystone");
            nonhuman.AddItem("Githzerai Magically disguised as a foreigner");
            nonhuman.AddItem("Daemon Cloaked from view or disguised as a friend");
            nonhuman.AddItem("Half-orc ambassador");
            nonhuman.AddItem("Hobgoblin ambassador");
            

            table.AddItem("Talon Officer with " + d12 + " soldiers");
            table.AddItem("Wizard with " + d6 + " guards");
            table.AddItem("Merchant with " + d24 + " guards");
            table.AddItem(nonhuman.GetResult());
            table.AddItem("Scholar");
            table.AddItem("Priest or cultist with " + d12 + " guards");
            table.AddItem("Officer of the Guild with " + d12 + " guards");
            table.AddItem("Ranger");
            table.AddItem("Marevak the Advisor with " + d24 + " guards");

            bool hasGuards = die.Roll(1, 10) < 7;
            string guards = hasGuards ? " with " + d12 + " guards" : "";
            table.AddItem("Foreigner: ambassador, spy" + guards);

            return table.GetResult();
        }

        public static string GeneralMisson()
        {
            var table = new RandomTable<string>();
            table.AddItem("Join Trading Party");
            table.AddItem("Quest for a specific object or person");

            var intrigueTable = new RandomTable<string>();
            intrigueTable.AddItem("Help in a quarrel");
            intrigueTable.AddItem("Join in a political intrigue");
            intrigueTable.AddItem("Assassinate visitor's enemy");
            intrigueTable.AddItem("Fight as champion in a duel");
            intrigueTable.AddItem("Steal plans");
            intrigueTable.AddItem("Spy on a meeting");
            intrigueTable.AddItem("Intercept a messenger");


            table.AddItem(intrigueTable.GetResult());
            table.AddItem("Join visitor's army or act as bodyguard");
            table.AddItem("Join in a raiding party to outlying area");
            table.AddItem("Join in a dungeon expedition");
            table.AddItem("Explore a hex to find a hidden location");
            table.AddItem("Vist visitor's home (purpose decided by DM");
            table.AddItem("Defend a village, area, hex, strategic point for a time");
            table.AddItem("Go upon secret mission for a faction");

            return table.GetResult();
        }

        public static string VisitorQuest()
        {
            return "Visitor: " + GeneralQuestGiver() + "\nMission: " + GeneralMisson();
        }

        public static string Rumors()
        {
            var eldTables = new EldTables();
            string who = eldTables.Adventurers().Name;

            string what = EldRandomQuest();

            var resultTable = new RandomTable<string>();
            resultTable.AddItem("Never returned");
            resultTable.AddItem("Reported a treasure they intend to go back and get");
            resultTable.AddItem("Bragged of treasure with more to obtain");
            resultTable.AddItem("Barely made it back alive");
            resultTable.AddItem("Is planning to go but has not yet");
            resultTable.AddItem("Rejected quest");
            resultTable.AddItem("Was unable to obtain a magic item");
            resultTable.AddItem("Was defeated by a villain with a magic item");

            string result = "Who: " + who + "\nWhat: " + what + "\nResult: " + resultTable.GetResult();
            return result;
        }

        public static string EldCreature()
        {
            var table = new RandomTable<string>();

            // tier 0
            table.AddItem("Giant Wolf Spider");
            table.AddItem("Velociraptor");
            table.AddItem("Wolf");
            table.AddItem("Giant Hyena");
            table.AddItem("Show Leopard");
            table.AddItem("Giant Elk");
            table.AddItem("Dimetrodon");
            table.AddItem("Ape");
            table.AddItem("Brown Bear");
            table.AddItem("Giant Raven");
            table.AddItem("Su-Monster");
            table.AddItem("Giant Boar");
            table.AddItem("Wild Dog");
            table.AddItem("Giant Wasp");
            table.AddItem("Deinonychus");
            table.AddItem("Ice Spider");
            table.AddItem("Young Winter Wolf");
            table.AddItem("Ice Spider Queen");
            table.AddItem("Giant Lizard");
            table.AddItem("Clawfoot");
            table.AddItem("Dire Wolf");
            table.AddItem("Giant Vulture");
            table.AddItem("Allosaurus");
            table.AddItem("Giant Bat");
            table.AddItem("Pteranodon");
            table.AddItem("Giant Goat");
            table.AddItem("Giant Eagle");
            table.AddItem("Crag Cat");
            table.AddItem("Cave Bear");
            table.AddItem("Giant Fire Beetle");
            table.AddItem("Stirge");
            table.AddItem("Giant Centipede");
            table.AddItem("Darkmantle");
            table.AddItem("Giant Spider");
            table.AddItem("Carrion Crawler");
            table.AddItem("Mastiff");
            table.AddItem("Giant Rat");
            table.AddItem("Wolf");
            table.AddItem("Giant Wolf Spider");
            table.AddItem("Aurochs");
            table.AddItem("Goblin");
            table.AddItem("Bugbear");
            table.AddItem("Dark Elf");
            table.AddItem("Gnoll");
            table.AddItem("Orc");
            table.AddItem("Hobgoblin");
            table.AddItem("Ogre");
            table.AddItem("Kobold");
            table.AddItem("Half Ogre");
            table.AddItem("Meazel");
            table.AddItem("Quaggoth");


            return table.GetResult();
        }


        public static string EldQuestLocation()
        {
            var table = new RandomTable<string>();

            table.AddItem("39-01 Kleiderdorf");
            table.AddItem("39-02 Godstone");
            table.AddItem("40-01 The Hellhive");
            table.AddItem("40-03 The Ring Barrow");
            table.AddItem("41-01 Stadschmieden Inn");
            table.AddItem("41-03 Floating Stones");
            table.AddItem("47-01 The Fields of Bone");
            table.AddItem("47-02 Ancient Valley");
            table.AddItem("47-03 Blink Dog Den");
            table.AddItem("48-01 Hermit's House");
            table.AddItem("48-02 Moon Gate");
            table.AddItem("48-03 A Hole in the Earth");
            table.AddItem("49-01 Bandit Encampment");
            table.AddItem("49-02 Magic Dead Light Stone");
            table.AddItem("49-03 The Healing Spring");
            table.AddItem("50-01 The Dwarven Hold of Waystone");
            table.AddItem("50-02 The Fountain of Folly");
            table.AddItem("50-03 The Fire King's Barrow");
            table.AddItem("57-01 Doomwood");
            table.AddItem("57-02 Tower of the Necromancer's Apprentice");
            table.AddItem("57-03 Thoromere's Throne");
            table.AddItem("58-01 Viehdorf Hamlet");
            table.AddItem("58-02 Orc Outpost Ya-Awk");
            table.AddItem("58-03 Sacraficial Altar");
            table.AddItem("59-01 Darkpine Woods");
            table.AddItem("59-02 Kedamaian - The Zerth Tower");
            table.AddItem("60-01 Copper Hill");
            table.AddItem("60-02 Giant Statue of the Old Queen");
            table.AddItem("60-03 Common Camp Site");
            table.AddItem("66-01 Canto Shrine");
            table.AddItem("66-02 The Raven Tree");
            table.AddItem("66-03 Fire Newt Hold");
            table.AddItem("69-03 The Dungeons of Behalten");
            table.AddItem("75-01 Hemhill Hamlet");
            table.AddItem("75-02 Deep Well");
            table.AddItem("75-03 Wererat's Home");
            table.AddItem("76-03 Ruined Dwarven Hold");
            table.AddItem("77-01 Breen the Frozen Lake");
            table.AddItem("77-02 Ruined Paladin Chapel");
            table.AddItem("77-03 The Embedded Sword");
            table.AddItem("78-01 The Ghost Town of Weizendorf");
            table.AddItem("78-02 The Unstrung Harp");
            table.AddItem("78-03 The Dead Circle");
            table.AddItem("79-01 Chopped Natural Columns");
            table.AddItem("85-01 The Lone Tomb");
            table.AddItem("85-02 The Ice Pool");
            table.AddItem("86-01 The Ruins of Ranchadt");

            return table.GetResult();
        }

        public static string GeneralFurnishingsAndAppointments()
        {
            var table = new RandomTable<string>();

            table.AddItem("Altar");
            table.AddItem("Curtain");
            table.AddItem("Bag");
            table.AddItem("Barrel");
            table.AddItem("Bed");
            table.AddItem("Blanket");
            table.AddItem("Box");
            table.AddItem("Brazier");
            table.AddItem("Bucket");
            table.AddItem("Cabinet");
            table.AddItem("Candelabrum");
            table.AddItem("Carpet");
            table.AddItem("Cask");
            table.AddItem("Chandeller");
            table.AddItem("Chair");
            table.AddItem("Chest");
            table.AddItem("Wardrobe");
            table.AddItem("Coal");
            table.AddItem("Couch");
            table.AddItem("Crate");
            table.AddItem("Cushion");
            table.AddItem("Grindstone");
            table.AddItem("Idol");
            table.AddItem("Keg");
            table.AddItem("Loom");
            table.AddItem("Painting");
            table.AddItem("Pedestal");
            table.AddItem("Pillow");
            table.AddItem("Quilt");
            table.AddItem("Rug");
            table.AddItem("Sack");
            table.AddItem("Shrine");
            table.AddItem("Sofa");
            table.AddItem("Staff");
            table.AddItem("Stool");
            table.AddItem("Table");
            table.AddItem("Tapestry");
            table.AddItem("Throne");
            table.AddItem("Trunk");
            table.AddItem("Tub");
            table.AddItem("Urn");

            return table.GetResult();
        }

        public static string UtensilsAndPersonalItems()
        {
            var table = new RandomTable<string>();

            table.AddItem("Basin");
            table.AddItem("Basket");
            table.AddItem("Book");
            table.AddItem("Bottle");
            table.AddItem("Bowl");
            table.AddItem("Box");
            table.AddItem("Brush");
            table.AddItem("Candle");
            table.AddItem("Candle Snuffer");
            table.AddItem("Candlestick");
            table.AddItem("Walking Cane");
            table.AddItem("Case");
            table.AddItem("Small Casket");
            table.AddItem("Coffer");
            table.AddItem("Perfume");
            table.AddItem("Comb");
            table.AddItem("Cup");
            table.AddItem("Decanter");
            table.AddItem("Dish");
            table.AddItem("Flagon");
            table.AddItem("Flask");
            table.AddItem("Jar");
            table.AddItem("Fork");
            table.AddItem("Grinder");
            table.AddItem("Drinking Horn");
            table.AddItem("Hourglass");
            table.AddItem("Jug");
            table.AddItem("Kettle");
            table.AddItem("Key");
            table.AddItem("Knife");
            table.AddItem("Dice");
            table.AddItem("Ladle");
            table.AddItem("Lamp");
            table.AddItem("Lantern");
            table.AddItem("Mirror");
            table.AddItem("Needle");
            table.AddItem("Scented Oil");
            table.AddItem("Lamp Oil");
            table.AddItem("Parchment");
            table.AddItem("Flute");
            table.AddItem("Smoking Pipe");
            table.AddItem("Pouch");
            table.AddItem("Powder");
            table.AddItem("Quill");
            table.AddItem("Razor");
            table.AddItem("Rope");
            table.AddItem("Salve");
            table.AddItem("Scroll");
            table.AddItem("Soap");
            table.AddItem("Spoon");
            table.AddItem("Statuette");
            table.AddItem("Figurine");
            table.AddItem("Thread");
            table.AddItem("Tinderbox");
            table.AddItem("Towel");
            table.AddItem("Tray");
            table.AddItem("Twine");
            table.AddItem("Vase");
            table.AddItem("Vial");
            table.AddItem("Whetstone");
            table.AddItem("Wig");
            table.AddItem("Wool");
            table.AddItem("Yarn");

            return table.GetResult();
        }


    }
}
