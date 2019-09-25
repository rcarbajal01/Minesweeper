using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    public class Square
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int mineNeighbors { get; set; }

        public bool isMine { get; set; }

        public bool hidden { get; set; }

        public Square (int x, int y)
        {
            X = x;
            Y = y;
            hidden = true;
            isMine = false;
        }
    }
}
