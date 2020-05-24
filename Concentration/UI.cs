using System;
using Ex02.ConsoleUtils;

namespace Concentration
{
    public class UI
    {
        private const char k_exitGame = 'Q'; 

        public static void WellcomeMessage()
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

        public static void getBoardHeightAndWidth(string io_height, string io_width)
        {
            bool isValid;

            Console.Write("Please Enter The Hight Of the Board (4 or 6): ");
            do
            {
                isValid = true;
                io_height = Console.ReadLine();
                if (io_height != "4" && io_height != "6")
                {
                    isValid = false;
                    Console.Write("Please Try Again: ");
                }
            } while (isValid == false);

            Console.Write("Please Enter The Width Of the Board (4 or 6): ");
            do
            {
                isValid = true;
                io_width = Console.ReadLine();
                if (io_width != "4" && io_width != "6")
                {
                    isValid = false;
                    Console.Write("Please Try Again: ");
                }
            } while (isValid == false);
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
                    isValid = false;
                    Console.Write("Please Try Again: ");
                
            } while (isValid == false);

            return cardLocation;
        }



        public static void AnnounceWinnerAndCheckRematch()
        {
            //PrintEndGameStatus();
            if (/*want rematch*/true)
            {
                //
            }
            else
            {
                //PrintEndGameStatus();
                //15 : 0
                //The winner is Liran
                ExitGame();
            }
        }
        private static void ExitGame()
        {

            Console.WriteLine("Thanks For Playing Concentration, See You Next Time (:");

        }

        public static void PrintBoard()
        {
            Screen.Clear();
            //Call Board.Show()

        }
    }
}


