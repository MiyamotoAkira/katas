using System;
using System.Collections.Generic;

namespace katasAlgorithms
{
    public class FizzBuzz
    {
        public string ConvertSingle(int number)
        {
            if (number % 3 == 0 && number % 5 == 0)
            {
                return "FizzBuzz";
            }

            if (number % 3 == 0)
            {
                return "Fizz";
            }

            if (number % 5 == 0)
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

