using System;
using System.Collections.Generic;
using Xunit;
using FizzBuzz;

namespace FizzBuzzTests
{
    public class FizzBuzzTest
    {
        [Theory]
        [MemberData("Fives")]
        public void FizzBuzzSingle_WhenAskingForAMultipleFive_ShouldReturnBuzz(int number)
        {
            var generator = new FizzBuzzGenerator();
            Assert.Equal("Buzz", generator.FizzBuzzSingle(number));
        }

        public static IEnumerable<object[]> Fives
        {
            get
            {
                yield return new object[] { 5 };
                yield return new object[] { 10 };
                yield return new object[] { 20 };
                yield return new object[] { 25 };
            }
        }

        [Theory]
        [MemberData("Threes")]
        public void FizzBuzzSingle_WhenAskingForAMultipleOfThree_ShouldReturnFizz(int number)
        {
            var generator = new FizzBuzzGenerator();
            Assert.Equal("Fizz", generator.FizzBuzzSingle(number));
        }

        public static IEnumerable<object[]> Threes
        {
            get
            {
                yield return new object[] { 3 };
                yield return new object[] { 6 };
                yield return new object[] { 9 };
                yield return new object[] { 12 };
            }
        }

        [Theory]
        [MemberData("ThreesAndFives")]
        public void FizzBuzzSingle_WhenAskingForAMultipleOfThreeAndFive_ShouldReturnFizzBuzz(int number)
        {
            var generator = new FizzBuzzGenerator();
            Assert.Equal("FizzBuzz", generator.FizzBuzzSingle(number));
        }

        public static IEnumerable<object[]> ThreesAndFives
        {
            get
            {
                yield return new object[] { 15 };
                yield return new object[] { 30 };
                yield return new object[] { 45 };
            }
        }

        [Theory]
        [MemberData("Others")]
        public void FizzBuzzSingle_WhenAskingForNonMultiplesOfThreeOrFive_ShouldReturnNumber(int number)
        {
            var generator = new FizzBuzzGenerator();
            Assert.Equal(number.ToString(), generator.FizzBuzzSingle(number));
        }

        public static IEnumerable<object[]> Others
        {
            get
            {
                yield return new object[] { 1 };
                yield return new object[] { 2 };
                yield return new object[] { 4 };
                yield return new object[] { 7 };
                yield return new object[] { 8 };
            }
        }
    }
}
