using Microsoft.VisualStudio.TestTools.UnitTesting;
using TTT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT.Tests
{
    [TestClass()]
    public class TilesLogicTests
    {
        [TestMethod()]
        public void CheckWhichButtonWasClicked()
        {
            int column = 3;
            int row = 4;
            bool[,] expected;
            expected = new bool[column, row];
            expected[column, row] ^= true;
            
            TilesLogic tl = new TilesLogic();
            tl.ProcessInput(column, row);

            bool[,] actual = tl.isTileActive;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void CheckNewGame()
        {
            int tilesPerEdge = 3;
            int randomShufflePower = 4;
            bool[,] expected;
            expected = new bool[tilesPerEdge, tilesPerEdge];

            TilesLogic tl = new TilesLogic();
            // bool actual = tl.NewGame(tilesPerEdge, randomShufflePower);


            Assert.AreEqual(expected, tl.isTileActive);


        }
        [TestMethod()]
        public void CheckForWin()
        {
            bool active = true;
            bool expected = true;

            TilesLogic tl = new TilesLogic();
            bool actual = tl.CheckForWin();

            Assert.AreEqual(expected, actual);
        }

    }
}