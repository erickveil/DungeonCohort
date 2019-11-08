using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCohort
{
    class LootTableResult
    {
        public int CP = 0;
        public int SP = 0;
        public int EP = 0;
        public int GP = 0;
        public int PP = 0;

        public string AsString()
        {
            string report = "";
            string delim = ", ";

            if (CP > 0) { report += "cp: " + CP.ToString(); }
            if (report != "" && SP > 0) { report += delim; }
            if (SP > 0) { report += "sp: " + SP.ToString(); }
            if (report != "" && EP > 0) { report += delim; }
            if (EP > 0) { report += "ep: " + EP.ToString(); }
            if (report != "" && GP > 0) { report += delim; }
            if (GP > 0) { report += "gp: " + GP.ToString(); }
            if (report != "" && PP > 0) { report += delim; }
            if (PP > 0) { report += "pp: " + PP.ToString(); }

            if (report == "") { return "none"; }

            return report;
        }

    }
}
