
public class sudoku_class {
	//Main board
	public static int[][] board = new int[9][9];

	//Creates a new board
	public sudoku_class(){
		board = new int[9][9];
	}
	
	//Creates a board based on an input
	public sudoku_class(int[][] input){
		board = input;
	}
	
	//Returns the board in its array form
	public int[][] board(){
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
				string_board += board[i][j];
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
}
