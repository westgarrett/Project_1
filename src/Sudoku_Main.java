
public class Sudoku_Main {
	public static void main(String[] args) {
		//Main board
		int[][] board = new int[9][9];
		Print_Board(board);

	}
	
	public static void Print_Board(int[][] board){
		//Calls method Convert_Board_To_String to make the board into a printable string
		String String_Board = Convert_Board_To_String(board);
		System.out.print(String_Board);
	}
	
	public static String Convert_Board_To_String(int[][] board){
		//Start with empty string
		String String_Board = "";
		//For every row
		for(int i = 0; i < board.length; i++){
			//For every column
			for(int j = 0; j < board[i].length; j++){
				//Adds integer from board at row and column specified
				String_Board += board[i][j];
				//If it is not at the last integer of the row then adds space|space
				if(j < board[i].length - 1){
					String_Board += " | ";
				}
			}
			//If it is not the last row then it adds the new line character
			if(i < board.length - 1){
				String_Board += "\n";
			}			
		}
		return String_Board;
	}

}
