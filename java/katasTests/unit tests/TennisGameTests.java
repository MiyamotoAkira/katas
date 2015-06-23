import org.junit.Test;

import static org.hamcrest.CoreMatchers.is;
import static org.junit.Assert.assertThat;

/**
 * Created by akira on 23/06/15.
 */
public class TennisGameTests {

    @Test
    public void StartingGame_CurrentScoreShouldBeAllLove()
    {
        TennisGame tennisGame = new TennisGame();
        assertThat(tennisGame.CurrentScore(), is("All Love"));
    }

    @Test
    public void FirstPointInGameIsPlayer1_CurrentScoreShouldBe15Love()
    {
        TennisGame tennisGame = new TennisGame();
        tennisGame.Score(TennisGame.Player.Player1);
        assertThat(tennisGame.CurrentScore(), is("15-Love"));
    }

    @Test
    public void FirstPointInGameIsPlayer2_CurrentScoreShouldBeLove15()
    {
        TennisGame tennisGame = new TennisGame();
        tennisGame.Score(TennisGame.Player.Player2);
        assertThat(tennisGame.CurrentScore(), is("Love-15"));
    }
}
