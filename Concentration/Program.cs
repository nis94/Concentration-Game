﻿using System;
namespace Concentration
{
    public class Program
    {
        public static void Main()
        {
            Board B = new Board(4, 4);
            B.printBoard();
           

            Console.WriteLine("\n\nPress Enter To Exit...");
            Console.ReadLine();
        }
    }
}



//    Liran - Player
//- name + score + chosenCards[2] 
//- c'tor + getters\setters + chooseCard/Quit + RandomChoose (for computer) 



//Nir - Board + Card
//print X 2, 



//Both - Menager 
//- turnNumber, player1, player2, board, (? gameStatus?)
//- checkIfPair, updateBoard(according to the chosen pair),  nextRound(according to the current player), checkGameStatus--->UI