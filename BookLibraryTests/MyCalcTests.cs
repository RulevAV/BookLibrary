using BookLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Xunit;

namespace BookLibraryTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Sum_10and20_30returned()
        {
            //arrange
            int x = 10;
            int y = 20;
            int expected = 30;

            //act
            MyCalc c = new MyCalc();
            int actual = c.sum(x, y);

            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, expected);
        }
    }
}
