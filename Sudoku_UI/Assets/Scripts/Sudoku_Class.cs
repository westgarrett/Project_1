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
    //public Text txt;
    public Text message;
    private bool change = false;
    public bool error = false;
    public InputField zero_zero;
    public InputField zero_one;
    public InputField zero_two;
    public InputField zero_three;
    public InputField zero_four;
    public InputField zero_five;
    public InputField zero_six;
    public InputField zero_seven;
    public InputField zero_eight;
    public InputField one_zero;
    public InputField one_one;
    public InputField one_two;
    public InputField one_three;
    public InputField one_four;
    public InputField one_five;
    public InputField one_six;
    public InputField one_seven;
    public InputField one_eight;
    public InputField two_zero;
    public InputField two_one;
    public InputField two_two;
    public InputField two_three;
    public InputField two_four;
    public InputField two_five;
    public InputField two_six;
    public InputField two_seven;
    public InputField two_eight;
    public InputField three_zero;
    public InputField three_one;
    public InputField three_two;
    public InputField three_three;
    public InputField three_four;
    public InputField three_five;
    public InputField three_six;
    public InputField three_seven;
    public InputField three_eight;
    public InputField four_zero;
    public InputField four_one;
    public InputField four_two;
    public InputField four_three;
    public InputField four_four;
    public InputField four_five;
    public InputField four_six;
    public InputField four_seven;
    public InputField four_eight;
    public InputField five_zero;
    public InputField five_one;
    public InputField five_two;
    public InputField five_three;
    public InputField five_four;
    public InputField five_five;
    public InputField five_six;
    public InputField five_seven;
    public InputField five_eight;
    public InputField six_zero;
    public InputField six_one;
    public InputField six_two;
    public InputField six_three;
    public InputField six_four;
    public InputField six_five;
    public InputField six_six;
    public InputField six_seven;
    public InputField six_eight;
    public InputField seven_zero;
    public InputField seven_one;
    public InputField seven_two;
    public InputField seven_three;
    public InputField seven_four;
    public InputField seven_five;
    public InputField seven_six;
    public InputField seven_seven;
    public InputField seven_eight;
    public InputField eight_zero;
    public InputField eight_one;
    public InputField eight_two;
    public InputField eight_three;
    public InputField eight_four;
    public InputField eight_five;
    public InputField eight_six;
    public InputField eight_seven;
    public InputField eight_eight;

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
        string string_board = convert_board_to_string();
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (i == 0)
                {
                    if (j == 0)
                    {
                        zero_zero.interactable = true;
                    }
                    else if (j == 1)
                    {
                        zero_one.interactable = true;
                    }
                    else if (j == 2)
                    {
                        zero_two.interactable = true;
                    }
                    else if (j == 3)
                    {
                        zero_three.interactable = true;
                    }
                    else if (j == 4)
                    {
                        zero_four.interactable = true;
                    }
                    else if (j == 5)
                    {
                        zero_five.interactable = true;
                    }
                    else if (j == 6)
                    {
                        zero_six.interactable = true;
                    }
                    else if (j == 7)
                    {
                        zero_seven.interactable = true;
                    }
                    else
                    {
                        zero_eight.interactable = true;
                    }
                }
                else if (i == 1)
                {
                    if (j == 0)
                    {
                        one_zero.interactable = true;
                    }
                    else if (j == 1)
                    {
                        one_one.interactable = true;
                    }
                    else if (j == 2)
                    {
                        one_two.interactable = true;
                    }
                    else if (j == 3)
                    {
                        one_three.interactable = true;
                    }
                    else if (j == 4)
                    {
                        one_four.interactable = true;
                    }
                    else if (j == 5)
                    {
                        one_five.interactable = true;
                    }
                    else if (j == 6)
                    {
                        one_six.interactable = true;
                    }
                    else if (j == 7)
                    {
                        one_seven.interactable = true;
                    }
                    else
                    {
                        one_eight.interactable = true;
                    }
                }
                else if (i == 2)
                {
                    if (j == 0)
                    {
                        two_zero.interactable = true;
                    }
                    else if (j == 1)
                    {
                        two_one.interactable = true;
                    }
                    else if (j == 2)
                    {
                        two_two.interactable = true;
                    }
                    else if (j == 3)
                    {
                        two_three.interactable = true;
                    }
                    else if (j == 4)
                    {
                        two_four.interactable = true;
                    }
                    else if (j == 5)
                    {
                        two_five.interactable = true;
                    }
                    else if (j == 6)
                    {
                        two_six.interactable = true;
                    }
                    else if (j == 7)
                    {
                        two_seven.interactable = true;
                    }
                    else
                    {
                        two_eight.interactable = true;
                    }
                }
                else if (i == 3)
                {
                    if (j == 0)
                    {
                        three_zero.interactable = true;
                    }
                    else if (j == 1)
                    {
                        three_one.interactable = true;
                    }
                    else if (j == 2)
                    {
                        three_two.interactable = true;
                    }
                    else if (j == 3)
                    {
                        three_three.interactable = true;
                    }
                    else if (j == 4)
                    {
                        three_four.interactable = true;
                    }
                    else if (j == 5)
                    {
                        three_five.interactable = true;
                    }
                    else if (j == 6)
                    {
                        three_six.interactable = true;
                    }
                    else if (j == 7)
                    {
                        three_seven.interactable = true;
                    }
                    else
                    {
                        three_eight.interactable = true;
                    }
                }
                else if (i == 4)
                {
                    if (j == 0)
                    {
                        four_zero.interactable = true;
                    }
                    else if (j == 1)
                    {
                        four_one.interactable = true;
                    }
                    else if (j == 2)
                    {
                        four_two.interactable = true;
                    }
                    else if (j == 3)
                    {
                        four_three.interactable = true;
                    }
                    else if (j == 4)
                    {
                        four_four.interactable = true;
                    }
                    else if (j == 5)
                    {
                        four_five.interactable = true;
                    }
                    else if (j == 6)
                    {
                        four_six.interactable = true;
                    }
                    else if (j == 7)
                    {
                        four_seven.interactable = true;
                    }
                    else
                    {
                        four_eight.interactable = true;
                    }
                }
                else if (i == 5)
                {
                    if (j == 0)
                    {
                        five_zero.interactable = true;
                    }
                    else if (j == 1)
                    {
                        five_one.interactable = true;
                    }
                    else if (j == 2)
                    {
                        five_two.interactable = true;
                    }
                    else if (j == 3)
                    {
                        five_three.interactable = true;
                    }
                    else if (j == 4)
                    {
                        five_four.interactable = true;
                    }
                    else if (j == 5)
                    {
                        five_five.interactable = true;
                    }
                    else if (j == 6)
                    {
                        five_six.interactable = true;
                    }
                    else if (j == 7)
                    {
                        five_seven.interactable = true;
                    }
                    else
                    {
                        five_eight.interactable = true;
                    }
                }
                else if (i == 6)
                {
                    if (j == 0)
                    {
                        six_zero.interactable = true;
                    }
                    else if (j == 1)
                    {
                        six_one.interactable = true;
                    }
                    else if (j == 2)
                    {
                        six_two.interactable = true;
                    }
                    else if (j == 3)
                    {
                        six_three.interactable = true;
                    }
                    else if (j == 4)
                    {
                        six_four.interactable = true;
                    }
                    else if (j == 5)
                    {
                        six_five.interactable = true;
                    }
                    else if (j == 6)
                    {
                        six_six.interactable = true;
                    }
                    else if (j == 7)
                    {
                        six_seven.interactable = true;
                    }
                    else
                    {
                        six_eight.interactable = true;
                    }
                }
                else if (i == 7)
                {
                    if (j == 0)
                    {
                        seven_zero.interactable = true;
                    }
                    else if (j == 1)
                    {
                        seven_one.interactable = true;
                    }
                    else if (j == 2)
                    {
                        seven_two.interactable = true;
                    }
                    else if (j == 3)
                    {
                        seven_three.interactable = true;
                    }
                    else if (j == 4)
                    {
                        seven_four.interactable = true;
                    }
                    else if (j == 5)
                    {
                        seven_five.interactable = true;
                    }
                    else if (j == 6)
                    {
                        seven_six.interactable = true;
                    }
                    else if (j == 7)
                    {
                        seven_seven.interactable = true;
                    }
                    else
                    {
                        seven_eight.interactable = true;
                    }
                }
                else
                {
                    if (j == 0)
                    {
                        eight_zero.interactable = true;
                    }
                    else if (j == 1)
                    {
                        eight_one.interactable = true;
                    }
                    else if (j == 2)
                    {
                        eight_two.interactable = true;
                    }
                    else if (j == 3)
                    {
                        eight_three.interactable = true;
                    }
                    else if (j == 4)
                    {
                        eight_four.interactable = true;
                    }
                    else if (j == 5)
                    {
                        eight_five.interactable = true;
                    }
                    else if (j == 6)
                    {
                        eight_six.interactable = true;
                    }
                    else if (j == 7)
                    {
                        eight_seven.interactable = true;
                    }
                    else
                    {
                        eight_eight.interactable = true;
                    }
                }

            }
        }
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] < 0)
                {
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            zero_zero.interactable = false;
                        }
                        else if (j == 1)
                        {
                            zero_one.interactable = false;
                        }
                        else if (j == 2)
                        {
                            zero_two.interactable = false;
                        }
                        else if (j == 3)
                        {
                            zero_three.interactable = false;
                        }
                        else if (j == 4)
                        {
                            zero_four.interactable = false;
                        }
                        else if (j == 5)
                        {
                            zero_five.interactable = false;
                        }
                        else if (j == 6)
                        {
                            zero_six.interactable = false;
                        }
                        else if (j == 7)
                        {
                            zero_seven.interactable = false;
                        }
                        else
                        {
                            zero_eight.interactable = false;
                        }
                    }
                    else if (i == 1)
                    {
                        if (j == 0)
                        {
                            one_zero.interactable = false;
                        }
                        else if (j == 1)
                        {
                            one_one.interactable = false;
                        }
                        else if (j == 2)
                        {
                            one_two.interactable = false;
                        }
                        else if (j == 3)
                        {
                            one_three.interactable = false;
                        }
                        else if (j == 4)
                        {
                            one_four.interactable = false;
                        }
                        else if (j == 5)
                        {
                            one_five.interactable = false;
                        }
                        else if (j == 6)
                        {
                            one_six.interactable = false;
                        }
                        else if (j == 7)
                        {
                            one_seven.interactable = false;
                        }
                        else
                        {
                            one_eight.interactable = false;
                        }
                    }
                    else if (i == 2)
                    {
                        if (j == 0)
                        {
                            two_zero.interactable = false;
                        }
                        else if (j == 1)
                        {
                            two_one.interactable = false;
                        }
                        else if (j == 2)
                        {
                            two_two.interactable = false;
                        }
                        else if (j == 3)
                        {
                            two_three.interactable = false;
                        }
                        else if (j == 4)
                        {
                            two_four.interactable = false;
                        }
                        else if (j == 5)
                        {
                            two_five.interactable = false;
                        }
                        else if (j == 6)
                        {
                            two_six.interactable = false;
                        }
                        else if (j == 7)
                        {
                            two_seven.interactable = false;
                        }
                        else
                        {
                            two_eight.interactable = false;
                        }
                    }
                    else if (i == 3)
                    {
                        if (j == 0)
                        {
                            three_zero.interactable = false;
                        }
                        else if (j == 1)
                        {
                            three_one.interactable = false;
                        }
                        else if (j == 2)
                        {
                            three_two.interactable = false;
                        }
                        else if (j == 3)
                        {
                            three_three.interactable = false;
                        }
                        else if (j == 4)
                        {
                            three_four.interactable = false;
                        }
                        else if (j == 5)
                        {
                            three_five.interactable = false;
                        }
                        else if (j == 6)
                        {
                            three_six.interactable = false;
                        }
                        else if (j == 7)
                        {
                            three_seven.interactable = false;
                        }
                        else
                        {
                            three_eight.interactable = false;
                        }
                    }
                    else if (i == 4)
                    {
                        if (j == 0)
                        {
                            four_zero.interactable = false;
                        }
                        else if (j == 1)
                        {
                            four_one.interactable = false;
                        }
                        else if (j == 2)
                        {
                            four_two.interactable = false;
                        }
                        else if (j == 3)
                        {
                            four_three.interactable = false;
                        }
                        else if (j == 4)
                        {
                            four_four.interactable = false;
                        }
                        else if (j == 5)
                        {
                            four_five.interactable = false;
                        }
                        else if (j == 6)
                        {
                            four_six.interactable = false;
                        }
                        else if (j == 7)
                        {
                            four_seven.interactable = false;
                        }
                        else
                        {
                            four_eight.interactable = false;
                        }
                    }
                    else if (i == 5)
                    {
                        if (j == 0)
                        {
                            five_zero.interactable = false;
                        }
                        else if (j == 1)
                        {
                            five_one.interactable = false;
                        }
                        else if (j == 2)
                        {
                            five_two.interactable = false;
                        }
                        else if (j == 3)
                        {
                            five_three.interactable = false;
                        }
                        else if (j == 4)
                        {
                            five_four.interactable = false;
                        }
                        else if (j == 5)
                        {
                            five_five.interactable = false;
                        }
                        else if (j == 6)
                        {
                            five_six.interactable = false;
                        }
                        else if (j == 7)
                        {
                            five_seven.interactable = false;
                        }
                        else
                        {
                            five_eight.interactable = false;
                        }
                    }
                    else if (i == 6)
                    {
                        if (j == 0)
                        {
                            six_zero.interactable = false;
                        }
                        else if (j == 1)
                        {
                            six_one.interactable = false;
                        }
                        else if (j == 2)
                        {
                            six_two.interactable = false;
                        }
                        else if (j == 3)
                        {
                            six_three.interactable = false;
                        }
                        else if (j == 4)
                        {
                            six_four.interactable = false;
                        }
                        else if (j == 5)
                        {
                            six_five.interactable = false;
                        }
                        else if (j == 6)
                        {
                            six_six.interactable = false;
                        }
                        else if (j == 7)
                        {
                            six_seven.interactable = false;
                        }
                        else
                        {
                            six_eight.interactable = false;
                        }
                    }
                    else if (i == 7)
                    {
                        if (j == 0)
                        {
                            seven_zero.interactable = false;
                        }
                        else if (j == 1)
                        {
                            seven_one.interactable = false;
                        }
                        else if (j == 2)
                        {
                            seven_two.interactable = false;
                        }
                        else if (j == 3)
                        {
                            seven_three.interactable = false;
                        }
                        else if (j == 4)
                        {
                            seven_four.interactable = false;
                        }
                        else if (j == 5)
                        {
                            seven_five.interactable = false;
                        }
                        else if (j == 6)
                        {
                            seven_six.interactable = false;
                        }
                        else if (j == 7)
                        {
                            seven_seven.interactable = false;
                        }
                        else
                        {
                            seven_eight.interactable = false;
                        }
                    }
                    else
                    {
                        if (j == 0)
                        {
                            eight_zero.interactable = false;
                        }
                        else if (j == 1)
                        {
                            eight_one.interactable = false;
                        }
                        else if (j == 2)
                        {
                            eight_two.interactable = false;
                        }
                        else if (j == 3)
                        {
                            eight_three.interactable = false;
                        }
                        else if (j == 4)
                        {
                            eight_four.interactable = false;
                        }
                        else if (j == 5)
                        {
                            eight_five.interactable = false;
                        }
                        else if (j == 6)
                        {
                            eight_six.interactable = false;
                        }
                        else if (j == 7)
                        {
                            eight_seven.interactable = false;
                        }
                        else
                        {
                            eight_eight.interactable = false;
                        }
                    }
                }
            }
        }
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (i == 0)
                {
                    if (j == 0)
                    {
                        ColorBlock cb = zero_zero.colors;
                        cb.normalColor = Color.white;
                        zero_zero.colors = cb;
                    }
                    else if (j == 1)
                    {
                        ColorBlock cb = zero_one.colors;
                        cb.normalColor = Color.white;
                        zero_one.colors = cb;
                    }
                    else if (j == 2)
                    {
                        ColorBlock cb = zero_two.colors;
                        cb.normalColor = Color.white;
                        zero_two.colors = cb;
                    }
                    else if (j == 3)
                    {
                        ColorBlock cb = zero_three.colors;
                        cb.normalColor = Color.white;
                        zero_three.colors = cb;
                    }
                    else if (j == 4)
                    {
                        ColorBlock cb = zero_four.colors;
                        cb.normalColor = Color.white;
                        zero_four.colors = cb;
                    }
                    else if (j == 5)
                    {
                        ColorBlock cb = zero_five.colors;
                        cb.normalColor = Color.white;
                        zero_five.colors = cb;
                    }
                    else if (j == 6)
                    {
                        ColorBlock cb = zero_six.colors;
                        cb.normalColor = Color.white;
                        zero_six.colors = cb;
                    }
                    else if (j == 7)
                    {
                        ColorBlock cb = zero_seven.colors;
                        cb.normalColor = Color.white;
                        zero_seven.colors = cb;
                    }
                    else
                    {
                        ColorBlock cb = zero_eight.colors;
                        cb.normalColor = Color.white;
                        zero_eight.colors = cb;
                    }
                }
                else if (i == 1)
                {
                    if (j == 0)
                    {
                        ColorBlock cb = one_zero.colors;
                        cb.normalColor = Color.white;
                        one_zero.colors = cb;
                    }
                    else if (j == 1)
                    {
                        ColorBlock cb = one_one.colors;
                        cb.normalColor = Color.white;
                        one_one.colors = cb;
                    }
                    else if (j == 2)
                    {
                        ColorBlock cb = one_two.colors;
                        cb.normalColor = Color.white;
                        one_two.colors = cb;
                    }
                    else if (j == 3)
                    {
                        ColorBlock cb = one_three.colors;
                        cb.normalColor = Color.white;
                        one_three.colors = cb;
                    }
                    else if (j == 4)
                    {
                        ColorBlock cb = one_four.colors;
                        cb.normalColor = Color.white;
                        one_four.colors = cb;
                    }
                    else if (j == 5)
                    {
                        ColorBlock cb = one_five.colors;
                        cb.normalColor = Color.white;
                        one_five.colors = cb;
                    }
                    else if (j == 6)
                    {
                        ColorBlock cb = one_six.colors;
                        cb.normalColor = Color.white;
                        one_six.colors = cb;
                    }
                    else if (j == 7)
                    {
                        ColorBlock cb = one_seven.colors;
                        cb.normalColor = Color.white;
                        one_seven.colors = cb;
                    }
                    else
                    {
                        ColorBlock cb = one_eight.colors;
                        cb.normalColor = Color.white;
                        one_eight.colors = cb;
                    }
                }
                else if (i == 2)
                {
                    if (j == 0)
                    {
                        ColorBlock cb = two_zero.colors;
                        cb.normalColor = Color.white;
                        two_zero.colors = cb;
                    }
                    else if (j == 1)
                    {
                        ColorBlock cb = two_one.colors;
                        cb.normalColor = Color.white;
                        two_one.colors = cb;
                    }
                    else if (j == 2)
                    {
                        ColorBlock cb = two_two.colors;
                        cb.normalColor = Color.white;
                        two_two.colors = cb;
                    }
                    else if (j == 3)
                    {
                        ColorBlock cb = two_three.colors;
                        cb.normalColor = Color.white;
                        two_three.colors = cb;
                    }
                    else if (j == 4)
                    {
                        ColorBlock cb = two_four.colors;
                        cb.normalColor = Color.white;
                        two_four.colors = cb;
                    }
                    else if (j == 5)
                    {
                        ColorBlock cb = two_five.colors;
                        cb.normalColor = Color.white;
                        two_five.colors = cb;
                    }
                    else if (j == 6)
                    {
                        ColorBlock cb = two_six.colors;
                        cb.normalColor = Color.white;
                        two_six.colors = cb;
                    }
                    else if (j == 7)
                    {
                        ColorBlock cb = two_seven.colors;
                        cb.normalColor = Color.white;
                        two_seven.colors = cb;
                    }
                    else
                    {
                        ColorBlock cb = two_eight.colors;
                        cb.normalColor = Color.white;
                        two_eight.colors = cb;
                    }
                }
                else if (i == 3)
                {
                    if (j == 0)
                    {
                        ColorBlock cb = three_zero.colors;
                        cb.normalColor = Color.white;
                        three_zero.colors = cb;
                    }
                    else if (j == 1)
                    {
                        ColorBlock cb = three_one.colors;
                        cb.normalColor = Color.white;
                        three_one.colors = cb;
                    }
                    else if (j == 2)
                    {
                        ColorBlock cb = three_two.colors;
                        cb.normalColor = Color.white;
                        three_two.colors = cb;
                    }
                    else if (j == 3)
                    {
                        ColorBlock cb = three_three.colors;
                        cb.normalColor = Color.white;
                        three_three.colors = cb;
                    }
                    else if (j == 4)
                    {
                        ColorBlock cb = three_four.colors;
                        cb.normalColor = Color.white;
                        three_four.colors = cb;
                    }
                    else if (j == 5)
                    {
                        ColorBlock cb = three_five.colors;
                        cb.normalColor = Color.white;
                        three_five.colors = cb;
                    }
                    else if (j == 6)
                    {
                        ColorBlock cb = three_six.colors;
                        cb.normalColor = Color.white;
                        three_six.colors = cb;
                    }
                    else if (j == 7)
                    {
                        ColorBlock cb = three_seven.colors;
                        cb.normalColor = Color.white;
                        three_seven.colors = cb;
                    }
                    else
                    {
                        ColorBlock cb = three_eight.colors;
                        cb.normalColor = Color.white;
                        three_eight.colors = cb;
                    }
                }
                else if (i == 4)
                {
                    if (j == 0)
                    {
                        ColorBlock cb = four_zero.colors;
                        cb.normalColor = Color.white;
                        four_zero.colors = cb;
                    }
                    else if (j == 1)
                    {
                        ColorBlock cb = four_one.colors;
                        cb.normalColor = Color.white;
                        four_one.colors = cb;
                    }
                    else if (j == 2)
                    {
                        ColorBlock cb = four_two.colors;
                        cb.normalColor = Color.white;
                        four_two.colors = cb;
                    }
                    else if (j == 3)
                    {
                        ColorBlock cb = four_three.colors;
                        cb.normalColor = Color.white;
                        four_three.colors = cb;
                    }
                    else if (j == 4)
                    {
                        ColorBlock cb = four_four.colors;
                        cb.normalColor = Color.white;
                        four_four.colors = cb;
                    }
                    else if (j == 5)
                    {
                        ColorBlock cb = four_five.colors;
                        cb.normalColor = Color.white;
                        four_five.colors = cb;
                    }
                    else if (j == 6)
                    {
                        ColorBlock cb = four_six.colors;
                        cb.normalColor = Color.white;
                        four_six.colors = cb;
                    }
                    else if (j == 7)
                    {
                        ColorBlock cb = four_seven.colors;
                        cb.normalColor = Color.white;
                        four_seven.colors = cb;
                    }
                    else
                    {
                        ColorBlock cb = four_eight.colors;
                        cb.normalColor = Color.white;
                        four_eight.colors = cb;
                    }
                }
                else if (i == 5)
                {
                    if (j == 0)
                    {
                        ColorBlock cb = five_zero.colors;
                        cb.normalColor = Color.white;
                        five_zero.colors = cb;
                    }
                    else if (j == 1)
                    {
                        ColorBlock cb = five_one.colors;
                        cb.normalColor = Color.white;
                        five_one.colors = cb;
                    }
                    else if (j == 2)
                    {
                        ColorBlock cb = five_two.colors;
                        cb.normalColor = Color.white;
                        five_two.colors = cb;
                    }
                    else if (j == 3)
                    {
                        ColorBlock cb = five_three.colors;
                        cb.normalColor = Color.white;
                        five_three.colors = cb;
                    }
                    else if (j == 4)
                    {
                        ColorBlock cb = five_four.colors;
                        cb.normalColor = Color.white;
                        five_four.colors = cb;
                    }
                    else if (j == 5)
                    {
                        ColorBlock cb = five_five.colors;
                        cb.normalColor = Color.white;
                        five_five.colors = cb;
                    }
                    else if (j == 6)
                    {
                        ColorBlock cb = five_six.colors;
                        cb.normalColor = Color.white;
                        five_six.colors = cb;
                    }
                    else if (j == 7)
                    {
                        ColorBlock cb = five_seven.colors;
                        cb.normalColor = Color.white;
                        five_seven.colors = cb;
                    }
                    else
                    {
                        ColorBlock cb = five_eight.colors;
                        cb.normalColor = Color.white;
                        five_eight.colors = cb;
                    }
                }
                else if (i == 6)
                {
                    if (j == 0)
                    {
                        ColorBlock cb = six_zero.colors;
                        cb.normalColor = Color.white;
                        six_zero.colors = cb;
                    }
                    else if (j == 1)
                    {
                        ColorBlock cb = six_one.colors;
                        cb.normalColor = Color.white;
                        six_one.colors = cb;
                    }
                    else if (j == 2)
                    {
                        ColorBlock cb = six_two.colors;
                        cb.normalColor = Color.white;
                        six_two.colors = cb;
                    }
                    else if (j == 3)
                    {
                        ColorBlock cb = six_three.colors;
                        cb.normalColor = Color.white;
                        six_three.colors = cb;
                    }
                    else if (j == 4)
                    {
                        ColorBlock cb = six_four.colors;
                        cb.normalColor = Color.white;
                        six_four.colors = cb;
                    }
                    else if (j == 5)
                    {
                        ColorBlock cb = six_five.colors;
                        cb.normalColor = Color.white;
                        six_five.colors = cb;
                    }
                    else if (j == 6)
                    {
                        ColorBlock cb = six_six.colors;
                        cb.normalColor = Color.white;
                        six_six.colors = cb;
                    }
                    else if (j == 7)
                    {
                        ColorBlock cb = six_seven.colors;
                        cb.normalColor = Color.white;
                        six_seven.colors = cb;
                    }
                    else
                    {
                        ColorBlock cb = six_eight.colors;
                        cb.normalColor = Color.white;
                        six_eight.colors = cb;
                    }
                }
                else if (i == 7)
                {
                    if (j == 0)
                    {
                        ColorBlock cb = seven_zero.colors;
                        cb.normalColor = Color.white;
                        seven_zero.colors = cb;
                    }
                    else if (j == 1)
                    {
                        ColorBlock cb = seven_one.colors;
                        cb.normalColor = Color.white;
                        seven_one.colors = cb;
                    }
                    else if (j == 2)
                    {
                        ColorBlock cb = seven_two.colors;
                        cb.normalColor = Color.white;
                        seven_two.colors = cb;
                    }
                    else if (j == 3)
                    {
                        ColorBlock cb = seven_three.colors;
                        cb.normalColor = Color.white;
                        seven_three.colors = cb;
                    }
                    else if (j == 4)
                    {
                        ColorBlock cb = seven_four.colors;
                        cb.normalColor = Color.white;
                        seven_four.colors = cb;
                    }
                    else if (j == 5)
                    {
                        ColorBlock cb = seven_five.colors;
                        cb.normalColor = Color.white;
                        seven_five.colors = cb;
                    }
                    else if (j == 6)
                    {
                        ColorBlock cb = seven_six.colors;
                        cb.normalColor = Color.white;
                        seven_six.colors = cb;
                    }
                    else if (j == 7)
                    {
                        ColorBlock cb = seven_seven.colors;
                        cb.normalColor = Color.white;
                        seven_seven.colors = cb;
                    }
                    else
                    {
                        ColorBlock cb = seven_eight.colors;
                        cb.normalColor = Color.white;
                        seven_eight.colors = cb;
                    }
                }
                else
                {
                    if (j == 0)
                    {
                        ColorBlock cb = eight_zero.colors;
                        cb.normalColor = Color.white;
                        eight_zero.colors = cb;
                    }
                    else if (j == 1)
                    {
                        ColorBlock cb = eight_one.colors;
                        cb.normalColor = Color.white;
                        eight_one.colors = cb;
                    }
                    else if (j == 2)
                    {
                        ColorBlock cb = eight_two.colors;
                        cb.normalColor = Color.white;
                        eight_two.colors = cb;
                    }
                    else if (j == 3)
                    {
                        ColorBlock cb = eight_three.colors;
                        cb.normalColor = Color.white;
                        eight_three.colors = cb;
                    }
                    else if (j == 4)
                    {
                        ColorBlock cb = eight_four.colors;
                        cb.normalColor = Color.white;
                        eight_four.colors = cb;
                    }
                    else if (j == 5)
                    {
                        ColorBlock cb = eight_five.colors;
                        cb.normalColor = Color.white;
                        eight_five.colors = cb;
                    }
                    else if (j == 6)
                    {
                        ColorBlock cb = eight_six.colors;
                        cb.normalColor = Color.white;
                        eight_six.colors = cb;
                    }
                    else if (j == 7)
                    {
                        ColorBlock cb = eight_seven.colors;
                        cb.normalColor = Color.white;
                        eight_seven.colors = cb;
                    }
                    else
                    {
                        ColorBlock cb = eight_eight.colors;
                        cb.normalColor = Color.white;
                        eight_eight.colors = cb;
                    }
                }
                //Debug.Log(string_board);
            }
        }



        // Tests
		test_valid_rowcol();
        test_valid_33();
        test_valid_all();
        test_create_board();
        test_convert_board_to_string();
        test_is_permanent_square();
        test_set_square();
        test_clear_entries();
        test_read_file();
        test_save();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Class Update Called");

        //txt.text = string_board;
        print_board();
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
        zero_zero.text = Convert.ToString(Math.Abs(board[0, 0]));
        zero_one.text = Convert.ToString(Math.Abs(board[0, 1]));
        zero_two.text = Convert.ToString(Math.Abs(board[0, 2]));
        zero_three.text = Convert.ToString(Math.Abs(board[0, 3]));
        zero_four.text = Convert.ToString(Math.Abs(board[0, 4]));
        zero_five.text = Convert.ToString(Math.Abs(board[0, 5]));
        zero_six.text = Convert.ToString(Math.Abs(board[0, 6]));
        zero_seven.text = Convert.ToString(Math.Abs(board[0, 7]));
        zero_eight.text = Convert.ToString(Math.Abs(board[0, 8]));
        one_zero.text = Convert.ToString(Math.Abs(board[1, 0]));
        one_one.text = Convert.ToString(Math.Abs(board[1, 1]));
        one_two.text = Convert.ToString(Math.Abs(board[1, 2]));
        one_three.text = Convert.ToString(Math.Abs(board[1, 3]));
        one_four.text = Convert.ToString(Math.Abs(board[1, 4]));
        one_five.text = Convert.ToString(Math.Abs(board[1, 5]));
        one_six.text = Convert.ToString(Math.Abs(board[1, 6]));
        one_seven.text = Convert.ToString(Math.Abs(board[1, 7]));
        one_eight.text = Convert.ToString(Math.Abs(board[1, 8]));
        two_zero.text = Convert.ToString(Math.Abs(board[2, 0]));
        two_one.text = Convert.ToString(Math.Abs(board[2, 1]));
        two_two.text = Convert.ToString(Math.Abs(board[2, 2]));
        two_three.text = Convert.ToString(Math.Abs(board[2, 3]));
        two_four.text = Convert.ToString(Math.Abs(board[2, 4]));
        two_five.text = Convert.ToString(Math.Abs(board[2, 5]));
        two_six.text = Convert.ToString(Math.Abs(board[2, 6]));
        two_seven.text = Convert.ToString(Math.Abs(board[2, 7]));
        two_eight.text = Convert.ToString(Math.Abs(board[2, 8]));
        three_zero.text = Convert.ToString(Math.Abs(board[3, 0]));
        three_one.text = Convert.ToString(Math.Abs(board[3, 1]));
        three_two.text = Convert.ToString(Math.Abs(board[3, 2]));
        three_three.text = Convert.ToString(Math.Abs(board[3, 3]));
        three_four.text = Convert.ToString(Math.Abs(board[3, 4]));
        three_five.text = Convert.ToString(Math.Abs(board[3, 5]));
        three_six.text = Convert.ToString(Math.Abs(board[3, 6]));
        three_seven.text = Convert.ToString(Math.Abs(board[3, 7]));
        three_eight.text = Convert.ToString(Math.Abs(board[3, 8]));
        four_zero.text = Convert.ToString(Math.Abs(board[4, 0]));
        four_one.text = Convert.ToString(Math.Abs(board[4, 1]));
        four_two.text = Convert.ToString(Math.Abs(board[4, 2]));
        four_three.text = Convert.ToString(Math.Abs(board[4, 3]));
        four_four.text = Convert.ToString(Math.Abs(board[4, 4]));
        four_five.text = Convert.ToString(Math.Abs(board[4, 5]));
        four_six.text = Convert.ToString(Math.Abs(board[4, 6]));
        four_seven.text = Convert.ToString(Math.Abs(board[4, 7]));
        four_eight.text = Convert.ToString(Math.Abs(board[4, 8]));
        five_zero.text = Convert.ToString(Math.Abs(board[5, 0]));
        five_one.text = Convert.ToString(Math.Abs(board[5, 1]));
        five_two.text = Convert.ToString(Math.Abs(board[5, 2]));
        five_three.text = Convert.ToString(Math.Abs(board[5, 3]));
        five_four.text = Convert.ToString(Math.Abs(board[5, 4]));
        five_five.text = Convert.ToString(Math.Abs(board[5, 5]));
        five_six.text = Convert.ToString(Math.Abs(board[5, 6]));
        five_seven.text = Convert.ToString(Math.Abs(board[5, 7]));
        five_eight.text = Convert.ToString(Math.Abs(board[5, 8]));
        six_zero.text = Convert.ToString(Math.Abs(board[6, 0]));
        six_one.text = Convert.ToString(Math.Abs(board[6, 1]));
        six_two.text = Convert.ToString(Math.Abs(board[6, 2]));
        six_three.text = Convert.ToString(Math.Abs(board[6, 3]));
        six_four.text = Convert.ToString(Math.Abs(board[6, 4]));
        six_five.text = Convert.ToString(Math.Abs(board[6, 5]));
        six_six.text = Convert.ToString(Math.Abs(board[6, 6]));
        six_seven.text = Convert.ToString(Math.Abs(board[6, 7]));
        six_eight.text = Convert.ToString(Math.Abs(board[6, 8]));
        seven_zero.text = Convert.ToString(Math.Abs(board[7, 0]));
        seven_one.text = Convert.ToString(Math.Abs(board[7, 1]));
        seven_two.text = Convert.ToString(Math.Abs(board[7, 2]));
        seven_three.text = Convert.ToString(Math.Abs(board[7, 3]));
        seven_four.text = Convert.ToString(Math.Abs(board[7, 4]));
        seven_five.text = Convert.ToString(Math.Abs(board[7, 5]));
        seven_six.text = Convert.ToString(Math.Abs(board[7, 6]));
        seven_seven.text = Convert.ToString(Math.Abs(board[7, 7]));
        seven_eight.text = Convert.ToString(Math.Abs(board[7, 8]));
        eight_zero.text = Convert.ToString(Math.Abs(board[8, 0]));
        eight_one.text = Convert.ToString(Math.Abs(board[8, 1]));
        eight_two.text = Convert.ToString(Math.Abs(board[8, 2]));
        eight_three.text = Convert.ToString(Math.Abs(board[8, 3]));
        eight_four.text = Convert.ToString(Math.Abs(board[8, 4]));
        eight_five.text = Convert.ToString(Math.Abs(board[8, 5]));
        eight_six.text = Convert.ToString(Math.Abs(board[8, 6]));
        eight_seven.text = Convert.ToString(Math.Abs(board[8, 7]));
        eight_eight.text = Convert.ToString(Math.Abs(board[8, 8]));
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
            if (i < board.GetLength(0) - 1)
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
        //Debug.Log("changed");
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

    public void change_entry(string place)
    {
        //Debug.Log("change entry");
        string[] splitted = place.Split(' ');
        int row = Convert.ToInt32(splitted[0]);
        int col = Convert.ToInt32(splitted[1]);
        int val;
        if (row == 0)
        {
            if (col == 0)
            {
                val = Convert.ToInt32(zero_zero.text);
            }
            else if (col == 1)
            {
                val = Convert.ToInt32(zero_one.text);
            }
            else if (col == 2)
            {
                val = Convert.ToInt32(zero_two.text);
            }
            else if (col == 3)
            {
                val = Convert.ToInt32(zero_three.text);
            }
            else if (col == 4)
            {
                val = Convert.ToInt32(zero_four.text);
            }
            else if (col == 5)
            {
                val = Convert.ToInt32(zero_five.text);
            }
            else if (col == 6)
            {
                val = Convert.ToInt32(zero_six.text);
            }
            else if (col == 7)
            {
                val = Convert.ToInt32(zero_seven.text);
            }
            else
            {
                val = Convert.ToInt32(zero_eight.text);
            }
        }
        else if (row == 1)
        {
            if (col == 0)
            {
                val = Convert.ToInt32(one_zero.text);
            }
            else if (col == 1)
            {
                val = Convert.ToInt32(one_one.text);
            }
            else if (col == 2)
            {
                val = Convert.ToInt32(one_two.text);
            }
            else if (col == 3)
            {
                val = Convert.ToInt32(one_three.text);
            }
            else if (col == 4)
            {
                val = Convert.ToInt32(one_four.text);
            }
            else if (col == 5)
            {
                val = Convert.ToInt32(one_five.text);
            }
            else if (col == 6)
            {
                val = Convert.ToInt32(one_six.text);
            }
            else if (col == 7)
            {
                val = Convert.ToInt32(one_seven.text);
            }
            else
            {
                val = Convert.ToInt32(one_eight.text);
            }
        }
        else if (row == 2)
        {
            if (col == 0)
            {
                val = Convert.ToInt32(two_zero.text);
            }
            else if (col == 1)
            {
                val = Convert.ToInt32(two_one.text);
            }
            else if (col == 2)
            {
                val = Convert.ToInt32(two_two.text);
            }
            else if (col == 3)
            {
                val = Convert.ToInt32(two_three.text);
            }
            else if (col == 4)
            {
                val = Convert.ToInt32(two_four.text);
            }
            else if (col == 5)
            {
                val = Convert.ToInt32(two_five.text);
            }
            else if (col == 6)
            {
                val = Convert.ToInt32(two_six.text);
            }
            else if (col == 7)
            {
                val = Convert.ToInt32(two_seven.text);
            }
            else
            {
                val = Convert.ToInt32(two_eight.text);
            }
        }
        else if (row == 3)
        {
            if (col == 0)
            {
                val = Convert.ToInt32(three_zero.text);
            }
            else if (col == 1)
            {
                val = Convert.ToInt32(three_one.text);
            }
            else if (col == 2)
            {
                val = Convert.ToInt32(three_two.text);
            }
            else if (col == 3)
            {
                val = Convert.ToInt32(three_three.text);
            }
            else if (col == 4)
            {
                val = Convert.ToInt32(three_four.text);
            }
            else if (col == 5)
            {
                val = Convert.ToInt32(three_five.text);
            }
            else if (col == 6)
            {
                val = Convert.ToInt32(three_six.text);
            }
            else if (col == 7)
            {
                val = Convert.ToInt32(three_seven.text);
            }
            else
            {
                val = Convert.ToInt32(three_eight.text);
            }
        }
        else if (row == 4)
        {
            if (col == 0)
            {
                val = Convert.ToInt32(four_zero.text);
            }
            else if (col == 1)
            {
                val = Convert.ToInt32(four_one.text);
            }
            else if (col == 2)
            {
                val = Convert.ToInt32(four_two.text);
            }
            else if (col == 3)
            {
                val = Convert.ToInt32(four_three.text);
            }
            else if (col == 4)
            {
                val = Convert.ToInt32(four_four.text);
            }
            else if (col == 5)
            {
                val = Convert.ToInt32(four_five.text);
            }
            else if (col == 6)
            {
                val = Convert.ToInt32(four_six.text);
            }
            else if (col == 7)
            {
                val = Convert.ToInt32(four_seven.text);
            }
            else
            {
                val = Convert.ToInt32(four_eight.text);
            }
        }
        else if (row == 5)
        {
            if (col == 0)
            {
                val = Convert.ToInt32(five_zero.text);
            }
            else if (col == 1)
            {
                val = Convert.ToInt32(five_one.text);
            }
            else if (col == 2)
            {
                val = Convert.ToInt32(five_two.text);
            }
            else if (col == 3)
            {
                val = Convert.ToInt32(five_three.text);
            }
            else if (col == 4)
            {
                val = Convert.ToInt32(five_four.text);
            }
            else if (col == 5)
            {
                val = Convert.ToInt32(five_five.text);
            }
            else if (col == 6)
            {
                val = Convert.ToInt32(five_six.text);
            }
            else if (col == 7)
            {
                val = Convert.ToInt32(five_seven.text);
            }
            else
            {
                val = Convert.ToInt32(five_eight.text);
            }
        }
        else if (row == 6)
        {
            if (col == 0)
            {
                val = Convert.ToInt32(six_zero.text);
            }
            else if (col == 1)
            {
                val = Convert.ToInt32(six_one.text);
            }
            else if (col == 2)
            {
                val = Convert.ToInt32(six_two.text);
            }
            else if (col == 3)
            {
                val = Convert.ToInt32(six_three.text);
            }
            else if (col == 4)
            {
                val = Convert.ToInt32(six_four.text);
            }
            else if (col == 5)
            {
                val = Convert.ToInt32(six_five.text);
            }
            else if (col == 6)
            {
                val = Convert.ToInt32(six_six.text);
            }
            else if (col == 7)
            {
                val = Convert.ToInt32(six_seven.text);
            }
            else
            {
                val = Convert.ToInt32(six_eight.text);
            }
        }
        else if (row == 7)
        {
            if (col == 0)
            {
                val = Convert.ToInt32(seven_zero.text);
            }
            else if (col == 1)
            {
                val = Convert.ToInt32(seven_one.text);
            }
            else if (col == 2)
            {
                val = Convert.ToInt32(seven_two.text);
            }
            else if (col == 3)
            {
                val = Convert.ToInt32(seven_three.text);
            }
            else if (col == 4)
            {
                val = Convert.ToInt32(seven_four.text);
            }
            else if (col == 5)
            {
                val = Convert.ToInt32(seven_five.text);
            }
            else if (col == 6)
            {
                val = Convert.ToInt32(seven_six.text);
            }
            else if (col == 7)
            {
                val = Convert.ToInt32(seven_seven.text);
            }
            else
            {
                val = Convert.ToInt32(seven_eight.text);
            }
        }
        else
        {
            if (col == 0)
            {
                val = Convert.ToInt32(eight_zero.text);
            }
            else if (col == 1)
            {
                val = Convert.ToInt32(eight_one.text);
            }
            else if (col == 2)
            {
                val = Convert.ToInt32(eight_two.text);
            }
            else if (col == 3)
            {
                val = Convert.ToInt32(eight_three.text);
            }
            else if (col == 4)
            {
                val = Convert.ToInt32(eight_four.text);
            }
            else if (col == 5)
            {
                val = Convert.ToInt32(eight_five.text);
            }
            else if (col == 6)
            {
                val = Convert.ToInt32(eight_six.text);
            }
            else if (col == 7)
            {
                val = Convert.ToInt32(eight_seven.text);
            }
            else
            {
                val = Convert.ToInt32(eight_eight.text);
            }
        }
        change = false;
        //int row, col, val;
        //row = int.Parse(first_int.text);
        //col = Convert.ToInt32(second_int.text);
        //int val = Convert.ToInt32(third_int.text);
        //Debug.Log(row);
        // Debug.Log(col);
        // Debug.Log(val);
        if (0 <= row && row <= 9)
        {
            if (0 <= col && col <= 9)
            {
                if (0 <= val && val <= 9)
                {
                    error = false;
                    setSquare(row, col, val);
                    int[,] validation = Validate();
                    for (int i = 0; i < validation.GetLength(0); i++)
                    {
                        for (int j = 0; j < validation.GetLength(1); j++)
                        {
                            if (validation[i, j] == 1 && board[i, j] > 0)
                            {
                                if (i == 0)
                                {
                                    if (j == 0)
                                    {
                                        ColorBlock cb = zero_zero.colors;
                                        cb.normalColor = Color.red;
                                        zero_zero.colors = cb;
                                    }
                                    else if (j == 1)
                                    {
                                        ColorBlock cb = zero_one.colors;
                                        cb.normalColor = Color.red;
                                        zero_one.colors = cb;
                                    }
                                    else if (j == 2)
                                    {
                                        ColorBlock cb = zero_two.colors;
                                        cb.normalColor = Color.red;
                                        zero_two.colors = cb;
                                    }
                                    else if (j == 3)
                                    {
                                        ColorBlock cb = zero_three.colors;
                                        cb.normalColor = Color.red;
                                        zero_three.colors = cb;
                                    }
                                    else if (j == 4)
                                    {
                                        ColorBlock cb = zero_four.colors;
                                        cb.normalColor = Color.red;
                                        zero_four.colors = cb;
                                    }
                                    else if (j == 5)
                                    {
                                        ColorBlock cb = zero_five.colors;
                                        cb.normalColor = Color.red;
                                        zero_five.colors = cb;
                                    }
                                    else if (j == 6)
                                    {
                                        ColorBlock cb = zero_six.colors;
                                        cb.normalColor = Color.red;
                                        zero_six.colors = cb;
                                    }
                                    else if (j == 7)
                                    {
                                        ColorBlock cb = zero_seven.colors;
                                        cb.normalColor = Color.red;
                                        zero_seven.colors = cb;
                                    }
                                    else
                                    {
                                        ColorBlock cb = zero_eight.colors;
                                        cb.normalColor = Color.red;
                                        zero_eight.colors = cb;
                                    }
                                }
                                else if (i == 1)
                                {
                                    if (j == 0)
                                    {
                                        ColorBlock cb = one_zero.colors;
                                        cb.normalColor = Color.red;
                                        one_zero.colors = cb;
                                    }
                                    else if (j == 1)
                                    {
                                        ColorBlock cb = one_one.colors;
                                        cb.normalColor = Color.red;
                                        one_one.colors = cb;
                                    }
                                    else if (j == 2)
                                    {
                                        ColorBlock cb = one_two.colors;
                                        cb.normalColor = Color.red;
                                        one_two.colors = cb;
                                    }
                                    else if (j == 3)
                                    {
                                        ColorBlock cb = one_three.colors;
                                        cb.normalColor = Color.red;
                                        one_three.colors = cb;
                                    }
                                    else if (j == 4)
                                    {
                                        ColorBlock cb = one_four.colors;
                                        cb.normalColor = Color.red;
                                        one_four.colors = cb;
                                    }
                                    else if (j == 5)
                                    {
                                        ColorBlock cb = one_five.colors;
                                        cb.normalColor = Color.red;
                                        one_five.colors = cb;
                                    }
                                    else if (j == 6)
                                    {
                                        ColorBlock cb = one_six.colors;
                                        cb.normalColor = Color.red;
                                        one_six.colors = cb;
                                    }
                                    else if (j == 7)
                                    {
                                        ColorBlock cb = one_seven.colors;
                                        cb.normalColor = Color.red;
                                        one_seven.colors = cb;
                                    }
                                    else
                                    {
                                        ColorBlock cb = one_eight.colors;
                                        cb.normalColor = Color.red;
                                        one_eight.colors = cb;
                                    }
                                }
                                else if (i == 2)
                                {
                                    if (j == 0)
                                    {
                                        ColorBlock cb = two_zero.colors;
                                        cb.normalColor = Color.red;
                                        two_zero.colors = cb;
                                    }
                                    else if (j == 1)
                                    {
                                        ColorBlock cb = two_one.colors;
                                        cb.normalColor = Color.red;
                                        two_one.colors = cb;
                                    }
                                    else if (j == 2)
                                    {
                                        ColorBlock cb = two_two.colors;
                                        cb.normalColor = Color.red;
                                        two_two.colors = cb;
                                    }
                                    else if (j == 3)
                                    {
                                        ColorBlock cb = two_three.colors;
                                        cb.normalColor = Color.red;
                                        two_three.colors = cb;
                                    }
                                    else if (j == 4)
                                    {
                                        ColorBlock cb = two_four.colors;
                                        cb.normalColor = Color.red;
                                        two_four.colors = cb;
                                    }
                                    else if (j == 5)
                                    {
                                        ColorBlock cb = two_five.colors;
                                        cb.normalColor = Color.red;
                                        two_five.colors = cb;
                                    }
                                    else if (j == 6)
                                    {
                                        ColorBlock cb = two_six.colors;
                                        cb.normalColor = Color.red;
                                        two_six.colors = cb;
                                    }
                                    else if (j == 7)
                                    {
                                        ColorBlock cb = two_seven.colors;
                                        cb.normalColor = Color.red;
                                        two_seven.colors = cb;
                                    }
                                    else
                                    {
                                        ColorBlock cb = two_eight.colors;
                                        cb.normalColor = Color.red;
                                        two_eight.colors = cb;
                                    }
                                }
                                else if (i == 3)
                                {
                                    if (j == 0)
                                    {
                                        ColorBlock cb = three_zero.colors;
                                        cb.normalColor = Color.red;
                                        three_zero.colors = cb;
                                    }
                                    else if (j == 1)
                                    {
                                        ColorBlock cb = three_one.colors;
                                        cb.normalColor = Color.red;
                                        three_one.colors = cb;
                                    }
                                    else if (j == 2)
                                    {
                                        ColorBlock cb = three_two.colors;
                                        cb.normalColor = Color.red;
                                        three_two.colors = cb;
                                    }
                                    else if (j == 3)
                                    {
                                        ColorBlock cb = three_three.colors;
                                        cb.normalColor = Color.red;
                                        three_three.colors = cb;
                                    }
                                    else if (j == 4)
                                    {
                                        ColorBlock cb = three_four.colors;
                                        cb.normalColor = Color.red;
                                        three_four.colors = cb;
                                    }
                                    else if (j == 5)
                                    {
                                        ColorBlock cb = three_five.colors;
                                        cb.normalColor = Color.red;
                                        three_five.colors = cb;
                                    }
                                    else if (j == 6)
                                    {
                                        ColorBlock cb = three_six.colors;
                                        cb.normalColor = Color.red;
                                        three_six.colors = cb;
                                    }
                                    else if (j == 7)
                                    {
                                        ColorBlock cb = three_seven.colors;
                                        cb.normalColor = Color.red;
                                        three_seven.colors = cb;
                                    }
                                    else
                                    {
                                        ColorBlock cb = three_eight.colors;
                                        cb.normalColor = Color.red;
                                        three_eight.colors = cb;
                                    }
                                }
                                else if (i == 4)
                                {
                                    if (j == 0)
                                    {
                                        ColorBlock cb = four_zero.colors;
                                        cb.normalColor = Color.red;
                                        four_zero.colors = cb;
                                    }
                                    else if (j == 1)
                                    {
                                        ColorBlock cb = four_one.colors;
                                        cb.normalColor = Color.red;
                                        four_one.colors = cb;
                                    }
                                    else if (j == 2)
                                    {
                                        ColorBlock cb = four_two.colors;
                                        cb.normalColor = Color.red;
                                        four_two.colors = cb;
                                    }
                                    else if (j == 3)
                                    {
                                        ColorBlock cb = four_three.colors;
                                        cb.normalColor = Color.red;
                                        four_three.colors = cb;
                                    }
                                    else if (j == 4)
                                    {
                                        ColorBlock cb = four_four.colors;
                                        cb.normalColor = Color.red;
                                        four_four.colors = cb;
                                    }
                                    else if (j == 5)
                                    {
                                        ColorBlock cb = four_five.colors;
                                        cb.normalColor = Color.red;
                                        four_five.colors = cb;
                                    }
                                    else if (j == 6)
                                    {
                                        ColorBlock cb = four_six.colors;
                                        cb.normalColor = Color.red;
                                        four_six.colors = cb;
                                    }
                                    else if (j == 7)
                                    {
                                        ColorBlock cb = four_seven.colors;
                                        cb.normalColor = Color.red;
                                        four_seven.colors = cb;
                                    }
                                    else
                                    {
                                        ColorBlock cb = four_eight.colors;
                                        cb.normalColor = Color.red;
                                        four_eight.colors = cb;
                                    }
                                }
                                else if (i == 5)
                                {
                                    if (j == 0)
                                    {
                                        ColorBlock cb = five_zero.colors;
                                        cb.normalColor = Color.red;
                                        five_zero.colors = cb;
                                    }
                                    else if (j == 1)
                                    {
                                        ColorBlock cb = five_one.colors;
                                        cb.normalColor = Color.red;
                                        five_one.colors = cb;
                                    }
                                    else if (j == 2)
                                    {
                                        ColorBlock cb = five_two.colors;
                                        cb.normalColor = Color.red;
                                        five_two.colors = cb;
                                    }
                                    else if (j == 3)
                                    {
                                        ColorBlock cb = five_three.colors;
                                        cb.normalColor = Color.red;
                                        five_three.colors = cb;
                                    }
                                    else if (j == 4)
                                    {
                                        ColorBlock cb = five_four.colors;
                                        cb.normalColor = Color.red;
                                        five_four.colors = cb;
                                    }
                                    else if (j == 5)
                                    {
                                        ColorBlock cb = five_five.colors;
                                        cb.normalColor = Color.red;
                                        five_five.colors = cb;
                                    }
                                    else if (j == 6)
                                    {
                                        ColorBlock cb = five_six.colors;
                                        cb.normalColor = Color.red;
                                        five_six.colors = cb;
                                    }
                                    else if (j == 7)
                                    {
                                        ColorBlock cb = five_seven.colors;
                                        cb.normalColor = Color.red;
                                        five_seven.colors = cb;
                                    }
                                    else
                                    {
                                        ColorBlock cb = five_eight.colors;
                                        cb.normalColor = Color.red;
                                        five_eight.colors = cb;
                                    }
                                }
                                else if (i == 6)
                                {
                                    if (j == 0)
                                    {
                                        ColorBlock cb = six_zero.colors;
                                        cb.normalColor = Color.red;
                                        six_zero.colors = cb;
                                    }
                                    else if (j == 1)
                                    {
                                        ColorBlock cb = six_one.colors;
                                        cb.normalColor = Color.red;
                                        six_one.colors = cb;
                                    }
                                    else if (j == 2)
                                    {
                                        ColorBlock cb = six_two.colors;
                                        cb.normalColor = Color.red;
                                        six_two.colors = cb;
                                    }
                                    else if (j == 3)
                                    {
                                        ColorBlock cb = six_three.colors;
                                        cb.normalColor = Color.red;
                                        six_three.colors = cb;
                                    }
                                    else if (j == 4)
                                    {
                                        ColorBlock cb = six_four.colors;
                                        cb.normalColor = Color.red;
                                        six_four.colors = cb;
                                    }
                                    else if (j == 5)
                                    {
                                        ColorBlock cb = six_five.colors;
                                        cb.normalColor = Color.red;
                                        six_five.colors = cb;
                                    }
                                    else if (j == 6)
                                    {
                                        ColorBlock cb = six_six.colors;
                                        cb.normalColor = Color.red;
                                        six_six.colors = cb;
                                    }
                                    else if (j == 7)
                                    {
                                        ColorBlock cb = six_seven.colors;
                                        cb.normalColor = Color.red;
                                        six_seven.colors = cb;
                                    }
                                    else
                                    {
                                        ColorBlock cb = six_eight.colors;
                                        cb.normalColor = Color.red;
                                        six_eight.colors = cb;
                                    }
                                }
                                else if (i == 7)
                                {
                                    if (j == 0)
                                    {
                                        ColorBlock cb = seven_zero.colors;
                                        cb.normalColor = Color.red;
                                        seven_zero.colors = cb;
                                    }
                                    else if (j == 1)
                                    {
                                        ColorBlock cb = seven_one.colors;
                                        cb.normalColor = Color.red;
                                        seven_one.colors = cb;
                                    }
                                    else if (j == 2)
                                    {
                                        ColorBlock cb = seven_two.colors;
                                        cb.normalColor = Color.red;
                                        seven_two.colors = cb;
                                    }
                                    else if (j == 3)
                                    {
                                        ColorBlock cb = seven_three.colors;
                                        cb.normalColor = Color.red;
                                        seven_three.colors = cb;
                                    }
                                    else if (j == 4)
                                    {
                                        ColorBlock cb = seven_four.colors;
                                        cb.normalColor = Color.red;
                                        seven_four.colors = cb;
                                    }
                                    else if (j == 5)
                                    {
                                        ColorBlock cb = seven_five.colors;
                                        cb.normalColor = Color.red;
                                        seven_five.colors = cb;
                                    }
                                    else if (j == 6)
                                    {
                                        ColorBlock cb = seven_six.colors;
                                        cb.normalColor = Color.red;
                                        seven_six.colors = cb;
                                    }
                                    else if (j == 7)
                                    {
                                        ColorBlock cb = seven_seven.colors;
                                        cb.normalColor = Color.red;
                                        seven_seven.colors = cb;
                                    }
                                    else
                                    {
                                        ColorBlock cb = seven_eight.colors;
                                        cb.normalColor = Color.red;
                                        seven_eight.colors = cb;
                                    }
                                }
                                else
                                {
                                    if (j == 0)
                                    {
                                        ColorBlock cb = eight_zero.colors;
                                        cb.normalColor = Color.red;
                                        eight_zero.colors = cb;
                                    }
                                    else if (j == 1)
                                    {
                                        ColorBlock cb = eight_one.colors;
                                        cb.normalColor = Color.red;
                                        eight_one.colors = cb;
                                    }
                                    else if (j == 2)
                                    {
                                        ColorBlock cb = eight_two.colors;
                                        cb.normalColor = Color.red;
                                        eight_two.colors = cb;
                                    }
                                    else if (j == 3)
                                    {
                                        ColorBlock cb = eight_three.colors;
                                        cb.normalColor = Color.red;
                                        eight_three.colors = cb;
                                    }
                                    else if (j == 4)
                                    {
                                        ColorBlock cb = eight_four.colors;
                                        cb.normalColor = Color.red;
                                        eight_four.colors = cb;
                                    }
                                    else if (j == 5)
                                    {
                                        ColorBlock cb = eight_five.colors;
                                        cb.normalColor = Color.red;
                                        eight_five.colors = cb;
                                    }
                                    else if (j == 6)
                                    {
                                        ColorBlock cb = eight_six.colors;
                                        cb.normalColor = Color.red;
                                        eight_six.colors = cb;
                                    }
                                    else if (j == 7)
                                    {
                                        ColorBlock cb = eight_seven.colors;
                                        cb.normalColor = Color.red;
                                        eight_seven.colors = cb;
                                    }
                                    else
                                    {
                                        ColorBlock cb = eight_eight.colors;
                                        cb.normalColor = Color.red;
                                        eight_eight.colors = cb;
                                    }
                                }
                            }
                        
                            
                        }
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
    public void test_create_board() {
        int[,] bak_board = board;
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
        create_board();
        int[,] res = Validate ();
        if (array2dComp(expected, res)) {
            Debug.Log ("Test ok");
        } else {
            Debug.Log ("Test FAIL");
        }
        board = bak_board;
    }
    public void test_convert_board_to_string() {
        int[,] test_board = {
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
        string expected = "0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0";
        int[,] bak_board = board;
        board = test_board;
        string res = convert_board_to_string();
        if (expected == res) {
            Debug.Log ("Test ok");
        } else {
            Debug.Log ("Test FAIL");
        }
        board = bak_board;
    }
    public void test_is_permanent_square() {
        int[,] bak_board = board;
        int[,] test_board = {
            {-5,3,4,6,7,8,9,1,2},
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
        if (is_permanent_square(0, 0)) {
            Debug.Log ("Test ok");
        } else {
            Debug.Log ("Test FAIL");
        }
        board = bak_board;
    }
    public void test_set_square() {
        int[,] bak_board = board;
        int[,] test_board = {
            {-5,3,4,6,7,8,9,1,2},
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
        if (!setSquare(0, 0, 1) && setSquare(1, 1, 0) && !setSquare(10, 1, 12)) {
            Debug.Log ("Test ok");
        } else {
            Debug.Log ("Test FAIL");
        }
        board = bak_board;
    }
    public void test_clear_entries() {
        int[,] expected = {
            { -5, 0, 0, 0, 0, 0, 0, 0, 0 },
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
            { -5, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 1, 0, 0, 0, 0, 0, 0, 0 }, 
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };
        board = test_board;
        clear_entries();
        if (array2dComp(expected, board)) {
            Debug.Log ("Test ok");
        } else {
            Debug.Log ("Test FAIL");
        }
        board = bak_board;
    }
    public void test_read_file() {
        int[,] bak_board = board;
        string path = @"test_file.txt";

        // read from blank
        StreamWriter write = new StreamWriter(path);
        write.Close();
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
        int[,] res = read_file(path);
        if (array2dComp(expected, res)) {
            Debug.Log ("Test ok");
        } else {
            Debug.Log ("Test FAIL");
        }
        
        // read from all 1
        write = new StreamWriter(path);
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                write.Write("1 ");
                expected[i, j] = 1;
            }
        }
        write.Close();
        res = read_file(path);
        if (array2dComp(expected, res)) {
            Debug.Log ("Test ok");
        } else {
            Debug.Log ("Test FAIL");
        }

        board = bak_board;
    }
    public void test_save() {
        int[,] test_board = {
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
        board = test_board;
        save();
        string path = @"save_file.txt";
        read_file(path);
        if (array2dComp(test_board, board)) {
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
