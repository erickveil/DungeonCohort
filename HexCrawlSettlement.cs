using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class HexCrawlSettlement
    {
        public string Type;
        bool IsRuins = false;

        public Character Leader;
        public EncounterComponent Retainers;

        /// <summary>
        /// What does the leader do when PCs arrive in their demesne?
        /// </summary>
        public string Reaction;

        public override string ToString()
        {
            return Type
                + "\nRuled by: " + Leader.ToString()
                + "\nRetainers: " + Retainers.ToString()
                + "\nRection: " + Reaction;
        }

        public void Init()
        {
            SetType();
            SetLeader();
            SetRetainers();
            SetReaction();
        }

        public void SetType()
        {
            var dice = Dice.Instance;
            IsRuins = dice.Roll(1, 6) <= 3;

            // TODO: chance of special package instead, such as Elven palace, or 
            // Dwarven hold, or dragon lair

            var table = new RandomTable<string>();
            table.AddItem("Mine");
            table.AddItem("Pyramid");
            table.AddItem("Town");
            table.AddItem("Motte and Bailey");
            table.AddItem("Fort");
            table.AddItem("Keep");
            table.AddItem("Tower");
            table.AddItem("Castle");
            table.AddItem("Temple");
            table.AddItem("Church");
            table.AddItem("Druid Grove");
            table.AddItem("Barbarian Camp");
            table.AddItem("Fighter Fortress");
            table.AddItem("Monk Monastery");
            table.AddItem("Paladin Chapel");
            table.AddItem("Ranger Lodge");
            table.AddItem("Sorcerer Sanctum");
            table.AddItem("Warlock Fane");
            table.AddItem("Bandit Hideout");
            table.AddItem("Cave network used as a Monster Lair");
            table.AddItem("Dungeon used as a stronghold");
            table.AddItem("Palace");
            table.AddItem("Entrance to the Underdark");
            // TODO: Gates?
            Type = table.GetResult();
        }

        public void SetLeader()
        {

        }

        public void SetRetainers()
        {

        }

        public void SetReaction()
        {
            var dice = Dice.Instance;

            var table = new RandomTable<string>();

            table.AddItem("Hold up inside. Deny entrance. Attack any " +
                "intruders.");
            table.AddItem("Hold up inside. Welcome visitors reluctantly. " +
                "Hiding something.");
            table.AddItem("Hold up inside. Welcome visitors and host party " +
                "up to one month and provide up to two weeks of rations " +
                "and horses if needed.");
            table.AddItem("Ride out to meet. Attacks!");
            table.AddItem("Ride out to meet. Challenge to one-on-one " +
                "battle. Will take PC's armor if win, or host up to one " +
                "month and provide 2 weeks of rations and horses if lose.");
            table.AddItem("Ride out to meet. Will cast Geas for the party " +
                "to perform a quest.");
            table.AddItem("Ride out to meet. Will demand a magic item " +
                "from the party as a toll.");
            int toll = dice.Roll(1, 4) * 1000;
            table.AddItem("Ride out to meet. Will demand " + toll + 
                " gp as a toll.");
            table.AddItem("Ride out to meet. Will demand 10% of their " +
                "coin as a tithe to their god.");
            // TODO: random quest generation?
            table.AddItem("Rides out to meet. Provides a quest, offering " +
                "a reward for its completion.");
            table.AddItem("Rides out to meet. Will escort the party " +
                "immediately to the edge of their demesne and warn them " +
                "to stay out.");

            Reaction = table.GetResult();

        }
    }
}
