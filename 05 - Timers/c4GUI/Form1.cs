///Authors:     Nick Smith, Kyle Wyse 
///Date:        28 Mar 2019
///
///Description: Includes the serializability features of the game, timers, 
///             and the event handlers for the drop-piece buttons and the 
///             Save-and-Quit button. Also includes helper methods to 
///             evaluate the  state of the game after each move and to 
///             draw the board
///             
///Variables:   
///
///Constructor: + Form1() ............... checks for existing saved game. creates new board if none found.
///                                   
///Methods:     - btnCol#_Click() ....... event handlers for dropping a piece
///
///             - btnSaveQuit_Click() ... saves the state of the game to an xml file and exits the application
///             
///             - clock_Tick() .......... updates countdown; changes player turn when zero is reached
///             
///             - Evaluate() ............ called by btnCol#_Click(). calls board.Drop() whenever a button is 
///                                       clicked to select a row. gets the results of board.drop and displays 
///                                       win/tie messages
///                                       PARAMS: (int) column number
///             
///             - DrawBoard() ........... uses a graphics object to draw the Spaces array from Board
///             
///             + PlayerTurn() .......... greys out player labels to indicate who's turn it is
///             
///             - RedrawStats() ......... updates the labels that display player stats
///             
///             - Form1_Shown() ......... draws the board after the form is first displayed
///             
///             - idle_Tick() ........... counts minutes that the program has not recieved new input; warns user @ 4 min
///                                       

using System;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace c4GUI
{
    [Serializable]
    public partial class Form1 : Form
    {
        const string saveFileName = "SaveGame.xml";
        const int PIECE_SIZE = 38;
        const int GAP = 4;
        Board board = null;
        int countDown = 10;
        int minsIdle = 0;

        public Form1()
        {
            //continue an existing game?
            if (File.Exists(saveFileName))
            {
                DialogResult load = MessageBox.Show("Do you want to resume an old game?", "Load Game", MessageBoxButtons.YesNo);
                if (load == DialogResult.Yes)
                {
                    Stream saveFile = File.OpenRead(saveFileName);
                    SoapFormatter deserializer = new SoapFormatter();
                    board = (Board)(deserializer.Deserialize(saveFile));
                    saveFile.Close();
                }
                //remove file regardless of restore or not since a new game would be started.
                File.Delete(saveFileName);
            }

            //game not restored so start a new one
            if (board == null) board = new Board();
            
            //create the form
            InitializeComponent();
        }

        //drop peice button event handlers
        private void butCol1_Click(object sender, EventArgs e) { Evaluate(0); }
        private void butCol2_Click(object sender, EventArgs e) { Evaluate(1); }
        private void butCol3_Click(object sender, EventArgs e) { Evaluate(2); }
        private void butCol4_Click(object sender, EventArgs e) { Evaluate(3); }
        private void butCol5_Click(object sender, EventArgs e) { Evaluate(4); }
        private void butCol6_Click(object sender, EventArgs e) { Evaluate(5); }
        private void butCol7_Click(object sender, EventArgs e) { Evaluate(6); }

        private void butSaveQuit_Click(object sender, EventArgs e)
        {
            Stream saveFile = File.Create(saveFileName);
            SoapFormatter serializer = new SoapFormatter();
            serializer.Serialize(saveFile, board);
            saveFile.Close();
            Application.Exit();
        }

        private void clock_Tick(object sender, EventArgs e)
        {
            countDown--;
            if (countDown == 0)
            {
                board.ChangeTurn();
                countDown = 10;
                PlayerTurn();
            }
            LblTime.Text = "Time remaining: " + countDown;
        }

        private void Evaluate(int col)
        /// called by each button event handler to drop pieces
        {
            minsIdle = 0;
            int gameResult = -1;
            try
            //perform move - returns game status
            {
                gameResult = board.Drop((int)(col));
                countDown = 10;
                LblTime.Text = "Time remaining: " + countDown;
                DrawBoard();
            }
            catch (Exception ex)
            {
                //clock.Stop(); //easy to take advantage of/get arround timer
                DialogResult dialog = MessageBox.Show("Error: " + ex.Message + " Please try again.", "Invalid Move");
                //clock.Start();
            }

            if (gameResult == 0)
            {
                DialogResult dialog = MessageBox.Show("You win!", "Game Over!");
                board.UpdateWinStats();
                board.Reset();
            }
            else if (gameResult == 2)
            {
                DialogResult dialog = MessageBox.Show("The game is a draw.", "Game Over!");
                board.Reset();
            }
            RedrawStats();
            PlayerTurn();

        }

        private void DrawBoard()
        {
            Graphics g;
            SolidBrush red = new SolidBrush(Color.Red);
            SolidBrush blue = new SolidBrush(Color.Blue);
            Point pos = new Point(0, GAP);

            char[,] b = board.GetSpaces();
            g = panel1.CreateGraphics();
            g.Clear(Color.White);
            for (int i = b.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    if (b[i, j].Equals('+'))
                    {
                        g.FillEllipse(red, pos.X, pos.Y, PIECE_SIZE, PIECE_SIZE);
                    }
                    else if (b[i, j].Equals('o'))
                    {
                        g.FillEllipse(blue, pos.X, pos.Y, PIECE_SIZE, PIECE_SIZE);
                    }
                    pos.X += PIECE_SIZE + GAP;
                }
                pos.X = 0;
                pos.Y += PIECE_SIZE + GAP;
            }
        }

        public void PlayerTurn()
        {
            char turn = board.GetPiece();
            if (turn == '+')
            {
                label5.ForeColor = System.Drawing.Color.Black;
                label4.ForeColor = System.Drawing.Color.LightGray;
            }
            else if (turn == 'o')
            {
                label5.ForeColor = System.Drawing.Color.LightGray;
                label4.ForeColor = System.Drawing.Color.Black;
            }
        }


        private void RedrawStats()
        {
            int[] p = board.GetStats();

            lblP1Stats.Text = "Current moves: " + p[0] + "\n" +
                              "Total moves: " + p[1] + "\n" +
                              "Total wins: " + p[2] + "\n" +
                              "Least moves \n" +
                              "to win: " + p[3];
            lblP2Stats.Text = "Current moves: " + p[4] + "\n" +
                              "Total moves: " + p[5] + "\n" +
                              "Total wins: " + p[6] + "\n" +
                              "Least moves \n" +
                              "to win: " + p[7];
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            DrawBoard();
            RedrawStats();
            PlayerTurn();
        }

        private void idle_Tick(object sender, EventArgs e)
        {
            minsIdle++;
            if (minsIdle == 4) LblIdle.Text = "Application will quit \n" +
                                              "after 1 more min of \n" +
                                              "inactivity";
            else if (minsIdle == 5) butSaveQuit_Click(sender, e);
        }
    }
}