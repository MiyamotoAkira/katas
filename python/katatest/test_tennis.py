import unittest
from nose_parameterized import parameterized
from code import tennis

class TestTennis(unittest.TestCase):
    def test_gameStarts_gameisalllove(self):
        game = tennis.Game()
        self.assertEqual(game.Player1Score, 0)
        self.assertEqual(game.Player2Score, 0)
        
    def test_player1Scores_gameisalllove_player1hasonepoint(self):
        game = tennis.Game()
        game.score_by_player1()
        self.assertEqual(game.Player1Score, 1)
        self.assertEqual(game.Player2Score, 0)

    def test_player2Scores_gameisalllove_player2hasonepoint(self):
        game = tennis.Game()
        game.score_by_player2()
        self.assertEqual(game.Player1Score, 0)
        self.assertEqual(game.Player2Score, 1)

    def test_calculate_if_game_is_finished_game_is_all_love(self):
        game = tennis.Game()
        self.assertFalse(game.is_game_finished())

    @parameterized.expand([
        (0, 0, False),
        (4, 3, False),
        (4, 4, False),
        (6, 4, True),
        (2, 6, True),
        (6, 5, False),
        (8, 10, True),
        (5, 3, True)
    ])
    def test_calculate_if_game_is_finished(self, player1_score, player2_score, expected):
        game = tennis.Game(player1_score, player2_score)
        self.assertEqual(game.is_game_finished(), expected)

    @parameterized.expand([
        (6, 4, 1),
        (4, 6, 2),
        (4, 5, 0)
        ])
    def test_who_won(self, player1_score, player2_score, result):
        game = tennis.Game(player1_score, player2_score)
        self.assertEqual(game.who_won(), result)

    @parameterized.expand([
        (0, 0, "All Love"),
        (1, 0, "Fifteen - Love"),
        (2, 3, "Thirty - Forty"),
        (3, 3, "Deuce"),
        (4, 3, "Advantage Player 1"),
        (5, 6, "Advantage Player 2"),
        (5, 3, "Game Finished. Player 1 won"),
        (6, 8, "Game Finished. Player 2 won")
        ])
    def test_get_current_result(self, player1_score, player2_score, expected):
        game = tennis.Game(player1_score, player2_score)
        self.assertEqual(game.get_current_result(), expected)
