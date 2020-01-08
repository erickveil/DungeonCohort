using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCohort
{
    class HexCrawlHex
    {
        public enum HexContentType
        {
            Empty, Encounter, EncouterWithTreasure, 
            Event, Obstacle, Feature, FeatureWithTreasure, Trick, 
            Settlement, BiomeSwitch
        };

        public enum TrailDirection
        {
            NoTrail, East, West, Northeast, Northwest, Southeast, Southwest
        };

        /// The biome type of the hex, will often remain unchanged through the
        /// crawl, and is set by the user at the beginning.
        public string Biome;
        /// A description of the immediate environment, ground cover, flora, etc
        public string Terrain;
        /// What is interesting about this area
        public HexCrawlContents Contents;
        /// Like Terrain, but a description of what this hex looks like from 
        /// an adjacent hex, to provide clues as to which way a party might 
        /// want to go next.
        /// Diferent aspects of the hex's contents can add a string to the list.
        /// For example, the Terrain suggests a distant tree line, but a fire
        /// event will add an entry about smoke.
        public List<string> DistantViewList = new List<string>();

        public int NavigationDC;

        // The Hex's position on a hexmap
        public int MapX;
        public int MapY;

        // Directions assume hexes have flat sides
        public bool RiverEast = false;
        public bool RiverWest = false;
        public bool RiverNorthEast = false;
        public bool RiverNorthWest = false;
        public bool RiverSouthEast = false;
        public bool RiverSouthWest = false;

        public bool TrailEast = false;
        public bool TrailWest = false;
        public bool TrailNorthWest = false;
        public bool TrailNorthEast = false;
        public bool TrailSouthWest = false;
        public bool TrailSouthEast = false;

        public void Init(string biome, int x, int y, int tier, 
            MagicItemPermissions allowedItems, TrailDirection trailEntersFrom)
        {
            SetBiome(biome);
            SetTerrain(Biome);
            HexContentType contentType = ChooseContentType();
            Contents = new HexCrawlContents();
            Contents.Init(contentType, tier, allowedItems);
            string severity = CrawlRoomTrap.ChooseSeverity();
            NavigationDC = CrawlRoomTrap.ChooseDc(severity);
            MapX = x;
            MapY = y;
            SetTrailRoutes(trailEntersFrom);

            SetDistantView();
        }

        public void SetTrailRoutes(TrailDirection trailEntersFrom)
        {

        }

        public void SetDistantView()
        {

        }

        public HexContentType ChooseContentType()
        {
            return HexContentType.Empty;

        }

        public void SetBiome(string biome)
        {

        }

        public void SetTerrain(string biome)
        {
        }
    }
}
