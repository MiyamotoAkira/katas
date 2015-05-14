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
            result [1].Should().Be(1);
            result [4].Should().Be(2);
            result [3].Should().Be(2);
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

