using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class Descriptors
    {

        public static string Color()
        {
            var table = new RandomTable<string>();

            table.AddItem("red");
            table.AddItem("orange");
            table.AddItem("yellow");
            table.AddItem("green");
            table.AddItem("blue");
            table.AddItem("purple");

            return table.GetResult();
        }
    }
}
