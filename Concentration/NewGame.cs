using System;
using System.Text;
using System.Threading;

namespace Concentration
{
    internal class NewGame
    {
        internal static void StartGame()
        {
            string firstPlayerName, secondPlayerName, rivalType;

            UI.PrintWellcomeMessage();
            firstPlayerName = UI.GetPlayerName();
            rivalType = UI.GetRivalType();
            if (rivalType == "1")
            {
                secondPlayerName = UI.GetPlayerName();
            }
            else
            {
                secondPlayerName = "COMPUTER";
            }

            RunGame(firstPlayerName, secondPlayerName);
        }

        internal static void RunGame(string i_firstPlayerName, string i_secondPlayerName)
        {
            string firstCardLocation, secondCardLocation;
            bool isEndOfGame = false;
            const int k_freezeTime = 1750;

            UI.GetBoardHeightAndWidth(out string height, out string width);
            GameManager gameManager = new GameManager(i_firstPlayerName, i_secondPlayerName, height, width);
            Player currentPlayer = gameManager.Player1;
            while (isEndOfGame == false)
            {
                UI.PrintBoard(gameManager.Board);
                if (currentPlayer.Type == ePlayerType.Computer)
                {
                    UI.PrintWhichPlayerTurn(gameManager.Player2.Name);
                    firstCardLocation = gameManager.FlipCardRandomAndReturnCardLocation();
                    UI.PrintBoard(gameManager.Board);
                    UI.PrintWhichPlayerTurn(gameManager.Player2.Name);
                    Thread.Sleep(k_freezeTime);
                    secondCardLocation = gameManager.FlipCardRandomAndReturnCardLocation();
                    UI.PrintBoard(gameManager.Board);
                }
                else
                {
                    if (gameManager.PlayerTurn == ePlayersTurn.Player1)
                    {
                        UI.PrintWhichPlayerTurn(gameManager.Player1.Name);
                    }
                    else
                    {
                        UI.PrintWhichPlayerTurn(gameManager.Player2.Name);
                    }

                    firstCardLocation = UI.GetCardLocation(gameManager.Board);
                    gameManager.FlipCard(firstCardLocation);
                    UI.PrintBoard(gameManager.Board);
                    secondCardLocation = UI.GetCardLocation(gameManager.Board);
                    gameManager.FlipCard(secondCardLocation);
                    UI.PrintBoard(gameManager.Board);
                }

                if (gameManager.IsPair(firstCardLocation, secondCardLocation) == false)
                {
                    gameManager.CardsNotMatchFlipBack(firstCardLocation, secondCardLocation);
                    if (currentPlayer == gameManager.Player1)
                    {
                        currentPlayer = gameManager.Player2;
                    }
                    else
                    {
                        currentPlayer = gameManager.Player1;
                    }
                }
                else
                {
                    gameManager.PairWasFounded();
                }

                if (gameManager.NumOfPairsFounded == gameManager.MaxNumOfPairs)
                {
                    isEndOfGame = true;
                }
            }

            StringBuilder pointStatusAndWinnerMsg = gameManager.PointsStatusAndWinner();
            if (UI.EndOfGameStatusAndCheckRematch(pointStatusAndWinnerMsg) == true)
            {
                RunGame(gameManager.Player1.Name, gameManager.Player2.Name);
            }
            else
            {
                UI.ExitGame();
            }
        }
    }
}
