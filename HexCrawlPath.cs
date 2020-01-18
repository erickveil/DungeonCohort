using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class HexCrawlPath
    {
        public string PathBranch = "";
        public string CurrentPathType = "";
        public string NewPathType = "";

        public HexCrawlLandmark LeftLandmark = null;
        public HexCrawlLandmark StraightLandmark = null;
        public HexCrawlLandmark RightLandmark = null;

        public void Init()
        {
            PathBranch = ChoosePathBranch();

            // Type of branching paths
            if (PathBranch.Contains("Fork")
                || PathBranch == "Cross")
            {
                NewPathType = ChoosePathType();
            }

            // Landmarks
            if (PathBranch == "Straight"
                || PathBranch == "Cross")
            {
                SetLandmark(ref StraightLandmark, CurrentPathType);
            }

            if (PathBranch == "Fork right" 
                || PathBranch == "Cross" )
            {
                SetLandmark(ref StraightLandmark, CurrentPathType);
                SetLandmark(ref RightLandmark, NewPathType);
            }

            if (PathBranch == "Fork left"
                || PathBranch == "Cross")
            {
                SetLandmark(ref StraightLandmark, CurrentPathType);
                SetLandmark(ref LeftLandmark, NewPathType);
            }

            if (PathBranch == "Turn right")
            {
                SetLandmark(ref RightLandmark, CurrentPathType);
            }

            if (PathBranch == "Turn left")
            {
                SetLandmark(ref LeftLandmark, CurrentPathType);
            }
        }

        public override string ToString()
        {
            string desc = CurrentPathType + " Route: " + PathBranch;
            if (NewPathType != "")
            {
                desc += "\nCrossing route: " + NewPathType;
            }

            if (!(StraightLandmark is null))
            {
                desc += "\nAhead: " + StraightLandmark.ToString();
            }

            if (!(LeftLandmark is null))
            {
                desc += "\nLeft: " + LeftLandmark.ToString();
            }
            
            if (!(RightLandmark is null))
            {
                desc += "\nRight: " + RightLandmark.ToString();
            }

            return desc;
        }

        public void SetLandmark(ref HexCrawlLandmark outLocation, string pathType)
        {
            var dice = Dice.Instance;

            if (pathType.Contains("Water"))
            {
                outLocation = new HexCrawlLandmark();
                outLocation.Init();
                outLocation.IsRuins = false;
                outLocation.LandmarkType = "Water";
                outLocation.Landmark = ChooseWaterwayFeature();
                outLocation.IsNatural = true;
            }

            else if (pathType.Contains("Landmark"))
            {
                outLocation = new HexCrawlLandmark();
                outLocation.Init();
            }

            else if (pathType == "Magical")
            {
                outLocation = new HexCrawlLandmark();
                outLocation.Init();
                outLocation.IsRuins = false;
                outLocation.LandmarkType = "Mystical";
                outLocation.Landmark = 
                    HexCrawlLandmark.ChooseMysticalLandmark();
                outLocation.IsNatural = true;
            }

            else if (pathType.Contains("Guide"))
            {
                outLocation = new HexCrawlLandmark();
                outLocation.Init();
            }

        }

        public static string ChoosePathBranch()
        {
            var table = new RandomTable<string>();

            table.AddItem("Straight", 4);
            table.AddItem("Turn right");
            table.AddItem("Turn left");
            table.AddItem("Fork right");
            table.AddItem("Fork left");
            table.AddItem("Cross");
            table.AddItem("End");

            return table.GetResult();
        }

        public static string ChoosePathType()
        {
            var table = new RandomTable<string>();

            table.AddItem("Trail: " + ChooseTrailType());
            table.AddItem("Waterway: " + ChooseWaterwayType());
            table.AddItem("Landmark Chain");
            table.AddItem("Magical");
            //table.AddItem("Wilderness Guide");

            return table.GetResult();
        }

        public static string ChooseTrailType()
        {
            var table = new RandomTable<string>();

            table.AddItem("Tracks - " + ChooseTracksType());
            table.AddItem("Animal run");
            table.AddItem("Infrequent trail");
            table.AddItem("Footpath");
            table.AddItem("Clear Trail");

            return table.GetResult();
        }

        public static string ChooseTracksType()
        {
            var table = new RandomTable<string>();

            table.AddItem("Distant sighting");
            table.AddItem("Sounds");
            table.AddItem("Body parts");
            table.AddItem("Victims");
            table.AddItem("Footprints");
            table.AddItem("Smells and vapors");
            table.AddItem("Environmental damage");
            table.AddItem("Intentional markings");
            table.AddItem("Scat/refuse");
            table.AddItem("Fur/Skin/Blood");

            return table.GetResult();
        }

        public static string ChooseWaterwayType()
        {
            var table = new RandomTable<string>();

            table.AddItem("Stream");
            table.AddItem("Brook");
            table.AddItem("Creek");
            table.AddItem("Tributary");

            return table.GetResult();
        }

        public static string ChooseWaterwayFeature()
        {
            var table = new RandomTable<string>();

            table.AddItem("Gentle");
            table.AddItem("Natural dam");
            table.AddItem("Spring");
            table.AddItem("Rapids");
            table.AddItem("Waterfall");
            table.AddItem("Pond");
            table.AddItem("Small lake");
            table.AddItem("Wier");
            table.AddItem("Constructed dam");

            return table.GetResult();
        }


        


    }
}
