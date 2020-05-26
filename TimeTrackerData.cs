using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCohort
{
    class TimeTrackerData
    {
        public int Rounds;
        public int Minutes;
        public int Hours;

        public void Copy(TimeTrackerData source)
        {
            Rounds = source.Rounds;
            Minutes = source.Minutes;
            Hours = source.Hours;
        }
    }
}
