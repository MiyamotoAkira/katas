/**
 * Created by akira on 22/06/15.
 */

import static org.junit.Assert.assertThat;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.junit.runners.Parameterized;

import java.util.*;

import static org.hamcrest.CoreMatchers.is;

@RunWith(Parameterized.class)
public class FizzBuzzConvertNumberTests {

    private final int value;
    private final String expected;

    public FizzBuzzConvertNumberTests(int value, String expected)
    {
        this.value = value;
        this.expected = expected;
    }

    @Parameterized.Parameters
    public static Collection<Object[]> SetParameters ()
    {
        return Arrays.asList( new Object[][]{
                {1, "1"},
                {2, "2"},
                {3, "Fizz"},
                {4, "4"},
                {5, "Buzz"},
                {6, "Fizz"},
                {7, "7"},
                {9, "Fizz"},
                {10, "Buzz"},
                {15, "FizzBuzz"}
        });
    }

    @Test
    public void ConvertNumber()
    {
        FizzBuzz fizzBuzz = new FizzBuzz();
        String result = fizzBuzz.ConvertNumber(this.value);
        assertThat(result, is(this.expected));
    }
}
