using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class CrawlRoomFeature
    {
        public string Descriptor = "";

        public void Init()
        {
            var table = new RandomTable<string>();

            table.AddItem("", 80);
            table.AddItem("Flooded");
            table.AddItem("Cobwebed");
            table.AddItem("Cracked");
            table.AddItem("Dripping");
            table.AddItem("Damp");
            table.AddItem("Bloody");
            table.AddItem("Dung-covered");
            table.AddItem("Dusty");
            table.AddItem("Fungal");
            table.AddItem("Moldy");
            table.AddItem("Leaf-strewn");
            table.AddItem("Straw-covered");
            table.AddItem("Scratched up");
            table.AddItem("Emptyh");
            table.AddItem("Cussioned");
            table.AddItem("Painted");
            table.AddItem("Steamy");
            table.AddItem("Frosty");
            table.AddItem("Flowery");
            table.AddItem("Musty");
            table.AddItem("Copper pipe");
            table.AddItem("Greed-fluid Dripping Stone Pipe");
            table.AddItem("Stone Wheel");
            table.AddItem("Flower Box");
            table.AddItem("Natural Spring with Glowing Mushrooms");
            table.AddItem("Rose-quartz Outcroppings");
            table.AddItem("Alcove of Wooden Mugs");
            table.AddItem("Giant Red X");
            table.AddItem("'Chog loves Jessica'");
            table.AddItem("Windows painted on the wall");
            table.AddItem("Skeleton of a small dog");
            table.AddItem("Pale White Pine tree");
            table.AddItem("Skeleton of a monkey with it's hand in a jar");
            table.AddItem("Brass Lever");
            table.AddItem("The Broken Mirror");
            table.AddItem("Creepy Black Candle Chandelier");
            table.AddItem("Brass Hookah");
            table.AddItem("Massive Gong");
            table.AddItem("Bloody Footprints");
            table.AddItem("Large Buckets of Smashed Grapes");
            table.AddItem("Bloated, Pale Vines");
            table.AddItem("Eyes in a Jar");
            table.AddItem("Sword Embedded in the Stone Floor");
            table.AddItem("Vineger-filled Water Clock");
            table.AddItem("The Smoky Quartz Wall");
            table.AddItem("Small Stone Pyramid");
            table.AddItem("Stinging, Prickly Weeds");
            table.AddItem("Giant Beetle Carapace");
            table.AddItem("Music From The Ceiling");
            table.AddItem("A Strange Hole Emits an Odd Odor");
            table.AddItem("Three Dead Kobolds");
            table.AddItem("Smashed Furnature");
            table.AddItem("Two Foot High Door");
            table.AddItem("Dartboard of Manticore Spines");
            table.AddItem("Sizzling Hibachi");
            table.AddItem("Imp Sculptures in Tiny Alcoves");
            table.AddItem("A Corpse in a Roll of Black Silk");
            table.AddItem("A Massive Harp With Broken Strings");
            table.AddItem("A Small Bar");
            table.AddItem("The Broken Birdcage");
            table.AddItem("The Still Smoking Pipe");
            table.AddItem("A Nest of Three Purple Eggs");
            table.AddItem("The Model of Your Home Town");
            table.AddItem("Torn Bag of Sand");
            table.AddItem("Marbel Pedestal");
            table.AddItem("200 Sheets of Handwritten paper say 'This is not the way'");
            table.AddItem("Fly Covered Manequin Hangs from a Noose");
            table.AddItem("Three Foot Opening With a Slimy Trail");
            table.AddItem("Two Stone Dogs and the Struggling Mouse");
            table.AddItem("The Giant Mousetrap and the Human Arm");
            table.AddItem("The Unlucky Teleport Victim");
            table.AddItem("The Smell of Brimstone and the Salt Circle");
            table.AddItem("The Filthy, Torn Dress and the Holy Symbol");
            table.AddItem("The Iron Cage and the Almost Escaped Skeleton");
            table.AddItem("The Red Rune on the Ceiling");
            table.AddItem("The Drooping Plant and the Single Red Fruit");
            table.AddItem("Three Piranha in a Fishbowl");
            table.AddItem("A Ledge Crowded with Noisy Pigeons");
            table.AddItem("The Wooden Box With No Lid");
            table.AddItem("A Stack of Wooden Doors");
            table.AddItem("A Small Canvas Tent");
            table.AddItem("A Window into the Stone");
            table.AddItem("Unnaturally Angled");
            table.AddItem("A Bottomless Hole");
            table.AddItem("A Broken Marble Head");
            table.AddItem("The Regurgitated Halfling");
            table.AddItem("Five, Red, Wooden, Creepy Masks");
            table.AddItem("Something Moves in the Barrel of Stagnant Water");
            table.AddItem("The Foot in the Velvet Slipper");
            table.AddItem("A Single Serving of Gelatinous Cube");
            table.AddItem("The Secrest of the Painting of the Nymphs");
            table.AddItem("A Ring of Toatstools");
            table.AddItem("The Leering Frog Deity");
            table.AddItem("The Rank Mold Gives off Heat");
            table.AddItem("The Ceiling Drips Blood");
            table.AddItem("A Fireplace Stuffed With Bones");
            table.AddItem("Incense Burners Swing From Chains");
            table.AddItem("The Numbing, Icy Bell");
            table.AddItem("Deep Throbbing Hearbeat");
            table.AddItem("The Dome of Black Glass");
            table.AddItem("The Dagger Pinned Hat");
            table.AddItem("The Slumbering Maiden");
            table.AddItem("Clown Shoes");
            table.AddItem("The Orc-erotica Collection");
            table.AddItem("The Floating Crystal Ball");

            Descriptor = table.GetResult();
        }
    }
}
