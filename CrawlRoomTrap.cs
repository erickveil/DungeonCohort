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
        public int AttackBonus = -1;
        public string Coating = "";
        public string DamageDice = "";
        public string DamageType = "";
        public int DC = -1;
        public string Disarm = "";
        public string Effect = "";
        public string ExitBlocker = "";
        public bool IsMagic = false;
        public string Location = "";
        public int Radius = 0;
        public string Severity = "";
        public string TrapDoorContents = "";
        public Encounter TrapMonster = null;
        public LootTableResult TrapTreasure = null;
        public string Trigger = "";
        public string Type = "";

        public string ToString(bool useEncounters = false)
        {
            string desc = ""
                + (Severity == "" ? "" : Severity + " ")
                + (IsMagic ? "Magical " : "")
                + Type + " "
                + (Location == "" ? "" : " From " + Location + " ")
                + (Coating == "" ? "" : "Coated with " + Coating + " ")
                + "("
                + (Radius == 0 ? "" : Radius.ToString() + " ft radius; ")
                + (AttackBonus == -1 ? "" : "To Hit: +" + AttackBonus.ToString() + "; ")
                + (DamageDice == "" ? "" : DamageDice + " " + DamageType + "; ")
                + (DC == -1 ? "" : "DC: " + DC.ToString() + "; ")
                + ")"
                + (Trigger == "" ? "" : "\nTrigged by: " + Trigger + "; ")
                + (ExitBlocker == "" ? "" : "\nExits blocked: " + ExitBlocker + "; ")
                + (Effect == "" ? "" : "\nEffect: " + Effect + "; ")
                + (Disarm == "" ? "" : "\nTo disarm: " + Disarm + "; ")
                + (TrapDoorContents == "" ? "" : "\nContains: " + TrapDoorContents + "; ")
                + ( (!(TrapMonster is null) && useEncounters) ? "\nMonster: " + TrapMonster.ToString() + "; " : "" )
                + ( TrapTreasure is null ? "" : "\nTreasure: " + TrapTreasure.ToString() + "; ")
                ;
            return desc;
        }

        public void InitAsDoorTrap(int tier)
        {
            _setType(tier, isDoor: true);
        }

        public void InitAsRoomTrap(int tier)
        {
            string severity = ChooseSeverity();
            string disarm = _chooseDisarm();
            int dc = ChooseDc(severity);
            string trigger = _chooseTrapTrigger();

            Location = "";
            Type = "Room Trap";
            ExitBlocker = _chooseExitBlocker(tier, severity, true);
            Trigger = trigger;
            Effect = _chooseRoomTrapEffect();
            DC = dc;
            Disarm = disarm;
            Severity = severity;
        }

        public void InitTrap(int tier)
        {
            _setType(tier, isDoor: false);
        }

        private void _setType(int tier, bool isDoor)
        {
            var typeTable = new RandomTable<CrawlRoomTrap>();
            string severity = ChooseSeverity();
            string disarm = _chooseDisarm();
            int dc = ChooseDc(severity);
            int attk = ChooseAttkBonus(severity);
            string damageDice = ChooseDamage(tier, severity);
            CrawlRoomTrap beam = _chooseBeamEffect();
            Dice dice = Dice.Instance;
            bool isCoated = dice.Roll(1, 6) <= 2;
            string coating = isCoated ? ChooseCoating() : "";
            CrawlRoomTrap trapdoor = _chooseTrapDoorTrap(tier, severity);
            int radius = dice.Roll(1, 6) * 5;
            string trigger = isDoor 
                ? _chooseDoorTrapTrigger() 
                : _chooseTrapTrigger();

            typeTable.AddItem(trapdoor);

            typeTable.AddItem(new CrawlRoomTrap
            {
                DamageDice = damageDice,
                Effect = ChooseGasType(),
                Location = ChooseLocation(),
                Trigger = trigger,
                Type = "Gas",
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                AttackBonus = attk,
                Coating = coating,
                DamageDice = damageDice,
                DamageType = "Piercing",
                Location = "The floor",
                Trigger = trigger,
                Type = "Spikes",
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                AttackBonus = attk,
                Coating = coating,
                DamageDice = damageDice,
                DamageType = "Piercing",
                Location = ChooseLocation(),
                Trigger = trigger,
                Type = "Darts",
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                AttackBonus = attk,
                Coating = coating,
                DamageDice = damageDice,
                DamageType = "Slashing",
                Location = ChooseLocation(),
                Trigger = trigger,
                Type = "Blades",
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                DamageDice = damageDice,
                DamageType = "Bludgeoning",
                Location = "The ceiling",
                Trigger = trigger,
                Type = "Falling Blocks",
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                Location = "The ceiling",
                DamageDice = "None",
                DamageType = "Restrained",
                Trigger = trigger,
                Type = "Net",
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                AttackBonus = attk,
                DamageDice = damageDice,
                DamageType = beam.DamageType,
                Effect = beam.Effect,
                IsMagic = true,
                Location = ChooseLocation(),
                Trigger = trigger,
                Type = "Beam",
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                DamageDice = damageDice,
                DamageType = beam.DamageType,
                Effect = beam.Effect,
                IsMagic = true,
                Location = ChooseLocation(),
                Trigger = "Viewing",
                Type = "Symbol",
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                DamageDice = damageDice,
                DamageType = beam.DamageType,
                Effect = beam.Effect,
                IsMagic = true,
                Location = ChooseLocation(),
                Radius = radius,
                Trigger = trigger,
                Type = "Blast",
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                Location = "The ceiling",
                Trigger = trigger,
                Type = "Cage drops from above"
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                Location = "",
                Type = "Room Trap",
                ExitBlocker = _chooseExitBlocker(tier, severity, true),
                Trigger = trigger,
                Effect = _chooseRoomTrapEffect(),
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                Location = "",
                Type = "Progress blocked",
                Trigger = trigger,
                ExitBlocker = _chooseExitBlocker(tier, severity, false),
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                DamageType = "Falling",
                Location = ChooseLocation(),
                Trigger = trigger,
                IsMagic = true,
                Type = "Reverse gravity",
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                AttackBonus = attk,
                Coating = coating,
                DamageDice = damageDice,
                DamageType = "Piercing",
                Location = ChooseLocation(),
                Trigger = trigger,
                Type = "Spears",
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                AttackBonus = attk,
                Coating = coating,
                DamageDice = damageDice,
                DamageType = "Piercing",
                Location = ChooseLocation(),
                Trigger = trigger,
                Type = "Arrows",
            });
            typeTable.AddItem(new CrawlRoomTrap
            {
                Type = "Sleep spell trap for " + dice.Roll(13, 8) + 
                " hp of creatures in ascending order of total hp, no save " +
                "(undead and immune to charm not affected)"
            });

            var trap = typeTable.GetResult();

            AttackBonus = trap.AttackBonus;
            Coating = trap.Coating;
            DamageDice = trap.DamageDice;
            DamageType = trap.DamageType;
            DC = dc;
            Disarm = disarm;
            Effect = trap.Effect;
            ExitBlocker = trap.ExitBlocker;
            IsMagic = trap.IsMagic;
            Location = trap.Location;
            Radius = trap.Radius;
            Severity = severity;
            TrapDoorContents = trap.TrapDoorContents;
            TrapMonster = trap.TrapMonster;
            TrapTreasure = trap.TrapTreasure;
            Trigger = trap.Trigger;
            Type = trap.Type;

        }

        private string _chooseTrapTrigger()
        {
            var table = new RandomTable<string>();

            table.AddItem("Stepping on a pressure plate");
            table.AddItem("Touching a trigger item");
            table.AddItem("Opening something");
            table.AddItem("Moving something");
            table.AddItem("Tripwire");
            table.AddItem("Disturbing spider webs");
            table.AddItem("Breaking a beam of light");
            table.AddItem("Pulling the wrong lever");
            table.AddItem("Living being enters the area");
            table.AddItem("Touching or dispelling the illusionary treasure");
            table.AddItem("Attacking the illusionary monster");
            table.AddItem("Disarming decoy tripwire");
            table.AddItem("Failing to disarm trap");

            return table.GetResult();
        }

        private string _chooseDoorTrapTrigger()
        {
            var table = new RandomTable<string>();

            table.AddItem("Stepping on a pressure plate");
            table.AddItem("Touching the doorknob");
            table.AddItem("Opening the door");
            table.AddItem("Moving through the door");
            table.AddItem("Tripwire");
            table.AddItem("Disturbing spider webs");
            table.AddItem("Examining door and failing save");
            table.AddItem("Failing to pick lock");
            table.AddItem("Attempting to pick lock");
            table.AddItem("Failing to disarm trap");
            table.AddItem("Pulling lever next to door");
            table.AddItem("Disarm decoy tripwire");

            return table.GetResult();

        }

        private string _chooseRoomTrapEffect()
        {
            var table = new RandomTable<string>();
            string direction = ChooseLocation();
            string pool = _chooseTrapDoorPoolEffect();
            string coating = ChooseCoating();
            var monsterGen = new EncounterFactory();
            //var encounter = monsterGen.PickRandomEncounter("Trap", false);
            /* ugggg if i want to set an encounter, i'd have to create 
             * *another* trap list table instead of strings.
             */

            table.AddItem("Secret panels open up from " + direction
                + " and deposit an encounter into the room");
            table.AddItem("Room fills with fluid in several turns. " +
                "Skill challenge to escape. " + pool);
            table.AddItem("Moving dungeon section slides, rotates, or " +
                "elivates. All exits now lead elsewhere.");
            table.AddItem("Teleportation of all room occupants to " +
                "another room");
            table.AddItem("Walls close in to smash party in several turns. " +
                "Skill challenge to escape.");
            table.AddItem("Spikes come out of entire floor: coated in " 
                + coating);
            table.AddItem("Oven room heats up: 1d8 fire damage, " +
                "each round");
            table.AddItem("Icebox room freezes occupants: 1d8 cold damage, " +
                "each round");
            table.AddItem("Tesla chamber: 1d8 lighning damage, " +
                "each round");
            table.AddItem("Necrotic chamber: 1d8 necrotic damage each " +
                "round");
            table.AddItem("High-pitched sound: 1d8 thunder damage each round");

            return table.GetResult();
        }

        private string _chooseExitBlocker(int tier, string severity, 
            bool isHardBlock)
        {
            var table = new RandomTable<string>();
            string dmg = ChooseDamage(tier, severity);
            string dc = ChooseDc(severity).ToString();

            table.AddItem("Solid stone slap drops from ceiling");
            table.AddItem("Portcuillus drops from ceiling");
            table.AddItem("Iron pannel drops from ceiling");
            table.AddItem("Doors slam shut");
            table.AddItem("Doors vanish behind illusion of wall");
            table.AddItem("Room rises, Exits sink into floor");
            table.AddItem("Ice wall. AC "
                + dc + ", 30 hp, " + dmg 
                + " cold damage in area after destroyed. DC "
                + dc + " con save for half");
            table.AddItem("Invisible force wall. " + dmg 
                + " force damage. DC " + dc + " dex save for half");

            if (isHardBlock) { return table.GetResult(); }

            table.AddItem("Blades spin out around exit: " + dmg
                + " slashing damage. DC " + dc + " dex save for half");
            table.AddItem("Fire wall. "
                + dmg + " fire damage to pass through. DC " 
                + dc + " dex save for half");
            table.AddItem("Lightining wall. " + dmg
                + " lighting damage. DC " + dc + " dex save for half");
            table.AddItem("Psychic barrier. " + dmg 
                + " psychic damage. DC " + dc + " int save for half");

            return table.GetResult();
        }

        private string _chooseTrapDoorPoolEffect()
        {
            var table = new RandomTable<string>();

            table.AddItem("Water. Half falling damage. Flames extinguished");
            table.AddItem("Acid. Damage every round");
            table.AddItem("Oil. Flames explode for extra fire damage. " +
                "Climb out at disadvantage.");
            table.AddItem("Poisoned. Save against poison condition");
            table.AddItem("Diseased: " + _chooseDisease());
            table.AddItem("Ofal and feces");
            table.AddItem("Lava. Damage every round.");

            return table.GetResult();
        }

        private CrawlRoomTrap _chooseTrapDoorTrap(int tier, string severity)
        {
            var table = new RandomTable<CrawlRoomTrap>();
            var lootGen = new TreasureFactory();
            var loot = lootGen.GetIndividualTreasure(1);
            var dice = Dice.Instance;
            bool isCoated = dice.Roll(1, 6) <= 2;
            var coating = isCoated ? ChooseCoating() : "";
            var monsterGen = new EncounterFactory();
            //var monster = monsterGen.PickMooks(1, "Trap", false);
            string damageDice = ChooseDamage(tier, severity);

            table.AddItem(new CrawlRoomTrap
            {
                DamageType = "Falling",
                DamageDice = damageDice, 
                Coating = "",
                TrapDoorContents = "Drops to an empty shaft",
                TrapMonster = null,
                TrapTreasure = null,
                Trigger = "Stepping on trapdoor",
                Type = "Trapdoor"
            });

            table.AddItem(new CrawlRoomTrap
            {
                DamageType = "Falling",
                DamageDice = damageDice, 
                Coating = "",
                Effect = "",
                TrapDoorContents = "Incidental treasure",
                TrapMonster = null,
                TrapTreasure = loot,
                Trigger = "Stepping on trapdoor",
                Type = "Trapdoor"
            });

            table.AddItem(new CrawlRoomTrap
            {
                DamageType = "Falling",
                DamageDice = damageDice, 
                Coating = coating,
                Effect = "",
                TrapDoorContents = "Spikes",
                TrapMonster = null,
                TrapTreasure = null,
                Trigger = "Stepping on trapdoor",
                Type = "Trapdoor"
            });

            table.AddItem(new CrawlRoomTrap
            {
                DamageType = "Falling",
                DamageDice = damageDice, 
                Coating = "",
                Effect = "",
                TrapDoorContents = "Monster",
                //TrapMonster = monster,
                TrapTreasure = null,
                Trigger = "Stepping on trapdoor",
                Type = "Trapdoor"
            });

            table.AddItem(new CrawlRoomTrap
            {
                DamageType = "Falling",
                DamageDice = damageDice, 
                Coating = "",
                Effect = _chooseTrapDoorPoolEffect(),
                TrapDoorContents = "Liquid", 
                TrapMonster = null,
                TrapTreasure = null,
                Trigger = "Stepping on trapdoor",
                Type = "Trapdoor"
            });

            table.AddItem(new CrawlRoomTrap
            {
                DamageType = "Falling",
                DamageDice = damageDice, 
                Coating = "",
                Effect = "",
                TrapDoorContents = "Straight drop to next level",
                TrapMonster = null,
                TrapTreasure = null,
                Trigger = "Stepping on trapdoor",
                Type = "Trapdoor"
            });

            table.AddItem(new CrawlRoomTrap
            {
                DamageType = "None",
                DamageDice = "", 
                Coating = "",
                Effect = "",
                TrapDoorContents = "Slide to next level",
                TrapMonster = null,
                TrapTreasure = null,
                Trigger = "Stepping on trapdoor",
                Type = "Trapdoor"
            });

            table.AddItem(new CrawlRoomTrap
            {
                DamageType = "Falling",
                DamageDice = damageDice, 
                Coating = "",
                Effect = "",
                TrapDoorContents = "Teleport to another part of the dungeon " +
                "and dropped to the floor",
                TrapMonster = null,
                TrapTreasure = null,
                Trigger = "Stepping on trapdoor",
                Type = "Trapdoor"
            });

            table.AddItem(new CrawlRoomTrap
            {
                DamageType = "Falling/Slashing",
                DamageDice = damageDice, 
                Coating = "",
                Effect = "",
                TrapDoorContents = "Blender blades, roll damage twice",
                TrapMonster = null,
                TrapTreasure = null,
                Trigger = "Stepping on trapdoor",
                Type = "Trapdoor"
            });

            table.AddItem(new CrawlRoomTrap
            {
                DamageType = "Falling",
                DamageDice = damageDice, 
                Coating = "",
                Effect = "",
                TrapDoorContents = "Gravity reverses each turn. Save to " +
                "escape each reversal",
                TrapMonster = null,
                TrapTreasure = null,
                Trigger = "Stepping on trapdoor",
                Type = "Trapdoor"
            });

            table.AddItem(new CrawlRoomTrap
            {
                DamageType = "Falling",
                DamageDice = damageDice,
                Coating = "",
                Effect = ChooseGasType(),
                TrapDoorContents = "Gas",
                TrapMonster = null,
                TrapTreasure = null,
                Trigger = "Stepping on trapdoor",
                Type = "Trapdoor"
            });

            table.AddItem(new CrawlRoomTrap
            {
                DamageType = "None",
                DamageDice = "", 
                Coating = "",
                Effect = "",
                TrapDoorContents = "Straw",
                TrapMonster = null,
                TrapTreasure = null,
                Trigger = "Stepping on trapdoor",
                Type = "Trapdoor"
            });
            table.AddItem(new CrawlRoomTrap
            {
                DamageType = "None",
                DamageDice = "",
                Coating = "",
                Effect = "",
                TrapDoorContents = "Drops victim into a one-way active gate: " 
                + CrawlRoomGate.ChooseGateDestination(),
                TrapMonster = null,
                TrapTreasure = null,
                Trigger = "Stepping on trapdoor",
                Type = "Trapdoor"
            });

            return table.GetResult();
        }

        public static string ChooseGasType()
        {
            var table = new RandomTable<string>();
            string color = _chooseGasColor();
            string odor = _chooseGasOdor() + " scented";
            string gas = color + ", " + odor + " gas: ";

            table.AddItem(gas + "Harmless, obscuring. All blinded in area.");
            table.AddItem(gas + "Poisonous. Save against poison condition.");
            table.AddItem(gas + "Blinding.");
            table.AddItem(gas + "Smelly. Characters smell bad. Double " +
                "wandering monster checks.");
            table.AddItem(gas + "Choking. Save for half damage.");
            table.AddItem(gas + "Sleep. Save or fall unconcious");
            table.AddItem(gas + "Acid damage.");
            table.AddItem(gas + "Flamable. Explodes if open flames are " +
                "within cloud.");
            table.AddItem(gas + "Exhausting. Take one level of exhaustion " +
                "per tier.");
            table.AddItem(gas + "Fright gas. Save against Fear condition.");
            table.AddItem(gas + "Incapacitating. Save or can't take " +
                "actions or reactions.");
            table.AddItem(gas + "Paralyzing. Save against Paralyzed " +
                "condition.");
            table.AddItem(gas + "Petrification. Save against Petrified " +
                "condition.");
            table.AddItem(gas + "Stunning. Save against stunning condition.");
            table.AddItem(gas + "Disease: " + _chooseDisease());
            table.AddItem(gas + "Confusion. Save or attack random nearby " +
                "creature or PC.");
            table.AddItem(gas + "Polymorph: " + _choosePolymorphForm());

            return table.GetResult();
        }

        public static string _choosePolymorphForm()
        {
            var table = new RandomTable<string>();

            table.AddItem("Mouse");
            table.AddItem("Frog");
            table.AddItem("Goblin");
            table.AddItem("Orc");
            table.AddItem("Troll");
            table.AddItem("Monkey");
            table.AddItem("Snake (non-poisonous)");
            table.AddItem("Ogre");
            table.AddItem("Dretch");
            table.AddItem("Lemure");
            table.AddItem("Nupperibo");
            table.AddItem("Maggot");
            table.AddItem("Goat");
            table.AddItem("Gray Ooze");
            table.AddItem("Black Pudding");
            table.AddItem("Giant");
            table.AddItem("Fish");
            table.AddItem("Pig");
            table.AddItem("Giant Rat");
            table.AddItem("Potted Plant");

            return table.GetResult();
        }

        public static string _chooseGasColor()
        {
            var table = new RandomTable<string>();

            table.AddItem("Invisible");
            table.AddItem("Green");
            table.AddItem("White");
            table.AddItem("Black");
            table.AddItem("Blue");
            table.AddItem("Yellow");
            table.AddItem("Red");
            table.AddItem("Orange");
            table.AddItem("Purple");

            return table.GetResult();

        }

        public static string _chooseGasOdor()
        {
            var table = new RandomTable<string>();

            table.AddItem("Odorless");
            table.AddItem("Rotten eggs");
            table.AddItem("Sweet smelling");
            table.AddItem("Floral");
            table.AddItem("Nausiating");
            table.AddItem("Eye-watering");
            table.AddItem("Pungent");
            table.AddItem("Acrid");

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

        public static string ChooseLocation()
        {
            var table = new RandomTable<string>();

            table.AddItem("The wall ahead");
            table.AddItem("The ceiling");
            table.AddItem("The right wall");
            table.AddItem("The left wall");
            table.AddItem("The wall behind");

            return table.GetResult();
        }

        public static string ChooseSeverity()
        {
            var severityTable = new RandomTable<string>();
            severityTable.AddItem("Setback", 2);
            severityTable.AddItem("Dangerous", 4);
            severityTable.AddItem("Deadly");
            return severityTable.GetResult();
        }

        private string _chooseDisarm()
        {
            var table = new RandomTable<string>();

            table.AddItem("Three successful castings of dispel magic " +
                "disables the device.");
            table.AddItem("PC may make an Intelegence (Arcana) check " +
                "as an action to disable the magic that operates the device.");
            table.AddItem("Rusty chains snake across the ceiling, " +
                "disappearing into holes on either wall.");
            table.AddItem("Three brass floor plates, nearly invisible " +
                "beneath the dust and detritus.");
            table.AddItem("An eroded bas-relief of a grinning " +
                "Pan-like figure, its fingers appear to be moveable.");
            table.AddItem("A shallow gutter runs along the far wall, " +
                "with a loose brick restricting the flow of water " +
                "through it.");
            table.AddItem("What appears to be a keyhole is discover " +
                "behind a loose stone.");
            table.AddItem("A rusted and jammed lever is found beneath " +
                "a discarded pile of clothing.");
            table.AddItem("A row of fake-emerald buttons on the wall, " +
                "covered in cobwebs.");
            table.AddItem("Three stones are arranged in a circle on a " +
                "lead pressure plate.");
            table.AddItem("A painting of an octopus is found in a far " +
                "corner, three of its arms appear depressible.");
            table.AddItem("A foot-long strip of iron is set into the " +
                "ceiling, with a small magnet at one end.");
            table.AddItem("A small wooden door opens to a panel filled " +
                "with strange metal gears.");
            table.AddItem("Three tiny brass levers in a hand-sized " +
                "hole in the floor.");
            table.AddItem("A moldy rope lies on the floor, leading to a " +
                "pulley lost in the shadows of the ceiling.");
            table.AddItem("Four keyhole sized openings along the bottom " +
                "of a door.");
            table.AddItem("A magical rune glows red when touched.");
            table.AddItem("A small statuette of an elephant lies beside " +
                "a small stone pedestal.");
            table.AddItem("A loose block in the ceiling appears to be " +
                "hooked to a chain above.");
            table.AddItem("Three counterweights hang on ropes just inside " +
                "the door.");
            table.AddItem("A bas-relief of a demonic face has " +
                "depressible eyes.");
            table.AddItem("A camouflaged metal door on one wall conceals " +
                "a copper lever.");
            table.AddItem("Magic runes spell out “Erase Me” with Read Magic.");
            table.AddItem("A statue of a wizened sage has moveable arms.");
            table.AddItem("An abandoned bottle contains a key matching " +
                "a concealed hole in the wall.");
            table.AddItem("A loose brick has fallen out of the wall and " +
                "must be replaced.");
            table.AddItem("A pulley disarms the trap, but the rope is " +
                "missing.");
            table.AddItem("A empty gourd hangs from a hook on the wall " +
                "and must be filled with water.");
            table.AddItem("Three couplets of an old poem are scrawled " +
                "on the wall; the missing couplet must be recited aloud.");
            table.AddItem("Two orcs are painted on the floor; erasing " +
                "one disarms, erasing the other sets off trap again.");
            table.AddItem("The trap is not disarm-able, but a detailed " +
                "schematic of the next trap is drawn in chalk upon the floor.");
            table.AddItem("Four loose bricks must be straitened.");
            table.AddItem("Water must be poured upon a leather strap " +
                "hanging over the door to loosen it.");
            table.AddItem("A ceramic cap over the disarming panel must " +
                "be broken open.");
            table.AddItem("A filthy wax seal over the panel must be " +
                "melted away.");
            table.AddItem("A magic mouth appears and demands to know " +
                "the meaning of life.");
            table.AddItem("Five pewter runes in the ceiling must be " +
                "depressed in order.");
            table.AddItem("A console of brass buttons is a decoy; the " +
                "real trap release is hidden beneath.");
            table.AddItem("Detect Magic must be cast to reveal the " +
                "invisible lever.");
            table.AddItem("A statuette of a dog must be broken open to " +
                "reveal a key.");
            table.AddItem("A silver floor panel (20gp value) covers a " +
                "stone lever crawling with centipedes.");
            table.AddItem("A stone chest must be opened to a precise degree.");
            table.AddItem("An empty hourglass must be filled with san" +
                "d and turned upside down.");
            table.AddItem("Three wall levers: two set off the trap again, " +
                "one disarms.");
            table.AddItem("A candle in a wall sconce must be burned down " +
                "to disarm.");
            table.AddItem("A wall sconce must be turned to a right angle.");
            table.AddItem("A chandelier must be pulled down to floor, " +
                "revolved 180 degrees, and sent back up again.");
            table.AddItem("Every candle on a seventeen candle-candelabra " +
                "must be lit; seven candles are missing.");
            table.AddItem("A torch must be applied to a heat-sensitive " +
                "floor panel.");
            table.AddItem("An invisible statue in the corner must have " +
                "both arms lowered.");
            table.AddItem("An imp appears and demands payment to disarm " +
                "the trap.");
            table.AddItem("A globe hangs from the ceiling; Light must be " +
                "cast upon it.");
            table.AddItem("A hollow needle emerges from the wall; " +
                "pricking a finger upon it disarms trap.");
            table.AddItem("A ceramic alligator statue with gaping maw: " +
                "will close maw if fed meat and disarm trap.");
            table.AddItem("A snake-filled pit contains the release lever.");
            table.AddItem("A small ochre jelly (1+1HD) must be coerced " +
                "off the pressure plate it rests upon");
            table.AddItem("The open mouth of a gargoyle must be filled " +
                "with wine or beer.");
            table.AddItem("An illusory wall conceals a control panel.");
            table.AddItem("A release lever at the bottom of a " +
                "sludge-filled well.");
            table.AddItem("Four small toilets line the far wall; all must " +
                "be flushed.");
            table.AddItem("A dagger must be placed into the hand of the " +
                "statue of an impish child.");
            table.AddItem("A complex set of gears is concealed within an " +
                "armoire.");
            table.AddItem("A lever is hidden behind a wine rack.");
            table.AddItem("An empty, moveable bookcase conceals a set of " +
                "rope pulleys.");
            table.AddItem("A fake toadstool, among a patch of real " +
                "ones, may be turned like a doorknob.");
            table.AddItem("A patch of mildew conceals a diagram detailing " +
                "how to disarm the trap.");
            table.AddItem("An unlit torch on the wall must be lit.");
            table.AddItem("The release lever has a hive of angry wasps " +
                "built around it.");
            table.AddItem("An acid-filled crystal ewer on a pedestal " +
                "must be carefully emptied.");
            table.AddItem("A row of clever brass gears is concealed just " +
                "under the plaster on one wall.");
            table.AddItem("A wick leading into a hole in the wall must be " +
                "lit.");
            table.AddItem("A row of skulls upon a ledge high on one wall; " +
                "one contains the detached lever deactivating the trap.");
            table.AddItem("An immense chalk maze drawn into the floor must " +
                "be carefully walked through to completion.");
            table.AddItem("A magic circle scribed into one wall must " +
                "have a corpse placed within it.");
            table.AddItem("A blackened steel wire stretches across " +
                "the ceiling and must be cut.");
            table.AddItem("Forty feet of chain must be pulled from a " +
                "hole in the ceiling; very noisy (check for wandering " +
                "monsters).");
            table.AddItem("An iron spike must be pulled out of the " +
                "stone wall it’s driven into (very difficult!).");
            table.AddItem("A leprechaun is geased to guard the release " +
                "and must be appeased with gold.");
            table.AddItem("A complex set of archaic runes must be " +
                "deciphered and read aloud.");
            table.AddItem("A frayed rope pull-cord is concealed " +
                "behind infested cobwebs.");
            table.AddItem("A nine-headed hydra statue must have its " +
                "heads hacked off.");
            table.AddItem("Acid must be applied to a soapstone plug.");
            table.AddItem("Seven locks must be picked, or the proper " +
                "keys found.");
            table.AddItem("A rude drawing of an elven maiden conceals " +
                "a wall plate.");
            table.AddItem("A magic mouth appears and demands an " +
                "immediate dance recital.");
            table.AddItem("A shallow pool of filthy water conceals " +
                "rusty mechanism; must be dry, clean, and oiled.");
            table.AddItem("A brazier must be filled with coal and lit.");
            table.AddItem("A chair attached to a hidden floor lever must " +
                "be tipped back.");
            table.AddItem("A slimy stone in the wall must be removed, " +
                "turned, and replaced.");
            table.AddItem("A dagger must be placed into a hole; cannot " +
                "be removed afterwards.");
            table.AddItem("A hand-shaped depression in the high ceiling " +
                "must be depressed.");
            table.AddItem("Dust-covered elvish runes on the far wall must " +
                "be read aloud.");
            table.AddItem("A froglike idol must be knelt in front of, " +
                "depressing a hidden floor plate.");
            table.AddItem("A rudely fashioned ceramic face on the wall " +
                "must be broken away to reveal a lever.");
            table.AddItem("Acid must be poured upon a series of thin " +
                "copper filaments.");
            table.AddItem("Three ceiling hooks must be chained " +
                "together and pulled; the chain is missing.");
            table.AddItem("The apparition of a pirate appears and " +
                "demands a bawdy tune.");
            table.AddItem("Three silver wires, nearly invisible, run " +
                "across the floor from either wall.");
            table.AddItem("Five brass levers are concealed behind the " +
                "painting of a grinning ettin.");
            table.AddItem("Rows of colored circles dot the floor. A " +
                "spinning wheel depicts the colors, and hands or feet " +
                "must be placed on the corresponding colors until the " +
                "trap releases. May require multiple participants.");

            return table.GetResult();
        }

        public static int ChooseDc(string severity)
        {
            var dice = Dice.Instance;
            if (severity == "Setback") { return dice.RandomNumber(10, 11); }
            if (severity == "Dangerous") { return dice.RandomNumber(12, 15); }
            return dice.RandomNumber(16, 20);
        }

        public static int ChooseAttkBonus(string severity)
        {
            var dice = Dice.Instance;
            if (severity == "Setback") { return dice.RandomNumber(3, 5); }
            if (severity == "Dangerous") { return dice.RandomNumber(6, 8); }
            return dice.RandomNumber(9, 12);
        }

        public static string ChooseDamage(int tier, string severity)
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

        public static string ChooseCoating()
        {
            var table = new RandomTable<string>();

            table.AddItem("Poison. Save against poison condition");
            table.AddItem("Paralyzing poison. Save against Paralyzed condition");
            table.AddItem("Disease: " + _chooseDisease());

            return table.GetResult();
        }

        public static string _chooseDisease()
        {
            var table = new RandomTable<string>();

            table.AddItem("Tetanus. Jaw and neck muscles painfully contract " +
                "and breathing becomes difficult. Max hp and movement " +
                "halved until cure disease."); 
            table.AddItem("Cackle Feaver. " +
                "https://roll20.net/compendium/dnd5e/Diseases#h-Cackle%20Fever"
                );
            table.AddItem("Sewer Plague. " +
                "https://roll20.net/compendium/dnd5e/Diseases#h-Sewer%20Plague"
                );
            table.AddItem("Sight Rot. " +
                "https://roll20.net/compendium/dnd5e/Diseases#h-Sight%20Rot");
            table.AddItem("Black Fly Filth Fever." +
                "https://dandwiki.com/wiki/Black_Fly_Filth_Fever_(5e_Disease)"
                );
            table.AddItem("Glitch. " +
                "https://dandwiki.com/wiki/Gliched_(5e_Disease)");
            table.AddItem("Miners Plague." +
                "https://dandwiki.com/wiki/Miners_Plague_(5e_Disease)");
            table.AddItem("Necrotic Disease." +
                "https://dandwiki.com/wiki/Necrotic_Disease_(5e_Disease)");
            table.AddItem("Weaver's Feaver." +
                "https://dandwiki.com/wiki/Weaver%27s_Fever_(5e_Disease)");

            return table.GetResult();

        }
    }
}
