import org.junit.Test;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.PrintWriter;
import static org.junit.Assert.*;


public class Sudoku_Tests {
	
	@Test
	public void create_board_tests() throws FileNotFoundException{
		Sudoku_Class.clear_save();
		Sudoku_Class game = new Sudoku_Class();
		int[][] answer = game.get_answer_board();
		game = new Sudoku_Class(answer);
		int[][] val_board = game.validBoard();
		boolean val = true;
		for(int i = 0; i < val_board.length; i++){
			for(int j = 0; j < val_board[i].length; j++){
				if(val_board[i][j] == -1){
					val = false;
				}
			}
		}
		assertTrue(val);
	}
	
	@Test
	public void win_tests() throws FileNotFoundException{
		int[][] input = {{5,3,4,6,7,8,9,1,2},{6,7,2,1,9,5,3,4,8},{1,9,8,3,4,2,5,6,7},{8,5,9,7,6,1,4,2,3},{4,2,6,8,5,3,7,9,1},{7,1,3,9,2,4,8,5,6},{9,6,1,5,3,7,2,8,4},{2,8,7,4,1,9,6,3,5},{3,4,5,2,8,6,1,7,9}};
		Sudoku_Class game = new Sudoku_Class(input);
		boolean expected = true;
		boolean output = game.win();
		assertEquals(expected, output);
		
		expected = false;
		input[0][0] = 1;
		game = new Sudoku_Class(input);
		output = game.win();
		assertEquals(expected, output);
	}
	
	@Test
	public void clear_save_tests() throws FileNotFoundException{
		//test1 uses all 1's
		int[][] input = new int[9][9];
		for(int i = 0; i < input.length; i++){
			for(int j = 0; j < input[i].length; j++){
				input[i][j] = 1;
			}
		}
		Sudoku_Class game = new Sudoku_Class(input);
		game.save();
		game.clear_save();
		File f = new File("save_file.txt");
		int[][] output = game.read_file(f);
		int[][] expected = new int[9][9];
		assertArrayEquals(expected, output);
		
		//test2 has permanent squares,i.e. negative numbers
		input[8][8] = -1;
		game = new Sudoku_Class(input);
		game.save();
		game.clear_save();
		output = game.read_file(f);
		assertArrayEquals(expected, output);
	}
	
	@Test
	public void save_tests() throws FileNotFoundException{
		//test1 uses all 1's
		int[][] input = new int[9][9];
		for(int i = 0; i < input.length; i++){
			for(int j = 0; j < input[i].length; j++){
				input[i][j] = 1;
			}
		}
		Sudoku_Class game = new Sudoku_Class(input);
		game.save();
		File f = new File("save_file.txt");
		int[][] output = game.read_file(f);
		assertArrayEquals(input, output);
		
		//test2 has permanent squares,i.e. negative numbers
		input[8][8] = -1;
		game = new Sudoku_Class(input);
		game.save();
		output = game.read_file(f);
		assertArrayEquals(input, output);
	}
	
	@Test
	public void read_file_tests() throws IOException{
		File f = new File("test_file.txt");
		PrintWriter write = new PrintWriter(f);
		write.close();
		
		//test1 has a blank file
		int[][] expected = new int[9][9];
		f = new File("test_file.txt");
		int[][] output = Sudoku_Class.read_file(f);
		assertArrayEquals(expected, output);
		
		//test2 has a file with all 1's
		f = new File("test_file.txt");
		write = new PrintWriter(f);
		for(int i = 0; i < 89; i++){
			write.print("1 ");
		}
		for(int i = 0; i < 9; i++){
			for(int j = 0; j < 9; j++){
				expected[i][j] = 1;
			}
		}
		write.close();
		output = Sudoku_Class.read_file(f);
		assertArrayEquals(expected, output);
		
		
		
		//test3 has a file with a permanent space, i.e. a negative value
		write = new PrintWriter(f);
		expected[8][8] = -1;
		for(int i = 0; i < 80; i++){
			write.write("1 ");
		}
		write.print("-1 ");
		write.close();
		output = Sudoku_Class.read_file(f);
		assertArrayEquals(expected, output);
		
		write = new PrintWriter(f);
		write.close();
	}
	
	
	@Test
	public void clear_entries_tests(){
		//Test 1 has no permanent spaces
		String expected = "0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0";
		int[][] input = {{5,3,4,6,7,8,9,1,2},{6,7,2,1,9,5,3,4,8},{1,9,8,3,4,2,5,6,7},{8,5,9,7,6,1,4,2,3},{4,2,6,8,5,3,4,9,1},{7,1,3,9,2,4,8,5,6},{9,6,1,5,3,7,2,8,4},{2,8,7,4,1,9,6,3,5},{3,4,5,2,8,6,1,7,9}};
		Sudoku_Class game = new Sudoku_Class(input);
		game.clear_entries();
		String output = game.convert_board_to_string();
		assertEquals(expected, output);
		
		//Test2 has a permanent space
		expected = "[5]| 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0";
		input[0][0] = -5;
		game = new Sudoku_Class(input);
		game.clear_entries();
		output = game.convert_board_to_string();
		assertEquals(expected, output);
	}
	
	@Test
	public void is_permanent_square_tests(){
		boolean expected = false;
		int[][] input = {{5,3,4,6,7,8,9,1,2},{6,7,2,1,9,5,3,4,8},{1,9,8,3,4,2,5,6,7},{8,5,9,7,6,1,4,2,3},{4,2,6,8,5,3,4,9,1},{7,1,3,9,2,4,8,5,6},{9,6,1,5,3,7,2,8,4},{2,8,7,4,1,9,6,3,5},{3,4,5,2,8,6,1,7,9}};
		Sudoku_Class game = new Sudoku_Class(input);
		boolean output = game.is_permanent_square(0, 0);
		assertEquals(expected, output);
		
		input[0][0] = -5;
		expected = true;
		game = new Sudoku_Class(input);
		output = game.is_permanent_square(0, 0);
		assertEquals(expected, output);
	}
	
	@Test
	public void validate_3x3_area_tests(){
		//test1 checks using a correct sudoku board
		int[][] expected = {{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0}};
		int[][] input = {{5,3,4,6,7,8,9,1,2},{6,7,2,1,9,5,3,4,8},{1,9,8,3,4,2,5,6,7},{8,5,9,7,6,1,4,2,3},{4,2,6,8,5,3,7,9,1},{7,1,3,9,2,4,8,5,6},{9,6,1,5,3,7,2,8,4},{2,8,7,4,1,9,6,3,5},{3,4,5,2,8,6,1,7,9}};
		Sudoku_Class game = new Sudoku_Class(input);
		int[][] output = game.validate_3x3_area();
		assertArrayEquals(expected, output);
		
		//test2 checks using an incorrect sudoku board
		expected[0][0] = 1;
		expected[2][0] = 1;
		input[0][0] = 1;
		game = new Sudoku_Class(input);
		output = game.validate_3x3_area();
		assertArrayEquals(expected, output);
		
		//test3 checks using a board with a permanent square
		input[0][0] = -1;
		game = new Sudoku_Class(input);
		output = game.validate_3x3_area();
		assertArrayEquals(expected, output);
		
	}

	@Test
	public void create_sudoku_class_with_input_tests(){
		int[][] expected = {{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0}};;
		int[][] input = {{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0}};
		Sudoku_Class game = new Sudoku_Class(input);
		int[][] output = game.get_board();
		assertArrayEquals(expected, output);

	}
	
//	public static void create_sudoku_class_no_input_tests() throws FileNotFoundException{
//		int[][] expected = new int[9][9];
//		Sudoku_Class game = new Sudoku_Class();
//		int[][] output = game.get_board();
//		if(Arrays.deepEquals(expected, output)){
//			System.out.println("sudoku_class() worked");
//		}else{
//			System.out.println("sudoku_class() failed");
//			System.out.println("Expected: \n" + expected);
//			System.out.println("Output: \n" + output);
//		}
//	}
	
	@Test
	public void print_board_tests(){
		String expected = "0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0";
		int[][] input = {{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0}};
		Sudoku_Class game = new Sudoku_Class(input);
		String output = game.convert_board_to_string();
		assertEquals(expected, output);
		
		input[0][0] = -5;
		expected = "[5]| 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0";
		game = new Sudoku_Class(input);
		output = game.convert_board_to_string();
		assertEquals(expected, output);
	}

    @Test
    public void testValidAllRowsAndCols0() {
        int[][] testBoard = new int[9][9];
        int[][] expected = new int[9][9];
        for (int i = 0; i < 9; i++) {
            for (int j = 0; j < 9; j++) {
                testBoard[i][j] = (i + j) % 9 + 1;
            }
        }
        Sudoku_Class game = new Sudoku_Class(testBoard);
        assertArrayEquals(expected, game.validAllRowsAndCols());
    }

    @Test
    public void testValidAllRowsAndCols1() {
        int[][] testBoard = {   {1, 0, 1, 0, 0, 0, 0, 0, 0},
                                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                                {0, 0, -1, 0, 0, 0, 0, 0, 0},
                                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                                {0, 0, 6, -6, 0, 0, 0, 0, 0},
                                {0, 0, 9, 0, 9, 0, 0, 0, 0},
                                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                                {0, 0, 6, 0, 0, 0, 0, 3, 0},
                                {0, 0, 3, 0, 0, 0, 0, 0, 3}};
        int[][] expected = {    {1, 0, 1, 0, 0, 0, 0, 0, 0},
                                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                                {0, 0, 1, 0, 0, 0, 0, 0, 0},
                                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                                {0, 0, 1, 1, 0, 0, 0, 0, 0},
                                {0, 0, 1, 0, 1, 0, 0, 0, 0},
                                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                                {0, 0, 1, 0, 0, 0, 0, 0, 0},
                                {0, 0, 1, 0, 0, 0, 0, 0, 1}};
        Sudoku_Class game = new Sudoku_Class(testBoard);
        assertArrayEquals(expected, game.validAllRowsAndCols());
    }

    @Test
    public void testValidBoard0() {
        int[][] testBoard = new int[9][9];
        int[][] expected = new int[9][9];
        for (int i = 0; i < 9; i++) {
            for (int j = 0; j < 9; j++) {
                testBoard[i][j] = 1;
                testBoard[i][j] *= Math.random() < .5 ? -1 : 1;
                expected[i][j] = 1;
            }
        }
        Sudoku_Class game = new Sudoku_Class(testBoard);
        assertArrayEquals(expected, game.validBoard());
    }

    @Test
    public void testValidBoard1() {
        int[][] testBoard = {   {1, 0, 1, -5, 0, 0, -6, 6, -6},
                                {0, -4, 0, 0, 5, 0, 6, -6, 6},
                                {4, 0, -1, 0, 0, 0, 5, 6, 0},
                                {0, 0, 0, 0, 0, 5, 8, 0, 0},
                                {0, 0, 6, -6, 0, 0, 0, -8, 5},
                                {0, 0, 9, 0, 9, 0, 0, 0, -8},
                                {0, -2, 0, 0, 0, 7, 0, 0, 0},
                                {2, 0, 6, 0, 7, 0, 0, -3, 0},
                                {0, 0, 3, -7, 0, 0, 0, 0, 3}};
        int[][] expected = {    {1, 0, 1, 1, 0, 0, 1, 1, 1},
                                {0, 1, 0, 0, 1, 0, 1, 1, 1},
                                {1, 0, 1, 0, 0, 0, 0, 1, 0},
                                {0, 0, 0, 0, 0, 0, 1, 0, 0},
                                {0, 0, 1, 1, 0, 0, 0, 1, 0},
                                {0, 0, 1, 0, 1, 0, 0, 0, 1},
                                {0, 1, 0, 0, 0, 1, 0, 0, 0},
                                {1, 0, 1, 0, 1, 0, 0, 1, 0},
                                {0, 0, 1, 1, 0, 0, 0, 0, 1}};
        Sudoku_Class game = new Sudoku_Class(testBoard);
        assertArrayEquals(expected, game.validBoard());
    }

    @Test
    public void testSetSquare0() {
        int[][] testBoard = new int[9][9];
        testBoard[0][0] = -1;
        testBoard[0][1] = 1;
        Sudoku_Class game = new Sudoku_Class(testBoard);
        assertEquals(false, game.setSquare(0,0, 3));
        assertEquals(false, game.setSquare(0,0, 0));
        assertEquals(true, game.setSquare(0,1, 3));
        assertEquals(true, game.setSquare(0,1, 0));
        assertEquals(false, game.setSquare(0,1, -3));
        assertEquals(false, game.setSquare(0,2, 13));
        assertEquals(false, game.setSquare(0,2, -2));
        assertEquals(false, game.setSquare(0,-1, 5));
        assertEquals(false, game.setSquare(13,0, -2));
        assertEquals(true, game.setSquare(8,0, 9));
    }
}
