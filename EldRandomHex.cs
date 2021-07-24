using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class EldRandomHex
    {
        public static string ChoseHex(int level)
        {
            switch(level)
            {
                case 1:
                    return L1Hex();
                case 2:
                    return L2Hex();
                case 3:
                    return L3Hex();
                case 4:
                    return L4Hex();
                case 5:
                    return L5Hex();
                default:
                    return L5Hex();
            }
        }

        public static string L1Hex()
        {
            var table = new RandomTable<string>();
            table.AddItem("59-01. Darkpine Woods");
            table.AddItem("59-02. Zerth Tower");
            table.AddItem("59-03. Dewbright Camp");
            table.AddItem("60-01. Copper Hill");
            table.AddItem("60-02. Giant Statue of Old Queen");
            table.AddItem("60-03. Common Camp Site");
            table.AddItem("68-01. Greenfield Hamlet");
            table.AddItem("68-02. Creeper Tangles");
            table.AddItem("68-03. Findleblast Caves");
            table.AddItem("69-01. Raptorclaw Keep");
            table.AddItem("69-01. Mercenaries' Graves");
            table.AddItem("69-01. Dungeons of Behalten");
            table.AddItem("78-01. Ghost Town of Weizendorf");
            table.AddItem("78-02. Unstrung Harp");
            table.AddItem("78-03. The Dead Circle");
            table.AddItem("79-01. Chopped Natural Columns");
            table.AddItem("79-02. The Cloaked Statue");
            table.AddItem("79-03. Kiraaye Ka");
            table.AddItem("L2: " + L2Hex());
            return table.GetResult();
        }

        public static string L2Hex()
        {
            var table = new RandomTable<string>();
            table.AddItem("49-01. Bandit Encampment");
            table.AddItem("49-02. Magic Dead Light Stone");
            table.AddItem("49-03. The Healing Spring");
            table.AddItem("50-01. Dwarven Hold of Waystone");
            table.AddItem("50-02. Fountain of Folly");
            table.AddItem("50-03. Moon Gate (Full)");
            table.AddItem("58-01. Viehdorf Hamlet");
            table.AddItem("58-02. Orc Outpost Ya-awk");
            table.AddItem("58-03. Sacrificial Altar");
            table.AddItem("67-01. Crumblestone Bridge");
            table.AddItem("67-02. Savage Village");
            table.AddItem("67-03. Hobgoblin Outpost");
            table.AddItem("77-01. Breen, The Frozen Lake");
            table.AddItem("77-02. Moon Gate (Gibbous Waning)");
            table.AddItem("77-03. The Embedded Sword");
            table.AddItem("86-01. The Ruins of Randchadt");
            table.AddItem("86-02. Ambush Spot");
            table.AddItem("86-03. The Cursed Fountain");
            table.AddItem("L3: " + L3Hex());
            return table.GetResult();

        }

        public static string L3Hex()
        {
            var table = new RandomTable<string>();
            table.AddItem("39-01. Ruins of a Mining Town");
            table.AddItem("39-02. Godstone");
            table.AddItem("39-03. Fey Woods");
            table.AddItem("40-01. The Hellhive");
            table.AddItem("40-02. Log Bridge Falls");
            table.AddItem("40-03. The Ring Barrow");
            table.AddItem("41-01. Stadschmieden Inn");
            table.AddItem("41-02. Ambush Spot");
            table.AddItem("41-03. Floating Stones");
            table.AddItem("48-01. Hermit's House");
            table.AddItem("48-02. The Fire King's Barrow");
            table.AddItem("48-03. A Hole in the Land");
            table.AddItem("57-01. Doomwood");
            table.AddItem("57-02. Tower of the Necromancer's Apprentice");
            table.AddItem("57-03. Thoromere's Throne");
            table.AddItem("66-01. Canto Shrine");
            table.AddItem("66-02. The Raven Tree");
            table.AddItem("66-03. Fire Newt Hold");
            table.AddItem("76-01. The Witchtower");
            table.AddItem("76-02. Bugbear Huts");
            table.AddItem("76-03. Ruined Dwarven Hold");
            table.AddItem("85-01. The Busted Portal");
            table.AddItem("85-02. The Ice Pool");
            table.AddItem("85-03. The Restful Obelisk");
            table.AddItem("L4: " + L4Hex());
            return table.GetResult();

        }

        public static string L4Hex()
        {
            var table = new RandomTable<string>();
            table.AddItem("29-01. The Green Circle");
            table.AddItem("29-02. " + EldHex.HexLocations());
            table.AddItem("29-03. " + EldHex.HexLocations());
            table.AddItem("30-01. The Knights Lodge");
            table.AddItem("30-02. " + EldHex.HexLocations());
            table.AddItem("30-03. " + EldHex.HexLocations());
            table.AddItem("31-01. The Ribs of Jord");
            table.AddItem("31-02. " + EldHex.HexLocations());
            table.AddItem("31-03. " + EldHex.HexLocations());
            table.AddItem("38-01. Zazan Thri-kreen Hive");
            table.AddItem("38-02. " + EldHex.HexLocations());
            table.AddItem("38-03. " + EldHex.HexLocations());
            table.AddItem("47-01. The Fields of Bone");
            table.AddItem("47-02. " + EldHex.HexLocations());
            table.AddItem("47-03. " + EldHex.HexLocations());
            table.AddItem("56-01. The Sword of the Titan");
            table.AddItem("56-02. " + EldHex.HexLocations());
            table.AddItem("56-03. " + EldHex.HexLocations());
            table.AddItem("65-01. The Maddening Stone");
            table.AddItem("65-02. The Witch's Cave");
            table.AddItem("65-03. The Wailing Skull");
            table.AddItem("75-01. Hemhill Hamlet");
            table.AddItem("75-02. Deep Well");
            table.AddItem("75-03. Wererat's House");
            table.AddItem("84-01. The Great Cistern");
            table.AddItem("84-02. " + EldHex.HexLocations());
            table.AddItem("84-03. " + EldHex.HexLocations());
            table.AddItem("90-01. Ruins of Stesen Tiga");
            table.AddItem("90-02. " + EldHex.HexLocations());
            table.AddItem("90-03. " + EldHex.HexLocations());
            table.AddItem("L5: " + L5Hex());
            return table.GetResult();
        }

        public static string L5Hex()
        {
            var table = new RandomTable<string>();
            table.AddItem("19-01. Feylight Glen");
            table.AddItem("19-02. " + EldHex.HexLocations());
            table.AddItem("19-03. " + EldHex.HexLocations());
            table.AddItem("20-01. The Great Mushrooms");
            table.AddItem("20-02. Moon Gate (Gibbous Waxing)");
            table.AddItem("20-03. " + EldHex.HexLocations());
            table.AddItem("21-01. Luftriket The Fortress of Air");
            table.AddItem("21-02. " + EldHex.HexLocations());
            table.AddItem("21-03. " + EldHex.HexLocations());
            table.AddItem("22-01. Ruined Castle Hugel Nach Hause");
            table.AddItem("22-02. " + EldHex.HexLocations());
            table.AddItem("22-03. " + EldHex.HexLocations());
            table.AddItem("28-01. Canto Village");
            table.AddItem("28-02. " + EldHex.HexLocations());
            table.AddItem("28-03. " + EldHex.HexLocations());
            table.AddItem("37-01. Twelve Basalt Statues");
            table.AddItem("37-02. Island Shrine");
            table.AddItem("37-03. Ruined Paladin Chapel");
            table.AddItem("46-01. The Crumbling Spike");
            table.AddItem("46-02. " + EldHex.HexLocations());
            table.AddItem("46-03. " + EldHex.HexLocations());
            table.AddItem("55-01. The Sword of the Titan");
            table.AddItem("55-02. " + EldHex.HexLocations());
            table.AddItem("55-03. " + EldHex.HexLocations());
            table.AddItem("64-01. Fourtower Bridge");
            table.AddItem("64-02. " + EldHex.HexLocations());
            table.AddItem("64-03. " + EldHex.HexLocations());
            table.AddItem("74-01. Hillock Mines");
            table.AddItem("74-02. The Scrying Crystal");
            table.AddItem("74-03. Gnoll Ruins");
            table.AddItem("83-01. The Lone Tomb");
            table.AddItem("83-02. Moon Gate (Last Quarter)");
            table.AddItem("83-03. " + EldHex.HexLocations());
            table.AddItem("89-01. Ornak: The Crystal Cave");
            table.AddItem("89-02. " + EldHex.HexLocations());
            table.AddItem("89-03. " + EldHex.HexLocations());
            return table.GetResult();
        }
    }
}
