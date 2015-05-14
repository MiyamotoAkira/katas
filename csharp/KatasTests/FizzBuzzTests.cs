using System;
using NUnit.Framework;
using katasAlgorithms;
using FluentAssertions;

namespace KatasTests
{
    [TestFixture]
    [Category("Unit")]
    public class FizzBuzzTests
    {
        public FizzBuzzTests ()
        {
        }

        [Test]
        [TestCase(1, "1")]
        [TestCase(3, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(6, "Fizz")]
        [TestCase(10, "Buzz")]
        [TestCase(15, "FizzBuzz")]
        public void SingleNumber_ANumberIsPassed_ExpectedLiteral(int number, string literal)
        {
            var fizzBuzz = new FizzBuzz ();
            var result = fizzBuzz.ConvertSingle(number);
            result.Should().Be(literal);
        }

        [Test]
        public void Run() 
        {
            var fizzBuzz = new FizzBuzz ();
            var result = fizzBuzz.Run(15);
            result.Should().Be("1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz");
        }
    }
}

