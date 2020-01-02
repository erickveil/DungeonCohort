using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    /// <summary>
    /// 1/3 monster, 1/3 empty, 1/6 trap, trick, other, 1/6 treasure
    /// </summary>
    class CrawlRoomContents
    {
        public enum RoomContentType 
        { 
            Empty, Monster, Trap, Hazard, Obstacle, Trick, Treasure,
            MonsterAndTreasure, HazardAndTreasure, TrapAndTreasure, 
            Merchant 
        };
        public RoomContentType ContentType;

        public string EncounterDifficulty;
        public Encounter RoomEncounter = null;
        public CrawlRoomTrap RoomTrap = null;
        public CrawlRoomComplexTrap ComplexTrap = null;
        public LootTableResult RoomTreasure = null;
        public string RoomHazard = "";
        public CrawlRoomTrick RoomTrick = null;
        public CrawlRoomGate RoomGate = null;

        public static string GetRandomDifficulty()
        {
            var table = new RandomTable<string>();

            table.AddItem("Easy", 4);
            table.AddItem("Medium", 16);
            table.AddItem("Hard", 8);
            table.AddItem("Deadly");

            return table.GetResult();
        }

        public void Init(int tier, MagicItemPermissions allowedLoot, 
            bool isHall)
        {
            EncounterDifficulty = GetRandomDifficulty();

            var contentsTable = new RandomTable<RoomContentType>();

            
            if (isHall)
            {
                contentsTable.AddItem(RoomContentType.Empty, 20);
                contentsTable.AddItem(RoomContentType.Monster, 5);
                contentsTable.AddItem(RoomContentType.Trap, 5);
                contentsTable.AddItem(RoomContentType.Hazard, 2);
                /*
                contentsTable.AddItem(RoomContentType.Obstacle, 2);
                */
            }
            else
            {
                contentsTable.AddItem(RoomContentType.Empty, 8);
                contentsTable.AddItem(RoomContentType.Monster, 28);
                contentsTable.AddItem(RoomContentType.MonsterAndTreasure, 20);
                contentsTable.AddItem(RoomContentType.Trap, 10);
                contentsTable.AddItem(RoomContentType.TrapAndTreasure, 3);
                contentsTable.AddItem(RoomContentType.Treasure, 6);
                contentsTable.AddItem(RoomContentType.Hazard, 6);
                contentsTable.AddItem(RoomContentType.HazardAndTreasure, 8);
                contentsTable.AddItem(RoomContentType.Trick, 6);
                /*
                contentsTable.AddItem(RoomContentType.Obstacle, 4);
                contentsTable.AddItem(RoomContentType.Merchant);
                */
            }

            ContentType = contentsTable.GetResult();

            switch (ContentType)
            {
                case RoomContentType.Empty:
                    break;
                case RoomContentType.Monster:
                    break;
                case RoomContentType.MonsterAndTreasure:
                    SetRoomHoard(tier, allowedLoot);
                    break;
                case RoomContentType.Trap:
                    SetRoomTrap(tier);
                    break;
                case RoomContentType.TrapAndTreasure:
                    SetRoomTrap(tier);
                    SetRoomHoard(tier, allowedLoot);
                    break;
                case RoomContentType.Hazard:
                    SetRoomHazard(tier);
                    break;
                case RoomContentType.HazardAndTreasure:
                    SetRoomHazard(tier);
                    SetIncidentalTreasure(tier);
                    break;
                case RoomContentType.Obstacle:
                    break;
                case RoomContentType.Trick:
                    SetRoomTrick();
                    break;
                case RoomContentType.Merchant:
                    break;
                case RoomContentType.Treasure:
                    SetRoomHoard(tier, allowedLoot);
                    break;
            }
        }

        public void Init(string biome, bool isStandardRace, 
            MagicItemPermissions allowedLoot, List<int> pcLevelList,
            List<int> pcQtyList, bool isHall)
        {
            int tier = EncounterFactory.GetTier(pcLevelList, pcQtyList);
            Init(tier, allowedLoot, isHall);

            if (ContentType == RoomContentType.Monster 
                || ContentType == RoomContentType.MonsterAndTreasure)
            {
                SetRoomEncounter(biome, isStandardRace, pcLevelList, pcQtyList);
            }
        }

        public override string ToString()
        {
            string difficultyDesc;
            if (ContentType == RoomContentType.Monster 
                || ContentType == RoomContentType.MonsterAndTreasure) 
            { 
                difficultyDesc = " (" + EncounterDifficulty + ")\n"; 
            }
            else 
            { 
                difficultyDesc = "\n"; 
            }

            string desc = _getTypeString(ContentType)
                + difficultyDesc
                + (RoomHazard == "" ? "" : RoomHazard + "\n")
                + (RoomEncounter is null ? "" : RoomEncounter.ToString() + "\n")
                + (RoomTrick is null ? "" : RoomTrick.ToString() + "\n")
                + (RoomGate is null ? "" : RoomGate.ToString() + "\n")
                + (RoomTrap is null ? "" : RoomTrap.ToString() + "\n")
                + (ComplexTrap is null ? "" : ComplexTrap.ToString() + "\n")
                + (RoomTreasure is null ? "" : RoomTreasure.ToString() + "\n")
                ;
            return desc;
        }

        public void SetRoomTrick()
        {
            var dice = Dice.Instance;

            int roll = dice.Roll(1, 6);

            if (roll <= 4)
            {
                RoomTrick = new CrawlRoomTrick();
                RoomTrick.Init();
                return;
            }
            else
            {
                RoomGate = new CrawlRoomGate();
                RoomGate.Init();
                return;
            }
        }

        public void SetRoomHazard(int tier)
        {
            string severity = CrawlRoomTrap.ChooseSeverity();
            int dc = CrawlRoomTrap.ChooseDc(severity);
            string damage = CrawlRoomTrap.ChooseDamage(tier, severity);
            string gas = CrawlRoomTrap.ChooseGasType();

            var table = new RandomTable<string>();
            table.AddItem("Brown mold (" + damage + " cold damage)");
            table.AddItem("Green slime (" + damage + " acid damage)");
            table.AddItem("Shrieker (alarm - check for wandering monsters)");
            table.AddItem("Violet Fungus (Monster Manual - necrotic damage)");
            table.AddItem("Yellow Mold (" + damage + " poison damage)");
            table.AddItem("Spiderwebs (DC " + dc + " dex save or restrained)");
            table.AddItem("Area currently caved in and not passable");
            table.AddItem("Cave in when PCs pass through (DC " + dc 
                + " dex save or take " + damage + " bludgeoning damage)");
            table.AddItem("Monster in area and 1 in 10 chance of cave in " +
                "each combat round");
            table.AddItem("Area caves in after PCs pass and blocks return");
            table.AddItem("Floor caves in and party drops to lower level");
            table.AddItem("Partial flooding, up to knees");
            table.AddItem("Partial flooding, conceals trap (disadvantage to " +
                "detect)");
            table.AddItem("Deeply submerged (10-20 ft) - swimming required " +
                "(check for wandering aquatic monster)");
            table.AddItem("Completely submerged - underwater swimming " +
                "required (check for wandering aquatic monster)");
            table.AddItem("Desecrated ground with undead (advantage to " +
                "all rolls)");
            table.AddItem("Slippery - Check for wandering monstar (DC 10 " +
                "acrobatics or fall prone each movement phase)");
            table.AddItem("Magic dead area");
            table.AddItem("Area filled with gas: " + gas);
            table.AddItem("The floor is lava (sink if entered, " + damage + 
                " damage each round, DC " + dc + " check to escape)");
            table.AddItem("Room is on fire (" + damage + " fire damage " + 
                "each turn in area)");
            table.AddItem("Rubble filled area. Difficult terrain.");
            table.AddItem("Elder rune: " + CrawlRoomGate.ChooseElderRune());

            RoomHazard = table.GetResult();

            if (RoomHazard.ToLower().Contains("trap")) { SetRoomTrap(tier); }

        }

        public void SetRoomEncounter(string biome, bool isStandardRace, 
            List<int> pcLevelList, List<int> pcQtyList)
        {
            var encounterGen = new EncounterFactory();
            encounterGen.PcLevelList = pcLevelList;
            encounterGen.PcQtyList = pcQtyList;
            encounterGen.Difficulty = EncounterDifficulty;
            RoomEncounter = encounterGen.PickRandomEncounter(biome, isStandardRace);
        }

        public void SetRoomTrap(int tier)
        {
            var dice = Dice.Instance;
            bool isComplexTrap = dice.Roll(1, 6) <= 2;
            if (isComplexTrap)
            {
                ComplexTrap = new CrawlRoomComplexTrap();
                ComplexTrap.Init(tier);
            }
            else
            {
                RoomTrap = new CrawlRoomTrap();
                RoomTrap.InitTrap(tier);
            }
        }

        public void SetRoomHoard(int tier, MagicItemPermissions permissions)
        {
            var lootGen = new TreasureFactory();
            RoomTreasure = lootGen.GetTreasureHoard(tier, permissions);
        }

        public void SetIncidentalTreasure(int tier)
        {
            var lootGetn = new TreasureFactory();
            RoomTreasure = lootGetn.GetIndividualTreasure(tier);
        }

        private string _getTypeString(RoomContentType typeVal)
        {
            switch (typeVal)
            {
                case RoomContentType.HazardAndTreasure: return "Hazard And Treasure";
                case RoomContentType.MonsterAndTreasure: return "Monster And Treasure";
                case RoomContentType.TrapAndTreasure: return "Trap And Treasure";
                default: return typeVal.ToString();
            }
        }

    }
}
