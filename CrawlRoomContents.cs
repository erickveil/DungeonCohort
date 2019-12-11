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

        public void Init(int tier, MagicItemPermissions allowedLoot)
        {
            var contentsTable = new RandomTable<RoomContentType>();

            // Current chances set to DMG 5e
            contentsTable.AddItem(RoomContentType.Empty, 8);
            contentsTable.AddItem(RoomContentType.Monster, 28);
            contentsTable.AddItem(RoomContentType.MonsterAndTreasure, 20);
            contentsTable.AddItem(RoomContentType.Trap, 10);
            contentsTable.AddItem(RoomContentType.TrapAndTreasure, 3);
            contentsTable.AddItem(RoomContentType.Hazard, 6);
            contentsTable.AddItem(RoomContentType.HazardAndTreasure, 8);
            contentsTable.AddItem(RoomContentType.Obstacle, 4);
            contentsTable.AddItem(RoomContentType.Trick, 4);
            contentsTable.AddItem(RoomContentType.Merchant);
            contentsTable.AddItem(RoomContentType.Treasure, 6);

            ContentType = contentsTable.GetResult();

            switch (ContentType)
            {
                case RoomContentType.Empty:
                    break;
                case RoomContentType.Monster:
                    // TODO: Generate difficulty - Save member for output
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
            List<int> pcQtyList)
        {
            int tier = EncounterFactory.GetTier(pcLevelList, pcQtyList);
            Init(tier, allowedLoot);

            if (ContentType == RoomContentType.Monster 
                || ContentType == RoomContentType.MonsterAndTreasure)
            {
                SetRoomEncounter(biome, isStandardRace);
            }
        }

        public override string ToString()
        {
            string desc = ContentType.ToString() + "\n"
                + (RoomEncounter is null ? "" : RoomEncounter.ToString() + "\n")
                + (RoomTrap is null ? "" : RoomTrap.ToString() + "\n")
                + (RoomTreasure is null ? "" : RoomTreasure.ToString())
                ;
            return desc;
        }

        public void SetRoomEncounter(string biome, bool isStandardRace)
        {
            var encounterGen = new EncounterFactory();
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

    }
}
