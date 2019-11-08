using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class JsonLootArt
    {
        public string name;
        public string source;
        public int page;
        public string type;
        public List<string> table = new List<string>();

        public RandomTable<ArtObjects> AsRollableTable()
        {
            var artTable = new RandomTable<ArtObjects>();
            int value;
            bool success = int.TryParse(type, out value);
            if (!success)
            {
                Console.WriteLine("Could not determine art value: " + type);
                value = 25;
            }

            foreach (string entry in table)
            {
                var art = new ArtObjects();
                art.value = value;
                art.name = entry;

                artTable.AddItem(art);
            }

            return artTable;
        }
    }
}
