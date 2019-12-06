using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Darkmoor;

namespace DungeonCohort.JsonLoading
{
    class JsonChamberPurposeLoader
    {
        JsonChamberPurpose _roomTypeObj;

        private static JsonChamberPurposeLoader _instance = null;
        private JsonChamberPurposeLoader() { }

        public static JsonChamberPurposeLoader Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new JsonChamberPurposeLoader();
                    _instance.LoadJsonData();
                }
                return _instance;
            }
        }

        public RandomTable<string> GetDungeonRoomTypeTable(string duneonType)
        {
            return _roomTypeObj.GetRoomTypeTable(duneonType);
        }

        private void LoadJsonData()
        {
            string filename = "chamberPurpose.json";
            string jsonData;
            try { jsonData = File.ReadAllText(filename); }
            catch (Exception)
            {
                Console.WriteLine("Could not load loot json data.");
                return;
            }

            // load the easy items
            _roomTypeObj = JsonConvert.DeserializeObject<JsonChamberPurpose>(jsonData);

            Console.WriteLine("Loaded " + filename);
        }

        
    }
}
