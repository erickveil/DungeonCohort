using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class CrawlRoomTrap
    {
        public int AttackBonus;
        public string DamageDice;
        public string DamageType;
        public int DC;
        public string Disarm;
        public bool IsMagic = false;
        public string Severity;
        public string TrapDoorContents;
        public string Trigger;
        public string Type;


        public void InitAsDoorTrap(int tier)
        {

        }

        private void _setType(int tier)
        {
            var typeTable = new RandomTable<CrawlRoomTrap>();
            string severity = _chooseSeverity();
            string disarm = _chooseDisarm();
            int dc = _chooseDc(severity);
            int attk = _chooseAttkBonus(severity);
            string dice = _chooseDamage(tier, severity);
            string damageType = _chooseDamageType();

            typeTable.AddItem(new CrawlRoomTrap
            {
                DamageDice = dice,
                DamageType = "Falling",
                Type = "Trap door",
                // Trap door content?
            }); 
            typeTable.AddItem(new CrawlRoomTrap
            {
                DamageDice = dice,
                Type = "Gas",
                // Gas type?
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                AttackBonus = attk,
                DamageDice = dice,
                DamageType = "Piercing",
                Type = "Spikes",
                // trap direction?
                // trap coating?
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                AttackBonus = attk,
                DamageDice = dice,
                DamageType = "Piercing",
                Type = "Darts",
                // trap direction?
                // trap coating?
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                AttackBonus = attk,
                DamageDice = dice,
                DamageType = "Slashing",
                Type = "Blades",
                // trap direction?
                // trap coating?
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                DamageDice = dice,
                DamageType = "Bludgeoning",
                Type = "Falling Blocks",
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                Type = "Net"
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                AttackBonus = attk,
                DamageDice = dice,
                DamageType = damageType,
                IsMagic = true,
                Type = "Magic beam",
                // trap direction?
                // beam effect
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                IsMagic = true,
                Trigger = "Viewing",
                Type = "Magic symbol",
                // trap effect 
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                AttackBonus = attk,
                DamageDice = dice,
                IsMagic = true,
                Type = "Magic Blast",
                // trap effect?
                // radius?
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                Type = "Cage drops from above"
            }); 
            typeTable.AddItem(new CrawlRoomTrap
            {
                Type = "Room Trap",
                // exits blocked?
                // room trap type?
            });      
            typeTable.AddItem(new CrawlRoomTrap
            {
                Type = ""
                // exit blocker?
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                DamageType = "Falling",
                Type = "Reverse gravity",
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                AttackBonus = attk,
                DamageDice = dice,
                DamageType = "Piercing",
                Type = "Spears",
                // trap directon
                // coating
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                AttackBonus = attk,
                DamageDice = dice,
                DamageType = "Piercing",
                Type = "Arrows",
                // trap direciton
                // coating
            });

            var trap = typeTable.GetResult();
            AttackBonus = trap.AttackBonus;
            DamageDice = trap.DamageDice;
            DamageType = trap.DamageType;
            DC = dc;
            Disarm = disarm;
            IsMagic = false;
            Severity = severity;
            Trigger = trap.Trigger;
            Type = trap.Type;

        }

        private string _chooseTrapDoorContents()
        {
            // TODO: trap doors are a subtype of trap and get a full object result
            var table = new RandomTable<string>();
            table.AddItem("Drops to empty shaft", 3);
            table.AddItem("Spikes"); // coating
            table.AddItem("Monster"); // guardian type monster
            table.AddItem("Incidental treasure"); // treasure
            table.AddItem("Liquid"); // trap pool
            table.AddItem("Straight drop to next level");
            table.AddItem("Slide to next level"); // no damage
            table.AddItem("Teleport to another part of the dungeon and dropped to the floor");
            table.AddItem("Blender blades. Roll damage twice");
            table.AddItem("Gravity reverses each turn. Save to escape each reversal");
            table.AddItem("Gas"); // gas type
            table.AddItem("Straw. No damage");
            return table.GetResult();
        }

        private string _chooseSeverity()
        {
            var severityTable = new RandomTable<string>();
            severityTable.AddItem("Setback", 2);
            severityTable.AddItem("Dangerous", 4);
            severityTable.AddItem("Deadly");
            return severityTable.GetResult();
        }

        private string _chooseDisarm()
        {
            var disarmTable = new RandomTable<string>();

            // TODO: add diarms

            return disarmTable.GetResult();
        }

        private int _chooseDc(string severity)
        {
            var dice = Dice.Instance;
            if (severity == "Setback") { return dice.RandomNumber(10, 11); }
            if (severity == "Dangerous") { return dice.RandomNumber(12, 15); }
            return dice.RandomNumber(16, 20);
        }

        private int _chooseAttkBonus(string severity)
        {
            var dice = Dice.Instance;
            if (severity == "Setback") { return dice.RandomNumber(3, 5); }
            if (severity == "Dangerous") { return dice.RandomNumber(6, 8); }
            return dice.RandomNumber(9, 12);
        }

        private string _chooseDamage(int tier, string severity)
        {
            switch (tier)
            {
                case 1:
                    if (severity == "Setback") { return "1d10"; }
                    if (severity == "Dangerous") { return "2d10"; }
                    return "4d10";
                case 2:
                    if (severity == "Setback") { return "2d10"; }
                    if (severity == "Dangerous") { return "4d10"; }
                    return "10d10";
                case 3:
                    if (severity == "Setback") { return "4d10"; }
                    if (severity == "Dangerous") { return "10d10"; }
                    return "18d10";
                default:
                    if (severity == "Setback") { return "10d10"; }
                    if (severity == "Dangerous") { return "18d10"; }
                    return "24d10";
            }
        }

        private string _chooseDamageType()
        {
            return "";

        }
    }
}
