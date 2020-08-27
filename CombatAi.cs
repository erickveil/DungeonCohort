using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class CombatAi
    {
        public static string CheckCombatReaction(string disposition)
        {
            List<uint> weight = _reactionWeights(disposition);
            var table = new RandomTable<string>();

            table.AddItem("Unavoidable attack", weight[0]);
            table.AddItem("Hostile, likely attacks but might listen", weight[1]);
            table.AddItem("Uncertain, opponent confused, hesitant, or threatening", weight[2]);
            table.AddItem("No attack, opponent leaves or considers offeres", weight[3]);
            table.AddItem("Friendly, seeking alliance or aid", weight[4]);

            return table.GetResult();
        }

        public static string ChooseOpeningTactics()
        {
            var table = new RandomTable<string>();

            table.AddItem("Face the party normally.", 3);
            table.AddItem("Hide in the room and attack after entry.");
            table.AddItem("Move to the next room and bust in while the " +
                "party's guard is down.");
            table.AddItem("Circle around and strike from behind after the " +
                "party enters the room.");
            table.AddItem("Noisy opponents, no supprise.");

            return table.GetResult();
        }

        public static string ChooseTargetPersistence()
        {
            var table = new RandomTable<string>();

            table.AddItem("Stay on target", 3);
            table.AddItem("Change when conditions change");

            return table.GetResult();
        }

        public static string ChooseFocus()
        {
            var table = new RandomTable<string>();

            table.AddItem("Lowest hp");
            table.AddItem("Lowest AC");
            table.AddItem("The Spellcaster");
            table.AddItem("The Healer");
            table.AddItem("The Tank", 2);
            table.AddItem("Highest damage dealt", 2);
            table.AddItem("Random PC", 3);
            table.AddItem("Highest initiative");
            table.AddItem("The first PC to attack");
            table.AddItem("Highest AC");
            table.AddItem("Most hp");
            table.AddItem("Divide up on party", 2);
            table.AddItem("The closest", 2);
            table.AddItem("Ranged attackers");
            table.AddItem("DM's choice");

            return table.GetResult();
        }

        public static string RangedStrategy()
        {
            var table = new RandomTable<string>();

            table.AddItem("Fire and move away from melee");
            table.AddItem("Fire once, then move in to melee");
            table.AddItem("Fire until melee moves in");

            return table.GetResult();
        }

        public static string ConsiderOffers()
        {
            var table = new RandomTable<string>();

            table.AddItem("No requirements. A disgruntled opponent " +
                "purposely shirks their duty.");
            table.AddItem("Perform a quest within the dungeon, in " +
                "another direction:\n" + ChoseQuest());
            table.AddItem("Demand a bribe for CR + 1d6 x 10 gp from each PC.");
            table.AddItem("Demand a bribe of a magic item.");
            table.AddItem("Impenetrable - refuses any offers and attacks " +
                "anyway.");

            return table.GetResult();
        }

        public static string ChoseQuest()
        {
            var goalTable = new RandomTable<string>();

            goalTable.AddItem("Kill a target");
            goalTable.AddItem("Capture a target alive");
            goalTable.AddItem("Find a magic item");
            goalTable.AddItem("Mediate a situation");
            goalTable.AddItem("Clear a branch of the dungeon");
            goalTable.AddItem("Bring the treasure");
            goalTable.AddItem("Escort an important person");
            goalTable.AddItem("Smuggle a package");
            goalTable.AddItem("Destroy a magical threat");
            goalTable.AddItem("Obtain information from a source");
            goalTable.AddItem("Rescue a captive");
            goalTable.AddItem("Map a section of the dungeon");

            string goal = goalTable.GetResult();

            var dice = Dice.Instance;
            int numRooms = dice.Roll(1, 4) + 1;


            return "Quest: " + goal + "\n" +
                "Difficulty: " + CrawlRoomContents.GetRandomDifficulty()
                + "\n" +
                "Encounters: " + numRooms;
        }

        public static string ChoosePersonality()
        {
            var table = new RandomTable<string>();

            table.AddItem("Surly: All PC negotiation checks made at " +
                "disadvantage.");
            table.AddItem("Paranoid: Persuasion checks made by PCs have " +
                "disadvantage.");
            table.AddItem("Imitigable: Intimidation checks made by the PCs " +
                "have disadvantage.");
            table.AddItem("Suspicious: Deception checks made by PCs get " +
                "disadvantage.");
            table.AddItem("Grim: Performance checks made by PCs get " +
                "disadvantage.");
            table.AddItem("Bored: Performance checks made by PCs get " +
                "advantage.");
            table.AddItem("Gullible: Deception checks made by PCs get " +
                "advantage.");
            table.AddItem("Glass Jaw: Intimidation checks made by PCs have " +
                "advantage.");
            table.AddItem("Pushover: Persuasion checks made by PCs have " +
                "advantage.");
            table.AddItem("Indifferent: All negotiation check made normally.");
            table.AddItem("Amicable: All PC negotiation checks made with " +
                "advantage.");
            table.AddItem("Unusual: Some other skill check can be used " +
                "and would get advantage (Medicine for an ill opponent, " +
                "arcana for one with interest in the arcane, etc.)");

            return table.GetResult();
        }

        public static string GetDualPersonality()
        {
            var positiveTable = GetPositivePersonalityTable();
            var negativeTable = GetNegativePersonalityTable();
            int positiveIndex = positiveTable.GetResultIndex();
            int negativeIndex = negativeTable.GetResultIndex();
            while (positiveIndex == negativeIndex)
            {
                negativeIndex = negativeTable.GetResultIndex();
            }
            string positiveResult = positiveTable.GetResult(positiveIndex);
            string negativeResult = negativeTable.GetResult(negativeIndex);
            return positiveResult + "\n" + negativeResult;
        }

        public static RandomTable<string> GetPositivePersonalityTable()
        {
            var table = new RandomTable<string>();

            table.AddItem("Bored: Performance checks made by PCs get " +
                "advantage.", 2);
            table.AddItem("Gullible: Deception checks made by PCs get " +
                "advantage.", 2);
            table.AddItem("Glass Jaw: Intimidation checks made by PCs have " +
                "advantage.", 2);
            table.AddItem("Pushover: Persuasion checks made by PCs have " +
                "advantage.", 2);

            table.AddItem("Indifferent: All negotiation check made normally.");
            table.AddItem("Amicable: All PC negotiation checks made with " + 
                "advantage.");

            table.AddItem("Unusual: Some other skill check can be used " +
                "and would get advantage (Medicine for an ill opponent, " +
                "arcana for one with interest in the arcane, etc.)");

            return table;
        }

        public static RandomTable<string> GetNegativePersonalityTable()
        {
            var table = new RandomTable<string>();

            table.AddItem("Grim: Performance checks made by PCs get " + 
                "disadvantage.", 2);
            table.AddItem("Suspicious: Deception checks made by PCs get " + 
                "disadvantage.", 2);
            table.AddItem("Imitigable: Intimidation checks made by the PCs " + 
                "have disadvantage.", 2);
            table.AddItem("Paranoid: Persuasion checks made by PCs have " + 
                "disadvantage.", 2);

            table.AddItem("Indifferent: All negotiation check made normally.");
            table.AddItem("Surly: All PC negotiation checks made at " + 
                "disadvantage.");

            return table;
        }

        public static string OpportunityPreference()
        {
            var table = new RandomTable<string>();

            table.AddItem("Avoid attacks of opportunity if stipped.");
            table.AddItem("Stop at intervening melee, attack, then move in, " +
                "splitting move if necessary.");
            table.AddItem("Disengage to get to target.");
            table.AddItem("Dodge to get to target.");
            table.AddItem("Dash to get to target.");
            table.AddItem("Normal movement to target, taking on attacks.");

            return table.GetResult();
        }

        public static string Fatality()
        {
            var table = new RandomTable<string>();

            table.AddItem("Typical: Take PC to 0 hp then focus on new " +
                "target.", 8);
            table.AddItem("Inquisitor: Attack to subdue all targets and " +
                "take prisoners for questining after the fight.", 2);
            table.AddItem("Kidnappers: Try to escape with fallen PCs. " +
                "Possibly to ransom them back later.", 2);
            table.AddItem("Hostage Negotiator: Grapple felled PCs and " +
                "use them as leverate against the surviving party to " +
                "surrender of perform quest/bribe/leave.", 2);
            table.AddItem("Thief: Steals an item from the felled PC and " +
                "attempts to make off with it.", 2);
            table.AddItem("Murderer: Takes one hit on the fallen PC if " +
                "they haven't made a death save yet, increasing the " +
                "danger that they will die soon.");

            return table.GetResult();
        }

        public static string MoraleFailure()
        {
            var table = new RandomTable<string>();

            table.AddItem("Surrender");
            table.AddItem("Dash (route)");
            table.AddItem("Dodge", 2);
            table.AddItem("Disengage or Dodge", 2);
            table.AddItem("Disengage or Dash", 2);

            return table.GetResult();
        }

        private static List<uint> _reactionWeights(string disposition)
        {
            var list = new List<uint>();
            if (disposition == "Uncertain")
            {
                list.Add(1);
                list.Add(1);
                list.Add(1);
                list.Add(1);
                list.Add(1);
            }
            else if (disposition == "Likely Ally")
            {
                list.Add(1);
                list.Add(1);
                list.Add(3);
                list.Add(3);
                list.Add(4);
            }
            else if (disposition == "Likely Foe")
            {
                list.Add(4);
                list.Add(3);
                list.Add(3);
                list.Add(1);
                list.Add(1);
            }
            else
            {
                throw new Exception("Undefined disposition: " + disposition);
            }
            return list;
        }

    }
}
