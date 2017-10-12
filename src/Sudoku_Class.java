import java.io.File;
import java.io.FileNotFoundException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Scanner;

public class Sudoku_Class {
	//Main board
	private int[][] board = new int[9][9];

	//Creates a new board
	public Sudoku_Class() throws FileNotFoundException{
		File f = new File("save_file.txt");
		board = read_file(f);
	}
	
	//Creates a board based on an input
	public Sudoku_Class(int[][] input){
		board = input;
	}
	
	public void clear_save() throws FileNotFoundException{
		File f = new File("save_file.txt");
		PrintWriter write = new PrintWriter(f);
		write.close();
	}
	
	public void save() throws FileNotFoundException{
		File f = new File("save_file.txt");
		PrintWriter write = new PrintWriter(f);
		for(int i = 0; i < board.length; i++){
			for(int j = 0; j < board[i].length; j++){
				write.print(board[i][j] + " ");
			}
		}
		write.close();
	}
	
	public static int[][] read_file(File file_name) throws FileNotFoundException{
		int[][] return_array = new int[9][9];
		File file = file_name;
		Scanner file_scanner = new Scanner(file);
		int row = 0;
		int column = 0;
		while(file_scanner.hasNext()){
			String a = file_scanner.next();
			int b = Integer.parseInt(a);
				if(row < 9){
				return_array[row][column] = b;
				column++;
				if(column >= 9){
					column = 0;
					row++;
				}
			}
		}
		file_scanner.close();
		return return_array;
	}
	
	public void clear_entries(){
		for(int i = 0; i < board.length; i++){
			for(int j = 0; j < board[i].length; j++){
				if(board[i][j] > 0){
					board[i][j] = 0;
				}
			}
		}
	}
	
	public boolean square_state(int row, int column){
		if(board[row][column] < 0){
			return true;
		}else{
			return false;
		}
	}
	
	public int[][] validate_3x3_area() {
		int[][] return_array = { { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 } };
		//For every row
		for (int i = 0; i < board.length; i++) {
			//For every column
			for (int j = 0; j < board[i].length; j++) {
				//Gets the value at the specified space
				int value = board[i][j];
				//If specified space is between column 0 and 2 and row 0 and 2
				if (0 <= j && j <= 2 && 0 <= i && i <= 2) {
					//For every row in the 3x3 area that the specified space is in
					for (int k = 0; k < 3; k++) {
						//For every column in the 3x3 area that the specified space is in
						for (int l = 0; l < 3; l++) {
							//If value is the same then it marks the spot in the return array
							if (value != 0 && Math.abs(value) == Math.abs(board[k][l]) && (i != k || j != l)) {
								return_array[i][j] = 1;
							}
						}
					}
				//If specified space is between column 3 and 5 and row 0 and 2
				} else if (3 <= j && j <= 5 && 0 <= i && i <= 2) {
					for (int k = 0; k < 3; k++) {
						for (int l = 3; l < 5; l++) {
							if (value != 0 && Math.abs(value) == Math.abs(board[k][l]) && i != k && j != l) {
								return_array[i][j] = 1;
							}
						}
					}
				//If specified space is between column 6 and 8 and row 0 and 2
				} else if (6 <= j && j <= 8 && 0 <= i && i <= 2) {
					for (int k = 0; k < 3; k++) {
						for (int l = 6; l < 8; l++) {
							if (value != 0 && Math.abs(value) == Math.abs(board[k][l]) && i != k && j != l) {
								return_array[i][j] = 1;
							}
						}
					}
				//If specified space is between column 0 and 2 and row 3 and 5
				} else if (0 <= j && j <= 2 && 3 <= i && i <= 5) {
					for (int k = 3; k < 5; k++) {
						for (int l = 0; l < 2; l++) {
							if (value != 0 && Math.abs(value) == Math.abs(board[k][l]) && i != k && j != l) {
								return_array[i][j] = 1;
							}
						}
					}
				//If specified space is between column 3 and 5 and row 3 and 5
				} else if (3 <= j && j <= 5 && 3 <= i && i <= 5) {
					for (int k = 3; k < 5; k++) {
						for (int l = 3; l < 5; l++) {
							if (value != 0 && Math.abs(value) == Math.abs(board[k][l]) && i != k && j != l) {
								return_array[i][j] = 1;
							}
						}
					}
				//If specified space is between column 6 and 8 and row 3 and 5
				} else if (6 <= j && j <= 8 && 3 <= i && i <= 5) {
					for (int k = 3; k < 5; k++) {
						for (int l = 6; l < 8; l++) {
							if (value != 0 && Math.abs(value) == Math.abs(board[k][l]) && i != k && j != l) {
								return_array[i][j] = 1;
							}
						}
					}
				//If specified space is between column 0 and 2 and row 6 and 8
				} else if (0 <= j && j <= 2 && 6 <= i && i <= 8) {
					for (int k = 6; k < 8; k++) {
						for (int l = 0; l < 2; l++) {
							if (value != 0 && Math.abs(value) == Math.abs(board[k][l]) && i != k && j != l) {
								return_array[i][j] = 1;
							}
						}
					}
				//If specified space is between column 3 and 5 and row 6 and 8
				} else if (3 <= j && j <= 5 && 6 <= i && i <= 8) {
					for (int k = 6; k < 8; k++) {
						for (int l = 3; l < 5; l++) {
							if (value != 0 && Math.abs(value) == Math.abs(board[k][l]) && i != k && j != l) {
								return_array[i][j] = 1;
							}
						}
					}
				//If specified space is between column 6 and 8 and row 6 and 8
				} else if (6 <= j && j <= 8 && 6 <= i && i <= 8) {
					for (int k = 6; k < 8; k++) {
						for (int l = 6; l < 8; l++) {
							if (value != 0 && Math.abs(value) == Math.abs(board[k][l]) && i != k && j != l) {
								return_array[i][j] = 1;
							}
						}
					}
				}
			}
		}
		return return_array;
	}

	
	//Returns the board in its array form
	public int[][] get_board(){
		return board;
	}
	
	public void print_board(){
		//Calls method Convert_Board_To_String to make the board into a printable string
		String string_board = convert_board_to_string();
		System.out.print(string_board);
	}
	
	public String convert_board_to_string(){
		//Start with empty string
		String string_board = "";
		//For every row
		for(int i = 0; i < board.length; i++){
			//For every column
			for(int j = 0; j < board[i].length; j++){
				//Adds integer from board at row and column specified
				if(board[i][j] < 0){
					string_board += "[";
					string_board += Math.abs(board[i][j]);
					string_board += "]";
				}else{
				string_board += board[i][j];}
				//If it is not at the last integer of the row then adds space|space
				if(j < board[i].length - 1){
					string_board += " | ";
				}
			}
			//If it is not the last row then it adds the new line character
			if(i < board.length - 1){
				string_board += "\n";
			}			
		}
		return string_board;
	}

    // Methods by Hoang
	int[][] validAllRowsAndCols() {
		List<HashSet<Integer>> numInRow = new ArrayList<HashSet<Integer>>();
		List<HashSet<Integer>> numInCol = new ArrayList<HashSet<Integer>>();
		for (int i = 0; i < 9; i++) {
			numInCol.add(new HashSet<Integer>());
			numInRow.add(new HashSet<Integer>());
		}
		int[][] ans = new int[9][9];
		for (int i = 0; i < 9; i++) {
			for (int j = 0; j < 9; j++) {
                ans[i][j] = 0;
			    int val = board[i][j];
				if (val > 0) {
					if (numInRow.get(i).contains(val)) {
						ans[i][j] = 1;
					}
					if (numInCol.get(j).contains(val)) {
						ans[i][j] = 1;
					}
					numInRow.get(i).add(val);
					numInCol.get(j).add(val);
				}
			}
		}
		return ans;
	}

}