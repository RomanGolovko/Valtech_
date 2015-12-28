using System;
using DLLs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CycleTests
    {
        readonly Cycle _cycle = new Cycle();

        #region PositiveNumSum
        [TestMethod]
        public void Can_Get_Positive_Numbers_Sum()
        {
            var count = 0;
            var result = _cycle.PositiveNumSum(ref count);
            Assert.AreEqual(2450, result);
            Assert.AreEqual(49, count);
        }

        [TestMethod]
        public void Can_Get_Positive_Numbers_Count()
        {
            var count = 0;
            var result = _cycle.PositiveNumSum(ref count);
            Assert.AreEqual(49, count);
        }
        #endregion

        #region IsSimple
        [TestMethod]
        public void The_Number_13_Is_Simple()
        {
            var num = 13;
            var result = _cycle.IsSimple(num);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void The_Number_12_Is_Complicate()
        {
            var num = 12;
            var result = _cycle.IsSimple(num);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void The_Number_1_And_2_Are_Simple()
        {
            var num1 = 1;
            var num2 = 2;
            var result1 = _cycle.IsSimple(num1);
            var result2 = _cycle.IsSimple(num2);
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Can_Get_ArgumentEception()
        {
            var num = -1;
            var result = _cycle.IsSimple(num);
        }
        #endregion

        #region GetSquareBySelection
        [TestMethod]
        public void Can_Get_Square_Root_With_9_In_GetSquareBySelection()
        {
            var num = 9;
            var result = _cycle.GetSquareBySelection(num);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Can_Get_Square_Root_With_8_In_GetSquareBySelection()
        {
            var num = 8;
            var result = _cycle.GetSquareBySelection(num);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Can_Get_ArgumentException_In_GetSquareBySelection_With_0()
        {
            var num = 0;
            var result = _cycle.GetSquareBySelection(num);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Can_Get_ArgumentException_In_GetSquareBySelection_With_Negotive_Param()
        {
            var num = -9;
            var result = _cycle.GetSquareBySelection(num);
        }
        #endregion

        #region GetSquareByBinarySearch
        [TestMethod]
        public void Can_Get_Square_Root_With_9_In_GetSquareByBinarySearch()
        {
            var num = 9;
            var result = _cycle.GetSquareBySelection(num);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Can_Get_Square_Root_With_8_In_GetSquareByBinarySearch()
        {
            var num = 8;
            var result = _cycle.GetSquareBySelection(num);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Can_Get_ArgumentException_In_GetSquareByBinarySearch_With_0()
        {
            var num = 0;
            var result = _cycle.GetSquareBySelection(num);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Can_Get_ArgumentException_In_GetSquareByBinarySearch_With_Negotive_Param()
        {
            var num = -9;
            var result = _cycle.GetSquareBySelection(num);
        }
        #endregion

        #region GetFactorial
        [TestMethod]
        public void Can_Get_Factorial_4()
        {
            var num = 4;
            var result = _cycle.GetFactorial(num);
            Assert.AreEqual(24, result);
        }

        [TestMethod]
        public void Can_Get_Factorial_2()
        {
            var num = 2;
            var result = _cycle.GetFactorial(num);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Can_Get_ArgumentException_With_Negotive_Number()
        {
            var num = -2;
            var result = _cycle.GetFactorial(num);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Can_Get_ArgumentException_With_0_Number()
        {
            var num = 0;
            var result = _cycle.GetFactorial(num);
        }
        #endregion

        #region NumberSum
        [TestMethod]
        public void Can_Get_Sum_Of_6_Positive_Numbers()
        {
            var num = 123456;
            var result = _cycle.NumbersSum(num);
            Assert.AreEqual(21, result);
        }

        [TestMethod]
        public void Can_Get_Sum_Of_6_Negative_Numbers()
        {
            var num = -123456;
            var result = _cycle.NumbersSum(num);
            Assert.AreEqual(-21, result);
        }

        [TestMethod]
        public void Can_Get_Sum_Of_1_Number()
        {
            var num = 3;
            var result = _cycle.NumbersSum(num);
            Assert.AreEqual(3, result);
        }
        #endregion

        #region ReverseNumbe
        [TestMethod]
        public void Can_Reverse_Number()
        {
            var num = 123;
            var result = _cycle.ReverseNumber(num);
            Assert.AreEqual(321, result);
        }

        [TestMethod]
        public void Can_Reverse_Number_With_1_Number()
        {
            var num = 3;
            var result = _cycle.ReverseNumber(num);
            Assert.AreEqual(3, result);
        }
        #endregion
    }
}
