using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCohort
{
    class HexCrawl
    {
        public enum HexCrawlDirection { NE, E, SE, SW, W, NW }
        public HexCrawlHex CurrentHex;

        public HexCrawlHex NorthEastHex;
        public HexCrawlHex EastHex;
        public HexCrawlHex SouthEastHex;
        public HexCrawlHex SouthWestHex;
        public HexCrawlHex WestHex;
        public HexCrawlHex NorthWestHex;

        /// <summary>
        /// This hexgrid is generated as needed.
        /// All hexcrawls start at 0, 0
        /// </summary>
        public List<HexCrawlHex> HexMap;

        /// <summary>
        /// Moves from the current hex on the map to an adjacent one in the 
        /// indicated directon.
        /// Will generate new hexes where needed.
        /// Sets the current hex to the one moved to, then consult the HexMap.
        /// Existing surrounding hexxes are set to the appropriate neighbor
        /// objects.
        /// Where neighbors don't exist, new ones are created and given the
        /// propper coordiante values.
        /// The neighbor hex descriptions are set on the current hex, based 
        /// on the surroundings.
        /// </summary>
        /// <param name="moveDirection"></param>
        public void Move(HexCrawlDirection moveDirection)
        {

        }

        public void TeleportToCoordinates(int x, int y)
        {

        }

        public void GenerateSurroundingHexes(int x, int y)
        {

        }

        public void SaveHexcrawl()
        {

        }

        public void LoadHexcrawl()
        {

        }
    }
}
