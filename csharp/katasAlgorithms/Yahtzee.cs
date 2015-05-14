using System;
using System.Collections.Generic;

namespace katasAlgorithms
{
    public enum Options
    {
        ONES = 1,
        TWOS,
        THREES,
        FOURS,
        FIVES,
        SIXES,
        PAIR,
        TWOPAIR,
        THREEKIND,
        FOURKIND,
        SMALL,
        LARGE,
        YAHTZEE
    }

    public class Yahtzee
    {
        public int CalculateRoll (IEnumerable<int> dice, Options option)
        {
            switch (option)
            {
            case Options.ONES:
            case Options.TWOS:
            case Options.THREES:
            case Options.FOURS:
            case Options.FIVES:
            case Options.SIXES:
                return CalculateSimpleNumbers(dice, (int)option);
            }

            return 0;
        }

        public int CalculateSimpleNumbers(IEnumerable<int> dice, int die)
        {
            var consolidated = ConsolidateDice(dice);
            if (consolidated.ContainsKey(die))
            {
                return die * consolidated [die];
            }

            return 0;
        }

        public Dictionary<int, int> ConsolidateDice(IEnumerable<int> dice)
        {
            Dictionary<int, int> consolidated = new Dictionary<int, int>();

            foreach (int die in dice)
            {
                if (!consolidated.ContainsKey(die))
                {
                    consolidated.Add(die, 0);
                }

                consolidated [die] += 1;
            }

            return consolidated;
        }
    }
}

