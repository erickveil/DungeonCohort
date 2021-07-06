using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class IndividualLoot
    {

        public static string SpecialIndividualLoot(LootTableResult resolvedIndiLoot)
        {
            var die = Dice.Instance;
            bool isItem = false;
            string result = "";
            if (resolvedIndiLoot.CP > 0)
            {
                isItem = die.Roll(1, 6) <= 3;
                if (isItem)
                {
                    int numItems = die.Roll(1, 4);
                    for (int i = 0; i < numItems; ++i)
                    {
                        result += UsefulItems() + ", ";
                    }
                    result += "(";
                }
                result += resolvedIndiLoot.CP + " cp";
                if (isItem) { result += ")"; }
                result += "\n";
            }
            if (resolvedIndiLoot.SP > 0)
            {
                isItem = die.Roll(1, 6) <= 3;
                if (isItem)
                {
                    int numItems = die.Roll(1, 4);
                    for (int i = 0; i < numItems; ++i)
                    {
                        result += UsefulItems() + ", ";
                    }
                    result += "(";
                }
                result += resolvedIndiLoot.SP + " sp";
                if (isItem) { result += ")"; }
                result += "\n";
            }
            if (resolvedIndiLoot.EP > 0)
            {
                isItem = die.Roll(1, 6) <= 3;
                if (isItem)
                {
                    result += ItemsOfWorth() + ", ";
                    result += "(";
                }
                result += resolvedIndiLoot.EP + " ep";
                if (isItem) { result += ")"; }
                result += "\n";
            }
            if (resolvedIndiLoot.GP > 0)
            {
                isItem = die.Roll(1, 6) <= 3;
                if (isItem)
                {
                    result += ItemsOfWorth() + ", ";
                    result += "(";
                }
                result += resolvedIndiLoot.GP + " gp";
                if (isItem) { result += ")"; }
                result += "\n";
            }
            if (resolvedIndiLoot.PP > 0)
            {
                isItem = die.Roll(1, 6) <= 3;
                if (isItem)
                {
                    result += ItemsOfWorth() + ", ";
                    result += "(";
                }
                result += resolvedIndiLoot.PP + " pp";
                if (isItem) { result += ")"; }
                result += "\n";
            }
            return result;
        }

        public static string UsefulItems()
        {
            var die = Dice.Instance;
            var table = new RandomTable<string>();

            // magic wands
            var lootLoader = JsonLootLoader.Instance;
            var wandTable = lootLoader.GetWandTable();

            // random spell
            var dataSources = DataSourceLoader.Instance;
            var spellSource = dataSources.SpellSource;
            // Can be anything! :O
            var spellTable = spellSource.GetFullSpellTable();

            // Spellbook
            var spellbook = new MagicItems();
            spellbook.InitAsWizardSpellbook(1);

            // potions
            var potionTable = lootLoader.GetPotionTable();

            // magic items (any)
            var magicItemTable = lootLoader.GetMagicItemTable();

            table.AddItem("Healing Potion");
            table.AddItem("Bandages");
            table.AddItem("Vial of Poison");
            table.AddItem("Vial of Acid");
            table.AddItem("Vial of Oil");
            table.AddItem("Tinder Kit");
            table.AddItem("Hard Rations");
            table.AddItem("Bag of Marbles");
            int num = die.Roll(1, 6);
            table.AddItem(num + " Torches");
            num = die.Roll(2, 6);
            table.AddItem(num + " Arrows");
            table.AddItem("Bag of Caltrops");
            table.AddItem("Full Wineskin");
            table.AddItem("Healing Salv (bonus hit die during a short rest)");
            table.AddItem("Scroll of " + spellTable.GetResult());
            table.AddItem(wandTable.GetResult() + " with One Charge");
            table.AddItem("Cursed " + wandTable.GetResult() + " with One Charge");
            table.AddItem("Treasure Map");
            table.AddItem("Someone Else's Spellbook");
            table.AddItem("Someone else's " + spellbook.ToString());
            table.AddItem("Partial Map of the Dungeon");
            table.AddItem("Magic Ink (For writing scrolls)");
            table.AddItem("Blank Scroll Parchment");
            table.AddItem("Invisible Ink");
            table.AddItem("Key Ingredient for a Potion");
            table.AddItem("Potion Recipe: " + potionTable.GetResult());
            table.AddItem("Potion: " + potionTable.GetResult());
            table.AddItem("Magic Item Construction Plans: " + magicItemTable.GetResult());
            table.AddItem("Thief's Tools");
            table.AddItem("Quest Hook");
            table.AddItem("Empty Vial");
            table.AddItem("Scroll Tube");
            table.AddItem("Mushrooms: " + EldHex.Mushrooms());
            table.AddItem("Lotus: " + EldHex.Lotus());
            num = die.Roll(1, 6);
            table.AddItem(num + " doses of Haster Powder (1 round duration, 1 level exhasution after");
            bool hasPower = die.Roll(1, 6) == 6;
            table.AddItem("Psionic Crystal: " + num + " psi points. " + (hasPower ? "Has Power." : "")); ;
            table.AddItem("Holy Symbol");
            table.AddItem("Spell Focus");
            table.AddItem("Sap");
            table.AddItem("Whistle");
            table.AddItem("50' Hemp Rope");
            table.AddItem("50' Silk Rope");
            table.AddItem("Lantern");
            table.AddItem("Pillow");
            table.AddItem(TrapKit());
            table.AddItem("Grappling Hook");
            table.AddItem("Crampons");
            table.AddItem("Hammer and Pittons");
            table.AddItem("Chalk");
            table.AddItem("Telescope");
            table.AddItem("Parascope");
            table.AddItem("Hand Mirror");
            table.AddItem("Compass");
            table.AddItem("Ball of Twine");
            table.AddItem("Antitoxin");

            return table.GetResult();
        }

        public static string TrapKit()
        {
            var table = new RandomTable<string>();

            table.AddItem("Bear Trap (restrain/damage)");
            table.AddItem("Net Trap (restrain)");
            table.AddItem("Dart Trap (damage)");
            table.AddItem(MagicTrapkit());
            table.AddItem("Alarm Tripwire");

            return "Trap Kit: " + table.GetResult();
        }

        public static string MagicTrapkit()
        {
            var trap = new CrawlRoomTrap();
            trap.InitAsMagicTrapKit();
            return trap.ToString();
        }

        public static string ItemsOfWorth()
        {
            var table = new RandomTable<string>();

            table.AddItem("Fine Pair of Boots");
            table.AddItem("Fine Clothes, Need laundering");
            table.AddItem("Counterfeit Coins");
            table.AddItem("A spoon of precious metal");
            table.AddItem("Rolled up painting");
            table.AddItem("Drinking Tankard");
            table.AddItem("Ornamental weapon (dagger/sword)");
            table.AddItem("Well-made walking stick");
            table.AddItem("Rare, magical wood - unformed (magic item ingredient)");
            table.AddItem("Rare, magical metal - bar (magic item ingredient)");
            table.AddItem("Bar(s) of Iron, Copper, Silver, or Gold");
            var gemTable = new RandomTable<string>();
            gemTable.AddItem("Bloodstone");
            gemTable.AddItem("Carnelian");
            gemTable.AddItem("Chrysoprase");
            gemTable.AddItem("Citrine");
            gemTable.AddItem("Lapis");
            gemTable.AddItem("Moonstone");
            gemTable.AddItem("Moss Agate");
            gemTable.AddItem("Onyx");
            gemTable.AddItem("Star Rose Quartz");
            gemTable.AddItem("Tigereye");
            table.AddItem("Gemstone: " + gemTable.GetResult());
            table.AddItem("Necklace");
            table.AddItem("Ring");
            table.AddItem("Cloak-clasp");
            table.AddItem("Circlet");
            table.AddItem("Bracer");
            table.AddItem("Arm-clasp");
            table.AddItem("Choker");
            table.AddItem("Collar");
            table.AddItem("Pin");
            table.AddItem("Valuable, mundane Book");
            table.AddItem("Statuette");
            table.AddItem("Locket with Image");
            table.AddItem("Rod");
            table.AddItem("Gemstone Dust");
            table.AddItem("Decorated Bone");
            table.AddItem("Fine Gloves");
            table.AddItem("Gauntlet");
            table.AddItem("Girdle");
            table.AddItem("Cloak");
            table.AddItem("Cape");
            table.AddItem("Crown");
            table.AddItem("Hat");

            return table.GetResult();

        }
    }
}
