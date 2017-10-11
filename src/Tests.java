//import org.junit.Test;

import java.util.Arrays;

//import static org.junit.Assert.assertArrayEquals;

public class Tests {

	public static void main(String[] args) {
		create_sudoku_class_no_input_tests();
		create_sudoku_class_with_input_tests();
		print_board_tests();
		validate_3x3_area_tests();

	}

	public static void validate_3x3_area_tests() {
		// test1 checks using a correct sudoku board
		// Square_Entry[][] expected = new Square_Entry[9][9];
		// for(int i = 0; i < expected.length; i++){
		// for(int j = 0; j < expected[i].length; j++){
		// expected[i][j] = new Square_Entry();
		// expected[i][j].set_value(0);
		// expected[i][j].set_permanent_state(false);
		// }
		// }
		int[][] expected = { { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 } };
		int[][] input_values = { { 5, 3, 4, 6, 7, 8, 9, 1, 2 },
				{ 6, 7, 2, 1, 9, 5, 3, 4, 8 }, { 1, 9, 8, 3, 4, 2, 5, 6, 7 },
				{ 8, 5, 9, 7, 6, 1, 4, 2, 3 }, { 4, 2, 6, 8, 5, 3, 4, 9, 1 },
				{ 7, 1, 3, 9, 2, 4, 8, 5, 6 }, { 9, 6, 1, 5, 3, 7, 2, 8, 4 },
				{ 2, 8, 7, 4, 1, 9, 6, 3, 5 }, { 3, 4, 5, 2, 8, 6, 1, 7, 9 } };
		Square_Entry[][] input = new Square_Entry[9][9];
		for (int i = 0; i < input_values.length; i++) {
			for (int j = 0; j < input_values[i].length; j++) {
				input[i][j] = new Square_Entry(input_values[i][j], false);
				System.out.print(input[i][j].value());
				}
			}
		Sudoku_Class game = new Sudoku_Class(input);
		int[][] output = game.validate_3x3_area();
		// boolean failed = false;
		// for(int i = 0; i < output.length; i++){
		// for(int j = 0; j < output[i].length; j++){
		// if(expected[i][j].value() != output[i][j].value()){
		// System.out.println("sudoku_class(input) failed");
		// failed = true;
		// }
		// }
		// }
		// if(!failed){
		// System.out.println("sudoku_class(input) worked");
		// }
		if (Arrays.deepEquals(expected, output)) {
			System.out.println("validate_3x3_area() test1 worked");
		} else {
			System.out.println("validate_3x3_area() test1 failed");
			System.out.println("Expected: \n" + expected);
			System.out.println("Output: \n" + output);
		}

		// test2 checks using an incorrect sudoku board
		expected[0][0] = 1;
		expected[2][0] = 1;
		input[0][0].set_value(1);
		game = new Sudoku_Class(input);
		output = game.validate_3x3_area();
		// failed = false;
		// for(int i = 0; i < output.length; i++){
		// for(int j = 0; j < output[i].length; j++){
		// if(expected[i][j].value() != output[i][j].value()){
		// System.out.println("sudoku_class(input) failed");
		// failed = true;
		// }
		// }
		// }
		// if(!failed){
		// System.out.println("sudoku_class(input) worked");
		// }
		if (Arrays.deepEquals(expected, output)) {
			System.out.println("validate_3x3_area() test2 worked");
		} else {
			System.out.println("validate_3x3_area() test2 failed");
			System.out.println("Expected: \n" + expected);
			System.out.println("Output: \n" + output);
		}
	}

	public static void create_sudoku_class_with_input_tests() {
		// int[][] expected =
		// {{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0}};;
		Square_Entry[][] expected = new Square_Entry[9][9];
		for (int i = 0; i < expected.length; i++) {
			for (int j = 0; j < expected[i].length; j++) {
				expected[i][j] = new Square_Entry();
				expected[i][j].set_value(0);
				expected[i][j].set_permanent_state(false);
			}
		}
		Square_Entry[][] input = new Square_Entry[9][9];
		for (int i = 0; i < input.length; i++) {
			for (int j = 0; j < input[i].length; j++) {
				input[i][j] = new Square_Entry();
				input[i][j].set_value(0);
				input[i][j].set_permanent_state(false);
			}
		}
		// int[][] input =
		// {{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0}};
		Sudoku_Class game = new Sudoku_Class(input);
		Square_Entry[][] output = game.get_board();
		boolean failed = false;
		for (int i = 0; i < output.length; i++) {
			for (int j = 0; j < output[i].length; j++) {
				if (expected[i][j].value() != output[i][j].value()) {
					System.out.println("sudoku_class(input) failed");
					failed = true;
				}
			}
		}
		if (!failed) {
			System.out.println("sudoku_class(input) worked");
		}
		// if(Arrays.deepEquals(expected, output)){
		// System.out.println("sudoku_class(input) worked");
		// }else{
		// System.out.println("sudoku_class(input) failed");
		// System.out.println("Expected: \n" + expected);
		// System.out.println("Output: \n" + output);
		// }

	}

	public static void create_sudoku_class_no_input_tests() {
		Square_Entry[][] expected = new Square_Entry[9][9];
		Sudoku_Class game = new Sudoku_Class();
		Square_Entry[][] output = game.get_board();
		if (Arrays.deepEquals(expected, output)) {
			System.out.println("sudoku_class() worked");
		} else {
			System.out.println("sudoku_class() failed");
			System.out.println("Expected: \n" + expected);
			System.out.println("Output: \n" + output);
		}
	}

	public static void print_board_tests() {
		String expected = "0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0";
		// int[][] input =
		// {{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0}};
		Square_Entry[][] input = new Square_Entry[9][9];
		for (int i = 0; i < input.length; i++) {
			for (int j = 0; j < input[i].length; j++) {
				input[i][j] = new Square_Entry();
				input[i][j].set_value(0);
				input[i][j].set_permanent_state(false);
			}
		}
		Sudoku_Class game = new Sudoku_Class(input);
		String output = game.convert_board_to_string();
		if (expected.equals(output)) {
			System.out.println("convert_board_to_string() worked");
		} else {
			System.out.println("convert_board_to_string() failed");
			System.out.println("Expected: \n" + expected);
			System.out.println("Output: \n" + output);
		}
	}

	// Tests by Hoang
	// @Test
	// public void testValidAllRowsAndCols0() {
	// int[][] testBoard = new int[9][9];
	// int[][] expected = new int[9][9];
	// for (int i = 0; i < 9; i++) {
	// for (int j = 0; j < 9; j++) {
	// testBoard[i][j] = (i + j) % 9 + 1;
	// }
	// }
	// Sudoku_Class game = new Sudoku_Class(testBoard);
	// // assertArrayEquals(game.validAllRowsAndCols(), expected);
}
// }
