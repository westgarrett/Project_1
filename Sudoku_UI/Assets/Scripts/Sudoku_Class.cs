using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Sudoku_Class : MonoBehaviour
{

    //Main board
    public int[,] board = new int[9, 9];
    private int[,] answer_board;
    public Text txt;
    public Text message;
    private bool change = false;
    public InputField first_int;
    public InputField second_int;
    public InputField third_int;
    public bool error = false;

    // Use this for initialization
    void Start()
    {
        //Debug.Log("Class Start Called");
        string path = @"save_file.txt";
        board = read_file(path);
        int zero_count = 0;

        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] == 0)
                {
                    zero_count++;
                }
            }
        }
        if (zero_count >= 81)
        {

            create_board();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Class Update Called");
        string string_board = convert_board_to_string();
        txt.text = string_board;
        if (error)
        {
            message.text = "Please use only 1-9 and integers";
        }
        else
        {
            message.text = "";
        }

    }

    //Creates a new board
    public void create_board()
    {
        board = new int[9, 9];
        ArrayList[,] choices = new ArrayList[9, 9];
        for (int i = 0; i < choices.GetLength(0); i++)
        {
            for (int j = 0; j < choices.GetLength(1); j++)
            {
                choices[i, j] = new ArrayList();
                for (int k = 1; k <= 9; k++)
                {
                    choices[i, j].Add(k);
                }
            }
        }
        board_filler(0, 0, choices, false);
        answer_board = new int[9, 9];
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                answer_board[i, j] = board[i, j];
            }
        }
        board = new int[9, 9];
        System.Random prob = new System.Random();
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                int chosen_num = prob.Next(4);
                if (chosen_num == 0)
                {
                    answer_board[i, j] = 0 - answer_board[i, j];
                    board[i, j] = answer_board[i, j];
                }
            }
        }
    }

    private void board_filler(int row, int col, ArrayList[,] choices, bool back)
    {
        System.Random random_number = new System.Random();
        bool valid = false;
        while (!valid)
        {
            if (choices[row, col].Count <= 0)
            {
                board[row, col] = 0;
                for (int k = 1; k <= 9; k++)
                {
                    choices[row, col].Add(k);
                }
                col--;
                if (col < 0)
                {
                    row--;
                    col = 8;
                }
                choices[row, col].Remove(board[row, col]);
                board_filler(row, col, choices, true);
                back = false;
                valid = true;
            }
            int num = random_number.Next(choices[row, col].Count);
            int element = Convert.ToInt32(choices[row, col][num]);
            board[row, col] = element;
            int[,] test = Validate();
            valid = true;
            bool removed = false;
            for (int i = 0; i <= row; i++)
            {
                for (int j = 0; j <= col; j++)
                {
                    if (test[i, j] == 1)
                    {
                        if (!removed)
                        {
                            valid = false;
                            choices[row, col].Remove(board[row, col]);
                            removed = true;
                        }

                    }
                }
            }
            if (choices[row, col].Count <= 0)
            {
                board[row, col] = 0;
                for (int k = 1; k <= 9; k++)
                {
                    choices[row, col].Add(k);
                }
                col--;
                if (col < 0)
                {
                    row--;
                    col = 8;
                }
                choices[row, col].Remove(board[row, col]);
                board_filler(row, col, choices, true);
                back = false;
                valid = true;
            }
            if (valid && !back)
            {
                col++;
                if (col >= 9)
                {
                    row++;
                    col = 0;
                }
                if (row < 9)
                {
                    board_filler(row, col, choices, false);
                }
            }
        }
    }

    public int[,] get_answer_board()
    {
        return answer_board;
    }

    public void clear_save()
    {
        string path = @"save_file.txt";
        StreamWriter write = new StreamWriter(path);
        write.Close();
    }

    public void save()
    {
        string path = @"save_file.txt";
        StreamWriter write = new StreamWriter(path);
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                write.Write(board[i, j] + " ");
            }
        }
        write.Close();
    }

    public static int[,] read_file(string path)
    {
        int[,] return_array = new int[9, 9];
        StreamReader reader = new StreamReader(path);
        int row = 0;
        int column = 0;
        string line;
        line = reader.ReadLine();
        //Debug.Log(line);
        bool stop = false;
        if (line == null)
        {
            stop = true;
        }
        else
        {
            string[] a = line.Split(' ');
            int count = 0;
            while (!stop && a[count] != null && !a[count].Equals(""))
            {
                int b = Convert.ToInt32(a[count]);
                if (row < 9)
                {
                    return_array[row, column] = b;
                    column++;
                    if (column >= 9)
                    {
                        column = 0;
                        row++;
                    }
                }
                count++;
                if (a[count] == null)
                {
                    stop = true;
                }
            }
        }
        reader.Close();
        return return_array;
    }

    public void clear_entries()
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] > 0)
                {
                    board[i, j] = 0;
                }
            }
        }
    }

    public bool is_permanent_square(int row, int column)
    {
        if (board[row, column] < 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Returns the board in its array form
    public int[,] get_board()
    {
        return board;
    }

    public void print_board()
    {
        //Calls method Convert_Board_To_string to make the board into a printable string
        string string_board = convert_board_to_string();
    }

    public string convert_board_to_string()
    {
        //Start with empty string
        string string_board = "";
        //For every row
        for (int i = 0; i < board.GetLength(0); i++)
        {
            //For every column
            for (int j = 0; j < board.GetLength(1); j++)
            {
                //Adds integer from board at row and column specified
                if (board[i, j] < 0)
                {
                    if (j != 0)
                    {
                        string_board = string_board.Trim();
                    }
                    string_board += "[";
                    string_board += Math.Abs(board[i, j]);
                    string_board += "]";
                }
                else
                {
                    string_board += board[i, j];
                }
                //If it is not at the last integer of the row then adds space|space
                if (j < board.GetLength(1) - 1 && board[i, j] >= 0)
                {
                    string_board += " | ";
                }
                else if (board[i, j] < 0 && j < board.GetLength(1) - 1)
                {
                    string_board += "| ";
                }
            }
            //If it is not the last row then it adds the new line character
            if (i < board.Length - 1)
            {
                string_board += "\n";
            }
        }
        return string_board;
    }

    // Return true if the square is successfully set to new value, false otherwise
    // No validation in this function.
    public bool setSquare(int r, int c, int val)
    {
        if (r < 0 || c < 0 || r > 9 || c > 9)
        {
            error = true;
            return false;
        }
        if (is_permanent_square(r, c) || val < 0 || val > 9)
        {
            error = true;
            return false;
        }

        board[r, c] = val;
        Debug.Log("changed");
        return true;
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

    public void change_entry()
    {

        Debug.Log("change entry");
        change = false;
        int row, col, val;
        row = int.Parse(first_int.text);
        col = Convert.ToInt32(second_int.text);
        val = Convert.ToInt32(third_int.text);
        Debug.Log(row);
        Debug.Log(col);
        Debug.Log(val);
        if (0 <= row && row <= 9)
        {
            if (0 <= col && col <= 9)
            {
                if (0 <= val && val <= 9)
                {
                    error = false;
                    setSquare(row, col, val);
                }
                else
                {
                    error = true;
                }
            }
            else
            {
                error = true;
            }
        }
        else
        {
            error = true;
        }
    }

    public void end()
    {
        clear_save();
        Start();
    }

    public void exit()
    {
        //Go to main menu
    }
}
