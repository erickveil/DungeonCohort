using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Darkmoor;

namespace DungeonCohort
{
    class JgCityEncounter
    {
        public string Type;
        public string Who;
        public int SocialLevel;

        public void init(string quarter)
        {
            var die = Dice.Instance;
            SocialLevel = die.Roll(1, 20);

            if (quarter == "") 
            { 
                Type = "Select Quarter";
                return;
            }

            Type = typeOfEncounter();
            Who = whoEncountered(quarter);
        }

        public string toString()
        {
            string output = "Social Level: " + SocialLevel + "\n" +
                Type + "\n" +
                Who;
            return output;
        }

        public string typeOfEncounter()
        {
            var table = new RandomTable<string>();
            table.AddItem("Attacked by Surprise");
            table.AddItem("Attacked");
            table.AddItem("Slanders/Insults");
            table.AddItem("Questions Characters");
            table.AddItem("Propositions Characters: " + proposition());
            table.AddItem(specialEncounter());
            return table.GetResult();
        }

        public string proposition()
        {
            var table = new RandomTable<string>();
            table.AddItem("Challenge");
            table.AddItem("Search");
            table.AddItem("Task/Mission");
            table.AddItem("Work Offer");
            table.AddItem("Sales Pitch"); // Was "sexual" but... yuck.
            table.AddItem("Kidnap Character");
            return table.GetResult();
        }

        public string specialEncounter()
        {
            var table = new RandomTable<string>();
            table.AddItem("Spit upon");
            table.AddItem("Dishwater from above");
            table.AddItem("Meathook from above");
            table.AddItem("Chamber pot emptied upon");
            table.AddItem("Clay pot hits (stun 1-4 turns)");
            table.AddItem("Brick hits (Unconcious 2-12 turns)");
            table.AddItem("Runaway Carriage (may dodge)");
            table.AddItem("Street caves in 1-6 feet");
            table.AddItem("Impress gang grabs character");
            table.AddItem("Were-rat kidnaps");
            table.AddItem("Beggar");
            table.AddItem("Drunks");
            table.AddItem("Messenger");
            table.AddItem("Performer");
            table.AddItem("Lamplighter");
            table.AddItem("Buffoon");
            table.AddItem("Vigilantes");
            table.AddItem("Town Crier");
            table.AddItem("Fugitive");
            table.AddItem("Hypnotist");
            return table.GetResult();
        }

        public string whoEncountered(string quarter)
        {
            var table = new RandomTable<string>();
            var die = Dice.Instance;
            int num = die.Roll(1, 4);

            table.AddItem(num + " Men: " + socialLevelEncounter(), 4);
            table.AddItem("Unusual: " + unusualEncounter());
            table.AddItem(quarter + " Quarter: " + quartersEncounter(quarter));
            return table.GetResult();
        }

        public string socialLevelEncounter()
        {
            var table = new RandomTable<string>();
            var die = Dice.Instance;
            table.AddItem("[Noble] " + nobleEncounter());
            table.AddItem("[Gentlemen] " + gentlemenEncounter());
            table.AddItem("[Military] " + militaryEncounter());
            table.AddItem("[Guildsmen] " + guildEncounter());
            table.AddItem("[Merchant] " + merchantEncounter());
            table.AddItem("[General] " + generalEncounter());
            return table.GetResult() + " carrying " + carriedCoin();
        }

        public string nobleEncounter()
        {
            var table = new RandomTable<string>();
            var die = Dice.Instance;
            int guardLevel = die.Roll(1, 6);
            int num = die.Roll(2, 6);

            table.AddItem(num + " Garrison Lvl " + guardLevel, 4);
            table.AddItem("Page/Varlet (SL 5)");
            table.AddItem("High Born (SL 6)");
            table.AddItem("Thane (SL 7)");
            table.AddItem("Aristocrat (SL 8)");
            table.AddItem("Knight (SL 9)");
            table.AddItem("Count (SL 10)");
            table.AddItem("Baron (SL 11)");
            table.AddItem("Viscount (SL 12)");
            table.AddItem("Duke (SL 13)");
            table.AddItem("Earl (SL 14)");
            table.AddItem("Senator (SL 15)");
            table.AddItem("Royal Minister (SL 16)");
            table.AddItem("Prince (SL 17)");
            table.AddItem("Queen (SL 18)");
            table.AddItem("King/Overlord (SL 19)");
            table.AddItem("God (SL 20)");
            return table.GetResult(SocialLevel - 1);
        }

        public string gentlemenEncounter()
        {
            var table = new RandomTable<string>();
            var die = Dice.Instance;
            int guardLevel = die.Roll(1, 6);
            int num = die.Roll(2, 6);

            table.AddItem("Garrison Lvl " + guardLevel, 3);
            table.AddItem("Constable (SL 4)");
            table.AddItem("Well Born (SL 5)");
            table.AddItem("Gentry (SL 6)");
            table.AddItem("Chevalier (SL 7)");
            table.AddItem("Pretender (SL 8)");
            table.AddItem("Magistrate (SL 9)");
            table.AddItem("Chief Magistrate (SL 10)");
            table.AddItem("Lord Mayor (SL 11)");
            table.AddItem("Patriarch (SL 12)");
            guardLevel = die.Roll(2, 8);
            table.AddItem(num + " Constable Patrol Lvl " + guardLevel, 3);
            guardLevel = die.Roll(4, 6);
            table.AddItem(num + " Constable Patrol Lvl " + guardLevel, 5);

            return table.GetResult(SocialLevel - 1);
        }

        public string militaryEncounter()
        {
            var table = new RandomTable<string>();

            var die = Dice.Instance;
            int num = die.Roll(2, 6);

            table.AddItem("Gladiator (SL 1)");
            table.AddItem("Page/Servant (SL 2)");
            table.AddItem("Militia (SL 3)");
            table.AddItem("Recruit/Mercenary (SL 4)");
            table.AddItem("Guard/Garrison (SL 5)");
            table.AddItem("Men At Arms (SL 6)");
            table.AddItem("Cavalrymen (SL 7)");
            table.AddItem("Sergeant/Engineer (SL 8)");
            table.AddItem("Squire/Aide (SL 9)");
            table.AddItem("Knight/Captain (SL 10)");
            table.AddItem("Knight Bachelor (SL 11)");
            table.AddItem("Knight Banneret (SL 12)");
            table.AddItem("General (SL 12)");
            table.AddItem("Army Commander (SL 13)");
            int guardLevel = die.Roll(2, 8);
            table.AddItem(num + " Constable Patrol Lvl " + guardLevel);
            guardLevel = die.Roll(4, 6);
            table.AddItem(num + " Constable Patrol Lvl " + guardLevel, 5);
            return table.GetResult(SocialLevel - 1);

        }

        public string guildEncounter()
        {
            var table = new RandomTable<string>();

            var die = Dice.Instance;
            int guardLevel = die.Roll(1, 6);
            int num = die.Roll(2, 6);

            table.AddItem("Beggar");
            table.AddItem("Laborer " + guildsmen());
            table.AddItem("Apprentice " + guildsmen());
            table.AddItem("Journeyman " + guildsmen());
            table.AddItem("Master Craftsman " + guildsmen());
            table.AddItem("Expert " + guildsmen());
            table.AddItem(guildsmen() + " Guildmaster");
            guardLevel = die.Roll(1, 12);
            table.AddItem(num + " Constable Patrol Lvl " + guardLevel, 3);
            guardLevel = die.Roll(2, 8);
            table.AddItem(num + " Constable Patrol Lvl " + guardLevel, 5);
            guardLevel = die.Roll(3, 6);
            table.AddItem(num + " Constable Patrol Lvl " + guardLevel, 5);
            return table.GetResult(SocialLevel - 1);

        }

        public string merchantEncounter()
        {
            var table = new RandomTable<string>();

            var die = Dice.Instance;
            int guardLevel = die.Roll(1, 6);
            int num = die.Roll(2, 6);

            table.AddItem("Garrison Lvl " + guardLevel, 2);
            table.AddItem(merchants() + " Huckster");
            table.AddItem(merchants() + " Vendor");
            table.AddItem(merchants() + " Trader");
            table.AddItem(merchants() + " Monger");
            table.AddItem(merchants() + " Proprieter");
            table.AddItem(merchants() + " Agent");
            table.AddItem(merchants() + " Magnate");
            guardLevel = die.Roll(1, 12);
            table.AddItem(num + " Constable Patrol Lvl " + guardLevel);
            guardLevel = die.Roll(2, 8);
            table.AddItem(num + " Constable Patrol Lvl " + guardLevel, 5);
            guardLevel = die.Roll(3, 6);
            table.AddItem(num + " Constable Patrol Lvl " + guardLevel, 5);

            return table.GetResult(SocialLevel - 1);
        }

        public string generalEncounter()
        {
            var table = new RandomTable<string>();
            table.AddItem("Slave");
            table.AddItem("Serf");
            table.AddItem("Villaine - " + generalHeirarchy());
            table.AddItem("Freeman - " + generalHeirarchy());
            table.AddItem("Citizen - " + generalHeirarchy());
            table.AddItem("Bureacrat");
            table.AddItem("Deputy Sheriff");
            table.AddItem("Sheriff");
            table.AddItem(womanEncounter(), 12);
            return table.GetResult(SocialLevel - 1);

        }

        public string womanEncounter()
        {
            var table = new RandomTable<string>();
            table.AddItem("Slave of (Roll Social Level)");
            table.AddItem("Vixen/Houri");
            table.AddItem("Concubine of (Roll Social Level)");
            table.AddItem("Amazon - " + militaryEncounter());
            table.AddItem("Daughter of (Roll Social Level)");
            var subTable = new RandomTable<string>();
            subTable.AddItem("Barmaid");
            subTable.AddItem("Lady");
            subTable.AddItem("Dame");
            subTable.AddItem("Goddess");
            table.AddItem(subTable.GetResult());
            return "Woman: " + table.GetResult();

        }

        public string carriedCoin()
        {
            var table = new RandomTable<string>();

            var die = Dice.Instance;
            int d4 = die.Roll(1, 4);
            int d6 = die.Roll(1, 6);
            int d8 = die.Roll(1, 8);

            table.AddItem(d4 + " cp");
            table.AddItem(d6 + " cp");
            table.AddItem(d4 + " sp");
            table.AddItem(d4 + " gp");
            table.AddItem(d8 + " gp");

            table.AddItem(die.Roll(2,6) + " gp");
            table.AddItem(die.Roll(3,6) + " gp");
            table.AddItem(die.Roll(2,12) + " gp");
            table.AddItem(die.Roll(2,20) + " gp");
            table.AddItem(die.Roll(3,20) + " gp");

            table.AddItem(die.Roll(4,20) + " gp");
            table.AddItem(die.Roll(5,20) + " gp");
            table.AddItem(die.Roll(6,20) + " gp");
            table.AddItem(die.Roll(7,20) + " gp");
            table.AddItem(die.Roll(8,20) + " gp");

            table.AddItem(die.Roll(9,20) + " gp");
            table.AddItem(die.Roll(10,20) + " gp");
            table.AddItem(die.Roll(11,20) + " gp");
            table.AddItem(die.Roll(12,20) + " gp");
            table.AddItem(die.Roll(13,20) + " gp");

            return table.GetResult(SocialLevel - 1);
        }

        public string unusualEncounter()
        {
            var table = new RandomTable<string>();
            table.AddItem("Troll");
            table.AddItem("Paladin");
            table.AddItem("Shadows");
            table.AddItem("Harpies");
            table.AddItem("Lammasu");
            table.AddItem("Giant");
            table.AddItem("Thief");
            table.AddItem("Wight");
            table.AddItem("Golem");
            table.AddItem("Wraith");
            table.AddItem("Blink Dog");
            table.AddItem("Zombies");
            table.AddItem("Skeletons");
            table.AddItem("Dervishes");
            table.AddItem("Illusionist");
            table.AddItem("Invisible Stalker");
            table.AddItem("Mind Flayer");
            table.AddItem("Golden Dragon");
            table.AddItem("Clerical Type");
            table.AddItem("Magic User Type");
            return table.GetResult();

        }

        public string quartersEncounter(string quarter)
        {
            switch (quarter)
            {
                case "Noble":
                    return nobleQuarters();
                case "Common":
                    return commonQuarters();
                case "Plaza":
                    return plazasQuarters();
                case "Seafront":
                    return seafrontQuarters();
                case "Merchant":
                    return merchantQuarter();
                case "Thieves":
                    return thievesQuarter();
                default:
                    return "Unrecognized Quarter: " + quarter;
            }
        }

        public string nobleQuarters()
        {
            var table = new RandomTable<string>();
            table.AddItem("Sheriff");
            table.AddItem("Knight");
            table.AddItem(generalEncounter());
            table.AddItem(gentlemenEncounter());
            table.AddItem(nobleEncounter());
            table.AddItem(nobleEncounter());
            return table.GetResult();
        }

        public string commonQuarters()
        {
            var table = new RandomTable<string>();
            table.AddItem("Goblin");
            table.AddItem("Orc");
            table.AddItem("Ogre");
            table.AddItem("Bandit");
            table.AddItem("Dwarf");
            table.AddItem("Giant Rat");
            return table.GetResult();
        }

        public string plazasQuarters()
        {
            var table = new RandomTable<string>();
            table.AddItem("Sharper/Gambler Con");
            table.AddItem("Beggar");
            table.AddItem("Slaver");
            table.AddItem("Performer");
            table.AddItem("Bard");
            table.AddItem("Mercenary");
            return table.GetResult();
        }

        public string seafrontQuarters()
        {
            var table = new RandomTable<string>();
            table.AddItem("Sailor");
            table.AddItem("Sailor");
            table.AddItem("Bucaneer");
            table.AddItem("Pirate");
            table.AddItem("Sea Captain");
            table.AddItem("Beggar");
            return table.GetResult();
        }

        public string merchantQuarter()
        {
            var table = new RandomTable<string>();
            table.AddItem("Robber");
            table.AddItem("Guard");
            table.AddItem(merchantEncounter(), 4);
            return table.GetResult();


        }

        public string thievesQuarter()
        {
            var table = new RandomTable<string>();
            table.AddItem("Apprentice");
            table.AddItem("Apprentice");
            table.AddItem("Footpad");
            table.AddItem("Robber");
            table.AddItem("Burglar");
            table.AddItem("Cutpurse");
            return table.GetResult();
        }

        public string guildsmen()
        {
            var table = new RandomTable<string>();
            table.AddItem("Accountant");
            table.AddItem("Alchemist");
            table.AddItem("Armorer");
            table.AddItem("Artist");
            table.AddItem("Assassin");
            table.AddItem("Astrologer");
            table.AddItem("Astronomer");
            table.AddItem("Author");
            table.AddItem("Beggar");
            table.AddItem("Boatmaker");
            table.AddItem("Bootmaker");
            table.AddItem("Botanist");
            table.AddItem("Bowmaker");
            table.AddItem("Bricklayer");
            table.AddItem("Carpenter");
            table.AddItem("Carpetmaker");
            table.AddItem("Carver");
            table.AddItem("Courtesan");
            table.AddItem("Engineer");
            table.AddItem("Executioneer");
            table.AddItem("Fletcher");
            table.AddItem("Geologist");
            table.AddItem("Glass-blower");
            table.AddItem("Goldsmith");
            table.AddItem("Hatmaker");
            table.AddItem("Inkmaker");
            table.AddItem("Interpereter");
            table.AddItem("Jeweller");
            table.AddItem("Lampmaker");
            table.AddItem("Leather craftsman");
            table.AddItem("Litigation trickster");
            table.AddItem("Mason");
            table.AddItem("Miner");
            table.AddItem("Magic User");
            table.AddItem("Mercenary");
            table.AddItem("Metal worker");
            table.AddItem("Navigator");
            table.AddItem("Perfumer/Dyer");
            table.AddItem("Pitchmaker");
            table.AddItem("Poet/Bard");
            table.AddItem("Potter");
            table.AddItem("Roofer");
            table.AddItem("Ropemaker");
            table.AddItem("Saddlemaker");
            table.AddItem("Sailmaker");
            table.AddItem("Sculptor");
            table.AddItem("Sailor");
            table.AddItem("Sage");
            table.AddItem("Smith");
            table.AddItem("Shipbuilder");
            table.AddItem("Slaver");
            table.AddItem("Scribe");
            table.AddItem("Thief");
            table.AddItem("Tailor");
            table.AddItem("Tanner");
            table.AddItem("Weaver");
            table.AddItem("Wig/Mask maker");
            table.AddItem("Wheelright");
            table.AddItem("Winemaker");

            return table.GetResult();
        }

        public string generalHeirarchy()
        {
            var table = new RandomTable<string>();
            table.AddItem(officialHeir());
            table.AddItem(servicesHeir());
            table.AddItem(trainerHeir());
            table.AddItem(performersHeir());
            table.AddItem(clericalHeir());
            table.AddItem(miscHeir());
            return table.GetResult();

        }

        public string officialHeir()
        {
            var table = new RandomTable<string>();
            table.AddItem("Moneylender");
            table.AddItem("Moneychanger");
            table.AddItem("Tax collector");
            table.AddItem("Banker");
            table.AddItem("Court Clerk");
            table.AddItem("Bureaucratic");
            return table.GetResult();

        }

        public string servicesHeir()
        {
            var table = new RandomTable<string>();
            table.AddItem("Teacher");
            table.AddItem("Maid/Butler");
            table.AddItem("Bathboy");
            table.AddItem("Doorman/Bouncer");
            table.AddItem("Wet Nurse");
            table.AddItem("Barkeeper");
            table.AddItem("Porter/Bearer");
            table.AddItem("Messenger");
            table.AddItem("Secretary/Aide");
            table.AddItem("Attendant");
            table.AddItem("Cook");
            table.AddItem("Warehouseman");
            return table.GetResult();

        }

        public string trainerHeir()
        {
            var table = new RandomTable<string>();
            table.AddItem("Shepherd");
            table.AddItem("Cowpoke");
            table.AddItem("Horsetrainer");
            table.AddItem("Animaltrainer");
            table.AddItem("Birdtrainer");
            table.AddItem("Gladiator trainer");
            return table.GetResult();

        }

        public string performersHeir()
        {
            var table = new RandomTable<string>();
            table.AddItem("Dancer");
            table.AddItem("Actor");
            table.AddItem("Minstrel");
            table.AddItem("Jester/Buffoon");
            table.AddItem("Puppeteer");
            table.AddItem("Circus performer");
            table.AddItem("Fortuneteller");
            table.AddItem("Orator");
            return table.GetResult();

        }

        public string clericalHeir()
        {
            var table = new RandomTable<string>();
            table.AddItem("Stockboy");
            table.AddItem("Clerk");
            table.AddItem("Head Clerk");
            table.AddItem("Manager");
            return table.GetResult() + " employed by " + merchants();

        }

        public string miscHeir()
        {
            var table = new RandomTable<string>();
            table.AddItem("Leech/doctor");
            table.AddItem("Undertaker");
            table.AddItem("Pawnshopkeeper");
            table.AddItem("Zookeeper");
            table.AddItem("Tavernkeeper");
            table.AddItem("Innkeeper");
            table.AddItem("Launderer");
            table.AddItem("Barber");
            table.AddItem("Butcher");
            table.AddItem("Baker");
            table.AddItem("Candlestickmaker");
            table.AddItem("Hunter");
            table.AddItem("Pipeweed grower");
            table.AddItem("Wagoneer");
            table.AddItem("Hypnotist");
            table.AddItem("Towncrier");
            table.AddItem("Lamplighter");
            table.AddItem("Mountaineer");
            table.AddItem("Fisherman");
            table.AddItem("Trapper");
            return table.GetResult();

        }

        public string merchants()
        {
            var table = new RandomTable<string>();
            table.AddItem(merchCommon(), 7);
            table.AddItem(merchRare(), 3);
            table.AddItem(merchExtraordinary());
            return table.GetResult();

        }

        public string merchCommon()
        {
            var table = new RandomTable<string>();
            table.AddItem("Food Stuffs");
            table.AddItem("Wine");
            table.AddItem("Beer");
            table.AddItem("Clothing");
            table.AddItem("Small Livestock");
            table.AddItem("Rope");
            table.AddItem("Tools");
            table.AddItem("Feeds & seeds");
            return table.GetResult();

        }

        public string merchRare()
        {
            var table = new RandomTable<string>();
            table.AddItem("Armorer");
            table.AddItem("Weapons");
            table.AddItem("Foundry");
            table.AddItem("Horses");
            table.AddItem("Cattle");
            table.AddItem("Shipyard");
            table.AddItem("Leather goods");
            table.AddItem("Wagon caravan");
            table.AddItem("Hotelier");
            table.AddItem("Spices");
            table.AddItem("Rugs/Tapestries");
            table.AddItem("Building Supplies");
            table.AddItem("Books/Art Objects");
            table.AddItem("Quarry/Mines");
            table.AddItem("Precious Gems & Metals");
            table.AddItem("Timber/Pitch");
            table.AddItem("Perfume/Soap");
            table.AddItem("Showman");
            table.AddItem("Processed Foods");
            table.AddItem("Shipping Line");
            return table.GetResult();

        }

        public string merchExtraordinary()
        {
            var table = new RandomTable<string>();
            table.AddItem("Magic Weapons");
            table.AddItem("Magic Armor");
            table.AddItem("Magic Items");
            table.AddItem("Magic Scrolls & Books");
            table.AddItem("Unusual Potions");
            table.AddItem("Fantastic Creature");
            table.AddItem("Fantastic Creature Eggs");
            table.AddItem("Fantastic Creature Parts");

            var die = Dice.Instance;
            int num = die.Roll(1, 4);
            return table.GetResult() + " (with " + num + " items)";


        }

    }
}
