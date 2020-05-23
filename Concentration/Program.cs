using System;
namespace Concentration
{
    public class Program
    {
        public static void Main()
        {
          //  Board b = new Board(4, 4);
           // Player p1 = new Player("Nir");
          //  Player p2 = new Player("Liran");
           // GameManager gm = new GameManager(p1, p2, b);
            UI ui = new UI();
            ui.RunMenu();
            ui.RunGame();
           


            //printBoard(B);


            Console.WriteLine("\n\nPress Enter To Exit...");
            Console.ReadLine();
        }
    }
}




