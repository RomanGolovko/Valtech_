using System;
using DataStructures.Abstract;
using DataStructures.Concrete.Arrays;
using DataStructures.Concrete.Lists;
using NUnit.Framework;

namespace DataStructuresTest
{
    [TestFixture(typeof(AList0))]
    [TestFixture(typeof(AList1))]
    [TestFixture(typeof(AList2))]
    [TestFixture(typeof(AListR))]
    [TestFixture(typeof(LList1))]
    [TestFixture(typeof(LList2))]
    [TestFixture(typeof(LListR))]
    public class NUnitTemplateTests<T> where T : IList, new()
    {
        IList MakeList()
        {
            return new T();
        }

        #region Size
        [Test]
        public void Can_Get_Size_Of_Many()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7 };
            var aList = MakeList();
            aList.Init(array);
            Assert.AreEqual(7, aList.Size());
        }

        [Test]
        public void Can_Get_Size_Of_2()
        {
            int[] array = { 1, 2 };
            var aList = MakeList();
            aList.Init(array);
            Assert.AreEqual(2, aList.Size());
        }

        [Test]
        public void Can_Get_Size_Of_1()
        {
            int[] array = { 1 };
            var aList = MakeList();
            aList.Init(array);
            Assert.AreEqual(1, aList.Size());
        }

        [Test]
        public void Can_Get_Size_Of_0()
        {
            var aList = MakeList();
            aList.Init(new int[0]);
            Assert.AreEqual(0, aList.Size());
        }

        [Test]
        public void Can_Get_Size_Of_Null()
        {
            var aList = MakeList();
            aList = null;
            Assert.Throws<NullReferenceException>(() => aList.Size());
        }
        #endregion

        #region Clear
        [Test]
        public void Can_Get_Clear_Many()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7 };
            var aList = MakeList();
            var expected = aList.Size();
            aList.Init(array);
            aList.Clear();
            var actual = aList.Size();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Can_Clear_2()
        {
            int[] array = { 1, 2 };
            var aList = MakeList();
            var expected = aList.Size();
            aList.Init(array);
            aList.Clear();
            var actual = aList.Size();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Can_Clear_1()
        {
            int[] array = { 1 };
            var aList = MakeList();
            var expected = aList.Size();
            aList.Init(array);
            aList.Clear();
            var actual = aList.Size();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Can_Clear_0()
        {
            var aList = MakeList();
            var expected = aList.Size();
            aList.Init(new int[0]);
            aList.Clear();
            var actual = aList.Size();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Can_Clear_Null()
        {
            var aList = MakeList();
            aList = null;
            Assert.Throws<NullReferenceException>(() => aList.Clear());
        }
        #endregion

        #region Init
        [Test]
        public void Can_Init_With_Size_Many([Range(0, 6)]int value)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7 };
            var aList = MakeList();
            aList.Init(array);
            Assert.AreEqual(7, aList.Size());
            Assert.AreEqual(value + 1, aList.Get(value));
        }

        [Test]
        public void Can_Init_With_Size_2([Range(0, 1)]int value)
        {
            int[] array = { 1, 2 };
            var aList = MakeList();
            aList.Init(array);
            Assert.AreEqual(2, aList.Size());
            Assert.AreEqual(value + 1, aList.Get(value));
        }

        [Test]
        public void Can_Init_With_Size_1()
        {
            int[] array = { 1 };
            var aList = MakeList();
            aList.Init(array);
            Assert.AreEqual(1, aList.Size());
            Assert.AreEqual(1, aList.Get(0));
        }

        [Test]
        public void Can_Init_With_Size_0()
        {
            var aList = MakeList();
            aList.Init(new int[0]);
            Assert.AreEqual(0, aList.Size());
        }

        [Test]
        public void Can_Init_With_Null()
        {
            var aList = MakeList();
            Assert.Throws<NullReferenceException>(() => aList.Init(null));
        }
        #endregion

        #region ToArray
        [Test]
        public void Can_Call_ToArray_For_Many()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7 };
            var aList = MakeList();
            aList.Init(array);
            Assert.AreEqual(array.Length, aList.Size());
        }

        [Test]
        public void Can_Call_ToArray_For_2()
        {
            int[] array = { 1, 2 };
            var aList = MakeList();
            aList.Init(array);
            Assert.AreEqual(array.Length, aList.Size());
        }

        [Test]
        public void Can_Call_ToArray_For_1()
        {
            int[] array = { 1 };
            var aList = MakeList();
            aList.Init(array);
            Assert.AreEqual(array.Length, aList.Size());
        }

        [Test]
        public void Can_Call_ToArray_For_0()
        {
            var aList = MakeList();
            var array = new int[0];
            aList.Init(array);
            Assert.AreEqual(array.Length, aList.Size());
        }

        [Test]
        public void Can_Call_ToArray_For_Null()
        {
            var aList = MakeList();
            aList = null;
            Assert.Throws<NullReferenceException>(() => aList.ToArray());
        }
        #endregion

        #region MinValue
        [Test]
        public void Can_Get_MinValue_For_Many()
        {
            int[] array = { 7, 12, 3, 4, 5, 6, 7 };
            var aList = MakeList();
            aList.Init(array);
            var result = aList.MinValue();
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Can_Get_MinValue_For_2()
        {
            int[] array = { 12, 8 };
            var aList = MakeList();
            aList.Init(array);
            var result = aList.MinValue();
            Assert.AreEqual(8, result);
        }

        [Test]
        public void Can_Get_MinValue_For_1()
        {
            int[] array = { 1 };
            var aList = MakeList();
            aList.Init(array);
            var result = aList.MinValue();
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Can_Get_MinValue_For_0()
        {
            var aList = MakeList();
            var array = new int[0];
            aList.Init(array);
            Assert.Throws<ArgumentNullException>(() => aList.MinValue());
        }

        [Test]
        public void Can_Get_MinValue_Null()
        {
            var aList = MakeList();
            aList = null;
            Assert.Throws<NullReferenceException>(() => aList.MinValue());
        }
        #endregion

        #region MaxValue
        [Test]
        public void Can_Get_MaxValue_For_Many()
        {
            int[] array = { 7, 12, 3, 4, 5, 6, 7 };
            var aList = MakeList();
            aList.Init(array);
            var result = aList.MaxValue();
            Assert.AreEqual(12, result);
        }

        [Test]
        public void Can_Get_MaxValue_For_2()
        {
            int[] array = { 3, 8 };
            var aList = MakeList();
            aList.Init(array);
            var result = aList.MaxValue();
            Assert.AreEqual(8, result);
        }

        [Test]
        public void Can_Get_MaxValue_For_1()
        {
            int[] array = { 12 };
            var aList = MakeList();
            aList.Init(array);
            var result = aList.MaxValue();
            Assert.AreEqual(12, result);
        }

        [Test]
        public void Can_Get_MaxValue_For_0()
        {
            var aList = MakeList();
            var array = new int[0];
            aList.Init(array);
            Assert.Throws<ArgumentNullException>(() => aList.MaxValue());
        }

        [Test]
        public void Can_Get_MaxValue_Null()
        {
            var aList = MakeList();
            aList = null;
            Assert.Throws<NullReferenceException>(() => aList.MaxValue());
        }
        #endregion

        #region MinValueIndex
        [Test]
        public void Can_Get_MinValueIndex_For_Many()
        {
            int[] array = { 7, 12, 3, 8, -5, 6, 7 };
            var aList = MakeList();
            aList.Init(array);
            var result = aList.MinValueIndex();
            Assert.AreEqual(4, result);
        }

        [Test]
        public void Can_Get_MinValueIndex_For_2()
        {
            int[] array = { 12, 8 };
            var aList = MakeList();
            aList.Init(array);
            var result = aList.MinValueIndex();
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Can_Get_MinValueIndex_For_1()
        {
            int[] array = { 1 };
            var aList = MakeList();
            aList.Init(array);
            var result = aList.MinValueIndex();
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Can_Get_MinValueIndex_For_0()
        {
            var aList = MakeList();
            var array = new int[0];
            aList.Init(array);
            Assert.Throws<ArgumentNullException>(() => aList.MinValueIndex());
        }

        [Test]
        public void Can_Get_MinValueIndex_Null()
        {
            var aList = MakeList();
            aList = null;
            Assert.Throws<NullReferenceException>(() => aList.MinValueIndex());
        }
        #endregion

        #region MaxValueIndex
        [Test]
        public void Can_Get_MaxValueIndex_For_Many()
        {
            int[] array = { 7, 12, 3, 4, 5, 6, 7 };
            var aList = MakeList();
            aList.Init(array);
            var result = aList.MaxValueIndex();
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Can_Get_MaxValueIndex_For_2()
        {
            int[] array = { 12, 8 };
            var aList = MakeList();
            aList.Init(array);
            var result = aList.MaxValueIndex();
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Can_Get_MaxValueIndex_For_1()
        {
            int[] array = { 1 };
            var aList = MakeList();
            aList.Init(array);
            var result = aList.MaxValueIndex();
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Can_Get_MaxValueIndex_For_0()
        {
            var aList = MakeList();
            var array = new int[0];
            aList.Init(array);
            Assert.Throws<ArgumentNullException>(() => aList.MaxValueIndex());
        }

        [Test]
        public void Can_Get_MaxValueIndex_Null()
        {
            var aList = MakeList();
            aList = null;
            Assert.Throws<NullReferenceException>(() => aList.MaxValueIndex());
        }
        #endregion

        #region Reverse
        [Test]
        public void Can_Reverse_For_Many([Range(0, 6)]int value)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7 };
            var aList = MakeList();
            aList.Init(array);
            aList.Reverse();
            Assert.AreEqual(aList.Get(value), 7 - value);
        }

        [Test]
        public void Can_Reverse_For_2()
        {
            int[] array = { 8, 12 };
            var aList = MakeList();
            aList.Init(array);
            aList.Reverse();
            Assert.IsTrue(aList.Get(0) > aList.Get(1));
        }

        [Test]
        public void Can_Reverse_For_1()
        {
            int[] array = { 1 };
            var aList = MakeList();
            aList.Init(array);
            aList.Reverse();
            Assert.AreEqual(1, aList.Get(0));
        }

        [Test]
        public void Can_Reverse_For_0()
        {
            var aList = MakeList();
            var array = new int[0];
            aList.Init(array);
            Assert.Throws<ArgumentNullException>(() => aList.Reverse());
        }

        [Test]
        public void Can_Reverse_Null()
        {
            var aList = MakeList();
            aList = null;
            Assert.Throws<NullReferenceException>(() => aList.Reverse());
        }
        #endregion

        #region HalfReverse
        [Test]
        public void Can_HalfReverse_For_Many()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7 };
            var aList = MakeList();
            aList.Init(array);
            aList.HalfReverse();
            Assert.AreEqual(aList.Get(2), 7);
            Assert.AreEqual(aList.Get(3), 4);
            Assert.AreEqual(aList.Get(4), 1);
        }

        [Test]
        public void Can_HalfReverse_For_2()
        {
            int[] array = { 12, 8 };
            var aList = MakeList();
            aList.Init(array);
            aList.HalfReverse();
            Assert.IsTrue(aList.Get(0) < aList.Get(1));
        }

        [Test]
        public void Can_HalfReverse_For_1()
        {
            int[] array = { 1 };
            var aList = MakeList();
            aList.Init(array);
            aList.HalfReverse();
            Assert.AreEqual(1, aList.Get(0));
        }

        [Test]
        public void Can_HalfReverse_For_0()
        {
            var aList = MakeList();
            var array = new int[0];
            aList.Init(array);
            Assert.Throws<ArgumentNullException>(() => aList.HalfReverse());
        }

        [Test]
        public void Can_HalfReverse_Null()
        {
            var aList = MakeList();
            aList = null;
            Assert.Throws<NullReferenceException>(() => aList.HalfReverse());
        }
        #endregion

        #region Get
        [Test]
        public void Can_Get_Of_Many([Range(0, 6)]int value)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7 };
            var aList = MakeList();
            aList.Init(array);
            var expected = value + 1;
            var actual = aList.Get(value);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Can_Get_Of_2([Values(0, 1)]int value)
        {
            int[] array = { 1, 2 };
            var aList = MakeList();
            aList.Init(array);
            var expected = value + 1;
            var actual = aList.Get(value);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Can_Get_Of_1()
        {
            int[] array = { 1 };
            var aList = MakeList();
            aList.Init(array);
            var result = aList.Get(0);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Can_Get_Of_0()
        {
            var aList = MakeList();
            aList.Init(new int[0]);
            Assert.Throws<IndexOutOfRangeException>(() => aList.Get(0));
        }

        [Test]
        public void Can_Get_Of_Null()
        {
            var aList = MakeList();
            aList = null;
            Assert.Throws<NullReferenceException>(() => aList.Get(0));
        }
        #endregion

        #region Set
        [Test]
        public void Can_Set_To_Many()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7 };
            var aList = MakeList();
            aList.Init(array);
            aList.Set(22, 3);
            Assert.AreEqual(3, aList.Get(2));
            Assert.AreEqual(22, aList.Get(3));
            Assert.AreEqual(5, aList.Get(4));

        }

        [Test]
        public void Can_Set_To_2([Values(0, 1)]int value)
        {
            int[] array = { 1, 2 };
            var aList = MakeList();
            aList.Init(array);
            aList.Set(22, 1);
            Assert.AreEqual(22, aList.Get(1));
        }

        [Test]
        public void Can_Set_To_1()
        {
            int[] array = { 1 };
            var aList = MakeList();
            aList.Init(array);
            aList.Set(22, 0);
            Assert.AreEqual(22, aList.Get(0));
        }

        [Test]
        public void Can_Set_To_0()
        {
            var aList = MakeList();
            aList.Init(new int[0]);
            Assert.Throws<IndexOutOfRangeException>(() => aList.Set(22, 0));
        }

        [Test]
        public void Can_Set_To_Null()
        {
            var aList = MakeList();
            aList = null;
            Assert.Throws<NullReferenceException>(() => aList.Set(12, 0));
        }
        #endregion

        #region Sort
        [Test]
        public void Can_Sort_For_Many([Range(0, 6)]int value)
        {
            int[] array = { 1, 6, 5, 7, 3, 2, 4 };
            var aList = MakeList();
            aList.Init(array);
            aList.Sort();
            Assert.AreEqual(aList.Get(value), value + 1);
        }

        [Test]
        public void Can_Sort_For_2()
        {
            int[] array = { 12, 8 };
            var aList = MakeList();
            aList.Init(array);
            aList.Sort();
            Assert.IsTrue(aList.Get(0) < aList.Get(1));
        }

        [Test]
        public void Can_Sort_For_1()
        {
            int[] array = { 1 };
            var aList = MakeList();
            aList.Init(array);
            aList.Sort();
            Assert.AreEqual(1, aList.Get(0));
        }

        [Test]
        public void Can_Sort_For_0()
        {
            var aList = MakeList();
            aList.Init(new int[0]);
            Assert.Throws<ArgumentNullException>(() => aList.Sort());
        }

        [Test]
        public void Can_Sort_Null()
        {
            var aList = MakeList();
            aList = null;
            Assert.Throws<NullReferenceException>(() => aList.Sort());
        }
        #endregion
    }
}
