using System;
using BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BLLTest
    {
        [TestMethod]
        public void Can_Add_Two_Numbers()
        {
            // Arrange
            var num1 = 5;
            var num2 = 3;
            var action = '+';
            var calc = new Calculator();

            // Action
            var result = calc.Calculate(num1, num2, action);

            // Assert
            Assert.AreEqual("8", result);
        }

        [TestMethod]
        public void Can_Subtract_Two_Numbers()
        {
            // Arrange
            var num1 = 5;
            var num2 = 3;
            var action = '-';
            var calc = new Calculator();

            // Action
            var result = calc.Calculate(num1, num2, action);

            // Assert
            Assert.AreEqual("2", result);
        }

        [TestMethod]
        public void Can_Multiply_Two_Numbers()
        {
            // Arrange
            var num1 = 5;
            var num2 = 3;
            var action = '*';
            var calc = new Calculator();

            // Action
            var result = calc.Calculate(num1, num2, action);

            // Assert
            Assert.AreEqual("15", result);
        }

        [TestMethod]
        public void Can_Dived_Two_Numbers()
        {
            // Arrange
            var num1 = 6;
            var num2 = 3;
            var action = '/';
            var calc = new Calculator();

            // Action
            var result = calc.Calculate(num1, num2, action);

            // Assert
            Assert.AreEqual("2", result);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Can_Catch_Exception()
        {
            // Arrange
            var num1 = 6;
            var num2 = 0;
            var action = '/';
            var calc = new Calculator();

            // Action
            var result = calc.Calculate(num1, num2, action);

            // Assert is handled by ExpectedException
        }

    }
}
