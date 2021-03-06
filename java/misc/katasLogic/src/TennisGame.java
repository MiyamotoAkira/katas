/**
 * Created by akira on 23/06/15.
 */
public class TennisGame {
    private int player2Points;
    private int player1Points;

    public TennisGame() {
        player1Points = 0;
        player2Points = 0;
    }

    public void Score(Player player) {
        switch (player) {
            case Player1:
                player1Points += 1;
                break;
            case Player2:
                player2Points += 1;
                break;
        }

    }

    public enum Player {
        Player1,
        Player2
    }

    public String CurrentScore() {
        if (player1Points == 0 && player2Points == 0) {
            return "All Love";
        }

        if (player1Points > 3)
        {
            return "Player1 Won";
        }

        if (player2Points > 3)
        {
            return "Player2 Won";
        }


        String result = GetPlayerPointsAsString(player1Points);
        result += "-";
        result += GetPlayerPointsAsString(player2Points);
        return result;
    }

    private String GetPlayerPointsAsString(int playerPoints) {
        switch (playerPoints)
        {
            case 0:
                return "Love";
            case 1:
                return "15";
            case 2:
                return "30";
            case 3:
                return "40";
            default:
                return "Not Implemented";
        }
    }
}
