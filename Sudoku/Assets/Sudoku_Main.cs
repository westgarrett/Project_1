using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sudoku_Main : MonoBehaviour {

    private static Sudoku_Class game;
    //private static Scanner scanner;
    private static bool exit;
    public Text txt;
    public InputField input;
    public static string choice;
    private bool first;
    private bool win;

    // Use this for initialization
    void Start () {
        //scanner = new Scanner(System.in);
        //txt.text = "Hello";
        //menu();
        first = true;
        win = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (first)
        {
            txt.text = "Welcome to Sudoku\nTo win the game you must fill each space with a number between 1-9\nEach row, column, and 3x3 section may only contain one of each number 1-9\nIf a number does not follow the rules then it will...\nIf a number is between brackets that means it is a permanent space and you can not change it\nLet the game begin";
            Debug.Log("Passed welcome");
            first = false;
        }
        //game = gameObject.AddComponent<Sudoku_Class>();
        game = new Sudoku_Class();
        exit = false;
        if (!win && !exit)
        {
            game.print_board();
            txt.text = "\nEnter 'change' to change an entry, 'clear' to clear the board of all of the entries, 'end' to end the game and start a new one, 'save' to save the game, and 'exit' to exit the game";
            user_choice();
            win = game.win();
        }
        if (win)
        {
            txt.text = "Congradulations, you have won!\nPlay Again: 'Yes' or 'No'";
            string input = Console.ReadLine();
            if (input.Equals("Yes"))
            {
                Start();
            }
            else
            {
                menu();
            }
        }
    }

    public void start_game()
    {
        //txt.text = "Welcome to Sudoku");
        // txt.text = "To win the game you must fill each space with a number between 1-9");
        // txt.text = "Each row, column, and 3x3 section may only contain one of each number 1-9");
        //txt.text = "If a number does not follow the rules then it will...");
        // txt.text = "If a number is between brackets that means it is a permanent space and you can not change it");
        //txt.text = "Let the game begin");
        //game = gameObject.AddComponent<Sudoku_Class>();
        game = new Sudoku_Class();
        bool win = false;
        exit = false;
        while (!win && !exit)
        {
            game.print_board();
            txt.text = "\nEnter 'change' to change an entry, 'clear' to clear the board of all of the entries, 'end' to end the game and start a new one, 'save' to save the game, and 'exit' to exit the game";

            user_choice();
            win = game.win();
        }
        if (win)
        {
            txt.text = "Congradulations, you have won!\nPlay Again: 'Yes' or 'No'";
            string input = Console.ReadLine();
            if (input.Equals("Yes"))
            {

                start_game();
            }
            else
            {

                menu();
            }
        }
    }

    public void user_choice()
    {
        string input = Console.ReadLine();
        if (input.Equals("change"))
        {
            txt.text = "Please enter 3 numbers row(0-8), column(0-8), value(0-9) with spaces between them or enter back to return to previous menu: ";
            int row, col, val;
            col = -1;
            val = -1;
            row = -1;
            string[] split_input = input.Split(' ');

            // Read 3 numbers
            bool allNumbers = true;
            try
            {
                //if (scanner.hasNextInt()) {
                if (48 <= Convert.ToChar(split_input[0]) && Convert.ToChar(split_input[0]) <= 57)
                {
                    //string user_input = "";
                    //user_input = scanner.nextLine();
                    //Scanner temp = new Scanner(user_input);
                    if (48 <= Convert.ToChar(split_input[0]) && Convert.ToChar(split_input[0]) <= 57)
                    {
                        row = Convert.ToInt32(split_input[0]);
                        if (48 <= Convert.ToChar(split_input[1]) && Convert.ToChar(split_input[1]) <= 57)
                        {
                            col = Convert.ToInt32(split_input[1]);
                            if (48 <= Convert.ToChar(split_input[2]) && Convert.ToChar(split_input[2]) <= 57)
                            {
                                val = Convert.ToInt32(split_input[2]);
                            }
                            else
                            {
                                txt.text = "Please put spaces between the numbers";
                                allNumbers = false;
                            }
                        }
                        else
                        {
                            txt.text = "Please put spaces between the numbers";
                            allNumbers = false;
                        }
                    }
                    else
                    {
                        txt.text = "Please put spaces between the numbers";
                        allNumbers = false;
                    }
                    //temp.close();
                }
            }
            catch (ArgumentException e)
            {
                if (!split_input[0].Equals("back"))
                {
                    txt.text = "Numbers, please!";
                    //scanner.nextLine();
                }
                allNumbers = false;
            }

            // Apply change
            if (allNumbers && !game.setSquare(row, col, val))
            {
                //if (game.setSquare(row, col, val)){
                //  scanner.nextLine();
                //}

                txt.text = "Invalid! Please try again.";
            }
        }
        else if (input.Equals("clear"))
        {
            game.clear_entries();
        }
        else if (input.Equals("save"))
        {
            game.save();
        }
        else if (input.Equals("exit"))
        {
            exit = true;
        }
        else if (input.Equals("end"))
        {
            game.clear_save();
            start_game();
        }
        else
        {
            txt.text = "Your response was not one of the availible choices";

        }
    }



    public void menu()
    {
        //txt.text = "Welcome, type 'play' and press enter to play a game";
        Debug.Log("menu()");
        //string input = Console.ReadLine();
        //if (input.Equals("play")) {
        //if (choice.Equals("play")) {
        //start_game();
        //Update();
        // } else {
        //    txt.text = "Your response was not one of the availible choices";
        //    menu();
        //}
    }

    public void OnSubmit()
    {
        choice = input.text;
    }
}
