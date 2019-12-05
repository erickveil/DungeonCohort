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
        EncounterFactory _encounterFactory;

        
        public Form1()
        {
            InitializeComponent();

            _ancestryIndex = AncestryIndex.Instance;
            _dice = Dice.Instance;
            _lootLoader = JsonLootLoader.Instance;

            _encounterFactory = new EncounterFactory();
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
            var permissions = GetItemPermissions();

            var treasureGen = new TreasureFactory();
            var loot = treasureGen.GetIndividualTreasure(tier, permissions);

            string lootReport = "Loot: " + loot.AsString();
            PrintBody(target, lootReport);
        }

        private void bu_hordeTreasure_Click(object sender, EventArgs e)
        {
            RichTextBox target = rtb_rndMonstOut;
            target.Clear();
            int tier = (int)nud_tier.Value;
            var permissions = GetItemPermissions();

            var treasureGen = new TreasureFactory();
            var loot = treasureGen.GetTreasureHoard(tier, permissions);

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
            _encounterFactory.Clear();
            _encounterFactory.PcLevelList.Add((int)nud_pcLevelA.Value);
            _encounterFactory.PcLevelList.Add((int)nud_pcLevelB.Value);
            _encounterFactory.PcLevelList.Add((int)nud_pcLevelC.Value);
            _encounterFactory.PcLevelList.Add((int)nud_pcLevelD.Value);

            _encounterFactory.PcQtyList.Add((int)nud_pcQtyA.Value);
            _encounterFactory.PcQtyList.Add((int)nud_pcQtyB.Value);
            _encounterFactory.PcQtyList.Add((int)nud_pcQtyC.Value);
            _encounterFactory.PcQtyList.Add((int)nud_pcQtyD.Value);

            _encounterFactory.Difficulty = cb_difficulty.Text;

            string biome = cb_biome.Text;
            bool isStandardRace = cb_stdRaceNpcs.Checked;

            RichTextBox target = rtb_rndMonstOut;
            target.Clear();

            if (biome == "")
            {
                PrintBody(target, "Set Biome");
                return;
            }
            if (_encounterFactory.Difficulty == "")
            {
                PrintBody(target, "Set Difficulty");
                return;
            }
            if (_encounterFactory.PcLevelList.Sum() == 0)
            {
                PrintBody(target, "Set PC Levels");
                return;
            }
            if (_encounterFactory.PcQtyList.Sum() == 0)
            {
                PrintBody(target, "Set Number of PCs");
                return;
            }
            _encounterFactory.PickRandomEncounter(biome, isStandardRace);

            PrintBody(target, _encounterFactory.LastEncounterAsString());
        }

        private void bu_rollDice_Click(object sender, EventArgs e)
        {
            int num = (int)nud_dNum.Value;
            var resultList = new List<int>();
            int size = (int)nud_dieSize.Value;
            int result = _dice.Roll(num, size, out resultList);

            string output = "";
            foreach (var roll in resultList)
            {
                output += roll.ToString() + "\n";
            }
            output += "Total: " + result.ToString();

            RichTextBox target = rtb_rndMonstOut;
            target.Clear();
            PrintBody(target, output);


        }

        private void bu_fate_Click(object sender, EventArgs e)
        {
            int chaosFactor = (int)nud_chaosFactor.Value;
            string odds = cobo_odds.Text;
            if (odds == "")
            {
                tb_fate.Text = "Set odds!";
                return;
            }

            bool isEvent;
            string result = GmEmulator.RollFate(chaosFactor, odds, out isEvent);
            tb_fate.Text = result;

            if (!isEvent) { return; }

            tb_fate.Text = tb_fate.Text + " (Event!)";

            string eventStr = GmEmulator.RollRandomEvent();
            rtb_event.Clear();
            PrintBody(rtb_event, eventStr);
        }

        private void bu_event_Click(object sender, EventArgs e)
        {
            string eventStr = GmEmulator.RollRandomEvent();
            rtb_event.Clear();
            PrintBody(rtb_event, eventStr);
        }

        private void bu_scene_Click(object sender, EventArgs e)
        {
            int chaosFactor = (int)nud_chaosFactor.Value;
            string result = GmEmulator.RollSceneMod(chaosFactor);
            tb_scene.Text = result;
        }

        private void but_CrawlRoom_Click(object sender, EventArgs e)
        {

        }
    }
}
