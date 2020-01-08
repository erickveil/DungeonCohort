using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class HexCrawlTrick
    {
        public string TrickFeature;
        public string TrickEffect;

        public override string ToString()
        {
            return TrickFeature + ": " + TrickEffect;
        }

        public void Init()
        {
            SetFeature();
            SetEffect();
        }

        public static string ChooseFeature()
        {
            var table = new RandomTable<string>();
            string liquid = CrawlRoomTrick.ChoosePoolLiquid();

            table.AddItem("Ring of toadstools");
            table.AddItem("Ring of standing stones");
            table.AddItem("Godstone");
            table.AddItem("Menhir");
            table.AddItem("Large growth of crystal");
            table.AddItem("Gravestone");
            table.AddItem("Giant tree");
            table.AddItem("Altar");
            table.AddItem("Pool: " + liquid);
            table.AddItem("Fountain: " + liquid);
            table.AddItem("Old Well");
            table.AddItem("Statue");
            table.AddItem("Giant Statue");
            table.AddItem("Great Crystal");
            table.AddItem("Throne");
            table.AddItem("Giant mushroom");
            table.AddItem("Skull");
            table.AddItem("Sphere of magical energy");
            table.AddItem("Stone obelisk");
            table.AddItem("Anvil");
            table.AddItem("Pedestal");
            table.AddItem("Tomb");
            table.AddItem("Stone Bowl");
            table.AddItem("Circle where nothing grows");
            table.AddItem("Bare foundation");
            table.AddItem("Natural spring");
            table.AddItem("Large, floating eye");
            table.AddItem("Marbel pedestal");
            table.AddItem("Drooping plant bearing a single, red fruit");
            table.AddItem("Dome of strange glass");
            table.AddItem("Small, strane symbols made from twigs hanging " +
                "from trees");
            table.AddItem("Giant skeleton");
            table.AddItem("Several dead travelers, bearing no marks");
            table.AddItem("Skeleton laying against a tree, with an arrow " +
                "in its ribcage");
            table.AddItem("Floating, disconnected bones of a single skeleton");
            table.AddItem("Pillar of light");
            table.AddItem("Abandoned chest, filled with human bones");
            table.AddItem("Open grave");
            return table.GetResult();
        }

        public void SetFeature()
        {
            var dice = Dice.Instance;
            bool isUnusual = dice.Roll(1, 6) <= 2;
            if (isUnusual)
            {
                TrickFeature = Descriptors.UnusualObjectDescriptor() + " "
                    + ChooseFeature();
            }
            else
            {
                TrickFeature = ChooseFeature();
            }
        }

        public void SetEffect()
        {
            TrickEffect = CrawlRoomTrick.ChooseTrickEffect();
        }
    }
}
