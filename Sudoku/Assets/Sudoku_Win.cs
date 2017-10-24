using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sudoku_Win : MonoBehaviour {
    public int[,] board{
        get{
            return b.board;
        }
    }
    private Sudoku_Class b;
    //public int[,] validBoard {
    //    get {
   //         return v.ans;
    //    }
    //}
    private Sudoku_Validate v;
    public bool return_value;

    void Awake(){
        b = gameObject.GetComponent<Sudoku_Class>();
    //    v = gameObject.GetComponent<Sudoku_Validate>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Win Update Called");
        return_value = true;
        int[,] valid_array = Validate();
        for (int i = 0; i < valid_array.GetLength(0); i++)
        {
            for (int j = 0; j < valid_array.GetLength(1); j++)
            {
                if (board[i, j] == 0)
                {
                    return_value = false;
                }
            }
        }
        if (return_value)
        {
            for (int i = 0; i < valid_array.Length; i++)
            {
                for (int j = 0; j < valid_array.GetLength(i); j++)
                {
                    if (valid_array[i, j] != 0)
                    {
                        return_value = false;
                    }
                }
            }
        }
    }

    public int[,] Validate()
    {
        //Debug.Log("Validate Start Called");
        int[,] res;
        int[,] rowsAndCols = ValidAllRowsAndCols();
        int[,] local3x3 = validate_3x3_area();
        res = new int[9, 9];
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                res[i, j] = rowsAndCols[i, j] | local3x3[i, j];
            }
        }
        return res;
    }

    int[,] ValidAllRowsAndCols()
    {

        int[,] ans = new int[9, 9];
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                ans[i, j] = 0;
                int val = Math.Abs(board[i, j]);
                if (val != 0)
                {
                    // Check for row
                    for (int k = 0; k < 9; k++)
                    {
                        if (k != j && val == Math.Abs(board[i, k]))
                        {
                            ans[i, j] = 1;
                        }
                    }
                    // Check for col
                    for (int k = 0; k < 9; k++)
                    {
                        if (k != i && val == Math.Abs(board[k, j]))
                        {
                            ans[i, j] = 1;
                        }
                    }
                }
            }
        }
        return ans;
    }

    public int[,] validate_3x3_area()
    {
        int[,] return_array = { { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 } };
        //For every row
        for (int i = 0; i < board.GetLength(0); i++)
        {
            //For every column
            for (int j = 0; j < board.GetLength(1); j++)
            {
                //Gets the value at the specified space
                int value = board[i, j];
                //If specified space is between column 0 and 2 and row 0 and 2
                if (0 <= j && j <= 2 && 0 <= i && i <= 2)
                {
                    //For every row in the 3x3 area that the specified space is in
                    for (int k = 0; k < 3; k++)
                    {
                        //For every column in the 3x3 area that the specified space is in
                        for (int l = 0; l < 3; l++)
                        {
                            //If value is the same then it marks the spot in the return array
                            if (value != 0 && Math.Abs(value) == Math.Abs(board[k, l]) && (i != k || j != l))
                            {
                                return_array[i, j] = 1;
                            }
                        }
                    }
                    //If specified space is between column 3 and 5 and row 0 and 2
                }
                else if (3 <= j && j <= 5 && 0 <= i && i <= 2)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        for (int l = 3; l < 6; l++)
                        {
                            if (value != 0 && Math.Abs(value) == Math.Abs(board[k, l]) && (i != k || j != l))
                            {
                                return_array[i, j] = 1;
                            }
                        }
                    }
                    //If specified space is between column 6 and 8 and row 0 and 2
                }
                else if (6 <= j && j <= 8 && 0 <= i && i <= 2)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        for (int l = 6; l < 9; l++)
                        {
                            if (value != 0 && Math.Abs(value) == Math.Abs(board[k, l]) && (i != k || j != l))
                            {
                                return_array[i, j] = 1;
                            }
                        }
                    }
                    //If specified space is between column 0 and 2 and row 3 and 5
                }
                else if (0 <= j && j <= 2 && 3 <= i && i <= 5)
                {
                    for (int k = 3; k < 6; k++)
                    {
                        for (int l = 0; l < 3; l++)
                        {
                            if (value != 0 && Math.Abs(value) == Math.Abs(board[k, l]) && (i != k || j != l))
                            {
                                return_array[i, j] = 1;
                            }
                        }
                    }
                    //If specified space is between column 3 and 5 and row 3 and 5
                }
                else if (3 <= j && j <= 5 && 3 <= i && i <= 5)
                {
                    for (int k = 3; k < 6; k++)
                    {
                        for (int l = 3; l < 6; l++)
                        {
                            if (value != 0 && Math.Abs(value) == Math.Abs(board[k, l]) && (i != k || j != l))
                            {
                                return_array[i, j] = 1;
                            }
                        }
                    }
                    //If specified space is between column 6 and 8 and row 3 and 5
                }
                else if (6 <= j && j <= 8 && 3 <= i && i <= 5)
                {
                    for (int k = 3; k < 6; k++)
                    {
                        for (int l = 6; l < 9; l++)
                        {
                            if (value != 0 && Math.Abs(value) == Math.Abs(board[k, l]) && (i != k || j != l))
                            {
                                return_array[i, j] = 1;
                            }
                        }
                    }
                    //If specified space is between column 0 and 2 and row 6 and 8
                }
                else if (0 <= j && j <= 2 && 6 <= i && i <= 8)
                {
                    for (int k = 6; k < 9; k++)
                    {
                        for (int l = 0; l < 3; l++)
                        {
                            if (value != 0 && Math.Abs(value) == Math.Abs(board[k, l]) && (i != k || j != l))
                            {
                                return_array[i, j] = 1;
                            }
                        }
                    }
                    //If specified space is between column 3 and 5 and row 6 and 8
                }
                else if (3 <= j && j <= 5 && 6 <= i && i <= 8)
                {
                    for (int k = 6; k < 9; k++)
                    {
                        for (int l = 3; l < 6; l++)
                        {
                            if (value != 0 && Math.Abs(value) == Math.Abs(board[k, l]) && (i != k || j != l))
                            {
                                return_array[i, j] = 1;
                            }
                        }
                    }
                    //If specified space is between column 6 and 8 and row 6 and 8
                }
                else if (6 <= j && j <= 8 && 6 <= i && i <= 8)
                {
                    for (int k = 6; k < 9; k++)
                    {
                        for (int l = 6; l < 9; l++)
                        {
                            if (value != 0 && Math.Abs(value) == Math.Abs(board[k, l]) && (i != k || j != l))
                            {
                                return_array[i, j] = 1;
                            }
                        }
                    }
                }
            }
        }
        return return_array;
    }

}
