﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darkmoor
{
    public class Dice
    {
        readonly Random _rng = new Random();
        private static Dice _instance = null;

        /// <summary>
        /// Singleton uses Instance to get.
        /// </summary>
        private Dice()
        {

        }

        public static Dice Instance
        {
            get
            {
                if (_instance is null) { _instance = new Dice();  }
                return _instance;
            }
        }

        /// <summary>
        /// Generates a number between min and max, inclusive.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public int RandomNumber(int min, int max)
        {
            return _rng.Next(min, max + 1);
        }

        /// <summary>
        /// Rolls qty dice with faces and returns the total.
        /// Can obtain the individual die rolls in results.
        /// Provides expected variation from the mean.
        /// </summary>
        /// <param name="qty"></param>
        /// <param name="faces"></param>
        /// <param name="results"></param>
        /// <returns></returns>
        public int Roll(int qty, int faces, out List<int> results)
        {
            results = new List<int>();
            int total = 0;
            for (int i = 0; i < qty; ++i)
            {
                int roll = _rng.Next(faces) + 1;
                total += roll;
                results.Add(roll);
                //Console.WriteLine("Roll: " + roll);
            }
            //Console.WriteLine("Total: " + total);
            return total;
        }

        /// <summary>
        /// Overloaded function without the need for a results list.
        /// </summary>
        /// <param name="qty"></param>
        /// <param name="faces"></param>
        /// <returns></returns>
        public int Roll(int qty, int faces)
        {
            int total = 0;
            for (int i = 0; i < qty; ++i)
            {
                int roll = _rng.Next(faces) + 1;
                total += roll;
                //Console.WriteLine("Roll: " + roll);
            }
            //Console.WriteLine("Total: " + total);
            return total;
        }

        /// <summary>
        /// Rolls dice in string form (1d4, 2d6, etc).
        /// </summary>
        /// <param name="dieStr"></param>
        /// <returns></returns>
        public int Roll(string dieStr)
        {
            string[] splitDie = dieStr.Split('d');
            if (splitDie.Length != 2)
            {
                Console.WriteLine("Illegal die string provided for rolling: " 
                    + dieStr);
                return 0;
            }

            int numDice = 1;
            bool success = int.TryParse(splitDie[0], out numDice);
            if (!success)
            {
                Console.WriteLine("Could not determine number of dice for " +
                    "rolling: " + dieStr);
                return 0;
            }

            int sides = 1;
            success = int.TryParse(splitDie[1], out sides);
            if (!success)
            {
                Console.WriteLine("Could not determine sides of die for " +
                    "rolling: " + dieStr);
                return 0;
            }

            return Roll(numDice, sides);
        }
    }
}
