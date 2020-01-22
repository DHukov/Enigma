using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TTT;

namespace UnitTestProject1
{
    [TestClass]
    public class MW
    {
        private bool[,] results;
        private bool[,] check;
        [TestMethod]
        public void CheckWhereWasClickedButton()
        {
         //   object mw = new MainWindow();
            //arrange
            object sender;
          //  var button = sender;
            int column = 5;
            int row = 4;
            int i = column;
            int j = row;

            bool expected = results[i, j];
            bool answer = check[5, 4];
            /*
            int i = 5;
            int j = 3;
            */
          // results[i,j] ^= true;

            MainWindow k = new MainWindow();
             object  act = k.Button_Click(answer);

            // results
            Assert.AreEqual(expected, act);

            //act
            //  mw.Button_Click(new );


            //assert
        }
        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}
