using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    /// <summary>
    /// Characters represent individuals, NPCs, Boss monsters, etc.
    /// A composit ancestry will suggest class/race combos, or just a simple
    /// ancestry can suggest a more typical creature.
    /// </summary>
    class Character
    {
        private Ancestry ancestry;
        public string _gender;
        public AlignmentValue _alignLC;
        public AlignmentValue _alignGE;

        internal Ancestry Ancestry { get => ancestry; set => ancestry = value; }

        // name
        // personal loot
        // faction
        // description
        // disposition
        // ai
        // motivation / backstory
        // villain actions / feats / upgrades

        public void Init(Ancestry ancestry)
        {
            Ancestry = ancestry;
            _gender = ChoseGender();
            _initAlignment();
        }

        public string GetFullIdentifier()
        {
            return _gender + " " + Ancestry.Composite.Name + " " 
                + Ancestry.Name;
        }

        public string GetAlignmentString()
        {
            if (_alignGE == AlignmentValue.ALIGN_NEUTRAL
                && _alignLC == AlignmentValue.ALIGN_NEUTRAL)
            {
                return "True Neutral";
            }
            return GetAlignmentString(_alignLC) + " " 
                + GetAlignmentString(_alignGE);
        }

        public static string GetAlignmentString(AlignmentValue align)
        {
            switch (align)
            {
                case AlignmentValue.ALIGN_CHAOS: return "Chaotic";
                case AlignmentValue.ALIGN_EVIL: return "Evil";
                case AlignmentValue.ALIGN_GOOD: return "Good";
                case AlignmentValue.ALIGN_LAW: return "Lawful";
                case AlignmentValue.ALIGN_NEUTRAL: return "Neutral";
                default: return "Any";
            }
        }

        public static string ChoseGender()
        {
            var table = new RandomTable<string>();
            table.AddItem("Male", 10);
            table.AddItem("Female", 10);
            table.AddItem("Nonbinary", 1);
            return table.GetResult();
        }

        public static bool IsAlignmentVariable(AlignmentValue align)
        {
            return (
                align == AlignmentValue.ALIGN_UNALIGNED
                || align == AlignmentValue.ALIGN_UNKNOWN
                || align == AlignmentValue.ALIGN_VARIES
                );
        }

        public static bool IsAlignmentGEBad(AlignmentValue align)
        { 
            return (
                align == AlignmentValue.ALIGN_LAW || 
                align == AlignmentValue.ALIGN_CHAOS
                );
        }

        public static bool IsAlignmentLCBad(AlignmentValue align)
        {
            return (
                align == AlignmentValue.ALIGN_GOOD || 
                align == AlignmentValue.ALIGN_EVIL
                );
        }

        private void _initAlignment()
        {
            var tableLC = new RandomTable<AlignmentValue>();
            tableLC.AddItem(AlignmentValue.ALIGN_CHAOS);
            tableLC.AddItem(AlignmentValue.ALIGN_LAW);
            tableLC.AddItem(AlignmentValue.ALIGN_NEUTRAL);

            var classAlignLC = Ancestry.AlignmentLC;
            if (!IsAlignmentVariable(classAlignLC) && 
                !IsAlignmentLCBad(classAlignLC))
            {
                tableLC.AddItem(classAlignLC, 3);
            }

            bool hasComposite = !(Ancestry.Composite is null);
            if (hasComposite)
            {
                var raceAlignLC = Ancestry.Composite.AlignmentLC;
                if (!IsAlignmentVariable(raceAlignLC) &&
                    !IsAlignmentLCBad(raceAlignLC) )
                {
                    tableLC.AddItem(raceAlignLC, 3);
                }
            }

            var tableGE = new RandomTable<AlignmentValue>();
            tableGE.AddItem(AlignmentValue.ALIGN_EVIL);
            tableGE.AddItem(AlignmentValue.ALIGN_GOOD);
            tableGE.AddItem(AlignmentValue.ALIGN_NEUTRAL);

            var classAlignGE = Ancestry.AlignmentGE;
            if (!IsAlignmentVariable(classAlignGE) && 
                !IsAlignmentGEBad(classAlignGE)
                )
            {
                tableGE.AddItem(classAlignGE, 3);
            }

            if (hasComposite)
            {
                var raceAlignGE = Ancestry.Composite.AlignmentGE;
                if (!IsAlignmentVariable(raceAlignGE) &&
                    !IsAlignmentLCBad(raceAlignGE) )
                {
                    tableGE.AddItem(raceAlignGE, 3);
                }
            }
            _alignLC = tableLC.GetResult();
            _alignGE = tableGE.GetResult();
        }
    }
}
