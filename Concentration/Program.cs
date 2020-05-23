using System;
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




