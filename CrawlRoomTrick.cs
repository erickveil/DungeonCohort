using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class CrawlRoomTrick
    {
        public string Object;
        public string Effect;

        public static string ChooseTrickObject()
        {
            var table = new RandomTable<string>();

            string liquid = ChoosePoolLiquid();

            // gate? 

            table.AddItem("Altar");
            table.AddItem("Pool: " + liquid);
            table.AddItem("Fountain");
            table.AddItem("Statue");
            table.AddItem("Great Crystal");
            table.AddItem("Crystal Ball");
            table.AddItem("Throne");
            table.AddItem("Giant mushroom");
            table.AddItem("Massive tome");
            table.AddItem("Tree");
            table.AddItem("Rune engraved on the wall");
            table.AddItem("Skull");
            table.AddItem("Sphere of magical energy");
            table.AddItem("Stone obelisk");
            table.AddItem("Coin");
            table.AddItem("Anvil");
            table.AddItem("Cauldron");
            table.AddItem("Pedestal");
            table.AddItem("Urn");
            table.AddItem("Tomb");
            table.AddItem("Gong");
            table.AddItem("Bowl");
            table.AddItem("Magic circle");
            table.AddItem("Prism");
            table.AddItem("Hourglass");
            table.AddItem("Mirror");
            table.AddItem("Sarcophagus");

            return table.GetResult();
        }

        public static string ChooseMundaneFeature()
        {
            var table = new RandomTable<string>();
            table.AddItem(ChooseTrickObject(), 32);
            table.AddItem("Balcony above to adjacent area above");
            table.AddItem("Balcony over adjacent area below");
            table.AddItem("Iron grate over crawlway that leads " 
                + ChooseDirection());
            return table.GetResult();
        }

        public static string ChooseTrickEffect()
        {
            var table = new RandomTable<string>();
            string damageType = ChooseDamageType();
            string align = ChooseAlignment();
            string geas = ChooseGeas();
            string suggestion = ChooseSuggestion();
            string attribute = ChooseAttribute();

            table.AddItem("Ages the first person who interacts 2d8 years");
            table.AddItem("Bestows resistance to " + damageType);
            table.AddItem("Bestows vulnerability to " + damageType);
            table.AddItem("Changes alignment to " + align);
            table.AddItem("Turns nonmagical iron armor to rust");
            table.AddItem("Turns all gold on character to lead");
            table.AddItem("Suppresses non-cursed magic items");
            table.AddItem("Enlarges characters");
            table.AddItem("Shrinks characters");
            table.AddItem("Grants a wish");
            table.AddItem("Casts geas on characters: " + geas);
            table.AddItem("Increases gravity - str save or fall prone");
            table.AddItem("Reverses gravity - fall to ceiling");
            table.AddItem("Contains an imprisoned creature");
            table.AddItem("Locks all exits");
            table.AddItem("Summons monsters");
            table.AddItem("Casts suggestion on the characters: " + suggestion);
            table.AddItem("Makes a loud wail or sound when touched " +
                "(roll for random encounters)");
            table.AddItem("Swaps two characters' minds");
            table.AddItem("Heals 2d8 hp");
            table.AddItem("Drains 2d8 hp");
            table.AddItem("Makes first character to interact 2d8 years " +
                "younger");
            table.AddItem("Changes gender (only works once)");
            table.AddItem("Temporary add 1 point to " + attribute);
            table.AddItem("Temporary subtract 1 point from" + attribute);
            table.AddItem("Tempoary add 1 level to all spells cast");
            table.AddItem("Add 1 temporary AC");
            table.AddItem("Subtract 1 temporary AC");
            table.AddItem("Removes all exhaustion");
            table.AddItem("Adds 1 level of exhaustion");
            table.AddItem("Adds poisoned state");
            table.AddItem("Character tempoary glows with faerie fire");
            table.AddItem("First weapon temporarily act as magical +1");
            table.AddItem("Weapons temporarily act as magical -1");
            table.AddItem("Grants inspiration to first character"); 
            table.AddItem("Mends and cleans character and all equipment");
            table.AddItem("Soils character and makes them stink of garbage. " +
                "Double all wandering monster chances.");
            table.AddItem("First character gains benefit of a short rest");
            table.AddItem("First charactet gains benefit of a long rest");
            table.AddItem("Characters lose 1d4 hit dice available for resting");
            table.AddItem("Drains highest spell slot, 1d4 ki points or " +
                "psi points");

            return table.GetResult();
        }


        public static string ChooseDirection()
        {
            var table = new RandomTable<string>();
            table.AddItem("north");
            table.AddItem("south");
            table.AddItem("east");
            table.AddItem("west");
            table.AddItem("up");
            table.AddItem("down");
            return table.GetResult();
        }

        public static string ChooseDamageType()
        {
            var table = new RandomTable<string>();
            table.AddItem("Piercing");
            table.AddItem("Slashing");
            table.AddItem("Bludgeoning");
            table.AddItem("Acid");
            table.AddItem("Poison");
            table.AddItem("Necrotic");
            table.AddItem("Radiant");
            table.AddItem("Lightning");
            table.AddItem("Thunder");
            table.AddItem("Psychic");
            table.AddItem("Fire");
            table.AddItem("Cold");

            return table.GetResult();
        }

        public static string ChooseAlignment()
        {
            var table = new RandomTable<string>();
            table.AddItem("Lawful Good");
            table.AddItem("Neutral Good");
            table.AddItem("Chaotic Good");
            table.AddItem("Lawful Neutral");
            table.AddItem("True Neutral");
            table.AddItem("Chaotic Neutral");
            table.AddItem("Lawful Evil");
            table.AddItem("Neutral Evil");
            table.AddItem("Chaotic Evil");
            return table.GetResult();
        }

        public static string ChooseGeas()
        {
            var table = new RandomTable<string>();
            table.AddItem("Kill an NPC in the dungeon");
            table.AddItem("Get a treasure and leave it here");
            table.AddItem("Find a magic itme and leave it here");
            table.AddItem("Find an NPC and bring them here alive");
            table.AddItem("Forge a truce between two factions");
            table.AddItem("Deliver an item to a place");
            return table.GetResult();
        }

        public static string ChooseSuggestion()
        {
            var table = new RandomTable<string>();
            table.AddItem("Leave the dungeon");
            table.AddItem("Leave behind all armor");
            table.AddItem("Surrender to the first monster you encounter");
            table.AddItem("Perform a quest: " + ChooseGeas());
            table.AddItem("Rest here - take a nap");
            table.AddItem("Leave behind all weapons");
            table.AddItem("Guard this room from all intruders");
            return table.GetResult();
        }

        public static string ChooseAttribute()
        {
            var table = new RandomTable<string>();
            table.AddItem("Strength");
            table.AddItem("Dexterity");
            table.AddItem("Constitution");
            table.AddItem("Intellegence");
            table.AddItem("Wisdom");
            table.AddItem("Charisma");
            return table.GetResult();
        }

        public static string ChoosePoolLiquid()
        {
            var table = new RandomTable<string>();
            table.AddItem("Empty (Needs to be filled to gain effect)", 5);
            table.AddItem("Clean water", 10);
            table.AddItem("Blood");
            table.AddItem("Dirty water", 10);
            table.AddItem("Green slime");
            table.AddItem("Black pudding");
            table.AddItem("Gelatinous cube settled to look like water " +
                "unless ezamined");
            table.AddItem("Opaque, muddy water");
            table.AddItem("Thick mud");
            table.AddItem("Boiling water");
            table.AddItem("Ale");
            table.AddItem("Wine");
            table.AddItem("Bubbling hot mud");
            table.AddItem("Ofal, guts");
            table.AddItem("Oil (cool)");
            table.AddItem("Boiling oil");
            table.AddItem("Lava");
            table.AddItem("Green water (algae)");
            table.AddItem("Harmless, opaque, colored slime");
            table.AddItem("Feces and urine");
            table.AddItem("A shimmering, liquid-like energy");
            table.AddItem("An inpenetrable dark, cold fluid");
            table.AddItem("Frozen solid ice");
            table.AddItem("Molten adamantine (looks like lava, and " +
                "cools to a permanent solid in 1d5 rounds if removed.");
            table.AddItem("Mercury (bathers float on top unless pushed " +
                "down with force)");
            return table.GetResult();
        }
    }
}
