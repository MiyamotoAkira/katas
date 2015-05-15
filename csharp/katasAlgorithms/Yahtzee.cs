using System.Collections.Generic;
using System.Linq;

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
        FULL,
        YAHTZEE
    }

    public class Yahtzee
    {
        public int CalculateRoll(IEnumerable<int> dice, Options option)
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
            case Options.PAIR:
                return CalculateKind(dice, 2);
            case Options.THREEKIND:
                return CalculateKind(dice, 3);
            case Options.FOURKIND:
                return CalculateKind(dice, 4);
            case Options.TWOPAIR:
                return CalculateDoubleKind(dice);
            case Options.FULL:
                return CalculateFullKind(dice);
            case Options.SMALL:
                return CalculateSmallStraight(dice);
            case Options.LARGE:
                return CalculateLargeStraight(dice);
            case Options.YAHTZEE:
                return CalculateYahtzee(dice);
            }

            return 0;
        }

        public int CalculateYahtzee(IEnumerable<int> dice)
        {
            var consolidated = ConsolidateDice(dice);
            if (consolidated.Count == 1)
            {
                return 50;
            }

            return 0;
        }

        public int CalculateSmallStraight(IEnumerable<int> dice)
        {
            if (CalculateStraight(dice, 0))
            {
                return 15;
            }

            return 0;
        }

        public int CalculateLargeStraight(IEnumerable<int> dice)
        {
            if (CalculateStraight(dice, 1))
            {
                return 20;
            }

            return 0;
        }

        public bool CalculateStraight(IEnumerable<int> dice, int modifier)
        {
            var consolidated = ConsolidateDice(dice);
            var ordered = consolidated.OrderBy(x => x.Key);
            if (ordered.Count() == 5 && ordered.First().Key == (1 + modifier) && ordered.Last().Key == (5 + modifier))
            {
                return true;
            }

            return false;
        }

        public int CalculateFullKind(IEnumerable<int> dice)
        {
            var consolidated = ConsolidateDice(dice);
            var triple = consolidated.FirstOrDefault(x => x.Value == 3);
            var pair = consolidated.FirstOrDefault(x => x.Value == 2);
            if (pair.Key > 0 && triple.Key > 0)
            {
                return triple.Key * 3 + pair.Key * 2;
            }

            return 0;
        }

        public int CalculateDoubleKind(IEnumerable<int> dice)
        {
            var consolidated = ConsolidateDice(dice);
            var ordered = consolidated.Where(x => x.Value >= 2).OrderByDescending(x => x.Key);

            if (ordered.Count() > 1)
            {
                return (ordered.First().Key * 2) + (ordered.Skip(1).First().Key * 2);
            }

            return 0;
        }

        public int CalculateKind(IEnumerable<int>dice, int size)
        {
            var consolidated = ConsolidateDice(dice);
            var ordered = consolidated.Where(x => x.Value >= size).OrderByDescending(x => x.Key);
            if (ordered.Any())
            {
                var biggerNumber = ordered.First();
                return biggerNumber.Key * size;
            }

            return 0;
        }

        public int CalculateSimpleNumbers(IEnumerable<int> dice, int die)
        {
            var consolidated = ConsolidateDice(dice);
            if (consolidated.ContainsKey(die))
            {
                return die * consolidated[die];
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

                consolidated[die] += 1;
            }

            return consolidated;
        }
    }
}

