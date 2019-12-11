using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;
using DungeonCohort.JsonLoading;

namespace DungeonCohort
{
    /// <summary>
    /// Generates random dungeon rooms
    /// 
    /// </summary>
    class CrawlRooms
    {
        public enum ExitDirection  
        { 
            EXIT_NORTH, EXIT_SOUTH, EXIT_WEST, EXIT_EAST 
        };

        public string RoomSize;
        public string RoomShape;
        public bool IsHall;
        public string RoomType;
        public int Orientation;
        public CrawlRoomIllumintion Illumination;
        public CrawlRoomFeature Feature;
        public CrawlRoomContents Contents;
        public CrawlRoomExit NorthExit = null;
        public CrawlRoomExit SouthExit = null;
        public CrawlRoomExit EastExit = null;
        public CrawlRoomExit WestExit = null;
        public CrawlRoomExit StandardExit;
        public int CeilingHeight; // also choose a standard height?


        public void RandomizeRoom(string dungeonType, bool isLargeRooms, 
            bool isNarrowHalls, int tier, ExitDirection enterFrom, 
            CrawlRoomExit entry, bool isSetEncounters, 
            MagicItemPermissions allowedLoot, string biome, 
            bool isStandardRace, List<int> pcLevelList, List<int> pcQtyList)
        {
            _setIsHall();
            _setRoomSize(isLargeRooms, isNarrowHalls);
            Illumination = new CrawlRoomIllumintion();
            if (IsHall)
            {
                _setHallShape(tier, enterFrom, entry);
                Illumination.InitForHall();
            }
            else
            {
                _setRoomShape(tier, enterFrom, entry);
                Illumination.InitForRoom();
            }

            var typeTableFactory = JsonChamberPurposeLoader.Instance;
            var typeTable = 
                typeTableFactory.GetDungeonRoomTypeTable(dungeonType);
            if (IsHall)
            {
                RoomType = "Hall";
            }
            else
            {
                RoomType = typeTable.GetResult();
            }

            var dice = Dice.Instance;
            Orientation = dice.Roll(1, 4);

            Contents = new CrawlRoomContents();
            if (isSetEncounters)
            {
                Contents.Init(biome, isStandardRace, allowedLoot, pcLevelList, 
                    pcQtyList, IsHall);

            }
            else
            {
                Contents.Init(tier, allowedLoot, IsHall);
            }

        }

        public string AsString()
        {
            // RoomType comes out seperately for formatting.

            string desc = ""
                + "Illumination: " + Illumination.AsString() + "\n"
                + RoomSize + ", " + RoomShape + "\n"
                + (IsHall ? "" : "Orientation: " + Orientation.ToString() + "\n")
                + "Contents: " + Contents.ToString() +  "\n"
                + "Exits:\n"
                + (NorthExit is null ? "" : "North: " + NorthExit.ToString() + "\n")
                + (SouthExit is null ? "" : "South: " + SouthExit.ToString() + "\n")
                + (EastExit is null ? "" : "East: " + EastExit.ToString() + "\n")
                + (WestExit is null ? "" : "West: " + WestExit.ToString() + "\n")
                ;
            return desc;
        }

        public void _setIsHall()
        {
            Dice dice = Dice.Instance;
            IsHall = (dice.Roll(1, 6) <= 2);
        }

        /// <summary>
        /// Rooms only
        /// </summary>
        private void _setRoomShape(int tier, ExitDirection enterFrom,
            CrawlRoomExit entry)
        {
            var shapeTable = new RandomTable<string>();
            shapeTable.AddItem("Square", 4);
            shapeTable.AddItem("Rectangle", 4);
            shapeTable.AddItem("Round", 2);
            shapeTable.AddItem("T-Shaped");
            shapeTable.AddItem("L-Shaped");

            var numExitsTable = new RandomTable<int>();
            numExitsTable.AddItem(0);
            numExitsTable.AddItem(1, 4);
            numExitsTable.AddItem(2, 8);
            numExitsTable.AddItem(3, 2);
            int numExits = numExitsTable.GetResult();
            var dice = Dice.Instance;
            int exitChance = 3;
            bool isLeft = false;
            bool isRight = false;
            bool isStraight = false;

            while (numExits > 0)
            {
                if (!isStraight)
                {
                    isStraight = (dice.Roll(1, 6) <= exitChance);
                    if (isStraight) { --numExits; }
                    if (numExits <= 0) { break; }
                }

                if (!isLeft)
                {
                    isLeft = (dice.Roll(1, 6) <= exitChance);
                    if (isLeft) { --numExits; }
                    if (numExits <= 0) { break; }
                }

                if (!isRight)
                {
                    isRight = (dice.Roll(1, 6) <= exitChance);
                    if (isRight) { --numExits; }
                    if (numExits <= 0) { break; }
                }

                if (isRight && isLeft && isStraight) { break; }
            }

            
            _setExits(enterFrom, entry, isRight, isLeft, isStraight, tier);

            RoomShape = shapeTable.GetResult();
        }


        /// <summary>
        /// Halls only
        /// </summary>
        /// <param name="tier"></param>
        /// <param name="enterFrom"></param>
        /// <param name="entry"></param>
        private void _setHallShape(int tier, ExitDirection enterFrom, 
            CrawlRoomExit entry)
        {
            var shapeTable = new RandomTable<string>();
            shapeTable.AddItem("Straight", 4);
            shapeTable.AddItem("Cross", 2);
            shapeTable.AddItem("T Fork", 8);
            shapeTable.AddItem("Right-turning", 2);
            shapeTable.AddItem("Left-turning", 2);
            shapeTable.AddItem("Stairs up one level");
            shapeTable.AddItem("Stairs down one level");

            RoomShape = shapeTable.GetResult();

            if (RoomShape.Contains("Straight")) {
                _setExits(enterFrom, entry, false, false, true, tier);
            }
            else if (RoomShape.Contains("Cross")) {
                _setExits(enterFrom, entry, true, true, true, tier);
            }
            else if (RoomShape.Contains("T")) {
                _setTHallExits(enterFrom, entry, tier);
            }
            else if (RoomShape.Contains("Right")) {
                _setExits(enterFrom, entry, true, false, false, tier);
            }
            else if (RoomShape.Contains("Left")) {
                _setExits(enterFrom, entry, false, true, false, tier);
            }
            else {
                _setExits(enterFrom, entry, false, false, false, tier);
            }
        }

        private void _setTHallExits(ExitDirection enterFrom, 
            CrawlRoomExit entry, int tier)
        {
            var dice = Dice.Instance;
            int orientation = dice.Roll(1, 3);
            switch (orientation) {
                case 1:
                    _setExits(enterFrom, entry, true, true, false, tier);
                    break;
                case 2:
                    _setExits(enterFrom, entry, false, true, true, tier);
                    break;
                default:
                    _setExits(enterFrom, entry, true, false, true, tier);
                    break;
            }
        }

        private void _setExits(ExitDirection enterFrom, 
            CrawlRoomExit entry,
            bool isRight, bool isLeft, bool isStraight, 
            int tier)
        {
            var dice = Dice.Instance;
            CrawlRoomExit leftExit = _buildExit(isLeft, tier);
            CrawlRoomExit rightExit = _buildExit(isRight, tier);
            CrawlRoomExit straightExit = _buildExit(isStraight, tier);

            switch (enterFrom)
            {
                case ExitDirection.EXIT_EAST:
                    EastExit = entry;
                    NorthExit = rightExit;
                    SouthExit = leftExit;
                    WestExit = straightExit;
                    break;
                case ExitDirection.EXIT_NORTH:
                    EastExit = leftExit;
                    NorthExit = entry;
                    SouthExit = straightExit;
                    WestExit = rightExit;
                    break;
                case ExitDirection.EXIT_SOUTH:
                    EastExit = rightExit;
                    NorthExit = straightExit;
                    SouthExit = entry;
                    WestExit = leftExit;
                    break;
                default: // west
                    EastExit = straightExit;
                    NorthExit = leftExit;
                    SouthExit = rightExit;
                    WestExit = entry;
                    break;
            }

        }

        private CrawlRoomExit _buildExit(bool isSet, int tier)
        {
            var dice = Dice.Instance;
            CrawlRoomExit roomExit = null;
            if (isSet)
            {
                bool isStandard = (dice.Roll(1, 6) > 2);
                if (isStandard) { roomExit = StandardExit; }
                else
                {
                    roomExit = new CrawlRoomExit();
                    roomExit.RandomizeExit(tier);
                }
            }
            else
            {
                roomExit = null;
            }
            return roomExit;
        }

        /// <summary>
        /// Requires IsHall to be set first
        /// </summary>
        /// <param name="isLargeRooms"></param>
        /// <param name="isNarrowHalls"></param>
        private void _setRoomSize(bool isLargeRooms, bool isNarrowHalls)
        {
            var sizeTable = new RandomTable<string>();
            if (IsHall)
            {
                sizeTable.AddItem("10 ft wide", 16);
                sizeTable.AddItem("20 ft wide");
                if (isNarrowHalls) { sizeTable.AddItem("5 ft wide"); }
            }
            else
            {
                sizeTable.AddItem("Small");
                sizeTable.AddItem("Medium", 4);
                if (isLargeRooms) { sizeTable.AddItem("Large"); }
            }
            RoomSize = sizeTable.GetResult();
        }
    }
}
