using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class DungeonAtmosphere
    {
        public static  string GenerateAtmosphere()
        {
            string desc =
                ConstructionQuality() +
                ", constructed of " +
                ConstructionMaterial() + ", " +
                Integrity() + ", " +
                GeneralFeature();

            return desc;
        }
        public static string ConstructionMaterial()
        {
            var table = new RandomTable<string>();

            table.AddItem("Dirt or mud bricks");
            table.AddItem("Granite", 3);
            table.AddItem("Basalt");
            table.AddItem("Sandstone");
            table.AddItem("Clay");
            table.AddItem("Limestone");
            table.AddItem("Composite stone", 3);
            table.AddItem(SpecialConstructionMaterial());
            table.AddItem(ConstructionMetals());

            return table.GetResult();
        }

        public static string SpecialConstructionMaterial()
        {
            var table = new RandomTable<string>();

            table.AddItem("Crystaline surfaces");
            table.AddItem("Fused roots");
            table.AddItem("Organic, living material");
            table.AddItem("Necrotic, rotting material");

            return table.GetResult();
        }

        public static string ConstructionMetals()
        {
            var table = new RandomTable<string>();

            table.AddItem("Red, rusted iron slabs");
            table.AddItem("Blue-green copper patina");
            table.AddItem("Polished, brushed steel pannels");
            table.AddItem("Gold-worked polished silver");
            table.AddItem("Mirror-polished silver");
            table.AddItem("Alien, violet-hued metal");
            table.AddItem("Led-lined stone panels");

            return table.GetResult();
        }

        public static string ConstructionQuality()
        {
            var table = new RandomTable<string>();

            table.AddItem("Natural caves");
            table.AddItem("Tunnels, dug out with claws");
            table.AddItem("Rough, excavated tunnels");
            table.AddItem("Smoothed, solid surfaces");
            table.AddItem("Masoned bicks");
            table.AddItem("Large, masoned bricks");
            table.AddItem("Etched with abstract patterns - "
                               + ConstructionPatterns());
            table.AddItem("Etched with imagery depicting "
                   + ConstructionImagery());
            table.AddItem("Relief sculpted with imagery depicting "
                           + ConstructionImagery());
            table.AddItem("Murals - " + ConstructionImagery());
            table.AddItem("Etched with runes or text describing "
                           + ConstructionImagery());
            table.AddItem("Crude, primitive paintings depicting "
                           + ConstructionImagery());
            table.AddItem("Adorned with " + ConstructionAdornments() + " ("
                   + ConstructionImagery() + ")");
            table.AddItem(UnusualQuality());

            return table.GetResult();
        }

        public static string ConstructionPatterns()
        {
            var table = new RandomTable<string>();

            table.AddItem("Geometric");
            table.AddItem("Arcane");
            table.AddItem("Profane");
            table.AddItem("Religious");
            table.AddItem("Organic");
            table.AddItem("Filigree");
            table.AddItem("Natural");

            return table.GetResult();
        }

        public static string ConstructionImagery()
        {
            var table = new RandomTable<string>();

            table.AddItem("Regional history");
            table.AddItem("Local history");
            table.AddItem("Dungeon origins");
            table.AddItem("Dungeon usurpers");
            table.AddItem("Fictional");
            table.AddItem("Cultural");
            table.AddItem("A specific individual's story");
            table.AddItem("An adventuring party's tale");
            table.AddItem("An artifact or item");

            return table.GetResult();
        }

        public static string ConstructionAdornments()
        {
            var table = new RandomTable<string>();

            table.AddItem("Paintings");
            table.AddItem("Tapestries");
            table.AddItem("Rugs");
            table.AddItem("Statuary");

            return table.GetResult();
        }

        public static string UnusualQuality()
        {
            var table = new RandomTable<string>();

            table.AddItem("Smooth, rounded with no corners");
            table.AddItem("Hexagonal walls and archways");
            table.AddItem("Impossible, alien angles");

            return table.GetResult();
        }

        public static string Integrity()
        {
            var table = new RandomTable<string>();

            table.AddItem("Sound construction", 4);
            table.AddItem("Unstable, rumbling");

            return table.GetResult();
        }

        public static string GeneralFeature()
        {
            var table = new RandomTable<string>();

            table.AddItem("Unremarkable atmosphere", 4);
            table.AddItem("Mildly dusty air", 2);
            table.AddItem("Choked with dust");
            table.AddItem("Choked with cobwebs");
            table.AddItem("Foul-smelling air", 2);
            table.AddItem("Irritating, chemical atmosphere");
            table.AddItem("Mist along the floor");
            table.AddItem("Smoke along the ceiling");
            table.AddItem("Blackened with soot upon the surfaces");
            table.AddItem("Inpenetrable darkness (all visual distances halved)");
            table.AddItem("Sweet smelling airs");
            table.AddItem("The scent of incense hangs in ther air");
            table.AddItem("Permeated with the scent of death");
            table.AddItem("Musty, moldy");
            table.AddItem("Damp and dripping");
            table.AddItem("Dry and parching");
            table.AddItem("Oderus: " + ChamberOdor(), 2);
            table.AddItem("Your hair stands on end");
            table.AddItem("There is a distant, dull hum");
            table.AddItem("Hot, like a sauna");
            table.AddItem("Chilly, you can see your breath");
            table.AddItem("Slick, slippery floors, and walls");
            table.AddItem("Mushrooms grow from the dark corners");
            table.AddItem("The air sparkles with points of light, like tiny stars");
            table.AddItem("A thin layer of slime covers everything");
            table.AddItem("Roots tangle accross the floor and hang from the ceiling");
            table.AddItem("Filled with an obscuring mist (all visual distances halved)");
            table.AddItem("Filled with a poisonous gas (poisoned effect within, and for 1d4 hours after)");
            table.AddItem("Submerged");
            table.AddItem("The air is choked with dust");
            table.AddItem("Dull, yellow light emenates from ceiling pannel");
            table.AddItem("Crawling with small insects");

            return table.GetResult();
        }

        public static string ChamberOdor()
        {
            var table = new RandomTable<string>();

            table.AddItem("Acrid");
            table.AddItem("Chlorine");
            table.AddItem("Dank or moldy");
            table.AddItem("Earthy");
            table.AddItem("Manure");
            table.AddItem("Metallic");
            table.AddItem("Ozone");
            table.AddItem("Putrid");
            table.AddItem("Rotting vegetation");
            table.AddItem("Salty and wet");
            table.AddItem("Smoky");
            table.AddItem("Stale");
            table.AddItem("Sulfurous");
            table.AddItem("Urine");

            return table.GetResult();

        }
    }
}
