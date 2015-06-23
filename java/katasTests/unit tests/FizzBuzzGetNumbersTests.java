import org.junit.Test;

import static org.hamcrest.CoreMatchers.is;
import static org.junit.Assert.assertThat;

/**
 * Created by akira on 23/06/15.
 */
public class FizzBuzzGetNumbersTests {
    @Test
    public void GetNumbers ()
    {
        FizzBuzz fizzBuzz = new FizzBuzz();
        String result = fizzBuzz.GetNumbers(15);
        assertThat(result, is ("1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz"));
    }
}
