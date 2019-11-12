using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DungeonCohort
{
    class JsonItem
    {
        public string name;
        public string rarity;
        public string type;
        public float value;
        public float weight;
        public string source;
        public int page;
        public JArray entries;
        public string weaponCategory;
        public string baseItem;
        public string dmg1;
        public string dmg2;
        public string dmgType;
        public JArray properties;
        public int crew;
        public int vehAc;
        public int vehHp;
        public int capPassenger;
        public float capCargo;
        public float vehSpeed;
        public JArray additionalSources;
        public JArray additionalEntries;

        public MagicItems AsMagicItem()
        {
            var magicItem = new MagicItems();
            magicItem.name = name;
            return magicItem;
        }
    }
}
