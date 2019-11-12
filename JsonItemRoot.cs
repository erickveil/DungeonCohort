using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DungeonCohort
{
    class JsonItemRoot
    {
        public JObject _meta;

        public List<JsonItem> item = new List<JsonItem>();

        public List<JsonItemGroup> itemGroup = new List<JsonItemGroup>();

        private JsonMagicVariantRoot _magicVariant;

        public JsonItemRoot()
        {
            var loader = new JsonMagicVariantLoader();
            loader.LoadMagicVariantJsonData();
            _magicVariant = loader.Root;
        }

        public JsonItem GetItemById(string id)
        {
            foreach (JsonItem itemData in item)
            {
                if (!id.Contains(itemData.name)) { continue; }
                return itemData;
            }

            // The id is likely a group or a generic, needs converting
            foreach (JsonItemGroup group in itemGroup)
            {
                //if (group.name != id) { continue; }
                if (!id.Contains(group.name)) { continue; }
                string newid = group.ChooseGroupItemName();
                var item = GetItemByBaseName(newid);
                if (item is null) { continue; }
                return item;
            }

            // Not basic, not group, must be generic?
            JsonMagicVariants variant = _magicVariant.GetVariantByName(id);
            if (variant is null) { return BuildItemFromScratch(id); }
            var variantItem = ConvertFromVariant(variant);
            if (!(variantItem is null)) { return variantItem; }

            // There's a lot of them.
            //Console.WriteLine("Could not determine JsonItem for " + id);

            // the Cross reference sub-tables are absurd.
            // Let's just make it up
            return BuildItemFromScratch(id);

        }

        public JsonItem GetItemByBaseName(string baseName)
        {
            foreach (JsonItem itemData in item)
            {
                if (!baseName.Contains(itemData.name)) { continue; }
                return itemData;
            }
            return null;
        }

        private JsonItem ConvertFromVariant(JsonMagicVariants variant)
        {
            var item = new JsonItem();
            item.name = variant.name;
            item.rarity = variant.inherits.rarity;
            item.type = variant.inherits.tier;
            item.source = variant.inherits.source;
            item.page = variant.inherits.page;
            item.entries = variant.inherits.entries;

            return item;
        }

        private JsonItem BuildItemFromScratch(string id)
        {
            string name;
            if (id[0] != '{')
            {
                name = id;
            }
            else
            {
                // remove last "}"
                name = id.Remove(id.Length - 1);
                // remove first "{@tiem "
                name = name.Substring(7);
            }
            var item = new JsonItem();
            item.name = name;
            return item;
        }

    }
}
