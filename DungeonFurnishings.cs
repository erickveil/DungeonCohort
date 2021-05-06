using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class DungeonFurnishings
    {
        public static string Condition()
        {
            var table = new RandomTable<string>();
            table.AddItem("Dusty");
            table.AddItem("Cracked");
            table.AddItem("Damaged");
            table.AddItem("Moldy");
            table.AddItem("Rotting");
            table.AddItem("Broken");
            table.AddItem("Burnt");
            table.AddItem("Scratched");
            table.AddItem("Blood-stained");
            table.AddItem("Brand-new");
            table.AddItem("Cobwebbed");
            table.AddItem("Toppled");
            table.AddItem("Gilded");
            table.AddItem("Unremarkable");
            table.AddItem("Carved");
            table.AddItem("Stained");
            table.AddItem("Painted");
            table.AddItem("Cloth-draped");
            table.AddItem("Glowing");
            table.AddItem("Floating");
            table.AddItem("Humming");
            table.AddItem("Smashed");
            table.AddItem("Crushed");
            table.AddItem("Upturned");
            return table.GetResult();
        }

        public static string General()
        {
            string content = Contents();

            var table = new RandomTable<string>();
            table.AddItem(Storage());
            table.AddItem("Armchair");
            table.AddItem("Armoire");
            table.AddItem("Curtain");
            table.AddItem("Bed");
            table.AddItem("Bench");
            table.AddItem("Blankent");
            table.AddItem("Brazier");
            table.AddItem("Cabinet");
            table.AddItem("Bunks");
            table.AddItem("Candelabrum");
            table.AddItem("Carpet");
            table.AddItem("Chandelier");
            table.AddItem("Chair");
            table.AddItem("Wardrobe");
            table.AddItem("Couch");
            table.AddItem("Cushion");
            table.AddItem("Dais");
            table.AddItem("Desk");
            table.AddItem("Fireplace");
            table.AddItem("Fountain");
            table.AddItem("Fresco: " + HexCrawlLandmark.ChooseStatueSubject());
            table.AddItem("Grindstone");
            table.AddItem("Idol");
            table.AddItem("Keg");
            table.AddItem("Loom");
            table.AddItem("Painting");
            table.AddItem("Pedestal");
            table.AddItem("Pillow");
            table.AddItem("Sconce");
            table.AddItem("Screen");
            table.AddItem("Shelves");
            table.AddItem("Shrine");
            table.AddItem("Sofa");
            table.AddItem("Stand");
            table.AddItem("Table");
            table.AddItem("Urn");
            table.AddItem("Wall basin");
            table.AddItem("Mushrooms");
            table.AddItem("Mold");
            table.AddItem("Giant Mushroom");
            table.AddItem("Standing Stone");
            table.AddItem("Statue: " + HexCrawlLandmark.ChooseStatueSubject());
            table.AddItem("Mural: " + HexCrawlLandmark.ChooseStatueSubject());
            table.AddItem("Tapestry: " + HexCrawlLandmark.ChooseStatueSubject());
            table.AddItem("Painting: " + HexCrawlLandmark.ChooseStatueSubject());
            table.AddItem("Bass Relief: " + HexCrawlLandmark.ChooseStatueSubject());
            table.AddItem("Column of light");
            table.AddItem("Columns");
            table.AddItem("Armor stand");
            table.AddItem("Mosaic: " + HexCrawlLandmark.ChooseStatueSubject());
            table.AddItem("Workshop: " + Workshop());
            table.AddItem("Runes");
            table.AddItem("Glyphs");
            table.AddItem("Altar emblazoned with :" + EldMagicItemGen.symbology());
            return table.GetResult();
        }

        public static string Workshop()
        {
            var table = new RandomTable<string>();

            table.AddItem("Boyer");
            table.AddItem("Carpenter");
            table.AddItem("Jeweler");
            table.AddItem("Mason");
            table.AddItem("Butcher");
            table.AddItem("Mechanic");
            table.AddItem("Farmer");
            table.AddItem("Fishery");
            table.AddItem("Crafts");
            table.AddItem("Siege");
            table.AddItem("Wood Furnace");
            table.AddItem("Magma Smelter");
            table.AddItem("Magma Kiln");
            table.AddItem("Magma glass furnace");
            table.AddItem("Tanner");
            table.AddItem("Loom");
            table.AddItem("Still");
            table.AddItem("Ashery");
            table.AddItem("Screw Press");
            table.AddItem("Smelter");
            table.AddItem("Quern");
            table.AddItem("Kiln");
            table.AddItem("Glass furnace");
            table.AddItem("Leather works");
            table.AddItem("Dyer");
            table.AddItem("Clothier");
            table.AddItem("Metalsmith forge");
            table.AddItem("Magma forge");

            return table.GetResult();
        }

        public static string Items()
        {
            var table = new RandomTable<string>();
            table.AddItem("Staff");
            table.AddItem("Pliers");
            table.AddItem("Hammer");
            table.AddItem("Robes");
            table.AddItem("Torch");
            table.AddItem("Dagger");
            table.AddItem("Skull");
            table.AddItem("Bones");
            table.AddItem("Lamp");
            table.AddItem("Lantern");
            table.AddItem("Whistle");
            table.AddItem("Padlock");
            table.AddItem("Key");
            table.AddItem("Scroll");
            table.AddItem(Book());
            table.AddItem("Crystal");
            return table.GetResult();

        }

        public static string Storage()
        {
            string content = Contents();
            var table = new RandomTable<string>();
            table.AddItem("Box");
            table.AddItem("Bag");
            table.AddItem("Sack");
            table.AddItem("Urn");
            table.AddItem("Crate");
            table.AddItem("Barrel");
            table.AddItem("Chest");
            table.AddItem("Skin");
            table.AddItem("Cask");
            table.AddItem("Keg");
            table.AddItem("Bucket");
            table.AddItem("Flagon");
            table.AddItem("Pitcher");
            table.AddItem("Mug");
            table.AddItem("Vial");
            table.AddItem("Jar");
            table.AddItem("Coffin");
            table.AddItem("Bowl");
            table.AddItem("Stone container");
            table.AddItem("Footlocker");
            table.AddItem("Iron trunk");
            return table.GetResult() + " of " + content;

        }

        public static string Contents()
        {
            var table = new RandomTable<string>();
            table.AddItem("Nothing (Empty)");
            table.AddItem("Ash");
            table.AddItem("Bark");
            table.AddItem("Bodily Organs");
            table.AddItem("Bones");
            table.AddItem("Cinders");
            table.AddItem("Crystals");
            table.AddItem("Dust");
            table.AddItem("Gelatin");
            table.AddItem("Grains");
            table.AddItem("Grease");
            table.AddItem("Husks");
            table.AddItem("Leaves");
            table.AddItem("Oil");
            table.AddItem("Paste");
            table.AddItem("Pellets");
            table.AddItem("Powder");
            table.AddItem("Hide");
            table.AddItem("Stalks");
            table.AddItem("Wheat");
            table.AddItem("Flour");
            table.AddItem("Salt");
            table.AddItem("Iron Bars");
            table.AddItem("Canvas");
            table.AddItem("Metal Scraps");
            table.AddItem("Copper Bars");
            table.AddItem("Cotton Cloth");
            table.AddItem("Ginger");
            table.AddItem("Salted Meat");
            table.AddItem("Wool");
            table.AddItem("Linen");
            table.AddItem("Barley");
            table.AddItem("Dried Peas");
            table.AddItem("Dried Lentils");
            table.AddItem("Millet");
            table.AddItem("Flour");
            table.AddItem("Potable Water");
            table.AddItem("Wine");
            table.AddItem("Beer");
            table.AddItem("Ale");
            table.AddItem("Mead");
            table.AddItem("Ichor");
            table.AddItem("Chopped-up Body Parts");
            table.AddItem("Blood");
            table.AddItem("Spiders");
            table.AddItem("Seeds");
            table.AddItem("Beans");
            table.AddItem("Rice");
            table.AddItem("Sand");
            table.AddItem("Broken Glass");
            table.AddItem("Glass 'Gemstones'");
            table.AddItem("Tin 'Coins'");
            table.AddItem("Toys");
            table.AddItem("Blank Parchment");
            table.AddItem("Blank Paper");
            table.AddItem("Ink");
            table.AddItem("Milk");
            return table.GetResult();


        }

        public static string Temple()
        {
            var table = new RandomTable<string>();
            table.AddItem(General());
            table.AddItem(Storage());
            table.AddItem("Altar");
            table.AddItem("Bells");
            table.AddItem("Candelabra");
            table.AddItem("Candles");
            table.AddItem("Candlesticks");
            table.AddItem("Cassocks");
            table.AddItem("Chimes");
            table.AddItem("Altar cloth");
            table.AddItem("Column");
            table.AddItem("Drum");
            table.AddItem("Font");
            table.AddItem("Gong");
            table.AddItem("Holy symbol");
            table.AddItem("Holy writings");
            table.AddItem("Idol");
            table.AddItem("Incensse burner");
            table.AddItem("Kneeling bench");
            table.AddItem("Lamp");
            table.AddItem("Lectern");
            table.AddItem("Mosaic");
            table.AddItem("Offertory container");
            table.AddItem("Paintings");
            table.AddItem("Frescoes");
            table.AddItem("Pews");
            table.AddItem("Musical Pipes");
            table.AddItem("Prayer rug");
            table.AddItem("Pulpit");
            table.AddItem("Robes");
            table.AddItem("Screen");
            table.AddItem("Shrine");
            table.AddItem("Chair");
            table.AddItem("Stand");
            table.AddItem("Statue");
            table.AddItem("Throne");
            table.AddItem("Vestments");
            return table.GetResult();

        }

        public static string GuardRoom()
        {
            var table = new RandomTable<string>();
            table.AddItem(General());
            table.AddItem(Storage());
            table.AddItem("Chair");
            table.AddItem("Bench");
            table.AddItem("Training Dummy");
            table.AddItem("Weapon Rack");
            table.AddItem("Shield");
            table.AddItem("Sword");
            table.AddItem("Spear");
            table.AddItem("Card Table");
            table.AddItem("Cards");
            table.AddItem("Dice");
            table.AddItem("Flagon");
            table.AddItem("Wineskin");
            table.AddItem("Dartboard");
            table.AddItem("Archery Target");
            table.AddItem("Grafitti");
            table.AddItem("Pile of Hay");
            table.AddItem("Blanket");
            table.AddItem("Cot");
            return table.GetResult();
        }

        public static string Study()
        {
            var table = new RandomTable<string>();
            table.AddItem(General());
            table.AddItem(Storage());
            table.AddItem("Armchair");
            table.AddItem("Chair");
            table.AddItem("Fireplace");
            table.AddItem("Endtable");
            table.AddItem("Ashtray");
            table.AddItem("Bookshelf");
            table.AddItem("Desk");
            table.AddItem("Painting");
            table.AddItem("Carpet");
            table.AddItem("Tapestry");
            table.AddItem("Pile of Firewood");
            table.AddItem(Book());
            return table.GetResult();
        }

        public static string Library()
        {
            var table = new RandomTable<string>();
            string book = Book();
            table.AddItem(General());
            table.AddItem(Storage());
            table.AddItem(Study());
            table.AddItem("Bookshelf");
            table.AddItem("Book: " + book);
            table.AddItem("Tome: " + book);
            table.AddItem("Codex: " + book);
            table.AddItem("Scroll: " + book);
            table.AddItem("Quill");
            table.AddItem("Desk");
            table.AddItem("Inkwell");
            table.AddItem("Lecturn");
            table.AddItem(book);
            return table.GetResult();
        }

        public static string Baracks()
        {
            var table = new RandomTable<string>();
            table.AddItem(General());
            table.AddItem(Storage());
            table.AddItem(GuardRoom());
            table.AddItem("Bunk");
            table.AddItem("Cot");
            table.AddItem("Empty Footlocker");
            table.AddItem("Common Clothes");
            table.AddItem("Mirror");
            table.AddItem("Chair");
            table.AddItem("Stool");
            table.AddItem("Bench");
            table.AddItem("Boot");
            table.AddItem("Glove");
            table.AddItem("Gorget");
            table.AddItem("Helm");
            return table.GetResult();
        }

        public static string Kitchen()
        {
            var table = new RandomTable<string>();
            table.AddItem(General());
            table.AddItem(Storage());
            table.AddItem("Pot");
            table.AddItem("Cauldron");
            table.AddItem("Firepit");
            table.AddItem("Counter");
            table.AddItem("Cutting Board");
            table.AddItem("Knife");
            table.AddItem("Pan");
            table.AddItem("Broom");
            table.AddItem("Oven");
            table.AddItem("Stove");
            table.AddItem("Charcoal");
            table.AddItem("Wood pile");
            table.AddItem("Cabinet");
            table.AddItem("Pantry");
            table.AddItem("Ladle");
            table.AddItem("Spoon");
            table.AddItem("Dish");
            table.AddItem("Tankard");
            table.AddItem("Plate");
            table.AddItem("Fork");
            table.AddItem("Spatula");
            table.AddItem("Stool");
            return table.GetResult();
        }

        public static string Bedroom()
        {
            var table = new RandomTable<string>();
            table.AddItem(General());
            table.AddItem(Storage());
            table.AddItem("Bed");
            table.AddItem("Cot");
            table.AddItem("Vanity");
            table.AddItem("Wardrobe");
            table.AddItem("Chair");
            table.AddItem("Stool");
            table.AddItem("Rug");
            table.AddItem("Painting");
            table.AddItem("Locket");
            table.AddItem(Book());
            table.AddItem("Brush");
            table.AddItem("Comb");
            table.AddItem("Curtain");
            table.AddItem("Screen");
            return table.GetResult();
        }

        public static string Book()
        {
            var table = new RandomTable<string>();
            table.AddItem("Account recods");
            table.AddItem("Alchemist notebook");
            table.AddItem("Almanac");
            table.AddItem("Bestiary");
            table.AddItem("Biography");
            table.AddItem("Book of herladry");
            table.AddItem("Book of myths");
            table.AddItem("Book of pressed flowers");
            table.AddItem("Herbologist's notebook");
            table.AddItem("Calendar");
            table.AddItem("Catalog");
            table.AddItem("Diary");
            table.AddItem("Dictionary");
            table.AddItem("Doodles or Sketches");
            table.AddItem("Forged document");
            table.AddItem("Grammar workbook");
            table.AddItem("Heretical text");
            table.AddItem("Historical text");
            table.AddItem("Last will and testament");
            table.AddItem("Legal code");
            table.AddItem("Letter");
            table.AddItem("Lunatic's ravings");
            table.AddItem("Magic tricks (not a spellbook)");
            table.AddItem("Memoir");
            table.AddItem("Map or atlas");
            table.AddItem("Memoir");
            table.AddItem("Navigational char or star chart");
            table.AddItem("Novel");
            table.AddItem("Pilot's Rudder");
            table.AddItem("Magic scroll");
            table.AddItem("Painting");
            table.AddItem("Poetry");
            table.AddItem("Prayer Book");
            table.AddItem("Property deed");
            table.AddItem("Recipe book or cookbook");
            table.AddItem("Recod of a criminal trial");
            table.AddItem("Sheet music");
            table.AddItem("Spellbook");
            table.AddItem("Text on armor making");
            table.AddItem("Text on astrology");
            table.AddItem("Text on brewing");
            table.AddItem("Text on exotic flora or fauna");
            table.AddItem("Text on herbalism");
            table.AddItem("Text on local flora");
            table.AddItem("Text on mathematics");
            table.AddItem("Text on masonry");
            table.AddItem("Text on medicine");
            table.AddItem("Theological text");
            table.AddItem("Tome of forbidden lore");
            table.AddItem("Travelogue for an exotic land");
            table.AddItem("Travelogue of the planes");
            table.AddItem("Treasure Map");
            return table.GetResult();
        }

        public static string DiningRoom()
        {
            var table = new RandomTable<string>();
            table.AddItem(General());
            table.AddItem(Storage());
            table.AddItem("Dining table");
            table.AddItem("Chair");
            table.AddItem("Dish");
            table.AddItem("Plate");
            table.AddItem("Bowl");
            table.AddItem("Ladle");
            table.AddItem("Spoon");
            table.AddItem("Fork");
            table.AddItem("Knife");
            table.AddItem("Tablecloth");
            table.AddItem("Napkin");
            table.AddItem("Tray");
            table.AddItem("Cart");
            table.AddItem("Candelabra");
            table.AddItem("Chadelier");
            table.AddItem("Statue");
            return table.GetResult();
        }

        public static string Pantry()
        {
            return Storage();
        }

        public static string Kennel()
        {
            var table = new RandomTable<string>();
            table.AddItem(General());
            table.AddItem(Storage());
            table.AddItem("Cage");
            table.AddItem("Chain");
            table.AddItem("Leash");
            table.AddItem("Collar");
            table.AddItem("Drain");
            table.AddItem("Bones");
            table.AddItem("Stall");
            table.AddItem("Trough");
            table.AddItem("Tack and Harness");
            table.AddItem("Hay bale");
            table.AddItem("Crop");
            return table.GetResult();
        }

        public static string Prison()
        {
            var table = new RandomTable<string>();
            table.AddItem(General());
            table.AddItem(Storage());
            table.AddItem("Cage");
            table.AddItem("Chain");
            table.AddItem("Drain");
            table.AddItem("Bones");
            table.AddItem("Cell");
            table.AddItem("Key");
            table.AddItem("Padlock");
            table.AddItem("Manacles");
            table.AddItem("Skull");
            return table.GetResult();
        }

        public static string Dorm()
        {
            var table = new RandomTable<string>();
            table.AddItem(General());
            table.AddItem(Storage());
            table.AddItem(Bedroom());
            table.AddItem("Bunk");
            table.AddItem("Trunk");
            table.AddItem("Desk");
            table.AddItem("Chair");
            table.AddItem(Book());
            table.AddItem("Bench");
            return table.GetResult();
        }

        public static string Museum()
        {
            var table = new RandomTable<string>();
            table.AddItem(General());
            table.AddItem(Storage());
            table.AddItem("Banch");
            table.AddItem("Pedestal");
            table.AddItem("Painting");
            table.AddItem("Statue");
            table.AddItem("Mural");
            table.AddItem("Mosaic");
            table.AddItem("Coat of arms");
            table.AddItem("Tapestry");
            table.AddItem("Pottery");
            table.AddItem("Display case");
            table.AddItem("Idol");
            table.AddItem("Skeleton");
            table.AddItem("Tablet");
            table.AddItem("Mummy");
            table.AddItem(Book());
            table.AddItem("Crystal");
            return table.GetResult();
        }

        public static string TortureChamber()
        {
            var table = new RandomTable<string>();
            table.AddItem(General());
            table.AddItem(Storage());
            table.AddItem("Rack");
            table.AddItem("Pliers");
            table.AddItem("Knife");
            table.AddItem("Chains");
            table.AddItem(Prison());
            table.AddItem("Shackles");
            table.AddItem("Table with restraints");
            table.AddItem("Stool");
            table.AddItem("Bucket");
            table.AddItem("Branding Irons");
            table.AddItem("Brazier");
            table.AddItem("Oubliette");
            table.AddItem("Iron mask");
            table.AddItem("Pitch");
            table.AddItem("Oil");
            table.AddItem("Thumbscrews");
            table.AddItem("Stocks");
            table.AddItem("Tub");
            return table.GetResult();
        }

        public static string TreasureRoom()
        {
            var table = new RandomTable<string>();
            table.AddItem(General());
            table.AddItem(Storage());
            table.AddItem(Museum());
            return table.GetResult();
        }

        public static string ThroneRoom()
        {
            var table = new RandomTable<string>();
            table.AddItem(General());
            table.AddItem(Storage());
            table.AddItem("Column");
            table.AddItem("Throne");
            table.AddItem("Dais");
            return table.GetResult();
        }

        public static string Crypt()
        {
            var table = new RandomTable<string>();
            table.AddItem(General());
            table.AddItem(Storage());
            table.AddItem("Urn");
            table.AddItem("Sepulcher");
            table.AddItem("Sarcophagus");
            table.AddItem("Tomb");
            table.AddItem("Coffin");
            table.AddItem("Ossuary");
            table.AddItem("Bones");
            table.AddItem("Skull");
            table.AddItem("Statue");
            table.AddItem("Idol");
            table.AddItem("Hearldry");
            table.AddItem("Tablet");
            return table.GetResult();
        }

        public static string Place()
        {
            var table = new RandomTable<string>();
            table.AddItem(General());
            table.AddItem(Storage());
            table.AddItem("");
            return table.GetResult();
        }
    }
}
