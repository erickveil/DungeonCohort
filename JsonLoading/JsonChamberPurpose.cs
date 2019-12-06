using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort.JsonLoading
{
    class JsonChamberPurpose
    {
        public List<JsonChamberPurposeTable> tableList;

        public RandomTable<string> GetRoomTypeTable(string dungeonType)
        {
            foreach (var table in tableList)
            {
                if (table.caption.ToLower().Contains(dungeonType.ToLower()))
                {
                    return table.AsRandomTable();
                }
            }
            Console.WriteLine("Could not find room type table for " 
                + dungeonType);
            return new RandomTable<string>();
        }
    }
}
