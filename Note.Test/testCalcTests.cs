using BookLibrary;
using BookLibrary.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note.Test
{
    [TestClass]
    public class testCalcTests
    {
        [TestMethod]
        public void asd()
        {
            // Arrange
            var c = new testCalc();
            var asd = c.sum(1,2);

            //var noteName = "note name";
            //var noteDetails = "note details";
            //var asd = handler.Get();

            // Act


            // Assert
           Assert.AreEqual(3, 3);

        }
    }
}
