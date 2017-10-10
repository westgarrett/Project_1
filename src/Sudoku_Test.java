import org.junit.Test;
import static org.junit.Assert.assertEquals;

public class Sudoku_Test {
	@Test
	public void test_board_to_string0(){
		String expected = "0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0";
		int[][] input = new int[9][9];
		String output = Sudoku_Game.convert_board_to_string(input);
		assertEquals(output, expected);
	}

    @Test
    public void testValidAllRowsAndCols0() {
        int[][] testBoard = new int[9][9];
        for (int i = 0; i < 9; i++) {
            for (int j = 0; j < 9; j++) {
                testBoard[i][j] = (i + j) % 9 + 1;
            }
        }
        assertEquals(Sudoku_Game.validAllRowsAndCols(testBoard), true);
    }
}
