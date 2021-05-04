using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort 
{
    class CardDeck<T>
    {
        private List<T> _UniqueItemList;
        private List<T> _MasterDeck;
        private List<T> _DrawDeck;
        private List<T> _DiscardDeck;

        private Dice _dice;

        public CardDeck()
        {
            _dice = Dice.Instance;
            _UniqueItemList = new List<T>();
            _MasterDeck = new List<T>();
            _DrawDeck = new List<T>();
            _DiscardDeck = new List<T>();
        }

        public void AddCard(T Card, uint Weight = 1)
        {
            _UniqueItemList.Add(Card);
            for (uint i = 0; i < Weight; ++i)
            {
                _MasterDeck.Add(Card);
                _DrawDeck.Add(Card);
            }
        }

        public T DrawCard()
        {
            if (_DrawDeck.Count == 0) { return default; }
            int roll = _dice.Roll(1, _DrawDeck.Count) - 1;
            var result = _DrawDeck[roll];
            _DiscardDeck.Add(result);
            _DrawDeck.RemoveAt(roll);
            return result;
        }

        public void ReshuffleDeck()
        {
            _DrawDeck.Clear();
            foreach(T Card in _MasterDeck)
            {
                _DrawDeck.Add(Card);
            }
            _DiscardDeck.Clear();
        }

        public int CountUniqueCards()
        {
            return _UniqueItemList.Count;
        }

        public int CountDrawDeck()
        {
            return _DrawDeck.Count;
        }

        public int CountMasterDeck()
        {
            return _MasterDeck.Count;
        }

        public int CountDiscardDeck()
        {
            return _DiscardDeck.Count;
        }
    }
}
