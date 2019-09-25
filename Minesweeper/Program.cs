using System;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid grid = new Grid();
            grid.showGrid();

            string inputX = String.Empty;
            string inputY = String.Empty;
            do
            {
                Console.WriteLine("Enter square X position");
                inputX = Console.ReadLine();
                Console.WriteLine("Enter square Y position");
                inputY = Console.ReadLine();
            }
            while (!grid.revealSquare(Convert.ToInt16(inputX), Convert.ToInt16(inputY)));
        }

        
    }
}
