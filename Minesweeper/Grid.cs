using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    public class Grid
    {

        public static List<Square> Squares { get; set; }
        public Grid()
        {
            Squares = new List<Square>();
            for(int i=0; i<8; i++)
            {
                for(int j=0; j<8; j++)
                {
                    Squares.Add(new Square(j, i));
                }
            }

            addMines();
            foreach (Square s in Squares)
            {
                addNeighbors(s, false);
            }


        }

        public void addMines()
        {
            Random ran = new Random();
            List<int[]> xyMineList = new List<int[]>();
            int ranNumX = ran.Next(0, 7);
            int ranNumY = ran.Next(0, 7);
            while (xyMineList.Count <= 10)
            {
                if (!xyMineList.Contains(new int[] { ranNumX, ranNumY }))
                    xyMineList.Add(new int[] { ranNumX, ranNumY });
                ranNumX = ran.Next(0, 7);
                ranNumY = ran.Next(0, 7);
            }

            int i = 0;
            foreach(int[] n in xyMineList)
            {
                Squares.Find(x => x.X == n[0] && x.Y == n[1]).isMine=true;
                i++;
            }
        }

        public void addNeighbors(Square current, bool revealNeighboors)
        {
            List<Square> neighborsList= Squares.FindAll(s => s.X >= current.X - 1 && s.X <= current.X + 1 && s.Y >= current.Y - 1 && s.Y <= current.Y + 1 && !s.isMine);
            neighborsList.Remove(current);
            if(!revealNeighboors)
                current.mineNeighbors = neighborsList.Count;
            else
            {
                foreach(Square s in neighborsList)
                {
                    if(!s.isMine)
                        s.hidden = false;
                }
            }
        }

        public bool revealSquare(int inputX, int inputY)
        {
            bool isMine = Squares.Find(x => x.X == inputX && x.Y == inputY).isMine;
            Square s = Squares.Find(x => x.X == inputX && x.Y == inputY);
            s.hidden = false;
            if (!isMine)
            {                
                addNeighbors(s, true);
            }
            showGrid();
            if (isMine)
            {
                Console.WriteLine("Game Over");
                Console.ReadLine();
            }            
            return isMine;
        }

        public void showGrid()
        {            
            for (int i = 0; i < 8; i++)
            {
                string line = String.Empty;
                for (int j = 0; j < 8; j++)
                {
                    Square s = Squares.Find(x => x.X == j && x.Y==i);
                    if (s.hidden)
                        line += "H";
                    else if (!s.hidden && !s.isMine)
                        line += s.mineNeighbors;
                    else if (s.isMine && !s.hidden)
                        line += "X";                    
                }
                Console.WriteLine(line);
            }
        }
    }
}
