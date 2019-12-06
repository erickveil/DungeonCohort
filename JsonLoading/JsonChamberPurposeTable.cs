using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort.JsonLoading
{
    class JsonChamberPurposeTable
    {
        public string caption;
        public List<List<string>> rows;

        public RandomTable<string> AsRandomTable()
        {
            int rownum = 0;
            var table = new RandomTable<string>();
            foreach (var row in rows)
            {
                if (row.Count != 2)
                {
                    Console.WriteLine(caption + " has odd row of size: " 
                        + row.Count + " at index " + rownum );
                    ++rownum;
                    continue;
                }
                table.AddItem(row[1]);
                ++rownum;
            }
            return table;
        }
    }
}
