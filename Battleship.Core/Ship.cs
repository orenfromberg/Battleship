using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Core
{
    /// <summary>
    /// type of ship
    /// </summary>
    public enum ShipType
    {
        DESTROYER = 2,
        SUBMARINE = 3,
        CRUISER = 3,
        BATTLESHIP = 4,
        CARRIER = 5,
    };

    /// <summary>
    /// heading of ship
    /// </summary>
    public enum ShipHeading
    {
        NORTH = 0,
        EAST = 1,
        SOUTH = 2,
        WEST = 3,
    };

    /// <summary>
    /// the battleship
    /// </summary>
    public class Ship
    {
        /// <summary>
        /// type of the battleship
        /// </summary>
        public ShipType Type { get; set; }

        /// <summary>
        /// heading of the battleship
        /// </summary>
        public ShipHeading Heading { get; set; }

        /// <summary>
        /// how many cells does the ship occupy
        /// </summary>
        public int Length
        {
            get
            {
                return (int) Type;
            }
        }

        /// <summary>
        /// get all points occupied by ship on grid at
        /// row and col
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public List<Point> GetPointsOnGridAt(Grid grid, int row, int col)
        {
            var points = new List<Point>();
            var rows = grid.Rows;
            var cols = grid.Cols;
            switch (Heading)
            {
                case ShipHeading.NORTH:
                    for (int i = 0; i < Length; i++)
                    {
                        int r = row + i;
                        int c = col;
                        points.Add(new Point { Row = r, Col = c});
                    }
                    break;
                case ShipHeading.EAST:
                    for (int i = 0; i < Length; i++)
                    {
                        int r = row;
                        int c = col - i;
                        points.Add(new Point { Row = r, Col = c });
                    }
                    break;
                case ShipHeading.SOUTH:
                    for (int i = 0; i < Length; i++)
                    {
                        int r = row - i;
                        int c = col;
                        points.Add(new Point { Row = r, Col = c });
                    }
                    break;
                case ShipHeading.WEST:
                    for (int i = 0; i < Length; i++)
                    {
                        int r = row;
                        int c = col + i;
                        points.Add(new Point { Row = r, Col = c });
                    }
                    break;
                default:
                    break;
            }

            return points;
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="type"></param>
        /// <param name="heading"></param>
        public Ship(ShipType type, ShipHeading heading)
        {
            Type = type;
            Heading = heading;
        }

        /// <summary>
        /// Occupy a cell with this ship
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public bool Occupy(Cell cell)
        {
            if (cell.IsOccupied)
                return false;

            cell.Ship = this;
            cell.IsOccupied = true;
            return true;
        }
    };


}
