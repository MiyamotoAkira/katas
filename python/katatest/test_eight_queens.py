import unittest
from code import eight_queens


class EightQueenTests(unittest.TestCase):
    def test_add_queen_to_square(self):
        eightQueen = eight_queens.EightQueen()
        eightQueen.add_queen_to_square((1, 1))
        table = eightQueen.get_table()
        self.assertEqual(table, {1: 1})

    def test_add_queen_to_square_doesnot_add_twice_to_row(self):
        eightQueen = eight_queens.EightQueen()
        eightQueen.add_queen_to_square((1, 1))
        inserted = eightQueen.add_queen_to_square((1, 3))
        self.assertFalse(inserted)
        table = eightQueen.get_table()
        self.assertEqual(table, {1: 1})

    def test_remove_queen(self):
        eightQueen = eight_queens.EightQueen()
        eightQueen.add_queen_to_square((1, 1))
        eightQueen.undo_last_queen()
        table = eightQueen.get_table()
        self.assertEqual(table, {})

    def test_find_next_square(self):
        eightQueen = eight_queens.EightQueen()
        eightQueen.add_queen_to_square((1, 1))
        eightQueen.setup_possibilities()
        square = eightQueen.find_next_square()
        self.assertEqual(square, (2, 3))

    def test_create_board_has_64_squares(self):
        eightQueen = eight_queens.EightQueen()
        self.assertEqual(len(eightQueen.board), 64)

    def test_eliminate_possibilities(self):
        eightQueen = eight_queens.EightQueen()
        eightQueen.add_queen_to_square((1, 1))
        self.assertTrue(len(eightQueen.board), 42)

    def test_undo_last_queen(self):
        eightQueen = eight_queens.EightQueen()
        eightQueen.add_queen_to_square((1, 1))
        eightQueen.setup_possibilities()
        square = eightQueen.find_next_square()
        eightQueen.add_queen_to_square(square)
        eightQueen.setup_possibilities()
        self.assertEqual(eightQueen.table, {1: 1, 2: 3})
        eightQueen.undo_last_queen()
        self.assertEqual(len(eightQueen.board), 42)
        self.assertEqual(eightQueen.table, {1: 1})

    def test_go_next_option(self):
        eightQueen = eight_queens.EightQueen()
        eightQueen.setup_possibilities()
        square = eightQueen.find_next_square()
        self.assertEqual(square, (1, 1))
        square = eightQueen.find_next_square()
        self.assertEqual(square, (1, 2))

    def test_go_next_option_no_option_left_returns_None(self):
        eightQueen = eight_queens.EightQueen()
        eightQueen.sorted_possibilities = [(1, 1)]
        eightQueen.last_possibility = 0
        square = eightQueen.find_next_square()
        self.assertEqual(square, None)

    def test_resolve_one(self):
        eightQueen = eight_queens.EightQueen()
        solution = eightQueen.resolve_one()
        self.assertEqual(solution,
                         {1: 1, 2: 5, 3: 8, 4: 6, 5: 3, 6: 7, 7: 2, 8: 4})
