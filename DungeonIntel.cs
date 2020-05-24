using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class DungeonIntel
    {

        public static string GetDungeonOriginalPurpose()
        {
            var table = new RandomTable<string>();

            table.AddItem("Incarceration");
            table.AddItem("Natural caverns");
            table.AddItem("Monster lair");
            table.AddItem("Death trap");
            table.AddItem("Treasure vault");
            table.AddItem("Mine");
            table.AddItem("Protect a gate");
            table.AddItem("Refuge/Stronghold");
            table.AddItem("Subterranean Society");
            table.AddItem("Underdark Entrance");
            table.AddItem("Cult Temple");
            table.AddItem("Tomb");
            table.AddItem("Guarded Passage to another Demesne");

            return table.GetResult();
        }

        public static string GetDungeonHistory()
        {
            var table = new RandomTable<string>();

            table.AddItem("Dungeon was abandoned: " + GetAbandonedReason());
            table.AddItem("Dungeon changed hands: " + GetNewOwnerReason());
            table.AddItem("Internal Event: " + GetInternalEvent());
            table.AddItem("Regional Event: " + GetExternalEvent());

            return table.GetResult();
        }

        public static string GetEndOfDungeonPuzzleSecret()
        {
            var table = new RandomTable<string>();

            table.AddItem("Boss is vulnerable to one damage type");
            table.AddItem("Boss is immune to all but one damage type");
            table.AddItem("Boss has secret escape route");
            table.AddItem("The combination for the final vault lock");
            table.AddItem("Boss has special power");

            return table.GetResult();
        }

        public static string GetAbandonedReason()
        {
            var table = new RandomTable<string>();

            table.AddItem("Plague");
            table.AddItem("Raiders");
            table.AddItem("Discovery made within the dungeon");
            table.AddItem("Inernal conflict");
            table.AddItem("Magical catastrophe");
            table.AddItem("Natural disaster");
            table.AddItem("Cursed by the gods");

            return table.GetResult();
        }

        public static string GetNewOwnerReason()
        {
            var table = new RandomTable<string>();

            table.AddItem("Invaders");
            table.AddItem("Planar Creatures");
            table.AddItem("Sold");
            table.AddItem("Minority outlived the majority");
            table.AddItem("Revolution");
            table.AddItem("Factional schism");
            table.AddItem("Factions unite");

            return table.GetResult();
        }

        public static string GetInternalEvent()
        {
            var table = new RandomTable<string>();

            table.AddItem("Site of a great miracle");
            table.AddItem("Inhabitants expand the dungeon");
            table.AddItem("Part of the dungeon cut off");
            table.AddItem("Purpose of the dungeon changed"); 
            table.AddItem("Rebellion");
            table.AddItem("Change in leadership");
            table.AddItem("Formed an alliance with an enemy");
            table.AddItem("Broke and alliance with an ally");
            table.AddItem("New level added to dungeon");

            return table.GetResult();
        }

        public static string GetExternalEvent()
        {
            var table = new RandomTable<string>();

            table.AddItem("Land falls into anarchy");
            table.AddItem("New government takes over");
            table.AddItem("Species migrates away");
            table.AddItem("Significant figure takes power");
            table.AddItem("War");
            table.AddItem("Famine");
            table.AddItem("Plague");
            table.AddItem("Shortage of important resource");
            table.AddItem("Economic collapse");
            table.AddItem("Era of prosperity");
            table.AddItem("Natural disaster");

            return table.GetResult();
        }

    }
}
