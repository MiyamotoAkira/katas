class Game():
    def __init__(self, player1Score=0, player2Score=0):
        self.Player1Score = player1Score
        self.Player2Score = player2Score

    def score_by_player1(self):
        self.Player1Score += 1

    def score_by_player2(self):
        self.Player2Score += 1

    def is_game_finished(self):
        return self.player_in_range() and self.diff_is_enough()

    def player_in_range(self):
        return self.Player1Score > 3 or self.Player2Score > 3

    def diff_is_enough(self):
        return abs(self.Player1Score - self.Player2Score) > 1

    def who_won(self):
        if self.is_game_finished():
            if self.Player1Score > self.Player2Score:
                return 1
            else:
                return 2
        else:
            return 0

    def get_current_result(self):
        if self.is_game_finished():
            if self.who_won() == 1:
                return "Game Finished. Player 1 won"
            elif self.who_won() == 2:
                return "Game Finished. Player 2 won"
        else:
            if self.both_players_in_deuce_range():
                if self.Player1Score > self.Player2Score:
                    return "Advantage Player 1"
                elif self.Player2Score > self.Player1Score:
                    return "Advantage Player 2"
                else:
                    return "Deuce"
            elif self.Player1Score == 0 and self.Player2Score == 0:
                return "All Love"
            else:
                result_player1 = self.get_result_player(self.Player1Score)
                result_player2 = self.get_result_player(self.Player2Score)
                return result_player1 + " - " + result_player2

    def both_players_in_deuce_range(self):
        return self.Player1Score > 2 and self.Player2Score > 2

    def get_result_player(self, player_score):
        if player_score == 0:
            return "Love"
        elif player_score == 1:
            return "Fifteen"
        elif player_score == 2:
            return "Thirty"
        elif player_score == 3:
            return "Forty"
