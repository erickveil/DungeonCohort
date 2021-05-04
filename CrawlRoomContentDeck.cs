using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class CrawlRoomContentDeck
    {
        public CardDeck<string> RoomContentDeck;

        public void BuildDeck()
        {
            RoomContentDeck = new CardDeck<string>();
            RoomContentDeck.AddCard("Empty");
            RoomContentDeck.AddCard("Monster", 2);
            RoomContentDeck.AddCard("Treasure");
            RoomContentDeck.AddCard("Trap");
            RoomContentDeck.AddCard("Hazard");
            RoomContentDeck.AddCard("Mundane Feature");
            RoomContentDeck.AddCard("Beneficial Feature");
            RoomContentDeck.AddCard("Trick");
            RoomContentDeck.AddCard("Monster and Treasure");
            RoomContentDeck.AddCard("Trap and Treasure");
            RoomContentDeck.AddCard("Hazard and Treasure");
            RoomContentDeck.AddCard("Monster and Trap");
            RoomContentDeck.AddCard("Monster and Hazard");

            var artifact = new RandomTable<string>();
            artifact.AddItem("Minor Artifact");
            artifact.AddItem("Monster and Artifact");
            artifact.AddItem("Trap and Artifact");
            artifact.AddItem("Monster, Treasure, and Artifact");
            artifact.AddItem("Monster and Trapped Artifact");

            RoomContentDeck.AddCard(artifact.GetResult());
        }

        public string DrawCard()
        {
            if (RoomContentDeck.CountDrawDeck() <= 0) { RoomContentDeck.ReshuffleDeck(); }
            return RoomContentDeck.DrawCard();
        }
    }
}
