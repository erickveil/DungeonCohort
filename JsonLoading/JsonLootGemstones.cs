using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class JsonLootGemstones
    {
        public string name;
        public string source;
        public int page;
        public string type;
        public List<string> table = new List<string>();

        public RandomTable<Gemstones> AsRollableTable()
        {
            var gemTable = new RandomTable<Gemstones>();

            int value;
            bool success = int.TryParse(type, out value);
            if (!success)
            {
                Console.WriteLine("Could not determine gemstone value: " 
                    + type);
                value = 10;
            }

            foreach (string entry in table)
            {
                var stone = new Gemstones();
                stone.value = value;
                stone.qty = 1;

                string[] splitStr = entry.Split('(');
                stone.type = splitStr[0].Trim();
                stone.description = splitStr[1].Trim();
                stone.description = 
                    stone.description.Remove(stone.description.Length - 1);

                gemTable.AddItem(stone);
            }

            return gemTable;
        }
    }
}
