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
    class JsonContainerContents
    {
        public List<List<string>> rows;

        private RandomTable<string> ContentsTable;
        private RandomTable<string> ContainerTable;

        public void Init()
        {
            LoadConentsFile();
            BuildConainerTable();
        }

        public void LoadConentsFile()
        {
            string jsonData;
            var filename = "ContainerContents.json";
            try { jsonData = File.ReadAllText(filename); }
            catch (Exception)
            {
                Console.WriteLine("Could not load container contents from " + 
                    filename);
                return;
            }

            var rootObj =
                JsonConvert.DeserializeObject<JsonContainerContents>(jsonData);
            ContentsTable = new RandomTable<string>();
            foreach (var rowList in rootObj.rows)
            {
                ContentsTable.AddItem(rowList[1]);
            }
        }

        public void BuildConainerTable()
        {
            ContainerTable = new RandomTable<string>();

            ContainerTable.AddItem("Barrel");
            ContainerTable.AddItem("Crate");
            ContainerTable.AddItem("Sack");
            ContainerTable.AddItem("Jar");
            ContainerTable.AddItem("Box");
            ContainerTable.AddItem("Bin");
            ContainerTable.AddItem("Bucket");
            ContainerTable.AddItem("Drawer");
            ContainerTable.AddItem("Cabinet");
        }

        public RandomTable<string> GetContainerContentsTable()
        {
            if (ContentsTable is null) { LoadConentsFile(); }
            return ContentsTable;
        }

        public RandomTable<string> GetContainerTable()
        {
            if (ContainerTable is null) { BuildConainerTable(); }
            return ContainerTable;
        }

        public string GetContainer()
        {
            var table = GetContainerTable();
            return table.GetResult();
        }

        public string GetContainerContent()
        {
            var table = GetContainerContentsTable();
            return table.GetResult();
        }
    }
}
