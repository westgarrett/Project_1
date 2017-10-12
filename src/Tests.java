import org.junit.Test;

import java.util.Arrays;

import static org.junit.Assert.assertArrayEquals;


public class Tests {

	public static void main(String[] args) {
		create_sudoku_class_no_input_tests();
		create_sudoku_class_with_input_tests();
		print_board_tests();
		validate_3x3_area_tests();
		square_state_tests();
	}
	
	public static void square_state_tests(){
		boolean expected = false;
		int[][] input = {{5,3,4,6,7,8,9,1,2},{6,7,2,1,9,5,3,4,8},{1,9,8,3,4,2,5,6,7},{8,5,9,7,6,1,4,2,3},{4,2,6,8,5,3,4,9,1},{7,1,3,9,2,4,8,5,6},{9,6,1,5,3,7,2,8,4},{2,8,7,4,1,9,6,3,5},{3,4,5,2,8,6,1,7,9}};
		Sudoku_Class game = new Sudoku_Class(input);
		boolean output = game.square_state(0, 0);
		if(expected == output){
			System.out.println("square_state() test1 worked");
		}else{
			System.out.println("square_state() test1 failed");
			System.out.println("Expected: \n" + expected);
			System.out.println("Output: \n" + output);
		}
		
		input[0][0] = -5;
		expected = true;
		game = new Sudoku_Class(input);
		output = game.square_state(0, 0);
		if(expected == output){
			System.out.println("square_state() test2 worked");
		}else{
			System.out.println("square_state() test2 failed");
			System.out.println("Expected: \n" + expected);
			System.out.println("Output: \n" + output);
		}
	}
	
	public static void validate_3x3_area_tests(){
		//test1 checks using a correct sudoku board
		int[][] expected = {{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0}};
		int[][] input = {{5,3,4,6,7,8,9,1,2},{6,7,2,1,9,5,3,4,8},{1,9,8,3,4,2,5,6,7},{8,5,9,7,6,1,4,2,3},{4,2,6,8,5,3,4,9,1},{7,1,3,9,2,4,8,5,6},{9,6,1,5,3,7,2,8,4},{2,8,7,4,1,9,6,3,5},{3,4,5,2,8,6,1,7,9}};
		Sudoku_Class game = new Sudoku_Class(input);
		int[][] output = game.validate_3x3_area();
		if(Arrays.deepEquals(expected, output)){
			System.out.println("validate_3x3_area() test1 worked");
		}else{
			System.out.println("validate_3x3_area() test1 failed");
			System.out.println("Expected: \n" + expected);
			System.out.println("Output: \n" + output);
		}
		
		//test2 checks using an incorrect sudoku board
		expected[0][0] = 1;
		expected[2][0] = 1;
		input[0][0] = 1;
		game = new Sudoku_Class(input);
		output = game.validate_3x3_area();
		if(Arrays.deepEquals(expected, output)){
			System.out.println("validate_3x3_area() test2 worked");
		}else{
			System.out.println("validate_3x3_area() test2 failed");
			System.out.println("Expected: \n" + expected);
			System.out.println("Output: \n" + output);
		}
		
		//test3 checks using a board with a permanent square
		input[0][0] = -1;
		game = new Sudoku_Class(input);
		output = game.validate_3x3_area();
		if(Arrays.deepEquals(expected, output)){
			System.out.println("validate_3x3_area() test3 worked");
		}else{
			System.out.println("validate_3x3_area() test3 failed");
			System.out.println("Expected: \n" + expected);
			System.out.println("Output: \n" + output);
		}
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
			System.out.println("convert_board_to_string() test1 worked");
		}else{
			System.out.println("convert_board_to_string() test1 failed");
			System.out.println("Expected: \n" + expected);
			System.out.println("Output: \n" + output);
		}
		
		input[0][0] = -5;
		expected = "[5] | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0";
		game = new Sudoku_Class(input);
		output = game.convert_board_to_string();
		if(expected.equals(output)){
			System.out.println("convert_board_to_string() test2 worked");
		}else{
			System.out.println("convert_board_to_string() test2 failed");
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
