import java.io.FileNotFoundException;
import java.util.InputMismatchException;
import java.util.Scanner;

public class Sudoku_Main {
	private static Sudoku_Class game;
	private static Scanner scanner;
	private static boolean exit;
	
	public static void main(String[] args) throws FileNotFoundException {
		scanner = new Scanner(System.in);
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
		exit = false;
		while (!win && !exit) {
			game.print_board();
			System.out.println("\nEnter 'change' to change an entry, 'clear' to clear the board of all of the entries, 'end' to end the game and start a new one, 'save' to save the game, and 'exit' to exit the game");
			user_choice();
			win = game.win();
		}
		if(win){
			System.out.println("Congradulations, you have won!");
			System.out.println("Play Again: 'Yes' or 'No'");
			String input = scanner.nextLine();
			if(input.equals("Yes")){
				start_game();
			}else{
				menu();
			}
		}
	}

	public static void user_choice() throws FileNotFoundException{
		String input = scanner.nextLine();
		if(input.equals("change")){
			System.out.println("Please enter 3 numbers row(0-8), column(0-8), value(0-9) with spaces between them or enter back to return to previous menu: ");
			int row, col, val;
			col = -1;
			val = -1;
			row = -1;

			// Read 3 numbers
			boolean allNumbers = true;
            try {
            	if(scanner.hasNextInt()){
            		String user_input = "";
            		user_input = scanner.nextLine();
            		Scanner temp = new Scanner(user_input);
            		if(temp.hasNextInt()){
            			row = temp.nextInt();
            			if(temp.hasNextInt()){
                			col = temp.nextInt();
                			if(temp.hasNextInt()){
                    			val = temp.nextInt();
                    		}else{
                    			System.out.println("Please put spaces between the numbers");
                    			allNumbers = false;
                    		}
                		}else{
                			System.out.println("Please put spaces between the numbers");
                			allNumbers = false;
                		}
            		}else{
            			System.out.println("Please put spaces between the numbers");
            			allNumbers = false;
            		}
            		temp.close();
            	}
            } catch (InputMismatchException e) {
            	if(!scanner.nextLine().equals("back")){
            		System.out.println("Numbers, please!");
            		scanner.nextLine();
            	}
                allNumbers = false;
            }

            // Apply change
            if (allNumbers && !game.setSquare(row, col, val)) {
            	if(game.setSquare(row, col, val)){
            		scanner.nextLine();
            	}
            	
                System.out.println("Invalid! Please try again.");
            }
		}else if(input.equals("clear")){
			game.clear_entries();
		}else if(input.equals("save")){
			game.save();
		}else if(input.equals("exit")){
			exit = true;
		}else if(input.equals("end")){
			game.clear_save();
			start_game();
		}else{
			System.out.println("Your response was not one of the availible choices");

		}
	}
		

	public static void menu() throws FileNotFoundException {
		System.out.println("Welcome, type 'play' and press enter to play a game");
		String input = scanner.nextLine();
		if (input.equals("play")) {
			start_game();
		} else {
			System.out.println("Your response was not one of the availible choices");
			menu();
		}
	}
}
