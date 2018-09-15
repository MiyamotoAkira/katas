import org.junit.jupiter.api.Test

class AcceptanceTest {
    @Test
    fun `Where we pass data and expect data back` () {
        val result =
                marsrover
                        .world(10,10)
                        .initial(3,5,"N")
                        .commands("FLFRRFFR")
                        .location()

        assertThat(result).isEqualTo("4,6,S")
    }
}