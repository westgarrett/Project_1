import org.junit.Test;

import java.util.Arrays;

import static org.junit.Assert.assertArrayEquals;


public class Tests {

	public static void main(String[] args) {
		create_sudoku_class_no_input_tests();
		create_sudoku_class_with_input_tests();
		print_board_tests();

	}
	
	public static void create_sudoku_class_with_input_tests(){
		int[][] expected = {{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0}};;
		int[][] input = {{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0}};
		Sudoku_Class game = new Sudoku_Class(input);
		int[][] output = game.get_board();
		if(Arrays.deepEquals(expected, output)){
			System.out.println("sudoku_class(input) worked");
		}else{
			System.out.println("sudoku_class(input) failed");
			System.out.println("Expected: \n" + expected);
			System.out.println("Output: \n" + output);
		}

	}
	
	public static void create_sudoku_class_no_input_tests(){
		int[][] expected = new int[9][9];
		Sudoku_Class game = new Sudoku_Class();
		int[][] output = game.get_board();
		if(Arrays.deepEquals(expected, output)){
			System.out.println("sudoku_class() worked");
		}else{
			System.out.println("sudoku_class() failed");
			System.out.println("Expected: \n" + expected);
			System.out.println("Output: \n" + output);
		}
	}
	
	public static void print_board_tests(){
		String expected = "0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0";
		int[][] input = {{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0}};
		Sudoku_Class game = new Sudoku_Class(input);
		String output = game.convert_board_to_string();
		if(expected.equals(output)){
			System.out.println("convert_board_to_string() worked");
		}else{
			System.out.println("convert_board_to_string() failed");
			System.out.println("Expected: \n" + expected);
			System.out.println("Output: \n" + output);
		}
	}

	// Tests by Hoang
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
		assertArrayEquals(game.validAllRowsAndCols(), expected);
	}
}
