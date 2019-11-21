using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class GmEmulator
    {
        public string RollFate(int chaosFactor, string odds)
        {
            int mid = _getFateBase(chaosFactor, odds);
            int low = (int)(mid * 0.2f);
            int high = (int)(100 - ((100 - mid) * 0.2f));
            if (low < 0) { low = 0; }
            if (mid >= 100) { high = 200; }

            var dice = Dice.Instance;
            int roll = dice.Roll(1, 100);
            if (roll < low) { return "Exceptional Yes"; }
            if (roll < mid) { return "Yes"; }
            if (roll < high) { return "No"; }
            return "Exceptional No";
        }

        public string RollEventFocus()
        {
            var table = new RandomTable<string>();
            table.AddItem("Remote event", 7);
            table.AddItem("NPC action", 21);
            table.AddItem("Introduce a new NPC", 7);
            table.AddItem("Move toward a thread", 10);
            table.AddItem("Move away from a thread", 7);
            table.AddItem("Close a thread", 3);
            table.AddItem("PC negative", 12);
            table.AddItem("PC positive", 8);
            table.AddItem("Ambiguous event", 8);
            table.AddItem("NPC negative", 9);
            table.AddItem("NPC positive", 8);
            return table.GetResult();
        }

        public string RollEventAction()
        {
            var table = new RandomTable<string>();

            table.AddItem("Attainment");
            table.AddItem("Starting");
            table.AddItem("Neglect");
            table.AddItem("Fight");
            table.AddItem("Recruit");
            table.AddItem("Triumph");
            table.AddItem("Violate");
            table.AddItem("Oppose");
            table.AddItem("Malice");
            table.AddItem("Communicate");
            table.AddItem("Persecute");
            table.AddItem("Increase");
            table.AddItem("Decrease");
            table.AddItem("Abandon");
            table.AddItem("Gratify");
            table.AddItem("Inquire");
            table.AddItem("Antagonise");
            table.AddItem("Move");
            table.AddItem("Waste");
            table.AddItem("Truce");
            table.AddItem("Release");
            table.AddItem("Befriend");
            table.AddItem("Judge");
            table.AddItem("Desert");
            table.AddItem("Dominate");
            table.AddItem("Procrastinate");
            table.AddItem("Praise");
            table.AddItem("Separate");
            table.AddItem("Take");
            table.AddItem("Break");
            table.AddItem("Heal");
            table.AddItem("Delay");
            table.AddItem("Stop");
            table.AddItem("Lie");
            table.AddItem("Return");
            table.AddItem("Immitate");
            table.AddItem("Struggle");
            table.AddItem("Inform");
            table.AddItem("Bestow");
            table.AddItem("Postpone");
            table.AddItem("Expose");
            table.AddItem("Haggle");
            table.AddItem("Imprison");
            table.AddItem("Release");
            table.AddItem("Celebrate");
            table.AddItem("Develop");
            table.AddItem("Travel");
            table.AddItem("Block");
            table.AddItem("Harm");
            table.AddItem("Debase");
            table.AddItem("Overindulge");
            table.AddItem("Adjourn");
            table.AddItem("Adversity");
            table.AddItem("Kill");
            table.AddItem("Disrupt");
            table.AddItem("Usurp");
            table.AddItem("Create");
            table.AddItem("Betray");
            table.AddItem("Agree");
            table.AddItem("Abuse");
            table.AddItem("Oppress");
            table.AddItem("Inspect");
            table.AddItem("Ambush");
            table.AddItem("Spy");
            table.AddItem("Attach");
            table.AddItem("Carry");
            table.AddItem("Open");
            table.AddItem("Carelessness");
            table.AddItem("Ruin");
            table.AddItem("Extravagance");
            table.AddItem("Trick");
            table.AddItem("Arrive");
            table.AddItem("Postpone");
            table.AddItem("Divide");
            table.AddItem("Refuse");
            table.AddItem("Mistrust");
            table.AddItem("Deceive");
            table.AddItem("Cruelty");
            table.AddItem("Intolerance");
            table.AddItem("Trust");
            table.AddItem("Excitement");
            table.AddItem("Activity");
            table.AddItem("Assist");
            table.AddItem("Care");
            table.AddItem("Negligence");
            table.AddItem("Passion");
            table.AddItem("Work hard");
            table.AddItem("Control");
            table.AddItem("Attract");
            table.AddItem("Failure");
            table.AddItem("Pursue");
            table.AddItem("Vengeance");
            table.AddItem("Proceedings");
            table.AddItem("Dispute");
            table.AddItem("Punish");
            table.AddItem("Guide");
            table.AddItem("Transform");
            table.AddItem("Overthrow");
            table.AddItem("Oppress");
            table.AddItem("Change");

            return table.GetResult();
        }

        int _getFateBase(int chaosFactor, string odds)
        {
            switch (odds)
            {
                case "Impossible": 
                    switch (chaosFactor)
                    {
                        case 1: return -20;
                        case 2: return 0;
                        case 3: return 0;
                        case 4: return 5;
                        case 5: return 5;
                        case 6: return 10;
                        case 7: return 15;
                        case 8: return 25;
                        default: return 50;
                    }
                case "No way":
                    switch (chaosFactor)
                    {
                        case 1: return 0;
                        case 2: return 5;
                        case 3: return 5;
                        case 4: return 10;
                        case 5: return 15;
                        case 6: return 25;
                        case 7: return 35;
                        case 8: return 50;
                        default: return 75;
                    }
                case "Very unlikely":
                    switch (chaosFactor)
                    {
                        case 1: return 5;
                        case 2: return 5;
                        case 3: return 10;
                        case 4: return 15;
                        case 5: return 25;
                        case 6: return 45;
                        case 7: return 50;
                        case 8: return 65;
                        default: return 85;
                    }
                case "Unlikely":
                    switch (chaosFactor)
                    {
                        case 1: return 5;
                        case 2: return 10;
                        case 3: return 15;
                        case 4: return 20;
                        case 5: return 35;
                        case 6: return 50;
                        case 7: return 55;
                        case 8: return 75;
                        default: return 90;
                    }
                case "50/50":
                    switch (chaosFactor)
                    {
                        case 1: return 10;
                        case 2: return 15;
                        case 3: return 25;
                        case 4: return 35;
                        case 5: return 50;
                        case 6: return 65;
                        case 7: return 75;
                        case 8: return 85;
                        default: return 95;
                    }
                case "Somewhat likely":
                    switch (chaosFactor)
                    {
                        case 1: return 20;
                        case 2: return 25;
                        case 3: return 45;
                        case 4: return 50;
                        case 5: return 65;
                        case 6: return 80;
                        case 7: return 85;
                        case 8: return 90;
                        default: return 95;
                    }
                case "Likely":
                    switch (chaosFactor)
                    {
                        case 1: return 25;
                        case 2: return 35;
                        case 3: return 50;
                        case 4: return 55;
                        case 5: return 75;
                        case 6: return 85;
                        case 7: return 90;
                        case 8: return 95;
                        default: return 100;
                    }
                case "Very likely":
                    switch (chaosFactor)
                    {
                        case 1: return 45;
                        case 2: return 50;
                        case 3: return 65;
                        case 4: return 75;
                        case 5: return 85;
                        case 6: return 90;
                        case 7: return 95;
                        case 8: return 95;
                        default: return 105;
                    }
                case "Near sure thing":
                    switch (chaosFactor)
                    {
                        case 1: return 50;
                        case 2: return 55;
                        case 3: return 75;
                        case 4: return 80;
                        case 5: return 90;
                        case 6: return 95;
                        case 7: return 95;
                        case 8: return 100;
                        default: return 115;
                    }
                case "A sure thing":
                    switch (chaosFactor)
                    {
                        case 1: return 55;
                        case 2: return 65;
                        case 3: return 80;
                        case 4: return 85;
                        case 5: return 90;
                        case 6: return 95;
                        case 7: return 95;
                        case 8: return 110;
                        default: return 125;
                    }
                case "Has to be":
                    switch (chaosFactor)
                    {
                        case 1: return 80;
                        case 2: return 85;
                        case 3: return 90;
                        case 4: return 95;
                        case 5: return 95;
                        case 6: return 100;
                        case 7: return 100;
                        case 8: return 130;
                        default: return 145;
                    }
                default:
                    throw new Exception("Unrecognized odds: " + odds);
            } // switch (odds)
        } // int _getFateBase()

    } // class GmEmulator 
} // namespace DungeonCohort
