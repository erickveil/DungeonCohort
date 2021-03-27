using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;
using DungeonCohort.JsonLoading;

namespace DungeonCohort
{
    class EldMagicItemGen
    {

        public static string genItem()
        {
            // low level

            string name = itemIdentity();
            string lesserPower = minorBenficialProperty();
            string lesserCurse = minorDetrimentalProperty();

            string description = name + ":" + "\n" +
                "Lesser ability: " + lesserPower + "\n" +
                "Lesser curse: " + lesserCurse;

            return description;
        }

        static string physicalForm()
        {
            var table = new RandomTable<string>();

            table.AddItem("Greatsword");
            table.AddItem("Longsword");
            table.AddItem("Shortsword");
            table.AddItem("Dagger");
            table.AddItem("Ring");
            table.AddItem("Crown");
            table.AddItem("Necklace");
            table.AddItem("Codex");
            table.AddItem("Tome");
            table.AddItem("Throne");
            table.AddItem("Chainmail");
            table.AddItem("Helm");
            table.AddItem("Shield");
            table.AddItem("Gauntlets");
            table.AddItem("Boots");
            table.AddItem("Cloak");
            table.AddItem("Belt");
            table.AddItem("Mask");
            table.AddItem("Font");
            table.AddItem("Fountain");
            table.AddItem("Statue");
            table.AddItem("Statuette");
            table.AddItem("Staff");
            table.AddItem("Rod");
            table.AddItem("Wand");
            table.AddItem("Orb");
            table.AddItem("Coin");
            table.AddItem("Scroll");
            table.AddItem("Tablet");
            table.AddItem("Obelisk");
            table.AddItem("Skull");
            table.AddItem("Gemstone");
            table.AddItem("Ink");
            table.AddItem("Pen");
            table.AddItem("Bone");
            table.AddItem("Dice");
            table.AddItem("Gong");
            table.AddItem("Flute");
            table.AddItem("Pan Pipes");
            table.AddItem("Smoking Pipe");
            table.AddItem("Urn");
            table.AddItem("Mirror");
            table.AddItem("Organ");
            table.AddItem("Jar");
            table.AddItem("Carpet");
            table.AddItem("Lamp");
            table.AddItem("Lantern");
            table.AddItem("Puzzlebox");
            table.AddItem("Cube");
            table.AddItem("Disk");
            table.AddItem("Hat");
            table.AddItem("Scepter");
            table.AddItem("Longbow");
            table.AddItem("Shortbow");
            table.AddItem("Spear");
            table.AddItem("Axe");
            table.AddItem("Chain Shirt");
            table.AddItem("Bracers");
            table.AddItem("Breastplate");
            table.AddItem("Cup");


            return table.GetResult();
        }

        static string minorBenficialProperty()
        {
            var table = new RandomTable<string>();

            var dataSource = DataSourceLoader.Instance;
            var spellSource = dataSource.SpellSource;
            var spellTable = spellSource.GetFullSpellTable();
            var cantripTable = JsonSpellLoader.FilterTableByLevel(spellTable, 0);
            var firstLevelTable = JsonSpellLoader.FilterTableByLevel(spellTable, 1);
            var secondLevelTable = JsonSpellLoader.FilterTableByLevel(spellTable, 2);
            var thirdLevelTable = JsonSpellLoader.FilterTableByLevel(spellTable, 3);
            string cantripSpell = cantripTable.GetResult().name;
            string firstLevelSpell = firstLevelTable.GetResult().name;
            string secondLevelSpell = secondLevelTable.GetResult().name;
            string thirdLevelSpell = thirdLevelTable.GetResult().name;

            var conditionTable = new RandomTable<string>();
            conditionTable.AddItem("charmed");
            conditionTable.AddItem("frightened");
            string condition = conditionTable.GetResult();

            table.AddItem("Proficiency in " + skill());
            table.AddItem("Immune to disease");
            table.AddItem("Can't be " + condition);
            table.AddItem("Resistance to " + damageType() + " damage");
            table.AddItem(cantripSpell + " 1/day");
            table.AddItem(firstLevelSpell + " 1/day");
            table.AddItem(secondLevelSpell + " 1/day");
            table.AddItem(thirdLevelSpell + " 1/day");
            table.AddItem("+1 AC");
            table.AddItem("+1 to hit and damage");
            table.AddItem("+1 to hit and damage, +2 vs " + monsterType());
            table.AddItem("+1 to hit and damage, +2 vs " + alignment());
            table.AddItem("+1 AC, +2 vs " + monsterType());
            table.AddItem("+1 AC, +2 vs " + alignment());

            return table.GetResult();
        }

        static string skill()
        {
            var table = new RandomTable<string>();

            table.AddItem("Athletics");
            table.AddItem("Acrobatics");
            table.AddItem("Sleight of Hand");
            table.AddItem("Stealth");
            table.AddItem("Arcana");
            table.AddItem("History");
            table.AddItem("Investigation");
            table.AddItem("Nature");
            table.AddItem("Religion");
            table.AddItem("Animal Handling");
            table.AddItem("Insight");
            table.AddItem("Medicine");
            table.AddItem("Perception");
            table.AddItem("Survival");
            table.AddItem("Deception");
            table.AddItem("Intimidation");
            table.AddItem("Performance");
            table.AddItem("Persuasion");

            return table.GetResult();
        }

        static string damageType()
        {
            var table = new RandomTable<string>();

            table.AddItem("Poison");
            table.AddItem("Acid");
            table.AddItem("Fire");
            table.AddItem("Cold");
            table.AddItem("Radiant");
            table.AddItem("Necrotic");
            table.AddItem("Lightning");
            table.AddItem("Thunder");
            table.AddItem("Force");
            table.AddItem("Psychic");
            table.AddItem("Slashing");
            table.AddItem("Piercing");
            table.AddItem("Bludgeoning");
            table.AddItem("Nonmagical");

            return table.GetResult();

        }

        static string monsterType()
        {
            var table = new RandomTable<string>();

            table.AddItem("Aberration");
            table.AddItem("Beast");
            table.AddItem("Celestial");
            table.AddItem("Construct");
            table.AddItem("Dragon");
            table.AddItem("Elemental");
            table.AddItem("Fey");
            table.AddItem("Fiend");
            table.AddItem("Giant");
            table.AddItem("Humanoid");
            table.AddItem("Monstrosity");
            table.AddItem("Ooze");
            table.AddItem("Plant");
            table.AddItem("Undead");

            return table.GetResult();

        }

        static string majorBeneficialProperty()
        {
            var table = new RandomTable<string>();

            var dataSource = DataSourceLoader.Instance;
            var spellSource = dataSource.SpellSource;
            var spellTable = spellSource.GetFullSpellTable();
            var fourthLevelTable = JsonSpellLoader.FilterTableByLevel(spellTable, 4);
            var fifthLevelTable = JsonSpellLoader.FilterTableByLevel(spellTable, 5);
            var sixthLevelTable = JsonSpellLoader.FilterTableByLevel(spellTable, 6);
            var seventhLevelTable = JsonSpellLoader.FilterTableByLevel(spellTable, 7);
            string fourthLevelSpell= fourthLevelTable.GetResult().name;
            string fifthLevelSpell = fifthLevelTable.GetResult().name;
            string sixthLevelSpell = sixthLevelTable.GetResult().name;
            string seventhLevelSpell = seventhLevelTable.GetResult().name;

            var conditionTable = new RandomTable<string>();
            conditionTable.AddItem("blinded");
            conditionTable.AddItem("deafened");
            conditionTable.AddItem("petrified");
            conditionTable.AddItem("stunned");
            string condition = conditionTable.GetResult();

            table.AddItem("+2 " + abilityScore() + ", max 24");
            table.AddItem("Regenerate 1d6 hp at start of turn if have at least 1 hp");
            table.AddItem("Extra 1d6 damage on weapon attacks");
            table.AddItem("Walking speed increased by 10 feet");
            table.AddItem(fourthLevelSpell + " 1/day");
            table.AddItem(fifthLevelSpell + " 1/day");
            table.AddItem(sixthLevelSpell + " 1/day");
            table.AddItem(seventhLevelSpell + " 1/day");
            table.AddItem("Can't be " + condition);
            table.AddItem("+2 AC");
            table.AddItem("+2 to hit and damage");

            return table.GetResult();
        }

        static string alignment()
        {
            var table = new RandomTable<string>();

            table.AddItem("Lawful Good");
            table.AddItem("Lawful");
            table.AddItem("Lawful Evil");
            table.AddItem("Good");
            table.AddItem("Evil");
            table.AddItem("Chaotic Good");
            table.AddItem("Chaotic");
            table.AddItem("Chaotic Evil");

            return table.GetResult();
        }

        static string abilityScore()
        {
            var table = new RandomTable<string>();

            table.AddItem("Strength");
            table.AddItem("Dexterity");
            table.AddItem("Constitution");
            table.AddItem("Intelligence");
            table.AddItem("Wisdom");
            table.AddItem("Charisma");

            return table.GetResult();
        }

        static string minorDetrimentalProperty()
        {
            var table = new RandomTable<string>();

            table.AddItem("Disadvantage on saving throws vs spells");
            table.AddItem("The value of gems you touch are reduced by half");
            table.AddItem("Blinded when more than 10 feet away from this item");
            table.AddItem("Disadvantage on saves against poison");
            table.AddItem("Strong stench noticiable up to 10 feet away");
            table.AddItem("All holy water within 10 feet is destoyed");
            table.AddItem("Physically ill and have disadvantage on Strength and Constitution ability checks or saves");
            table.AddItem("Weight increases by 1d4x10 lbs");
            table.AddItem("Appearance changes (up to DM)");
            table.AddItem("Deafened when more than 10 feet from this item");
            table.AddItem("Weight drops by 1d4x5 lbs");
            table.AddItem("Can't smell");
            table.AddItem("Nonmagical flames are extinguished within 30 feet");
            table.AddItem("Other creatures cannot take a short or long rest within 300 feet of you");
            table.AddItem("Deal 1d6 necrotic damage to any plant you touch that isn't a creature");
            table.AddItem("Animals within 30 feet of you are hostile towards you");
            table.AddItem("Must eat and drink 6 times the normal ammount each day");
            table.AddItem("Once attuned, the owner never wants to part with the " +
                "object and guards it jealously and with paranoia");

            return table.GetResult();

        }

        static string majorDetrimentalProperty()
        {
            var table = new RandomTable<string>();

            table.AddItem("You rot over the course of 4 days until you look undead");
            table.AddItem("Alignment is randomly determined each day");
            table.AddItem("You are affected by a geas as soon as you attune to this item");
            table.AddItem("Artifact contains a life force that is hostile " +
                "to you. Each time you use one of the abilites, 50% chance " +
                "the life force tries to leave the artifact and enter your " +
                "body. DC 20 Charisma saving throw or become an NPC under " +
                "the DM's control until it is banished using dispel evil " +
                "and good spell.");
            table.AddItem("Creatures with CR 0 as well as plants that aren't" +
                " creatures drop to 0 hp within 10 feet of the artifact.");
            table.AddItem("Artifact imprisons a death slaad. Each time you " +
                "use one of the artifact's properties, 10% the slaad appears " +
                "within 15 feet of you and attacks.");
            table.AddItem(monsterType() + " are always hostile towards you");
            table.AddItem("Artifact dilutes magic potions within 10 feet, " +
                "rendering them nonmagical");
            table.AddItem("Erases magic scrolls within 10 feet, rendering " +
                "them nonmagical.");
            table.AddItem("Before using an ability from the artifact, must " +
                "first use a bonus action to draw blood from yourself, a " +
                "willing creature in reach, or an incapacitated creature, " +
                "using a piercing or slashing melee weapon. Subject takes " +
                "1d4 damage.");
            table.AddItem("Gain a form of long term madness");
            table.AddItem("Take 4d10 psychic damage when attuned");
            table.AddItem("Take 8d10 psychic damage when attuned");
            table.AddItem("Before you attune, you must kill a creature of " +
                "your alignment");
            table.AddItem(abilityScore() + " is reduced by 2");
            table.AddItem("Age 3d10 years. Succeed DC 10 Con save or die " +
                "from the shock. If you die, you are instantly transformed " +
                "into a wight under the DM's control that is swork to " +
                "protect the artifact.");
            table.AddItem("Lose the ability to speak");
            table.AddItem("Vulnerability to all damage");
            table.AddItem("All who lay eyes on the artifact must succeed a " +
                "DC 10 Int save or irrationally covet the artifact. Will " +
                "plot to obtain it by any means necessary, destroying any " +
                "prior relationships with the current owner in the process.");

            return table.GetResult();

        }

        static string itemEgo()
        {
            var table = new RandomTable<string>();

            table.AddItem("8");
            table.AddItem("9");
            table.AddItem("10");
            table.AddItem("11");
            table.AddItem("12");
            table.AddItem("13");
            table.AddItem("14");
            table.AddItem("15");
            table.AddItem("16");
            table.AddItem("17");
            table.AddItem("18");
            table.AddItem("19");
            table.AddItem("20");
            table.AddItem("21");
            table.AddItem("22");
            table.AddItem("23");

            return table.GetResult();
        }

        /*
        // https://5e.tools/items.html#moonblade_dmg
        static string sentience()
        {

        }

        static string intelligentItemCommunication()
        {

        }
        */

        /*
        // random syllables
        static string itemPropperName()
        {

        }
        */

        static string symbology()
        {
            var table = new RandomTable<string>();

            table.AddItem("ankh");
            table.AddItem("star");
            table.AddItem("cup");
            table.AddItem("rune");
            table.AddItem("glyph");
            table.AddItem("moon");
            table.AddItem("sun");
            table.AddItem("tree");
            table.AddItem("leaf");
            table.AddItem("mountain");
            table.AddItem("dragon");

            return table.GetResult();
        }

        // locations, cultures, npcs, and flavor descriptors to go with
        static string itemOrigin()
        {
            var table = new RandomTable<string>();

            string celestial = "Celestial: mirror polished gold and silver " +
                "metal. Bright light 20 feet, Dim light 20 feet.";
            string demon = "Demon: Black and seething. Stinks of rot.";
            string earth = "Earth: Hardened stone. Matte and earthy tones.";
            string air = "Air: Lightweight, translucent blue. A gentle breeze " +
                "when wielded";
            string storm = "Storm/Lightning: Low hum, static shock when touched.";
            string gem = "Gem: Polished, cut crystal. Carries a note when struck.";
            string negative = "Negative Energy: Black without contour - absorbs light. " +
                "Nearby flowers wilt and turn to ash.";
            string ice = "Ice: Cold and clear, covered in frost. You can see your" +
                " breath.";
            string fire = "Fire: Hot to the touch. Flames lick its surface.";
            string giant = "Giant: Oversized and twice as heavy.";
            string illithid = "Illithid: Organic, writhing. A mental fog overcomes you.";
            string githyanki = "Githyanki: Silver, with strnagely glowing components.";
            string githzerai = "Githzerai: Difficult to focus on. Material " +
                "changes type and shape over time.";
            string kingdom = "Old Kingdoms: Well crafted, etched with runes " +
                "of a forgotten language.";
            string holy = "Holy relic: Emplazoned with a " + symbology();
            string necro = "Necromancer: Adorned with skulls, crafted of " +
                "bone.";

            table.AddItem("Eldrazel - " + celestial);
            table.AddItem("Reveria - " + celestial);
            table.AddItem("Volak - " + demon);
            table.AddItem("Malstromport - " + demon);
            table.AddItem("Jord - " + earth);
            table.AddItem("Jordheim - " + earth);
            table.AddItem("Luftkonge - " + air);
            table.AddItem("Luftriket - " + air);
            table.AddItem("Tordenvaer - " + storm);
            table.AddItem("Edelsten - " + gem);
            table.AddItem("Perle Rike - " + gem);
            table.AddItem("Nod - " + negative);
            table.AddItem("Ingen Steder - " + negative);
            table.AddItem("Is - " + ice);
            table.AddItem("Breen - " + ice);
            table.AddItem("Brannherre - " + fire);
            table.AddItem("Brennede Holde - " + fire);
            table.AddItem("Hovedstad - " + giant);
            table.AddItem("Kraton - " + illithid);
            table.AddItem("Pos Gropyokan - " + githyanki);
            table.AddItem("Stesen Satu - " + githyanki);
            table.AddItem("Stesen Dua - " + githyanki);
            table.AddItem("Stesen Tiga - " + githyanki);
            table.AddItem("Kedamaian - " + githzerai);
            table.AddItem("Keharmonian - " + githzerai);
            table.AddItem("Ketenangan - " + githzerai);
            table.AddItem("Hugel Nach Hause - " + kingdom);
            table.AddItem("Konigsschloss - " + kingdom);
            table.AddItem("Starkes Fort - " + kingdom);
            table.AddItem("Sicher Ort - " + kingdom);
            table.AddItem("Behalten - " + kingdom);
            table.AddItem("Festung - " + kingdom);
            table.AddItem("Weizendorf - " + kingdom);
            table.AddItem("Viehdorf - " + kingdom);
            table.AddItem("Ranchstadt - " + kingdom);
            table.AddItem("Kleiderdorf - " + kingdom);
            table.AddItem("Stadtschmieden - " + kingdom);
            table.AddItem("Kleinerweiler - " + kingdom);
            table.AddItem("Versteckterherd - " + kingdom);
            table.AddItem("Familienbestitz - " + kingdom);
            table.AddItem("Handelsposten - " + kingdom);
            table.AddItem("Hinterwalder - " + kingdom);
            table.AddItem("Fischerdorf - " + kingdom);
            table.AddItem("Schwertstadt - " + kingdom);
            table.AddItem("Bergbaustadt - " + kingdom);
            table.AddItem("Schlafrighohl - " + kingdom);
            table.AddItem("Viehkreuzung - " + kingdom);
            table.AddItem("Hirtengasse - " + kingdom);
            table.AddItem("Ruhigerbach - " + kingdom);
            table.AddItem("Fasanenspitze - " + kingdom);
            table.AddItem("Heiligerort - " + holy);
            table.AddItem("Gotterhause - " + holy);
            table.AddItem("Heiligesherz - " + holy);
            table.AddItem("Todesturm - " + necro);

            return table.GetResult();
        }

        // Combine elements for a proper name
        // Wudunder - Crown - Celestial (Mirror polished gold and silver, wings, eyes)
        // The Crown of Aeldian - Lightning (Static shock when touched, makes hair stand on end, Lightning damage)
        static string itemIdentity()
        {
            return physicalForm() + " of " + itemOrigin();
        }
    }
}
