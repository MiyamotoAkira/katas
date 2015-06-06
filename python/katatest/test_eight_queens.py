import unittest
from code import eight_queens

class EightQueenTests(unittest.TestCase):
    def test_add_queen_to_square(self):
        eightQueen = eight_queens.EightQueen()
        eightQueen.add_queen_to_square((1,1))
        table = eightQueen.get_table()
        self.assertEqual(table,{1:1})

    def test_add_queen_to_square_doesnot_add_twice_to_row(self):
        eightQueen = eight_queens.EightQueen()
        eightQueen.add_queen_to_square((1,1))
        inserted = eightQueen.add_queen_to_square((1,3))
        self.assertFalse(inserted)
        table = eightQueen.get_table()
        self.assertEqual(table,{1:1})

    def test_remove_queen(self):
        eightQueen = eight_queens.EightQueen()
        eightQueen.add_queen_to_square((1,1))
        eightQueen.remove_queen((1,1))
        table = eightQueen.get_table()
        self.assertEqual(table,{})

    def test_find_next_square(self):
        eightQueen = eight_queens.EightQueen()
        eightQueen.add_queen_to_square((1,1))
        square= eightQueen.find_next_square()
        self.assertEqual(square,{1:3})
