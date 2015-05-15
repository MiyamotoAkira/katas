using System;
using System.Collections.Generic;

namespace katasAlgorithms
{
    public class FizzBuzz
    {
        public bool DivisibleBy5(int number)
        {
            return number % 5 == 0;
        }

        public bool DivisibleBy3(int number)
        {
            return number % 3 == 0;
        }

        public string ConvertSingle(int number)
        {
            if (DivisibleBy3(number) && DivisibleBy5(number))
            {
                return "FizzBuzz";
            }

            if (DivisibleBy3(number))
            {
                return "Fizz";
            }

            if (DivisibleBy5(number))
            {
                return "Buzz";
            }

            return number.ToString();
        }

        public string Run(int numberOfIterations)
        {
            List<string> results = new List<string>();
            for (int counter = 1; counter <= numberOfIterations; counter++)
            {
                results.Add(ConvertSingle(counter));
            }

            return String.Join(" ", results);
        }
    }
}

