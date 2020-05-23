using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concentration
{
    class GameManager
    {
        private Board m_Board;
        private Player m_player1;
        private Player m_player2;
        private readonly int r_maxNumOfPairs;
        private int m_numOfPairsFound = 0;

        //UI messages 

        public GameManager(Player player1, Player player2, Board gameBoard)
        {
            m_player1 = player1;
            m_player2 = player2;
            m_Board = gameBoard;
            r_maxNumOfPairs = (gameBoard.Height * gameBoard.Width) / 2;
        }


        private void startGame()
        {


        }



<<<<<<< HEAD
        //        }
        //        else
        //        {
        //            sleep
        //        }




        //            isPair=CheckIfpair(chos1, chos2);

        //            if(isPair)
        //            {
        //                //1) Player score ++
        //                /
        //            }
        //            else
        //            {

        //            }

        //            }
        //    }
        //}
=======
        public void GameSetup()
        {
             
            m_player1 = new Player(UI.getname());
            int i_boardHight = UI.

        }

>>>>>>> 09f219e8342e64b2948d1765e447ac3580193161
    }
}