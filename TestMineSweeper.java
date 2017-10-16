class minesweeper
{
  // 0-8 are clue values (how many mines are surrouding this tile), 9 is a mine
  public int[][] mines;
  // 0 is an open tile, or a tile that has been dug up
  // 1 is a closed tile, or a tile that has not been dug up
  // 2 is a question mark, for user QoL
  // 3 is a mine mark, or a flag
  public int[][] tiles;

  private String status;

  // creates a default board of 9x9
  public minesweeper ()
  {
    initGame (9, 9);
  }

  // when given parameters, creates a board to parameters
  public minesweeper (int newRows, int newCols)
  {
    initGame (newRows, newCols);
  }

  // gives the game status, ie play, lose, win
  public String getStatus ()
  {
    return this.status;
  }
  
  // returns number of rows
  public int getRows ()
  {
    return this.mines.length;
  }
  
  // returns number of columns
  public int getCols ()
  {
    return this.mines[0].length;
  }

  // checks if the index is within the boundaries 
  private boolean validIndex (int x, int y)
  {
    return ((x < tiles.length) && (x >= 0) && (y < tiles[0].length) && (y >= 0));
  }

  // returns the mine state of the current location, ie what is the number or mine here
  public int getMines (int r, int c)
  {
    if (validIndex(r, c))
    {
      return mines[r][c];
    }
    else
    {
      return -1;
    }
  }

  // returns the tile state of the current location, ie what is shown in the UI
  public int getTiles (int r, int c)
  {
    if (validIndex(r, c))
    {
      return tiles[r][c];
    }
    else
    {
      return -1;
    }
  }
  
  // digs up tiles and calculates what happens next
  public void markTile (int r, int c, int t)
  {
    // if the index is valid and the status is play
    if((validIndex(r, c)) && (status.equals("play"))) 
    {
      switch (t)
      {
      case 0: 
        // if the tiles are not dug up and not flagged, ie if tiles are clean or questioned
        if((tiles[r][c] != 0) && (tiles[r][c] != 3))
        {
          // set state of tile to dug up
          tiles[r][c] = 0;
          if (gameWon())
          {
            status = "win";
          }
          else if (mines[r][c] == 9)
          {
            status = "lose";
          }
          // if the mine board int is 0, recursion the surrounding 8 tiles until the mine board int isn't 0
          else if (mines[r][c] == 0)
          {
            markTile(r - 1, c - 1, 0);
            markTile(r - 1, c, 0);
            markTile(r - 1, c + 1, 0);
            markTile(r, c - 1, 0);
            markTile(r, c + 1, 0);
            markTile(r + 1, c - 1, 0);
            markTile(r + 1, c, 0);
            markTile(r + 1, c + 1, 0);
          }
        }
        break;
      case 1: 
        if (tiles[r][c] != 0)
        {
          tiles[r][c] = 1;
        }
        break;
      case 2: 
        if (tiles[r][c] != 0)
        {
          tiles[r][c] = 2;
        }
        break;
      case 3: 
        if (tiles[r][c] != 0)
        {
          tiles[r][c] = 3;
        }
        break;
      }
    }
  }

  public String toStringMines ()
  {
    String result = "\n";

    for (int r = 0; r < mines.length; r++)
    {
      for (int c = 0; c < mines[r].length; c++)
      {
        result = result + mines[r][c];
      }
      result += "\n";
    }

    return result;
  }

  public String toStringTiles ()
  {
    String result = "\n";
    for (int r = 0; r < tiles.length; r++)
    {
      for (int c = 0; c < tiles[r].length; c++)
      {
        result = result + tiles[r][c];
      }
      result += "\n";
    }
    return result;
  }

  public String toStringBoard ()
  {
    String result = "";
    for (int r = 0; r < tiles.length; r++)
    {
      for (int c = 0; c < tiles[r].length; c++)
      {
        result += this.getBoard(r, c);
      }
      result += "\n";
    }
    return result;
  }


  public char getBoard (int r, int c)
  {
    if (status.equals("play"))
    {
      switch (tiles[r][c])
      {
        case 0:
          if (mines[r][c] == 0)
          {
            return ' ';
          }
          else
          {
            return Character.forDigit(mines[r][c], 10);
          }
        case 1: return 'X';
        case 2: return '?';
        case 3: return 'F';
      }
    }

    else if (status.equals("lose"))
    {
      switch (tiles[r][c])
      {
        case 0:
          if (mines[r][c] == 0)
          {
            return ' ';
          }
          // the losing tile
          else if (mines[r][c] == 9)
          {
            return '!';
          }
          else
          {
            return Character.forDigit(mines[r][c], 10);
          }

        // closed tiles
        case 1:
          if (mines[r][c] == 9)
          {
            return '*';
          }
          else
          {
            return 'X';
          }

        // question mark tiles
        case 2:
          if (mines[r][c] == 9)
          {
            return '*';
          }
          else
          {
            return '?';
          }

        // flagged mine tiles
        case 3:
          if (mines[r][c] == 9)
          {
            return '*';
          }
          else
          {
            return '-';
          }
      }
    }

    else // game win
    {
      switch (tiles[r][c])
      {
        case 0:
          if (mines[r][c] == 0)
          {
            return ' ';
          }
          else
          {
            return Character.forDigit(mines[r][c], 10);
          }

        case 1:
          if (mines[r][c] == 9)
          {
            return 'F';
          }
          else // this should never happen
          {
            return 'X';
          }
  
        case 2: 
          if (mines[r][c] == 9)
          {
            return 'F';
          }
          else
          {
            return '?';
          }

        // all mines are marked as F
        case 3: return 'F';
      }
    }
    // filler, if it makes it through everything, which it shouldn't
    return 'N';
  }

  private void initGame (int newRows, int newCols)
  {
    if ((newRows >= 1) && (newCols >= 1))
    {
      mines = new int[newRows][newCols];
      tiles = new int[newRows][newCols];
    }

    resetTiles ();
    placeMines ();
    calculateClues ();
    status = "play";
  }

  private void resetTiles ()
  {
    for (int r = 0; r < tiles.length; r++)
    {
      for (int c = 0; c < tiles[r].length; c++)
      {
        tiles[r][c] = 1; // on website, -1
      }
    }
  }
  

  private void placeMines ()
  {
    int numMines = (1 + (mines.length * mines[0].length)) / 10;

    int placedMines = 0;
    while (placedMines <= numMines)
    {
      int randomRow = (int)(Math.random() * mines.length);
      int randomCol = (int)(Math.random() * mines[0].length);

      if (mines[randomRow][randomCol] == 9)
      {
        
      }
      else
      {
        mines[randomRow][randomCol] = 9;
        placedMines++;
      }
    }
  }

  private void calculateClues ()
  {
    // check every tile for mines around
    // need checks for edges and corners
    for (int r = 0; r < mines.length; r++)
    {
      for (int c = 0; c < mines[r].length; c++)
      {
        if (mines[r][c] != 9)
        {
          int counterMines = 0;
          // if upper left slot is a mine
          if (r != 0 && c != 0 && mines[r-1][c-1] == 9)
          {
            counterMines++;;
          }
          // if upper slot is a mine
          if (r != 0 && mines[r-1][c] == 9)
          {
            counterMines++;;
          }
          // if upper right slot is a mine
          if (r != 0 && c != mines[r].length - 1 && mines[r-1][c+1] == 9)
          {
            counterMines++;;
          }
          // if left slot is a mine
          if (c != 0 && mines[r][c-1] == 9)
          {
            counterMines++;;
          }
          // if right slot is a mine
          if (c != mines[r].length - 1 && mines[r][c+1] == 9)
          {
            counterMines++;;
          }
          // if lower left slot is a mine
          if (r != mines.length - 1 && c != 0 && mines[r+1][c-1] == 9)
          {
            counterMines++;;
          }
          // if lower slot is a mine
          if (r != mines.length - 1 && mines[r+1][c] == 9)
          {
            counterMines++;;
          }
          // if lower right slot is a mine
          if (r != mines.length - 1 && c != mines[r].length - 1 && mines[r+1][c+1] == 9)
          {
            counterMines++;;
          }
          mines[r][c] = counterMines;
        }
      }
    }
  }

  private boolean gameWon ()
  {
    boolean game = true;
    for (int i = 0; i < tiles.length; i++) 
    {
      for (int j = 0; j < tiles[i].length; j++) 
      {
        if ((tiles[i][j] != 0) && (mines[i][j] != 9)) 
        {
          game = false;
          break;
        }
      }
    }
    return game;
  }
}

public class TestMineSweeper
{
  public static void main (String [] args)
  {
    minesweeper game = new minesweeper (2, 5);

    System.out.println (game.toStringMines());
    System.out.println (game.toStringTiles());
    System.out.println (game.toStringBoard());

    game.markTile (0, 0, 0);

    game.markTile (0, 1, 2);
    
    game.markTile (0, 2, 3);

    System.out.println (game.toStringTiles());
 
    System.out.println (game.toStringBoard());
    





  }
}
