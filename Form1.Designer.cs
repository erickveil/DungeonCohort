namespace DungeonCohort
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtb_rndMonstOut = new System.Windows.Forms.RichTextBox();
            this.bu_monster = new System.Windows.Forms.Button();
            this.nud_tier = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.bu_genNPC = new System.Windows.Forms.Button();
            this.cb_biome = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_stdRaceNpcs = new System.Windows.Forms.CheckBox();
            this.bu_npcParty = new System.Windows.Forms.Button();
            this.bu_indiTreasure = new System.Windows.Forms.Button();
            this.bu_hordeTreasure = new System.Windows.Forms.Button();
            this.gb_AllowedMagicItems = new System.Windows.Forms.GroupBox();
            this.cb_allowMajorLegendary = new System.Windows.Forms.CheckBox();
            this.cb_allowMajorVeryRare = new System.Windows.Forms.CheckBox();
            this.cb_allowMajorRare = new System.Windows.Forms.CheckBox();
            this.cb_allowMajorUncommon = new System.Windows.Forms.CheckBox();
            this.cb_allowMinorLegendary = new System.Windows.Forms.CheckBox();
            this.cb_allowMinorVeryRare = new System.Windows.Forms.CheckBox();
            this.cb_allowMinorRare = new System.Windows.Forms.CheckBox();
            this.cb_allowMinorUncommon = new System.Windows.Forms.CheckBox();
            this.cb_allowCommon = new System.Windows.Forms.CheckBox();
            this.gb_party = new System.Windows.Forms.GroupBox();
            this.nud_pcQtyD = new System.Windows.Forms.NumericUpDown();
            this.nud_pcQtyC = new System.Windows.Forms.NumericUpDown();
            this.nud_pcQtyB = new System.Windows.Forms.NumericUpDown();
            this.nud_pcQtyA = new System.Windows.Forms.NumericUpDown();
            this.nud_pcLevelD = new System.Windows.Forms.NumericUpDown();
            this.nud_pcLevelC = new System.Windows.Forms.NumericUpDown();
            this.nud_pcLevelB = new System.Windows.Forms.NumericUpDown();
            this.nud_pcLevelA = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_difficulty = new System.Windows.Forms.ComboBox();
            this.bu_encounter = new System.Windows.Forms.Button();
            this.gb_dice = new System.Windows.Forms.GroupBox();
            this.bu_rollDice = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.nud_dieSize = new System.Windows.Forms.NumericUpDown();
            this.nud_dNum = new System.Windows.Forms.NumericUpDown();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_dev = new System.Windows.Forms.TabPage();
            this.tab_mythic = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.nud_chaosFactor = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.cobo_odds = new System.Windows.Forms.ComboBox();
            this.bu_fate = new System.Windows.Forms.Button();
            this.tb_fate = new System.Windows.Forms.TextBox();
            this.bu_event = new System.Windows.Forms.Button();
            this.rtb_event = new System.Windows.Forms.RichTextBox();
            this.bu_scene = new System.Windows.Forms.Button();
            this.tb_scene = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nud_tier)).BeginInit();
            this.gb_AllowedMagicItems.SuspendLayout();
            this.gb_party.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pcQtyD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pcQtyC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pcQtyB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pcQtyA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pcLevelD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pcLevelC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pcLevelB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pcLevelA)).BeginInit();
            this.gb_dice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_dieSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_dNum)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tab_dev.SuspendLayout();
            this.tab_mythic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_chaosFactor)).BeginInit();
            this.SuspendLayout();
            // 
            // rtb_rndMonstOut
            // 
            this.rtb_rndMonstOut.Location = new System.Drawing.Point(1432, 26);
            this.rtb_rndMonstOut.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.rtb_rndMonstOut.Name = "rtb_rndMonstOut";
            this.rtb_rndMonstOut.Size = new System.Drawing.Size(849, 1010);
            this.rtb_rndMonstOut.TabIndex = 0;
            this.rtb_rndMonstOut.Text = "";
            // 
            // bu_monster
            // 
            this.bu_monster.Location = new System.Drawing.Point(243, 93);
            this.bu_monster.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.bu_monster.Name = "bu_monster";
            this.bu_monster.Size = new System.Drawing.Size(368, 55);
            this.bu_monster.TabIndex = 1;
            this.bu_monster.Text = "Random Monster";
            this.bu_monster.UseVisualStyleBackColor = true;
            this.bu_monster.Click += new System.EventHandler(this.bu_monster_Click);
            // 
            // nud_tier
            // 
            this.nud_tier.Location = new System.Drawing.Point(499, 24);
            this.nud_tier.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.nud_tier.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nud_tier.Name = "nud_tier";
            this.nud_tier.Size = new System.Drawing.Size(112, 38);
            this.nud_tier.TabIndex = 2;
            this.nud_tier.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(419, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tier";
            // 
            // bu_genNPC
            // 
            this.bu_genNPC.Location = new System.Drawing.Point(243, 172);
            this.bu_genNPC.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.bu_genNPC.Name = "bu_genNPC";
            this.bu_genNPC.Size = new System.Drawing.Size(365, 55);
            this.bu_genNPC.TabIndex = 4;
            this.bu_genNPC.Text = "NPC";
            this.bu_genNPC.UseVisualStyleBackColor = true;
            this.bu_genNPC.Click += new System.EventHandler(this.bu_genNPC_Click);
            // 
            // cb_biome
            // 
            this.cb_biome.FormattingEnabled = true;
            this.cb_biome.Items.AddRange(new object[] {
            "Dungeon",
            "Wilderness",
            "Lawful Civ",
            "Chaos Civ",
            "Neutral Civ"});
            this.cb_biome.Location = new System.Drawing.Point(739, 23);
            this.cb_biome.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cb_biome.Name = "cb_biome";
            this.cb_biome.Size = new System.Drawing.Size(316, 39);
            this.cb_biome.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(627, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "Biome";
            // 
            // cb_stdRaceNpcs
            // 
            this.cb_stdRaceNpcs.AutoSize = true;
            this.cb_stdRaceNpcs.Checked = true;
            this.cb_stdRaceNpcs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_stdRaceNpcs.Location = new System.Drawing.Point(1082, 26);
            this.cb_stdRaceNpcs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_stdRaceNpcs.Name = "cb_stdRaceNpcs";
            this.cb_stdRaceNpcs.Size = new System.Drawing.Size(322, 36);
            this.cb_stdRaceNpcs.TabIndex = 7;
            this.cb_stdRaceNpcs.Text = "Standard Race NPCs";
            this.cb_stdRaceNpcs.UseVisualStyleBackColor = true;
            // 
            // bu_npcParty
            // 
            this.bu_npcParty.Location = new System.Drawing.Point(243, 246);
            this.bu_npcParty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bu_npcParty.Name = "bu_npcParty";
            this.bu_npcParty.Size = new System.Drawing.Size(365, 55);
            this.bu_npcParty.TabIndex = 8;
            this.bu_npcParty.Text = "NPC Party";
            this.bu_npcParty.UseVisualStyleBackColor = true;
            this.bu_npcParty.Click += new System.EventHandler(this.bu_npcParty_Click);
            // 
            // bu_indiTreasure
            // 
            this.bu_indiTreasure.Location = new System.Drawing.Point(243, 976);
            this.bu_indiTreasure.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.bu_indiTreasure.Name = "bu_indiTreasure";
            this.bu_indiTreasure.Size = new System.Drawing.Size(365, 55);
            this.bu_indiTreasure.TabIndex = 9;
            this.bu_indiTreasure.Text = "Individual Treasure";
            this.bu_indiTreasure.UseVisualStyleBackColor = true;
            this.bu_indiTreasure.Click += new System.EventHandler(this.bu_indiTreasure_Click);
            // 
            // bu_hordeTreasure
            // 
            this.bu_hordeTreasure.Location = new System.Drawing.Point(243, 1045);
            this.bu_hordeTreasure.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.bu_hordeTreasure.Name = "bu_hordeTreasure";
            this.bu_hordeTreasure.Size = new System.Drawing.Size(363, 55);
            this.bu_hordeTreasure.TabIndex = 10;
            this.bu_hordeTreasure.Text = "Horde Treasure";
            this.bu_hordeTreasure.UseVisualStyleBackColor = true;
            this.bu_hordeTreasure.Click += new System.EventHandler(this.bu_hordeTreasure_Click);
            // 
            // gb_AllowedMagicItems
            // 
            this.gb_AllowedMagicItems.Controls.Add(this.cb_allowMajorLegendary);
            this.gb_AllowedMagicItems.Controls.Add(this.cb_allowMajorVeryRare);
            this.gb_AllowedMagicItems.Controls.Add(this.cb_allowMajorRare);
            this.gb_AllowedMagicItems.Controls.Add(this.cb_allowMajorUncommon);
            this.gb_AllowedMagicItems.Controls.Add(this.cb_allowMinorLegendary);
            this.gb_AllowedMagicItems.Controls.Add(this.cb_allowMinorVeryRare);
            this.gb_AllowedMagicItems.Controls.Add(this.cb_allowMinorRare);
            this.gb_AllowedMagicItems.Controls.Add(this.cb_allowMinorUncommon);
            this.gb_AllowedMagicItems.Controls.Add(this.cb_allowCommon);
            this.gb_AllowedMagicItems.Location = new System.Drawing.Point(249, 327);
            this.gb_AllowedMagicItems.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_AllowedMagicItems.Name = "gb_AllowedMagicItems";
            this.gb_AllowedMagicItems.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_AllowedMagicItems.Size = new System.Drawing.Size(357, 618);
            this.gb_AllowedMagicItems.TabIndex = 11;
            this.gb_AllowedMagicItems.TabStop = false;
            this.gb_AllowedMagicItems.Text = "Allowed Magic Items";
            // 
            // cb_allowMajorLegendary
            // 
            this.cb_allowMajorLegendary.AutoSize = true;
            this.cb_allowMajorLegendary.Checked = true;
            this.cb_allowMajorLegendary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allowMajorLegendary.Location = new System.Drawing.Point(5, 537);
            this.cb_allowMajorLegendary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_allowMajorLegendary.Name = "cb_allowMajorLegendary";
            this.cb_allowMajorLegendary.Size = new System.Drawing.Size(274, 36);
            this.cb_allowMajorLegendary.TabIndex = 8;
            this.cb_allowMajorLegendary.Text = "Major, Legendary";
            this.cb_allowMajorLegendary.UseVisualStyleBackColor = true;
            // 
            // cb_allowMajorVeryRare
            // 
            this.cb_allowMajorVeryRare.AutoSize = true;
            this.cb_allowMajorVeryRare.Checked = true;
            this.cb_allowMajorVeryRare.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allowMajorVeryRare.Location = new System.Drawing.Point(5, 494);
            this.cb_allowMajorVeryRare.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_allowMajorVeryRare.Name = "cb_allowMajorVeryRare";
            this.cb_allowMajorVeryRare.Size = new System.Drawing.Size(265, 36);
            this.cb_allowMajorVeryRare.TabIndex = 7;
            this.cb_allowMajorVeryRare.Text = "Major, Very Rare";
            this.cb_allowMajorVeryRare.UseVisualStyleBackColor = true;
            // 
            // cb_allowMajorRare
            // 
            this.cb_allowMajorRare.AutoSize = true;
            this.cb_allowMajorRare.Checked = true;
            this.cb_allowMajorRare.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allowMajorRare.Location = new System.Drawing.Point(5, 448);
            this.cb_allowMajorRare.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_allowMajorRare.Name = "cb_allowMajorRare";
            this.cb_allowMajorRare.Size = new System.Drawing.Size(200, 36);
            this.cb_allowMajorRare.TabIndex = 6;
            this.cb_allowMajorRare.Text = "Major, Rare";
            this.cb_allowMajorRare.UseVisualStyleBackColor = true;
            // 
            // cb_allowMajorUncommon
            // 
            this.cb_allowMajorUncommon.AutoSize = true;
            this.cb_allowMajorUncommon.Checked = true;
            this.cb_allowMajorUncommon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allowMajorUncommon.Location = new System.Drawing.Point(5, 405);
            this.cb_allowMajorUncommon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_allowMajorUncommon.Name = "cb_allowMajorUncommon";
            this.cb_allowMajorUncommon.Size = new System.Drawing.Size(283, 36);
            this.cb_allowMajorUncommon.TabIndex = 5;
            this.cb_allowMajorUncommon.Text = "Major, Uncommon";
            this.cb_allowMajorUncommon.UseVisualStyleBackColor = true;
            // 
            // cb_allowMinorLegendary
            // 
            this.cb_allowMinorLegendary.AutoSize = true;
            this.cb_allowMinorLegendary.Checked = true;
            this.cb_allowMinorLegendary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allowMinorLegendary.Location = new System.Drawing.Point(5, 296);
            this.cb_allowMinorLegendary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_allowMinorLegendary.Name = "cb_allowMinorLegendary";
            this.cb_allowMinorLegendary.Size = new System.Drawing.Size(274, 36);
            this.cb_allowMinorLegendary.TabIndex = 4;
            this.cb_allowMinorLegendary.Text = "Minor, Legendary";
            this.cb_allowMinorLegendary.UseVisualStyleBackColor = true;
            // 
            // cb_allowMinorVeryRare
            // 
            this.cb_allowMinorVeryRare.AutoSize = true;
            this.cb_allowMinorVeryRare.Checked = true;
            this.cb_allowMinorVeryRare.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allowMinorVeryRare.Location = new System.Drawing.Point(5, 241);
            this.cb_allowMinorVeryRare.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_allowMinorVeryRare.Name = "cb_allowMinorVeryRare";
            this.cb_allowMinorVeryRare.Size = new System.Drawing.Size(265, 36);
            this.cb_allowMinorVeryRare.TabIndex = 3;
            this.cb_allowMinorVeryRare.Text = "Minor, Very Rare";
            this.cb_allowMinorVeryRare.UseVisualStyleBackColor = true;
            // 
            // cb_allowMinorRare
            // 
            this.cb_allowMinorRare.AutoSize = true;
            this.cb_allowMinorRare.Checked = true;
            this.cb_allowMinorRare.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allowMinorRare.Location = new System.Drawing.Point(5, 186);
            this.cb_allowMinorRare.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_allowMinorRare.Name = "cb_allowMinorRare";
            this.cb_allowMinorRare.Size = new System.Drawing.Size(200, 36);
            this.cb_allowMinorRare.TabIndex = 2;
            this.cb_allowMinorRare.Text = "Minor, Rare";
            this.cb_allowMinorRare.UseVisualStyleBackColor = true;
            // 
            // cb_allowMinorUncommon
            // 
            this.cb_allowMinorUncommon.AutoSize = true;
            this.cb_allowMinorUncommon.Checked = true;
            this.cb_allowMinorUncommon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allowMinorUncommon.Location = new System.Drawing.Point(5, 138);
            this.cb_allowMinorUncommon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_allowMinorUncommon.Name = "cb_allowMinorUncommon";
            this.cb_allowMinorUncommon.Size = new System.Drawing.Size(283, 36);
            this.cb_allowMinorUncommon.TabIndex = 1;
            this.cb_allowMinorUncommon.Text = "Minor, Uncommon";
            this.cb_allowMinorUncommon.UseVisualStyleBackColor = true;
            // 
            // cb_allowCommon
            // 
            this.cb_allowCommon.AutoSize = true;
            this.cb_allowCommon.Checked = true;
            this.cb_allowCommon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allowCommon.Location = new System.Drawing.Point(5, 88);
            this.cb_allowCommon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_allowCommon.Name = "cb_allowCommon";
            this.cb_allowCommon.Size = new System.Drawing.Size(253, 36);
            this.cb_allowCommon.TabIndex = 0;
            this.cb_allowCommon.Text = "Minor, Common";
            this.cb_allowCommon.UseVisualStyleBackColor = true;
            // 
            // gb_party
            // 
            this.gb_party.Controls.Add(this.nud_pcQtyD);
            this.gb_party.Controls.Add(this.nud_pcQtyC);
            this.gb_party.Controls.Add(this.nud_pcQtyB);
            this.gb_party.Controls.Add(this.nud_pcQtyA);
            this.gb_party.Controls.Add(this.nud_pcLevelD);
            this.gb_party.Controls.Add(this.nud_pcLevelC);
            this.gb_party.Controls.Add(this.nud_pcLevelB);
            this.gb_party.Controls.Add(this.nud_pcLevelA);
            this.gb_party.Controls.Add(this.label4);
            this.gb_party.Controls.Add(this.label3);
            this.gb_party.Location = new System.Drawing.Point(633, 93);
            this.gb_party.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.gb_party.Name = "gb_party";
            this.gb_party.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.gb_party.Size = new System.Drawing.Size(333, 405);
            this.gb_party.TabIndex = 12;
            this.gb_party.TabStop = false;
            this.gb_party.Text = "Party";
            // 
            // nud_pcQtyD
            // 
            this.nud_pcQtyD.Location = new System.Drawing.Point(179, 303);
            this.nud_pcQtyD.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.nud_pcQtyD.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_pcQtyD.Name = "nud_pcQtyD";
            this.nud_pcQtyD.Size = new System.Drawing.Size(131, 38);
            this.nud_pcQtyD.TabIndex = 9;
            // 
            // nud_pcQtyC
            // 
            this.nud_pcQtyC.Location = new System.Drawing.Point(179, 238);
            this.nud_pcQtyC.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.nud_pcQtyC.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_pcQtyC.Name = "nud_pcQtyC";
            this.nud_pcQtyC.Size = new System.Drawing.Size(131, 38);
            this.nud_pcQtyC.TabIndex = 8;
            // 
            // nud_pcQtyB
            // 
            this.nud_pcQtyB.Location = new System.Drawing.Point(176, 174);
            this.nud_pcQtyB.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.nud_pcQtyB.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_pcQtyB.Name = "nud_pcQtyB";
            this.nud_pcQtyB.Size = new System.Drawing.Size(133, 38);
            this.nud_pcQtyB.TabIndex = 7;
            // 
            // nud_pcQtyA
            // 
            this.nud_pcQtyA.Location = new System.Drawing.Point(176, 110);
            this.nud_pcQtyA.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.nud_pcQtyA.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_pcQtyA.Name = "nud_pcQtyA";
            this.nud_pcQtyA.Size = new System.Drawing.Size(133, 38);
            this.nud_pcQtyA.TabIndex = 6;
            // 
            // nud_pcLevelD
            // 
            this.nud_pcLevelD.Location = new System.Drawing.Point(27, 303);
            this.nud_pcLevelD.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.nud_pcLevelD.Name = "nud_pcLevelD";
            this.nud_pcLevelD.Size = new System.Drawing.Size(133, 38);
            this.nud_pcLevelD.TabIndex = 5;
            // 
            // nud_pcLevelC
            // 
            this.nud_pcLevelC.Location = new System.Drawing.Point(27, 238);
            this.nud_pcLevelC.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.nud_pcLevelC.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nud_pcLevelC.Name = "nud_pcLevelC";
            this.nud_pcLevelC.Size = new System.Drawing.Size(133, 38);
            this.nud_pcLevelC.TabIndex = 4;
            // 
            // nud_pcLevelB
            // 
            this.nud_pcLevelB.Location = new System.Drawing.Point(27, 174);
            this.nud_pcLevelB.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.nud_pcLevelB.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nud_pcLevelB.Name = "nud_pcLevelB";
            this.nud_pcLevelB.Size = new System.Drawing.Size(133, 38);
            this.nud_pcLevelB.TabIndex = 3;
            // 
            // nud_pcLevelA
            // 
            this.nud_pcLevelA.Location = new System.Drawing.Point(27, 110);
            this.nud_pcLevelA.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.nud_pcLevelA.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nud_pcLevelA.Name = "nud_pcLevelA";
            this.nud_pcLevelA.Size = new System.Drawing.Size(133, 38);
            this.nud_pcLevelA.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 32);
            this.label4.TabIndex = 1;
            this.label4.Text = "Qty";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 32);
            this.label3.TabIndex = 0;
            this.label3.Text = "Level";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(627, 522);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 32);
            this.label5.TabIndex = 13;
            this.label5.Text = "Difficulty";
            // 
            // cb_difficulty
            // 
            this.cb_difficulty.FormattingEnabled = true;
            this.cb_difficulty.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard",
            "Deadly"});
            this.cb_difficulty.Location = new System.Drawing.Point(783, 519);
            this.cb_difficulty.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cb_difficulty.Name = "cb_difficulty";
            this.cb_difficulty.Size = new System.Drawing.Size(183, 39);
            this.cb_difficulty.TabIndex = 14;
            // 
            // bu_encounter
            // 
            this.bu_encounter.Location = new System.Drawing.Point(633, 584);
            this.bu_encounter.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.bu_encounter.Name = "bu_encounter";
            this.bu_encounter.Size = new System.Drawing.Size(333, 55);
            this.bu_encounter.TabIndex = 15;
            this.bu_encounter.Text = "Encounter";
            this.bu_encounter.UseVisualStyleBackColor = true;
            this.bu_encounter.Click += new System.EventHandler(this.bu_encounter_Click);
            // 
            // gb_dice
            // 
            this.gb_dice.Controls.Add(this.bu_rollDice);
            this.gb_dice.Controls.Add(this.label6);
            this.gb_dice.Controls.Add(this.nud_dieSize);
            this.gb_dice.Controls.Add(this.nud_dNum);
            this.gb_dice.Location = new System.Drawing.Point(994, 93);
            this.gb_dice.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.gb_dice.Name = "gb_dice";
            this.gb_dice.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.gb_dice.Size = new System.Drawing.Size(344, 200);
            this.gb_dice.TabIndex = 16;
            this.gb_dice.TabStop = false;
            this.gb_dice.Text = "Dice";
            // 
            // bu_rollDice
            // 
            this.bu_rollDice.Location = new System.Drawing.Point(19, 110);
            this.bu_rollDice.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.bu_rollDice.Name = "bu_rollDice";
            this.bu_rollDice.Size = new System.Drawing.Size(299, 55);
            this.bu_rollDice.TabIndex = 3;
            this.bu_rollDice.Text = "Roll";
            this.bu_rollDice.UseVisualStyleBackColor = true;
            this.bu_rollDice.Click += new System.EventHandler(this.bu_rollDice_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(149, 52);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 32);
            this.label6.TabIndex = 2;
            this.label6.Text = "d";
            // 
            // nud_dieSize
            // 
            this.nud_dieSize.Location = new System.Drawing.Point(200, 48);
            this.nud_dieSize.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.nud_dieSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_dieSize.Name = "nud_dieSize";
            this.nud_dieSize.Size = new System.Drawing.Size(117, 38);
            this.nud_dieSize.TabIndex = 1;
            this.nud_dieSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // nud_dNum
            // 
            this.nud_dNum.Location = new System.Drawing.Point(16, 48);
            this.nud_dNum.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.nud_dNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_dNum.Name = "nud_dNum";
            this.nud_dNum.Size = new System.Drawing.Size(117, 38);
            this.nud_dNum.TabIndex = 0;
            this.nud_dNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_dev);
            this.tabControl1.Controls.Add(this.tab_mythic);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(2334, 1221);
            this.tabControl1.TabIndex = 17;
            // 
            // tab_dev
            // 
            this.tab_dev.Controls.Add(this.rtb_rndMonstOut);
            this.tab_dev.Controls.Add(this.gb_AllowedMagicItems);
            this.tab_dev.Controls.Add(this.bu_encounter);
            this.tab_dev.Controls.Add(this.bu_hordeTreasure);
            this.tab_dev.Controls.Add(this.gb_dice);
            this.tab_dev.Controls.Add(this.bu_indiTreasure);
            this.tab_dev.Controls.Add(this.cb_difficulty);
            this.tab_dev.Controls.Add(this.bu_npcParty);
            this.tab_dev.Controls.Add(this.cb_stdRaceNpcs);
            this.tab_dev.Controls.Add(this.bu_genNPC);
            this.tab_dev.Controls.Add(this.label5);
            this.tab_dev.Controls.Add(this.cb_biome);
            this.tab_dev.Controls.Add(this.label2);
            this.tab_dev.Controls.Add(this.nud_tier);
            this.tab_dev.Controls.Add(this.gb_party);
            this.tab_dev.Controls.Add(this.label1);
            this.tab_dev.Controls.Add(this.bu_monster);
            this.tab_dev.Location = new System.Drawing.Point(10, 48);
            this.tab_dev.Name = "tab_dev";
            this.tab_dev.Padding = new System.Windows.Forms.Padding(3);
            this.tab_dev.Size = new System.Drawing.Size(2314, 1163);
            this.tab_dev.TabIndex = 0;
            this.tab_dev.Text = "Development";
            this.tab_dev.UseVisualStyleBackColor = true;
            // 
            // tab_mythic
            // 
            this.tab_mythic.Controls.Add(this.tb_scene);
            this.tab_mythic.Controls.Add(this.bu_scene);
            this.tab_mythic.Controls.Add(this.rtb_event);
            this.tab_mythic.Controls.Add(this.bu_event);
            this.tab_mythic.Controls.Add(this.tb_fate);
            this.tab_mythic.Controls.Add(this.bu_fate);
            this.tab_mythic.Controls.Add(this.cobo_odds);
            this.tab_mythic.Controls.Add(this.label8);
            this.tab_mythic.Controls.Add(this.nud_chaosFactor);
            this.tab_mythic.Controls.Add(this.label7);
            this.tab_mythic.Location = new System.Drawing.Point(10, 48);
            this.tab_mythic.Name = "tab_mythic";
            this.tab_mythic.Padding = new System.Windows.Forms.Padding(3);
            this.tab_mythic.Size = new System.Drawing.Size(2314, 1163);
            this.tab_mythic.TabIndex = 1;
            this.tab_mythic.Text = "GM Emulation";
            this.tab_mythic.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(460, 80);
            this.label7.TabIndex = 0;
            this.label7.Text = "Chaos Factor";
            // 
            // nud_chaosFactor
            // 
            this.nud_chaosFactor.Location = new System.Drawing.Point(213, 18);
            this.nud_chaosFactor.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nud_chaosFactor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_chaosFactor.Name = "nud_chaosFactor";
            this.nud_chaosFactor.Size = new System.Drawing.Size(120, 38);
            this.nud_chaosFactor.TabIndex = 1;
            this.nud_chaosFactor.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(339, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(208, 80);
            this.label8.TabIndex = 2;
            this.label8.Text = "Odds";
            // 
            // cobo_odds
            // 
            this.cobo_odds.FormattingEnabled = true;
            this.cobo_odds.Items.AddRange(new object[] {
            "Impossible",
            "No way",
            "Very unlikely",
            "Unlikely",
            "50/50",
            "Somewhat likely",
            "Very likely",
            "Near sure thing",
            "A sure thing",
            "Has to be"});
            this.cobo_odds.Location = new System.Drawing.Point(426, 17);
            this.cobo_odds.Name = "cobo_odds";
            this.cobo_odds.Size = new System.Drawing.Size(226, 39);
            this.cobo_odds.TabIndex = 3;
            // 
            // bu_fate
            // 
            this.bu_fate.Location = new System.Drawing.Point(26, 65);
            this.bu_fate.Name = "bu_fate";
            this.bu_fate.Size = new System.Drawing.Size(182, 50);
            this.bu_fate.TabIndex = 4;
            this.bu_fate.Text = "Fate";
            this.bu_fate.UseVisualStyleBackColor = true;
            this.bu_fate.Click += new System.EventHandler(this.bu_fate_Click);
            // 
            // tb_fate
            // 
            this.tb_fate.Location = new System.Drawing.Point(225, 72);
            this.tb_fate.Name = "tb_fate";
            this.tb_fate.Size = new System.Drawing.Size(236, 38);
            this.tb_fate.TabIndex = 5;
            // 
            // bu_event
            // 
            this.bu_event.Location = new System.Drawing.Point(26, 133);
            this.bu_event.Name = "bu_event";
            this.bu_event.Size = new System.Drawing.Size(182, 50);
            this.bu_event.TabIndex = 6;
            this.bu_event.Text = "Event";
            this.bu_event.UseVisualStyleBackColor = true;
            this.bu_event.Click += new System.EventHandler(this.bu_event_Click);
            // 
            // rtb_event
            // 
            this.rtb_event.Location = new System.Drawing.Point(225, 133);
            this.rtb_event.Name = "rtb_event";
            this.rtb_event.Size = new System.Drawing.Size(236, 223);
            this.rtb_event.TabIndex = 7;
            this.rtb_event.Text = "";
            // 
            // bu_scene
            // 
            this.bu_scene.Location = new System.Drawing.Point(26, 363);
            this.bu_scene.Name = "bu_scene";
            this.bu_scene.Size = new System.Drawing.Size(182, 50);
            this.bu_scene.TabIndex = 8;
            this.bu_scene.Text = "Scene";
            this.bu_scene.UseVisualStyleBackColor = true;
            // 
            // tb_scene
            // 
            this.tb_scene.Location = new System.Drawing.Point(233, 370);
            this.tb_scene.Name = "tb_scene";
            this.tb_scene.Size = new System.Drawing.Size(228, 38);
            this.tb_scene.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2371, 1258);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nud_tier)).EndInit();
            this.gb_AllowedMagicItems.ResumeLayout(false);
            this.gb_AllowedMagicItems.PerformLayout();
            this.gb_party.ResumeLayout(false);
            this.gb_party.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pcQtyD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pcQtyC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pcQtyB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pcQtyA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pcLevelD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pcLevelC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pcLevelB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pcLevelA)).EndInit();
            this.gb_dice.ResumeLayout(false);
            this.gb_dice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_dieSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_dNum)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tab_dev.ResumeLayout(false);
            this.tab_dev.PerformLayout();
            this.tab_mythic.ResumeLayout(false);
            this.tab_mythic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_chaosFactor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_rndMonstOut;
        private System.Windows.Forms.Button bu_monster;
        private System.Windows.Forms.NumericUpDown nud_tier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bu_genNPC;
        private System.Windows.Forms.ComboBox cb_biome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cb_stdRaceNpcs;
        private System.Windows.Forms.Button bu_npcParty;
        private System.Windows.Forms.Button bu_indiTreasure;
        private System.Windows.Forms.Button bu_hordeTreasure;
        private System.Windows.Forms.GroupBox gb_AllowedMagicItems;
        private System.Windows.Forms.CheckBox cb_allowMajorLegendary;
        private System.Windows.Forms.CheckBox cb_allowMajorVeryRare;
        private System.Windows.Forms.CheckBox cb_allowMajorRare;
        private System.Windows.Forms.CheckBox cb_allowMajorUncommon;
        private System.Windows.Forms.CheckBox cb_allowMinorLegendary;
        private System.Windows.Forms.CheckBox cb_allowMinorVeryRare;
        private System.Windows.Forms.CheckBox cb_allowMinorRare;
        private System.Windows.Forms.CheckBox cb_allowMinorUncommon;
        private System.Windows.Forms.CheckBox cb_allowCommon;
        private System.Windows.Forms.GroupBox gb_party;
        private System.Windows.Forms.NumericUpDown nud_pcQtyD;
        private System.Windows.Forms.NumericUpDown nud_pcQtyC;
        private System.Windows.Forms.NumericUpDown nud_pcQtyB;
        private System.Windows.Forms.NumericUpDown nud_pcQtyA;
        private System.Windows.Forms.NumericUpDown nud_pcLevelD;
        private System.Windows.Forms.NumericUpDown nud_pcLevelC;
        private System.Windows.Forms.NumericUpDown nud_pcLevelB;
        private System.Windows.Forms.NumericUpDown nud_pcLevelA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_difficulty;
        private System.Windows.Forms.Button bu_encounter;
        private System.Windows.Forms.GroupBox gb_dice;
        private System.Windows.Forms.Button bu_rollDice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nud_dieSize;
        private System.Windows.Forms.NumericUpDown nud_dNum;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_dev;
        private System.Windows.Forms.TabPage tab_mythic;
        private System.Windows.Forms.TextBox tb_scene;
        private System.Windows.Forms.Button bu_scene;
        private System.Windows.Forms.RichTextBox rtb_event;
        private System.Windows.Forms.Button bu_event;
        private System.Windows.Forms.TextBox tb_fate;
        private System.Windows.Forms.Button bu_fate;
        private System.Windows.Forms.ComboBox cobo_odds;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nud_chaosFactor;
        private System.Windows.Forms.Label label7;
    }
}

