﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class CrawlRoomGate
    {
        public string GateForm;
        public string GateActivation;
        public string GateVisualEffect;
        public string GateAllowance;
        public string GateFrequency;
        public string GateDirection;
        public string GateSideEffect;

        public string GateDestination;

        public void Init()
        {
            GateForm = ChooseGateForm();
            GateActivation = ChooseGateActivation();
            GateVisualEffect = ChooseGateVisualEffect();
            GateAllowance = ChooseGateAllowance();
            GateFrequency = ChooseGateFrequency();
            GateDirection = ChooseGateDirection();
            GateDestination = ChooseGateDestination();

            var dice = Dice.Instance;
            bool isRuned = dice.Roll(1, 10) == 1;
            if (isRuned) GateSideEffect = "Elder rune: " + ChooseElderRune();
        }

        public override string ToString()
        {
            return
                GateDirection + " gate, "
                + GateForm + "; Openend by "
                + GateActivation + " to reveal "
                + GateVisualEffect + ". It transports "
                + GateAllowance + " " 
                + GateFrequency 
                + (GateSideEffect == "" ? "" : ". Effect on first user: " 
                + GateSideEffect)
                ;
        }

        public static string ChooseGateForm()
        {
            var table = new RandomTable<string>();
            table.AddItem("A large, round gate on a dias");
            table.AddItem("An empty archway");
            table.AddItem("Two paralell, upright standing stones");
            table.AddItem("A portal between two statues");
            table.AddItem("Two floor mounted bars of strange metal");
            table.AddItem("A black obelisk");
            table.AddItem("An empty stone dias");
            table.AddItem("A pool of calm water");
            table.AddItem("A magic circle etched on the floor");
            table.AddItem("A large, oval mirror");
            return table.GetResult();
        }

        public static string ChooseGateActivation()
        {
            var table = new RandomTable<string>();
            table.AddItem("Stepping through");
            table.AddItem("Speaking command deciphered from runes around " +
                "gate" );
            table.AddItem("Approaching gate");
            table.AddItem("Pulling a lever");
            table.AddItem("Operating a strange console");
            table.AddItem("1 workweek of downtime research in books found in" +
                "the room");
            table.AddItem("Always open");
            table.AddItem("Being the master of the dungeon");
            table.AddItem("Carrying a special badge");
            table.AddItem("Lighting the 2 brazers on either side");
            // secret door trigger
            return table.GetResult();
        }

        public static string ChooseGateVisualEffect()
        {
            var table = new RandomTable<string>();
            table.AddItem("Swirling colors");
            table.AddItem("Shimmering curtain");
            table.AddItem("Flashing runes");
            table.AddItem("No visible effects");
            table.AddItem("Bright flash of light");
            table.AddItem("Woever uses it dissapears in a puff of smoke");
            table.AddItem("Mist fills gate and pours out onto the floor");
            table.AddItem("Mist trickles out of the gate, clinging to the " +
                "floor");
            table.AddItem("A dull glow fills the space");
            table.AddItem("Gate frame glows");
            table.AddItem("An impenitrable black void fills the space");
            table.AddItem("A whide column of light shoots down over the gate");
            return table.GetResult();
        }

        public static string ChooseGateAllowance()
        {
            var table = new RandomTable<string>();
            table.AddItem("One being");
            table.AddItem("Two beings");
            table.AddItem("Any number of beings", 8);
            return table.GetResult();
        }

        public static string ChooseGateFrequency()
        {
            var table = new RandomTable<string>();
            table.AddItem("Each trigger", 4);
            table.AddItem("Each minute");
            table.AddItem("Each hour");
            table.AddItem("Every 24 hours");
            return table.GetResult();
        }

        public static string ChooseGateDirection()
        {
            var table = new RandomTable<string>();
            table.AddItem("Two-way", 8);
            table.AddItem("One-way, from here", 2);
            table.AddItem("One-way, to here");
            return table.GetResult();
        }

        public static string ChooseElderRune()
        {
            var table = new RandomTable<string>();
            table.AddItem("The target must succeed on a Constitution " +
                "saving throw or it can't regain hit points until a remove " +
                "curse or greater restoration spell is cast on it.");
            table.AddItem("The target is immune to the blinded, " +
                "charmed, deafened, frightened, paralyzed, petrified, " +
                "poisoned, and stunned conditions.In addition, the " +
                "target stabilizes immediate ly when it drops to 0 hit " +
                "points. This boon effect lasts for 24 hours.");
            table.AddItem("The target must succeed on a Constitution " +
                "saving throw or it gains vulnerability to all damage " +
                "and a -2 penalty to death saving throws for 24 hours.");
            table.AddItem("When the target hits with an attack, the " +
                "target can turn that hit into a critical hit, after " +
                "which this boon effect ends.");
            table.AddItem("The target must make a 1 Constitution saving " +
                "throw, taking 20d6 force damage on a failed save, " +
                "or half as much damage on a successful one.");
            table.AddItem("The target recovers its expended spell slots " +
                "of 6th level and lower. If the target has no spell " +
                "slots to recover, a magical shield surrounds the target " +
                "for l hour instead. This shield grants the target " +
                "resistance to al l damage and can't be dispelled, " +
                "though contact with an antimagic field destroys it.");
            table.AddItem("The target must succeed on a Wisdom saving " +
                "throw or suffer the effect of a confusion spe ll with a " +
                "duration of l minute.");
            table.AddItem("Whe n the target rolls damage, it can reroll " +
                "any of the damage dice once.It must use the new rolls, " +
                "after which this boon effect ends.");
            table.AddItem("The target must ma ke a Dexterity saving " +
                "throw, taking lOdlO fire damage on a failed save, or " +
                "half as much , damage on a successful save.");
            table.AddItem("The target gains a pool of ten d6s. Up to two " +
                "of these dice can be expended at a time and added to " +
                "any damage roll the target makes when it hits wiht a " +
                "weapon attack. The damage added by these dice is fire " +
                "damage.");
            table.AddItem("For the next 24 hours, the target can't gain " +
                "advantage on attack rolls, ability checks, or saving " +
                "throws.");
            table.AddItem("Once within the next 24 hours, the target can " +
                "use its reaction to reduce the damae it takes from one " +
                "source by 10d6.");
            table.AddItem("T he target must succeed on a Wisdom saving " +
                "throw or be incapaci - tated for l hour. While " +
                "incapacitated in this way, the target gains the " +
                "following personality flaw, which supersedes any " +
                "opposing flaw: 'I fundamentally disagree with everything " +
                "anyone else says.'");
            table.AddItem(" The target can cast the augury spell as an " +
                "action three times, requiring no components and with " +
                "no chance of a random reading.");
            table.AddItem(" All nonmagical co ins and gems on the target's " +
                "person vanish.");
            table.AddItem(" The rune magically sum- mons a goblin(use " +
                "the goblin stat block 1 in the Monster Manual), which " +
                "appears in an unoccupied space within 20 fee t of the " +
                "target. The goblin is rude to everyone except the target " +
                "and obeys the target's commands.The goblin vanishes in a " +
                "puff of smoke if it drops to 0 hit points.");
            table.AddItem("The target must succeed on a Wisdom saving " +
                "throw or be re strained fo r 24 hours.");
            table.AddItem("For the next 24 hours, the target gains the " +
                "following benefits: • The effects of the freedom of " +
                "movement spell • The ability to cast the knock spell " +
                "at will, requiring no components");
            return table.GetResult();
        }

        public static string ChooseGateDestination()
        {
            var table = new RandomTable<string>();
            table.AddItem("Unvisited location in this dungeon", 8);
            table.AddItem("Location in this dungeon that has already " +
                "been visited", 4);
            table.AddItem("Location in another dungeon");
            table.AddItem("Another plane of existence: " 
                + ChooseAnotherDimension());
            table.AddItem("A wizard's gate room elsewhere in the world");
            table.AddItem("An underdark monster lair");
            table.AddItem("Somewhere in the wilderness");
            return table.GetResult();
        }

        public static string ChooseAnotherDimension()
        {
            var table = new RandomTable<string>();
            table.AddItem(ChooseInnerPlanes());
            table.AddItem(ChooseOuterPlanes());
            table.AddItem(ChooseTransientPlanes());
            table.AddItem(ChooseSetting());
            // TODO: add procedural prime worlds from 1e Manual o/t Planes
            return table.GetResult();
        }

        public static string ChooseInnerPlanes()
        {
            var table = new RandomTable<string>();
            table.AddItem("Earth");
            table.AddItem("Air");
            table.AddItem("Water");
            table.AddItem("Fire");
            table.AddItem("Positive");
            table.AddItem("Negative");
            table.AddItem("Magma");
            table.AddItem("Ooze");
            table.AddItem("Ice");
            table.AddItem("Smoke");
            table.AddItem("Minerals");
            table.AddItem("Steam");
            table.AddItem("Lightning");
            table.AddItem("Radiance");
            table.AddItem("Salt");
            table.AddItem("Dust");
            table.AddItem("Ash");
            table.AddItem("Vaccuum");
            table.AddItem("Shadowfell");
            table.AddItem("Feywild");
            table.AddItem("Draconia (dragonlands)");
            return table.GetResult();
        }

        public static string ChooseOuterPlanes()
        {
            var table = new RandomTable<string>();
            table.AddItem("Elysium");
            table.AddItem("Beastlands");
            table.AddItem("Olympus");
            table.AddItem("Ysgard");
            table.AddItem("Limbo");
            table.AddItem("Pandemoneum");
            table.AddItem("Abyss");
            table.AddItem("Tarterus");
            table.AddItem("Hades");
            table.AddItem("Gehena");
            table.AddItem("Hell");
            table.AddItem("Acheron");
            table.AddItem("Mechanus");
            table.AddItem("Arcadia");
            table.AddItem("Seven Heavens");
            table.AddItem("Twin Paradises");
            table.AddItem("Concordant Opposition");
            return table.GetResult();
        }

        public static string ChooseTransientPlanes()
        {
            var table = new RandomTable<string>();
            table.AddItem("Etherial");
            table.AddItem("Border etherial");
            table.AddItem("Astral");
            return table.GetResult();

        }

        public static string ChooseSetting()
        {
            var table = new RandomTable<string>();
            table.AddItem("Faerun");
            table.AddItem("Athas");
            // table.AddItem("Greyhawk"); I don't know anything about this place
            table.AddItem("Krynn");
            table.AddItem("Sigil");
            table.AddItem("Ravenloft");
            table.AddItem("Kara-tur");
            table.AddItem("Wilderlands");
            table.AddItem("Underdark");
            table.AddItem("Zakhara (Al Qadim)");

            // my own worlds
            table.AddItem("The Ring");
            table.AddItem("Sverdheim");
            table.AddItem("Corinthia");
            table.AddItem("Anaxarete");
            table.AddItem("The Primordial Wilderness");
            return table.GetResult();
        }








    }
}
