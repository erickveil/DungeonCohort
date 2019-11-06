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
            ((System.ComponentModel.ISupportInitialize)(this.nud_tier)).BeginInit();
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
            this.bu_monster.Location = new System.Drawing.Point(17, 172);
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
            this.bu_genNPC.Location = new System.Drawing.Point(20, 243);
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
            this.cb_stdRaceNpcs.Location = new System.Drawing.Point(886, 28);
            this.cb_stdRaceNpcs.Name = "cb_stdRaceNpcs";
            this.cb_stdRaceNpcs.Size = new System.Drawing.Size(322, 36);
            this.cb_stdRaceNpcs.TabIndex = 7;
            this.cb_stdRaceNpcs.Text = "Standard Race NPCs";
            this.cb_stdRaceNpcs.UseVisualStyleBackColor = true;
            // 
            // bu_npcParty
            // 
            this.bu_npcParty.Location = new System.Drawing.Point(20, 318);
            this.bu_npcParty.Name = "bu_npcParty";
            this.bu_npcParty.Size = new System.Drawing.Size(365, 55);
            this.bu_npcParty.TabIndex = 8;
            this.bu_npcParty.Text = "NPC Party";
            this.bu_npcParty.UseVisualStyleBackColor = true;
            this.bu_npcParty.Click += new System.EventHandler(this.bu_npcParty_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2133, 1073);
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
    }
}

