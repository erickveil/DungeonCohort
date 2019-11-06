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

        
        public Form1()
        {
            InitializeComponent();

            _ancestryIndex = AncestryIndex.Instance;
            _ancestryIndex.LoadAllSources();
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

        private void bu_monster_Click(object sender, EventArgs e)
        {
            RichTextBox target = rtb_rndMonstOut;
            target.Clear();

            int tier = (int)nud_tier.Value;
            string biome = cb_biome.Text;
            Ancestry monster = _ancestryIndex.GetRandomAncestry(tier, biome);

            string monsterName = monster.Name;
            string cr = monster.CR;
            PrintBody(target, monsterName + " (" + cr + ")" );
        }

        private void bu_genNPC_Click(object sender, EventArgs e)
        {
            RichTextBox target = rtb_rndMonstOut;
            target.Clear();

            int tier = (int)nud_tier.Value;
            Ancestry npc = _ancestryIndex.GetRandomNPC(tier, AlignmentValue.ALIGN_GOOD);

            string npcName = npc.GetCompositeName();
            string cr = npc.CR;
            PrintBody(target, npcName + " (" + cr + ")" );
        }
    }
}
