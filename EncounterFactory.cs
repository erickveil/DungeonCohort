using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    /// <summary>
    /// Generates an encounter ballanced to a party of PCs (not by tier)
    /// </summary>
    class EncounterFactory
    {
        public List<int> PcLevelList = new List<int>();
        public List<int> PcQtyList = new List<int>();
        public string Difficulty;

        private AncestryIndex MonsterSource;

        public Encounter LastEncounter;
        public float LastModifier;
        public string LastSubDifficulty;

        public static int GetTier(List<int>PcLevelList, List<int>PcQtyList)
        {
            float totalLevels = PcLevelList.Count();
            float totalPCs = PcQtyList.Count();
            float avgLevel = totalLevels / totalPCs;

            if (avgLevel < 5.5f) { return 1; }
            if (avgLevel < 11.5f) { return 2; }
            if (avgLevel < 17.5f) { return 3; }
            return 4;
        }

        public EncounterFactory()
        {
            MonsterSource = AncestryIndex.Instance;
        }

        public string LastEncounterAsString()
        {
            string output = LastEncounter.ToString() + "\n" + "\n"
                + GetDifficultyReport(LastEncounter);

            return output;
        }
        
        public void Clear()
        {
            PcLevelList = new List<int>();
            PcQtyList = new List<int>();
            Difficulty = "";
            LastEncounter = null;
            LastModifier = 0;
        }

        public Encounter PickRandomEncounter(string biome, bool isStandardRace)
        {
            // Cant use an encounter table, because the last rolled becomes
            // the output data, regardless of choice.
            var dice = Dice.Instance;
            int roll = dice.Roll(1, 12);
            int numPcs = CalcTotalPcs();
            int numMookMod = dice.Roll(1, 4) - 1;
            int numMooks = numPcs + numMookMod;
            switch(roll)
            {
                case 1: return PickOneMookPerPc(biome, isStandardRace);
                case 2: return PickTwoMooksPerPc(biome, isStandardRace);
                case 3: return PickOneBoss(biome, isStandardRace);
                case 4: return PickBossWithMooks(biome, isStandardRace, 
                    numMooks);
                case 5: return PickBossWithMooks(biome, isStandardRace, 
                    numMooks: numPcs - 1);
                case 6: return PickBossWithMooks(biome, isStandardRace, 
                    numMooks: 2);
                case 7: return PickBossWithMooks(biome, isStandardRace, 
                    numMooks: 3);
                case 8: return PickBossWithMooks(biome, isStandardRace, 
                    numMooks, numBosses: 2);
                case 9: return PickNBosses(biome, isStandardRace, 2);
                case 10: return PickNBosses(biome, isStandardRace, 3);
                case 11: return PickThreeTypes(biome, isStandardRace);
                case 12: return PickMooks(numMooks, biome, 
                    isStandardRace);
                case 13:
                    numMooks = dice.Roll(1, (numPcs * 2));
                    return PickMooks(numMooks, biome, isStandardRace);

                default: 
                    throw new Exception("Invalid encounter strategy selected.");
            }
        }

        public Encounter PickOneBoss(string biome, bool isStandardRace)
        {
            return PickMooks(numMonsters: 1, biome, isStandardRace);
        }

        public Encounter PickNBosses(string biome, bool isStandardRace, 
            int numBosses)
        {
            return PickMooks(numBosses, biome, isStandardRace);
        }

        public Encounter PickOneMookPerPc(string biome, bool isStandardRace)
        {
            int qty = CalcTotalPcs();
            return PickMooks(qty, biome, isStandardRace);
        }

        public Encounter PickTwoMooksPerPc(string biome, bool isStandardRace)
        {
            int qty = CalcTotalPcs() * 2;
            return PickMooks(qty, biome, isStandardRace);
        }

        public Encounter PickBossWithMooks(string biome, bool isStandardRace, 
            int numMooks, int numBosses = 1)
        {
            int numPcs = CalcTotalPcs();
            if (numPcs == 0)
            {
                throw new Exception("Can't generate encounter for no PCs.");
            }

            // how much of the xp budget does the boss take?
            var dice = Dice.Instance;
            int bossSize = dice.Roll(1, 3);
            float bossMod;
            switch (bossSize)
            {
                case 1: 
                    bossMod = 0.5f;
                    break;
                case 2:
                    bossMod = 0.33f;
                    break;
                default:
                    bossMod = 0.25f;
                    break;
            }

            var encounter = new Encounter();

            int ut = CalcUpperThreshold();
            int totalMonsters = numMooks + numBosses;
            float xpMod = CalcXpMultiplier(totalMonsters , numPcs);
            int totalXpBudget = (int)((float)ut / xpMod);
            int bossXpBudget = (int)(totalXpBudget * bossMod);
            int eachBossXp = (int)((float)bossXpBudget / (float)numBosses);
            int mookXpBudget = totalXpBudget - bossXpBudget;
            int totalMooks = numMooks;
            int eachMookXp = (int)((float)mookXpBudget / (float)totalMooks);

            Ancestry boss = MonsterSource.GetRandomAncestryByXpv(biome, 
                eachBossXp, isStandardRace);
            var bossRoster = new EncounterComponent();
            bossRoster.Monster = boss;
            bossRoster.Qty = numBosses;
            encounter.MemberList.Add(bossRoster);

            // mooks
            Ancestry mooks = MonsterSource.GetRandomAncestryByXpv(biome,
                eachMookXp, isStandardRace);
            var mookRoster = new EncounterComponent();
            mookRoster.Monster = mooks;
            mookRoster.Qty = totalMooks;
            encounter.MemberList.Add(mookRoster);

            // save
            LastModifier = xpMod;
            LastEncounter = encounter;

            return encounter;
        }

        public Encounter PickThreeTypes(string biome, bool isStandardRace)
        {
            int numPcs = CalcTotalPcs();
            if (numPcs == 0)
            {
                throw new Exception("Can't generate encounter for no PCs.");
            }

            var dice = Dice.Instance;
            int mookMod = dice.Roll(1, 4) - 1;

            int numBosses = 1;
            int numSeargents = 2;
            int numMooks = numPcs - (numBosses + numSeargents) + mookMod;
            if (numMooks <= 0) { numMooks = 0; }
            float bossMod = 0.33f;

            var encounter = new Encounter();

            int ut = CalcUpperThreshold();
            int totalMonsters = numMooks + numBosses;
            float xpMod = CalcXpMultiplier(totalMonsters , numPcs);
            int totalXpBudget = (int)((float)ut / xpMod);

            int bossXpBudget = (int)(totalXpBudget * bossMod);
            int eachBossXp = (int)((float)bossXpBudget / (float)numBosses);

            int remainingBudget = totalXpBudget - bossXpBudget;
            int seargentBudget = (int)((float)remainingBudget * 0.5f);
            int eachSeargentXp = (int)((float)seargentBudget * 0.5f);
            remainingBudget = remainingBudget - seargentBudget;

            int mookXpBudget = remainingBudget;
            int totalMooks = numMooks;
            int eachMookXp = (int)((float)mookXpBudget / (float)totalMooks);

            // boss
            Ancestry boss = MonsterSource.GetRandomAncestryByXpv(biome, 
                eachBossXp, isStandardRace);
            var bossRoster = new EncounterComponent();
            bossRoster.Monster = boss;
            bossRoster.Qty = numBosses;
            encounter.MemberList.Add(bossRoster);

            // seargents
            Ancestry seargent = MonsterSource.GetRandomAncestryByXpv(biome,
                eachSeargentXp, isStandardRace);
            var seargentRoster = new EncounterComponent();
            seargentRoster.Monster = seargent;
            seargentRoster.Qty = numSeargents;
            encounter.MemberList.Add(seargentRoster);

            if (numMooks != 0)
            {
                // mooks
                Ancestry mooks = MonsterSource.GetRandomAncestryByXpv(biome,
                    eachMookXp, isStandardRace);
                var mookRoster = new EncounterComponent();
                mookRoster.Monster = mooks;
                mookRoster.Qty = totalMooks;
                encounter.MemberList.Add(mookRoster);
            }

            // save
            LastModifier = xpMod;
            LastEncounter = encounter;

            return encounter;
        }

        /// <summary>
        /// Picks mooks for an encounter and records the picks to the class
        /// </summary>
        /// <param name="numMonsters"></param>
        /// <param name="biome"></param>
        /// <param name="isStandardRace"></param>
        /// <returns></returns>
        public Encounter PickMooks(int numMonsters, string biome, 
            bool isStandardRace)
        {
            int numPcs = CalcTotalPcs();
            if (numPcs == 0)
            {
                throw new Exception("Can't generate encounter for no PCs.");
            }
            int ut = CalcUpperThreshold();
            //int randomUpperThreshold = CalcRandomUpperThreshold();
            int randomUpperThreshold = ut;
            int monsterXpValue = (randomUpperThreshold / numMonsters);

            float mod = CalcXpMultiplier(numMonsters, numPcs);
            LastModifier = mod;
            monsterXpValue = (int)(monsterXpValue / mod);

            Ancestry mook = MonsterSource.GetRandomAncestryByXpv(biome, 
                monsterXpValue, isStandardRace);
            var encounter = new Encounter();
            var mookRoster = new EncounterComponent();
            mookRoster.Monster = mook;
            mookRoster.Qty = numMonsters;
            encounter.MemberList.Add(mookRoster);
            LastEncounter = encounter;
            return encounter;
        }

        public string GetDifficultyReport(Encounter encounter)
        {
            string difficulty = CalcActualDifficulty(encounter);

            int partyEasy = CalcEasyThreshold();
            int partyMedium = CalcMediumThreshold();
            int partyHard = CalcHardThreshold();
            int partyDeadly = CalcDeadlyThreshold();
            int partyAbsurd = (partyDeadly - partyHard) + partyDeadly;

            string breakdown = "Easy: " + partyEasy.ToString() + "\n"
                + "Medium: " + partyMedium.ToString() + "\n"
                + "Hard: " + partyHard.ToString() + "\n"
                + "Deadly: " + partyDeadly.ToString() + "\n"
                + "Absurd: " + partyAbsurd.ToString();

            int totalXp = encounter.GetTotalXpv();
            int totalPcs = CalcTotalPcs();
            int totalMonsters = encounter.GetTotalMonsters();

            float xpMod = CalcXpMultiplier(totalMonsters, totalPcs);
            int adjustedXpv = ((int)(xpMod * totalXp));

            string totals = "Total XP: " + totalXp.ToString() + "\n"
                + "Adjusted XP: " + adjustedXpv.ToString();

            string report = "Difficulty: " + difficulty + "\n" + "\n"
                + breakdown + "\n" + "\n"
                + totals;

            return report;
        }

        public string CalcActualDifficulty(Encounter encounter)
        {
            int partyEasy = CalcEasyThreshold();
            int partyMedium = CalcMediumThreshold();
            int partyHard = CalcHardThreshold();
            int partyDeadly = CalcDeadlyThreshold();
            int partyAbsurd = (partyDeadly - partyHard) + partyDeadly;

            int totalMonsterXp = 0;
            int qtyMonsters = 0;
            foreach (var comp in encounter.MemberList)
            {
                int qty = comp.Qty;
                Ancestry monster = comp.Monster;
                int xpv = monster.GetXpValue();
                totalMonsterXp += (xpv * qty);
                qtyMonsters += qty;
            }

            int qtyPcs = CalcTotalPcs();
            float xpMod = CalcXpMultiplier(qtyMonsters, qtyPcs);
            totalMonsterXp = (int)(totalMonsterXp * xpMod);

            string difficulty;
            if (totalMonsterXp < partyEasy) { difficulty = "Trivial"; }
            else if (totalMonsterXp < partyMedium) { difficulty = "Easy"; }
            else if (totalMonsterXp < partyHard) { difficulty = "Medium"; }
            else if (totalMonsterXp < partyDeadly) { difficulty = "Hard"; }
            else if (totalMonsterXp < partyAbsurd) { difficulty = "Deadly"; }
            else { difficulty = "Absurd"; }

            return difficulty;
        }

        public float CalcXpMultiplier(int qtyMonsters, int qtyPlayers)
        {
            if (qtyPlayers < 3)
            {
                if (qtyMonsters <= 1) { return 1.5f; }
                if (qtyMonsters == 2) { return 2; }
                if (qtyMonsters >= 3 && qtyMonsters <= 6) { return 2.5f; }
                if (qtyMonsters >= 7 && qtyMonsters <= 10) { return 3; }
                if (qtyMonsters >= 11 && qtyMonsters <= 14) { return 4; }
                return 5;
            }
            if (qtyPlayers > 5)
            {
                if (qtyMonsters <= 1) { return 0.5f; }
                if (qtyMonsters == 2) { return 1f; }
                if (qtyMonsters >= 3 && qtyMonsters <= 6) { return 1.5f; }
                if (qtyMonsters >= 7 && qtyMonsters <= 10) { return 2; }
                if (qtyMonsters >= 11 && qtyMonsters <= 14) { return 2.5f; }
                return 3;
            }

            if (qtyMonsters <= 1) { return 1; }
            if (qtyMonsters == 2) { return 1.5f; }
            if (qtyMonsters >= 3 && qtyMonsters <= 6) { return 2; }
            if (qtyMonsters >= 7 && qtyMonsters <= 10) { return 2.5f; }
            if (qtyMonsters >= 11 && qtyMonsters <= 14) { return 3; }
            return 4;
        }

        public int CalcTotalPcs()
        {
            int total = 0;
            if (PcLevelList.Count != PcQtyList.Count)
            {
                throw new Exception("Sizes of Level list and Qty list do " +
                    "not match.");
            }

            for (int i = 0; i < PcQtyList.Count; ++i)
            { 
                if (PcLevelList[i] == 0) { continue; }
                total += PcQtyList[i]; 
            }
            return total;
        }

        public int CalcLowerThreshold()
        {
            switch(Difficulty)
            {
                case "Easy": return CalcEasyThreshold();
                case "Medium": return CalcMediumThreshold();
                case "Hard": return CalcHardThreshold();
                case "Deadly": return CalcDeadlyThreshold();
                default:
                    throw new Exception("Bad difficulty: " + Difficulty);
            }
        }

        public int CalcUpperThreshold()
        {
            switch(Difficulty)
            {
                case "Easy": return CalcMediumThreshold();
                case "Medium": return CalcHardThreshold();
                case "Hard": return CalcDeadlyThreshold();
                case "Deadly":
                    int diff = CalcDeadlyThreshold() - CalcHardThreshold();
                    return CalcDeadlyThreshold() + diff;
                default:
                    throw new Exception("Bad difficulty: " + Difficulty);
            }
        }

        public int CalcRandomUpperThreshold()
        {
            var dice = Dice.Instance;
            int subDifficultyLevel = dice.Roll(1, 3);

            int lowerThreshold = CalcLowerThreshold();
            int upperThreshold = CalcUpperThreshold();
            int difficultyXpSize = upperThreshold - lowerThreshold;
            float mod;
            int range;

            switch (subDifficultyLevel)
            {
                case 1:
                    LastSubDifficulty = "Low";
                    mod = 0.25f;
                    range = (int)(difficultyXpSize * mod);
                    return lowerThreshold + range;
                case 2:
                    LastSubDifficulty = "Middle";
                    mod = 0.5f;
                    range = (int)(difficultyXpSize * mod);
                    return lowerThreshold + range;
                default:
                    LastSubDifficulty = "High";
                    return upperThreshold;
            }
        }

        public int CalcEasyThreshold()
        {
            int[] thresholdList = 
            { 
                0, 25, 50, 75, 125, 250, 300, 350, 450, 550, 
                600, 800, 1000, 1100, 1250, 1400, 1600, 2000, 2100, 2400, 
                2800
            };

            return _calcThreshold(thresholdList);
        }

        public int CalcMediumThreshold()
        {
            int[] thresholdList =
            {
                0, 50, 100, 150, 250, 500, 600, 750, 900, 1100,
                1200, 1600, 2000, 2200, 2500, 2800, 3200, 3900, 4200, 4900,
                5700
            };

            return _calcThreshold(thresholdList);
        }

        public int CalcHardThreshold()
        {
            int[] thresholdList =
            {
                0, 75, 150, 225, 375, 750, 900, 1100, 1400, 1600, 
                1900, 2400, 3000, 3400, 3800, 4300, 4800, 5900, 6300, 7300, 
                8500
            };

            return _calcThreshold(thresholdList);
        }

        public int CalcDeadlyThreshold()
        {
            int[] thresholdList =
            {
                0, 100, 200, 400, 500, 1100, 1400, 1700, 2100, 2400, 
                2800, 3600, 4500, 5100, 5700, 6400, 7200, 8800, 9500, 10900, 
                12700
            };

            return _calcThreshold(thresholdList);
        }

        private int _calcThreshold(int[] thresholdList)
        {
            if (thresholdList.Length != 21)
            {
                throw new Exception("Threshold list is bad length.");
            }

            int totalThreshold = 0;

            for (int i = 0; i < PcLevelList.Count; ++i)
            {
                bool isBadMatch = PcQtyList.Count < i + 1;
                if (isBadMatch) 
                {
                    throw new Exception("Size mismatch between PC levels " +
                        "and PC qtys");
                }

                int level = PcLevelList[i];
                int qty = PcQtyList[i];

                bool isNotSet = level == 0 || qty == 0;
                if (isNotSet) { continue; }

                int individualThreshold = thresholdList[level];
                int levelThreshold = individualThreshold * qty;
                totalThreshold += levelThreshold;
            }

            return totalThreshold;
        }
    }
}
