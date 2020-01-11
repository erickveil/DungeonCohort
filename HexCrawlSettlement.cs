using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    /// <summary>
    /// Settlement occupants is set up similar to how OD&D did, with greater
    /// variety, and using 5e NPC types.
    /// </summary>
    class HexCrawlSettlement
    {
        public string Type;
        bool IsRuins = false;

        public Character Leader = null;
        public EncounterComponent Retainers = null;

        /// <summary>
        /// What does the leader do when PCs arrive in their demesne?
        /// </summary>
        public string Reaction = "";

        public override string ToString()
        {
            string ruin = (IsRuins ? " Ruins" : "");
            string desc = Type + ruin;
            if (!(Leader is null)) 
            {
                desc += "\nRuled by: " + Leader.ToString();
            }
            if (!(Retainers is null))
            {
                desc += "\nRetainers: " + Retainers.ToString();
            }
            if (Reaction != "")
            {
                desc += "\nRection: " + Reaction;
            }

            return desc;
        }

        public void Init(int tier, bool isLeaderStdRace)
        {
            var dice = Dice.Instance;
            IsRuins = dice.Roll(1, 6) <= 3;

            SetType();
            if (!IsRuins)
            {
                SetLeader(tier, isLeaderStdRace);
                SetRetainers(tier);
                SetReaction();
            }
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

        private void SetLeader(int tier, bool isStdRace)
        {
            var alignment = Character.ChoseAlignmentGE();

            var ancestryIndex = AncestryIndex.Instance;
            Leader = new Character();
            Leader = ancestryIndex.GetRandomNPC(tier, alignment, isStdRace);
        }

        private void SetRetainers(int tier)
        {
            var ancestryIndex = AncestryIndex.Instance;
            var alignmentGE = Leader._alignGE;
            var table = ancestryIndex.GetFullAncestryTable();
            table = ancestryIndex.FilterTableByGEAlignment(table, alignmentGE);
            table = ancestryIndex.FilterTableByTier(table, tier);

            var retainerType = table.GetResult();

            var dice = Dice.Instance;
            int qty = dice.Roll(2, 12);

            Retainers = new EncounterComponent();
            Retainers.Monster = retainerType;
            Retainers.Qty = qty;
        }

        private void SetReaction()
        {

            var dice = Dice.Instance;

            var table = new RandomTable<string>();
            int toll = dice.Roll(1, 4) * 1000;

            // TODO: random quest generation?
            if (Leader._alignGE == AlignmentValue.ALIGN_GOOD
                || Leader._alignGE == AlignmentValue.ALIGN_NEUTRAL)
            {
                table.AddItem("Hold up inside. Deny entrance. Attack any " +
                    "intruders.");
                table.AddItem("Hold up inside. Welcome visitors reluctantly. " +
                    "Hiding something.");
                table.AddItem("Hold up inside. Welcome visitors and host party " +
                    "up to one month and provide up to two weeks of rations " +
                    "and horses if needed.");
                table.AddItem("Ride out to meet. Challenge to one-on-one " +
                    "battle. Will take PC's armor if win, or host up to one " +
                    "month and provide 2 weeks of rations and horses if lose.");
                table.AddItem("Ride out to meet. Will demand 10% of their " +
                    "coin as a tithe to their god.");
                table.AddItem("Rides out to meet. Provides a quest, offering " +
                    "a reward for its completion.");
                table.AddItem("Rides out to meet. Will escort the party " +
                    "immediately to the edge of their demesne and warn them " +
                    "to stay out.");
            }
            if (Leader._alignGE == AlignmentValue.ALIGN_EVIL
                || Leader._alignGE == AlignmentValue.ALIGN_NEUTRAL)
            
            {
                table.AddItem("Hold up inside. Deny entrance. Attack any " +
                    "intruders.");
                table.AddItem("Hold up inside. Welcome visitors reluctantly. " +
                    "Hiding something.");
                table.AddItem("Ride out to meet. Attacks!");

                table.AddItem("Ride out to meet. Challenge to one-on-one " +
                    "battle. Will take PC's armor if win, or host up to one " +
                    "month and provide 2 weeks of rations and horses if lose.");
                table.AddItem("Ride out to meet. Will cast Geas for the party " +
                    "to perform a quest.");
                table.AddItem("Ride out to meet. Will demand a magic item " +
                    "from the party as a toll.");
                table.AddItem("Ride out to meet. Will demand " + toll + 
                    " gp as a toll.");
                table.AddItem("Ride out to meet. Will demand 10% of their " +
                    "coin as a tithe to their god.");
                table.AddItem("Rides out to meet. Will escort the party " +
                    "immediately to the edge of their demesne and warn them " +
                    "to stay out.");
            }
            Reaction = table.GetResult();
        }
    }
}
