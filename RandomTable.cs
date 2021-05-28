using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darkmoor
{
    class RandomTable<T>
    {
        private List<T> _ItemList;
        private List<T> _UniqueItemList;
        private Dice _dice;

        /// <summary>
        /// Allows for bell curves on the table by specifying the number of 
        /// dice to roll for the table.
        /// Note that you should buffer the front of the table with N-1 elements
        /// and if you have a number of items not divisible by N, Padd the end 
        /// until you do.
        /// </summary>
        public int NumTableDice = 1;

        /// <summary>
        /// Initializes the entry list
        /// </summary>
        public RandomTable()
        {
            _dice = Dice.Instance;

            _ItemList = new List<T>();
            _UniqueItemList = new List<T>();
        }

        /// <summary>
        /// Adds and item to the table, with a heavier weight, the higher the
        /// weight value is.
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Weight"></param>
        public void AddItem(T Item, uint Weight = 1)
        {
            _UniqueItemList.Add(Item);
            for (uint i = 0; i < Weight; ++i)
            {
                _ItemList.Add(Item);
            }
        }

        /// <summary>
        /// Rolls on the table and returns the result
        /// </summary>
        /// <returns></returns>
        public T GetResult()
        {
            if (_ItemList.Count == 0) { return default(T); }
            if (NumTableDice == 1)
            {
                int roll = _dice.Roll(1, _ItemList.Count) - 1;
                var result = _ItemList[roll];
                return result;
            }

            int dieSize = _ItemList.Count / NumTableDice;
            int multiroll = _dice.Roll(NumTableDice, dieSize) - 1;
            var multiresult = _ItemList[multiroll];
            return multiresult;
        }

        /// <summary>
        /// Retruns the result at the location requested
        /// If the index is out of bounds, will throw.
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public T GetResult(int Index)
        {
            if (Index > _ItemList.Count)
            {
                throw new Exception("Error on RandomTable::GetResult(int) " +
                    "requesting index " + Index + " out of a possible " + 
                    _ItemList.Count + " entries.");
            }
            return _ItemList[Index];
        }

        public int GetResultIndex()
        {
            if (_ItemList.Count == 0) { return -1; }
            return _dice.Roll(1, _ItemList.Count) - 1;
        }

        /// <summary>
        /// Gets the number of individual items added to the table
        /// </summary>
        /// <returns></returns>
        public int CountUniqueEntries()
        {
            return _UniqueItemList.Count;
        }

        /// <summary>
        /// Gets the size of the table itself.
        /// </summary>
        /// <returns></returns>
        public int CountPossibilites()
        {
            return _ItemList.Count;
        }

        public List<T> GetUniqueEntryList()
        {
            return _UniqueItemList;
        }
    }
}
