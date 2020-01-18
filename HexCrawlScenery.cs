using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class HexCrawlScenery
    {
        public string Scenery;

        public void Init(string biome)
        {
            switch (biome)
            {
                case "Plains":
                    Scenery = ChoosePlainsScenery();
                    break;
                case "Mountains":
                    Scenery = ChooseMountainScenery();
                    break;
                case "Forest":
                    Scenery = ChooseForestScenery();
                    break;
                default:
                    Scenery = ChooseUniversalScenery();
                    break;
            }
        }

        public override string ToString()
        {
            return Scenery;
        }

        public static string ChooseForestScenery()
        {
            var table = new RandomTable<string>();

            table.AddItem("Deciduous trees give way to a clearing, where thick pines " +
                  "take up the forrest on the other side.");
            table.AddItem("The tree canopy makes way for a rare view of the sky.");
            table.AddItem("Tall, thick-trunked trees with peeling bark straddle " +
                           "either side of a puddle-riddled path.");
            table.AddItem("Grassy undergrowth covers the forest floor with clusters of " +
                           "ferns and wads of brambles.");
            table.AddItem("A clearing makes way, and in its center stands a solitary " +
                           "archway. A cold, unused firepit was dug at its base a " +
                           "long time ago.");
            table.AddItem("Cold mountains of stone rise up on either side asn the " +
                           "forest collects in the valley between them, " +
                           "the trees impenitrable through their canopy.");
            table.AddItem(ChooseUniversalScenery(), 16);

            return table.GetResult();
        }

        public static string ChoosePlainsScenery()
        {
            var table = new RandomTable<string>();

            table.AddItem("An endless field of short grass over a flat landscape, punctuated by tall, grey boulders");
            table.AddItem("Grass so tall that even a human can't see over it");
            table.AddItem("Sparce grass over a russet, dirt field, littered wth rocks and a few shrubs");
            table.AddItem("A large, granite rock formation juts out of the landscape and must be circumvented");
            table.AddItem("Streams crisscross the area");
            table.AddItem("An unmapped, shallow river crosses the party's path");
            table.AddItem("The landscape is interrupted by a wide chasm, spanned by an old, crumbling stone bridge");
            table.AddItem("The way leads tha party down the bottom of a wide chasm");
            table.AddItem("The landscape rises up 10-20 feet up rocky cliffs on either side of the party's path");
            table.AddItem("The landscape drops and the party must climb down a 1-200 foot cliff to the plains below");
            table.AddItem("Many copese of trees, little clusters dot the landscape");
            table.AddItem("The way is sparsely cluttered with thin trees");
            table.AddItem("The way takes the party through a small wood");
            table.AddItem("The way passes through a small, thick wood");
            table.AddItem("The party follows a babling brook for a while");
            table.AddItem("Ruddy red soil contrasts bright green foliage for the whole watch");
            table.AddItem("The ground softens, and eventually gives way to shallow water, out of which the tall grass grows");
            table.AddItem("The party must circumvent a small lake");
            table.AddItem("Old, abandoned farmlands, the old properties edged by short, knee-high walls of piled stone");
            table.AddItem("The party passes a distant, abandoned farmnouse, overgown with weeds and dirt");
            table.AddItem("A crumbled ruins of a barn");
            table.AddItem("The grasslands are broken up by gently rolling hills");
            table.AddItem("The land for this watch grows hard and cracked");
            table.AddItem("A stiff breeze blows in from the west");
            table.AddItem("A mist clings to the ground about the party's feet");
            table.AddItem("An obscuring fog makes progress difficult");
            table.AddItem("Light seasonal percipitaton");
            table.AddItem("A torrential downpour drenches the party for the duration of this watch");
            table.AddItem("Moisture clings to the grass in this region, soaking through everybody's boots and making the cuffs of everyone's trousers uncomfortably wet");
            table.AddItem("A field of wildflowers");
            table.AddItem("Field rats plague this region");
            table.AddItem("Creeper tangles the ground about the party's feet");
            table.AddItem("A gusty gale opposes the party the whole watch");
            table.AddItem("A strong wind presses at the party's backs");
            table.AddItem("A lone scarecrow is passed along the way");
            table.AddItem("A mesa blocks the party's path and must be circumvented");
            table.AddItem("The area is dotted with the scattered ruins of an ancient culture. Only chunks of weathered masonry remains");
            table.AddItem("The party passes through a region of ash, where a grassfire has recently burned down all of the vegetation.");
            table.AddItem("A pile of busted and weathered wooden lumber is all that denotes the location of some sort of ruined building");
            table.AddItem("A wide field of tree stumps where a forrest once stood");
            table.AddItem("Saplings are sprouted up all over, as if a new forrest were growing in this area");
            table.AddItem("A large orderly farm field grows here, but with no sign of a farmhouse or any farmers");
            table.AddItem("The region is full of charred stumps of trees. This was once a forrest that has recentl burned down");
            table.AddItem("An old wooden bridge crossing over nothing");
            table.AddItem("A rickety old bridge spans a chasm");
            table.AddItem("A covered bridge spans a small river");
            table.AddItem("A small pond populated by ducks and koi");
            table.AddItem("The land gives way to a desolate moor.");
            table.AddItem("Patches of short, stumpy grass cluster about the shallow " +
                           "pools of water in the otherwise flat and muddy landscape");
            table.AddItem("Colorless stones cluster about the short grass in these " +
                           "rolling hills.");
            table.AddItem("Rows of taller grass crisscross the shorter grass as it " +
                           "seems the whole land is tilted in one direction.");
            table.AddItem("The foot of a small mountain rises sharply out of the " +
                           "landscape ahead.");
            table.AddItem("The flat, wattery land reflects the sky, broken up by " +
                           "ancient stone  arches made from age-worn masonry. Relief " +
                           "statues that once adorned them have been weather beaten " +
                           "into vaguely humanoid shapes.");
            table.AddItem("Thick, rolling clouds gather overhead, more massive than " +
                           "any mountain range. They grow dark near the horison, where " +
                           "you can see distant rainfall.");
            table.AddItem("A muddy trail cuts throug waist-high grass. A single " +
                           "cyprus stands from the field ahead, and a cluster of " +
                           "shorter trees gathers in the distance to one side.");
            table.AddItem("The flat landscape gives way to a wide treeline, near the " +
                           "horizion.");
            table.AddItem("As you crest a hill, you get a breathtaking view, high " +
                           "over the flat land that stretches seemingly forever beyond.");
            table.AddItem("Flat, grassy land is broken up by great plateaus that rise," +
                           "scattered about until the horizon.");
            table.AddItem(ChooseUniversalScenery(), 16);

            return table.GetResult();
        }

        public static string ChooseMountainScenery()
        {
            var table = new RandomTable<string>();

            table.AddItem("Had to make their way accross a ledge on the side of a sheer cliff.");
            table.AddItem("An ice bridge spans a chasm.");
            table.AddItem("An ancient, stone bridge spanning a chasm.");
            table.AddItem("The ruined shell of some ancient structure, surrounded by crumbling columns");
            table.AddItem("A tangled maze of old, not-maintained trails that required a lot of backtracking.");
            table.AddItem("Climbing hand over hand up a steep incline was required.");
            table.AddItem("Scrambling over loose gravel and rocks that provide precarious footing.");
            table.AddItem("Intermittent rumblings and minor earthquakes.");
            table.AddItem("Various tiny caves that are homes to small animals such as lizards or birds.");
            table.AddItem("Sparce shrubbery, some of which have red berries");
            table.AddItem("A wooded area of the mountainside");
            table.AddItem("An old trail winds up the mountainside");
            table.AddItem("Have to scramble around large outcroppings of rocks and boulders");
            table.AddItem("A heavy gale blows over the landscape, directly against the directoin of travel");
            table.AddItem("A heavy wind blows at the party's backs the whole way, until they round an outcropping of rock");
            table.AddItem("A large overhang shileds the party from the sky as they pass this way");
            table.AddItem("A wide ledge winds around the edge of a long, sheer cliff");
            table.AddItem("A high cliff blocks the way with sparse footholds for climbing");
            table.AddItem("A rope bridge sways precariously in the wind");
            table.AddItem("A fallen tree crosses a shallow ravine");
            table.AddItem("A flock of mountain goats crosses the party's path");
            table.AddItem("The way plateaus and a herd of aurochs lounge about, munching the sparse grass");
            table.AddItem("A sparse wood of thin trees dot the sloped mountainside");
            table.AddItem("A pass through steep inclines on either side");
            table.AddItem("The party crosses a ride, climbing up one side and down the other");
            table.AddItem("The party crosses several short riges that require climbing up one and down the other, over and over");
            table.AddItem("The party traverses the length of a long, high ridge");
            table.AddItem("The way goes throug a tunnel that's more of a crack in the mountainside");
            table.AddItem("The way goes through the bottom of a deep chasm.");
            table.AddItem("A path moves along one side of a chasm, crosses a stone bridge to the otherside, and continues");
            table.AddItem("Rough carved steps wind up the side of a cliff");
            table.AddItem("A whiteout blizzard or heavy storm cuts vision down to nothing");
            table.AddItem("Frequent small stones continuously fall from the higher ground, occasionally striking a character");
            table.AddItem("Buzzards circle overhead the entire time the party travels this route");
            table.AddItem("The party comes accross the frozen body of a human dressed in rags");
            table.AddItem("Little lizzards scurry out of the path of the party as it crosses this area");
            table.AddItem("The party reaches a ledge that provides a breathtaking view of the lowlands beyond the mountain");
            table.AddItem("The party ascends into a cloud, and wanders in " +
                "circles for a while before proceeding");
            table.AddItem("A wind kicks up dust and many small, rocks, " +
                "abrassively whipping against the party for a while.");
            table.AddItem("The party follows a mountain stream for a way");
            table.AddItem("A waterfall pours down a cliff and into a " +
                "small lake before emptying down the mountain.");
            table.AddItem("The party climbs to a plateau that is shaped " +
                "like a bowl. Many mountain streams empty into a " +
                "small lake, and the skeleton of an old wall looms at the " +
                "far side.");
            table.AddItem("Cliffs drop thousands of feet on either side");
            table.AddItem("A sheer drop falls thousands of feet to one side, and the " +
                           "sky is blotted out by the overhanging mountain above as " +
                           "you make your way along a great notch, etched into its " +
                           "side.");
            table.AddItem("Squat shrubs collect around the bases of boulders that are " + 
                           "so frequent that you have to wind your way around them.");
            table.AddItem("Massive spires of moss-covered stone jut from the land, with " +
                           "a fog that rolls between them, leaving just the vegetation-" +
                           "speckeled tops visible.");
            table.AddItem(ChooseUniversalScenery(), 16);

            return table.GetResult();
        }

        public static string ChooseUniversalScenery()
        {
            var table = new RandomTable<string>();

            table.AddItem("The shores of a lake lap at the bottoms of hills that " +
                          "rise into great rock formations with gaps between them.");
            table.AddItem("Weathered stone steps, overgrown with grass and moss, " +
                           "rise a low, circular mound. At its top is a circle of " +
                           "standing stones, arranged around a crumbling crypt.");
            table.AddItem("Cresting a rise in the landscape, beyond stand two sharp " +
                           "peaks of stone piercing from the ground and bare of " +
                           "any vegetation.");
            table.AddItem("Rough stone peaks serrate the landscape ahead.");
            table.AddItem("The ground before you grows hard as the soil gives way to " +
                           "bare stone. Shallow puddles of water dot the gray rock.");
            table.AddItem("The land before you drops suddeny, a cliff straight down " +
                           "100 feet into a steep hill that drops away from you.");
            table.AddItem("You pass through the bottom of a deep chasm, barely 50 " + 
                           "feet wide and dark. Ancient and broken columns cluster " +
                           "allong the " +
                           "natural walls, and crumbled stairways of elder stone " +
                           "rise a few feet and break off, leading nowhere.");
            table.AddItem("Spires of stone just from the landscape like great, " +
                           "jagged stelagmites. Nooks on their surfaces glow with what " +
                           "look like torchlight in the dark, though it is just a " +
                           "lichen.");
            table.AddItem("Tall trees blot out the sun, their canopies far overhead.");
            table.AddItem("A sullen fog darkens the trees ahead and a strange silence " +
                           "hangs over the land.");
            table.AddItem("Trees with great roots that pull the earth up in mounds " + 
                           "at their bases, eliminating any flatness this land may " +
                           "have once had.");
            table.AddItem("Strange, blocky columns rise hundreds of feet into the " +
                           "air. Thirty feet to a side, their bases have been carved " +
                           "away like a tree that has been chopped at and abandoned");
            table.AddItem("The land rises up on either side as your way takes you " +
                           "into a narrow valley, barely wide enough for two horses " +
                           "side by side");
            table.AddItem("The muddy land is criss-crossed in a confusion of hoof " +
                           "prints");
            table.AddItem("A narrow vale is cluttered with bones and broken spears. " +
                           "An army was trapped and slaughtered here, long ago.");
            table.AddItem("The trees make way, like a dungeon exit that leads to a " +
                           "narrow valley with sharp rising hills on either side, " +
                           "so thin that mounted riders would have to pass single " +
                           "file.");
            table.AddItem("A stream empties from a nearby lake, flowing past you");
            table.AddItem("The wooden, skeletal ruins of a small town lie ahead");
            table.AddItem("Steep hills, covered in pines, rise up far ahead in the " +
                           "distance, and the path you are on appears to lead between " +
                           "two of them.");
            table.AddItem("A river winds lazily along your path ahead, wide with " +
                           "islands, and tall hills rise up on either side of it, " +
                           "the vale choked with trees.");
            table.AddItem("The trail ends at an old, rickety dock that juts out over " +
                           "a wide field of mud until it reaches its crumbled end.");
            table.AddItem("The trail leads into a damp, muddy land. Wooden posts have " +
                           "been laid down, side by side and sunken into the mire to " +
                           "provide a solid continuation of the path.");
            table.AddItem("The land drops steeply away, revealing a wide, shallow " +
                           "vale below and a great open sky above");
            table.AddItem("The land stops at an overhang and drops thousands of feet " +
                           "below. The wooded vale below rises up again in the " +
                           "distance into sharp, jagged peaks of bare stone.");
            table.AddItem("The fog does little to obscure a massive, looming mountain " +
                           "ahead.");
            table.AddItem("The trail wraps around the crest of a hill that falls " +
                           "sharply to one side. Shielded from the sky by a great oak, " +
                           "you can see a forrested mountain rise up from the bottom " +
                           "of the hillside.");
            table.AddItem("A great wall once divided this land, but now it is mostly " +
                           "a crumbled ruin, with wide gaps and toppled masonry.");
            table.AddItem("What looks to be the formidable stone gates to an ancient " +
                           "dungeon loom before you, but as your path takes you around " +
                           "them, you can see that is all that is left, the dungeon " +
                           "itslef is collapesd, its rubble long ago overgrown. Only " +
                           "the doors still stand.");
            table.AddItem("Rolling hills, topped with large, smoth boulders that have " +
                           "made way for the growth of old trees");
            table.AddItem("A great cliff stands to one side, and the roar of a " +
                           "waterfall feeds the river below. The trail leads to a " +
                           "fallen log that bridges the river, a few hundred feet up.");
            table.AddItem("The land dissappears into a great sinkhole, wider around " +
                           "than a city. At the far end, a wide river empties into it " +
                           "and birds circle overhead.");
            table.AddItem("The world gives way to great, mountainous masses of stone " +
                           "with wide, sloping bases with sharp, vertical peaks, like " +
                           "massive, natural columns that have been broken off at their " +
                           "bases.");
            table.AddItem("The stone shell of a great keep sits against a cliff-face, " +
                           "far off in the distance ahead. Just the outer wall stands, " +
                           "open to the sky and protecting only the dirt.");

            return table.GetResult();
        }
    }
}
