using System;
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
            Empty, Event, Feature, Trick, EventAndFeature
        };

        public HexCrawlPath Route;
        public HexCrawlScenery Scenery;
        public HexContentType Contents;

        public HexCrawlLandmark Landmark;
        public HexCrawlEvent Event;
        public HexCrawlTrick Trick;

        public void Init(string biome, string currentPathType)
        {
            Route = new HexCrawlPath();
            Route.CurrentPathType = currentPathType;
            Route.Init();

            Scenery = new HexCrawlScenery();
            Scenery.Init(biome);

            Contents = ChooseHexContentType();

            if (Contents == HexContentType.Feature)
            {
                Landmark = new HexCrawlLandmark();
                Landmark.Init();
            }

            if (Contents == HexContentType.Event)
            {
                Event = new HexCrawlEvent();
                Event.Init();
            }

            if (Contents == HexContentType.Trick)
            {
                Trick = new HexCrawlTrick();
                Trick.Init();
            }

            if (Contents == HexContentType.EventAndFeature)
            {
                Event = new HexCrawlEvent();
                Event.Init();
                Landmark = new HexCrawlLandmark();
                Landmark.Init();
            }

        }

        public override string ToString()
        {
            string desc =
                "Route: " + Route.ToString() + "\n" 
                + "Scenery: " + Scenery.ToString() + "\n" 
                + "Contents: " + Contents.ToString() + "\n";

            if (!(Landmark is null))
            {
                desc += "Local Landmark: " + Landmark.ToString() + "\n";
            }

            if (!(Event is null))
            {
                desc += Event.ToString() + "\n";
            }

            if (!(Trick is null))
            {
                desc += Trick.ToString() + "\n";
            }

            return desc;
        }

        public HexContentType ChooseHexContentType()
        {
            var table = new RandomTable<HexContentType>();

            if (Route.PathBranch == "End")
            {
                table.AddItem(HexContentType.Feature);
                table.AddItem(HexContentType.Trick);
                table.AddItem(HexContentType.EventAndFeature, 2);
            }
            else if (Route.PathBranch == "Straight")
            {
                table.AddItem(HexContentType.Empty);
                table.AddItem(HexContentType.Feature, 2);
                table.AddItem(HexContentType.Event, 4);
                table.AddItem(HexContentType.Trick, 2);
                table.AddItem(HexContentType.EventAndFeature);
            }
            else
            {
                table.AddItem(HexContentType.Feature, 2);
                table.AddItem(HexContentType.Event, 4);
                table.AddItem(HexContentType.Trick, 2);
                table.AddItem(HexContentType.EventAndFeature);
            }

            return table.GetResult();
        }
    }
}
