///Authors:     Nick Smith
///             Kyle Wyse 
///Date:        15 Feb 2019
///
///Description: The game is traditional Connect Four, played by two users on the same machine. The rules of the
///             game are the standard Connect Four rules, including the effects of gravity. When the application
///             sarts up, the users will be prompted with a menu where they will have to choose whether to begin
///             a game or quit. After a game is finished, the users will be returned to the intial menu. The 
///             users can also continue an existing game; they will be prompted when the application opens. Also 
///             includes a helper method, endGame(), which recives the outcome of a completed game as a string
///             and displays it with the final layout of the game board.
///
///Rules:       Players must take turns selecting a row from which to drop one colored disc (represented by ‘+’
///             and ‘o’ in the command line version) into a 7x6 grid with #’s. The pieces will “fall” to the 
///             space above the highest occupied space in that row. If a row is filled, no further pieces can 
///             be dropped there.
///
///Winning:     The game ends when one player forms a horizontal, vertical, or diagonal line of four of their 
///             discs.If the board is filled before either player gets four in a row, then the game is a draw.
///
///Input:       Users will need to enter the following on the command line:
///             -   The letter 'p' or 'P' to play a game
///             -	Column selection(an integer between 1 and 7 inclusive)
///             -	The letter ‘q’ or ‘Q’ as the command to quit the game
///             -	The letter ‘s’ or ‘S’ to save and exit
///
///Output       The program will output instructions when the application first is loaded. After each turn, the
///             refreshed game board will be displayed. Upon the win/draw condition being met, the program will
///             output a message indicating who won or if the game was a tie.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// two lines added to make program serializable
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

namespace ConnectFour
{
    [Serializable]
    class PlayConnectFour
    {
        const string saveFileName = "SaveGame.xml";
        const int charOffset = 49;
        const int boardWidth = 7;
        const int boardHeight = 6;

        static Board board = null;

        static void Main(string[] args)
        {
            ///STARTUP
            
            bool running = true;
            string input;
            char selection = '*';
            
            //load an existing profile? Enter player names?

            while (running)
            {
                Console.Clear();
                //continue an existing game?
                if (File.Exists(saveFileName))
                {
                    Console.Write("Do you want to resume an old game? (Y/N)");
                    input = Console.ReadLine();
                    if (input[0] == 'y' || input[0] == 'Y')
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
                if (board == null)  board = new Board(boardHeight, boardWidth); 

                //get user action
                Console.WriteLine("Welcome to Connect Four! \n" +
                                  "Enter 'P' to play. \n" + 
                              /*  "Enter 'S' to see player stats. \n" + */
                                  "Enter 'Q' to quit.");

                input = Console.ReadLine().ToUpper(); 
                try
                {
                    selection = input[0];
                }
                catch (IndexOutOfRangeException) // no input
                {
                    continue;
                }

            /*  if (selection == 'S') User.GetStats();  */
                if (selection == 'Q') running = false;



                ///PLAY CONNECT FOUR
                bool play = running; //only play game if user has chosen not to exit app
                int gameResult = 1; 
                while (play) 
                {
                    play = true;
                    Console.Clear();
                    Console.WriteLine("Enter the column number (1-7) where you would like to place your peice.\n" +
                                      "Enter 'S' to save and exit.\n" +
                                      "Enter 'Q' to quit game.\n");
                    
                    ///DRAW THE BOARD 
                    board.Draw();
                    ///GET NEXT ACTION
                    input = Console.ReadLine().ToUpper();
                    try
                    {
                        selection = input[0];
                    }
                    catch (IndexOutOfRangeException) // no input
                    {
                        continue;
                    }
                    ///HANDLE USER SELECTION
                    if (selection == 'S')
                    //save game
                    {
                        Stream saveFile = File.Create(saveFileName);
                        SoapFormatter serializer = new SoapFormatter();
                        serializer.Serialize(saveFile, board);
                        saveFile.Close();
                        return;//exit program directly
                    }
                    //quit game
                    else if (selection == 'Q') play = false;

                    else if ((int)(selection - charOffset) < 7)
                    //valid column number entered
                    {
                        try
                        {
                            //perform move - returns game status
                            gameResult = board.Drop((int)(selection - charOffset));
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("Error: " + e.Message + " Please try again.");
                            Console.ReadLine();
                            continue;
                        }
                    }
                    ///EVALUATE RESULT OF MOVE  
                    if (gameResult == 0)
                    {
                        endGame("You win!");
                        play = false;
                    }
                    else if (gameResult == 2)
                    {
                        endGame("The game is a draw.");
                        play = false;
                    }

                }
                //game over
                Console.Clear();

            }
            //end program
            Console.WriteLine("Goodbye!");

        }

        private static void endGame(string outcome)
            //to remove redundant code
        {
            Console.Clear();
            Console.WriteLine(outcome);
            board.Draw();
            Console.ReadLine();
            board = null;
        }

    }
}
