///Authors:     Nick Smith
///             Kyle Wyse 
///Date:        7 Feb 2019
///Description: Maintains the game board and game logic for connect four

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    class Board
    {
        private char[,] spaces;

        private const int COLUMNS = 1; // because i keep mixing them up and it's aggravating 
        private const int ROWS = 0;

        public Board()
        {
            spaces = new char[6,7];
            this.Reset();
        }

        private void Reset()
        //set all elements in spaces = '#'
        {
            for (int i = 0; i < spaces.GetLength(ROWS); i++)
            {
                for (int j = 0; j < spaces.GetLength(COLUMNS); j++)
                {
                    spaces[i, j] = '#';
                }
            }
        }

        public int Drop(int column, char piece)
        // updates the 2D Spaces array that represents the game board. 
        // calls Check() when complete. forwards Check's return value to client
        // 0 if game is won
        // 1 if game is not won and there are available moves
        // 2 if the game is a draw
        {
            int row = spaces.GetLength(ROWS) - 1;//=5
            while (row >= 1 && spaces[row - 1, column] == '#')
            {
                row--;
            }
            spaces[row, column] = piece;
            return Check(row, column, piece);
        }

        public void Draw()
        {
            for (int i = spaces.GetLength(ROWS) - 1; i >= 0; i--)
            {
                for (int j = 0; j < spaces.GetLength(COLUMNS); j++)
                {
                    Console.Write(spaces[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }

        public bool ColumnIsFull(int col)
        {
            return spaces[spaces.GetLength(ROWS) - 1, col] != '#';
        }

        /// GAME LOGIC
        /// <summary>
        /// checks the horizontal column that the peice was played in to see if it makes 4-in-a-row
        /// then checks vertical row that the peice was played in to see if it makes 4-in-a-row
        /// then checks all possible diagonal win conditions for the player whose peice was just placed
        /// </summary>
        /// <param playedRow="r"></param>
        /// <param playedColumn="c"></param>
        /// <param peice="p"></param>
        /// <returns> int 0, 1, or 2 </returns>
        private int Check(int r, int c, char p)
        // called by Drop()
        // will examine the Spaces array to see if the game has been won.
        // returns 0 if game is won
        // returns 1 if game is not won and there are available moves
        // returns 2 if the game is a draw

        // win-draw logic adapted from:
        // https://stackoverflow.com/questions/32770321/connect-4-check-for-a-win-algorithm
        {
            int count = 0;

            ///CHECK WIN CONDITION

            // Horizontal check
            for (int i = 0; i < spaces.GetLength(COLUMNS); i++)
            {
                if (spaces[r,i] == p)
                    count++;
                else
                    count = 0;

                if (count >= 4) return 0; //win
            }
            count = 0;

            //Vertical check
            for (int i = 0; i < spaces.GetLength(ROWS); i++)
            {
                if (spaces[i,c] == p)
                    count++;
                else
                    count = 0;

                if (count >= 4) return 0; //win
            }

            // Diagonal top-left to bottom-right : bottom half
            for (int i = 3; i < spaces.GetLength(ROWS); i++) //start with 4th row (spaces[3,0]) & move up
            {
                count = 0;
                int row, col;
                for (row = i, col = 0; row >= 0 && col < spaces.GetLength(COLUMNS); row--, col++)
                {
                    if (spaces[row,col] == p)
                    {
                        count++;
                        if (count >= 4) return 0; //win
                    }
                    else count = 0;
                }
            }

            // ... : top half 
            for (int i = 1; i < spaces.GetLength(COLUMNS) - 4; i++) //start at 2nd col (spaces[1,5]) & move across
            {
                count = 0;
                int row, col;
                for (row = 5, col = i; row >= 0 && col < spaces.GetLength(COLUMNS); row--, col++)
                {
                    if (spaces[row, col] == p)
                    {
                        count++;
                        if (count >= 4) return 0; //win
                    }
                    else  count = 0; 
                }
            }

            // Diagonal bottom-left to top-right : top half
            for (int i = spaces.GetLength(ROWS)-4; i >= 0; i--) //start with 3rd row (spaces[2,0]) & move down
            {
                count = 0;
                int row, col;
                for (row = i, col = 0; row < spaces.GetLength(ROWS) && col < spaces.GetLength(COLUMNS); row++, col++)
                {
                    if (spaces[row, col] == p)
                    {
                        count++;
                        if (count >= 4) return 0; //win 
                    }
                    else count = 0;
                }
            }

            // ... : bottom half 
            for (int i = 1; i < spaces.GetLength(COLUMNS)-3; i++) //start with 2nd col (spaces[0,1]) & move accross
            {
                count = 0;
                int row, col;
                for (row = 0, col = i; row < spaces.GetLength(ROWS) && col < spaces.GetLength(COLUMNS); row++, col++)
                {
                    if (spaces[row, col] == p)
                    {
                        count++;
                        if (count >= 4) return 0; //win
                    }
                    else  count = 0;
                }
            }

            ///CHECK TIE CONDTION
            for (int i = 0; i < spaces.GetLength(COLUMNS); i++)
            {
                if (spaces[spaces.GetLength(ROWS) -1, i] == '#') return 2;
            }

            ///DEFAULT: GAME NOT WON
            return 1;
        }

    }
}
