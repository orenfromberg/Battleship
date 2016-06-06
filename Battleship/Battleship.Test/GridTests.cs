using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Battleship.Core;

namespace Battleship.Test
{
    [TestClass]
    public class GridTests
    {
        [TestMethod]
        public void AddShipToGrid()
        {
            // arrange
            // battleship headed north
            Ship ship = new Ship(ShipType.BATTLESHIP, ShipHeading.NORTH);

            // square grid of 10 rows and columns
            Grid grid = new Grid(10);

            // act
            // add the ship at row 3, col 5
            bool success = grid.Add(ship, 3, 5);

            // assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void AddShipHeadedSouthOffGrid()
        {
            // arrange

            // battleship headed north
            Ship ship = new Ship(ShipType.BATTLESHIP, ShipHeading.SOUTH);

            // square grid of 10 rows and columns
            Grid grid = new Grid(10);

            // act
            bool success = grid.Add(ship, 1, 5);

            // assert
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void AddShipToOccupiedPosition()
        {
            // arrange
            Ship ship1 = new Ship(ShipType.BATTLESHIP, ShipHeading.WEST);

            Grid grid = new Grid(10);

            grid.Add(ship1, 1, 1);

            Ship ship2 = new Ship(ShipType.CRUISER, ShipHeading.NORTH);

            // act
            bool success = grid.Add(ship2, 1, 1);

            // assert
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void AddShipToUnOccupiedPosition()
        {
            // arrange
            Ship ship1 = new Ship(ShipType.BATTLESHIP, ShipHeading.WEST);

            Grid grid = new Grid(10);

            grid.Add(ship1, 1, 1);

            Ship ship2 = new Ship(ShipType.CRUISER, ShipHeading.NORTH);

            // act
            bool success = grid.Add(ship2, 2, 1);

            // assert
            Assert.IsTrue(success);
        }
    }
}
