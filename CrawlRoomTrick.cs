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
        public string Object = "";
        public string Effect = "";

        public void Init()
        {
            var dice = Dice.Instance;
            bool isTrick = dice.Roll(1, 6) <= 3;
            if (isTrick) { InitAsTrick(); }
            else { InitAsFeature(); }
        }


        public void InitAsTrick()
        {
            Object = ChooseTrickObject();
            Effect = ChooseTrickEffect();
        }

        public void InitAsFeature()
        {
            Object = ChooseMundaneFeature();
        }

        public override string ToString()
        {
            return Object
                + (Effect == "" ? "" : ": " + Effect);
        }

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
            table.AddItem("Lever");
            table.AddItem("Obvious pressure plate");
            table.AddItem("Dias");
            table.AddItem("Natural spring");
            table.AddItem("Mushroom ring");
            table.AddItem("Stone wheel");
            table.AddItem("Skeleton of a monkey with its hand in a " +
                "jar, wrapped around a gemstone");
            table.AddItem("Large, floating eye");
            table.AddItem("Pyramid");
            table.AddItem("Massive harp with broken strings");
            table.AddItem("A bowl of unusual fruit");
            table.AddItem("A ring of salt");
            table.AddItem("A sword embedded in the stone floor");
            table.AddItem("A smoky quartz wall");
            table.AddItem("Three imp sculptures in tiny alcoves near the " +
                "ceiling");
            table.AddItem("A music box");
            table.AddItem("A nest with three purple eggs");
            table.AddItem("A Marbel pedestal");
            table.AddItem("A red rune on the ceiling");
            table.AddItem("A drooping plant bearing a single, red fruit");
            table.AddItem("Five red, wooden, creepy masks");
            table.AddItem("A dome of black glass");

            return table.GetResult();
        }

        public static string ChooseMundaneFeature()
        {
            var table = new RandomTable<string>();
            table.AddItem(ChooseTrickObject(), 16);
            table.AddItem("Collumns", 8);
            table.AddItem("Balcony above to adjacent area above", 4);
            table.AddItem("Balcony over adjacent area below", 4);
            table.AddItem("Iron grate over crawlway that leads " 
                + ChooseDirection());
            table.AddItem("Still smoking pipe");
            table.AddItem("Copper pipe");
            table.AddItem("Flower Box");
            table.AddItem("Alcove of wooden mugs");
            table.AddItem("Giant red X");
            table.AddItem("Skeleton of a small dog");
            table.AddItem("A broken mirror");
            table.AddItem("Bloody footprints");
            table.AddItem("Eyes in a jar");
            table.AddItem("Music eminates from the ceiling");
            table.AddItem("A sizzling hibachi");
            table.AddItem("A corpse wrapped in a roll of black silk");
            table.AddItem("A scale model of the PCs' home town with a " +
                "statue of a demon in the square.");
            table.AddItem("A swarm of flies");
            table.AddItem("A trail of ants leads from an exit to a blank wall");
            table.AddItem("A fly covered manequin hangs from a noose");
            table.AddItem("An unlucky teleport victim");
            table.AddItem("An iron cage containing an almost escaped skeleton");
            table.AddItem("Three piranha in a fishbowl");
            table.AddItem("A window into stone");
            table.AddItem("A bottomless hole");
            table.AddItem("A broken, marble head");
            table.AddItem("A severed foot in a velvet slipper");
            table.AddItem("A single serving of gelatinous cube");
            table.AddItem("The ceiling is dripping with blood");
            table.AddItem("A fireplace stuffed with bones");
            table.AddItem("Bones litter the floor");
            table.AddItem("A collection of hand-drawn orc erotica");
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
