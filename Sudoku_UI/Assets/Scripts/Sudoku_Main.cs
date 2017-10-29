using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sudoku_Main : MonoBehaviour
{

    private static bool exit;
    public Text txt;
    public static string choice;
    private bool first;
    public bool win
    {
        get
        {
            return w.return_value;
        }
    }
    private Sudoku_Win w;
    public int[,] board
    {
        get
        {
            return b.board;
        }
    }
    private Sudoku_Class b;
    private bool change = false;


    void Awake()
    {
        b = gameObject.GetComponent<Sudoku_Class>();
        w = gameObject.GetComponent<Sudoku_Win>();
    }

    // Use this for initialization
    void Start()
    {
        //Debug.Log("Main Start Called");
        first = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Main Update Called");
        exit = false;
        if (!win && !exit)
        {
            txt.text = "\nPress 'change' to change an entry, 'clear' to clear the board of all of the entries, 'end' to end the game and start a new one, 'save' to save the game, and 'exit' to exit the game. The dark shaded squares are permanent and can not be changed. If a entry conflicts with another square then it will be highlighted gray.";
        }
        if (win)
        {
            txt.text = "Congradulations, you have won!To Play Again Press End";
        }
    }
}
