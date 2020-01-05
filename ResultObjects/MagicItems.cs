using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCohort.JsonLoading;
using Darkmoor;

namespace DungeonCohort
{
    class MagicItems
    {
        public string name;

        // TODO: These need to be set!
        public string rarity;
        public string type; // major/minor

        public JsonSpell scrollSpell = null;

        public List<JsonSpell> spellBook = null;

        public override string ToString()
        {
            if (!(scrollSpell is null))
            {
                return name + " - " + scrollSpell.ToString();
            }

            if (!(spellBook is null))
            {
                return name + "\n" + GetOrderedSpellList();
            }

            return name;
        }

        public string GetOrderedSpellList()
        {
            if (spellBook is null) { return ""; }

            List<JsonSpell> orderedList = spellBook.OrderBy(o => o.level).ToList();

            string result = "";
            foreach (var spell in spellBook) 
            {
                string level = spell.level == 0 
                    ? "Cantrip" 
                    : spell.level.ToString();
                result += "  - " + level + ": " + spell.ToString() + "\n";
            }
            return result;
        }

        public MagicItems Copy()
        {
            var copy = new MagicItems();
            copy.name = name;
            copy.rarity = rarity;
            copy.type = type;
            // NOTE: does not copy the spell object, as this is most often 
            // unique.
            return copy;
        }

        public void InitAsWizardSpellbook(int tier)
        {
            name = "Wizard Spellbook";
            rarity = "Common";
            type = "Minor";

            spellBook = new List<JsonSpell>();
            // JsonSpellLoader
            var dataSources = DataSourceLoader.Instance;
            var spellSource = dataSources.SpellSource;
            var spellTable = spellSource.GetFullSpellTable();
            var wizardSpells = 
                JsonSpellLoader.FilterTableByCharacterClass(
                    spellTable, "Wizard");


            var spellsTableLevel = new RandomTable<JsonSpell>[10];
            for (int i = 0; i < 10; ++i)
            {
                spellsTableLevel[i] = 
                    JsonSpellLoader.FilterTableByLevel(wizardSpells, i);
            }

            var dice = Dice.Instance;
            int qty;
            if (tier == 1)
            {
                qty = dice.Roll(1, 4) + 1;
                for (int i = 0; i < qty; ++i)
                {
                    spellBook.Add(spellsTableLevel[0].GetResult());
                }
                qty = dice.Roll(1, 2);
                for (int i = 0; i < qty; ++i)
                {
                    spellBook.Add(spellsTableLevel[1].GetResult());
                }

                bool hasLevel = dice.Roll(1, 2) == 1;
                if (!hasLevel) { return; }
                spellBook.Add(spellsTableLevel[2].GetResult());

                hasLevel = dice.Roll(1, 4) == 4;
                if (!hasLevel) { return; }
                spellBook.Add(spellsTableLevel[3].GetResult());
            }
            else if (tier == 2)
            {
                qty = dice.Roll(1, 2);
                for (int i = 0; i < qty; ++i)
                {
                    spellBook.Add(spellsTableLevel[1].GetResult());
                }
                qty = dice.Roll(1, 4) + 1;
                for (int i = 0; i < qty; ++i)
                {
                    spellBook.Add(spellsTableLevel[2].GetResult());
                }
                qty = dice.Roll(1, 2) + 1;
                for (int i = 0; i < qty; ++i)
                {
                    spellBook.Add(spellsTableLevel[3].GetResult());
                }

                spellBook.Add(spellsTableLevel[4].GetResult());

                bool hasLevel = dice.Roll(1, 2) == 1;
                if (!hasLevel) { return; }
                spellBook.Add(spellsTableLevel[5].GetResult());

                hasLevel = dice.Roll(1, 4) == 4;
                if (!hasLevel) { return; }
                spellBook.Add(spellsTableLevel[6].GetResult());
            }
            else if (tier == 3)
            {
                qty = dice.Roll(1, 2);
                for (int i = 0; i < qty; ++i)
                {
                    spellBook.Add(spellsTableLevel[3].GetResult());
                }

                qty = dice.Roll(1, 4) + 1;
                for (int i = 0; i < qty; ++i)
                {
                    spellBook.Add(spellsTableLevel[4].GetResult());
                }

                qty = dice.Roll(1, 2) + 1;
                for (int i = 0; i < qty; ++i)
                {
                    spellBook.Add(spellsTableLevel[5].GetResult());
                }

                qty = dice.Roll(1, 2);
                for (int i = 0; i < qty; ++i)
                {
                    spellBook.Add(spellsTableLevel[6].GetResult());
                }

                spellBook.Add(spellsTableLevel[7].GetResult());

                bool hasLevel = dice.Roll(1, 2) == 1;
                if (!hasLevel) { return; }
                spellBook.Add(spellsTableLevel[8].GetResult());
            }
            else
            {
                qty = dice.Roll(1, 2);
                for (int i = 0; i < qty; ++i)
                {
                    spellBook.Add(spellsTableLevel[4].GetResult());
                }

                qty = dice.Roll(1, 4) + 1;
                for (int i = 0; i < qty; ++i)
                {
                    spellBook.Add(spellsTableLevel[5].GetResult());
                }

                qty = dice.Roll(1, 2) + 1;
                for (int i = 0; i < qty; ++i)
                {
                    spellBook.Add(spellsTableLevel[6].GetResult());
                }

                qty = dice.Roll(1, 2);
                for (int i = 0; i < qty; ++i)
                {
                    spellBook.Add(spellsTableLevel[7].GetResult());
                }

                spellBook.Add(spellsTableLevel[8].GetResult());

                bool hasLevel = dice.Roll(1, 2) == 1;
                if (!hasLevel) { return; }
                spellBook.Add(spellsTableLevel[9].GetResult());
            }

        }

    }
}
