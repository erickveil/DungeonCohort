using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DungeonCohort
{
    class JsonReligiousArticles
    {
        public List<List<string>> rows;

        private static RandomTable<string> _furnishingsTable;

        public void Load()
        {
            string filename = "ReligiousArticles.json";
            string jsonData;
            try { jsonData = File.ReadAllText(filename); }
            catch (Exception)
            {
                Console.WriteLine("Could not load data from " + filename);
                return;
            }

            var rootObj = 
                JsonConvert.DeserializeObject<JsonReligiousArticles>(jsonData);
            rows = rootObj.rows;

            _furnishingsTable = new RandomTable<string>();
            foreach (List<string> row in rows)
            {
                _furnishingsTable.AddItem(row[1]);
            }

        }
        public RandomTable<string> GetRollableTable()
        {
            if (_furnishingsTable is null) { Load(); }
            return _furnishingsTable;

        }

        public string GetItem()
        {
            if (_furnishingsTable is null) { Load(); }
            return _furnishingsTable.GetResult();
        }
    }
}
