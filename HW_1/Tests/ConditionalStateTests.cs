using System;
using DLLs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ConditionalStateTests
    {
        readonly ConditionalStatements _condState = new ConditionalStatements();

        #region Even
        [TestMethod]
        public void Can_Add_Two_Numbers()
        {
            var a = 3;
            var b = 5;
            var result = _condState.Even(a, b);
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void Can_Multiply_Two_Numbers()
        {
            var a = 2;
            var b = 5;
            var result = _condState.Even(a, b);
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Can_Get_ArgumentException_With_0_Argument()
        {
            var a = 0;
            var b = 5;
            var result = _condState.Even(a, b);
        }
        #endregion

        #region FindQuarter
        [TestMethod]
        public void Can_Get_1_Quater()
        {
            var x = 3;
            var y = 5;
            var result = _condState.FindQuarter(x, y);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Can_Get_2_Quater()
        {
            var x = -2;
            var y = 8;
            var result = _condState.FindQuarter(x, y);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Can_Get_3_Quater()
        {
            var x = -3;
            var y = -1;
            var result = _condState.FindQuarter(x, y);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Can_Get_4_Quater()
        {
            var x = 3;
            var y = -15;
            var result = _condState.FindQuarter(x, y);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Can_Get_ArgumentException_With_X_Is_0()
        {
            var x = 0;
            var y = 5;
            var result = _condState.FindQuarter(x, y);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Can_Get_ArgumentException_With_Y_Is_0()
        {
            var x = 7;
            var y = 0;
            var result = _condState.FindQuarter(x, y);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Can_Get_ArgumentException_With_X_And_Y_Is_0()
        {
            var x = 0;
            var y = 0;
            var result = _condState.FindQuarter(x, y);
        }
        #endregion

        #region PositiveValueSum
        [TestMethod]
        public void Can_Get_Positsve_Numbers_Sum_With_3_Positive_Num()
        {
            var num1 = 3;
            var num2 = 15;
            var num3 = 8;
            var result = _condState.PositiveValueSum(num1, num2, num3);
            Assert.AreEqual(26, result);
        }

        [TestMethod]
        public void Can_Get_Positsve_Numbers_Sum_With_2_Positive_Num()
        {
            var num1 = 3;
            var num2 = -15;
            var num3 = 8;
            var result = _condState.PositiveValueSum(num1, num2, num3);
            Assert.AreEqual(11, result);
        }

        [TestMethod]
        public void Can_Get_Positsve_Numbers_Sum_With_1_Positive_Num()
        {
            var num1 = 3;
            var num2 = -15;
            var num3 = -8;
            var result = _condState.PositiveValueSum(num1, num2, num3);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Can_Get_0_From_Negotive_2_Numbers()
        {
            var num1 = 0;
            var num2 = -15;
            var num3 = -1;
            var result = _condState.PositiveValueSum(num1, num2, num3);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Can_Get_0_From_Negotive_3_Numbers()
        {
            var num1 = -28;
            var num2 = -15;
            var num3 = -1;
            var result = _condState.PositiveValueSum(num1, num2, num3);
            Assert.AreEqual(0, result);
        }


        [TestMethod]
        public void Can_Get_0_From_Fro_All_0_Numbers()
        {
            var num1 = 0;
            var num2 = 0;
            var num3 = 0;
            var result = _condState.PositiveValueSum(num1, num2, num3);
            Assert.AreEqual(0, result);
        }
        #endregion

        #region MaxValue
        [TestMethod]
        public void Can_Get_Multiplied_Expression()
        {
            var a = 3;
            var b = 2;
            var c = 1;
            var result = _condState.MaxValue(a, b, c);
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void Can_Get_Added_Expression()
        {
            var a = 1;
            var b = 1;
            var c = 1;
            var result = _condState.MaxValue(a, b, c);
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Can_Get_Expression_When_All_Numbers_Are_0()
        {
            var a = 0;
            var b = 0;
            var c = 0;
            var result = _condState.MaxValue(a, b, c);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Can_Get_Expression_When_1_Numbers_Are_Not_0()
        {
            var a = 0;
            var b = 8;
            var c = 0;
            var result = _condState.MaxValue(a, b, c);
            Assert.AreEqual(11, result);
        }

        [TestMethod]
        public void Can_Get_Expression_Whith_All_Negotives_Numbers()
        {
            var a = -3;
            var b = -8;
            var c = -1;
            var result = _condState.MaxValue(a, b, c);
            Assert.AreEqual(-9, result);
        }
        #endregion

        #region CheckMark
        [TestMethod]
        public void Can_Get_A_Mark_With_100_Rating()
        {
            var rating = 100;
            var result = _condState.CheckMark(rating);
            Assert.AreEqual("A", result);
        }

        [TestMethod]
        public void Can_Get_A_Mark_With_99_Rating()
        {
            var rating = 99;
            var result = _condState.CheckMark(rating);
            Assert.AreEqual("A", result);
        }

        [TestMethod]
        public void Can_Get_A_Mark_With_90_Rating()
        {
            var rating = 90;
            var result = _condState.CheckMark(rating);
            Assert.AreEqual("A", result);
        }

        [TestMethod]
        public void Can_Get_B_Mark_With_89_Rating()
        {
            var rating = 89;
            var result = _condState.CheckMark(rating);
            Assert.AreEqual("B", result);
        }

        [TestMethod]
        public void Can_Get_B_Mark_With_88_Rating()
        {
            var rating = 88;
            var result = _condState.CheckMark(rating);
            Assert.AreEqual("B", result);
        }

        [TestMethod]
        public void Can_Get_B_Mark_With_75_Rating()
        {
            var rating = 75;
            var result = _condState.CheckMark(rating);
            Assert.AreEqual("B", result);
        }

        [TestMethod]
        public void Can_Get_C_Mark_With_74_Rating()
        {
            var rating = 74;
            var result = _condState.CheckMark(rating);
            Assert.AreEqual("C", result);
        }

        [TestMethod]
        public void Can_Get_C_Mark_With_69_Rating()
        {
            var rating = 69;
            var result = _condState.CheckMark(rating);
            Assert.AreEqual("C", result);
        }

        [TestMethod]
        public void Can_Get_C_Mark_With_60_Rating()
        {
            var rating = 60;
            var result = _condState.CheckMark(rating);
            Assert.AreEqual("C", result);
        }

        [TestMethod]
        public void Can_Get_D_Mark_With_59_Rating()
        {
            var rating = 59;
            var result = _condState.CheckMark(rating);
            Assert.AreEqual("D", result);
        }

        [TestMethod]
        public void Can_Get_D_Mark_With_40_Rating()
        {
            var rating = 40;
            var result = _condState.CheckMark(rating);
            Assert.AreEqual("D", result);
        }

        [TestMethod]
        public void Can_Get_E_Mark_With_39_Rating()
        {
            var rating = 39;
            var result = _condState.CheckMark(rating);
            Assert.AreEqual("E", result);
        }

        [TestMethod]
        public void Can_Get_E_Mark_With_20_Rating()
        {
            var rating = 20;
            var result = _condState.CheckMark(rating);
            Assert.AreEqual("E", result);
        }

        [TestMethod]
        public void Can_Get_F_Mark_With_19_Rating()
        {
            var rating = 19;
            var result = _condState.CheckMark(rating);
            Assert.AreEqual("F", result);
        }

        [TestMethod]
        public void Can_Get_F_Mark_With_0_Rating()
        {
            var rating = 0;
            var result = _condState.CheckMark(rating);
            Assert.AreEqual("F", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Can_Get_ArgumentException_With_Negativ_And_More_Then_100_Rating()
        {
            var rating = -1;
            var result1 = _condState.CheckMark(rating);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Can_Get_ArgumentException_With_More_Then_100_Rating()
        {
            var rating = 101;
            var result1 = _condState.CheckMark(rating);
        }
        #endregion
    }
}
