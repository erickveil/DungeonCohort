using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    /// <summary>
    /// Generates random dungeon rooms
    /// 
    /// </summary>
    class CrawlRooms
    {
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
            bool isNarrowHalls)
        {
            _setIsHall();
            _setRoomSize(isLargeRooms, isNarrowHalls);
        }

        public void AsString()
        {

        }

        public void _setIsHall()
        {
            Dice dice = Dice.Instance;
            IsHall = (dice.Roll(1, 6) <= 3);
        }

        private void _setHallShape()
        {
            var shapeTable = new RandomTable<string>();
            shapeTable.AddItem("Straight", 2);
            shapeTable.AddItem("Cross", 2);
            shapeTable.AddItem("T Fork", 2);
            shapeTable.AddItem("Right-turning", 2);
            shapeTable.AddItem("Left-turning", 2);
            shapeTable.AddItem("Stairs up one level");
            shapeTable.AddItem("Stairs down one level");

            int choice = shapeTable.GetResultIndex();
            RoomShape = shapeTable.GetResult(choice);

            switch (choice)
            {
                case 0: // straight
                    AheadExit = new CrawlRoomExit();
                    AheadExit.RandomizeExit();
                    break;
                case 1: // cross
                    RightExit = new CrawlRoomExit();
                    RightExit.RandomizeExit();
                    LeftExit = new CrawlRoomExit();
                    LeftExit.RandomizeExit();
                    AheadExit = new CrawlRoomExit();
                    AheadExit.RandomizeExit();
                    break;
                case 2: // T
                    RightExit = new CrawlRoomExit();
                    RightExit.RandomizeExit();
                    LeftExit = new CrawlRoomExit();
                    LeftExit.RandomizeExit();
                    break;
                case 3: // right
                    RightExit = new CrawlRoomExit();
                    RightExit.RandomizeExit();
                    break;
                case 4: // left
                    LeftExit = new CrawlRoomExit();
                    LeftExit.RandomizeExit();
                    break;
                default: //stairs; 
                    break;
            }
        }

        /// <summary>
        /// Rooms only
        /// </summary>
        private void _setRoomShape()
        {
            var shapeTable = new RandomTable<string>();
            shapeTable.AddItem("Square", 4);
            shapeTable.AddItem("Rectangle", 4);
            shapeTable.AddItem("Round", 2);
            shapeTable.AddItem("T-Shaped");
            shapeTable.AddItem("L-Shaped");

            var dice = Dice.Instance;
            if (dice.Roll(1, 6) <= 3)
            {
                LeftExit = new CrawlRoomExit();
                LeftExit.RandomizeExit();
            }
            if (dice.Roll(1, 6) <= 3)
            {
                RightExit = new CrawlRoomExit();
                RightExit .RandomizeExit();
            }
            if (dice.Roll(1, 6) <= 3)
            {
                AheadExit = new CrawlRoomExit();
                AheadExit.RandomizeExit();
            }

            RoomShape = shapeTable.GetResult();
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
