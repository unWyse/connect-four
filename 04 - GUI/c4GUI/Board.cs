///Authors:     Nick Smith, Kyle Wyse 
///Date:        19 Mar 2019
///
///Description: Maintains the board and game logic for connect four. Can be saved as an XML file and 
///             reloaded at a later time. 
///             
///Variables:   - (char) Spaces[,] .. The grid which makes up the game board. All spaces are initialized to 
///                                   '#' and will contain either '+' or '-' once used.
///             - (char) piece ...... VALUES: '#', '+', or '-'
///             - (int) COLS ........ Width of the game board
///             - (int) ROWS ........ Height of the game board
///             
///             //Player Variables
///             - (int) p#Moves ......... = moves this game
///             - (int) p#AllMoves ...... = moves over all continuous games
///             - (int) p#Wins .......... = total wins
///             - (int) p#LeastToWin .... = fewest number of moves this player has used to win a game
///                         
/// 
///Constructor: + Board() ........... Initializes Spaces[], then calls Reset().
///                                   PARAMS:  (int) height, (int) width OR null
///                                   RETURNS: void
///
///Methods:     - Check() ........... Will examine the Spaces array to see if the game has been won.
///                                   PARAMS:  (int) r, (int) c ==> ie the row and column just played
///                                   RETURNS: (int) 0: game is won
///                                                  1: game is not yet won
///                                                  2: game is a tie
///                                           
///             + Reset() ........... Sets all elements of Spaces to '#'. Called by the constructor.
///                                   PARAMS:  none
///                                   RETURNS: void
///                                  
///             + Drop() ............ Updates the Spaces array with the next user. Calls ColumnIsFull() to 
///                                   determine if the requested move can be made, then calls Check() and 
///                                   forwards that value to the caller.
///                                   PARAMS:  (int) column
///                                   RETURNS: same as Check()
///                                  
///             + Draw() ............ [REMOVED] Draws the board 
///                                   PARAMS:  none
///                                   RETURNS: void
///                                  
///             + ColumnIsFull() .... Checks whether the column that is trying to be used is full.
///                                   PARAMS:  (int) column
///                                   RETURNS: bool
///                                   
///             + GetSpaces() ....... RETURNS: char[,]
///             + GetPiece() ........ RETURNS: char
///             + UpdateWinStats() .. RETURNS: void
///             + GetStats() ........ RETURNS: int[]



using System;

namespace c4GUI
{
    [Serializable]
    class Board
    {
        //board fields
        private char[,] spaces;
        private char piece;
        private int COLS = 7, ROWS = 6;

        //player fields
        int p1Moves = 0;
        int p1AllMoves = 0;
        int p1Wins = 0;
        int p1LeastToWin = 42;

        int p2Moves = 0;
        int p2AllMoves = 0;
        int p2Wins = 0;
        int p2LeastToWin = 42;
        
        public Board()
        {
            spaces = new char[ROWS, COLS];
            this.Reset();
            piece = '+';
        }

        public Board(int height, int width)
        {
            COLS = width;
            ROWS = height;
            spaces = new char[ROWS, COLS];
            this.Reset();
            piece = '+';
        }

        public void Reset()
        //set all elements in spaces = '#'
        {
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    spaces[i, j] = '#';
                }
            }
            piece = '+';
            p1Moves = 0;
            p2Moves = 0;
        }

        public int Drop(int column)
        // updates the 2D Spaces array that represents the game board
        // calls Check() when complete. forwards Check's return value to client
        // 0 if game is won
        // 1 if game is not won and there are available moves
        // 2 if the game is a draw
        {
            if (ColumnIsFull(column)) throw new Exception("That column is full.");

            int row = ROWS - 1;
            while (row >= 1 && spaces[row - 1, column] == '#')
            {
                row--;
            }
            spaces[row, column] = piece;

            int gameResult = Check(row, column);
            //change player peice
            if (piece == '+')
            {
                p1Moves++;
                p1AllMoves++;
                piece = 'o';
            }
            else
            {
                p2Moves++;
                p2AllMoves++;
                piece = '+';
            }

            return gameResult;
        }

        public bool ColumnIsFull(int column)
        {
            return spaces[ROWS - 1, column] != '#';
        }

        public char[,] GetSpaces()
        {
            return spaces;
        }

        public char GetPiece()
        {
            return piece;
        }

        public void UpdateWinStats()
        {
            if (piece == 'o')//'o' is the opposite of what you expect here because the piece was 
                             //already changed by Drop();
            {
                p1Wins++;
                if(p1Moves<p1LeastToWin) p1LeastToWin = p1Moves;
            }
            else
            {
                p2Wins++;
                if (p2Moves < p2LeastToWin) p2LeastToWin = p2Moves;
            }
        }

        public int[] GetStats()
        {
            int[] p = { p1Moves, p1AllMoves, p1Wins, p1LeastToWin,
                        p2Moves, p2AllMoves, p2Wins, p2LeastToWin};
            return p;
        }

        /// GAME LOGIC
        /// <summary>
        /// checks the horizontal column that the piece was played in to see if it makes 4-in-a-row
        /// then checks vertical row that the piece was played in to see if it makes 4-in-a-row
        /// then checks all possible diagonal win conditions for the player whose piece was just placed
        /// </summary>
        /// <param playedRow="r"></param>
        /// <param playedColumn="c"></param>
        /// <returns> int 0, 1, or 2 </returns>
        private int Check(int r, int c)
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
            for (int i = 0; i < COLS; i++)
            {
                if (spaces[r, i] == piece)
                    count++;
                else
                    count = 0;

                if (count >= 4) return 0; //win
            }
            count = 0;

            //Vertical check
            for (int i = 0; i < ROWS; i++)
            {
                if (spaces[i, c] == piece)
                    count++;
                else
                    count = 0;

                if (count >= 4) return 0; //win
            }

            // Diagonal top-left to bottom-right : bottom half
            for (int i = 3; i < ROWS; i++) //start with 4th row (spaces[3,0]) & move up
            {
                count = 0;
                int row, col;
                for (row = i, col = 0; row >= 0 && col < COLS; row--, col++)
                {
                    if (spaces[row, col] == piece)
                    {
                        count++;
                        if (count >= 4) return 0; //win
                    }
                    else count = 0;
                }
            }

            // ... : top half 
            for (int i = 1; i < COLS - 4; i++) //start at 2nd col (spaces[1,5]) & move across
            {
                count = 0;
                int row, col;
                for (row = 5, col = i; row >= 0 && col < COLS; row--, col++)
                {
                    if (spaces[row, col] == piece)
                    {
                        count++;
                        if (count >= 4) return 0; //win
                    }
                    else count = 0;
                }
            }

            // Diagonal bottom-left to top-right : top half
            for (int i = ROWS - 4; i >= 0; i--) //start with 3rd row (spaces[2,0]) & move down
            {
                count = 0;
                int row, col;
                for (row = i, col = 0; row < ROWS && col < COLS; row++, col++)
                {
                    if (spaces[row, col] == piece)
                    {
                        count++;
                        if (count >= 4) return 0; //win 
                    }
                    else count = 0;
                }
            }

            // ... : bottom half 
            for (int i = 1; i < COLS - 3; i++) //start with 2nd col (spaces[0,1]) & move accross
            {
                count = 0;
                int row, col;
                for (row = 0, col = i; row < ROWS && col < COLS; row++, col++)
                {
                    if (spaces[row, col] == piece)
                    {
                        count++;
                        if (count >= 4) return 0; //win
                    }
                    else count = 0;
                }
            }

            ///CHECK TIE CONDTION
            for (int i = 0; i < COLS; i++)
            {
                if (spaces[ROWS - 1, i] == '#') return 1; //board not full
            }

            ///DEFAULT: GAME IS A TIE
            return 2;
        }

    }
}
