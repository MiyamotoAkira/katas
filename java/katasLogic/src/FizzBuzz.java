/**
 * Created by akira on 22/06/15.
 */
public class FizzBuzz {
    public String ConvertNumber(int i) {
        if (i % 3 == 0 && i % 5 == 0)
        {
            return "FizzBuzz";
        }
        else if (i% 3 == 0)
        {
            return "Fizz";
        }
        else if (i % 5 == 0)
        {
            return "Buzz";
        }

        return String.valueOf(i);
    }

    public String GetNumbers(int numberOfNumbers) {
        String result = "";
        for (int currentNumber = 1; currentNumber <= numberOfNumbers; currentNumber++) {
            result += ConvertNumber(currentNumber) + " ";
        }

        return result.substring(0, result.length() - 1);
    }
}
