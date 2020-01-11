﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

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

        enum TrailRoute { 
            Straight, TurnRight, TurnLeft, Cross, BranchRight, BranchLeft, 
            DeadEnd
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
            MagicItemPermissions allowedItems, TrailDirection trailEntersFrom,
            bool isSettlementLeaderStdRace 
            )
        {
            SetBiome(biome);
            SetTerrain(Biome);
            HexContentType contentType = ChooseContentType();
            Contents = new HexCrawlContents();
            Contents.Init(contentType, tier, allowedItems, 
                isSettlementLeaderStdRace);
            string severity = CrawlRoomTrap.ChooseSeverity();
            NavigationDC = CrawlRoomTrap.ChooseDc(severity);
            MapX = x;
            MapY = y;
            SetTrailRoutes(trailEntersFrom);

            SetDistantView();
        }

        public void SetTrailRoutes(TrailDirection trailEntersFrom)
        {
            var dice = Dice.Instance;
            TrailRoute route = (TrailRoute)dice.RandomNumber(0, 6);
            switch (route)
            {
                case TrailRoute.BranchLeft:
                    switch (trailEntersFrom)
                    {
                        case TrailDirection.East:
                            TrailEast = true;
                            TrailSouthWest = true;
                            TrailWest = true;
                            break;
                        case TrailDirection.Northeast:
                            TrailNorthEast = true;
                            TrailSouthEast = true;
                            TrailSouthWest = true;
                            break;
                        case TrailDirection.Northwest:
                            TrailNorthWest = true;
                            TrailEast = true;
                            TrailSouthEast = true;
                            break;
                        case TrailDirection.NoTrail:
                            // TODO: find a trail?
                            break;
                        case TrailDirection.Southeast:
                            TrailSouthEast = true;
                            TrailWest = true;
                            TrailSouthWest = true;
                            break;
                        case TrailDirection.Southwest:
                            TrailSouthWest = true;
                            TrailNorthWest = true;
                            TrailNorthEast = true;
                            break;
                        case TrailDirection.West:
                            TrailWest = true;
                            TrailNorthEast = true;
                            TrailEast = true;
                            break;
                    } // switch (trailEntersFrom)
                    break;
                case TrailRoute.BranchRight:
                    switch (trailEntersFrom)
                    {
                        case TrailDirection.East:
                            TrailEast = true;
                            TrailNorthWest = true;
                            TrailWest = true;
                            break;
                        case TrailDirection.Northeast:
                            TrailNorthEast = true;
                            TrailSouthEast = true;
                            TrailSouthWest = true;
                            break;
                        case TrailDirection.Northwest:
                            TrailNorthWest = true;
                            TrailEast = true;
                            TrailSouthEast = true;
                            break;
                        case TrailDirection.NoTrail:
                            // Todo: find a trail?
                            break;
                        case TrailDirection.Southeast:
                            TrailSouthEast = true;
                            TrailWest = true;
                            TrailNorthWest = true;
                            break;
                        case TrailDirection.Southwest:
                            TrailSouthWest = true;
                            TrailNorthWest = true;
                            TrailNorthEast = true;
                            break;
                        case TrailDirection.West:
                            TrailWest = true;
                            TrailNorthEast = true;
                            TrailEast = true;
                            break;
                    } // switch (trailEntersFrom)
                    break;
                case TrailRoute.Cross:
                    switch (trailEntersFrom)
                    {
                        case TrailDirection.East:
                            TrailEast = true;
                            TrailNorthWest = true;
                            TrailSouthEast = true;
                            TrailWest = true;
                            break;
                        case TrailDirection.Northeast:
                            TrailNorthEast = true;
                            TrailSouthEast = true;
                            TrailNorthWest = true;
                            TrailSouthWest = true;
                            break;
                        case TrailDirection.Northwest:
                            TrailNorthWest = true;
                            TrailEast = true;
                            TrailWest = true;
                            TrailSouthEast = true;
                            break;
                        case TrailDirection.NoTrail:
                            // Todo: find a trail?
                            break;
                        case TrailDirection.Southeast:
                            TrailSouthEast = true;
                            TrailWest = true;
                            TrailEast = true;
                            TrailNorthWest = true;
                            break;
                        case TrailDirection.Southwest:
                            TrailSouthWest = true;
                            TrailNorthWest = true;
                            TrailSouthEast = true;
                            TrailNorthEast = true;
                            break;
                        case TrailDirection.West:
                            TrailWest = true;
                            TrailNorthEast = true;
                            TrailSouthWest = true;
                            TrailEast = true;
                            break;
                    } // switch (trailEntersFrom)
                    break;
                case TrailRoute.DeadEnd:
                    switch (trailEntersFrom)
                    {
                        case TrailDirection.East:
                            TrailEast = true;
                            break;
                        case TrailDirection.Northeast:
                            TrailNorthEast = true;
                            break;
                        case TrailDirection.Northwest:
                            TrailNorthWest = true;
                            break;
                        case TrailDirection.NoTrail:
                            break;
                        case TrailDirection.Southeast:
                            TrailSouthEast = true;
                            break;
                        case TrailDirection.Southwest:
                            TrailSouthWest = true;
                            break;
                        case TrailDirection.West:
                            TrailWest = true;
                            break;
                    } // switch (trailEntersFrom)
                    break;
                case TrailRoute.Straight:
                    switch (trailEntersFrom)
                    {
                        case TrailDirection.East:
                            TrailEast = true;
                            TrailWest = true;
                            break;
                        case TrailDirection.Northeast:
                            TrailNorthEast = true;
                            TrailSouthWest = true;
                            break;
                        case TrailDirection.Northwest:
                            TrailNorthWest = true;
                            TrailSouthEast = true;
                            break;
                        case TrailDirection.NoTrail:
                            // Todo: find a trail?
                            break;
                        case TrailDirection.Southeast:
                            TrailSouthEast = true;
                            TrailNorthWest = true;
                            break;
                        case TrailDirection.Southwest:
                            TrailSouthWest = true;
                            TrailNorthEast = true;
                            break;
                        case TrailDirection.West:
                            TrailWest = true;
                            TrailEast = true;
                            break;
                    } // switch (trailEntersFrom)
                    break;
                case TrailRoute.TurnLeft:
                    switch (trailEntersFrom)
                    {
                        case TrailDirection.East:
                            TrailEast = true;
                            TrailSouthWest = true;
                            break;
                        case TrailDirection.Northeast:
                            TrailNorthEast = true;
                            TrailSouthEast = true;
                            break;
                        case TrailDirection.Northwest:
                            TrailNorthWest = true;
                            TrailEast = true;
                            break;
                        case TrailDirection.NoTrail:
                            // TODO: find a trail?
                            break;
                        case TrailDirection.Southeast:
                            TrailSouthEast = true;
                            TrailWest = true;
                            break;
                        case TrailDirection.Southwest:
                            TrailSouthWest = true;
                            TrailNorthWest = true;
                            break;
                        case TrailDirection.West:
                            TrailWest = true;
                            TrailNorthEast = true;
                            break;
                    } // switch (trailEntersFrom)
                    break;
                case TrailRoute.TurnRight:
                    switch (trailEntersFrom)
                    {
                        case TrailDirection.East:
                            TrailEast = true;
                            TrailNorthWest = true;
                            break;
                        case TrailDirection.Northeast:
                            TrailNorthEast = true;
                            TrailSouthEast = true;
                            break;
                        case TrailDirection.Northwest:
                            TrailNorthWest = true;
                            TrailEast = true;
                            break;
                        case TrailDirection.NoTrail:
                            // Todo: find a trail?
                            break;
                        case TrailDirection.Southeast:
                            TrailSouthEast = true;
                            TrailWest = true;
                            break;
                        case TrailDirection.Southwest:
                            TrailSouthWest = true;
                            TrailNorthWest = true;
                            break;
                        case TrailDirection.West:
                            TrailWest = true;
                            TrailNorthEast = true;
                            break;
                    } // switch (trailEntersFrom)
                    break;
            } // switch (route)
        } // void SetTrailRoutes()

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
