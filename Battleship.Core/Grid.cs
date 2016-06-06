using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Core
{
    public class Point
    {
        public int Row { get; set; }

        public int Col { get; set; }
    }

    public class Grid
    {
        /// <summary>
        /// Height of grid
        /// </summary>
        public int Rows { get; set; }

        /// <summary>
        /// Width of grid
        /// </summary>
        public int Cols { get; set; }

        private Cell[] _cells;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        public Grid(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            InitCells();
        }

        /// <summary>
        /// Constructor for a square grid
        /// </summary>
        /// <param name="dimension"></param>
        public Grid(int dimension)
        {
            Rows = dimension;
            Cols = dimension;
            InitCells();
        }

        private void InitCells()
        {
            var length = Rows * Cols;
            _cells = new Cell[length];
            for (int i = 0; i < length; i++)
            {
                _cells[i] = new Cell();
            }
        }

        /// <summary>
        /// Add ship to the grid
        /// </summary>
        /// <param name="ship"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public bool Add(Ship ship, int row, int col)
        {
            var points = ship.GetPointsOnGridAt(this, row, col);

            foreach (var point in points)
            {
                if (!IsCellInBounds(point.Row, point.Col) || IsCellOccupied(point.Row, point.Col))
                    return false;
            }

            foreach (var point in points)
            {
                var cell = _cells[row * Cols + col];
                cell.Ship = ship;
                cell.IsOccupied = true;
            }

            return true;
        }

        /// <summary>
        /// check if cell is occupied at row and col
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public bool IsCellOccupied(int row, int col)
        {
            return _cells[row * Cols + col].IsOccupied;
        }

        /// <summary>
        /// check if cell is in bounds at row and col
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public bool IsCellInBounds(int row, int col)
        {
            return 0 <= row && row < Rows && 0 <= col && col < Cols;
        }
    }
}
