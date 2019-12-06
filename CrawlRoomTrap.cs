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
        public string Effect;
        public bool IsMagic = false;
        public string Location;
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
            CrawlRoomTrap beam = _chooseBeamEffect();

            typeTable.AddItem(new CrawlRoomTrap
            {
                DamageDice = dice,
                DamageType = "Falling",
                Location = "The floor",
                Type = "Trap door",
                // Trap door content?
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                DamageDice = dice,
                Location = _chooseLocation(),
                Type = "Gas",
                // Gas type?
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                AttackBonus = attk,
                DamageDice = dice,
                DamageType = "Piercing",
                Location = "The floor",
                Type = "Spikes",
                // trap coating?
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                AttackBonus = attk,
                DamageDice = dice,
                DamageType = "Piercing",
                Location = _chooseLocation(),
                Type = "Darts",
                // trap coating?
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                AttackBonus = attk,
                DamageDice = dice,
                DamageType = "Slashing",
                Location = _chooseLocation(),
                Type = "Blades",
                // trap coating?
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                DamageDice = dice,
                DamageType = "Bludgeoning",
                Location = "The ceiling",
                Type = "Falling Blocks",
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                Location = "The ceiling",
                DamageDice = "None",
                DamageType = "Restrained",
                Type = "Net",
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                AttackBonus = attk,
                DamageDice = dice,
                DamageType = beam.DamageType,
                Effect = beam.Effect,
                IsMagic = true,
                Location = _chooseLocation(),
                Type = "Magic beam",
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                DamageDice = dice,
                DamageType = beam.DamageType,
                Effect = beam.Effect,
                IsMagic = true,
                Location = _chooseLocation(),
                Trigger = "Viewing",
                Type = "Magic symbol",
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                DamageDice = dice,
                DamageType = beam.DamageType,
                Effect = beam.Effect,
                IsMagic = true,
                Location = _chooseLocation(),
                Type = "Magic blast",
                // radius?
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                Location = "The ceiling",
                Type = "Cage drops from above"
            }); 
            typeTable.AddItem(new CrawlRoomTrap
            {
                Location = "The room",
                Type = "Room Trap",
                // exits blocked?
                // room trap type?
            });      
            typeTable.AddItem(new CrawlRoomTrap
            {
                Location = "The exit",
                Type = ""
                // exit blocker?
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                DamageType = "Falling",
                Location = _chooseLocation(),
                Type = "Reverse gravity",
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                AttackBonus = attk,
                DamageDice = dice,
                DamageType = "Piercing",
                Location = _chooseLocation(),
                Type = "Spears",
                // coating
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                AttackBonus = attk,
                DamageDice = dice,
                DamageType = "Piercing",
                Location = _chooseLocation(),
                Type = "Arrows",
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
            // not just a string result
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

        private CrawlRoomTrap _chooseBeamEffect()
        {
            var table = new RandomTable<CrawlRoomTrap>();

            table.AddItem(new CrawlRoomTrap
            {
                Effect = "Armor damaged -1 AC on failed save",
                DamageType = "Acid"
            }); 
            table.AddItem(new CrawlRoomTrap
            {
                Effect = "Movement halved on failed save",
                DamageType = "Cold"
            });          
            table.AddItem(new CrawlRoomTrap
            {
                Effect = "Unattended flamable items are destroyed",
                DamageType = "Fire"
            });
            table.AddItem(new CrawlRoomTrap
            {
                Effect = "Concentration checks at disadvantage",
                DamageType = "Psychic"
            });
            table.AddItem(new CrawlRoomTrap
            {
                Effect = "Those slain rise as zombies",
                DamageType = "Necrotic"
            });
            table.AddItem(new CrawlRoomTrap
            {
                Effect = "Save or be blinded",
                DamageType = "Radiant"
            });
            table.AddItem(new CrawlRoomTrap
            {
                Effect = "Strikes all in a straight line from the source",
                DamageType = "Lightning"
            });
            table.AddItem(new CrawlRoomTrap
            {
                Effect = "Roll for wandering monster chance from noise",
                DamageType = "Thunder"
            });
            table.AddItem(new CrawlRoomTrap
            {
                Effect = "Save or knocked back 10 feet",
                DamageType = "Force"
            });
            table.AddItem(new CrawlRoomTrap
            {
                Effect = "Take one level of exhaustion per tier",
                DamageType = "Exhaustion"
            });
            table.AddItem(new CrawlRoomTrap
            {
                Effect = "Save or acquire Fear condition",
                DamageType = "Fear"
            }); 
            table.AddItem(new CrawlRoomTrap
            {
                Effect = "Save or incapacitated",
                DamageType = "Incapacitation"
            });
            table.AddItem(new CrawlRoomTrap
            {
                Effect = "Save or paralyzed",
                DamageType = "Paralyzation"
            });
            table.AddItem(new CrawlRoomTrap
            {
                Effect = "Save or petrified",
                DamageType = "Petrification"
            });
            table.AddItem(new CrawlRoomTrap
            {
                Effect = "Save or stunned",
                DamageType = "Stunning"
            });


            return table.GetResult();
        }

        private string _chooseLocation()
        {
            var table = new RandomTable<string>();

            table.AddItem("The wall ahead");
            table.AddItem("The ceiling");
            table.AddItem("The right wall");
            table.AddItem("The left wall");
            table.AddItem("The wall behind");

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
