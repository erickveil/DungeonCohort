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
            this.nud_dNum = new System.Windows.Forms.NumericUpDown();
            this.nud_dieSize = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.bu_rollDice = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.nud_dNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_dieSize)).BeginInit();
            this.SuspendLayout();
            // 
            // rtb_rndMonstOut
            // 
            this.rtb_rndMonstOut.Location = new System.Drawing.Point(467, 12);
            this.rtb_rndMonstOut.Name = "rtb_rndMonstOut";
            this.rtb_rndMonstOut.Size = new System.Drawing.Size(321, 426);
            this.rtb_rndMonstOut.TabIndex = 0;
            this.rtb_rndMonstOut.Text = "";
            // 
            // bu_monster
            // 
            this.bu_monster.Location = new System.Drawing.Point(6, 72);
            this.bu_monster.Name = "bu_monster";
            this.bu_monster.Size = new System.Drawing.Size(138, 23);
            this.bu_monster.TabIndex = 1;
            this.bu_monster.Text = "Random Monster";
            this.bu_monster.UseVisualStyleBackColor = true;
            this.bu_monster.Click += new System.EventHandler(this.bu_monster_Click);
            // 
            // nud_tier
            // 
            this.nud_tier.Location = new System.Drawing.Point(44, 11);
            this.nud_tier.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nud_tier.Name = "nud_tier";
            this.nud_tier.Size = new System.Drawing.Size(42, 20);
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
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tier";
            // 
            // bu_genNPC
            // 
            this.bu_genNPC.Location = new System.Drawing.Point(8, 102);
            this.bu_genNPC.Name = "bu_genNPC";
            this.bu_genNPC.Size = new System.Drawing.Size(137, 23);
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
            this.cb_biome.Location = new System.Drawing.Point(193, 9);
            this.cb_biome.Name = "cb_biome";
            this.cb_biome.Size = new System.Drawing.Size(121, 21);
            this.cb_biome.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Biome";
            // 
            // cb_stdRaceNpcs
            // 
            this.cb_stdRaceNpcs.AutoSize = true;
            this.cb_stdRaceNpcs.Checked = true;
            this.cb_stdRaceNpcs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_stdRaceNpcs.Location = new System.Drawing.Point(332, 12);
            this.cb_stdRaceNpcs.Margin = new System.Windows.Forms.Padding(1);
            this.cb_stdRaceNpcs.Name = "cb_stdRaceNpcs";
            this.cb_stdRaceNpcs.Size = new System.Drawing.Size(128, 17);
            this.cb_stdRaceNpcs.TabIndex = 7;
            this.cb_stdRaceNpcs.Text = "Standard Race NPCs";
            this.cb_stdRaceNpcs.UseVisualStyleBackColor = true;
            // 
            // bu_npcParty
            // 
            this.bu_npcParty.Location = new System.Drawing.Point(8, 133);
            this.bu_npcParty.Margin = new System.Windows.Forms.Padding(1);
            this.bu_npcParty.Name = "bu_npcParty";
            this.bu_npcParty.Size = new System.Drawing.Size(137, 23);
            this.bu_npcParty.TabIndex = 8;
            this.bu_npcParty.Text = "NPC Party";
            this.bu_npcParty.UseVisualStyleBackColor = true;
            this.bu_npcParty.Click += new System.EventHandler(this.bu_npcParty_Click);
            // 
            // bu_indiTreasure
            // 
            this.bu_indiTreasure.Location = new System.Drawing.Point(8, 439);
            this.bu_indiTreasure.Name = "bu_indiTreasure";
            this.bu_indiTreasure.Size = new System.Drawing.Size(137, 23);
            this.bu_indiTreasure.TabIndex = 9;
            this.bu_indiTreasure.Text = "Individual Treasure";
            this.bu_indiTreasure.UseVisualStyleBackColor = true;
            this.bu_indiTreasure.Click += new System.EventHandler(this.bu_indiTreasure_Click);
            // 
            // bu_hordeTreasure
            // 
            this.bu_hordeTreasure.Location = new System.Drawing.Point(8, 468);
            this.bu_hordeTreasure.Name = "bu_hordeTreasure";
            this.bu_hordeTreasure.Size = new System.Drawing.Size(136, 23);
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
            this.gb_AllowedMagicItems.Location = new System.Drawing.Point(10, 167);
            this.gb_AllowedMagicItems.Margin = new System.Windows.Forms.Padding(1);
            this.gb_AllowedMagicItems.Name = "gb_AllowedMagicItems";
            this.gb_AllowedMagicItems.Padding = new System.Windows.Forms.Padding(1);
            this.gb_AllowedMagicItems.Size = new System.Drawing.Size(134, 259);
            this.gb_AllowedMagicItems.TabIndex = 11;
            this.gb_AllowedMagicItems.TabStop = false;
            this.gb_AllowedMagicItems.Text = "Allowed Magic Items";
            // 
            // cb_allowMajorLegendary
            // 
            this.cb_allowMajorLegendary.AutoSize = true;
            this.cb_allowMajorLegendary.Checked = true;
            this.cb_allowMajorLegendary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allowMajorLegendary.Location = new System.Drawing.Point(2, 225);
            this.cb_allowMajorLegendary.Margin = new System.Windows.Forms.Padding(1);
            this.cb_allowMajorLegendary.Name = "cb_allowMajorLegendary";
            this.cb_allowMajorLegendary.Size = new System.Drawing.Size(108, 17);
            this.cb_allowMajorLegendary.TabIndex = 8;
            this.cb_allowMajorLegendary.Text = "Major, Legendary";
            this.cb_allowMajorLegendary.UseVisualStyleBackColor = true;
            // 
            // cb_allowMajorVeryRare
            // 
            this.cb_allowMajorVeryRare.AutoSize = true;
            this.cb_allowMajorVeryRare.Checked = true;
            this.cb_allowMajorVeryRare.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allowMajorVeryRare.Location = new System.Drawing.Point(2, 207);
            this.cb_allowMajorVeryRare.Margin = new System.Windows.Forms.Padding(1);
            this.cb_allowMajorVeryRare.Name = "cb_allowMajorVeryRare";
            this.cb_allowMajorVeryRare.Size = new System.Drawing.Size(105, 17);
            this.cb_allowMajorVeryRare.TabIndex = 7;
            this.cb_allowMajorVeryRare.Text = "Major, Very Rare";
            this.cb_allowMajorVeryRare.UseVisualStyleBackColor = true;
            // 
            // cb_allowMajorRare
            // 
            this.cb_allowMajorRare.AutoSize = true;
            this.cb_allowMajorRare.Checked = true;
            this.cb_allowMajorRare.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allowMajorRare.Location = new System.Drawing.Point(2, 188);
            this.cb_allowMajorRare.Margin = new System.Windows.Forms.Padding(1);
            this.cb_allowMajorRare.Name = "cb_allowMajorRare";
            this.cb_allowMajorRare.Size = new System.Drawing.Size(81, 17);
            this.cb_allowMajorRare.TabIndex = 6;
            this.cb_allowMajorRare.Text = "Major, Rare";
            this.cb_allowMajorRare.UseVisualStyleBackColor = true;
            // 
            // cb_allowMajorUncommon
            // 
            this.cb_allowMajorUncommon.AutoSize = true;
            this.cb_allowMajorUncommon.Checked = true;
            this.cb_allowMajorUncommon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allowMajorUncommon.Location = new System.Drawing.Point(2, 170);
            this.cb_allowMajorUncommon.Margin = new System.Windows.Forms.Padding(1);
            this.cb_allowMajorUncommon.Name = "cb_allowMajorUncommon";
            this.cb_allowMajorUncommon.Size = new System.Drawing.Size(112, 17);
            this.cb_allowMajorUncommon.TabIndex = 5;
            this.cb_allowMajorUncommon.Text = "Major, Uncommon";
            this.cb_allowMajorUncommon.UseVisualStyleBackColor = true;
            // 
            // cb_allowMinorLegendary
            // 
            this.cb_allowMinorLegendary.AutoSize = true;
            this.cb_allowMinorLegendary.Checked = true;
            this.cb_allowMinorLegendary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allowMinorLegendary.Location = new System.Drawing.Point(2, 124);
            this.cb_allowMinorLegendary.Margin = new System.Windows.Forms.Padding(1);
            this.cb_allowMinorLegendary.Name = "cb_allowMinorLegendary";
            this.cb_allowMinorLegendary.Size = new System.Drawing.Size(108, 17);
            this.cb_allowMinorLegendary.TabIndex = 4;
            this.cb_allowMinorLegendary.Text = "Minor, Legendary";
            this.cb_allowMinorLegendary.UseVisualStyleBackColor = true;
            // 
            // cb_allowMinorVeryRare
            // 
            this.cb_allowMinorVeryRare.AutoSize = true;
            this.cb_allowMinorVeryRare.Checked = true;
            this.cb_allowMinorVeryRare.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allowMinorVeryRare.Location = new System.Drawing.Point(2, 101);
            this.cb_allowMinorVeryRare.Margin = new System.Windows.Forms.Padding(1);
            this.cb_allowMinorVeryRare.Name = "cb_allowMinorVeryRare";
            this.cb_allowMinorVeryRare.Size = new System.Drawing.Size(105, 17);
            this.cb_allowMinorVeryRare.TabIndex = 3;
            this.cb_allowMinorVeryRare.Text = "Minor, Very Rare";
            this.cb_allowMinorVeryRare.UseVisualStyleBackColor = true;
            // 
            // cb_allowMinorRare
            // 
            this.cb_allowMinorRare.AutoSize = true;
            this.cb_allowMinorRare.Checked = true;
            this.cb_allowMinorRare.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allowMinorRare.Location = new System.Drawing.Point(2, 78);
            this.cb_allowMinorRare.Margin = new System.Windows.Forms.Padding(1);
            this.cb_allowMinorRare.Name = "cb_allowMinorRare";
            this.cb_allowMinorRare.Size = new System.Drawing.Size(81, 17);
            this.cb_allowMinorRare.TabIndex = 2;
            this.cb_allowMinorRare.Text = "Minor, Rare";
            this.cb_allowMinorRare.UseVisualStyleBackColor = true;
            // 
            // cb_allowMinorUncommon
            // 
            this.cb_allowMinorUncommon.AutoSize = true;
            this.cb_allowMinorUncommon.Checked = true;
            this.cb_allowMinorUncommon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allowMinorUncommon.Location = new System.Drawing.Point(2, 58);
            this.cb_allowMinorUncommon.Margin = new System.Windows.Forms.Padding(1);
            this.cb_allowMinorUncommon.Name = "cb_allowMinorUncommon";
            this.cb_allowMinorUncommon.Size = new System.Drawing.Size(112, 17);
            this.cb_allowMinorUncommon.TabIndex = 1;
            this.cb_allowMinorUncommon.Text = "Minor, Uncommon";
            this.cb_allowMinorUncommon.UseVisualStyleBackColor = true;
            // 
            // cb_allowCommon
            // 
            this.cb_allowCommon.AutoSize = true;
            this.cb_allowCommon.Checked = true;
            this.cb_allowCommon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allowCommon.Location = new System.Drawing.Point(2, 37);
            this.cb_allowCommon.Margin = new System.Windows.Forms.Padding(1);
            this.cb_allowCommon.Name = "cb_allowCommon";
            this.cb_allowCommon.Size = new System.Drawing.Size(99, 17);
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
            this.gb_party.Location = new System.Drawing.Point(155, 72);
            this.gb_party.Name = "gb_party";
            this.gb_party.Size = new System.Drawing.Size(125, 170);
            this.gb_party.TabIndex = 12;
            this.gb_party.TabStop = false;
            this.gb_party.Text = "Party";
            // 
            // nud_pcQtyD
            // 
            this.nud_pcQtyD.Location = new System.Drawing.Point(67, 127);
            this.nud_pcQtyD.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_pcQtyD.Name = "nud_pcQtyD";
            this.nud_pcQtyD.Size = new System.Drawing.Size(49, 20);
            this.nud_pcQtyD.TabIndex = 9;
            // 
            // nud_pcQtyC
            // 
            this.nud_pcQtyC.Location = new System.Drawing.Point(67, 100);
            this.nud_pcQtyC.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_pcQtyC.Name = "nud_pcQtyC";
            this.nud_pcQtyC.Size = new System.Drawing.Size(49, 20);
            this.nud_pcQtyC.TabIndex = 8;
            // 
            // nud_pcQtyB
            // 
            this.nud_pcQtyB.Location = new System.Drawing.Point(66, 73);
            this.nud_pcQtyB.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_pcQtyB.Name = "nud_pcQtyB";
            this.nud_pcQtyB.Size = new System.Drawing.Size(50, 20);
            this.nud_pcQtyB.TabIndex = 7;
            // 
            // nud_pcQtyA
            // 
            this.nud_pcQtyA.Location = new System.Drawing.Point(66, 46);
            this.nud_pcQtyA.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_pcQtyA.Name = "nud_pcQtyA";
            this.nud_pcQtyA.Size = new System.Drawing.Size(50, 20);
            this.nud_pcQtyA.TabIndex = 6;
            // 
            // nud_pcLevelD
            // 
            this.nud_pcLevelD.Location = new System.Drawing.Point(10, 127);
            this.nud_pcLevelD.Name = "nud_pcLevelD";
            this.nud_pcLevelD.Size = new System.Drawing.Size(50, 20);
            this.nud_pcLevelD.TabIndex = 5;
            // 
            // nud_pcLevelC
            // 
            this.nud_pcLevelC.Location = new System.Drawing.Point(10, 100);
            this.nud_pcLevelC.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nud_pcLevelC.Name = "nud_pcLevelC";
            this.nud_pcLevelC.Size = new System.Drawing.Size(50, 20);
            this.nud_pcLevelC.TabIndex = 4;
            // 
            // nud_pcLevelB
            // 
            this.nud_pcLevelB.Location = new System.Drawing.Point(10, 73);
            this.nud_pcLevelB.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nud_pcLevelB.Name = "nud_pcLevelB";
            this.nud_pcLevelB.Size = new System.Drawing.Size(50, 20);
            this.nud_pcLevelB.TabIndex = 3;
            // 
            // nud_pcLevelA
            // 
            this.nud_pcLevelA.Location = new System.Drawing.Point(10, 46);
            this.nud_pcLevelA.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nud_pcLevelA.Name = "nud_pcLevelA";
            this.nud_pcLevelA.Size = new System.Drawing.Size(50, 20);
            this.nud_pcLevelA.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Qty";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Level";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(155, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
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
            this.cb_difficulty.Location = new System.Drawing.Point(209, 249);
            this.cb_difficulty.Name = "cb_difficulty";
            this.cb_difficulty.Size = new System.Drawing.Size(71, 21);
            this.cb_difficulty.TabIndex = 14;
            // 
            // bu_encounter
            // 
            this.bu_encounter.Location = new System.Drawing.Point(155, 276);
            this.bu_encounter.Name = "bu_encounter";
            this.bu_encounter.Size = new System.Drawing.Size(125, 23);
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
            this.gb_dice.Location = new System.Drawing.Point(286, 72);
            this.gb_dice.Name = "gb_dice";
            this.gb_dice.Size = new System.Drawing.Size(129, 84);
            this.gb_dice.TabIndex = 16;
            this.gb_dice.TabStop = false;
            this.gb_dice.Text = "Dice";
            // 
            // nud_dNum
            // 
            this.nud_dNum.Location = new System.Drawing.Point(6, 20);
            this.nud_dNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_dNum.Name = "nud_dNum";
            this.nud_dNum.Size = new System.Drawing.Size(44, 20);
            this.nud_dNum.TabIndex = 0;
            this.nud_dNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nud_dieSize
            // 
            this.nud_dieSize.Location = new System.Drawing.Point(75, 20);
            this.nud_dieSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_dieSize.Name = "nud_dieSize";
            this.nud_dieSize.Size = new System.Drawing.Size(44, 20);
            this.nud_dieSize.TabIndex = 1;
            this.nud_dieSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "d";
            // 
            // bu_rollDice
            // 
            this.bu_rollDice.Location = new System.Drawing.Point(7, 46);
            this.bu_rollDice.Name = "bu_rollDice";
            this.bu_rollDice.Size = new System.Drawing.Size(112, 23);
            this.bu_rollDice.TabIndex = 3;
            this.bu_rollDice.Text = "Roll";
            this.bu_rollDice.UseVisualStyleBackColor = true;
            this.bu_rollDice.Click += new System.EventHandler(this.bu_rollDice_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 508);
            this.Controls.Add(this.gb_dice);
            this.Controls.Add(this.bu_encounter);
            this.Controls.Add(this.cb_difficulty);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gb_party);
            this.Controls.Add(this.gb_AllowedMagicItems);
            this.Controls.Add(this.bu_hordeTreasure);
            this.Controls.Add(this.bu_indiTreasure);
            this.Controls.Add(this.bu_npcParty);
            this.Controls.Add(this.cb_stdRaceNpcs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_biome);
            this.Controls.Add(this.bu_genNPC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nud_tier);
            this.Controls.Add(this.bu_monster);
            this.Controls.Add(this.rtb_rndMonstOut);
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
            ((System.ComponentModel.ISupportInitialize)(this.nud_dNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_dieSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

