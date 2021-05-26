using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCohort.JsonLoading;
using Darkmoor;

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

        public List<string> MundaneItemList = new List<string>();

        public string ContainedIn = "";
        public string HiddenBy = "";
        public CrawlRoomTrap ProtectedBy = null;

        public override string ToString()
        {
            string report = "";
            string delim = ", ";

            if (HiddenBy != "")
            {
                report += "HIDDEN: " + HiddenBy + "\n";
            }

            if (ContainedIn != "")
            {
                report += "Container: " + ContainedIn + "\n";
            }

            if (!(ProtectedBy is null))
            {
                report += "Trapped: " + ProtectedBy.ToString() + "\n";
            }

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

            if (report != "" && ( !(ArtList is null) && ArtList.Count != 0 ) ) 
            { 
                report += "\n"; 
            }
            foreach (var art in ArtList)
            {
                report += art.name + " worth " + art.value.ToString() + " gp\n";
            }

            if (report != "" 
                && ( !(MagicItemList is null) && MagicItemList.Count != 0 ) ) 
            {
                report += "\n";
            }
            foreach (var magicItem in MagicItemList)
            {
                report += magicItem.ToString()
                    + " (" + magicItem.type + ", " + magicItem.rarity + ")"
                    + "\n";
            }

            if (report != "" 
                && ( !(MundaneItemList is null) 
                && MundaneItemList.Count != 0 ) ) 
            {
                report += "\n";
            }
            foreach (var item in MundaneItemList)
            {
                report += item + "\n";
            }

            if (report == "") { return "none"; }

            return report;
        }

        public void SetContainer(int tier)
        {
            var table = new RandomTable<string>();
            table.AddItem("Bags");
            table.AddItem("Sacks");
            table.AddItem("Small Coffers");
            table.AddItem("Chests");
            table.AddItem("Huge Chests");
            table.AddItem("Pottery Jars");
            table.AddItem("Metal Urns");
            table.AddItem("Stone Containers");
            table.AddItem("Iron Trunks");
            table.AddItem("Loose");

            var dice = Dice.Instance;
            int choice = dice.Roll(1, 10) - 1;
            ContainedIn = table.GetResult(choice);
            if (choice <= 3) { SetHidingPlace(); }
            if (choice >= 5) { SetProtection(tier); }
        }

        public void SetHidingPlace()
        {
            var table = new RandomTable<string>();
            table.AddItem("Invisibility", 3);
            table.AddItem("Illusion to change or hide appearance", 2);
            table.AddItem("Secret space under container");
            table.AddItem("Secret compartment in container", 2);
            table.AddItem("Inside ordinary item in plain view");
            table.AddItem("Disguised to appear as something else");
            table.AddItem("Under a heap of trash/dung", 2);
            table.AddItem("Behind a loose stone in the wall", 2);
            table.AddItem("In a secret room nearby", 5);
            table.AddItem("", 10);
            HiddenBy = table.GetResult();
        }

        public void SetProtection(int tier)
        {
            var dice = Dice.Instance;
            bool isNotTrapped = dice.Roll(1, 20) <= 11;
            if (isNotTrapped) { return; }
            bool isMagicCircle = dice.Roll(1, 6) <= 2;
            if (isMagicCircle)
            {
                CreateProtectiveCircle(tier);
            }
            else
            {
                ProtectedBy = new CrawlRoomTrap();
                ProtectedBy.InitAsDoorTrap(tier);
            }
        }

        public void CreateProtectiveCircle(int tier)
        {
            ProtectedBy = new CrawlRoomTrap();

            var effectTable = new RandomTable<string>();
            effectTable.AddItem("Teleportation");
            effectTable.AddItem("Force Shield");
            effectTable.AddItem("Damage");
            effectTable.AddItem("Summoning");

            var damageTable = new RandomTable<string>();
            damageTable.AddItem("Force");
            damageTable.AddItem("Psychic");
            damageTable.AddItem("Necrotic");
            damageTable.AddItem("Cold");
            damageTable.AddItem("Fire");
            damageTable.AddItem("Lightning");
            damageTable.AddItem("Thunder");

            ProtectedBy.Effect = effectTable.GetResult();
            ProtectedBy.Radius = 10;
            ProtectedBy.Type = "Magic Circle";

            if (ProtectedBy.Effect == "Damage")
            {
                ProtectedBy.Severity = CrawlRoomTrap.ChooseSeverity();
                ProtectedBy.DC = CrawlRoomTrap.ChooseDc(ProtectedBy.Severity);
                ProtectedBy.DamageDice = CrawlRoomTrap.ChooseDamage(tier, ProtectedBy.Severity);
                ProtectedBy.DamageType = damageTable.GetResult();
            }


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
