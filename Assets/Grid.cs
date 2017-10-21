using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid {
    public static int w = 10;
    public static int h = 13;
    public static Element[,] elements = new Element[w, h];

    public static void uncoverMines()
    {
        foreach (Element elem in elements)
            if (elem.mine)
                elem.loadTexture(0);
    }

    // checks if a mine is at the location
    public static bool mineAt(int x, int y)
    {
        // if the location is in range, then check for mine
        if (x >= 0 && y >= 0 && x < w && y < h)
            return elements[x, y].mine;
        return false;
    }

    public static int adjacentMines(int x, int y)
    {
        int count = 0;

        if (mineAt(x + 1, y - 1)) ++count; // bot right
        if (mineAt(x + 1, y    )) ++count; //     right
        if (mineAt(x + 1, y + 1)) ++count; // top right
        if (mineAt(x    , y - 1)) ++count; // bot
        if (mineAt(x    , y + 1)) ++count; // top
        if (mineAt(x - 1, y - 1)) ++count; // bot left
        if (mineAt(x - 1, y    )) ++count; // bot
        if (mineAt(x - 1, y + 1)) ++count; // top left

        return count;
    }

    public static void floodFillUncover(int x, int y, bool[,] visited)
    {
        if (x >= 0 && y >= 0 && x < w && y < h)
        {
            // if location has already been recursed, just return
            if (visited[x, y])
                return;

            // uncover element
            elements[x, y].loadTexture(adjacentMines(x, y));

            // if not a empty zero, then stop recursing
            if (adjacentMines(x, y) > 0)
                return;

            visited[x, y] = true;

            floodFillUncover(x - 1, y, visited);
            floodFillUncover(x + 1, y, visited);
            floodFillUncover(x, y - 1, visited);
            floodFillUncover(x, y + 1, visited);
        }

    }

    public static bool isFinished()
    {
        foreach (Element elem in elements)
            if (elem.isCovered() && !elem.mine)
                return false;
        return true;
    }
}
