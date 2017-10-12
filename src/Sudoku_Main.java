import java.io.FileNotFoundException;
import java.util.Scanner;

public class Sudoku_Main {
	private static Sudoku_Class game;
	
	public static void main(String[] args) throws FileNotFoundException {
		menu();
	}

	public static void start_game() throws FileNotFoundException {
		System.out.println("Welcome to Sudoku");
		System.out.println("To win the game you must fill each space with a number between 1-9");
		System.out.println("Each row, column, and 3x3 section may only contain one of each number 1-9");
		System.out.println("If a number does not follow the rules then it will...");
		System.out.println("If a number is between brackets that means it is a permanent space and you can not change it");
		System.out.println("Let the game begin");
		game = new Sudoku_Class();
		boolean win = false;
		while (!win) {
			game.print_board();
			System.out.println("\nEnter 'change' to change an entry, 'clear' to clear the board of all of the entries, 'end' to end the game and start a new one, 'save' to save the game, and 'exit' to exit the game");
			user_choice();
		}
	}

	public static void user_choice() throws FileNotFoundException{
		Scanner scanner = new Scanner(System.in);
		String input = scanner.nextLine();
		if(input.equals("change")){
			//code to direct to it goes here
		}else if(input.equals("clear")){
			game.clear_entries();
		}else if(input.equals("save")){
			game.save();
		}else if(input.equals("exit")){
			menu();
		}else if(input.equals("end")){
			game.clear_save();
			start_game();
		}else{
			System.out.println("Your response was not one of the availible choices");
			user_choice();
		}
		scanner.close();
	}
		

	public static void menu() throws FileNotFoundException {
		System.out.println("Welcome, type 'play' and press enter to play a game");
		Scanner scanner = new Scanner(System.in);
		String input = scanner.nextLine();
		if (input.equals("play")) {
			start_game();
		} else {
			System.out.println("Your response was not one of the availible choices");
			menu();
		}
	}
}
