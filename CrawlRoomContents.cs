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
        public LootTableResult RoomTreasure = null;

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
                /*
                contentsTable.AddItem(RoomContentType.Hazard, 2);
                contentsTable.AddItem(RoomContentType.Obstacle, 2);
                contentsTable.AddItem(RoomContentType.Trick, 1);
                */
            }
            else
            {
                // Current chances set to DMG 5e
                contentsTable.AddItem(RoomContentType.Empty, 8);
                contentsTable.AddItem(RoomContentType.Monster, 28);
                contentsTable.AddItem(RoomContentType.MonsterAndTreasure, 20);
                contentsTable.AddItem(RoomContentType.Trap, 10);
                contentsTable.AddItem(RoomContentType.TrapAndTreasure, 3);
                contentsTable.AddItem(RoomContentType.Treasure, 6);
                /*
                contentsTable.AddItem(RoomContentType.Hazard, 6);
                contentsTable.AddItem(RoomContentType.Obstacle, 4);
                contentsTable.AddItem(RoomContentType.Trick, 4);
                contentsTable.AddItem(RoomContentType.HazardAndTreasure, 8);
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
                    break;
                case RoomContentType.HazardAndTreasure:
                    SetIncidentalTreasure(tier);
                    break;
                case RoomContentType.Obstacle:
                    break;
                case RoomContentType.Trick:
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
                + (RoomEncounter is null ? "" : RoomEncounter.ToString() + "\n")
                + (RoomTrap is null ? "" : RoomTrap.ToString() + "\n")
                + (RoomTreasure is null ? "" : RoomTreasure.ToString())
                ;
            return desc;
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
            RoomTrap = new CrawlRoomTrap();
            RoomTrap.InitTrap(tier);
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
