using System;
using DLLs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FunctionTests
    {
        readonly Function _function = new Function();

        #region GetDayOfWeek
        [TestMethod]
        public void Can_Get_Day_Monday()
        {
            // Arrange
            var num = 1;

            // Act
            var result = _function.GetDayOfWeek(num);

            //Assert
            Assert.AreEqual("monday", result);
        }

        [TestMethod]
        public void Can_Get_Day_Tuesday()
        {
            // Arrange
            var num = 2;

            // Act
            var result = _function.GetDayOfWeek(num);

            //Assert
            Assert.AreEqual("tuesday", result);
        }

        [TestMethod]
        public void Can_Get_Day_Wednesday()
        {
            // Arrange
            var num = 3;

            // Act
            var result = _function.GetDayOfWeek(num);

            //Assert
            Assert.AreEqual("wednesday", result);
        }

        [TestMethod]
        public void Can_Get_Day_Thursday()
        {
            // Arrange
            var num = 4;

            // Act
            var result = _function.GetDayOfWeek(num);

            //Assert
            Assert.AreEqual("thursday", result);
        }

        [TestMethod]
        public void Can_Get_Day_Friday()
        {
            // Arrange
            var num = 5;

            // Act
            var result = _function.GetDayOfWeek(num);

            //Assert
            Assert.AreEqual("friday", result);
        }

        [TestMethod]
        public void Can_Get_Day_Saturday()
        {
            // Arrange
            var num = 6;

            // Act
            var result = _function.GetDayOfWeek(num);

            //Assert
            Assert.AreEqual("saturday", result);
        }

        [TestMethod]
        public void Can_Get_Day_Sunday()
        {
            // Arrange
            var num = 7;

            // Act
            var result = _function.GetDayOfWeek(num);

            //Assert
            Assert.AreEqual("sunday", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Can_Caught_ArgumentException_In_GetDayOfWeek()
        {
            // Arrange
            var num = 0;

            // Act
            _function.GetDayOfWeek(num);
        }

        #endregion

        #region GetDistance
        [TestMethod]
        public void Can_Get_Distance_With_All_Positive_Param()
        {
            // Arrange
            var x1 = 1;
            var y1 = 1;
            var x2 = 4;
            var y2 = 5;

            // Act
            var result = _function.GetDistance(x1, y1, x2, y2);

            //Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Can_Get_Distance_With_All_Negotive_Param()
        {
            // Arrange
            var x1 = -1;
            var y1 = -1;
            var x2 = -4;
            var y2 = -5;

            // Act
            var result = _function.GetDistance(x1, y1, x2, y2);

            //Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Can_Get_Distance_With_Equal_Param()
        {
            // Arrange
            var x1 = 1;
            var y1 = 4;
            var x2 = 1;
            var y2 = 4;

            // Act
            var result = _function.GetDistance(x1, y1, x2, y2);

            //Assert
            Assert.AreEqual(0, result);
        }

        #endregion
    }
}
