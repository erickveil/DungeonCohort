using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DungeonCohort.JsonLoading
{
    class JsonSpell
    {
        public string name = "";
        public int level;
        public string school;
        public JObject range;
        public JObject components;
        public JArray duration;
        public JObject classes;
        public string source;
        public JArray entries;
        public int page;
        public List<string> damageInflict = new List<string>();
        public List<string> savingThrow = new List<string>();
        public List<string> areaTags = new List<string>();
        public JArray backgrounds;
        public List<string> miscTags = new List<string>();

        public List<string> GetCharacterClasses()
        {
            var resultList = new List<string>();

            if (name == "")
            {
                Console.WriteLine("Attempting to get class of " +
                    "uninitialized spell object.");
                return resultList;
            }

            var fromClassList = (JArray)classes["fromClassList"];
            if (fromClassList is null)
            {
                Console.WriteLine("Spell " + name + 
                    " does not have class list");
                return resultList;
            }

            foreach (JObject classObj in fromClassList)
            {
                var name = classObj["name"];
                string source = (string)classObj["source"];
                if (name is null) { continue; }
                resultList.Add((string)name);
            }

            return resultList;
        }

        public bool IsForCharacterClass(string testCharacterClass)
        {
            var classList = GetCharacterClasses();
            foreach (var className in classList)
            {
                if (
                    className.ToLower().Contains(testCharacterClass.ToLower())
                    || testCharacterClass.ToLower().Contains(className.ToLower())
                    )
                {
                    return true;
                }
            }
            return false;
        }

    }
}
