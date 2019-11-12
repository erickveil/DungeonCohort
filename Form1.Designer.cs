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
            this.cb_allowCommon = new System.Windows.Forms.CheckBox();
            this.cb_allowMinorUncommon = new System.Windows.Forms.CheckBox();
            this.cb_allowMinorRare = new System.Windows.Forms.CheckBox();
            this.cb_allowMinorVeryRare = new System.Windows.Forms.CheckBox();
            this.cb_allowMinorLegendary = new System.Windows.Forms.CheckBox();
            this.cb_allowMajorUncommon = new System.Windows.Forms.CheckBox();
            this.cb_allowMajorRare = new System.Windows.Forms.CheckBox();
            this.cb_allowMajorVeryRare = new System.Windows.Forms.CheckBox();
            this.cb_allowMajorLegendary = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nud_tier)).BeginInit();
            this.gb_AllowedMagicItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtb_rndMonstOut
            // 
            this.rtb_rndMonstOut.Location = new System.Drawing.Point(1245, 29);
            this.rtb_rndMonstOut.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.rtb_rndMonstOut.Name = "rtb_rndMonstOut";
            this.rtb_rndMonstOut.Size = new System.Drawing.Size(849, 1010);
            this.rtb_rndMonstOut.TabIndex = 0;
            this.rtb_rndMonstOut.Text = "";
            // 
            // bu_monster
            // 
            this.bu_monster.Location = new System.Drawing.Point(16, 172);
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
            this.nud_tier.Location = new System.Drawing.Point(117, 26);
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
            this.label1.Location = new System.Drawing.Point(35, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tier";
            // 
            // bu_genNPC
            // 
            this.bu_genNPC.Location = new System.Drawing.Point(21, 243);
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
            this.cb_biome.Location = new System.Drawing.Point(515, 21);
            this.cb_biome.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cb_biome.Name = "cb_biome";
            this.cb_biome.Size = new System.Drawing.Size(316, 39);
            this.cb_biome.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(405, 36);
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
            this.cb_stdRaceNpcs.Location = new System.Drawing.Point(885, 29);
            this.cb_stdRaceNpcs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_stdRaceNpcs.Name = "cb_stdRaceNpcs";
            this.cb_stdRaceNpcs.Size = new System.Drawing.Size(322, 36);
            this.cb_stdRaceNpcs.TabIndex = 7;
            this.cb_stdRaceNpcs.Text = "Standard Race NPCs";
            this.cb_stdRaceNpcs.UseVisualStyleBackColor = true;
            // 
            // bu_npcParty
            // 
            this.bu_npcParty.Location = new System.Drawing.Point(21, 317);
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
            this.bu_indiTreasure.Location = new System.Drawing.Point(21, 546);
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
            this.bu_hordeTreasure.Location = new System.Drawing.Point(29, 615);
            this.bu_hordeTreasure.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.bu_hordeTreasure.Name = "bu_hordeTreasure";
            this.bu_hordeTreasure.Size = new System.Drawing.Size(355, 55);
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
            this.gb_AllowedMagicItems.Location = new System.Drawing.Point(820, 370);
            this.gb_AllowedMagicItems.Name = "gb_AllowedMagicItems";
            this.gb_AllowedMagicItems.Size = new System.Drawing.Size(329, 618);
            this.gb_AllowedMagicItems.TabIndex = 11;
            this.gb_AllowedMagicItems.TabStop = false;
            this.gb_AllowedMagicItems.Text = "Allowed Magic Items";
            // 
            // cb_allowCommon
            // 
            this.cb_allowCommon.AutoSize = true;
            this.cb_allowCommon.Checked = true;
            this.cb_allowCommon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allowCommon.Location = new System.Drawing.Point(6, 88);
            this.cb_allowCommon.Name = "cb_allowCommon";
            this.cb_allowCommon.Size = new System.Drawing.Size(253, 36);
            this.cb_allowCommon.TabIndex = 0;
            this.cb_allowCommon.Text = "Minor, Common";
            this.cb_allowCommon.UseVisualStyleBackColor = true;
            // 
            // cb_allowMinorUncommon
            // 
            this.cb_allowMinorUncommon.AutoSize = true;
            this.cb_allowMinorUncommon.Checked = true;
            this.cb_allowMinorUncommon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allowMinorUncommon.Location = new System.Drawing.Point(6, 139);
            this.cb_allowMinorUncommon.Name = "cb_allowMinorUncommon";
            this.cb_allowMinorUncommon.Size = new System.Drawing.Size(283, 36);
            this.cb_allowMinorUncommon.TabIndex = 1;
            this.cb_allowMinorUncommon.Text = "Minor, Uncommon";
            this.cb_allowMinorUncommon.UseVisualStyleBackColor = true;
            // 
            // cb_allowMinorRare
            // 
            this.cb_allowMinorRare.AutoSize = true;
            this.cb_allowMinorRare.Checked = true;
            this.cb_allowMinorRare.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allowMinorRare.Location = new System.Drawing.Point(6, 187);
            this.cb_allowMinorRare.Name = "cb_allowMinorRare";
            this.cb_allowMinorRare.Size = new System.Drawing.Size(200, 36);
            this.cb_allowMinorRare.TabIndex = 2;
            this.cb_allowMinorRare.Text = "Minor, Rare";
            this.cb_allowMinorRare.UseVisualStyleBackColor = true;
            // 
            // cb_allowMinorVeryRare
            // 
            this.cb_allowMinorVeryRare.AutoSize = true;
            this.cb_allowMinorVeryRare.Checked = true;
            this.cb_allowMinorVeryRare.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allowMinorVeryRare.Location = new System.Drawing.Point(6, 240);
            this.cb_allowMinorVeryRare.Name = "cb_allowMinorVeryRare";
            this.cb_allowMinorVeryRare.Size = new System.Drawing.Size(265, 36);
            this.cb_allowMinorVeryRare.TabIndex = 3;
            this.cb_allowMinorVeryRare.Text = "Minor, Very Rare";
            this.cb_allowMinorVeryRare.UseVisualStyleBackColor = true;
            // 
            // cb_allowMinorLegendary
            // 
            this.cb_allowMinorLegendary.AutoSize = true;
            this.cb_allowMinorLegendary.Checked = true;
            this.cb_allowMinorLegendary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allowMinorLegendary.Location = new System.Drawing.Point(6, 295);
            this.cb_allowMinorLegendary.Name = "cb_allowMinorLegendary";
            this.cb_allowMinorLegendary.Size = new System.Drawing.Size(274, 36);
            this.cb_allowMinorLegendary.TabIndex = 4;
            this.cb_allowMinorLegendary.Text = "Minor, Legendary";
            this.cb_allowMinorLegendary.UseVisualStyleBackColor = true;
            // 
            // cb_allowMajorUncommon
            // 
            this.cb_allowMajorUncommon.AutoSize = true;
            this.cb_allowMajorUncommon.Checked = true;
            this.cb_allowMajorUncommon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allowMajorUncommon.Location = new System.Drawing.Point(6, 406);
            this.cb_allowMajorUncommon.Name = "cb_allowMajorUncommon";
            this.cb_allowMajorUncommon.Size = new System.Drawing.Size(283, 36);
            this.cb_allowMajorUncommon.TabIndex = 5;
            this.cb_allowMajorUncommon.Text = "Major, Uncommon";
            this.cb_allowMajorUncommon.UseVisualStyleBackColor = true;
            // 
            // cb_allowMajorRare
            // 
            this.cb_allowMajorRare.AutoSize = true;
            this.cb_allowMajorRare.Checked = true;
            this.cb_allowMajorRare.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allowMajorRare.Location = new System.Drawing.Point(6, 448);
            this.cb_allowMajorRare.Name = "cb_allowMajorRare";
            this.cb_allowMajorRare.Size = new System.Drawing.Size(200, 36);
            this.cb_allowMajorRare.TabIndex = 6;
            this.cb_allowMajorRare.Text = "Major, Rare";
            this.cb_allowMajorRare.UseVisualStyleBackColor = true;
            // 
            // cb_allowMajorVeryRare
            // 
            this.cb_allowMajorVeryRare.AutoSize = true;
            this.cb_allowMajorVeryRare.Checked = true;
            this.cb_allowMajorVeryRare.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allowMajorVeryRare.Location = new System.Drawing.Point(6, 494);
            this.cb_allowMajorVeryRare.Name = "cb_allowMajorVeryRare";
            this.cb_allowMajorVeryRare.Size = new System.Drawing.Size(265, 36);
            this.cb_allowMajorVeryRare.TabIndex = 7;
            this.cb_allowMajorVeryRare.Text = "Major, Very Rare";
            this.cb_allowMajorVeryRare.UseVisualStyleBackColor = true;
            // 
            // cb_allowMajorLegendary
            // 
            this.cb_allowMajorLegendary.AutoSize = true;
            this.cb_allowMajorLegendary.Checked = true;
            this.cb_allowMajorLegendary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allowMajorLegendary.Location = new System.Drawing.Point(6, 536);
            this.cb_allowMajorLegendary.Name = "cb_allowMajorLegendary";
            this.cb_allowMajorLegendary.Size = new System.Drawing.Size(274, 36);
            this.cb_allowMajorLegendary.TabIndex = 8;
            this.cb_allowMajorLegendary.Text = "Major, Legendary";
            this.cb_allowMajorLegendary.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2133, 1061);
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
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nud_tier)).EndInit();
            this.gb_AllowedMagicItems.ResumeLayout(false);
            this.gb_AllowedMagicItems.PerformLayout();
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
    }
}

