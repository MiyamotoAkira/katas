import unittest
from code import fizzbuzz

class FizzBuzzTest(unittest.TestCase):
    def test_single_one(self):
        result = fizzbuzz.single_one(1)
        self.assertEqual(result, "1")
            
