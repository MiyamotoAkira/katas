using System;
using NUnit.Framework;
using System.Collections.Generic;
using FluentAssertions;
using katasAlgorithms;

namespace KatasTests
{
    [TestFixture]
    [Category("Unit")]
    public class YahtzeeTests
    {
        [Test]
        public void ConsolidateDice()
        {
            Yahtzee yahtzee = new Yahtzee();
            var result = yahtzee.ConsolidateDice(new List<int> { 1, 4, 4, 3, 3 });
            result[1].Should().Be(1);
            result[4].Should().Be(2);
            result[3].Should().Be(2);
        }

        [Test]
        public void CalculateRoll()
        {
            Yahtzee yahtzee = new Yahtzee();
            foreach (TestCase testCase in SetTestCases())
            {
                var result = yahtzee.CalculateRoll(testCase.Dice, testCase.OptionChosen);
                result.Should().Be(
                    testCase.Expected, 
                    "For Dice {0}, on option {1} the expected result is {2}", 
                    testCase.Dice.ToString(), 
                    testCase.OptionChosen, 
                    testCase.Expected);
            }
        }

        public IEnumerable<TestCase> SetTestCases()
        {
            List<TestCase> testCases = new List<TestCase>();            
            testCases.Add(new TestCase(new List<int>{ 1, 3, 2, 2, 5 }, Options.ONES, 1));
            testCases.Add(new TestCase(new List<int>{ 1, 3, 2, 2, 5 }, Options.TWOS, 4));
            testCases.Add(new TestCase(new List<int>{ 3, 3, 3, 3, 5 }, Options.THREES, 12));
            testCases.Add(new TestCase(new List<int>{ 4, 3, 4, 3, 5 }, Options.FOURS, 8));
            testCases.Add(new TestCase(new List<int>{ 4, 3, 4, 3, 5 }, Options.FIVES, 5));
            testCases.Add(new TestCase(new List<int>{ 4, 3, 4, 3, 5 }, Options.SIXES, 0));
            testCases.Add(new TestCase(new List<int>{ 6, 6, 6, 3, 5 }, Options.SIXES, 18));
            testCases.Add(new TestCase(new List<int>{ 2, 3, 2, 2, 5 }, Options.PAIR, 4));
            testCases.Add(new TestCase(new List<int>{ 2, 3, 2, 2, 5 }, Options.THREEKIND, 6));
            testCases.Add(new TestCase(new List<int>{ 2, 3, 2, 2, 2 }, Options.FOURKIND, 8));
            testCases.Add(new TestCase(new List<int>{ 1, 3, 2, 2, 2 }, Options.FOURKIND, 0));
            testCases.Add(new TestCase(new List<int>{ 2, 3, 4, 1, 5 }, Options.FOURKIND, 0));
            testCases.Add(new TestCase(new List<int>{ 2, 3, 3, 2, 2 }, Options.TWOPAIR, 10));
            testCases.Add(new TestCase(new List<int>{ 2, 3, 3, 2, 2 }, Options.FULL, 12));
            testCases.Add(new TestCase(new List<int>{ 2, 3, 3, 2, 4 }, Options.FULL, 0));
            testCases.Add(new TestCase(new List<int>{ 2, 3, 3, 1, 4 }, Options.TWOPAIR, 0));
            testCases.Add(new TestCase(new List<int>{ 1, 2, 3, 4, 5 }, Options.SMALL, 15));
            testCases.Add(new TestCase(new List<int>{ 1, 2, 3, 4, 4 }, Options.SMALL, 0));
            testCases.Add(new TestCase(new List<int>{ 2, 3, 4, 5, 6 }, Options.LARGE, 20));
            testCases.Add(new TestCase(new List<int>{ 2, 3, 4, 5, 1 }, Options.LARGE, 0));
            testCases.Add(new TestCase(new List<int>{ 2, 3, 4, 5, 1 }, Options.YAHTZEE, 0));
            testCases.Add(new TestCase(new List<int>{ 2, 2, 2, 2, 2 }, Options.YAHTZEE, 50));
            return testCases;
        }
    }

    public struct TestCase
    {
        public List<int> Dice;
        public Options OptionChosen;
        public int Expected;

        public TestCase(List<int> dice, Options option, int expected)
        {
            Dice = dice;
            OptionChosen = option;
            Expected = expected;
        }
    }
}

