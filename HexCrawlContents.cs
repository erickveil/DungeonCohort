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
        public HexCrawlHex.HexContentType ContentType;
        public string EncounterDifficulty = "";
        public DualDescription HexEvent;
        public DualDescription HexObstacle;
        public DualDescription HexFeature;
        public LootTableResult HexTreasure;
        public HexCrawlTrick HexTrick;
        public HexCrawlSettlement HexSettlement;

        public override string ToString()
        {
            return base.ToString();
        }

        public void Init(HexCrawlHex.HexContentType contentType, int tier, 
            MagicItemPermissions allowedItems)
        {
            ContentType = contentType;
            switch(contentType)
            {
                case HexCrawlHex.HexContentType.Empty:
                    break;
                case HexCrawlHex.HexContentType.Encounter:
                    SetEncounter();
                    break;
                case HexCrawlHex.HexContentType.EncouterWithTreasure:
                    SetEncounter();
                    SetTreasure(tier, allowedItems);
                    break;
                case HexCrawlHex.HexContentType.Event:
                    SetEvent();
                    break;
                case HexCrawlHex.HexContentType.Feature:
                    SetFeature();
                    break;
                case HexCrawlHex.HexContentType.FeatureWithTreasure:
                    SetFeature();
                    SetTreasure(tier, allowedItems);
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
            EncounterDifficulty = CrawlRoomContents.GetRandomDifficulty();
        }

        public void SetEvent()
        {
            var table = new RandomTable<DualDescription>();

            // TODO: chance of quest or reaction?

            string severity = CrawlRoomTrap.ChooseSeverity();
            int dc = CrawlRoomTrap.ChooseDc(severity);
            string investigation = " (DC " + dc + " Investiagation)";

            table.AddItem(new DualDescription() { 
                Near = "Ongoing battle", 
                Far = "Plumes of smoke rise up and the distant sound of battle" 
            });
            table.AddItem(new DualDescription() { 
                Near = "Wilderness fire", 
                Far = "A great column of smoke rises" 
            });
            table.AddItem(new DualDescription() { 
                Near = "Funeral procession", 
                Far = "Tracks showing several humanoids in a disordered " +
                "column" + investigation 
            });
            table.AddItem(new DualDescription() { 
                Near = "Merchant caravan", 
                Far = "Tracks of several pack animals and wagons" + 
                investigation 
            });
            table.AddItem(new DualDescription() { 
                Near = "Marching army", 
                Far = "Tracks of an army column marching" + investigation 
            });
            table.AddItem(new DualDescription() { 
                Near = "An obscuring fog settles on the area", 
                Far = "A fog is rolling in" 
            });
            table.AddItem(new DualDescription() { 
                Near = "NPC party camp", 
                Far = "A thin trail of smoke rises" 
            });
            table.AddItem(new DualDescription() { 
                Near = "Recently abandoned campsite", 
                Far = "The faint smell of a recent campfire" + investigation
            });
            table.AddItem(new DualDescription() { 
                Near = "A single NPC in one-on-one battle with a single " +
                "opponent", 
                Far = "The distant clash of arms" + investigation 
            });
            table.AddItem(new DualDescription() { 
                Near = "An NPC with a quest for the party", 
                Far = "Humanoid tracks lead in this direction" 
            });

            //table.AddItem(new DualDescription() { Near = "", Far = "" });

            HexEvent = table.GetResult();


        }

        public void SetObstacle()
        {
            var table = new RandomTable<DualDescription>();

            string severity = CrawlRoomTrap.ChooseSeverity();
            int dc = CrawlRoomTrap.ChooseDc(severity);
            string investigation = " (DC " + dc + " Investiagation)";

            table.AddItem(new DualDescription() { 
                Near = "A cliff rises up", 
                Far = "A cliff face overlooks this land in the distance" 
            });
            table.AddItem(new DualDescription() { 
                Near = "A sheer drop down a cliff to the landscape below", 
                Far = "Normally high-flying birds can be seen flying " +
                "lower this way" + investigation 
            });
            table.AddItem(new DualDescription() { 
                Near = "An unbridged chasm", 
                Far = "A barely perceptible echo of your voices from " +
                "this way" + investigation
            });
            table.AddItem(new DualDescription() { 
                Near = "A rushing, deep river", 
                Far = "A small stream runs down this way" + investigation
            });
            table.AddItem(new DualDescription() { 
                Near = "A lava flow", 
                Far = "The smell of sulfur from this way" + investigation 
            });
            table.AddItem(new DualDescription() { 
                Near = "A wide growth of Razorvine", 
                Far = "The tracks of local fauna go every way but " +
                "this one" + investigation 
            });
            table.AddItem(new DualDescription() { 
                Near = "A group of bandits, burying a box", 
                Far = "Tracks of a small group of humanoids" + investigation 
            });

            //table.AddItem(new DualDescription() { Near = "", Far = "" });

            HexObstacle = table.GetResult();
        }

        public void SetFeature()
        {
            var table = new RandomTable<DualDescription>();

            string severity = CrawlRoomTrap.ChooseSeverity();
            int dc = CrawlRoomTrap.ChooseDc(severity);
            string investigation = " (DC " + dc + " Investiagation)";
            var dice = Dice.Instance;
            bool isRuined = dice.Roll(1, 6) <= 3;
            string ruin = isRuined ? "Ruined " : "";
            string remoteStructure = isRuined 
                ? "" 
                : "A thin trail of smoke rises";
            string remoteSettlement = isRuined 
                ? "" 
                : "A wide, worn path, recently used, leads this way";

            table.AddItem(new DualDescription() { 
                Near = HexCrawlTrick.ChooseFeature(), 
                Far = "" 
            }, 4);
            table.AddItem(new DualDescription() { 
                Near = ruin + "Cottage", 
                Far = remoteStructure
            });
            table.AddItem(new DualDescription() { 
                Near = ruin + "Hovel", 
                Far = remoteStructure
            });
            table.AddItem(new DualDescription() { 
                Near = ruin + "Farm", 
                Far = remoteStructure
            });
            table.AddItem(new DualDescription() { 
                Near = ruin + "Village", 
                Far = remoteSettlement
            });
            table.AddItem(new DualDescription() { 
                Near = ruin + "Mill", 
                Far = remoteStructure
            });
            table.AddItem(new DualDescription() { 
                Near = ruin + "Inn", 
                Far = remoteSettlement
            });
            table.AddItem(new DualDescription() { 
                Near = ruin + "Trading post", 
                Far = remoteSettlement 
            });
            table.AddItem(new DualDescription() { 
                Near = "Graveyard", 
                Far = "" 
            });

            // table.AddItem(new DualDescription() { Near = "", Far = "" });

            HexFeature = table.GetResult();

        }

        public void SetTreasure(int tier, MagicItemPermissions allowedItems)
        {
            var treasureGen = new TreasureFactory();
            var dice = Dice.Instance;
            bool isHoard = dice.Roll(1, 6) == 6;
            if (isHoard)
            {
                HexTreasure = treasureGen.GetTreasureHoard(tier, allowedItems);
            }
            else
            {
                HexTreasure = treasureGen.GetIndividualTreasure(tier);
            }
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
