using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class CrawlRoomComplexTrap
    {

        public string Severity;
        public string Initiative;
        public string Lockout;
        public string Stragglers;
        public string ControlComponent;
        public int NumGuns;
        public string GunComponent;
        public string AoEComponent;
        public string RoomComponent;

        public void Init(int tier)
        {
            Severity = CrawlRoomTrap.ChooseSeverity();
            _setInitiative();
            _setLockout();
            _setStragglerHandling();
            _setControlComponent(tier);
            _setGunComponent(tier);
            _setAoeComponent(tier);
            _setRoomComponent(tier);

        }

        public override string ToString()
        {
            return Severity + " Complex Trap\n"
                + "Initiative: " + Initiative + "\n"
                + "Start: " + Lockout + "\n"
                + "Stragglers: " + Stragglers + "\n\n"
                + "Mechanism: " + ControlComponent + "\n\n"
                + "Attacks: " + GunComponent + "\n\n"
                + "AoE: " + AoEComponent + "\n\n"
                + "Room Effect: " + RoomComponent;
        }

        private void _setInitiative()
        {
            var table = new RandomTable<string>();

            table.AddItem("Initiative count 10");
            table.AddItem("Initiative count 20");
            table.AddItem("Initiative count 10 and 20");

            Initiative = table.GetResult();
        }

        private void _setLockout()
        {
            int dc = CrawlRoomTrap.ChooseDc(Severity);

            var table = new RandomTable<string>();

            table.AddItem("Stone slabs drop over all exits");
            table.AddItem("Room rotates, sealing off doorways with solid " +
                "stone");
            table.AddItem("Iron panels drop over all exits");
            table.AddItem("Portcuillus drop over all exits");
            table.AddItem("Exits vanish, obscured by illusion (DC " + dc 
                + " Int check as an action to disbelive)");
            table.AddItem("Exits magically cease to exist");
            table.AddItem("Whole party teleported to trap room with no exits");

            Lockout = table.GetResult();
        }

        private void _setStragglerHandling()
        {
            var table = new RandomTable<string>();

            table.AddItem("Leave out");
            table.AddItem("Random encounter");
            table.AddItem("Trap is on straggler");

            Stragglers = table.GetResult();
        }

        private void _setControlComponent(int tier)
        {
            string stats = " (AC: " + CrawlRoomTrap.ChooseDc(Severity) + "; "
                + "hp: "
                ;

            var table = new RandomTable<string>();

            table.AddItem("None", 3);
            table.AddItem("Control station - " + _controlStationForm(tier) 
                + stats);
            table.AddItem("Maintainance panel - " + 
                _maintainancePanelForm(Severity, tier));
            table.AddItem("Targeting component - " + _targetControlForm());

            ControlComponent = table.GetResult();
        }

        private void _setGunComponent(int tier)
        {
            var dice = Dice.Instance;
            int numGuns = dice.Roll(1, 2) + tier;

            string stats = " (AC: " + CrawlRoomTrap.ChooseDc(Severity) + "; "
                + "hp: " + _componentHp(tier) + "; "
                + "damage threshold: " + _componentDamageThreshold(tier) + "; "
                + "to hit: " + CrawlRoomTrap.ChooseAttkBonus(Severity) + "; "
                + "damage: " + CrawlRoomTrap.ChooseDamage(tier, Severity)
                + ")";

            string direction = CrawlRoomTrap.ChooseLocation();

            var formTable = new RandomTable<string>();
            formTable.AddItem("Turrets mounted on the wall " + direction);
            formTable.AddItem("Mechanical arms with a gun on the end of " +
                "it, mounted on " + direction);
            formTable.AddItem("Turrets emerge from a trap door in the " + 
                direction + " and retract on its turn");
            formTable.AddItem("Slits in the walls");
            formTable.AddItem("Holes in the walls");

            bool isCoated = dice.Roll(1, 6) <= 2;
            string coating = (isCoated 
                ? "; Coated with " + CrawlRoomTrap.ChooseCoating() 
                : "");
            int dc = CrawlRoomTrap.ChooseDc(Severity);

            var table = new RandomTable<string>();

            table.AddItem("darts" + coating);
            table.AddItem("spears" + coating);
            table.AddItem("an acid spray");
            table.AddItem("a cold beam - speed reduced by 120 feet unti " +
                "this initiative next turn");
            table.AddItem("a ray of fire");
            table.AddItem("a psychic blast - any concentration checks " +
                "have disadvantage");
            table.AddItem("a necrotic ray - those slain rise as zombies");
            table.AddItem("a radiant beam");
            table.AddItem("a lighting bolt - strikes all in a straight " +
                "line as the target");
            table.AddItem("a force blast - knocks targets back up to 10 feet");
            table.AddItem("a ray of exhaustion - target makes a Con save " +
                "vs DC " + dc + " takes one level of exhausion");
            table.AddItem("a fear ray - target must make a Wis save vs DC " 
                + dc + " or is affected by fear for 1 round");
            table.AddItem("an incapacitating ray - Str save vs DC " + dc 
                + " or be incapacitated 1 round");
            table.AddItem("a paralyzing beam - Dex save vs DC " + dc 
                + " or be petrified for 1 round");
            table.AddItem("a stun ray - Cha save vs DC " + dc 
                + " or be stunned for 1 round");
            table.AddItem("a petrification ray - Dex save vs DC " + dc 
                + " or be petrified. Save again at the end of each turn " +
                "to end the effect.");

            string beamType = table.GetResult();

            GunComponent = numGuns + formTable.GetResult() + "; fires " 
                + beamType + " " + stats;
        }

        private void _setAoeComponent(int tier)
        {
            var shapeTable = new RandomTable<string>();
            shapeTable.AddItem("Cone - from wall, fixed locations");
            shapeTable.AddItem("Circle - from ceiling, fixed locations");
            shapeTable.AddItem("Sphere - random blast areas marked one " +
                "turn before exploding");
            shapeTable.AddItem("Sphere - random blast area with no warning");
            shapeTable.AddItem("Sphere - targets a random character");
            string shape = shapeTable.GetResult();

            int dc = CrawlRoomTrap.ChooseDc(Severity);
            string stats = " (AC: " + dc + "; " +
                "hp: " + _componentHp(tier) + "; " +
                "damage threshold: " + _componentDamageThreshold(tier) + "; " +
                "damage: " + CrawlRoomTrap.ChooseDamage(tier, Severity) +
                ", Dex save DC " + dc + " for half damage)";

            string location = CrawlRoomTrap.ChooseLocation();

            var formTable = new RandomTable<string>();
            formTable.AddItem("A Magic rune on the " + location);
            formTable.AddItem("A Turret mounted on the " + location);
            formTable.AddItem("A Standing stone of a strange material");
            formTable.AddItem("A Floating, glowing orb");
            formTable.AddItem("A Statue of cloaked figure");
            formTable.AddItem("A Small, metal dome mounted on the " 
                + location);
            formTable.AddItem("An unknown source");
            string form = formTable.GetResult();

            var effectTable = new RandomTable<string>();
            effectTable.AddItem("a blast of acid");
            effectTable.AddItem("a cold blast - speed reduced by 10 " +
                "feet until this initiative next turn - ");
            effectTable.AddItem("a fireball");
            effectTable.AddItem("a psychic blast - any concentration " +
                "checks have disadvantage - ");
            effectTable.AddItem("a necrotic blast - those slain rise as " +
                "zombies - ");
            effectTable.AddItem("a radiant blast");
            effectTable.AddItem("a lightning ball");
            effectTable.AddItem("a force blast");
            string effect = effectTable.GetResult();

            AoEComponent = form + " fires " + effect + " in the shape of a " 
                + shape + ". " + stats;
        }

        private void _setRoomComponent(int tier)
        {
            var dice = Dice.Instance;
            int rounds = dice.Roll(1, 4) + 5;
            var effectTable = new RandomTable<string>();
            effectTable.AddItem("Gas fills room in " + dice.Roll(1, 4) +
                " rounds: " + CrawlRoomTrap.ChooseGasType());
            effectTable.AddItem("Gravity reverses initiative for falling " +
                "damage");
            effectTable.AddItem("Room fills with " + 
                CrawlRoomTrap.ChooseTrapDoorPoolEffect() + " in " + 
                rounds + " rounds");
            effectTable.AddItem("Monsters teleported into room");
            effectTable.AddItem("Walls close in on party to smash them in " + 
                rounds + " rounds");
            effectTable.AddItem("Room filled with magical darkness");
            effectTable.AddItem("Anti-magic - no arcane spells or abilities");
            effectTable.AddItem("Shielded form the planes - no divine " +
                "spells or abilites");
            effectTable.AddItem("No gravity in room - we all float");
            effectTable.AddItem("Everyone is slowed to half speed");
            effectTable.AddItem("Room prevents magical scrying, gating, " +
                "teleporting, passwall, etc");
            RoomComponent = effectTable.GetResult();
        }

        private int _componentHp(int tier)
        {
            var dice = Dice.Instance;

            if (Severity == "Setback")
            {
                if (tier == 1) { return dice.Roll(6, 6); }
                else if (tier == 2) { return dice.Roll(8, 6); }
                else if (tier == 3) { return dice.Roll(10, 6); }
                else { return dice.Roll(12, 6); };
            }
            else if (Severity == "Dangerous")
            {
                if (tier == 1) { return dice.Roll(6, 8); }
                else if (tier == 2) { return dice.Roll(8, 8); }
                else if (tier == 3) { return dice.Roll(10, 8); }
                else { return dice.Roll(12, 8); };

            }
            else
            {
                if (tier == 1) { return dice.Roll(6, 12); }
                else if (tier == 2) { return dice.Roll(8, 12); }
                else if (tier == 3) { return dice.Roll(10, 12); }
                else { return dice.Roll(12, 12); };
            }
        }

        private int _componentDamageThreshold(int tier)
        {
            if (tier == 1) { return 5; }
            else if (tier == 2) { return 10; }
            else if (tier == 3) { return 15; }
            else { return 20; }
        }

        private string _controlStationForm(int tier)
        {
            var dice = Dice.Instance;
            int leverNumber = dice.Roll(1, 4) + 2;
            string leverDescription = "";

            for (int i = 0; i < leverNumber; ++i)
            {
                leverDescription += i.ToString() + " (" + Descriptors.Color()
                    + "): " + _controlEffect(tier) + "\n";
            }

            int dc = CrawlRoomTrap.ChooseDc(Severity);

            var table = new RandomTable<string>();

            table.AddItem("Stone pedestal on floor");
            table.AddItem("Metal panel in wall");
            table.AddItem("Hidden panel in " + CrawlRoomTrap.ChooseLocation() 
                + " (DC " + dc + " to find)");

            string form = table.GetResult();

            var typeTable = new RandomTable<string>();

            typeTable.AddItem("Levers");
            typeTable.AddItem("Buttons");
            typeTable.AddItem("Sliders");
            typeTable.AddItem("Wheels");
            typeTable.AddItem("Knobs");
            typeTable.AddItem("Glowing runes");

            string control = typeTable.GetResult();

            return form + " with " + control + ":\n" + leverDescription;
        }

        private string _maintainancePanelForm(string severity, int tier)
        {
            var dice = Dice.Instance;
            int leverNumber = dice.Roll(1, 4) + 2;
            string leverDescription = "";

            for (int i = 0; i < leverNumber; ++i)
            {
                leverDescription += i.ToString() + " (" + Descriptors.Color()
                    + "): " + _controlEffect(tier) + "\n";
            }

            int dc = CrawlRoomTrap.ChooseDc(Severity);

            var table = new RandomTable<string>();

            table.AddItem("Behind metal panel, bolted to wall (Str DC " + dc 
                + " to open");
            table.AddItem("Hidden in panel in " + 
                CrawlRoomTrap.ChooseLocation() + " (DC " + dc + " to find)");
            table.AddItem("Locked metal panel in " + 
                CrawlRoomTrap.ChooseLocation() + " (DC " + dc + " to open)");

            string form = table.GetResult();

            var typeTable = new RandomTable<string>();

            typeTable.AddItem("wires");
            typeTable.AddItem("gears");
            typeTable.AddItem("pipes");
            typeTable.AddItem("pistons");
            typeTable.AddItem("belts");
            typeTable.AddItem("glowing runes");

            string control = typeTable.GetResult();

            return form + " with " + control + ":\n" + leverDescription;
        }

        private string _targetControlForm()
        {
            var table = new RandomTable<string>();

            var dice = Dice.Instance;
            int num = dice.Roll(2, 4);

            table.AddItem("Rotating pillar, topped with a crystaline eye");
            table.AddItem("Statue with gem eyes and a rotating head");
            table.AddItem("A mechanical arm, gripping a crystal sphere");
            table.AddItem("A strange, floating orb");
            table.AddItem("A large, floating eyeball, visible only on " +
                "the ethereal plane");
            table.AddItem(num + " polished, metal mirrors, mounted on " +
                "the walls");
            table.AddItem(num + " large, glowing runes, set into the walls");
            table.AddItem(num + " mechanical eyes, set into the walls");
            table.AddItem(num + " stone imps, mounted near the ceiling");

            return table.GetResult();
        }

        private string _controlEffect(int tier)
        {
            int dc = CrawlRoomTrap.ChooseDc(Severity);
            string damage = CrawlRoomTrap.ChooseDamage(tier, Severity);

            var table = new RandomTable<string>();

            table.AddItem("Triggers next pahse of trap");
            table.AddItem("Disables one component");
            table.AddItem("Does nothing");
            table.AddItem("Adds +1 to all trap attacks");
            table.AddItem("Subtracts -1 to all attacks");
            table.AddItem("Seeds up trap: adds new initiative turn");
            table.AddItem("Slows down trap: removes lowest initiative " +
                "- minimum 1 turn");
            table.AddItem("Add +1 to all damage");
            table.AddItem("Subtracts -1 from all damage");
            table.AddItem("Electorcutes user for " + damage + 
                " lightining damage");
            table.AddItem("Spreads grease of trap floor, Dex save DC " + dc + 
                " each round to remain standing");
            table.AddItem("Explodes for " + damage + " fire damage, " +
                "Dex save DC " + dc + " for half. Controls no longer work.");
            table.AddItem("Pops off harmlessly in user's hand");

            return table.GetResult();
        }
    }
}
