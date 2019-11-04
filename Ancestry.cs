using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darkmoor
{
    enum AlignmentValue
    {
        ALIGN_UNALIGNED, ALIGN_GOOD, ALIGN_EVIL, ALIGN_LAW,
        ALIGN_CHAOS, ALIGN_NEUTRAL, ALIGN_VARIES, ALIGN_UNKNOWN
    }

    /// <summary>
    /// The blueprint for members of civilizations
    /// Values should be loaded from a file or defined with constants.
    /// Or user created via interface, perhaps.
    /// 
    /// To track actual populations of this ancestry in the world, 
    /// use a seperate class, called Population.
    /// This Ancestry class initalizes a Population.
    /// </summary>
    class Ancestry
    {
        public string Name;
        public int MinAppearing;
        public int MaxAppearing;
        public int BaseAc;
        public int BaseToHit;
        public int BaseNumAttacks;
        public int HitDice;
        public int MoraleBonus;
        //public int XpValue;
        public string CR;
        public Ancestry Composite;
        public AlignmentValue AlignmentLC;
        public AlignmentValue AlignmentGE;
        public List<string> Type = new List<string>();

        public string GetCompositeName()
        {
            if (Composite is null)
            {
                return Name;
            }
            return Composite.Name + " " + Name;
        }

        public int GetXpValue()
        {
            return BestiaryMonster.GetXpValue(CR);
        }

        public int GetTier()
        {
            return BestiaryMonster.GetTier(GetXpValue());
        }
    }
}
