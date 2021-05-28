using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    /**
     * Name
     * Ancestry
     * Culture
     * Henchman Type
     */
    class EldHenchmen
    {

        public static string Culture1;
        public static string Culture2;

        public static string GenerateAllHirelings()
        {
            var die = Dice.Instance;
            int qty = die.Roll(1, 6) + 1;
            string list = "";
            for (int i = 0; i < qty; ++i)
            {
                list += GenerateHireling();
                list += "\n\n";
            }
            return list;

        }

        public static string GenerateHireling()
        {
            string job = GetHireling();
            string sex = PhysicalSex();
            string ancestry = GetAncestry();
            string culture = GetCulture();
            string name = GetName(sex, culture);

            return job + "\n" + name + "\n" + sex + " " + culture + " " + ancestry;
        }

        public static string GetCulture()
        {
            var table = new RandomTable<string>();

            string Culture1 = GetSingleCulture();
            string Culture2 = GetSingleCulture();
            while (Culture1 == Culture2) { Culture2 = GetSingleCulture();  }

            table.AddItem(Culture1, 9);
            table.AddItem("Multicultural: " + Culture1 + "/" + Culture2);

            return table.GetResult();
        }

        public static string GetSingleCulture()
        {
            var table = new RandomTable<string>();

            table.AddItem("Vanir");
            table.AddItem("Thraxian");
            table.AddItem("Illuskan");
            table.AddItem("Waterdhavian");
            table.AddItem("Ironbound");

            return table.GetResult();
        }

        public static string GetAncestry()
        {
            var table = new RandomTable<string>();

            table.AddItem(GetSingleAncestry(), 9);
            string multi1 = GetSingleAncestry();
            string multi2 = GetSingleAncestry();
            while (multi1 == multi2) { multi2 = GetSingleAncestry(); }
            table.AddItem("Mixed ancestry: " + multi1 + "/" + multi2);

            return table.GetResult();
        }

        public static string GetSingleAncestry()
        {
            var table = new RandomTable<string>();

            table.AddItem("Human", 16);
            table.AddItem("Orc");
            table.AddItem("Elf");
            table.AddItem("Halfling");
            table.AddItem("Tiefling");
            table.AddItem("Dragonborn");
            table.AddItem("Tabaxi");
            table.AddItem("Aarococra");
            table.AddItem("Githzerai");
            table.AddItem("Dwarf");
            table.AddItem("Goblin");
            table.AddItem("Asir");
            table.AddItem("Kobold");

            return table.GetResult();
        }

        public static string GetHireling()
        {
            var table = new RandomTable<string>();
            table.NumTableDice = 2;

            table.AddItem("Scout", 2);
            table.AddItem("Valet");
            table.AddItem("Priest");
            table.AddItem("Unskilled", 2);
            table.AddItem("Guard", 2);
            table.AddItem("Wizard");
            table.AddItem("Herbalist");
            table.AddItem("Adventurer", 2);

            return table.GetResult();
        }

        public static string PhysicalSex()
        {
            var table = new RandomTable<string>();

            table.AddItem("Male");
            table.AddItem("Female");

            return table.GetResult();
        }

        public static string GetName(string sex, string culture)
        {
            bool isMulticultural = culture.Contains("Multicultural");
            if (isMulticultural) { 
                var splitCulture = culture.Split(' ');
                var multiPart = splitCulture[1];
                var dualCulture = multiPart.Split('/');
                return MixedName(dualCulture[0], dualCulture[1], sex); 
            }

            if (culture == "Thraxian") { return ThraxianName(); }
            if (culture == "Vanir") { return VanirName(sex); }
            if (culture == "Waterdhavian") { return WaterdhavianName(sex); }
            if (culture == "Ironbound") { return IronboundName(sex); }
            return IlluskanName(sex);
        }

        public static string MixedName(string culture1, string culture2, string sex)
        {
            string preName = ThraxianPrename();
            string firstName = "";
            string lastName = "";
            string nickName = ThraxianNickname();

            var firstNameTable = new RandomTable<string>();
            var lastNameTable = new RandomTable<string>();

            string testCulture = "Thraxian";
            if (culture1 == testCulture || culture2 == testCulture)
            {
                firstNameTable.AddItem(ThraxianFirstName());
            }

            testCulture = "Vanir";
            if (culture1 == testCulture || culture2 == testCulture)
            {
                if (sex == "Female") { firstName = VanirNameFemale(); }
                else { firstName = VanirNameMale(); }
                lastName = VanirSurname(sex);
                firstNameTable.AddItem(firstName);
                lastNameTable.AddItem(lastName);
            }

            testCulture = "Waterdhavian";
            if (culture1 == testCulture || culture2 == testCulture)
            {
                if (sex == "Female") { firstName = WaterdhavianNameFemale(); }
                else { firstName = WaterdhavianNameMale(); }
                lastName = WaterdhavianSurname();
                firstNameTable.AddItem(firstName);
                lastNameTable.AddItem(lastName);
            }

            testCulture = "Illuskan";
            if (culture1 == testCulture || culture2 == testCulture)
            {
                if (sex == "Female") { firstName = IlluskanFemaleName(); }
                else { firstName = IlluskanMaleName(); }
                lastName = IlluskanSurname();
                firstNameTable.AddItem(firstName);
                lastNameTable.AddItem(lastName);
            }

            testCulture = "Ironbound";
            if (culture1 == testCulture || culture2 == testCulture)
            {
                if (sex == "Female") { firstName = IronboundFemaleName(); }
                else { firstName = IronboundMaleName(); }
                lastName = IronboundSurname();
                firstNameTable.AddItem(firstName);
                lastNameTable.AddItem(lastName);
            }

            firstName = firstNameTable.GetResult();
            lastName = lastNameTable.GetResult();

            string fullName = "";
            var fullNameTable = new RandomTable<string>();

            if (culture1 == "Thraxian" || culture2 == "Thraxian")
            {
                fullNameTable.AddItem(ThraxianNamePattern(preName, firstName, nickName));
            }
            fullNameTable.AddItem(StandardNameGen(sex, firstName, firstName, lastName));

            fullName = fullNameTable.GetResult();
            return fullName;
        }

        public static string ThraxianName()
        {
            string pName = ThraxianPrename();
            string name = ThraxianFirstName();
            string nName = ThraxianNickname();

            return ThraxianNamePattern(pName, name, nName);
        }

        public static string WaterdhavianName(string sex)
        {
            string fName = WaterdhavianNameFemale();
            string mName = WaterdhavianNameMale();
            string sName = WaterdhavianSurname();
            return StandardNameGen(sex, mName, fName, sName);
        }

        public static string VanirName(string sex)
        {
            string mName = VanirNameMale();
            string fName = VanirNameFemale();
            string sName = VanirSurname(sex);
            return StandardNameGen(sex, mName, fName, sName);
        }

        public static string IlluskanName(string sex)
        {
            string mName = IlluskanMaleName();
            string fName = IlluskanFemaleName();
            string sName = IlluskanSurname();
            return StandardNameGen(sex, mName, fName, sName);
        }

        public static string IronboundName(string sex)
        {
            string mName = IronboundMaleName();
            string fName = IronboundFemaleName();
            string sName = IronboundSurname();
            return StandardNameGen(sex, mName, fName, sName);
        }

        public static string StandardNameGen(string sex, string mName, 
            string fName, string sName)
        {
            var die = Dice.Instance;
            bool hasSurname = die.Roll(1, 6) <= 2;

            sName = hasSurname ? " " + sName : "";

            if (sex == "Female") { return fName + sName; }
            return mName + sName;
        }

        public static string ThraxianNamePattern(string pName, string name, string nName)
        {
            var table = new RandomTable<string>();

            table.AddItem(pName + " " + name);
            table.AddItem(name);
            table.AddItem(name + " " + nName);
            table.AddItem(pName + " " + name + " " + nName);

            return table.GetResult();
        }


        public static string IronboundFemaleName()
        {
            var table = new RandomTable<string>();

            table.AddItem("Yoalin");
            table.AddItem("Bramora");
            table.AddItem("Andreline");
            table.AddItem("Drismilda");
            table.AddItem("Firhilda");
            table.AddItem("Yondildia");
            table.AddItem("Jazmere");
            table.AddItem("Glorian");
            table.AddItem("Weytrold");
            table.AddItem("Naerma");
            table.AddItem("Fortuna");
            table.AddItem("Sundra");

            return table.GetResult();
        }

        public static string IronboundMaleName()
        {
            var table = new RandomTable<string>();

            table.AddItem("Urist");
            table.AddItem("Dunan");
            table.AddItem("Bamur");
            table.AddItem("Dilur");
            table.AddItem("Ralvol");
            table.AddItem("Bogreed");
            table.AddItem("Thirfeg");
            table.AddItem("Lubok");
            table.AddItem("Nemdor");
            table.AddItem("Barnek");
            table.AddItem("Krojak");
            table.AddItem("Yanir");

            return table.GetResult();
        }

        public static string IronboundSurname()
        {
            var table = new RandomTable<string>();

            table.AddItem("Copperborn");
            table.AddItem("Axefall");
            table.AddItem("Goldbeard");
            table.AddItem("Silverwise");
            table.AddItem("Coingrip");
            table.AddItem("Alehorn");
            table.AddItem("Glimmerstone");
            table.AddItem("Brewmantle");
            table.AddItem("Fairhand");
            table.AddItem("Gildedheart");
            table.AddItem("Oreminder");
            table.AddItem("Brashblade");

            return table.GetResult();
        }

        public static string IlluskanMaleName()
        {
            var table = new RandomTable<string>();

            table.AddItem("Ander");
            table.AddItem("Blath");
            table.AddItem("Bran");
            table.AddItem("Frath");
            table.AddItem("Geth");
            table.AddItem("Lander");
            table.AddItem("Malcer");
            table.AddItem("Stor");
            table.AddItem("Taman");
            table.AddItem("Urth");
            table.AddItem("Dagult");
            table.AddItem("Renaer");

            return table.GetResult();
        }

        public static string IlluskanFemaleName()
        {
            var table = new RandomTable<string>();

            table.AddItem("Amafrey");
            table.AddItem("Betha");
            table.AddItem("Cefrey");
            table.AddItem("Kethra");
            table.AddItem("Mara");
            table.AddItem("Olga");
            table.AddItem("Silifrey");
            table.AddItem("Westra");
            table.AddItem("Ulna");
            table.AddItem("Danrys");
            table.AddItem("Sariah");
            table.AddItem("Bethly");

            return table.GetResult();
        }

        public static string IlluskanSurname()
        {
            var table = new RandomTable<string>();

            table.AddItem("Brightwood");
            table.AddItem("Helder");
            table.AddItem("Hornraven");
            table.AddItem("Lackman");
            table.AddItem("Stonar");
            table.AddItem("Stormwind");
            table.AddItem("Winddrivver");
            table.AddItem("Seacrest");
            table.AddItem("Fulstern");
            table.AddItem("Hawkin");
            table.AddItem("Steelshimmer");
            table.AddItem("Afterbrow");

            return table.GetResult();
        }

        public static string VanirNameFemale()
        {
            var table = new RandomTable<string>();

            table.AddItem("Aase");
            table.AddItem("Ethna");
            table.AddItem("Dyrdis");
            table.AddItem("Freylief");
            table.AddItem("Hallbera");
            table.AddItem("Hildisif");
            table.AddItem("Thora");
            table.AddItem("Helga");
            table.AddItem("Vigdis");
            table.AddItem("Yngvildr");
            table.AddItem("Sinn");
            table.AddItem("Ingunn");

            return table.GetResult();
        }

        public static string VanirNameMale()
        {
            var table = new RandomTable<string>();

            table.AddItem("Bjorn");
            table.AddItem("Einarr");
            table.AddItem("Styrbjorn");
            table.AddItem("Grimr");
            table.AddItem("Helgi");
            table.AddItem("Thorgeirr");
            table.AddItem("Arngrimr");
            table.AddItem("Orm");
            table.AddItem("Finnr");
            table.AddItem("Sigurthr");
            table.AddItem("Svartr");
            table.AddItem("Oddr");

            return table.GetResult();
        }

        public static string VanirSurname(string sex)
        {
            var table = new RandomTable<string>();

            table.AddItem("the Red");
            table.AddItem("the Bloody");
            table.AddItem("the Wise");
            table.AddItem("the Lucky");
            table.AddItem("the Bold");
            table.AddItem("the Tall");
            table.AddItem("the Trusty");
            table.AddItem("the Grim");
            string prenom = sex == "Female" ? "daughter" : "son";
            table.AddItem(prenom + " of " + VanirNameMale());
            table.AddItem(prenom + " of " + VanirNameFemale());
            if (sex == "Female")
            {
                table.AddItem(VanirNameMale() + "dottr");
                table.AddItem(VanirNameFemale() + "dottr");
            }
            else
            {
                table.AddItem(VanirNameMale() + "son");
                table.AddItem(VanirNameFemale() + "son");
            }

            return table.GetResult();

        }

        public static string WaterdhavianNameMale()
        {
            var table = new RandomTable<string>();

            table.AddItem("Aluar");
            table.AddItem("Coril");
            table.AddItem("Yuldar");
            table.AddItem("Thessalar");
            table.AddItem("Elemos");
            table.AddItem("Murgos");
            table.AddItem("Denthar");
            table.AddItem("Laerlos");
            table.AddItem("Baerom");
            table.AddItem("Kelbin");
            table.AddItem("Nuthos");
            table.AddItem("Theros");

            return table.GetResult();
        }

        public static string WaterdhavianNameFemale()
        {
            var table = new RandomTable<string>();

            table.AddItem("Loene");
            table.AddItem("Shyrrbr");
            table.AddItem("Thear");
            table.AddItem("Xorla");
            table.AddItem("Laerel");
            table.AddItem("Eleelae");
            table.AddItem("Yulyssil");
            table.AddItem("Shulaleen");
            table.AddItem("Edareen");
            table.AddItem("Yalah");
            table.AddItem("Dala");
            table.AddItem("Kylynne");

            return table.GetResult();
        }

        public static string WaterdhavianSurname()
        {
            var table = new RandomTable<string>();

            table.AddItem("Gauntyl");
            table.AddItem("Cassalanter");
            table.AddItem("Eltorchul");
            table.AddItem("Anteos");
            table.AddItem("Eagleshield");
            table.AddItem("Gost");
            table.AddItem("Gralhund");
            table.AddItem("Stormweather");
            table.AddItem("Moonstar");
            table.AddItem("Zun");
            table.AddItem("Hawkwinter");
            table.AddItem("Husteem");

            return table.GetResult();
        }

        public static string ThraxianFirstName()
        {
            var table = new RandomTable<string>();

            table.AddItem("Kromag");
            table.AddItem("Gharm");
            table.AddItem("Karash");
            table.AddItem("Wryner");
            table.AddItem("Krash");
            table.AddItem("Amal");
            table.AddItem("Frackak");
            table.AddItem("Warhark");
            table.AddItem("Zeres");
            table.AddItem("Mog");
            table.AddItem("Gog");
            table.AddItem("Barkon");

            return table.GetResult();
        }

        public static string ThraxianPrename()
        {
            var table = new RandomTable<string>();

            table.AddItem("General");
            table.AddItem("Commander");
            table.AddItem("War Chief");
            table.AddItem("Warlord");
            table.AddItem("Hammerlord");
            table.AddItem("Blademaster");
            table.AddItem("Shadowspinner");
            table.AddItem("Corpsecaller");
            table.AddItem("Lieutennant");
            table.AddItem("Captain");
            table.AddItem("Magistrate");
            table.AddItem("Judge");

            return table.GetResult();
        }

        public static string ThraxianNickname()
        {
            var table = new RandomTable<string>();

            table.AddItem("the Orator");
            table.AddItem("the Cruel");
            table.AddItem("the Forgotten");
            table.AddItem("the Herald");
            table.AddItem("the Destroyer");
            table.AddItem("the Avenger");
            table.AddItem("the Conquerer");
            table.AddItem("the Freebooter");
            table.AddItem("the Slayer");
            table.AddItem("the Deadly");
            table.AddItem("the Seer");
            table.AddItem("the Cold");

            return table.GetResult();
        }
    }
}
