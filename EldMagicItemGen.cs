using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;
using DungeonCohort.JsonLoading;
using RandomWords;

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

            string description = 
                "Lesser ability: " + lesserPower + "\n" +
                "Lesser curse: " + lesserCurse;

            string major =
                "\nMajor ability: " + majorBeneficialProperty() + "\n" +
                "Major curse: " + majorDetrimentalProperty();
            var die = Dice.Instance;
            bool isMajor = die.Roll(1, 6) == 6;
            if (isMajor) { description += major; }

            bool isIntelligent = die.Roll(1, 6) == 6;
            string ego = itemEgo();
            string temperament = intelligentItemTemprament();
            string communication = intelligentItemCommunication();
            string purpose = specialPurpose();

            if (isIntelligent)
            {
                description += "\n" +
                    "Intelligent\n" +
                    "Ego: +" + ego + "\n" +
                    "Temperament: " + temperament + "\n" +
                    "Communication: " + communication + "\n" +
                    "Special Purpose: " + purpose + "\n";
                name = namedItemIdentity();
            }

            description = name + ":" + "\n" + description;

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
            table.AddItem("Battleaxe");
            table.AddItem("Greataxe");
            table.AddItem("Glaive");
            table.AddItem("Pike");
            table.AddItem("Halberd");
            table.AddItem("Warhammer");
            table.AddItem("Key");
            table.AddItem("Crystal");

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
            table.AddItem("Beacon. The bearer can use a bonus action to cause the item to shed bright light in a 10-foot radius and dim light for an additional 10 feet, or to extinguish the light.");
            table.AddItem("Compass. The wielder can use an action to learn which way is north.");
            table.AddItem("Conscientious. When the bearer of this item contemplates or undertakes a malevolent act, the item enhances pangs of conscience.");
            table.AddItem("Delver. While underground, the bearer of this item always knows the item's depth below the surface and the direction to the nearest staircase, ramp, or other path leading upward.");
            table.AddItem("Gleaming. This item never gets dirty.");
            table.AddItem("Guardian. The item whispers warnings to its bearer, granting a +2 bonus to initiative if the bearer isn't incapacitated.");
            table.AddItem("Hidden Message. A message is hidden somewhere on the item. It might be visible only at a certain time of the year, under the light of one phase of the moon, or in a specific location.");
            table.AddItem("Key. The item is used to unlock a container, chamber, vault, or other entryway.");
            table.AddItem("Language. The bearer can speak and understand a language of the DM's choice while the item is on the bearer 's person.");
            table.AddItem("Sentinel. Choose a kind of creature that is an enemy of the item's creator. This item glows faintly when such creatures are within 120 feet of it.");
            table.AddItem("Temperate. The bearer suffers no harm in temperatures as cold as -20 degrees Fahrenheit or as warm as 120 degrees Fahrenheit.");
            table.AddItem("War Leader. The bearer can use an action to cause his or her voice to carry clearly for up to 300 feet until the end of the bearer's next turn.");
            table.AddItem("Waterborne. This item floats on water and other liquids. Its bearer has advantage on Strength (Athletics) checks to swim.");

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
            table.AddItem("Physically ill and have disadvantage on Strength and Constitution ability checks, skill checks, or saves");
            table.AddItem("Weight increases by 5 lbs each time it is used");
            table.AddItem("Appearance changes (up to DM)");
            table.AddItem("Deafened when more than 10 feet from this item");
            table.AddItem("Weight drops by 5 lbs each time this is used");
            table.AddItem("Age 1 month with each use");
            table.AddItem("Become younger by 1 month with each use");
            table.AddItem("Nonmagical flames are extinguished within 30 feet");
            table.AddItem("Other creatures cannot take a short or long rest within 300 feet of you");
            table.AddItem("Deal 1d6 necrotic damage to any plant you touch that isn't a creature");
            table.AddItem("Animals within 30 feet of you are hostile towards you");
            table.AddItem("Must eat and drink 6 times the normal ammount each day");
            table.AddItem("Once attuned, the owner never wants to part with the " +
                "object and guards it jealously and with paranoia");
            table.AddItem("Wicked. When the bearer is presented with an opportunity to act in a selfish or malevolent way, the item heightens the bearer's urge to do so.");
            table.AddItem("Frail. The item crumbles, frays, chips, or cracks slightly when wielded, worn, or activated. This quirk has no effect on its properties, but if the item has seen much use, it looks decrepit.");
            table.AddItem("Hungry. This item's magical properties function only if fresh blood from a humanoid has been applied to it within the past 24 hours. It needs only a drop to activate.");
            table.AddItem("Loud. The item makes a loud noise-such as a clang, a shout, or a resonating gong-when used. ");
            table.AddItem("Painful. The bearer experiences a harmless flash of pain when using the item.");
            table.AddItem("Posessive. Doesn't allow the owner to posess any other magical items.");
            table.AddItem("Repulsive. The bearer feels a sense of distaste when in contact with the item, and continues to sense discomfort while bearing it.");
            table.AddItem("Slothful. The bearer of this item feels slothful and lethargic. While attuned to the item, the bearer requires 10 hours to finish a long rest.");

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

            table.AddItem("0");
            table.AddItem("1");
            table.AddItem("2");
            table.AddItem("3");
            table.AddItem("4");
            table.AddItem("5");
            table.AddItem("6");

            return table.GetResult();
        }

        static string intelligentItemCommunication()
        {
            var table = new RandomTable<string>();

            table.AddItem("Semi-empathy (throb, tingle, urges)");
            table.AddItem("Empathy");
            table.AddItem("Muttering, requires close attention that can only be understood sometimes.");
            table.AddItem("Speech");
            table.AddItem("Visions and dreams");
            table.AddItem("Telepathy");

            return table.GetResult();
        }

        static string intelligentItemTemprament()
        {
            var table = new RandomTable<string>();

            table.AddItem("Noble and just");
            table.AddItem("Kind and caring");
            table.AddItem("Crass but well-meaning");
            table.AddItem("Strict and unbending");
            table.AddItem("Indifferent");
            table.AddItem("Fickle and inconsistent");
            table.AddItem("Manipulative and deceitful");
            table.AddItem("Cruel and self-serving");
            table.AddItem("Angry and bloothirsty");

            return table.GetResult();
        }

        static string specialPurpose()
        {
            var table = new RandomTable<string>();

            table.AddItem("Defeat and slay a faction");
            table.AddItem("Slay all " + monsterType());
            table.AddItem("Overthrow a government");
            table.AddItem("Avenge a wrong");
            table.AddItem("Restore a lost faction");
            table.AddItem("Fulfill a prophesey");

            return table.GetResult();
        }

        static string itemPropperName()
        {
            var wordGen = new WordGen();
            var die = Dice.Instance;
            var rng = die.getRng();
            string word = wordGen.randWord(rng);

            return wordGen.capitalize(word);
        }

        public static string symbology()
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
            table.AddItem("bat");
            table.AddItem("skull");
            table.AddItem("pentacle");
            table.AddItem("heart");
            table.AddItem("diamond");
            table.AddItem("sword");
            table.AddItem("gryphon");
            table.AddItem("claw");
            table.AddItem("'X'");
            table.AddItem("circle");
            table.AddItem("eye");
            table.AddItem("hand");
            table.AddItem("wolf");
            table.AddItem("bird");
            table.AddItem("cat");

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
            var die = Dice.Instance;
            bool isNamed = die.Roll(1, 6) >= 4;
            string name = "";
            if (isNamed) { name = itemPropperName() + ", "; }
            return name + physicalForm() + " of " + itemOrigin();
        }

        static string namedItemIdentity()
        {
            var die = Dice.Instance;
            string name = itemPropperName() + ", "; 
            return name + physicalForm() + " of " + itemOrigin();

        }
    }
}
