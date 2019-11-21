///Authors:     Nick Smith
///             Kyle Wyse 
///Date:        7 Feb 2019
///Description: Code to run connect four application

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    class PlayConnectFour
    {
        static void Main(string[] args)
        {
            ///STARTUP
            Board board;
            bool running = true;
            string input;
            char selection = '*';
            //continue an existing game?
            //load an existing profile?
            //enter player one name
            //enter player two name

            while (running)
            {
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

                //initaialize game board & variables
                board = new Board();
                char piece = '+'; // '+' ==> player 1
                                  // 'o' ==> player 2

                ///PLAY CONNECT FOUR
                int gameResult = 1; // 
                while (selection != 'Q') 
                {
                    Console.Clear();
                    Console.WriteLine("Enter the row number (1-7) where you would like to place your peice.\n" +
                                      "Enter 'Q' to quit game.\n");

                    ///DRAW THE BOARD 
                    board.Draw();
                    ///GET NEXT ACTION
                    input = Console.ReadLine().ToUpper(); // FIXME: simply pressing enter will crash program
                    try
                    {
                        selection = input[0];
                    }
                    catch (IndexOutOfRangeException) // no input
                    {
                        continue;
                    }

                    //if (input == null) continue;
                    if ((int)(selection - 48) <= 7)
                    {
                        if (board.ColumnIsFull((int)(selection - 49)))
                        {
                            Console.WriteLine("That column is full. Please try again.");
                            continue; // go get a new input
                        }
                        //perform move - returns game status
                        gameResult = board.Drop((int)(selection - 49), piece);
                        //change player peice
                        if (piece == '+') piece = 'o';
                        else piece = '+';
                    }

                    if (gameResult == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("You win!");
                        board.Draw();
                        Console.ReadLine();
                        break;
                    }
                    else if (gameResult == 2) Console.WriteLine("The game is a draw.");

                }

                
                Console.Clear();

            }

            Console.WriteLine("Goodbye!");

        }
    }
}
