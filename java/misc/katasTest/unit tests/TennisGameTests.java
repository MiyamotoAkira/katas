import org.junit.Test;

import static org.hamcrest.CoreMatchers.is;
import static org.junit.Assert.assertThat;

/**
 * Created by akira on 23/06/15.
 */
public class TennisGameTests {

    @Test
    public void StartingGame_CurrentScoreShouldBeAllLove() {
        TennisGame tennisGame = new TennisGame();
        assertThat(tennisGame.CurrentScore(), is("All Love"));
    }

    @Test
    public void FirstPointInGameIsPlayer1_CurrentScoreShouldBe15Love() {
        TennisGame tennisGame = new TennisGame();
        tennisGame.Score(TennisGame.Player.Player1);
        assertThat(tennisGame.CurrentScore(), is("15-Love"));
    }

    @Test
    public void FirstPointInGameIsPlayer2_CurrentScoreShouldBeLove15() {
        TennisGame tennisGame = new TennisGame();
        tennisGame.Score(TennisGame.Player.Player2);
        assertThat(tennisGame.CurrentScore(), is("Love-15"));
    }

    @Test
    public void GamePlayedTill4030() {
        TennisGame tennisGame = new TennisGame();
        tennisGame.Score(TennisGame.Player.Player1);
        tennisGame.Score(TennisGame.Player.Player1);
        tennisGame.Score(TennisGame.Player.Player1);
        tennisGame.Score(TennisGame.Player.Player2);
        tennisGame.Score(TennisGame.Player.Player2);
        assertThat(tennisGame.CurrentScore(), is("40-30"));
    }

    @Test
    public void GamePlayedUntilPlayer1Wins() {
        TennisGame tennisGame = new TennisGame();
        tennisGame.Score(TennisGame.Player.Player1);
        tennisGame.Score(TennisGame.Player.Player1);
        tennisGame.Score(TennisGame.Player.Player1);
        tennisGame.Score(TennisGame.Player.Player1);
        assertThat(tennisGame.CurrentScore(), is("Player1 Won"));
    }

    @Test
    public void GamePlayedUntilPlayer2Wins() {
        TennisGame tennisGame = new TennisGame();
        tennisGame.Score(TennisGame.Player.Player2);
        tennisGame.Score(TennisGame.Player.Player2);
        tennisGame.Score(TennisGame.Player.Player2);
        tennisGame.Score(TennisGame.Player.Player2);
        assertThat(tennisGame.CurrentScore(), is("Player2 Won"));
    }
}
