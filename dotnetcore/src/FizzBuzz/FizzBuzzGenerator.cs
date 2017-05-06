using System;

namespace FizzBuzz
{
    public class FizzBuzzGenerator
    {
		public string FizzBuzzSingle(int number)
		{
			var answer = "";
			if (number % 3 == 0)
				answer += "Fizz";
			if (number % 5 == 0)
				answer += "Buzz";
			if (string.IsNullOrWhiteSpace(answer))
				answer = number.ToString();
			return answer;
		}
    }
}
