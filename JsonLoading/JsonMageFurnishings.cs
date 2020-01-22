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
    class JsonMageFurnishings
    {
        public List<List<string>> rows;

        private RandomTable<string> MageFurnishingsTable;

        public void LoadFile()
        {
            string filename = "MageFurnishings.json";
            string jsonData = DataSourceLoader.LoadFile(filename);
            if (jsonData == "") { return; }

            var rootObj = 
                JsonConvert.DeserializeObject<JsonMageFurnishings>(jsonData);

            MageFurnishingsTable = new RandomTable<string>();
            foreach (var rowList in rootObj.rows)
            {
                MageFurnishingsTable.AddItem(rowList[1]);
            }
        }

        public RandomTable<string> GetMageFurnishingsTable()
        {
            if (MageFurnishingsTable is null) { LoadFile(); }
            return MageFurnishingsTable;
        }

        public string GetMageFurnature()
        {
            var table = GetMageFurnishingsTable();
            return table.GetResult();
        }
    }
}
