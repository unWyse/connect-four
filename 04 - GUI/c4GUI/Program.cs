///Authors:     Nick Smith
///             Kyle Wyse 
///Date:        19 Mar 2019
///
///Description: The game is traditional Connect Four, played by two users on the same machine. The rules of the
///             game are the standard Connect Four rules, including the effects of gravity. When the application
///             sarts up, the users will be prompted with a dialog box where they will have to choose whether to 
///              continue an existing game
///
///Rules:       Players must take turns selecting a row from which to drop one colored disc (represented by ‘+’
///             and ‘o’ in the command line version) into a 7x6 grid with #’s. The pieces will “fall” to the 
///             space above the highest occupied space in that row. If a row is filled, no further pieces can 
///             be dropped there.
///
///Winning:     The game ends when one player forms a horizontal, vertical, or diagonal line of four of their 
///             discs.If the board is filled before either player gets four in a row, then the game is a draw.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c4GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
                
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
