using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Core
{
    public enum CellState
    {
        UNTARGETED,
        TARGETED_HIT,
        TARGETED_MISS,
    };

    public class Cell
    {
        /// <summary>
        /// whether the cell is currently occupied by a ship
        /// </summary>
        public bool IsOccupied { get; set; }

        /// <summary>
        /// Ship that is occupying this cell
        /// </summary>
        public Ship Ship { get; set; }

        /// <summary>
        /// State of the cell
        /// </summary>
        public CellState State { get; set; }

    }
}
