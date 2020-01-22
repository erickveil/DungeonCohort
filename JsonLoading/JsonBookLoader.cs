using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using Darkmoor;

namespace DungeonCohort.JsonLoading
{
    class JsonBookLoader
    {
        public List<List<string>> rows;

        private RandomTable<string> BookSubjectTable;

        public void LoadBookFile()
        {
            string jsonData;
            var filename = "Books.json";
            try { jsonData = File.ReadAllText(filename); }
            catch (Exception)
            {
                Console.WriteLine("Could not load books from " + filename);
                return;
            }

            var rootObj = 
                JsonConvert.DeserializeObject<JsonBookLoader>(jsonData);

            BookSubjectTable = new RandomTable<string>();

            foreach (var rowList in rootObj.rows)
            {
                BookSubjectTable.AddItem(rowList[1]);
            }
        }

        public RandomTable<string> GetBookSubjectTable()
        {
            if (BookSubjectTable is null) { LoadBookFile(); }
            return BookSubjectTable;
        }

        public string GetBookSubject()
        {
            var table = GetBookSubjectTable();
            return table.GetResult();
        }
    }
}
