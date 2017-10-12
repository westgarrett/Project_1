import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;

public class Sudoku_Class {
	//Main board
	private int[][] board = new int[9][9];

	//Creates a new board
	public Sudoku_Class(){
		board = new int[9][9];
	}
	
	//Creates a board based on an input
	public Sudoku_Class(int[][] input){
		board = input;
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
				int value = Math.abs(board[i][j]);
				//If specified space is between column 0 and 2 and row 0 and 2
				if (0 <= j && j <= 2 && 0 <= i && i <= 2) {
					//For every row in the 3x3 area that the specified space is in
					for (int k = 0; k < 3; k++) {
						//For every column in the 3x3 area that the specified space is in
						for (int l = 0; l < 3; l++) {
							//If value is the same then it marks the spot in the return array
							if (value != 0 && value >=0 && value == Math.abs(board[k][l]) && (i != k || j != l)) {
								return_array[i][j] = 1;
							}
						}
					}
				//If specified space is between column 3 and 5 and row 0 and 2
				} else if (3 <= j && j <= 5 && 0 <= i && i <= 2) {
					for (int k = 0; k < 3; k++) {
						for (int l = 3; l < 5; l++) {
							if (value != 0 && value >=0 && value == Math.abs(board[k][l]) && i != k && j != l) {
								return_array[i][j] = 1;
							}
						}
					}
				//If specified space is between column 6 and 8 and row 0 and 2
				} else if (6 <= j && j <= 8 && 0 <= i && i <= 2) {
					for (int k = 0; k < 3; k++) {
						for (int l = 6; l < 8; l++) {
							if (value != 0 && value >=0 && value == Math.abs(board[k][l]) && i != k && j != l) {
								return_array[i][j] = 1;
							}
						}
					}
				//If specified space is between column 0 and 2 and row 3 and 5
				} else if (0 <= j && j <= 2 && 3 <= i && i <= 5) {
					for (int k = 3; k < 5; k++) {
						for (int l = 0; l < 2; l++) {
							if (value != 0 && value >=0 && value == Math.abs(board[k][l]) && i != k && j != l) {
								return_array[i][j] = 1;
							}
						}
					}
				//If specified space is between column 3 and 5 and row 3 and 5
				} else if (3 <= j && j <= 5 && 3 <= i && i <= 5) {
					for (int k = 3; k < 5; k++) {
						for (int l = 3; l < 5; l++) {
							if (value != 0 && value >=0 && value == Math.abs(board[k][l]) && i != k && j != l) {
								return_array[i][j] = 1;
							}
						}
					}
				//If specified space is between column 6 and 8 and row 3 and 5
				} else if (6 <= j && j <= 8 && 3 <= i && i <= 5) {
					for (int k = 3; k < 5; k++) {
						for (int l = 6; l < 8; l++) {
							if (value != 0 && value >=0 && value == Math.abs(board[k][l]) && i != k && j != l) {
								return_array[i][j] = 1;
							}
						}
					}
				//If specified space is between column 0 and 2 and row 6 and 8
				} else if (0 <= j && j <= 2 && 6 <= i && i <= 8) {
					for (int k = 6; k < 8; k++) {
						for (int l = 0; l < 2; l++) {
							if (value != 0 && value >=0 && value == Math.abs(board[k][l]) && i != k && j != l) {
								return_array[i][j] = 1;
							}
						}
					}
				//If specified space is between column 3 and 5 and row 6 and 8
				} else if (3 <= j && j <= 5 && 6 <= i && i <= 8) {
					for (int k = 6; k < 8; k++) {
						for (int l = 3; l < 5; l++) {
							if (value != 0 && value >=0 && value == Math.abs(board[k][l]) && i != k && j != l) {
								return_array[i][j] = 1;
							}
						}
					}
				//If specified space is between column 6 and 8 and row 6 and 8
				} else if (6 <= j && j <= 8 && 6 <= i && i <= 8) {
					for (int k = 6; k < 8; k++) {
						for (int l = 6; l < 8; l++) {
							if (value != 0 && value >=0 && value == Math.abs(board[k][l]) && i != k && j != l) {
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
		int[][] ans = new int[9][9];
		for (int i = 0; i < 9; i++) {
			for (int j = 0; j < 9; j++) {
                ans[i][j] = 0;
                int val = Math.abs(board[i][j]);
				if (val != 0) {
				    // Check for row
					for (int k = 0; k < 9; k++) {
						if (k != j && val == Math.abs(board[i][k])) {
						    ans[i][j] = 1;
                        }
					}
					// Check for col
                    for (int k = 0; k < 9; k++) {
					    if (k != i && val == Math.abs(board[k][j])) {
					        ans[i][j] = 1;
                        }
                    }
				}
			}
		}
		return ans;
	}

	// Return 9x9 0/1 board denotes if a square is invalid or not.
	int[][] validBoard() {
		int[][] rowsAndCols = validAllRowsAndCols();
		int[][] local3x3 = validate_3x3_area();
		int[][] res = new int[9][9];
		for (int i = 0; i < 9; i++) {
			for (int j = 0; j < 9; j++) {
				res[i][j] = rowsAndCols[i][j] | local3x3[i][j];
			}
		}
		return res;
	}

	// Return true if the square is successfully set to new value, false otherwise
	// No validation in this function.
	public boolean setSquare(int r, int c, int val) {
		if (square_state(r, c)) {
			return false;
		}

		board[r][c] = val;
		return true;
	}
}
