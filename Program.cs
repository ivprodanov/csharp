using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OliIvanTicTacToe
{
    class Program
    {
        static char[] myarr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; // array initialization and population in a single line 

        static int hasSomeoneWon = 0;  //initializes the variable, to which the winning/draw condition method is later assigned 

        static int playerChoice;

        static int whoBegins = new Random().Next(0, 2); //generates a random number : either 0 or 1 

        static void Main(string[] args)
        {
            // who gets to make the first move 

            if (whoBegins == 0) // if the random method returns a 0
            {
                Console.WriteLine("     -");
                Thread.Sleep(350);
                Console.WriteLine("     /");
                Thread.Sleep(350);
                Console.WriteLine("     -");
                Thread.Sleep(350);
                Console.WriteLine("     \\");
                Thread.Sleep(350);
                Console.WriteLine("     ©");
                
                Thread.Sleep(800);

                Console.WriteLine("It's heads!!");

                
                Console.WriteLine("Player 0 begins");
                Console.WriteLine("The match starts in: 3");
                Thread.Sleep(1000);
                Console.WriteLine("                     2");
                Thread.Sleep(1000);
                Console.WriteLine("                     1");
                Thread.Sleep(1000);
                Console.WriteLine("                     Go!");
                Thread.Sleep(2000);
            }
            else if (whoBegins == 1) // if the random method returns a 1 
            {
                Console.WriteLine("     -");
                Thread.Sleep(350);
                Console.WriteLine("     /");
                Thread.Sleep(350);
                Console.WriteLine("     -");
                Thread.Sleep(350);
                Console.WriteLine("     \\");
                Thread.Sleep(350);
                Console.WriteLine("     o");
                Console.WriteLine("=============");
                Thread.Sleep(800);

                Console.WriteLine("It's tails!!");

                Console.WriteLine("=============");
                Console.WriteLine("Player X begins");
                Console.WriteLine("The match starts in: 3");
                Thread.Sleep(1000);
                Console.WriteLine("                     2");
                Thread.Sleep(1000);
                Console.WriteLine("                     1");
                Thread.Sleep(1000);
                Console.WriteLine("                     Go!");
                Thread.Sleep(2000);
            }

            

            do
            {
                Console.Clear();
                Console.WriteLine("Player 1 : 0  -------   Player 2 : X"); 
                Console.WriteLine("\n");
                Board(); // calls the board drawing method

                

                if (!int.TryParse(Console.ReadLine(), out playerChoice)) //|| !(playerChoice >= 1 && playerChoice < myarr.Length)) --- let's leave this here just in case
                {   
                    //The player who gave an invalid input gets to go again.
                    if(whoBegins == 1) 
                    {
                        whoBegins--;
                    }
                    if(whoBegins == 0)
                    {
                        whoBegins++;
                    }
                    Console.WriteLine("Use a NUMBER from the BOARD. Not a letter, not your primary teacher's name, a number!! "); // An error handling alternative
                    Console.WriteLine("Don't type anything until this message hides..");
                    Thread.Sleep(5000);
                }

                if ((myarr[playerChoice] != 'X' && myarr[playerChoice] != 'O') ) //if there is no X or O at the chosen position
                {
                    if (whoBegins == 0)   
                    {
                        myarr[playerChoice] = 'O'; //The case in which player one begins. The game starts with 'O'

                        whoBegins++;
                    }
                    else if(whoBegins == 1)
                    {
                        myarr[playerChoice] = 'X';//The case in which player two begins. The game starts with 'X' 
                        whoBegins--;
                    }
                }
                else // If the position which the player chooses is already marked, output a message and wait two seconds  
                {
                    Console.WriteLine("Sorry the row {0} is already marked with {1}", playerChoice, myarr[playerChoice]);

                    Console.WriteLine("\n");

                    Console.WriteLine("Please hold on for two seconds. The board is loading again..");

                    Thread.Sleep(2000); 
                }

                
                hasSomeoneWon = CheckIfSomeoneWon(); // the winning/draw condition method is assigned to this variable and is checked on each move a player has made

            } while (hasSomeoneWon != 1 && hasSomeoneWon != -1); // repeat until the one of the winning conditions or the draw condition is met

            Console.Clear();// clearing the console  

            Board();// outputting the board  

            if (hasSomeoneWon == 1)// if the value is 1 - someone won.  
            {
                if (whoBegins == 1) //if the value of whoBegins is 1 - player one has won.
                {
                    Console.WriteLine("Player one has won! 'O' wins!!!");
                    Console.WriteLine("Shake hands and press Enter to exit the game...");
                }
                else if (whoBegins == 0) //if the value of whoBegins is 0 - player one has won.
                {
                    Console.WriteLine("Player two has won! 'X' wins!!!");
                    Console.WriteLine("Shake hands and press Enter to exit the game...");
                }
            }

            else if(hasSomeoneWon == -1) // if the value of hasSomeWon is -1 there's a draw. (Look at the last few lines of code)   
            {
                Console.WriteLine("IT'S A DRAW!");
                Console.WriteLine("You feeling like you've got a bit of a rematch in you? if so, press Enter and restart the game...");
            }
            Console.ReadLine();
        }

        private static void Board() //draws the board
        {
            Console.WriteLine("  _________________ ");
            Console.WriteLine(" *_________________* ");
            Console.WriteLine("||     |     |     ||");
            Console.WriteLine("||  {0}  |  {1}  |  {2}  ||",myarr[1],myarr[2],myarr[3]);
            Console.WriteLine("||_____|_____|_____||");
            Console.WriteLine("||     |     |     ||");
            Console.WriteLine("||  {0}  |  {1}  |  {2}  ||", myarr[4], myarr[5], myarr[6]);
            Console.WriteLine("||_____|_____|_____||");
            Console.WriteLine("||     |     |     ||");
            Console.WriteLine("||  {0}  |  {1}  |  {2}  ||", myarr[7], myarr[8], myarr[9]);
            Console.WriteLine("||_____|_____|_____||");
            Console.WriteLine(" *_________________* ");

        }

        private static int CheckIfSomeoneWon()  
        {
            //horizontal winning condition

            if (myarr[1] == myarr[2] && myarr[2] == myarr[3])
            {
                return 1;
            }
            else if (myarr[4] == myarr[5] && myarr[5] == myarr[6])
            {
                return 1;
            }
            else if(myarr[7] == myarr[8] && myarr[8] == myarr[9])
            {
                return 1;
            }


            //vertical winning condition

            if (myarr[1] == myarr[4] && myarr[4] == myarr[7])
            {
                return 1;
            }
            else if (myarr[2] == myarr[5] && myarr[5] == myarr[8])
            {
                return 1;
            }
            else if (myarr[3] == myarr[6] && myarr[6] == myarr[9])
            {
                return 1;
            }

            //diagonal winning condition

            if (myarr[3] == myarr[5] && myarr[5] == myarr[7])
            {
                return 1;
            }
            else if (myarr[1] == myarr[5] && myarr[5] == myarr[9])
            {
                return 1;
            }

            //draw condition 

            else if (myarr[1] != '1' && myarr[2] != '2' && myarr[3] != '3' && myarr[4] != '4' && myarr[5] != '5' && myarr[6] != '6' && myarr[7] != '7' && myarr[8] != '8' && myarr[9] != '9')
            {
                return -1;
            }

            else
            {
                return 0;
            }
        }
    }
}

