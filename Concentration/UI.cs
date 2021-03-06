﻿using System;
using System.Text;
using System.Threading;
using Ex02.ConsoleUtils;

namespace Concentration
{
    internal class UI
    {
        internal static void PrintWellcomeMessage()
        {
            Console.WriteLine("Welcome To Concentration Game");
            Console.WriteLine(Environment.NewLine);
        }

        internal static string GetPlayerName()
        {
            string playerName;
            bool isValid;

            Console.Write("Please Enter Player Name: ");
            do
            {
                playerName = Console.ReadLine();
                if (playerName.Length == 0)
                {
                    isValid = false;
                    Console.Write("Name Length Should Be Minimum 1 Letter, Please Try Again: ");
                }
                else if (playerName == "COMPUTER")
                {
                    isValid = false;
                    Console.Write("Player Name Can't Be 'COMPUTER', Please Try Again: ");
                }
                else
                {
                    break;
                }
            }
            while (isValid == false);

            return playerName;
        }

        internal static string GetRivalType()
        {
            const string k_VsPlayer = "1", k_VsComputer = "2";
            string rivalType;
            bool isValid;

            Console.WriteLine("Who Do You Want To Play With?\nPress 1 For Other Player\nPress 2 For Computer");
            do
            {
                isValid = true;
                rivalType = Console.ReadLine();
                if (rivalType != k_VsPlayer && rivalType != k_VsComputer)
                {
                    isValid = false;
                    Console.Write("You Can Choose 1 Or 2 Only, Please Try Again: ");
                }
            }
            while (isValid == false);

            return rivalType;
        }

        internal static void GetBoardHeightAndWidth(out string o_height, out string o_width)
        {
            const string k_MinSize = "4", k_MedSize = "5", k_MaxSize = "6";
            bool isValid;

            Console.Write("Please Enter The Hight Of the Board (4 - 6): ");
            do
            {
                o_height = Console.ReadLine();
                if (int.Parse(o_height) < int.Parse(k_MinSize) || int.Parse(o_height) > int.Parse(k_MaxSize))
                {
                    isValid = false;
                    Console.Write("Hight Can Be Only Between 4 And 6, Please Try Again: ");
                }
                else
                {
                    break;
                }
            } 
            while (isValid == false);

            Console.Write("Please Enter The Width Of the Board (4 - 6): ");
            do
            {
                o_width = Console.ReadLine();
                if (int.Parse(o_width) < int.Parse(k_MinSize) || int.Parse(o_width) > int.Parse(k_MaxSize))
                {
                    isValid = false;
                    Console.Write("Hight Can Be Only Between 4 And 6, Please Try Again: ");
                }
                else if (o_height == k_MedSize && o_width == k_MedSize)
                {
                    isValid = false;
                    Console.Write("Total Board Size Should Be Even. Please Choose 4 Or 6: ");
                }
                else
                {
                    break;
                }
            } 
            while (isValid == false);
        }

        internal static void PrintWhichPlayerTurn(string i_name)
        {
            Console.WriteLine(i_name + "'s Turn");
        }

        internal static string GetCardLocation(Board i_gameBoard)
        {
            const char k_exitGame = 'Q';

            string cardLocation;
            bool isValid;

            Console.WriteLine("Please Enter Card Location On The Board (For Example 'A1')");
            Console.WriteLine("Or Press 'Q' To Exit The Game");
            do
            {
                isValid = true;
                cardLocation = Console.ReadLine();

                if (cardLocation.Length == 1)
                {
                    if (cardLocation[0] == k_exitGame)
                    {
                        ExitGame();
                    }
                    else
                    {
                        isValid = false;
                        Console.Write("Input Size Mismatch, Please Try Again: ");
                    }
                }
                else if (cardLocation.Length > 2 || cardLocation.Length == 0)
                {
                    isValid = false;
                    Console.Write("Input Size Mismatch, Please Try Again: ");
                }
                else
                {
                    int column = cardLocation[0] - 'A';
                    int row = cardLocation[1] - '1';
                    if (column >= i_gameBoard.Width || column < 0 || row >= i_gameBoard.Height || row < 0)
                    {
                        isValid = false;
                        Console.Write("No Such Location On Board!, Please Try Again: ");
                    }
                    else if (i_gameBoard[row, column].IsFlipped == true)
                    {
                        isValid = false;
                        Console.Write("Location Is Already Taken!, Please Try Again: ");
                    }
                    else
                    {
                        break;
                    }
                }
            } 
            while (isValid == false);

            return cardLocation;
        }

        internal static bool EndOfGameStatusAndCheckRematch(StringBuilder i_msg)
        {
            const string k_yes = "Y", k_no = "N";
            bool isValid, isRematchWanted;
            string input;

            Console.WriteLine(i_msg);
            Console.WriteLine("Do You Want A Rematch? (Y/N)");
            do
            {
                isValid = true;
                input = Console.ReadLine();
                if (input != k_yes && input != k_no)
                {
                    isValid = false;
                    Console.Write("Invalid Input!, Please Try Again: ");
                }
            }
            while (isValid == false);

            if (input == k_yes)
            {
                isRematchWanted = true;
            }
            else
            {
                isRematchWanted = false;
            }
            return isRematchWanted;
        }

        internal static void ExitGame()
        {
            const int k_validExit = 1, k_freezeTime = 4000;

            Console.WriteLine("Thanks For Playing Concentration, See You Next Time (:");
            Thread.Sleep(k_freezeTime);
            Environment.Exit(k_validExit);
        }

        internal static void PrintBoard(Board i_gameBoard)
        {
            char ch = 'A';
            Screen.Clear();
            Console.Write("     ");
            for (int j = 0; j < i_gameBoard.Width; j++)
            {
                Console.Write(ch.ToString());
                Console.Write("   ");
                ch++;
            }

            for (int i = 0; i < i_gameBoard.Height; i++)
            {
                Console.Write(Environment.NewLine);
                Console.Write("   ");
                for (int j = 0; j < i_gameBoard.Width; j++)
                {
                    Console.Write("====");
                }
                Console.Write("=");
                Console.Write(Environment.NewLine);
                Console.Write((i + 1).ToString());
                Console.Write(" ");
                for (int j = 0; j < i_gameBoard.Width; j++)
                {
                    Console.Write(" | ");
                    if (i_gameBoard[i, j].IsFlipped == true)
                    {
                        i_gameBoard[i, j].Show();
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write(" |");
            }

            Console.Write(Environment.NewLine);
            Console.Write("   ");
            for (int j = 0; j < i_gameBoard.Width; j++)
            {
                Console.Write("====");
            }

            Console.WriteLine("=");
        }
    }
}
