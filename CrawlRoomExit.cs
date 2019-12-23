using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class CrawlRoomExit
    {
        public string Type = "";
        public string Mechanism = "";
        public string State = "";
        public CrawlRoomLock DoorLock;
        public CrawlRoomTrap DoorTrap;

        public void RandomizeExit(int tier)
        {
            var dice = Dice.Instance;
            bool isSecret = dice.Roll(1, 20) == 1;
            if (isSecret)
            {
                InitAsSecretDoor(tier);
                return;
            }

            var typeTable = new RandomTable<string>();
            typeTable.AddItem("Wooden Door", 16);
            typeTable.AddItem("Archway", 8);
            typeTable.AddItem("Stone Door", 8);
            typeTable.AddItem("Portcuillus");
            typeTable.AddItem("Iron Vault Door");
            typeTable.AddItem("Curtain");
            typeTable.AddItem("Mimic (door)");

            Type = typeTable.GetResult();

            _setMechanism(tier);

            bool isTrapped = dice.Roll(1, 20) == 1;
            if (!isTrapped) { return; }

            if ( !(
                Type.Contains("Arch")
                || Type.Contains("Curtain")
                || Type.Contains("Mimic")
                ) )
            {
                DoorTrap = new CrawlRoomTrap();
                DoorTrap.InitAsDoorTrap(tier);
            }
        }

        public override string ToString()
        {
            string doorLock;
            if (Type.ToLower().Contains("curtain")
                || Type.ToLower().Contains("arch")
                || Type.ToLower().Contains("mimic")
                )
            {
                doorLock = "";
            }
            else if (State.ToLower().Contains("barred"))
            {
                doorLock = "";
            }
            else if (DoorLock is null)
            {
                doorLock = "";
            }
            else
            {
                doorLock = DoorLock.ToString();
            }

            return Type + "; "
                + (Mechanism == "" ? "" : Mechanism + "; ")
                + (State == "" ? "" : State + "; ")
                + doorLock
                + (DoorTrap is null ? "" : "; Trapped: " + DoorTrap.ToString() )
                ;
        }

        public void InitAsStandard(int tier)
        {
            var typeTable = new RandomTable<string>();
            typeTable.AddItem("Archway");
            typeTable.AddItem("Wooden Door", 4);
            typeTable.AddItem("Stone Door", 2);

            Type = typeTable.GetResult();

            // standard doors have easier locks
            --tier;
            if (tier < 1) { tier = 1; }
            _setMechanism(tier, true);

            // standard door aren't trapped
        }

        public void InitAsSecretDoor(int tier)
        {
            var table = new RandomTable<string>();
            table.AddItem("Wall");
            table.AddItem("Archway covered by illusion");
            table.AddItem("Bookshelf");
            table.AddItem("Wardrobe");
            table.AddItem("Coffin");

            string form = table.GetResult();
            Type = "Secret Door: " + form;
            _setSecretDoorMechanism();

            var dice = Dice.Instance;
            bool isTrapped = dice.Roll(1, 10) == 1;
            if (!isTrapped) { return; }

            DoorTrap = new CrawlRoomTrap();
            DoorTrap.InitAsDoorTrap(tier);
        }

        private void _setMechanism(int tier, bool isStandard = false)
        {
            var mechanismTable = new RandomTable<string>();
            mechanismTable.AddItem("Knob", 4);
            mechanismTable.AddItem("Handle", 4);
            mechanismTable.AddItem("Push plate");
            mechanismTable.AddItem("No knob: Opens when approached");
            mechanismTable.AddItem("Wheel");
            mechanismTable.AddItem("Lever", 2);
            mechanismTable.AddItem("Pull ring", 2);
            mechanismTable.AddItem("Door knocker");
            mechanismTable.AddItem("Button");
            mechanismTable.AddItem("Secret activator");

            if (Type.Contains("Arch") || Type.Contains("Curtain"))
            {
                Mechanism = "";
            }
            else
            {
                Mechanism = mechanismTable.GetResult();
                if (isStandard) { return; }
                _setState(tier);
            }
        }

        private void _setSecretDoorMechanism()
        {
            var mechanismTable = new RandomTable<string>();
            mechanismTable.AddItem("Push on door");
            mechanismTable.AddItem("Press loose stone near door");
            mechanismTable.AddItem("Step on floor plate");
            mechanismTable.AddItem("Mysteriously opens ajar on its own");
            mechanismTable.AddItem("Already open, closes and seals after " +
                "1 party member enters");
            mechanismTable.AddItem("Twist a sconce");
            mechanismTable.AddItem("Lever disguised as part of the " +
                "concealment");
            mechanismTable.AddItem("Obvious lever in the room");
            mechanismTable.AddItem("Inconspicuous keyhole");

            Mechanism = mechanismTable.GetResult();
        }

        private void _setState(int tier)
        {
            var stateTable = new RandomTable<string>();
            stateTable.AddItem("Closed", 32);
            stateTable.AddItem("Locked", 16);
            stateTable.AddItem("Barred on opposite side", 8);
            stateTable.AddItem("Barred on this side", 4);
            stateTable.AddItem("Opened by a lever in this room", 2);
            stateTable.AddItem("Open");
            stateTable.AddItem("Destroyed");
            stateTable.AddItem("Opened by a lever in the next room");

            State = stateTable.GetResult();

            if (State == "Locked")
            {
                DoorLock = new CrawlRoomLock();
                DoorLock.Init(tier);
            }
            else
            {
                DoorLock = null;
            }
            
        }
    }
}
