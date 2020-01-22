using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TTT;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
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
            bool act = k.Button_Click(answer);

            // results
            Assert.AreEqual(expected, act);

            //act
            //  mw.Button_Click(new );


            //assert


        }

      //  private bool[,] results;
      //  private bool[,] check;
       
    }
}
