using System;
using System.Text;
using System.Threading;
using Ex02.ConsoleUtils;

namespace Concentration
{
    public class UI
    {
        private const char k_exitGame = 'Q'; 

        public static void PrintWellcomeMessage()
        {
            Console.WriteLine("Welcome To Concentration Game!");
        }
        
        public static string GetPlayerName()
        {
            string playerName;
            bool isValid;

            Console.Write("Please Enter Player Name: ");
            do
            {
                isValid = true;
                playerName = Console.ReadLine();
                if (playerName.Length == 0)
                {
                    isValid = false;
                    Console.Write("Please Try Again: ");
                }
            } while (isValid == false);

            return playerName;
        }

        public static string GetRivalType()
        { 
            string rivalType;
            bool isValid;

            Console.WriteLine("Who Do You Want To Play With?\nPress 1 For Other Player\nPress 2 For Computer");
            do
            {
                isValid = true;
                rivalType = Console.ReadLine();
                if (rivalType != "0" && rivalType != "1") 
                {
                    isValid = false;
                    Console.Write("Please Try Again: ");
                }
            } while (isValid == false);

            return rivalType;
        }

        public static void GetBoardHeightAndWidth(out string o_height, out string o_width)
        {
            bool isValid;

            Console.Write("Please Enter The Hight Of the Board (4 or 6): ");
            do
            {
                isValid = true;
                o_height = Console.ReadLine();
                if (o_height != "4" && o_height != "6")
                {
                    isValid = false;
                    Console.Write("Please Try Again: ");
                }
            } while (isValid == false);

            Console.Write("Please Enter The Width Of the Board (4 or 6): ");
            do
            {
                isValid = true;
                o_width = Console.ReadLine();
                if (o_width != "4" && o_width != "6")
                {
                    isValid = false;
                    Console.Write("Please Try Again: ");
                }
            } while (isValid == false);
        }

        public static void PrintWhichPlayerTurn(string i_name)
        {
            Console.WriteLine(i_name + "'s Turn:");
        }

        public static string GetCardLocation()
        {
            ///Check Validity (check if already flipped. check if valid chars) - if Card1Location == Q ----> Exit 

            string cardLocation;
            char rowNum, colLetter;
            bool isValid;

            Console.Write("Please Enter Card Location On The Board(For Example: A1): ");
            do
            {
                isValid = true;
                cardLocation = Console.ReadLine();
                rowNum = cardLocation[0];
                colLetter = cardLocation[1];
                if (rowNum == k_exitGame)
                {
                    ExitGame();
                }
                else if (/* Not like the string template*/)
                {
                    isValid = false;
                    Console.Write("Template Mismatch!, Card Location Should Be CapitelLetter&Number, Please Try Again: ");
                }
                else if (/* Point is not on board */)
                {
                    isValid = false;
                    Console.Write("Point Is Not On Board!, Please Try Again: ");
                }
            } while (isValid == false);

            return cardLocation;
        }

        public static void EndOfGameStatusAndCheckRematch(StringBuilder i_msg)
        {
            bool isValid;
            string input;
            Console.WriteLine(i_msg);
            Console.WriteLine("Do You Want A Rematch?(y/n)");
            do
            {
                isValid = true;
                input = Console.ReadLine();
                if (input != "y" && input != "n")
                {
                    isValid = false;
                    Console.Write("Please Try Again: ");
                }
            } while (isValid == false);

            if (input == "y")
            {
                // rematch
            }
            else
            {
                ExitGame();
            }
        }
        private static void ExitGame()
        {
            Console.WriteLine("Thanks For Playing Concentration, See You Next Time (:");
            Thread.Sleep(2000);
            Environment.Exit(1);
        }

        public static void PrintBoard()
        {
            Screen.Clear();
           // Call Board.Show()
        }
    }
}


