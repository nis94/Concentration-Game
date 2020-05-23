using System;
namespace Concentration
{
    public class Program
    {
        public static void Main()
        {
            Board B = new Board(4, 4);
            UI.printBoard(B);
           

            Console.WriteLine("\n\nPress Enter To Exit...");
            Console.ReadLine();
        }
    }
}




