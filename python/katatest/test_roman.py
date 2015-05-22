import unittest
from nose_parameterized import parameterized
from code import romans

class RomanTests(unittest.TestCase):
    @parameterized.expand([
        (1, "I"),
        (2, "II"),
        (3, "III"),
        (4, "IV"),
        (5, "V"),
        (6, "VI"),
        (7, "VII"),
        (8, "VIII"),
        (9, "IX")
        ])
    def test_ones(self, number, expected):
        result = romans.convert_ones(number)
        self.assertEqual(result, expected)

        
    @parameterized.expand([
        (1, "X"),
        (2, "XX"),
        (3, "XXX"),
        (4, "XL"),
        (5, "L"),
        (6, "LX"),
        (7, "LXX"),
        (8, "LXXX"),
        (9, "XC")
        ])
    def test_tens(self, number, expected):
        result = romans.convert_tens(number)
        self.assertEqual(result, expected)
