using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DungeonCohort;

namespace Darkmoor
{
    /// <summary>
    /// Loads, holds, and provides anctries.
    /// </summary>
    class AncestryIndex
    {
        RandomTable<Ancestry> _ancestryTable;
        RandomTable<Ancestry> _pcRaces = new RandomTable<Ancestry>();

        Dice _dice;
        bool _isLoaded = false;

        private static AncestryIndex _instance = null;

        /// <summary>
        /// Index of all possible ancestries.
        /// This reference is a singleton, because we only need one instance
        /// and once loaded, it never changes.
        /// 
        /// It provides the blueprints for all populations.
        /// </summary>
        private AncestryIndex()
        {
            _dice = Dice.Instance;
            _ancestryTable = new RandomTable<Ancestry>();
        }

        /// <summary>
        /// Get an instance of this singelton.
        /// </summary>
        public static AncestryIndex Instance
        {
            get
            {
                if (_instance is null) { _instance = new AncestryIndex(); }
                return _instance;
            }
        }

        /// <summary>
        /// Old method used in the initial testing. Now ancestries are loaded
        /// from files so you can control what is included in your world.
        /// </summary>
        public void LoadConstantAncestries()
        {
            var nameList = new List<string> { 
                "human", "elf", "dwarf", "hobgoblin", "dark elf", "orc" 
            };

            foreach(var name in nameList)
            {
                var ancestryObj = new Ancestry();
                ancestryObj.Name = name;
                ancestryObj.MinAppearing = 180;
                ancestryObj.MaxAppearing = 220;
                ancestryObj.BaseAc = 10;
                ancestryObj.BaseToHit = 0;
                ancestryObj.BaseNumAttacks = 1;
                ancestryObj.HitDice = 1;
                ancestryObj.MoraleBonus = 0;
                _ancestryTable.AddItem(ancestryObj);
            }
        }

        public void LoadPCAncestries()
        {
            var nameList = new List<string> { 
                "Human", "Elf", "Dwarf", "Halfling", "Gnome", "Halfelf",
                "Halforc", "Tiefling", "Aisimar", "Dragonborn", "Tortle",
                "Warforged", "Goliath", "Gensai", "Tabaxi"
            };

            foreach(var name in nameList)
            {
                var ancestryObj = new Ancestry();
                ancestryObj.Name = name;
                ancestryObj.MinAppearing = 180;
                ancestryObj.MaxAppearing = 220;
                ancestryObj.BaseAc = 10;
                ancestryObj.BaseToHit = 0;
                ancestryObj.BaseNumAttacks = 1;
                ancestryObj.HitDice = 1;
                ancestryObj.MoraleBonus = 0;
                ancestryObj.CR = "1/8";
                ancestryObj.Type.Add("humanoid");
                ancestryObj.AlignmentGE = AlignmentValue.ALIGN_VARIES;
                ancestryObj.AlignmentLC = AlignmentValue.ALIGN_VARIES;
                _pcRaces.AddItem(ancestryObj);
            }
        }

        /// <summary>
        /// Loads all ancestries from various files.
        /// </summary>
        public void LoadAllSources()
        {
            if (_isLoaded) { return; }
            _isLoaded = true;

            LoadCsvAncestries();
            LoadJsonAncestries();
            LoadPCAncestries();
        }

        /// <summary>
        /// CSV ancestries are easy to create by users who want to add their 
        /// own or control available ancestries via whitelist.
        /// </summary>
        public void LoadCsvAncestries()
        {
            try
            {
                string fileContents = File.ReadAllText(@"ancestries.csv");
                string[] recordList = fileContents.Split('\n');
                bool isFirst = true;
                foreach (var record in recordList)
                {
                    // Skip header line
                    if (isFirst)
                    {
                        isFirst = false;
                        continue;
                    }
                    // Skip empty lines
                    if (record == "") { continue; }

                    string[] splitRecord = record.Split(',');
                    var entryList = new List<string>(splitRecord);
                    var ancestry = new Ancestry();

                    _fillStringEntry(entryList, 0, out ancestry.Name);

                    if (entryList.Count() <= 7)
                    {
                        Console.WriteLine("WARN: "
                            + ancestry.Name + " entry only has " 
                            + entryList.Count() + " members: " + record);
                    }

                    _fillIntEntry(entryList, 1, out ancestry.MinAppearing, 
                        ancestry.Name + " MinAppearing");
                    _fillIntEntry(entryList, 2, out ancestry.MaxAppearing, 
                        ancestry.Name + " MaxAppearing");
                    _fillIntEntry(entryList, 3, out ancestry.BaseAc, 
                        ancestry.Name + " BaseAc");
                    _fillIntEntry(entryList, 4, out ancestry.BaseToHit, 
                        ancestry.Name + " BaseToHit");
                    _fillIntEntry(entryList, 5, out ancestry.BaseNumAttacks, 
                        ancestry.Name + " NumAttacks");
                    _fillIntEntry(entryList, 6, out ancestry.HitDice, 
                        ancestry.Name + " HitDice");
                    _fillIntEntry(entryList, 7, out ancestry.MoraleBonus, 
                        ancestry.Name + " MoraleBonus");

                    _ancestryTable.AddItem(ancestry);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Skipping ancestries.csv");
            }

        }

        /// <summary>
        /// A specially formatted JSON file of D&D creatures can be provided.
        /// These JSON files are not included with this repo, as they contain
        /// monsters that I don't have the license for.
        /// </summary>
        public void LoadJsonAncestries()
        {
            var loader = new BestiaryJsonLoader();
            loader.LoadAllBestiaries();

            // Civilizations
            var ancestryList = loader.ExportAsAncestryList();
            foreach (var ancestry in ancestryList)
            {
                _ancestryTable.AddItem(ancestry);
            }
        }

        private void _fillStringEntry(List<string> entryList, int index, 
            out string target)
        {
            target = "";
            if (entryList.Count() <= index) { return; }
            target = entryList[index];
        }

        private void _fillIntEntry(List<string> entryList, int index,
            out int target, string targetId = "")
        {
            target = 0;
            if (entryList.Count() <= index) { return; }
            bool ok = Int32.TryParse(entryList[index], out target);
            if (!ok) 
            {
                Console.WriteLine("WARN: " + targetId + " (val="
                    + entryList[index] + ") could not be converted to int.");
            }
        }

        /// <summary>
        /// Gets a random ancestry from the table of all ancestries.
        /// </summary>
        /// <returns></returns>
        public Ancestry GetRandomAncestry()
        {
            return _ancestryTable.GetResult();
        }

        /// <summary>
        /// Gets a random ancestry whos CR falls withing the tier for a party
        /// of 4.
        /// </summary>
        /// <param name="tier"></param>
        /// <returns></returns>
        public Ancestry GetRandomAncestry(int tier)
        {
            return GetRandomAncestry(tier, "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tier"></param>
        /// <param name="biome">Pass an empty string to select from any biome.
        /// Otherwise the biome values are as follows:
        /// Dungeon
        /// Wilderness
        /// Lawful Civ
        /// Chaos Civ
        /// Neutral Civ
        /// </param>
        /// <param name="isStandardRace">If set to true, only uses standard 
        /// PC races for generating NPCs. Avoids monster race NPCs</param>
        /// <returns></returns>
        public Ancestry GetRandomAncestry(int tier, string biome, 
            bool isStandardRace = false)
        {
            var biomeTable = FilterTableByBiomeType(_ancestryTable, biome);
            var tierTable = FilterTableByTier(biomeTable, tier);
            var finalTable = tierTable;

            AlignmentValue align = AlignmentValue.ALIGN_NEUTRAL;
            if (biome == "Lawful Civ")
            {
                align = AlignmentValue.ALIGN_GOOD;
                finalTable = FilterTableByGEAlignment(tierTable, align);
            }
            else if (biome == "Chaos Civ")
            {
                align = AlignmentValue.ALIGN_EVIL;
                finalTable = FilterTableByGEAlignment(tierTable, align);
            }

            Ancestry result = finalTable.GetResult();
            if (IsNpcProfesson(result))
            {
                result = ConvertProfessionToNPC(result, align, isStandardRace);
            }
            return result;
        }

        /// <summary>
        /// Many biomes of random monsters are just selected from a list of
        /// types that the monster may be a part of.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="biome"></param>
        /// <returns></returns>
        public RandomTable<Ancestry> FilterTableByBiomeType(
            RandomTable<Ancestry> source, string biome)
        {
            var sourceList = source.GetUniqueEntryList();
            var allowedType = new List<string>();
            if (biome == "Dungeon")
            {
                allowedType = new List<string>
                {
                    "abberation",
                    "celestial",
                    "construct",
                    "dragon",
                    "elemental",
                    "fiend",
                    "humanoid",
                    "monstrosity",
                    "ooze",
                    "undead"
                };
            }
            else if (biome == "Wilderness")
            {
                allowedType = new List<string>
                {
                    "beast",
                    "celestial",
                    "dragon",
                    "elemental",
                    "fey",
                    "fiend",
                    "giant",
                    "humanoid",
                    "plant"
                };
            }
            else if (biome == "Lawful Civ")
            {
                allowedType = new List<string>
                {
                    "celestial",
                    "dragon",
                    "giant",
                    "humanoid"
                };
            }
            else if (biome == "Chaos Civ")
            {
                allowedType = new List<string>
                {
                    "dragon",
                    "fiend",
                    "giant",
                    "humanoid",
                    "undead"
                };
            }
            else if (biome == "Neutral Civ")
            {
                allowedType = new List<string>
                {
                    "dragon",
                    "giant",
                    "humanoid"
                };
            }
            else if (biome == "")
            {
                return source;
            }
            else
            {
                Console.WriteLine("Unknown biome filter: " + biome);
                return source;
            }
            var resultTable = new RandomTable<Ancestry>();
            foreach (var ancestry in sourceList)
            {
                foreach (var filter in allowedType)
                {
                    if (!ancestry.Type.Contains(filter)) { continue; }
                    resultTable.AddItem(ancestry);
                }
            }
            if (resultTable.CountUniqueEntries() == 0)
            {
                Console.WriteLine("No valid entries in table for biome " +
                    "filter: " + biome);
            }
            return resultTable;
        }

        /// <summary>
        /// Create a table that is made up of Ancestries that fall within the 
        /// provided tiers.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="highTier"></param>
        /// <param name="lowTier"></param>
        /// <returns></returns>
        public RandomTable<Ancestry> FilterTableByTier(
            RandomTable<Ancestry> source, int highTier, int lowTier = 0)
        {
            var sourceList = source.GetUniqueEntryList();
            var resultTable = new RandomTable<Ancestry>();
            int lowXp = TierToXp(lowTier - 1);
            int highXp = TierToXp(highTier);
            foreach (var ancestry in sourceList)
            {
                if (ancestry.GetXpValue() < lowXp) { continue; }
                if (ancestry.GetXpValue() > highXp) { continue; }
                resultTable.AddItem(ancestry);
            }
            if (resultTable.CountUniqueEntries() == 0)
            {
                Console.WriteLine("No valid entries in table for tier " +
                    "filter.");
            }
            return resultTable;
        }

        /// <summary>
        /// Create a table that is made up of ancestries with the correct
        /// alignement.
        /// Neutral requests can include Good or Evil, or even questionably
        /// aligned results.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="alignGE"></param>
        /// <returns></returns>
        public RandomTable<Ancestry> FilterTableByGEAlignment(
            RandomTable<Ancestry> source, AlignmentValue alignGE)
        {
            var sourceList = source.GetUniqueEntryList();
            var resultTable = new RandomTable<Ancestry>();
            foreach (var ancestry in sourceList)
            {
                bool isExactMatch = ancestry.AlignmentGE == alignGE;
                bool isTestingForNeutral = 
                    alignGE == AlignmentValue.ALIGN_NEUTRAL;
                bool isAncestryNeutral =
                    ancestry.AlignmentGE == AlignmentValue.ALIGN_NEUTRAL
                    || ancestry.AlignmentGE == AlignmentValue.ALIGN_UNALIGNED
                    || ancestry.AlignmentGE == AlignmentValue.ALIGN_UNKNOWN;
                bool isAncectryFlexible =
                    ancestry.AlignmentGE == AlignmentValue.ALIGN_VARIES;

                // Exact matches are on the list, of course
                if (isExactMatch)
                {
                    resultTable.AddItem(ancestry);
                    continue;
                }
                // Flexibly aligned ancestries can be on the list
                if (isAncectryFlexible) 
                {
                    resultTable.AddItem(ancestry);
                    continue;
                } 
                // Asking for a neutral aligned ancestry can result in anybody
                if (isTestingForNeutral)
                {
                    resultTable.AddItem(ancestry);
                    continue;
                }
                // Neutral aligned ancestries can be found anywhere
                if (isAncestryNeutral)
                {
                    resultTable.AddItem(ancestry);
                    continue;
                }
            }
            if (resultTable.CountPossibilites() == 0)
            {
                Console.WriteLine("No results obtained from an AlignGE " +
                    "filter.");
            }
            return resultTable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="alignLC"></param>
        /// <returns></returns>
        public RandomTable<Ancestry> FilterTableByLCAlignment(
            RandomTable<Ancestry> source, AlignmentValue alignLC)
        {
            var sourceList = source.GetUniqueEntryList();
            var resultTable = new RandomTable<Ancestry>();
            foreach (var ancestry in sourceList)
            {
                bool isExactMatch = ancestry.AlignmentLC == alignLC;
                bool isTestingForNeutral = 
                    alignLC == AlignmentValue.ALIGN_NEUTRAL;
                bool isAncestryNeutral =
                    ancestry.AlignmentGE == AlignmentValue.ALIGN_NEUTRAL
                    || ancestry.AlignmentGE == AlignmentValue.ALIGN_UNALIGNED
                    || ancestry.AlignmentGE == AlignmentValue.ALIGN_UNKNOWN;
                bool isAncectryFlexible =
                    ancestry.AlignmentGE == AlignmentValue.ALIGN_VARIES;

                // Exact matches are on the list, of course
                if (isExactMatch)
                {
                    resultTable.AddItem(ancestry);
                    continue;
                }
                // Flexibly aligned ancestries can be on the list
                if (isAncectryFlexible) 
                {
                    resultTable.AddItem(ancestry);
                    continue;
                } 
                // Asking for a neutral aligned ancestry can result in anybody
                if (isTestingForNeutral)
                {
                    resultTable.AddItem(ancestry);
                    continue;
                }
                // Neutral aligned ancestries can be found anywhere
                if (isAncestryNeutral)
                {
                    resultTable.AddItem(ancestry);
                    continue;
                }
            }
            if (resultTable.CountPossibilites() == 0)
            {
                Console.WriteLine("No results obtained from an AlignCL " +
                    "filter.");
            }
            return resultTable;
        }

        /// <summary>
        /// Returns the upper xp limit on a tier's CR
        /// </summary>
        /// <param name="tier"></param>
        /// <returns></returns>
        public static int TierToXp(int tier)
        {
            if (tier == -1) { return 0; }
            if (tier == 0) { return 200; }
            if (tier == 1) { return 1800; }
            if (tier == 2) { return 7200; }
            if (tier == 3) { return 18000; }
            return 900900; 
        }

        public Character GetRandomNPC(int tier, AlignmentValue goodEvil, 
            bool isUseStdPCRace)
        {
            var professionTable = GetNPCProfessionTable(tier);
            var profession = professionTable.GetResult();
            var raceTable = GetRandomNPCRace(goodEvil, isUseStdPCRace);
            profession.Composite = raceTable.GetResult();
            var npc = new Character();
            npc.Init(profession);
            return npc;
        }

        public Ancestry ConvertProfessionToNPC(Ancestry ancestry, 
            AlignmentValue goodEvil, bool isUseStdPCRace)
        {
            var raceTable = GetRandomNPCRace(goodEvil, isUseStdPCRace);
            ancestry.Composite = raceTable.GetResult();
            return ancestry;
        }

        public RandomTable<Ancestry> GetRandomNPCRace(AlignmentValue goodEvil,
            bool isUseStdPCRace)
        {
            if (isUseStdPCRace) { return _pcRaces; }

            var table = new RandomTable<Ancestry>();
            var humanoidTable = GetHumanoidTable();
            var allHumanoids = humanoidTable.GetUniqueEntryList();
            foreach (var ancestry in allHumanoids)
            {
                if (
                    (ancestry.AlignmentGE == goodEvil)
                    || (ancestry.AlignmentGE == AlignmentValue.ALIGN_NEUTRAL)
                    || (ancestry.AlignmentGE == AlignmentValue.ALIGN_UNALIGNED)
                    || (ancestry.AlignmentGE == AlignmentValue.ALIGN_UNKNOWN)
                    || (ancestry.AlignmentGE == AlignmentValue.ALIGN_VARIES)
                    || goodEvil == AlignmentValue.ALIGN_NEUTRAL
                    )
                {
                    table.AddItem(ancestry);
                }
            }

            var allPCRaceList = _pcRaces.GetUniqueEntryList();
            foreach (var race in allPCRaceList)
            {
                table.AddItem(race);
            }
            return table;
        }

        public RandomTable<Ancestry> GetHumanoidTable()
        {
            var table = new RandomTable<Ancestry>();
            var allAncestryList = _ancestryTable.GetUniqueEntryList();
            foreach (var ancestry in allAncestryList)
            {
                if (!ancestry.Type.Contains("humanoid")) { continue; }
                if (ancestry.Type.Contains("any race")) { continue; }
                if (ancestry.Type.Contains("shapechangers")) { continue; }
                table.AddItem(ancestry);
            }
            return table;
        }

        public RandomTable<Ancestry> GetNPCProfessionTable(int tier)
        {
            var table = new RandomTable<Ancestry>();

            var allAncestries = _ancestryTable.GetUniqueEntryList();
            foreach (var ancestry in allAncestries)
            {
                if (!ancestry.Type.Contains("any race")) { continue; }
                if (ancestry.GetTier() > tier) { continue; }
                table.AddItem(ancestry);
            }

            return table;
        }

        public bool IsNpcProfesson(Ancestry ancestry)
        {
            return (ancestry.Type.Contains("any race"));
        }

        public RandomTable<Ancestry> GetTierZeroAncestryTable()
        {
            var table = new RandomTable<Ancestry>();
            var allAncestries = _ancestryTable.GetUniqueEntryList();
            foreach (var ancestry in allAncestries)
            {
                //if (ancestry.Type.Contains("any race")) { continue; }
                if (ancestry.GetXpValue() > 200) { continue; }
                table.AddItem(ancestry);
            }
            return table;
        }

    }
}
