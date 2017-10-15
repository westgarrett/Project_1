import java.io.FileNotFoundException;
import java.util.Scanner;


public class Game_Main {
	
	public static void main(String[] args) throws FileNotFoundException{
		Scanner scanner = new Scanner(System.in);
		boolean run = true;
		while(run){
			System.out.println("Welcome");
			System.out.println("To play Sudoku type 'Sudoku' and press enter");
			System.out.println("To play Minesweeper type 'Minesweeper' and press enter");
			String input = scanner.nextLine();
			if(input.equals("Sudoku")){
				Sudoku_Main.main(args);
			}else if(input.equals("Minesweeper")){
				//Replace with reference to minesweeper
				System.out.println("Minesweeper");
			}else{
				System.out.println("Your choice was not valid. Please try again.");
			}
		}
		scanner.close();
	}
}
