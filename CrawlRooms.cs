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

        public List<string> BookList;
        public List<string> MundaneItemList;


        public void RandomizeRoom(string dungeonType, bool isLargeRooms,
            bool isNarrowHalls, int tier, ExitDirection enterFrom,
            CrawlRoomExit entry, bool isSetEncounters,
            MagicItemPermissions allowedLoot, string biome,
            bool isStandardRace, List<int> pcLevelList, List<int> pcQtyList,
            bool isSpellbooksInHorde)
        {
            _setIsHall();
            _setRoomSize(isLargeRooms, isNarrowHalls);
            Illumination = new CrawlRoomIllumintion();
            Feature = new CrawlRoomFeature();
            if (IsHall)
            {
                _setHallShape(tier, enterFrom, entry);
                Illumination.InitForHall();
            }
            else
            {
                _setRoomShape(tier, enterFrom, entry);
                Illumination.InitForRoom();
                Feature.Init();
            }

            var typeTableFactory = JsonChamberPurposeLoader.Instance;
            var typeTable =
                typeTableFactory.GetDungeonRoomTypeTable(dungeonType);
            if (IsHall)
            {
                RoomType = "Hallway";
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
                    pcQtyList, IsHall, isSpellbooksInHorde);

            }
            else
            {
                Contents.Init(tier, allowedLoot, IsHall, isSpellbooksInHorde);
            }

            _setFeaturesByRoomType(tier, allowedLoot, isSpellbooksInHorde);

        }

        public string GetHeader()
        {
            return
                (Feature.Descriptor == "" ? "" : Feature.Descriptor + " ")
                + RoomType;
        }

        public string AsString()
        {
            // RoomType comes out seperately as headder for formatting.
            string books = "";
            if (!(BookList is null))
            {
                books = "Books:\n";
                foreach (var book in BookList)
                {
                    books += "  - " + book + "\n";
                }
            }

            string mundaneItems = "";
            if (!(MundaneItemList is null))
            {
                mundaneItems = "Misc Containers:\n";
                foreach (var item in MundaneItemList)
                {
                    mundaneItems += "  - " + item + "\n";
                }
            }

            string desc = ""
                + "Illumination: " + Illumination.AsString() + "\n"
                + RoomSize + ", " + RoomShape + "\n"
                + (IsHall ? "" : "Orientation: " + Orientation.ToString() + "\n")
                + "Contents: " + Contents.ToString() + "\n"
                + books 
                + mundaneItems
                + GetExits()
                ;
            return desc;
        }

        public string GetExits()
        {
            int numExits = 0;
            if (!(NorthExit is null)) { ++numExits; }
            if (!(SouthExit is null)) { ++numExits; }
            if (!(EastExit is null)) { ++numExits; }
            if (!(WestExit is null)) { ++numExits; }

            string north = NorthExit is null ? "" : "North: " + NorthExit.ToString() + "\n";
            string south = SouthExit is null ? "" : "South: " + SouthExit.ToString() + "\n";
            string east = EastExit is null ? "" : "East: " + EastExit.ToString() + "\n";
            string west = WestExit is null ? "" : "West: " + WestExit.ToString() + "\n";

            return "Exits: " + numExits.ToString() + "\n"
                + north
                + south
                + east
                + west;
        }

        public void _setFeaturesByRoomType(int tier, 
            MagicItemPermissions permissions, bool isSpellbooksInHorde
            )
        {
            var dice = Dice.Instance;
            var dataSource = DataSourceLoader.Instance;

            if (RoomType.ToLower().Contains("vault"))
            {
                bool isLooted = dice.Roll(1, 6) <= 2;
                if (isLooted &&
                    !(
                    Contents.ContentType == CrawlRoomContents.RoomContentType.HazardAndTreasure
                    || Contents.ContentType == CrawlRoomContents.RoomContentType.MonsterAndTreasure
                    || Contents.ContentType == CrawlRoomContents.RoomContentType.TrapAndTreasure
                    || Contents.ContentType == CrawlRoomContents.RoomContentType.Treasure
                    )
                    )
                {
                    RoomType += " (Recently looted)";
                    Contents.RoomTreasure = null;
                }
                else
                {
                    Contents.SetRoomHoard(tier, permissions, isSpellbooksInHorde);

                }
                SetStorageItems();
                
            }
            if ( RoomType.Contains("Trap") )
            {
                bool isComplexTrap = dice.Roll(1, 6) <= 1;
                if (isComplexTrap)
                {
                    Contents.RoomTrap = null;
                    Contents.ComplexTrap = new CrawlRoomComplexTrap();
                    Contents.ComplexTrap.Init(tier);
                }
                else
                {
                    Contents.RoomTrap = new CrawlRoomTrap();
                    Contents.RoomTrap.InitAsRoomTrap(tier);
                    Contents.ComplexTrap = null;
                }
            }
            if (RoomType.Contains("trap"))
            {
                bool isTrapped = dice.Roll(1, 4) <= 2;
                if (isTrapped)
                {
                    Contents.SetRoomTrap(tier);
                }
            }
            if (RoomType.Contains("Armory"))
            {
                Contents.SetArmoryContents();
                SetStorageItems();
            }
            if (RoomType.Contains("Chapel")
                || RoomType.Contains("Shrine")
                || RoomType.Contains("Central temple")
                || RoomType == "Chantry"
                )

            {
                bool hasStrangObject = dice.Roll(1, 6) <= 2;
                if (hasStrangObject)
                {
                    var furnishingTable = new JsonReligiousArticles();
                    string furnishing = furnishingTable.GetItem();
                    string descriptor = Descriptors.UnusualObjectDescriptor();
                    string item = descriptor + " " + furnishing;
                    if (Contents.RoomTrick == null)
                    {
                        Contents.RoomTrick = new CrawlRoomTrick();
                        Contents.RoomTrick.Init();
                    }
                    Contents.RoomTrick.Object = item;
                }
            }
            if (RoomType.Contains("Cistern")
                || RoomType.Contains("Well")
                || RoomType.ToLower().Contains("bath")
                )
            {
                Contents.RoomTrick = new CrawlRoomTrick();
                Contents.RoomTrick.Object = "Filled with: " + 
                    CrawlRoomTrick.ChoosePoolLiquid(); 
                bool isTrick = dice.Roll(1, 6) == 1;
                if (isTrick)
                {
                    Contents.RoomTrick.Effect = 
                        CrawlRoomTrick.ChooseTrickEffect();
                }
            }
            if (RoomType.Contains("Kennel")
                || RoomType.ToLower().Contains("zoo")
                || RoomType.Contains("Stable")
                || RoomType.Contains("Bestiary")
                )
            {
                bool isEncounter = dice.Roll(1, 6) <= 3;
                if (isEncounter)
                {
                    Contents.ContentType = 
                        CrawlRoomContents.RoomContentType.Monster;
                }
            }
            if (RoomType.Contains("Pen")
                || RoomType.Contains("Prison")
                || RoomType == "Cell"
                )
            {
                // Chance of ally
                bool isEncounter = dice.Roll(1, 6) <= 3;
                if (isEncounter)
                {
                    Contents.ContentType = 
                        CrawlRoomContents.RoomContentType.Monster;
                }
            }
            if (RoomType.Contains("Storage"))
            {
                int roll = dice.Roll(1, 8);
                bool isHoard = roll == 8;
                bool isIncidental = roll >= 6;
                bool isEmpty = roll == 1;
                if (isHoard)
                {
                    Contents.SetRoomHoard(tier, permissions, isSpellbooksInHorde);
                    SetStorageItems();
                }
                else if (isIncidental)
                {
                    Contents.SetIncidentalTreasure(tier);
                    SetStorageItems();
                }
                else if (isEmpty)
                {
                    Contents.RoomTreasure = null;
                    RoomType += " (Empty)";
                }
                else
                {
                    SetStorageItems();
                }
            }
            if (RoomType.Contains("Throne"))
            {
                if (Contents.RoomTrick is null)
                {
                    Contents.SetRoomTrick();
                    if (!(Contents.RoomTrick is null))
                    {
                        Contents.RoomTrick.Object = "Throne";
                    }
                    else if (!(Contents.RoomGate is null))
                    {
                        Contents.RoomGate.GateForm = "Throne";
                    }
                }
            }
            if (RoomType.Contains("Trophy")
                || RoomType.Contains("Gallery")
                )
            {
                int roll = dice.Roll(1, 6);
                bool isHoard = roll == 6;
                bool isIncidental = roll >= 4;
                if (isHoard)
                {
                    Contents.SetRoomHoard(tier, permissions, isSpellbooksInHorde);
                }
                else if (isIncidental)
                {
                    Contents.SetIncidentalTreasure(tier);
                }
            }
            if (RoomType.Contains("Workshop"))
            {
                // What kind?
                SetStorageItems();
            }
            if (RoomType.Contains("Conjuring"))
            {
                bool isGate = dice.Roll(1, 6) <= 3;
                bool isMonster = dice.Roll(1, 6) <= 2;
                bool isCircle = (dice.Roll(1, 6) <= 3) && !isGate;
                if (isGate)
                {
                    Contents.RoomGate = new CrawlRoomGate();
                    Contents.RoomGate.Init();
                    Contents.RoomGate.GateDestination = 
                        CrawlRoomGate.ChooseAnotherDimension();
                    Contents.RoomGate.GateDirection = "One-way, to here";
                }
                if (isMonster)
                {
                    if (Contents.ContentType != 
                        CrawlRoomContents.RoomContentType.MonsterAndTreasure)
                    {
                        Contents.ContentType = 
                            CrawlRoomContents.RoomContentType.Monster;
                    }
                }
                if (isCircle)
                {
                    Contents.SetRoomTrick();
                    Contents.RoomTrick.Object = "Magic circle";
                }
            }
            if (RoomType.Contains("Lair"))
            {
                bool isMonster = dice.Roll(1, 6) <= 4;
                if (isMonster)
                {
                    if (Contents.ContentType != 
                        CrawlRoomContents.RoomContentType.MonsterAndTreasure)
                    {
                        Contents.ContentType = 
                            CrawlRoomContents.RoomContentType.Monster;
                    }
                }
            }
            if (RoomType.Contains("Library")
                || RoomType.Contains("Study")
                || RoomType.Contains("Classroom")
                || RoomType.Contains("schoolroom")
                )
            {
                var bookSource = dataSource.BookSource;
                int numBooks = dice.Roll(1, 4);
                BookList = new List<string>();
                for (int i = 0; i < numBooks; ++i)
                {
                    BookList.Add(bookSource.GetBookSubject());
                }
            }
            if (RoomType.Contains("Planar"))
            {
                bool isActive = dice.Roll(1, 4) == 4;
                Contents.RoomGate = new CrawlRoomGate();
                Contents.RoomGate.Init();
                if (!isActive)
                {
                    RoomType += " (Currently inactive)";
                }
                Contents.RoomGate.GateDestination = 
                    CrawlRoomGate.ChooseAnotherDimension();
            }
            if (RoomType.Contains("Crypt")
                || RoomType.Contains("Tomb")
                )
            {
                // chance of tomb object/sepulcher
                bool isMonster = dice.Roll(1, 6) <= 2;
                if (isMonster)
                {
                    if (Contents.ContentType != 
                        CrawlRoomContents.RoomContentType.MonsterAndTreasure)
                    {
                        Contents.ContentType = 
                            CrawlRoomContents.RoomContentType.Monster;
                    }
                }
            }
            if (RoomType.Contains("Grand crypt"))
            {
                // 100% with sepulcher
                RoomSize = "Large";
            }
            if (RoomType.Contains("large")
                || RoomType.Contains("great")
                )
            {
                RoomSize = "Large";
            }
            if (RoomType.Contains("Divination"))
            {
                // divination object
            }
            if (RoomType.Contains("Guard")
                || RoomType.Contains("Watch room")
                )
            {
                bool isMonster = dice.Roll(1, 6) <= 4;
                if (isMonster)
                {
                    if (Contents.ContentType != 
                        CrawlRoomContents.RoomContentType.MonsterAndTreasure)
                    {
                        Contents.ContentType = 
                            CrawlRoomContents.RoomContentType.Monster;
                    }
                }
            }
            if (RoomType == "Closet")
            {
                RoomSize = "Small";
                SetStorageItems();
            }

        }

        public void SetStorageItems()
        {
            var dataSource = DataSourceLoader.Instance;
            var dice = Dice.Instance;
            var contentsSource = dataSource.ContainerContentsSource;
            int numContainers = dice.Roll(1, 3) + 1;
            MundaneItemList = new List<string>();
            for (int i = 0; i < numContainers; ++i)
            {
                string mundaneItem =
                    contentsSource.GetContainer() + " of " +
                    contentsSource.GetContainerContent();
                MundaneItemList.Add(mundaneItem);
            }
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
                case ExitDirection.EXIT_WEST:
                    EastExit = straightExit;
                    NorthExit = leftExit;
                    SouthExit = rightExit;
                    WestExit = entry;
                    break;
                default:
                    EastExit = _buildExit(isLeft, tier);
                    NorthExit = _buildExit(isRight, tier);
                    SouthExit = _buildExit(isStraight, tier);
                    WestExit = _buildExit(tier);
                    break;
            }

        }

        private CrawlRoomExit _buildExit(int tier)
        {
            var dice = Dice.Instance;
            bool isSet = dice.Roll(1, 6) <= 3;
            return _buildExit(isSet, tier);
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
