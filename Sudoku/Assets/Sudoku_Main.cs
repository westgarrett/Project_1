using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sudoku_Main : MonoBehaviour {

    //public Sudoku_Class game;
    //private static Scanner scanner;
    private static bool exit;
    public Text txt;
    public InputField input;
    public static string choice;
    private bool first;
    public bool win {
        get {
            return w.return_value;
        }
    }
    private Sudoku_Win w;
    public int[,] board {
        get {
            return b.board;
        }
    }
    private Sudoku_Class b;
    private bool change = false;
    public InputField first_int;
    public InputField second_int;
    public InputField third_int;

    void Awake() {
        b = gameObject.GetComponent<Sudoku_Class>();
        w = gameObject.GetComponent<Sudoku_Win>();
    }

    // Use this for initialization
    void Start () {
        Debug.Log("Main Start Called");
        first = true;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Main Update Called");
        exit = false;
        if (!win && !exit)
        {
                txt.text = "\nPress 'change' to change an entry, 'clear' to clear the board of all of the entries, 'end' to end the game and start a new one, 'save' to save the game, and 'exit' to exit the game";
        }
        if (win)
        {
            txt.text = "Congradulations, you have won!\nPlay Again: 'Yes' or 'No'";
            if (input.Equals("Yes"))
            {
                Start();
            }
            else
            {
                //menu();
            }
        }
    }
    
    public void change_entry() {
        change = false;
        int row, col, val;
        row = Convert.ToInt32(first_int);
        col = Convert.ToInt32(second_int);
        val = Convert.ToInt32(third_int);
        
        //string inp = Convert.ToString(input);
        //string[] split_input = inp.Split(' ');

        // Read 3 numbers
        //bool allNumbers = true;
        //try
        //{
         
                //string user_input = "";
                //user_input = scanner.nextLine();
                //Scanner temp = new Scanner(user_input);
                if (48 <= Convert.ToChar(row) && Convert.ToChar(row) <= 57)
                {
                    if (48 <= Convert.ToChar(col) && Convert.ToChar(col) <= 57)
                    {
                        if (48 <= Convert.ToChar(val) && Convert.ToChar(val) <= 57)
                        {
                            board[row,col] = val;
                        }
                        else
                        {
                            txt.text = "Please use only 1-9 and integers";
                            //allNumbers = false;
                        }
                    }
                    else
                    {
                        txt.text = "Please put spaces between the numbers";
                        //allNumbers = false;
                    }
                }
            else
            {
                txt.text = "Please use only 1-9 and integers";
                //allNumbers = false;
            }

            //temp.close();

        //}
        //catch (ArgumentException e)
        //{
         //   if (!split_input[0].Equals("back"))
        //    {
        //        txt.text = "Numbers, please!";
        //        //scanner.nextLine();
        //    }
        //    allNumbers = false;
        //}

        // Apply change
        //if (allNumbers && !game.setSquare(row, col, val))
        //{
        ////if (game.setSquare(row, col, val)){
        ////  scanner.nextLine();
        ////}

        //txt.text = "Invalid! Please try again.";
        //}
    }
}
