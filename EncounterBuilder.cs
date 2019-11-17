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
    class EncounterBuilder
    {
        public List<int> PcLevelList = new List<int>();
        public List<int> PcQtyList = new List<int>();
        public string Difficulty;

        public AncestryIndex MonsterSource;

        public Encounter LastEncounter;
        public float LastModifier;
        public string LastSubDifficulty;

        public string LastEncounterAsString()
        {
            // TODO: Calculate actual difficulty, not the expected difficulty
            string output = "Difficulty: " 
                + LastSubDifficulty + " "
                + Difficulty + "\n"
                + LastEncounter.AsString() + "\n"
                + "Adjusted xp: " 
                + ((int)(LastModifier * LastEncounter.GetTotalXpv())).ToString()
                ;

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
            int roll = dice.Roll(1, 4);
            switch(roll)
            {
                case 1: return PickOneMookPerPc(biome, isStandardRace);
                case 2: return PickTwoMooksPerPc(biome, isStandardRace);
                case 3: return PickOneBoss(biome, isStandardRace);
                case 4: return PickBossWithMooks(biome, isStandardRace);
                default: 
                    throw new Exception("Invalid encounter strategy selected.");
            }
        }

        public Encounter PickOneBoss(string biome, bool isStandardRace)
        {
            return PickMooks(numMonsters: 1, biome, isStandardRace);
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

        public Encounter PickBossWithMooks(string biome, bool isStandardRace)
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
            int randomUpperThreshold = CalcRandomUpperThreshold();
            int bossXpValue = (int)(randomUpperThreshold * bossMod);

            // boss
            int totalMonsters = numPcs + 1;
            float mod = CalcXpMultiplier(totalMonsters , numPcs);
            bossXpValue = (int)(bossXpValue / mod);

            Ancestry boss = MonsterSource.GetRandomAncestryByXpv(biome, 
                bossXpValue, isStandardRace);
            var bossRoster = new EncounterComponent();
            bossRoster.Monster = boss;
            bossRoster.Qty = 1;
            encounter.MemberList.Add(bossRoster);

            // mooks
            // TODO: The Mooks are too high CR for their difficulty and qty
            int xpLeftForMooks = randomUpperThreshold - bossXpValue;
            int totalMooks = numPcs;
            int mookXpValue = (int)(xpLeftForMooks / totalMooks);
            Ancestry mooks = MonsterSource.GetRandomAncestryByXpv(biome,
                mookXpValue, isStandardRace);
            var mookRoster = new EncounterComponent();
            mookRoster.Monster = mooks;
            mookRoster.Qty = totalMooks;
            encounter.MemberList.Add(mookRoster);

            // save
            LastModifier = mod;
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
            int randomUpperThreshold = CalcRandomUpperThreshold();
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
