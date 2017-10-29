using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sudoku_Win : MonoBehaviour
{
    public int[,] board
    {
        get
        {
            return b.board;
        }
		set
		{
			b.board = value;
		}
    }
    private Sudoku_Class b;
    public bool return_value;

    void Awake()
    {
        b = gameObject.GetComponent<Sudoku_Class>();
    }

    // Use this for initialization
    void Start()
    {
		test_valid_rowcol ();
		test_valid_33 ();
		test_valid_all ();
    }

    // Update is called once per frame
    void Update()
    {
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
            for (int i = 0; i < valid_array.GetLength(0); i++)
            {
                for (int j = 0; j < valid_array.GetLength(1); j++)
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
	public void test_valid_all()
	{
		int[,] expected = {
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }
		};
		int[,] bak_board = board;
		int[,] test_board = {
			{5,3,4,6,7,8,9,1,2},
			{6,7,2,1,9,5,3,4,8},
			{1,9,8,3,4,2,5,6,7},
			{8,5,9,7,6,1,4,2,3},
			{4,2,6,8,5,3,7,9,1},
			{7,1,3,9,2,4,8,5,6},
			{9,6,1,5,3,7,2,8,4},
			{2,8,7,4,1,9,6,3,5},
			{3,4,5,2,8,6,1,7,9}
		};
		board = test_board;
		int[,] res = Validate ();
		if (array2dComp(expected, res)) {
			Debug.Log ("Test ok");
		} else {
			Debug.Log ("Test FAIL");
		}
		board = bak_board;
	}
	public void test_valid_rowcol()
	{
		int[,] expected = {
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }
		};
		int[,] bak_board = board;
		int[,] test_board = {
			{5,3,4,6,7,8,9,1,2},
			{6,7,2,1,9,5,3,4,8},
			{1,9,8,3,4,2,5,6,7},
			{8,5,9,7,6,1,4,2,3},
			{4,2,6,8,5,3,7,9,1},
			{7,1,3,9,2,4,8,5,6},
			{9,6,1,5,3,7,2,8,4},
			{2,8,7,4,1,9,6,3,5},
			{3,4,5,2,8,6,1,7,9}
		};
		board = test_board;
		int[,] res = ValidAllRowsAndCols ();
		if (array2dComp(expected, res)) {
			Debug.Log ("Test ok");
		} else {
			Debug.Log ("Test FAIL");
		}
		board = bak_board;
	}
	public void test_valid_33()
	{
		int[,] expected = {
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }
		};
		int[,] bak_board = board;
		int[,] test_board = {
			{5,3,4,6,7,8,9,1,2},
			{6,7,2,1,9,5,3,4,8},
			{1,9,8,3,4,2,5,6,7},
			{8,5,9,7,6,1,4,2,3},
			{4,2,6,8,5,3,7,9,1},
			{7,1,3,9,2,4,8,5,6},
			{9,6,1,5,3,7,2,8,4},
			{2,8,7,4,1,9,6,3,5},
			{3,4,5,2,8,6,1,7,9}
		};
		board = test_board;
		int[,] res = validate_3x3_area ();
		if (array2dComp(expected, res)) {
			Debug.Log ("Test ok");
		} else {
			Debug.Log ("Test FAIL");
		}
		board = bak_board;
	}
	public bool array2dComp(int[,] a, int[,] b) {
		for (int i = 0; i < 9; i++) {
			for (int j = 0; j < 9; j++) {
				if (a [i,j] != b [i,j]) {
					return false;
				}
			}
		}
		return true;
	}
}
