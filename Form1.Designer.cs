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
            ((System.ComponentModel.ISupportInitialize)(this.nud_tier)).BeginInit();
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
            this.bu_monster.Location = new System.Drawing.Point(12, 57);
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
            this.bu_genNPC.Location = new System.Drawing.Point(13, 87);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

