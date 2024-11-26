using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TickTackToes.GameLoopLogic;

namespace TickTackToes.Models
{
    public class GameGrid : Computer
    {
        public string GridPositionName { get; set; }
        public int GridXValue { get; set; }
        public int GridYValue { get; set; }
    }
}
