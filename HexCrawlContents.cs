using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class HexCrawlContents
    {
        Encounter HexEncounter;
        string HexEvent;
        string HexObstacle;
        string HexFeature;
        LootTableResult HexTreasure;
        HexCrawlTrick HexTrick;
        HexCrawlSettlement HexSettlement;

        public override string ToString()
        {
            return base.ToString();
        }

        public void Init(HexCrawlHex.HexContentType contentType)
        {
            switch(contentType)
            {
                case HexCrawlHex.HexContentType.Empty:
                    break;
                case HexCrawlHex.HexContentType.Encounter:
                    SetEncounter();
                    break;
                case HexCrawlHex.HexContentType.EncouterWithTreasure:
                    SetEncounter();
                    SetTreasure();
                    break;
                case HexCrawlHex.HexContentType.Event:
                    SetEvent();
                    break;
                case HexCrawlHex.HexContentType.Feature:
                    SetFeature();
                    break;
                case HexCrawlHex.HexContentType.FeatureWithTreasure:
                    SetFeature();
                    SetTreasure();
                    break;
                case HexCrawlHex.HexContentType.Obstacle:
                    SetObstacle();
                    break;
                case HexCrawlHex.HexContentType.Settlement:
                    SetSettlement();
                    break;
                case HexCrawlHex.HexContentType.Trick:
                    SetTrick();
                    break;
                default:
                    break;
            }
        }

        public void SetEncounter()
        {

        }

        public void SetEvent()
        {
            var table = new RandomTable<string>();

            // TODO: chance of quest or reaction?
            // TODO: how to set border descriptions for events like fire?
            table.AddItem("Ongoing battle");
            table.AddItem("Wilderness fire");
            table.AddItem("Funeral Procession");
            table.AddItem("Merchant Caravan");
            table.AddItem("Marching Army");
            table.AddItem("An obscuring fog settles on the area");
            table.AddItem("");

            HexEvent = table.GetResult();

        }

        public void SetObstacle()
        {

        }

        public void SetFeature()
        {

        }

        public void SetTreasure()
        {

        }

        public void SetTrick()
        {
            HexTrick = new HexCrawlTrick();
            HexTrick.Init();
        }

        public void SetSettlement()
        {
            HexSettlement = new HexCrawlSettlement();
            HexSettlement.Init();
        }
    }
}
