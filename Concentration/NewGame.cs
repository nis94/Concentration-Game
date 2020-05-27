using System;
using System.Text;
using Ex02.ConsoleUtils;

namespace Concentration
{
    public class NewGame
    {
        public static void Setup()
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

        public static void RunGame(string i_firstPlayerName, string i_secondPlayerName)
        {
            string height, width, firstCardLocation, secondCardLocation;
            bool isEndOfGame = false;

            UI.GetBoardHeightAndWidth(out height, out width); 
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
                    secondCardLocation = gameManager.FlipCardRandomAndReturnCardLocation();
                    UI.PrintBoard(gameManager.Board);
                }
                else
                {
                    if(gameManager.PlayerTurn == ePlayersTurn.Player1)
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
                    if(currentPlayer==gameManager.Player1)
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

            StringBuilder pointStatusAndWinnerMsg= gameManager.PointsStatusAndWinner();
            if(UI.EndOfGameStatusAndCheckRematch(pointStatusAndWinnerMsg)==true)
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
