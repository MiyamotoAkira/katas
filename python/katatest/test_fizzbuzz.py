import unittest
from nose_parameterized import parameterized
from code import fizzbuzz


class FizzBuzzTest(unittest.TestCase):
    @parameterized.expand([
        (1, "1"),
        (3, "Fizz"),
        (6, "Fizz"),
        (5, "Buzz"),
        (10, "Buzz"),
        (15, "FizzBuzz")
        ])
    def test_single_one(self, number, expected):
        result = fizzbuzz.single_one(number)
        self.assertEqual(result, expected)

    def test_fizz_buzz(self):
        result = fizzbuzz.fizz_buzz(20)
        self.assertEqual(result, "1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz" +
                         " 11 Fizz 13 14 FizzBuzz 16 17 Fizz 19 Buzz")
