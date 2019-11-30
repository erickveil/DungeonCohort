using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCohort
{
    class CrawlRoomShape
    {
        public bool IsHall;
        public CrawlRoomExit LeftExit = null;
        public CrawlRoomExit RightExit = null;
        public CrawlRoomExit StraightExit = null;
    }
}
