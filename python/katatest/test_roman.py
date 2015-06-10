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

    @parameterized.expand([
        (1, "C"),
        (2, "CC"),
        (3, "CCC"),
        (4, "CD"),
        (5, "D"),
        (6, "DC"),
        (7, "DCC"),
        (8, "DCCC"),
        (9, "CM")
        ])
    def test_hundreds(self, number, expected):
        result = romans.convert_hundreds(number)
        self.assertEqual(result, expected)

    @parameterized.expand([
        (1, "M"),
        (2, "MM"),
        (3, "MMM"),
        ])
    def test_thousands(self, number, expected):
        result = romans.convert_thousands(number)
        self.assertEqual(result, expected)

    @parameterized.expand([
        (156, "CLVI"),
        (2321, "MMCCCXXI"),
        (3067, "MMMLXVII"),
        ])
    def test_conver_to_roman(self, number, expected):
        result = romans.convert_to_roman(number)
        self.assertEqual(result, expected)
