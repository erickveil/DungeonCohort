using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCohort
{
    class LootTableResult
    {
        public int CP = 0;
        public int SP = 0;
        public int EP = 0;
        public int GP = 0;
        public int PP = 0;

        /// <summary>
        /// Note: I've tried running games where hoards have multiple types of
        /// gems, and honestly, it's a huge pain to describe and nobody gets
        /// anything special or exciting out of the variety.
        /// They're all the same value anyway, so why not make them all the 
        /// same type? 
        /// </summary>
        public Gemstones Gems;

        /// <summary>
        /// Art on the other hand might be confused for magical items, and 
        /// should be unique, so we use a list of items.
        /// </summary>
        public List<ArtObjects> ArtList = new List<ArtObjects>();

        /// <summary>
        /// Likewise, magic items should be unique
        /// </summary>
        public List<MagicItems> MagicItemList = new List<MagicItems>();

        public string AsString()
        {
            string report = "";
            string delim = ", ";

            if (CP > 0) { report += "cp: " + CP.ToString(); }
            if (report != "" && SP > 0) { report += delim; }
            if (SP > 0) { report += "sp: " + SP.ToString(); }
            if (report != "" && EP > 0) { report += delim; }
            if (EP > 0) { report += "ep: " + EP.ToString(); }
            if (report != "" && GP > 0) { report += delim; }
            if (GP > 0) { report += "gp: " + GP.ToString(); }
            if (report != "" && PP > 0) { report += delim; }
            if (PP > 0) { report += "pp: " + PP.ToString(); }
            if (report != "" && !(Gems is null)) { report += "\n"; }
            if (!(Gems is null))
            {
                report += Gems.qty.ToString() + " " + Gems.type + " at " 
                    + Gems.value.ToString() + " gp each";
            }
            if (report != "" && !(ArtList is null)) { report += "\n"; }
            foreach (var art in ArtList)
            {
                report += art.name + " worth " + art.value.ToString() + " gp\n";
            }

            if (report != "" && !(MagicItemList is null)) { report += "\n"; }
            foreach (var magicItem in MagicItemList)
            {
                report += magicItem.name 
                    + "(" + magicItem.type + ", " + magicItem.rarity + ")"
                    + "\n";
            }

            if (report == "") { return "none"; }

            return report;
        }

        public void PurgeResults(MagicItemPermissions permissions)
        {
            var newItemList = new List<MagicItems>();

            foreach (var magicItem in MagicItemList)
            {
                if (magicItem.type == "Minor")
                {
                    if (magicItem.rarity == "Common" && permissions.MinorCommon)
                    {
                        newItemList.Add(magicItem);
                        continue;
                    }
                    if (magicItem.rarity == "Uncommon" && permissions.MinorUncommon)
                    {
                        newItemList.Add(magicItem);
                        continue;
                    }
                    if (magicItem.rarity == "Rare" && permissions.MinorRare)
                    {
                        newItemList.Add(magicItem);
                        continue;
                    }
                    if (magicItem.rarity == "Very Rare" && permissions.MinorVeryRare)
                    {
                        newItemList.Add(magicItem);
                        continue;
                    }
                    if (magicItem.rarity == "Legendary" && permissions.MinorLegendary)
                    {
                        newItemList.Add(magicItem);
                        continue;
                    }
                }
                else if (magicItem.type == "Major")
                {
                    if (magicItem.rarity == "Uncommon" && permissions.MajorUncommon)
                    {
                        newItemList.Add(magicItem);
                        continue;
                    }
                    if (magicItem.rarity == "Rare" && permissions.MajorRare)
                    {
                        newItemList.Add(magicItem);
                        continue;
                    }
                    if (magicItem.rarity == "Very Rare" && permissions.MajorVeryRare)
                    {
                        newItemList.Add(magicItem);
                        continue;
                    }
                    if (magicItem.rarity == "Legendary" && permissions.MajorLegendary)
                    {
                        newItemList.Add(magicItem);
                        continue;
                    }
                }
                else if (magicItem.rarity == "" || magicItem.rarity is null
                    || magicItem.type == "" || magicItem.type is null)
                {
                     newItemList.Add(magicItem);
                     continue;
                }
            } // foreach
            MagicItemList.Clear();
            MagicItemList = newItemList;
        } // PurgeResults

    } // LootTableResult
} // namespace
