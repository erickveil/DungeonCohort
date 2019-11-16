using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Darkmoor;

namespace DungeonCohort
{
    public partial class Form1 : Form
    {
        AncestryIndex _ancestryIndex;
        JsonLootLoader _lootLoader;
        Dice _dice;
        EncounterBuilder _encounterBuilder;

        
        public Form1()
        {
            InitializeComponent();

            _ancestryIndex = AncestryIndex.Instance;
            _ancestryIndex.LoadAllSources();
            _dice = Dice.Instance;
            _lootLoader = new JsonLootLoader();
            _lootLoader.LoadLootJsonData();

            _encounterBuilder = new EncounterBuilder();
            _encounterBuilder.MonsterSource = _ancestryIndex;
        }

        public void Print(RichTextBox target, string message, Font font)
        {
            int msgStart = target.Text.Length;
            int msgLen = message.Length;
            target.AppendText(message);
            target.Select(msgStart, msgLen);
            target.SelectionFont = font;
        }

        public void PrintH1(RichTextBox target, string msg)
        {
            var typeface = "ITC Avant Garde Gothic LT";
            var size = 11;
            var style = FontStyle.Bold;
            var font = new Font(typeface, size, style);
            Print(target, msg, font);
        }

        public void PrintH2(RichTextBox target, string msg)
        {
            var typeface = "ITC Avant Garde Gothic LT";
            var size = 9;
            var style = FontStyle.Bold;
            var font = new Font(typeface, size, style);
            msg = msg.ToUpper();
            Print(target, msg, font);
        }

        public void PrintH3(RichTextBox target, string msg)
        {
            var typeface = "ITC Avant Garde Gothic LT";
            var size = 9;
            var style = FontStyle.Bold;
            var font = new Font(typeface, size, style);
            Print(target, msg, font);
        }

        public void PrintBody(RichTextBox target, string msg)
        {
            var typeface = "AvantGarde Normal";
            var size = 11;
            var style = FontStyle.Regular;
            var font = new Font(typeface, size, style);
            Print(target, msg, font);
        }

        public void PrintBodyBold(RichTextBox target, string msg)
        {
            var typeface = "AvantGarde Normal";
            var size = 11;
            var style = FontStyle.Bold;
            var font = new Font(typeface, size, style);
            Print(target, msg, font);
        }

        public void PrintList(RichTextBox target, string msg)
        {

            var typeface = "AvantGarde Normal";
            var size = 11;
            var style = FontStyle.Regular;
            var font = new Font(typeface, size, style);

            int msgStart = target.Text.Length;
            int msgLen = msg.Length;
            target.AppendText(msg);
            target.Select(msgStart, msgLen);
            target.SelectionFont = font;
            target.SelectionBullet = true;
        }

        private void bu_monster_Click(object sender, EventArgs e)
        {
            RichTextBox target = rtb_rndMonstOut;
            target.Clear();

            int tier = (int)nud_tier.Value;
            string biome = cb_biome.Text;
            bool isStdRace = cb_stdRaceNpcs.Checked;
            Ancestry monster = _ancestryIndex.GetRandomAncestry(tier, biome, 
                isStdRace);

            var lootTable = _lootLoader.GetIndividualLootTable(tier);
            LootTableResult loot = lootTable.GetResult();
            string lootReport = "\nLoot: " + loot.AsString();

            string monsterName = monster.GetCompositeName();
            string cr = monster.CR;
            PrintBody(target, monsterName + " (CR: " + cr + ")" + lootReport);
        }

        private void bu_genNPC_Click(object sender, EventArgs e)
        {
            RichTextBox target = rtb_rndMonstOut;
            target.Clear();

            int tier = (int)nud_tier.Value;
            bool isStdRace = cb_stdRaceNpcs.Checked;
            Character npc = _ancestryIndex.GetRandomNPC(tier, 
                AlignmentValue.ALIGN_GOOD, isStdRace);

            var lootTable = _lootLoader.GetIndividualLootTable(tier);
            LootTableResult loot = lootTable.GetResult();
            string lootReport = "\nLoot: " + loot.AsString();

            string npcName = npc.GetFullIdentifier();
            string alignment = npc.GetAlignmentString();
            string cr = npc.Ancestry.CR;
            PrintBody(target, npcName + " (" + cr + ")\n" + alignment
                + lootReport);
        }

        private void bu_npcParty_Click(object sender, EventArgs e)
        {
            int numMembers = _dice.Roll(1, 4) + 1;
            int tier = (int)nud_tier.Value;
            bool isStdRace = cb_stdRaceNpcs.Checked;
            AlignmentValue align = Character.ChoseAlignmentGE();
            var leader = _ancestryIndex.GetRandomNPC(tier, align, isStdRace);
            var partyRoster = new List<Character>();
            for (int i = 0; i < numMembers; ++i)
            {
                partyRoster.Add(
                    _ancestryIndex.GetRandomNPC(tier, align, isStdRace)
                    );
            }

            RichTextBox target = rtb_rndMonstOut;
            target.Clear();

            PrintH1(target, "NPC Party\n");

            var lootTable = _lootLoader.GetIndividualLootTable(tier);
            LootTableResult loot = lootTable.GetResult();
            string lootReport = "Loot: " + loot.AsString();

            string npcName = leader.GetFullIdentifier();
            string alignment = leader.GetAlignmentString();
            string cr = leader.Ancestry.CR;
            PrintList(target, npcName + " (cr: " + cr + "; " + alignment 
                + "; " + lootReport + ")\n");
            foreach(var npc in partyRoster)
            {
                lootTable = _lootLoader.GetIndividualLootTable(tier);
                loot = lootTable.GetResult();
                lootReport = "Loot: " + loot.AsString();

                npcName = npc.GetFullIdentifier();
                alignment = npc.GetAlignmentString();
                cr = npc.Ancestry.CR;

                PrintList(target, npcName + " (cr: " + cr + "; " + 
                    alignment + "; " + lootReport + ")\n");
            }
        }

        private void bu_indiTreasure_Click(object sender, EventArgs e)
        {
            RichTextBox target = rtb_rndMonstOut;
            target.Clear();
            int tier = (int)nud_tier.Value;

            var lootTable = _lootLoader.GetIndividualLootTable(tier);
            LootTableResult loot = lootTable.GetResult();
            var permissions = GetItemPermissions();
            loot.PurgeResults(permissions);
            string lootReport = "Loot: " + loot.AsString();

            PrintBody(target, lootReport);



        }

        private void bu_hordeTreasure_Click(object sender, EventArgs e)
        {
            RichTextBox target = rtb_rndMonstOut;
            target.Clear();
            int tier = (int)nud_tier.Value;


            var lootTable = _lootLoader.GetHordeLootTable(tier);
            LootTableResult loot = lootTable.GetResult();
            var permissions = GetItemPermissions();
            loot.PurgeResults(permissions);
            string lootReport = "Treasure Horde:\n" + loot.AsString();

            PrintBody(target, lootReport);

        }

        private MagicItemPermissions GetItemPermissions()
        {
            var permissions = new MagicItemPermissions();
            permissions.MinorCommon = cb_allowCommon.Checked;
            permissions.MinorUncommon = cb_allowMinorUncommon.Checked;
            permissions.MinorRare = cb_allowMinorRare.Checked;
            permissions.MinorVeryRare = cb_allowMinorVeryRare.Checked;
            permissions.MinorLegendary = cb_allowMinorLegendary.Checked;
            permissions.MajorUncommon = cb_allowMajorUncommon.Checked;
            permissions.MajorRare = cb_allowMajorRare.Checked;
            permissions.MajorVeryRare = cb_allowMajorVeryRare.Checked;
            permissions.MajorLegendary = cb_allowMajorLegendary.Checked;
            return permissions;
        }

        private void bu_encounter_Click(object sender, EventArgs e)
        {
            _encounterBuilder.Clear();
            _encounterBuilder.PcLevelList.Add((int)nud_pcLevelA.Value);
            _encounterBuilder.PcLevelList.Add((int)nud_pcLevelB.Value);
            _encounterBuilder.PcLevelList.Add((int)nud_pcLevelC.Value);
            _encounterBuilder.PcLevelList.Add((int)nud_pcLevelD.Value);

            _encounterBuilder.PcQtyList.Add((int)nud_pcQtyA.Value);
            _encounterBuilder.PcQtyList.Add((int)nud_pcQtyB.Value);
            _encounterBuilder.PcQtyList.Add((int)nud_pcQtyC.Value);
            _encounterBuilder.PcQtyList.Add((int)nud_pcQtyD.Value);

            _encounterBuilder.Difficulty = cb_difficulty.Text;

            string biome = cb_biome.Text;
            bool isStandardRace = cb_stdRaceNpcs.Checked;

            _encounterBuilder.PickOneMookPerPc(biome, isStandardRace);

            RichTextBox target = rtb_rndMonstOut;
            target.Clear();
            PrintBody(target, _encounterBuilder.LastEncounterAsString());
        }
    }
}
