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
using DungeonCohort.JsonLoading;

namespace DungeonCohort
{
    public partial class Form1 : Form
    {
        AncestryIndex _ancestryIndex;
        JsonLootLoader _lootLoader;
        Dice _dice;
        EncounterFactory _encounterFactory;

        CrawlRooms _lastRoom = null;
        CrawlRoomExit _standardExit = null;

        TimeTracker tracker1 = new TimeTracker();
        TimeTracker tracker2 = new TimeTracker();
        TimeTracker tracker3 = new TimeTracker();
        TimeTracker tracker4 = new TimeTracker();

        public Form1()
        {
            InitializeComponent();

            _ancestryIndex = AncestryIndex.Instance;
            _dice = Dice.Instance;
            _lootLoader = JsonLootLoader.Instance;

            _encounterFactory = new EncounterFactory();
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

        public void PrintList(RichTextBox target, string msg)
        {

            var typeface = "AvantGarde Normal";
            var size = 11;
            var style = FontStyle.Regular;
            var font = new Font(typeface, size, style);

            int msgStart = target.Text.Length;
            int msgLen = msg.Length;
            target.AppendText(msg);
            target.Select(msgStart, msgLen);
            target.SelectionFont = font;
            target.SelectionBullet = true;
        }

        private void bu_monster_Click(object sender, EventArgs e)
        {
            RichTextBox target = rtb_rndMonstOut;
            target.Clear();

            int tier = (int)nud_tier.Value;
            string biome = cb_biome.Text;
            bool isStdRace = cb_stdRaceNpcs.Checked;
            Ancestry monster = _ancestryIndex.GetRandomAncestry(tier, biome, 
                isStdRace);

            var lootTable = _lootLoader.GetIndividualLootTable(tier);
            LootTableResult loot = lootTable.GetResult();
            string lootReport = "\nLoot: " + loot.ToString();

            string monsterName = monster.GetCompositeName();
            string cr = monster.CR;
            PrintBody(target, monsterName + " (CR: " + cr + ")" + lootReport);
        }

        private void bu_genNPC_Click(object sender, EventArgs e)
        {
            RichTextBox target = rtb_rndMonstOut;
            target.Clear();

            int tier = (int)nud_tier.Value;
            bool isStdRace = cb_stdRaceNpcs.Checked;
            Character npc = _ancestryIndex.GetRandomNPC(tier, 
                AlignmentValue.ALIGN_GOOD, isStdRace);

            var lootTable = _lootLoader.GetIndividualLootTable(tier);
            LootTableResult loot = lootTable.GetResult();
            string lootReport = "\nLoot: " + loot.ToString();

            string npcName = npc.GetFullIdentifier();
            string alignment = npc.GetAlignmentString();
            string cr = npc.Ancestry.CR;
            PrintBody(target, npcName + " (" + cr + ")\n" + alignment
                + lootReport);
        }

        private void bu_npcParty_Click(object sender, EventArgs e)
        {
            int numMembers = _dice.Roll(1, 4) + 1;
            int tier = (int)nud_tier.Value;
            bool isStdRace = cb_stdRaceNpcs.Checked;
            AlignmentValue align = Character.ChoseAlignmentGE();
            var leader = _ancestryIndex.GetRandomNPC(tier, align, isStdRace);
            var partyRoster = new List<Character>();
            for (int i = 0; i < numMembers; ++i)
            {
                partyRoster.Add(
                    _ancestryIndex.GetRandomNPC(tier, align, isStdRace)
                    );
            }

            RichTextBox target = rtb_rndMonstOut;
            target.Clear();

            PrintH1(target, "NPC Party\n");

            var lootTable = _lootLoader.GetIndividualLootTable(tier);
            LootTableResult loot = lootTable.GetResult();
            string lootReport = "Loot: " + loot.ToString();

            string npcName = leader.GetFullIdentifier();
            string alignment = leader.GetAlignmentString();
            string cr = leader.Ancestry.CR;
            PrintList(target, npcName + " (cr: " + cr + "; " + alignment 
                + "; " + lootReport + ")\n");
            foreach(var npc in partyRoster)
            {
                lootTable = _lootLoader.GetIndividualLootTable(tier);
                loot = lootTable.GetResult();
                lootReport = "Loot: " + loot.ToString();

                npcName = npc.GetFullIdentifier();
                alignment = npc.GetAlignmentString();
                cr = npc.Ancestry.CR;

                PrintList(target, npcName + " (cr: " + cr + "; " + 
                    alignment + "; " + lootReport + ")\n");
            }
        }

        private void bu_indiTreasure_Click(object sender, EventArgs e)
        {
            RichTextBox target = rtb_rndMonstOut;
            target.Clear();
            int tier = (int)nud_tier.Value;
            var permissions = GetItemPermissions();

            var treasureGen = new TreasureFactory();
            var loot = treasureGen.GetIndividualTreasure(tier, permissions);

            string lootReport = "Loot: " + loot.ToString();
            PrintBody(target, lootReport);
        }

        private void bu_hordeTreasure_Click(object sender, EventArgs e)
        {
            RichTextBox target = rtb_rndMonstOut;
            target.Clear();
            int tier = (int)nud_tier.Value;
            var permissions = GetItemPermissions();

            bool isSpellbooksInHorde = chkSpellbooksInHorde.Checked;
            var treasureGen = new TreasureFactory();
            var loot = treasureGen.GetTreasureHoard(tier, permissions, isSpellbooksInHorde);

            string lootReport = "Treasure Horde:\n" + loot.ToString();
            PrintBody(target, lootReport);

        }

        private MagicItemPermissions GetItemPermissions()
        {
            var permissions = new MagicItemPermissions();
            permissions.MinorCommon = cb_allowCommon.Checked;
            permissions.MinorUncommon = cb_allowMinorUncommon.Checked;
            permissions.MinorRare = cb_allowMinorRare.Checked;
            permissions.MinorVeryRare = cb_allowMinorVeryRare.Checked;
            permissions.MinorLegendary = cb_allowMinorLegendary.Checked;
            permissions.MajorUncommon = cb_allowMajorUncommon.Checked;
            permissions.MajorRare = cb_allowMajorRare.Checked;
            permissions.MajorVeryRare = cb_allowMajorVeryRare.Checked;
            permissions.MajorLegendary = cb_allowMajorLegendary.Checked;
            return permissions;
        }

        private void bu_encounter_Click(object sender, EventArgs e)
        {
            _encounterFactory.Clear();
            _encounterFactory.PcLevelList.Add((int)nud_pcLevelA.Value);
            _encounterFactory.PcLevelList.Add((int)nud_pcLevelB.Value);
            _encounterFactory.PcLevelList.Add((int)nud_pcLevelC.Value);
            _encounterFactory.PcLevelList.Add((int)nud_pcLevelD.Value);

            _encounterFactory.PcQtyList.Add((int)nud_pcQtyA.Value);
            _encounterFactory.PcQtyList.Add((int)nud_pcQtyB.Value);
            _encounterFactory.PcQtyList.Add((int)nud_pcQtyC.Value);
            _encounterFactory.PcQtyList.Add((int)nud_pcQtyD.Value);

            _encounterFactory.Difficulty = cb_difficulty.Text;

            string biome = cb_biome.Text;
            bool isStandardRace = cb_stdRaceNpcs.Checked;

            RichTextBox target = rtb_rndMonstOut;
            target.Clear();

            if (biome == "")
            {
                PrintBody(target, "Set Biome");
                return;
            }
            if (_encounterFactory.Difficulty == "")
            {
                PrintBody(target, "Set Difficulty");
                return;
            }
            if (_encounterFactory.PcLevelList.Sum() == 0)
            {
                PrintBody(target, "Set PC Levels");
                return;
            }
            if (_encounterFactory.PcQtyList.Sum() == 0)
            {
                PrintBody(target, "Set Number of PCs");
                return;
            }
            _encounterFactory.PickRandomEncounter(biome, isStandardRace);

            PrintBody(target, _encounterFactory.LastEncounterAsString());
        }

        private void bu_rollDice_Click(object sender, EventArgs e)
        {
            int num = (int)nud_dNum.Value;
            var resultList = new List<int>();
            int size = (int)nud_dieSize.Value;
            int result = _dice.Roll(num, size, out resultList);

            string output = "";
            foreach (var roll in resultList)
            {
                output += roll.ToString() + "\n";
            }
            output += "Total: " + result.ToString();

            RichTextBox target = rtb_rndMonstOut;
            target.Clear();
            PrintBody(target, output);


        }

        private void bu_fate_Click(object sender, EventArgs e)
        {
            int chaosFactor = (int)nud_chaosFactor.Value;
            string odds = cobo_odds.Text;
            if (odds == "")
            {
                tb_fate.Text = "Set odds!";
                return;
            }

            bool isEvent;
            string result = GmEmulator.RollFate(chaosFactor, odds, out isEvent);
            tb_fate.Text = result;

            if (!isEvent) { return; }

            tb_fate.Text = tb_fate.Text + " (Event!)";

            string eventStr = GmEmulator.RollRandomEvent();
            rtb_event.Clear();
            PrintBody(rtb_event, eventStr);
        }

        private void bu_event_Click(object sender, EventArgs e)
        {
            string eventStr = GmEmulator.RollRandomEvent();
            rtb_event.Clear();
            PrintBody(rtb_event, eventStr);
        }

        private void bu_scene_Click(object sender, EventArgs e)
        {
            int chaosFactor = (int)nud_chaosFactor.Value;
            string result = GmEmulator.RollSceneMod(chaosFactor);
            tb_scene.Text = result;
        }

        private void but_CrawlRoom_Click(object sender, EventArgs e)
        {
            var room = new CrawlRooms();

            // Get basic crawl room specifications from UI
            string dungeonType = combo_crawlDungeonType.Text;
            bool isLargeRoom = cb_crawlLargeRooms.Checked;
            bool isNarrowHalls = cb_crawlNarrowPassages.Checked;
            int tier = (int)nud_tier.Value;

            // persistently use the same standard exit in all rooms
            // creating it if necessary
            if (_standardExit is null)
            {
                _standardExit = new CrawlRoomExit();
                _standardExit.InitAsStandard(tier);
            }
            room.StandardExit = _standardExit;

            // If we generate full encounters in monster rooms, we need more
            // data from the UI
            bool isSetEncounters = ch_crawlFullEncounters.Checked;
            MagicItemPermissions allowedItems = GetItemPermissions();
            string biome = cb_biome.Text;
            bool isStandardRace = cb_stdRaceNpcs.Checked;
            List<int> pcLevelList = new List<int>();
            List<int> pcQtyList = new List<int>();
            pcLevelList.Add((int)nud_pcLevelA.Value);
            pcLevelList.Add((int)nud_pcLevelB.Value);
            pcLevelList.Add((int)nud_pcLevelC.Value);
            pcLevelList.Add((int)nud_pcLevelD.Value);
            pcQtyList.Add((int)nud_pcQtyA.Value);
            pcQtyList.Add((int)nud_pcQtyB.Value);
            pcQtyList.Add((int)nud_pcQtyC.Value);
            pcQtyList.Add((int)nud_pcQtyD.Value);

            // Match the entrance to this room to the exit of the last room
            CrawlRooms.ExitDirection enterFrom = CrawlRooms.ExitDirection.EXIT_EAST;
            string entryInputVal = cb_crawlEnterDirection.Text;

            CrawlRoomExit entry;
            // First enter the dungeon by a standard exit type
            if (_lastRoom is null)
            {
                _lastRoom = new CrawlRooms();
                _lastRoom.NorthExit = new CrawlRoomExit();
                _lastRoom.SouthExit = new CrawlRoomExit();
                _lastRoom.EastExit = new CrawlRoomExit();
                _lastRoom.WestExit = new CrawlRoomExit();
                _lastRoom.NorthExit.InitAsStandard(tier);
                _lastRoom.SouthExit.InitAsStandard(tier);
                _lastRoom.EastExit.InitAsStandard(tier);
                _lastRoom.WestExit.InitAsStandard(tier);
            }

            // String to enum conversion
            switch (entryInputVal)
            {
                case "North":
                    enterFrom = CrawlRooms.ExitDirection.EXIT_NORTH;
                    entry = _lastRoom.SouthExit;
                    break;
                case "South":
                    enterFrom = CrawlRooms.ExitDirection.EXIT_SOUTH;
                    entry = _lastRoom.NorthExit;
                    break;
                case "East":
                    enterFrom = CrawlRooms.ExitDirection.EXIT_EAST;
                    entry = _lastRoom.WestExit;
                    break;
                default:
                    enterFrom = CrawlRooms.ExitDirection.EXIT_WEST;
                    entry = _lastRoom.EastExit;
                    break;
            }

            // for encounters we need to make sure the encounter data is set
            var target = rtb_Crawl;
            target.Clear();
            if (isSetEncounters)
            {
                if (biome == "")
                {
                    PrintBody(target, "Set Biome");
                    return;
                }
                if (pcLevelList.Sum() == 0)
                {
                    PrintBody(target, "Set PC Levels");
                    return;
                }
                if (pcQtyList.Sum() == 0)
                {
                    PrintBody(target, "Set Number of PCs");
                    return;
                }
            }

            bool isSpellbookInHorde = chkSpellbooksInHorde.Checked;
            // put it all together here
            room.RandomizeRoom(
                dungeonType,
                isLargeRoom,
                isNarrowHalls,
                tier,
                enterFrom,
                entry,
                isSetEncounters,
                allowedItems,
                biome,
                isStandardRace,
                pcLevelList,
                pcQtyList,
                isSpellbookInHorde
                );

            target.Clear();
            PrintH2(target, room.GetHeader());
            PrintBody(target, "\n" + room.AsString());

            // save the room for determining the next room's entrance
            _lastRoom = room;
        }

        private void bu_mythicClear_Click(object sender, EventArgs e)
        {
            rtb_event.Clear();
            tb_fate.Text = "";
            tb_scene.Text = "";
        }

        private void bu_rndTrap_Click(object sender, EventArgs e)
        {
            int tier = (int)nud_tier.Value;
            var trap = new CrawlRoomTrap();
            trap.InitTrap(tier);

            var target = rtb_rndMonstOut;
            target.Clear();
            PrintBody(target, trap.ToString());

        }

        private void bu_crawlClear_Click(object sender, EventArgs e)
        {
            _lastRoom = null;
            var target = rtb_Crawl;
            target.Clear();
        }

        private void but_trap_Click(object sender, EventArgs e)
        {
            var trap = new CrawlRoomTrap();
            int tier = (int)nud_tier.Value;
            trap.InitTrap(tier);
            string desc = trap.ToString();
            var target = rtb_Crawl;
            target.Clear();
            PrintBody(target, desc);
        }

        private void but_complexTrap_Click(object sender, EventArgs e)
        {
            int tier = (int)nud_tier.Value;
            var trap = new CrawlRoomComplexTrap();
            trap.Init(tier);
            string desc = trap.ToString();
            var target = rtb_Crawl;
            target.Clear();
            PrintBody(target, desc);

        }

        private void bu_hex_Landmark_Click(object sender, EventArgs e)
        {
            var landmark = new HexCrawlLandmark();
            landmark.Init();
            var target = rtb_HexCrawlOut;
            target.Clear();
            PrintBody(target, landmark.ToString());
        }

        private void bu_HexCrawlRoute_Click(object sender, EventArgs e)
        {
            string currentRouteType = cbx_HexCrawlRouteType.Text;
            var newPath = new HexCrawlPath();
            newPath.CurrentPathType = currentRouteType;
            newPath.Init();

            var target = rtb_HexCrawlOut;
            target.Clear();
            PrintBody(target, newPath.ToString());
        }

        private void bu_HexEvent_Click(object sender, EventArgs e)
        {
            var hexEvent = new HexCrawlEvent();
            hexEvent.Init();

            var target = rtb_HexCrawlOut;
            target.Clear();
            PrintBody(target, hexEvent.ToString());

        }

        private void bu_Landscape_Click(object sender, EventArgs e)
        {
            string biome = cb_HexCrawlBiome.Text;
            var scenery = new HexCrawlScenery();
            scenery.Init(biome);

            var target = rtb_HexCrawlOut;
            target.Clear();
            PrintBody(target, scenery.ToString());
        }

        private void bu_hexCrawl_Click(object sender, EventArgs e)
        {
            string biome = cb_HexCrawlBiome.Text;
            string currentPathType = cbx_HexCrawlRouteType.Text;

            var hex = new HexCrawlHex();
            hex.Init(biome, currentPathType);

            var target = rtb_HexCrawlOut;
            target.Clear();
            PrintBody(target, hex.ToString());
        }

        private void bu_dungeonIntel_Click(object sender, EventArgs e)
        {
            var dice = Dice.Instance;

            string origin = DungeonIntel.GetDungeonOriginalPurpose();

            int numHistory = dice.Roll(1, 4) + 1;
            string history = "";
            for (int i = 0; i < numHistory; ++i)
            {
                history += DungeonIntel.GetDungeonHistory() + "\n";
            }

            string puzzle = DungeonIntel.GetEndOfDungeonPuzzleSecret();

            var target = rtb_Crawl;
            target.Clear();

            PrintBodyBold(target, "Origin: ");
            PrintBody(target, origin + "\n");
            PrintBodyBold(target, "History:\n");
            PrintList(target, history);
            PrintBodyBold(target, "Secret: ");
            PrintBody(target, puzzle);

        }

        private void bu_questGen_Click(object sender, EventArgs e)
        {
            var target = rtb_rndMonstOut;
            target.Clear();
            PrintBody(target, Quests.CreateQuest());

        }

        private void crawl_atmosphere_Click(object sender, EventArgs e)
        {
            var target = rtb_Crawl;
            target.Clear();
            PrintBody(target, DungeonAtmosphere.GenerateAtmosphere());

        }

        private void butAI_Click(object sender, EventArgs e)
        {
            string disposition = comboReactionDisposition.Text;
            string tactics = CombatAi.ChooseOpeningTactics();
            string focus = CombatAi.ChooseFocus();
            string opportunity = CombatAi.OpportunityPreference();
            string persistence = CombatAi.ChooseTargetPersistence();
            string ranged = CombatAi.RangedStrategy();
            string fatality = CombatAi.Fatality();

            var target = rtbCombatAI;
            target.Clear();
            PrintBodyBold(target, "Tactics: \n");
            PrintBody(target, tactics + "\n\n");
            PrintBodyBold(target, "Focus: \n");
            PrintBody(target, focus + "\n\n");
            PrintBodyBold(target, "Opportunity: \n");
            PrintBody(target, opportunity + "\n\n");
            PrintBodyBold(target, "Persistence: \n");
            PrintBody(target, persistence + "\n\n");
            PrintBodyBold(target, "Ranged: \n");
            PrintBody(target, ranged + "\n\n");
            PrintBodyBold(target, "Fatality: \n");
            PrintBody(target, fatality);
        }

        private void butNegotiate_Click(object sender, EventArgs e)
        {
            string personality = CombatAi.GetDualPersonality();
            string offers = CombatAi.ConsiderOffers();

            var target = rtbNegotiate;
            target.Clear();

            PrintBodyBold(target, "Personality:\n");
            PrintBody(target, personality + "\n\n");
            PrintBodyBold(target, "Offers:\n");
            PrintBody(target, offers);
        }

        private void butMorale_Click(object sender, EventArgs e)
        {
            var dice = Dice.Instance;
            int DC = dice.Roll(2, 8) + 3;
            string failure = CombatAi.MoraleFailure();

            var target = rtbMorale;
            target.Clear();

            PrintBodyBold(target, "Morale DC: ");
            PrintBody(target, DC.ToString() + "\n\n");
            PrintBodyBold(target, "If Failed: ");
            PrintBody(target, failure);
        }

        private void chIsSet1_CheckedChanged(object sender, EventArgs e)
        {
            if (chIsSet1.Checked)
            {
                tracker1.Name = tbTimerName1.Text;
                tracker1.Duration.Rounds = (int)nudDurRounds1.Value;
                tracker1.Duration.Minutes = (int)nudDurMins1.Value;
                tracker1.Duration.Hours = (int)nudDurHrs1.Value;
                tracker1.SetTimer();
            }
            else
            {
                tracker1.IsSet = false;
            }
            _updateTracker1Ui();
        }

        private void chIsSet2_CheckedChanged(object sender, EventArgs e)
        {
            if (chIsSet2.Checked)
            {
                tracker2.Name = tbTimerName2.Text;
                tracker2.Duration.Rounds = (int)nudDurRounds2.Value;
                tracker2.Duration.Minutes = (int)nudDurMins2.Value;
                tracker2.Duration.Hours = (int)nudDurHrs2.Value;
                tracker2.SetTimer();
            }
            else
            {
                tracker2.IsSet = false;
            }
            _updateTracker2Ui();
        }

        private void chIsSet3_CheckedChanged(object sender, EventArgs e)
        {
            if (chIsSet3.Checked)
            {
                tracker3.Name = tbTimerName3.Text;
                tracker3.Duration.Rounds = (int)nudDurRounds3.Value;
                tracker3.Duration.Minutes = (int)nudDurMins3.Value;
                tracker3.Duration.Hours = (int)nudDurHrs3.Value;
                tracker3.SetTimer();
            }
            else
            {
                tracker3.IsSet = false;
            }
            _updateTracker3Ui();
        }

        private void chIsSet4_CheckedChanged(object sender, EventArgs e)
        {
            if (chIsSet4.Checked)
            {
                tracker4.Name = tbTimerName4.Text;
                tracker4.Duration.Rounds = (int)nudDurRounds4.Value;
                tracker4.Duration.Minutes = (int)nudDurMins4.Value;
                tracker4.Duration.Hours = (int)nudDurHrs4.Value;
                tracker4.SetTimer();
            }
            else
            {
                tracker4.IsSet = false;
            }
            _updateTracker4Ui();
        }

        private void butRound_Click(object sender, EventArgs e)
        {
            ++nudCombatRounds.Value;
            tracker1.AdvanceRound();
            tracker2.AdvanceRound();
            tracker3.AdvanceRound();
            tracker4.AdvanceRound();
            _updateTracker1Ui();
            _updateTracker2Ui();
            _updateTracker3Ui();
            _updateTracker4Ui();
        }

        private void butEndCombat_Click(object sender, EventArgs e)
        {
            ++nudCombatRounds.Value;
            tracker1.EndCombat();
            tracker2.EndCombat();
            tracker3.EndCombat();
            tracker4.EndCombat();
            _updateTracker1Ui();
            _updateTracker2Ui();
            _updateTracker3Ui();
            _updateTracker4Ui();
        }

        private void butExplore_Click(object sender, EventArgs e)
        {
            ++nudCombatRounds.Value;
            tracker1.AdvanceTenMinutes();
            tracker2.AdvanceTenMinutes();
            tracker3.AdvanceTenMinutes();
            tracker4.AdvanceTenMinutes();
            _updateTracker1Ui();
            _updateTracker2Ui();
            _updateTracker3Ui();
            _updateTracker4Ui();
        }

        private void butShortRest_Click(object sender, EventArgs e)
        {
            ++nudCombatRounds.Value;
            tracker1.AdvanceOneHour();
            tracker2.AdvanceOneHour();
            tracker3.AdvanceOneHour();
            tracker4.AdvanceOneHour();
            _updateTracker1Ui();
            _updateTracker2Ui();
            _updateTracker3Ui();
            _updateTracker4Ui();
        }

        private void but4Hr_Click(object sender, EventArgs e)
        {
            ++nudCombatRounds.Value;
            tracker1.AdvanceFourHours();
            tracker2.AdvanceFourHours();
            tracker3.AdvanceFourHours();
            tracker4.AdvanceFourHours();
            _updateTracker1Ui();
            _updateTracker2Ui();
            _updateTracker3Ui();
            _updateTracker4Ui();
        }

        private void but8Hr_Click(object sender, EventArgs e)
        {
            ++nudCombatRounds.Value;
            tracker1.AdvanceEightHours();
            tracker2.AdvanceEightHours();
            tracker3.AdvanceEightHours();
            tracker4.AdvanceEightHours();
            _updateTracker1Ui();
            _updateTracker2Ui();
            _updateTracker3Ui();
            _updateTracker4Ui();
        }

        private void _updateTracker1Ui()
        {
            tbTimerName1.Text = tracker1.Name;

            nudDurRounds1.Value = tracker1.Duration.Rounds;
            nudDurMins1.Value = tracker1.Duration.Minutes;
            nudDurHrs1.Value = tracker1.Duration.Hours;

            nudRemRounds1.Value = tracker1.Remaining.Rounds;
            nudRemMin1.Value = tracker1.Remaining.Minutes;
            nudRemHr1.Value = tracker1.Remaining.Hours;
            if (chIsSet1.Checked != tracker1.IsSet) 
            { 
                chIsSet1.Checked = tracker1.IsSet; 
            }
        }

        private void _updateTracker2Ui()
        {
            tbTimerName2.Text = tracker2.Name;

            nudDurRounds2.Value = tracker2.Duration.Rounds;
            nudDurMins2.Value = tracker2.Duration.Minutes;
            nudDurHrs2.Value = tracker2.Duration.Hours;

            nudRemRounds2.Value = tracker2.Remaining.Rounds;
            nudRemMin2.Value = tracker2.Remaining.Minutes;
            nudRemHr2.Value = tracker2.Remaining.Hours;
            if (chIsSet2.Checked != tracker2.IsSet) 
            { 
                chIsSet2.Checked = tracker2.IsSet; 
            }
        }

        private void _updateTracker3Ui()
        {
            tbTimerName3.Text = tracker3.Name;

            nudDurRounds3.Value = tracker3.Duration.Rounds;
            nudDurMins3.Value = tracker3.Duration.Minutes;
            nudDurHrs3.Value = tracker3.Duration.Hours;

            nudRemRounds3.Value = tracker3.Remaining.Rounds;
            nudRemMin3.Value = tracker3.Remaining.Minutes;
            nudRemHr3.Value = tracker3.Remaining.Hours;
            if (chIsSet3.Checked != tracker3.IsSet) 
            { 
                chIsSet3.Checked = tracker3.IsSet; 
            }
        }

        private void _updateTracker4Ui()
        {
            tbTimerName4.Text = tracker4.Name;

            nudDurRounds4.Value = tracker4.Duration.Rounds;
            nudDurMins4.Value = tracker4.Duration.Minutes;
            nudDurHrs4.Value = tracker4.Duration.Hours;

            nudRemRounds4.Value = tracker4.Remaining.Rounds;
            nudRemMin4.Value = tracker4.Remaining.Minutes;
            nudRemHr4.Value = tracker4.Remaining.Hours;
            if (chIsSet4.Checked != tracker4.IsSet) 
            { 
                chIsSet4.Checked = tracker4.IsSet; 
            }
        }

        private void comboCommonTimers1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCommonTimers1.Text == "Torch") { tracker1.SetTorch(); }
            if (comboCommonTimers1.Text == "Lantern") { tracker1.setLantern(); }
            if (comboCommonTimers1.Text == "Bless") { tracker1.setBless(); }
            _updateTracker1Ui();
        }

        private void comboCommonTimers2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCommonTimers2.Text == "Torch") { tracker2.SetTorch(); }
            if (comboCommonTimers2.Text == "Lantern") { tracker2.setLantern(); }
            if (comboCommonTimers2.Text == "Bless") { tracker2.setBless(); }
            _updateTracker2Ui();
        }

        private void comboCommonTimers3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCommonTimers3.Text == "Torch") { tracker3.SetTorch(); }
            if (comboCommonTimers3.Text == "Lantern") { tracker3.setLantern(); }
            if (comboCommonTimers3.Text == "Bless") { tracker3.setBless(); }
            _updateTracker3Ui();
        }

        private void comboCommonTimers4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCommonTimers4.Text == "Torch") { tracker4.SetTorch(); }
            if (comboCommonTimers4.Text == "Lantern") { tracker4.setLantern(); }
            if (comboCommonTimers4.Text == "Bless") { tracker4.setBless(); }
            _updateTracker4Ui();
        }

        private void butMagicItem_Click(object sender, EventArgs e)
        {
            RichTextBox target = rtb_rndMonstOut;
            target.Clear();
            int tier = (int)nud_tier.Value;
            var permissions = GetItemPermissions();

            var treasureGen = new TreasureFactory();
            var loot = treasureGen.GetMagicItem(tier, permissions);

            string lootReport = loot.ToString();
            PrintBody(target, lootReport);

        }

        private void butReaction_Click(object sender, EventArgs e)
        {
            string disposition = comboReactionDisposition.Text;
            string reaction = CombatAi.CheckCombatReaction(disposition);

            var target = rtbReaction;
            target.Clear();
            PrintBody(target, reaction);
        }

        private void butRoomContents_Click(object sender, EventArgs e)
        {
            var room = new CrawlRooms();

            // Get basic crawl room specifications from UI
            string dungeonType = combo_crawlDungeonType.Text;
            bool isLargeRoom = cb_crawlLargeRooms.Checked;
            bool isNarrowHalls = cb_crawlNarrowPassages.Checked;
            int tier = (int)nud_tier.Value;

            // If we generate full encounters in monster rooms, we need more
            // data from the UI
            bool isSetEncounters = ch_crawlFullEncounters.Checked;
            MagicItemPermissions allowedItems = GetItemPermissions();
            string biome = cb_biome.Text;
            bool isStandardRace = cb_stdRaceNpcs.Checked;
            List<int> pcLevelList = new List<int>();
            List<int> pcQtyList = new List<int>();
            pcLevelList.Add((int)nud_pcLevelA.Value);
            pcLevelList.Add((int)nud_pcLevelB.Value);
            pcLevelList.Add((int)nud_pcLevelC.Value);
            pcLevelList.Add((int)nud_pcLevelD.Value);
            pcQtyList.Add((int)nud_pcQtyA.Value);
            pcQtyList.Add((int)nud_pcQtyB.Value);
            pcQtyList.Add((int)nud_pcQtyC.Value);
            pcQtyList.Add((int)nud_pcQtyD.Value);

            // for encounters we need to make sure the encounter data is set
            var target = rtb_Crawl;
            target.Clear();
            if (isSetEncounters)
            {
                if (biome == "")
                {
                    PrintBody(target, "Set Biome");
                    return;
                }
                if (pcLevelList.Sum() == 0)
                {
                    PrintBody(target, "Set PC Levels");
                    return;
                }
                if (pcQtyList.Sum() == 0)
                {
                    PrintBody(target, "Set Number of PCs");
                    return;
                }
            }


            bool isSpellbookInHorde = chkSpellbooksInHorde.Checked;

            var entry = new CrawlRoomExit();
            var enterFrom = CrawlRooms.ExitDirection.EXIT_EAST;
            // put it all together here
            room.RandomizeRoom(
                dungeonType,
                isLargeRoom,
                isNarrowHalls,
                tier,
                enterFrom,
                entry,
                isSetEncounters,
                allowedItems,
                biome,
                isStandardRace,
                pcLevelList,
                pcQtyList,
                isSpellbookInHorde,
                isHallsAllowed: false
                );

            target.Clear();
            PrintH2(target, room.GetHeader());
            PrintBody(target, "\n" + room.AsContentsOnlyString());

            // save the room for determining the next room's entrance
            _lastRoom = room;

        }

        private void butRestock_Click(object sender, EventArgs e)
        {
            var room = new CrawlRooms();

            // Get basic crawl room specifications from UI
            string dungeonType = combo_crawlDungeonType.Text;
            bool isLargeRoom = cb_crawlLargeRooms.Checked;
            bool isNarrowHalls = cb_crawlNarrowPassages.Checked;
            int tier = (int)nud_tier.Value;

            // If we generate full encounters in monster rooms, we need more
            // data from the UI
            bool isSetEncounters = ch_crawlFullEncounters.Checked;
            MagicItemPermissions allowedItems = GetItemPermissions();
            string biome = cb_biome.Text;
            bool isStandardRace = cb_stdRaceNpcs.Checked;
            List<int> pcLevelList = new List<int>();
            List<int> pcQtyList = new List<int>();
            pcLevelList.Add((int)nud_pcLevelA.Value);
            pcLevelList.Add((int)nud_pcLevelB.Value);
            pcLevelList.Add((int)nud_pcLevelC.Value);
            pcLevelList.Add((int)nud_pcLevelD.Value);
            pcQtyList.Add((int)nud_pcQtyA.Value);
            pcQtyList.Add((int)nud_pcQtyB.Value);
            pcQtyList.Add((int)nud_pcQtyC.Value);
            pcQtyList.Add((int)nud_pcQtyD.Value);

            // for encounters we need to make sure the encounter data is set
            var target = rtb_Crawl;
            target.Clear();
            if (isSetEncounters)
            {
                if (biome == "")
                {
                    PrintBody(target, "Set Biome");
                    return;
                }
                if (pcLevelList.Sum() == 0)
                {
                    PrintBody(target, "Set PC Levels");
                    return;
                }
                if (pcQtyList.Sum() == 0)
                {
                    PrintBody(target, "Set Number of PCs");
                    return;
                }
            }


            bool isSpellbookInHorde = chkSpellbooksInHorde.Checked;

            bool isHall = checkRestockHall.Checked;

            // put it all together here
            room.RestockRoom(
                tier,
                isSetEncounters,
                allowedItems,
                biome,
                isStandardRace,
                pcLevelList,
                pcQtyList,
                isSpellbookInHorde,
                isHall
                );

            target.Clear();
            PrintBody(target, room.AsRestockString());

            // save the room for determining the next room's entrance
            _lastRoom = room;


        }

        private void butEldEncounter_Click(object sender, EventArgs e)
        {
            var eldTable = new EldTables();
            var location = (EldTables.EldBiome)cbEldLocation.SelectedIndex;
            var lvl = (int)nudEldLevel.Value; 
            string result = eldTable.Encounter(location, lvl);

            var target = rtbEldResult;
            target.Clear();
            PrintBody(target, result);
        }

        private void bu_crawl_trick_Click(object sender, EventArgs e)
        {
            var trickObj = new CrawlRoomTrick();
            trickObj.InitAsTrick();
            var target = rtb_Crawl;
            target.Clear();
            string result = trickObj.Object + "\n" + trickObj.Effect;
            PrintBody(target, result);
        }

        private void bu_crawl_feature_Click(object sender, EventArgs e)
        {
            var featureObj = new CrawlRoomTrick();
            featureObj.InitAsFeature();
            var target = rtb_Crawl;
            target.Clear();
            string result = featureObj.Object;
            PrintBody(target, result);
        }

        private void butEldRndQuest_Click(object sender, EventArgs e)
        {
            string quest = EldQuests.EldRandomQuest();
            var target = rtbEldQuestResult;
            target.Clear();
            PrintBody(target, quest);
        }

        private void butUnderdarkCrawl_Click(object sender, EventArgs e)
        {
            string hex = UnderdarkCrawl.RollHex();
            var target = rtbUnderdarkCrawl;
            target.Clear();
            PrintBody(target, hex);
        }

        private void buttEldArtifact_Click(object sender, EventArgs e)
        {
            string artifact = EldMagicItemGen.genItem();
            var target = rtbEldArtifact;
            target.Clear();
            PrintBody(target, artifact);
        }

        private void rtbEldResult_TextChanged(object sender, EventArgs e)
        {

        }

        private void but_crawlRoomType_Click(object sender, EventArgs e)
        {
            var chamber = JsonChamberPurposeLoader.Instance;
            var table = chamber.GetDungeonRoomTypeTable(combo_crawlDungeonType.Text);
            string type = table.GetResult();
            var target = rtb_Crawl;
            target.Clear();
            PrintBody(target, type);
        }

        private void but_crawlRoomHazard_Click(object sender, EventArgs e)
        {
            var contents = new CrawlRoomContents();
            contents.SetRoomHazard((int)nud_tier.Value);
            string hazard = contents.RoomHazard;
            var target = rtb_Crawl;
            target.Clear();
            PrintBody(target, hazard);
        }

        private void butFurnitureCondition_Click(object sender, EventArgs e)
        {
            string item = DungeonFurnishings.Condition();
            var target = rtbFurniture;
            target.Clear();
            PrintBody(target, item);
        }

        private void butGenFurnature_Click(object sender, EventArgs e)
        {
            string item = DungeonFurnishings.General();
            var target = rtbFurniture;
            target.Clear();
            PrintBody(target, item);
        }

        private void butGenItems_Click(object sender, EventArgs e)
        {
            string item = DungeonFurnishings.Items();
            var target = rtbFurniture;
            target.Clear();
            PrintBody(target, item);
        }

        private void butStorageFurniture_Click(object sender, EventArgs e)
        {
            string item = DungeonFurnishings.Storage();
            var target = rtbFurniture;
            target.Clear();
            PrintBody(target, item);
        }

        private void butFurnBook_Click(object sender, EventArgs e)
        {
            string item = DungeonFurnishings.Book();
            var target = rtbFurniture;
            target.Clear();
            PrintBody(target, item);
        }

        private void butGuardFurnature_Click(object sender, EventArgs e)
        {
            string item = DungeonFurnishings.GuardRoom();
            var target = rtbFurniture;
            target.Clear();
            PrintBody(target, item);
        }

        private void butStudyFurnature_Click(object sender, EventArgs e)
        {
            string item = DungeonFurnishings.Study();
            var target = rtbFurniture;
            target.Clear();
            PrintBody(target, item);
        }

        private void butLibraryFurnature_Click(object sender, EventArgs e)
        {
            string item = DungeonFurnishings.Library();
            var target = rtbFurniture;
            target.Clear();
            PrintBody(target, item);
        }

        private void butBaracksFurnature_Click(object sender, EventArgs e)
        {
            string item = DungeonFurnishings.Baracks();
            var target = rtbFurniture;
            target.Clear();
            PrintBody(target, item);
        }

        private void butKitchenFurnature_Click(object sender, EventArgs e)
        {
            string item = DungeonFurnishings.Kitchen();
            var target = rtbFurniture;
            target.Clear();
            PrintBody(target, item);
        }

        private void butBedroomFurnature_Click(object sender, EventArgs e)
        {
            string item = DungeonFurnishings.Bedroom();
            var target = rtbFurniture;
            target.Clear();
            PrintBody(target, item);
        }

        private void butDiningFurnature_Click(object sender, EventArgs e)
        {
            string item = DungeonFurnishings.DiningRoom();
            var target = rtbFurniture;
            target.Clear();
            PrintBody(target, item);

        }

        private void butPantryFurnature_Click(object sender, EventArgs e)
        {
            string item = DungeonFurnishings.Pantry();
            var target = rtbFurniture;
            target.Clear();
            PrintBody(target, item);

        }

        private void butKennelFurnature_Click(object sender, EventArgs e)
        {
            string item = DungeonFurnishings.Kennel();
            var target = rtbFurniture;
            target.Clear();
            PrintBody(target, item);

        }

        private void butPrisonFurnature_Click(object sender, EventArgs e)
        {
            string item = DungeonFurnishings.Prison();
            var target = rtbFurniture;
            target.Clear();
            PrintBody(target, item);

        }

        private void butDormFurnature_Click(object sender, EventArgs e)
        {
            string item = DungeonFurnishings.Dorm();
            var target = rtbFurniture;
            target.Clear();
            PrintBody(target, item);

        }

        private void butMuseumFurniture_Click(object sender, EventArgs e)
        {
            string item = DungeonFurnishings.Museum();
            var target = rtbFurniture;
            target.Clear();
            PrintBody(target, item);

        }

        private void butTortureFurnature_Click(object sender, EventArgs e)
        {
            string item = DungeonFurnishings.TortureChamber();
            var target = rtbFurniture;
            target.Clear();
            PrintBody(target, item);

        }

        private void butTreasureRoom_Click(object sender, EventArgs e)
        {
            string item = DungeonFurnishings.TreasureRoom();
            var target = rtbFurniture;
            target.Clear();
            PrintBody(target, item);

        }

        private void butThroneRoomFurniture_Click(object sender, EventArgs e)
        {
            string item = DungeonFurnishings.ThroneRoom();
            var target = rtbFurniture;
            target.Clear();
            PrintBody(target, item);

        }

        private void butCryptFurniture_Click(object sender, EventArgs e)
        {
            string item = DungeonFurnishings.Crypt();
            var target = rtbFurniture;
            target.Clear();
            PrintBody(target, item);

        }

        private void butTempleFurnature_Click(object sender, EventArgs e)
        {
            string item = DungeonFurnishings.Temple();
            var target = rtbFurniture;
            target.Clear();
            PrintBody(target, item);

        }

        private void butJGCity_Click(object sender, EventArgs e)
        {
            var encounter = new JgCityEncounter();
            string quarters = comboJgQuarters.Text;
            encounter.init(quarters);
            var target = rtbJg;
            target.Clear();
            PrintBody(target, encounter.toString());
        }

        private void butJgSocial_Click(object sender, EventArgs e)
        {
            var encounter = new JgCityEncounter();
            string quarters = comboJgQuarters.Text;
            encounter.init(quarters);
            encounter.Who = encounter.socialLevelEncounter();

            var target = rtbJg;
            target.Clear();
            PrintBody(target, encounter.Who + " (SL: " + encounter.SocialLevel + ")");

        }

        private void butJGNoble_Click(object sender, EventArgs e)
        {
            var encounter = new JgCityEncounter();
            string quarters = comboJgQuarters.Text;
            encounter.init(quarters);
            encounter.Who = encounter.nobleEncounter();

            var target = rtbJg;
            target.Clear();
            PrintBody(target, encounter.toString());
        }

        private void butJgGentlemen_Click(object sender, EventArgs e)
        {
            var encounter = new JgCityEncounter();
            string quarters = comboJgQuarters.Text;
            encounter.init(quarters);
            encounter.Who = encounter.gentlemenEncounter();

            var target = rtbJg;
            target.Clear();
            PrintBody(target, encounter.toString());

        }

        private void butJGMilitary_Click(object sender, EventArgs e)
        {
            var encounter = new JgCityEncounter();
            string quarters = comboJgQuarters.Text;
            encounter.init(quarters);
            encounter.Who = encounter.militaryEncounter();

            var target = rtbJg;
            target.Clear();
            PrintBody(target, encounter.toString());

        }

        private void jgGuildEncounter_Click(object sender, EventArgs e)
        {
            var encounter = new JgCityEncounter();
            string quarters = comboJgQuarters.Text;
            encounter.init(quarters);
            encounter.Who = encounter.guildEncounter();

            var target = rtbJg;
            target.Clear();
            PrintBody(target, encounter.toString());

        }

        private void butJgMerchant_Click(object sender, EventArgs e)
        {
            var encounter = new JgCityEncounter();
            string quarters = comboJgQuarters.Text;
            encounter.init(quarters);
            encounter.Who = encounter.merchantEncounter();

            var target = rtbJg;
            target.Clear();
            PrintBody(target, encounter.toString());

        }

        private void butJgGeneral_Click(object sender, EventArgs e)
        {
            var encounter = new JgCityEncounter();
            string quarters = comboJgQuarters.Text;
            encounter.init(quarters);
            encounter.Who = encounter.generalEncounter();

            var target = rtbJg;
            target.Clear();
            PrintBody(target, encounter.toString());

        }

        private void butJgWoman_Click(object sender, EventArgs e)
        {
            var encounter = new JgCityEncounter();
            string quarters = comboJgQuarters.Text;
            encounter.init(quarters);
            encounter.Who = encounter.womanEncounter();

            var target = rtbJg;
            target.Clear();
            PrintBody(target, encounter.toString());


        }

        private CrawlRoomContentDeck _crawlRoomContentDeck = null;

        private void butContentCard_Click(object sender, EventArgs e)
        {
            if (_crawlRoomContentDeck == null)
            {
                _crawlRoomContentDeck = new CrawlRoomContentDeck();
                _crawlRoomContentDeck.BuildDeck();
            }

            string result = _crawlRoomContentDeck.DrawCard();
            var target = rtb_Crawl;
            target.Clear();
            PrintBody(target, result + 
                "\n" +
                "\nDraw Deck Count: " + _crawlRoomContentDeck.RoomContentDeck.CountDrawDeck() +
                "\nDiscard Deck Count: " + _crawlRoomContentDeck.RoomContentDeck.CountDiscardDeck()
                );

        }

        private void buShuffleCrawlContent_Click(object sender, EventArgs e)
        {
            if (_crawlRoomContentDeck == null)
            {
                _crawlRoomContentDeck = new CrawlRoomContentDeck();
                _crawlRoomContentDeck.BuildDeck();
            }

            _crawlRoomContentDeck.RoomContentDeck.ReshuffleDeck();
            var target = rtb_Crawl;
            target.Clear();
            PrintBody(target, 
                "\nDraw Deck Count: " + _crawlRoomContentDeck.RoomContentDeck.CountDrawDeck() +
                "\nDiscard Deck Count: " + _crawlRoomContentDeck.RoomContentDeck.CountDiscardDeck() 
                );

        }

        private void butEldMotivation_Click(object sender, EventArgs e)
        {
            var table = new EldTables();
            string subject = comboEldMotivation.Text;
            string result = table.Motivation(subject);
            tbEldMotivation.Text = result;
        }

        private void butEldSpecificQuest_Click(object sender, EventArgs e)
        {
            string quest = EldQuests.SpecificAdventures();
            var target = rtbEldQuestResult;
            target.Clear();
            PrintBody(target, quest);
        }

        private void butEldVisitorQuest_Click(object sender, EventArgs e)
        {
            string quest = EldQuests.VisitorQuest();
            var target = rtbEldQuestResult;
            target.Clear();
            PrintBody(target, quest);
        }

        private void butEldRumors_Click(object sender, EventArgs e)
        {
            string quest = EldQuests.Rumors();
            var target = rtbEldQuestResult;
            target.Clear();
            PrintBody(target, quest);
        }

        private void butEldLocations_Click(object sender, EventArgs e)
        {
            string loc = EldHex.HexLocations();
            var target = rtbEldHex;
            target.Clear();
            PrintBody(target, loc);
        }

        private void butEldHexEvents_Click(object sender, EventArgs e)
        {
            int tier = 1;

            string hexEvent = EldHex.HexEvent(tier, _ancestryIndex);
            var target = rtbEldHexEvents;
            target.Clear();
            PrintBody(target, hexEvent);

        }

        private void butEldNpc_Click(object sender, EventArgs e)
        {
            int tier = 1;
            var npc = EldHex.Npc(tier, _ancestryIndex);

            var target = rtbEldNpc;
            target.Clear();
            PrintBody(target, npc);
        }

        private void butEldHirling_Click(object sender, EventArgs e)
        {
            var target = rtbUnderdarkCrawl;
            string npc = EldHenchmen.GenerateHireling();
            target.Clear();
            PrintBody(target, npc);
        }

        private void butEldHirelingGroup_Click(object sender, EventArgs e)
        {
            var target = rtbUnderdarkCrawl;
            string npc = EldHenchmen.GenerateAllHirelings();
            target.Clear();
            PrintBody(target, npc);

        }

        private void buEldPatrons_Click(object sender, EventArgs e)
        {
            var die = Dice.Instance;
            int numPatrons = die.Roll(4, 4);
            string results = "";
            
            for (int i = 0; i < numPatrons; ++i)
            {
                string quest = EldQuests.VisitorQuest();
                int tier = 1;
                string npc = EldHex.Npc(tier, _ancestryIndex);
                string henchman = EldHenchmen.GenerateHireling();

                var table = new RandomTable<string>();
                table.AddItem("Corporal of the Watch Eilidh");
                table.AddItem("Captain of the Watch Mebros");
                table.AddItem("Baliff Laird");
                table.AddItem("Priest Svartr the Bold");
                var num = die.Roll(2, 2);
                table.AddItem(num + " Guards", 2);
                table.AddItem("Seargent of the Guard");
                table.AddItem("Quest patron: " + quest);
                table.AddItem("NPC: " + npc, 3);
                table.AddItem("Hireling: " + henchman, 8);

                results += table.GetResult() + "\n\n";

                var target = rtbUnderdarkCrawl;
                target.Clear();
                PrintBody(target, results);

            }
        }

        private void butEldRandomSummons_Click(object sender, EventArgs e)
        {
            var table = new RandomTable<string>();

            table.AddItem("Individual Treasure");
            table.AddItem("Minor Artifact");
            table.AddItem("Magic Item");
            table.AddItem("Treasure Horde");
            table.AddItem("Inspiration");

            table.AddItem("Monster Encounter", 2);
            table.AddItem("Deadly Encounter");
            table.AddItem("Trap Effect", 2);
            table.AddItem("Curse");
            table.AddItem("Cursed Magic Item");

            table.AddItem("Nothing");

            string result = table.GetResult();

            var target = rtbEldArtifact;
            target.Clear();
            PrintBody(target, result);
        }
    }
}
