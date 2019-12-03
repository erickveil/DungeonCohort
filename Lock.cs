﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class Lock
    {
        public string LockType;
        public int LockDC;

        public void Init(int tier)
        {
            var typeTable = new RandomTable<string>();
            typeTable.AddItem("Key", 20);
            typeTable.AddItem("Combination");

            LockType = typeTable.GetResult();

            var dice = Dice.Instance;
            int mod = dice.Roll(1, 6);
            if (tier == 1) { LockDC = 10 + mod; }
            if (tier == 2) { LockDC = 14 + mod; }
            if (tier == 3) { LockDC = 17 + mod; }
            LockDC = 20 + mod;
        }
    }
}
