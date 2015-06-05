class Game():
    def __init__(self, player1Score = 0, player2Score = 0):
        self.Player1Score = player1Score
        self.Player2Score = player2Score

    def score_by_player1(self):
        self.Player1Score += 1

    def score_by_player2(self):
        self.Player2Score += 1

    def is_game_finished(self):
        return self.player_in_range() and  self.diff_is_enough()

    def player_in_range(self):
        return self.Player1Score > 4 or self.Player2Score > 4

    def diff_is_enough(self):
        return abs(self.Player1Score - self.Player2Score) > 1

    def who_won(self):
        if self.is_game_finished():
            if self.Player1Score > self.Player2Score:
                return "player 1"
            else:
                return "player 2"
        else:
            return "still in play"
