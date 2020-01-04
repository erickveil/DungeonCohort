using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using Darkmoor;

namespace DungeonCohort.JsonLoading
{
    class JsonSpellLoader
    {
        /// <summary>
        /// The final list. Will be full after loading.
        /// </summary>
        public List<JsonSpell> SpellList = new List<JsonSpell>();

        /// <summary>
        /// For Json loading. Will be empty after loading is complete.
        /// </summary>
        public List<JsonSpell> spell = new List<JsonSpell>();

        public void LoadAllSpells()
        {
            LoadSpellFile("spells-ai.json");
            LoadSpellFile("spells-ggr.json");
            LoadSpellFile("spells-llk.json");
            LoadSpellFile("spells-phb.json");
            LoadSpellFile("spells-scag.json");
            LoadSpellFile("spells-xge.json");
        }

        public void LoadSpellFile(string filename)
        {
            string jsonData;
            try { jsonData = File.ReadAllText(filename); }
            catch (Exception)
            {
                Console.WriteLine("Could not load spells from " + filename);
                return;
            }

            var rootObj = 
                JsonConvert.DeserializeObject<JsonSpellLoader>(jsonData);
            foreach (var spellObj in rootObj.spell)
            {
                SpellList.Add(spellObj);
            }
        }

        public RandomTable<JsonSpell> GetFullSpellTable()
        {
            Validate();
            var table = new RandomTable<JsonSpell>();
            foreach (var spellObj in SpellList)
            {
                table.AddItem(spellObj);
            }
            return table;
        }

        public static JsonSpell GetScrollSpell(string itemName, 
            JsonSpellLoader spellRef)
        {
            if (!itemName.ToLower().Contains("spell scroll")) { return null; }
            // the level is always the 14th character in the scroll item's name
            // except catrips
            const int LEVEL_POSITION = 14;
            char levelChar = itemName[LEVEL_POSITION];
            int spellLevel = (int)Char.GetNumericValue(levelChar);
            if (spellLevel == -1) { spellLevel = 0; }

            var spellTable = spellRef.GetFullSpellTable();
            spellTable = 
                FilterTableByLevel(spellTable, spellLevel);
            return spellTable.GetResult();
        }


        public static RandomTable<JsonSpell> FilterTableByLevel(
            RandomTable<JsonSpell> baseTable, int level)
        {
            var table = new RandomTable<JsonSpell>();
            var spellList = baseTable.GetUniqueEntryList();
            foreach (var spellObj in spellList)
            {
                if (spellObj.level != level) { continue; }
                table.AddItem(spellObj);
            }
            return table;
        }

        public static RandomTable<JsonSpell> FilterTableByLevelRange(
            RandomTable<JsonSpell> baseTable, int minLevel, int maxLevel)
        {
            var table = new RandomTable<JsonSpell>();
            var spellList = baseTable.GetUniqueEntryList();
            foreach (var spellObj in spellList)
            {
                if (spellObj.level < minLevel) { continue; }
                if (spellObj.level > maxLevel) { continue; }
                table.AddItem(spellObj);
            }
            return table;
        }

        public static RandomTable<JsonSpell> FilterTableBySchool(
            RandomTable<JsonSpell> baseTable, string school)
        {
            var table = new RandomTable<JsonSpell>();
            var spellList = baseTable.GetUniqueEntryList();
            foreach (var spellObj in spellList)
            {
                if (spellObj.school != school) { continue; }
                table.AddItem(spellObj);
            }
            return table;
        }

        public static RandomTable<JsonSpell> FilterTableBySchool(
            RandomTable<JsonSpell> baseTable, List<string>schoolList)
        {
            var table = new RandomTable<JsonSpell>();
            var spellList = baseTable.GetUniqueEntryList();
            foreach (var spellObj in spellList)
            {
                foreach (var school in schoolList)
                {
                    if (spellObj.school != school) { continue; }
                    table.AddItem(spellObj);
                }
            }
            return table;
        }

        public static RandomTable<JsonSpell> FilterTableByCharacterClass(
            RandomTable<JsonSpell> baseTable, string characterClass)
        {
            var table = new RandomTable<JsonSpell>();
            var spellList = baseTable.GetUniqueEntryList();
            foreach (var spellObj in spellList)
            {
                if (spellObj.IsForCharacterClass(characterClass)) 
                { 
                    table.AddItem(spellObj);
                }
            }
            return table;
        }

        public static RandomTable<JsonSpell> FilterTableByCharacterClass(
            RandomTable<JsonSpell> baseTable, List<string>characterClassList)
        {
            var table = new RandomTable<JsonSpell>();
            var spellList = baseTable.GetUniqueEntryList();
            foreach (var spellObj in spellList)
            {
                foreach (var characterClass in characterClassList)
                {
                    if (spellObj.IsForCharacterClass(characterClass))
                    {
                        table.AddItem(spellObj);
                    }
                }
            }
            return table;
        }

        public void Validate()
        {
            if (SpellList.Count != 0) { return; }
            LoadAllSpells();
        }

    }
}
