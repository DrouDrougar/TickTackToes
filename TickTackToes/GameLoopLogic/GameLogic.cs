using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TickTackToes.GameLoopLogic
{
    public class GameLogic
    {
        public string CurrentPlayer { get; set; } = X;

        private const string X = "X";
        private const string O = "O";
        private string[,] Board = new string[3, 3];
  
        public void SetNextPlayer()
        {
            if (CurrentPlayer == X)
            {
                CurrentPlayer = O;
            }
            else
            {
                CurrentPlayer = X;
            }
        }


        public bool WinCondition()
        {
            //checking rows
            for (var i = 0; i < 3; i++)
            {
                if (!String.IsNullOrWhiteSpace(Board[i, 0]))
                {
                    if (Board[i, 0] == Board[i, 1] && Board[i, 0] == Board[i, 2])
                    {
                        return true;
                    }
                }
            }
            //checking collums
            for (var i = 0; i < 3; i++)
            {
                if (!String.IsNullOrWhiteSpace(Board[0, i]))
                {
                    if (Board[0, i] == Board[1, i] && Board[0, i] == Board[2, i])
                    {
                        return true;
                    }
                }
            }
            //checking diagonals where 1, 1 is the middle of the grid.
            if (!String.IsNullOrWhiteSpace(Board[1, 1]))
                {
                    if (Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2])
                    {
                        return true;
                    }
                if (Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0])
                {
                    return true;
                }
            }
            
            return false;
        }
        //we take in the positions to make sure that the board stays in sync.
        internal void UpdateBoard(Position position, string value)
        {
            Board[position.x, position.y] = value;
        }

        public bool WinPatterns()
        {
            string grid1 = "0,2";
            string grid2 = "1,2";
            string grid3 = "2,2";

            string grid4 = "0,1";
            string grid5 = "1,1";
            string grid6 = "2,1";

            string grid7 = "0,0";
            string grid8 = "1,0";
            string grid9 = "2,0";


            if (grid1 == X && grid2 == X && grid3 == X)
            { return true; }
            //456
            if (grid4 == X && grid5 == X && grid6 == X)
            { return true; }
            //789
            if (grid7 == X && grid8 == X && grid9 == X)
            { return true; }
            //147
            if (grid1 == X && grid4 == X && grid7 == X)
            { return true; }

            //159
            if (grid1 == X && grid5 == X && grid9 == X)
            { return true; }
            //258
            if (grid8 == X && grid5 == X && grid2 == X)
            { return true; }
            //369
            if (grid9 == X && grid6 == X && grid3 == X)
            { return true; }
            //357
            if (grid7 == X && grid5 == X && grid3 == X)
            { return true; }


            if (grid1 == O && grid2 == O && grid3 == O)
            { return true; }
            //456
            if (grid4 == O && grid5 == O && grid6 == O)
            { return true; }
            //789
            if (grid7 == O && grid8 == O && grid9 == O)
            { return true; }
            //147
            if (grid1 == O && grid4 == O && grid7 == O)
            { return true; }

            //159
            if (grid1 == O && grid5 == O && grid9 == O)
            { return true; }
            //258
            if (grid8 == O && grid5 == O && grid2 == O)
            { return true; }
            //369
            if (grid9 == O && grid6 == O && grid3 == O)
            { return true; }
            //357
            if (grid7 == O && grid5 == O && grid3 == O)
            { return true; }
            return false;
        }


    }

    //public int x {  get; set; }
    //public int y { get; set; }

    //private const string  Grid7 = "0,0";
    //private const string  Grid4 = "0,1";
    //private const string  Grid1 = "0,2";
    //private const string  Grid8 = "1,0";
    //private const string  Grid5 = "1,1";
    //private const string  Grid2 = "1,2";
    //private const string  Grid9 = "2,0";
    //private const string  Grid6 = "2,1";
    //private const string  Grid3 = "2,2";
    //public string ComputerClick()
    //{

    //    while (true)
    //    {
    //        var random = new Random();
    //        var locationString1 = x;
    //        var locationString2 = y;
    //        string position;
    //        locationString1 = random.Next(3);
    //        locationString2 = random.Next(3);

    //        if (String.IsNullOrWhiteSpace(Board[locationString1, locationString2]))
    //        {
    //            position = locationString1 + "," + locationString2;

    //            if (position == Grid1)
    //            {
    //                return "Grid1";

    //            }
    //            if (position == Grid2)
    //            {
    //                return "Grid2";
    //            }
    //            if (position == Grid3)
    //            {
    //                return "Grid3";
    //            }
    //            if (position == Grid4)
    //            {
    //                return "Grid4";
    //            }
    //            if (position == Grid5)
    //            {
    //                return "Grid5";
    //            }
    //            if (position == Grid6)
    //            {
    //                return "Grid6";
    //            }
    //            if (position == Grid7)
    //            {
    //                return "Grid7";
    //            }
    //            if (position == Grid8)
    //            {
    //                return "Grid8";
    //            }
    //            if (position == Grid9)
    //            {
    //                return "Grid9";
    //            }
    //            else
    //            {

    //                return null;
    //            }

    //        }
    //    }
    //}

}
