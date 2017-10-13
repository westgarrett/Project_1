import org.junit.Test;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Arrays;

import static org.junit.Assert.assertArrayEquals;
import static org.junit.Assert.assertEquals;


public class Tests {


	public static void main(String[] args) throws IOException {
		create_sudoku_class_no_input_tests();
		create_sudoku_class_with_input_tests();
		print_board_tests();
		validate_3x3_area_tests();
		is_permanent_square_tests();
		clear_entries_tests();
		read_file_tests();
		save_tests();
		clear_save_tests();
	}
	
	public static void clear_save_tests() throws FileNotFoundException{
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
		if(Arrays.deepEquals(expected, output)){
			System.out.println("clear_save() test1 worked");
		}else{
			System.out.println("clear_save() test1 failed");
			System.out.println("Expected: \n" + expected);
			System.out.println("Output: \n" + output);
		}
		
		//test2 has permanent squares,i.e. negative numbers
		input[8][8] = -1;
		game = new Sudoku_Class(input);
		game.save();
		game.clear_save();
		output = game.read_file(f);
		if(Arrays.deepEquals(expected, output)){
			System.out.println("clear_save() test2 worked");
		}else{
			System.out.println("clear_save() test2 failed");
			System.out.println("Expected: \n" + input);
			System.out.println("Output: \n" + output);
		}
	}
	
	public static void save_tests() throws FileNotFoundException{
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
		if(Arrays.deepEquals(input, output)){
			System.out.println("save() test1 worked");
		}else{
			System.out.println("save() test1 failed");
			System.out.println("Expected: \n" + input);
			System.out.println("Output: \n" + output);
		}
		
		//test2 has permanent squares,i.e. negative numbers
		input[8][8] = -1;
		game = new Sudoku_Class(input);
		game.save();
		output = game.read_file(f);
		if(Arrays.deepEquals(input, output)){
			System.out.println("save() test2 worked");
		}else{
			System.out.println("save() test2 failed");
			System.out.println("Expected: \n" + input);
			System.out.println("Output: \n" + output);
		}
	}
	
	public static void read_file_tests() throws IOException{
		File f = new File("test_file.txt");
		PrintWriter write = new PrintWriter(f);
		write.close();
		
		//test1 has a blank file
		int[][] expected = new int[9][9];
		f = new File("test_file.txt");
		int[][] output = Sudoku_Class.read_file(f);
		if(Arrays.deepEquals(expected, output)){
			System.out.println("read_file() test1 worked");
		}else{
			System.out.println("read_file() test1 failed");
			System.out.println("Expected: \n" + expected);
			System.out.println("Output: \n" + output);
		}
		
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
		if(Arrays.deepEquals(expected, output)){
			System.out.println("read_file() test2 worked");
		}else{
			System.out.println("read_file() test2 failed");
			System.out.println("Expected: \n" + expected);
			System.out.println("Output: \n" + output);
		}
		
		
		
		//test3 has a file with a permanent space, i.e. a negative value
		write = new PrintWriter(f);
		expected[8][8] = -1;
		for(int i = 0; i < 80; i++){
			write.write("1 ");
		}
		write.print("-1 ");
		write.close();
		output = Sudoku_Class.read_file(f);
		if(Arrays.deepEquals(expected, output)){
			System.out.println("read_file() test3 worked");
		}else{
			System.out.println("read_file() test3 failed");
			System.out.println("Expected: \n" + expected);
			System.out.println("Output: \n" + output);
		}
		
		write = new PrintWriter(f);
		write.close();
	}
	
	public static void clear_entries_tests(){
		//Test 1 has no permanent spaces
		String expected = "0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0";
		int[][] input = {{5,3,4,6,7,8,9,1,2},{6,7,2,1,9,5,3,4,8},{1,9,8,3,4,2,5,6,7},{8,5,9,7,6,1,4,2,3},{4,2,6,8,5,3,4,9,1},{7,1,3,9,2,4,8,5,6},{9,6,1,5,3,7,2,8,4},{2,8,7,4,1,9,6,3,5},{3,4,5,2,8,6,1,7,9}};
		Sudoku_Class game = new Sudoku_Class(input);
		game.clear_entries();
		String output = game.convert_board_to_string();
		if(expected.equals(output)){
			System.out.println("clear_entries() test1 worked");
		}else{
			System.out.println("clear_entries() test1 failed");
			System.out.println("Expected: \n" + expected);
			System.out.println("Output: \n" + output);
		}
		
		//Test2 has a permanent space
		expected = "[5] | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0";
		input[0][0] = -5;
		game = new Sudoku_Class(input);
		game.clear_entries();
		output = game.convert_board_to_string();
		if(expected.equals(output)){
			System.out.println("clear_entries() test2 worked");
		}else{
			System.out.println("clear_entries() test2 failed");
			System.out.println("Expected: \n" + expected);
			System.out.println("Output: \n" + output);
		}
	}
	
	public static void is_permanent_square_tests(){
		boolean expected = false;
		int[][] input = {{5,3,4,6,7,8,9,1,2},{6,7,2,1,9,5,3,4,8},{1,9,8,3,4,2,5,6,7},{8,5,9,7,6,1,4,2,3},{4,2,6,8,5,3,4,9,1},{7,1,3,9,2,4,8,5,6},{9,6,1,5,3,7,2,8,4},{2,8,7,4,1,9,6,3,5},{3,4,5,2,8,6,1,7,9}};
		Sudoku_Class game = new Sudoku_Class(input);
		boolean output = game.is_permanent_square(0, 0);
		if(expected == output){
			System.out.println("is_permanent_square() test1 worked");
		}else{
			System.out.println("is_permanent_square() test1 failed");
			System.out.println("Expected: \n" + expected);
			System.out.println("Output: \n" + output);
		}
		
		input[0][0] = -5;
		expected = true;
		game = new Sudoku_Class(input);
		output = game.is_permanent_square(0, 0);
		if(expected == output){
			System.out.println("is_permanent_square() test2 worked");
		}else{
			System.out.println("is_permanent_square() test2 failed");
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
		
		//test4
		int[][] new_input = {{1,-2,-3,4,5,6,7,8,9},{-2,-3,-4,-5,-6,-7,-8,-9,1},{3,4,-5,6,-7,-8,9,1,2},{-4,5,6,-7,-8,9,1,2,3},{5,6,-7,-8,-9,1,-2,3,-4},{6,-7,-8,9,-1,-2,3,-4,-5},{-7,-8,9,-1,-2,-3,4,-5,-6},{8,9,1,-2,3,-4,-5,-6,-7},{-9,-1,-2,-3,-4,-5,-6,7,-8}};
		game = new Sudoku_Class(new_input);
		output = game.validate_3x3_area();
		int[][] new_expected = {{0, 1, 1, 0, 1, 1, 0, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 0, 1, 0, 0, 1, 0, 0}, {0, 1, 1, 0, 1, 1, 0, 1, 1}, {1, 0, 0, 1, 0, 0, 1, 0, 0}, {1, 0, 0, 1, 0, 0, 1, 0, 0}, {0, 1, 1, 0, 1, 1, 0, 1, 1}, {1, 0, 0, 1, 0, 0, 1, 0, 0}, {1, 0, 0, 1, 0, 0, 1, 0, 0}};
		if(Arrays.deepEquals(new_expected, output)){
			System.out.println("validate_3x3_area() test4 worked");
		}else{
			System.out.println("validate_3x3_area() test4 failed");
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
	
	public static void create_sudoku_class_no_input_tests() throws FileNotFoundException{
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
