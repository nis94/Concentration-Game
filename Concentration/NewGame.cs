using System;

namespace Concentration
{
    public class NewGame
    {
        public static void Setup()
        {
            string firstPlayerName, secondPlayerName, rivalType;

            UI.WellcomeMessage(); 
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

            UI.getBoardHeightAndWidth(height, width); //$$$ Maybe I should send by ref
            GameManager gameManager = new GameManager(i_firstPlayerName, i_secondPlayerName, height, width);

            while (isEndOfGame == false)
            {
                UI.PrintBoard();
                firstCardLocation=UI.GetCardLocation(); 

                gameManager.flipCard(firstCardLocation);
                UI.PrintBoard();

                secondCardLocation = UI.GetCardLocation(); 
                gameManager.flipCard(secondCardLocation);
                UI.PrintBoard();

                if (gameManager.isPair(firstCardLocation, secondCardLocation) == false)
                {
                    gameManager.cardsNotMatch(firstCardLocation, secondCardLocation);
                }
                else
                {
                    gameManager.pairWasFounded();
                }

                if (gameManager.NumOfPairsFounded == gameManager.MaxNumOfPairs)
                {
                    isEndOfGame = true;
                }
            }

            string winnerName = gameManager.PointsStatusAndWinner();// $$$ TO DO
            UI.AnnounceWinnerAndCheckRematch(winnerName);
        }
    }
}
