using System;
using DLLs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ArraysTests
    {
        private readonly Arrays _arrays = new Arrays();

        #region GetMinValue
        [TestMethod]
        public void Can_Get_Array_Min_Element()
        {
            int[] array = { -50, 20, 1, 15, 0, -8 };
            var result = _arrays.GetMinValue(array);
            Assert.AreEqual(-50, result);
        }

        [TestMethod]
        public void Can_Get_Array_Whith_1_Element_In_GetMinValue()
        {
            int[] array = { -10 };
            var result = _arrays.GetMinValue(array);
            Assert.AreEqual(-10, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Can_Get_NullReferenceException_In_GetMinValue()
        {
            int[] array = null;
            var result = _arrays.GetMinValue(array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Can_Get_ArgumentException_In_GetMinValue()
        {
            int[] array = { };
            var result = _arrays.GetMinValue(array);
        }
        #endregion

        #region GetMaxValue
        [TestMethod]
        public void Can_Get_Array_Max_Element()
        {
            int[] array = { -50, 20, 1, 15, 0, -8 };
            var result = _arrays.GetMaxValue(array);
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void Can_Get_Array_Whith_1_Element_In_GetMaxValue()
        {
            int[] array = { -10 };
            var result = _arrays.GetMinValue(array);
            Assert.AreEqual(-10, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Can_Get_NullReferenceException_In_GetMaxValue()
        {
            int[] array = null;
            var result = _arrays.GetMinValue(array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Can_Get_ArgumentException_In_GetMaxValue()
        {
            int[] array = { };
            var result = _arrays.GetMinValue(array);
        }
        #endregion

        #region GetMinValueIndex
        [TestMethod]
        public void Can_Get_Array_Min_Element_Index()
        {
            int[] array = { 0, 20, 1, 15, -50, -8 };
            var result = _arrays.GetMinValueIndex(array);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Can_Get_Array_Min_Element_Index_In_Array_Whith_1_Element_In_GetMinValueIndex()
        {
            int[] array = { -10 };
            var result = _arrays.GetMinValue(array);
            Assert.AreEqual(-10, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Can_Get_NullReferenceException_In_GetMinValueIndex()
        {
            int[] array = null;
            var result = _arrays.GetMinValue(array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Can_Get_ArgumentException_In_GetMinValueIndex()
        {
            int[] array = { };
            var result = _arrays.GetMinValue(array);
        }
        #endregion

        #region GetMaxValueIndex
        [TestMethod]
        public void Can_Get_Array_Max_Element_Index()
        {
            int[] array = { 0, 20, 1, 15, -50, -8 };
            var result = _arrays.GetMaxValueIndex(array);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Can_Get_Array_Min_Element_Index_In_Array_Whith_1_Element_In_GetMaxValueIndex()
        {
            int[] array = { -10 };
            var result = _arrays.GetMinValue(array);
            Assert.AreEqual(-10, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Can_Get_NullReferenceException_In_GetMaxValueIndex()
        {
            int[] array = null;
            var result = _arrays.GetMinValue(array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Can_Get_ArgumentException_In_GetMaxValueIndex()
        {
            int[] array = { };
            var result = _arrays.GetMinValue(array);
        }
        #endregion

        #region GetOddIndexValuesSum
        [TestMethod]
        public void Can_Get_Odd_Index_Value_Sum()
        {
            int[] array = { 0, 20, 1, 15, -50, -8 };
            var result = _arrays.GetOddIndexValueSum(array);
            Assert.AreEqual(27, result);
        }

        [TestMethod]
        public void Can_Get_Odd_Index_Value_Sum_With_1_Element_In_Array()
        {
            int[] array = { 1 };
            var result = _arrays.GetOddIndexValueSum(array);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Can_Get_NullReferenceException_In_GetOddIndexValuesSum()
        {
            int[] array = null;
            var result = _arrays.GetMinValue(array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Can_Get_ArgumentException_In_GetOddIndexValuesSum()
        {
            int[] array = { };
            var result = _arrays.GetMinValue(array);
        }
        #endregion

        #region ArraysRevers
        [TestMethod]
        public void Can_Revers_Array()
        {
            int[] array = { 0, 20, 1, 15, -50, -8 };
            var result = _arrays.ArraysRevers(array);
            Assert.AreEqual(-8, result[0]);
        }

        [TestMethod]
        public void Can_Get_Array_Min_Element_Index_In_Array_Whith_1_Element_In_ArraysRevers()
        {
            int[] array = { -10 };
            var result = _arrays.GetMinValue(array);
            Assert.AreEqual(-10, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Can_Get_NullReferenceException_In_ArraysRevers()
        {
            int[] array = null;
            var result = _arrays.GetMinValue(array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Can_Get_ArgumentException_In_ArraysRevers()
        {
            int[] array = { };
            var result = _arrays.GetMinValue(array);
        }
        #endregion

        #region GetOddValueSum
        [TestMethod]
        public void Can_Get_Odd_Values_Sum()
        {
            int[] array = { 0, 20, 1, 15, -50, -8 };
            var result = _arrays.GetOddValueSum(array);
            Assert.AreEqual(16, result);
        }

        [TestMethod]
        public void Can_Get_0_In_Array_With_Even_Element()
        {
            int[] array = { 0, 20, 12, 16, -50, -8 };
            var result = _arrays.GetOddValueSum(array);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Can_Get_NullReferenceException_In_GetOddValueSum()
        {
            int[] array = null;
            var result = _arrays.GetMinValue(array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Can_Get_ArgumentException_In_GetOddValueSum()
        {
            int[] array = { };
            var result = _arrays.GetMinValue(array);
        }
        #endregion

        #region SwapArrayIndexValue
        [TestMethod]
        public void Can_Swap_Array_Index_Value()
        {
            int[] array = { 0, 20, 1, 15, -50, -8, 22 };
            var result = _arrays.SwapArrayIndexValue(array);
            Assert.AreEqual(22, result[2]);
        }

        [TestMethod]
        public void Can_Get_Array_Whith_1_Element_In_SwapArrayIndexValue()
        {
            int[] array = { -10 };
            var result = _arrays.GetMinValue(array);
            Assert.AreEqual(-10, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Can_Get_NullReferenceException_In_SwapArrayIndexValue()
        {
            int[] array = null;
            var result = _arrays.GetMinValue(array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Can_Get_ArgumentException_In_SwapArrayIndexValue()
        {
            int[] array = { };
            var result = _arrays.GetMinValue(array);
        }
        #endregion

        #region BubbleSort
        [TestMethod]
        public void Can_Use_BubbleSort()
        {
            int[] array = { 0, 20, 1, 15, -50, -8, 22 };
            var result = _arrays.BubbleSort(array);
            Assert.IsTrue(result[3] > result[2]);
            Assert.IsTrue(result[4] > result[3]);
        }

        [TestMethod]
        public void Can_Get_Array_Whith_1_Element_In_BubbleSort()
        {
            int[] array = { -10 };
            var result = _arrays.GetMinValue(array);
            Assert.AreEqual(-10, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Can_Get_NullReferenceException_In_BubbleSort()
        {
            int[] array = null;
            var result = _arrays.GetMinValue(array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Can_Get_ArgumentException_In_BubbleSort()
        {
            int[] array = { };
            var result = _arrays.GetMinValue(array);
        }
        #endregion

        #region SelectionSort
        [TestMethod]
        public void Can_Use_SelectionSort()
        {
            int[] array = { 0, 20, 1, 15, -50, -8, 22 };
            var result = _arrays.SelectionSort(array);
            Assert.IsTrue(result[3] > result[2]);
            Assert.IsTrue(result[4] > result[3]);
        }

        [TestMethod]
        public void Can_Get_Array_Whith_1_Element_In_SelectionSort()
        {
            int[] array = { -10 };
            var result = _arrays.GetMinValue(array);
            Assert.AreEqual(-10, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Can_Get_NullReferenceException_In_SelectionSort()
        {
            int[] array = null;
            var result = _arrays.GetMinValue(array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Can_Get_ArgumentException_In_SelectionSort()
        {
            int[] array = { };
            var result = _arrays.GetMinValue(array);
        }
        #endregion

        #region InsertionSort
        [TestMethod]
        public void Can_Use_InsertionSort()
        {
            int[] array = { 0, 20, 1, 15, -50, -8, 22 };
            var result = _arrays.InsertionSort(array);
            Assert.IsTrue(result[3] > result[2]);
            Assert.IsTrue(result[4] > result[3]);
        }

        [TestMethod]
        public void Can_Get_Array_Whith_1_Element_In_InsertionSort()
        {
            int[] array = { -10 };
            var result = _arrays.GetMinValue(array);
            Assert.AreEqual(-10, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Can_Get_NullReferenceException_In_InsertionSort()
        {
            int[] array = null;
            var result = _arrays.GetMinValue(array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Can_Get_ArgumentException_In_InsertionSort()
        {
            int[] array = { };
            var result = _arrays.GetMinValue(array);
        }
        #endregion
    }
}
