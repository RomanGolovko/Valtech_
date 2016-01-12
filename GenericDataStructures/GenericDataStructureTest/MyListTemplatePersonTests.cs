using System;
using GenericDataStructures.Abstract;
using GenericDataStructures.Concrete;
using NUnit.Framework;

namespace GenericDataStructureTest
{
    [TestFixture(typeof(AList0<Person>))]
    [TestFixture(typeof(AList1<Person>))]
    [TestFixture(typeof(AList2<Person>))]
    public class MyListTemplatePersonTests<T> where T : IMyList<Person>, new()
    {
        IMyList<Person> MakeList()
        {
            return new T();
        }

        #region Size
        [Test]
        public void Can_Get_Size_Of_Many()
        {
            var array = new Person[5];
            array[0] = new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 };
            array[1] = new Person { Id = 2, FirstName = "test2", LastName = "test2", Age = 22 };
            array[2] = new Person { Id = 3, FirstName = "test3", LastName = "test3", Age = 23 };
            array[3] = new Person { Id = 4, FirstName = "test4", LastName = "test4", Age = 24 };
            array[4] = new Person { Id = 5, FirstName = "test5", LastName = "test5", Age = 25 };
            var aList = MakeList();
            aList.Init(array);
            Assert.AreEqual(5, aList.Size());
        }

        [Test]
        public void Can_Get_Size_Of_2()
        {
            var array = new Person[2];
            array[0] = new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 };
            array[1] = new Person { Id = 2, FirstName = "test2", LastName = "test2", Age = 22 };
            var aList = MakeList();
            aList.Init(array);
            Assert.AreEqual(2, aList.Size());
        }

        [Test]
        public void Can_Get_Size_Of_1()
        {
            var array = new Person[] { new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 } };
            var aList = MakeList();
            aList.Init(array);
            Assert.AreEqual(1, aList.Size());
        }

        [Test]
        public void Can_Get_Size_Of_0()
        {
            var aList = MakeList();
            aList.Init(new Person[0]);
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
            var array = new Person[5];
            array[0] = new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 };
            array[1] = new Person { Id = 2, FirstName = "test2", LastName = "test2", Age = 22 };
            array[2] = new Person { Id = 3, FirstName = "test3", LastName = "test3", Age = 23 };
            array[3] = new Person { Id = 4, FirstName = "test4", LastName = "test4", Age = 24 };
            array[4] = new Person { Id = 5, FirstName = "test5", LastName = "test5", Age = 25 };
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
            var array = new Person[2];
            array[0] = new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 };
            array[1] = new Person { Id = 2, FirstName = "test2", LastName = "test2", Age = 22 };
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
            var array = new Person[] { new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 } };
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
            aList.Init(new Person[0]);
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
            var array = new Person[5];
            array[0] = new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 };
            array[1] = new Person { Id = 2, FirstName = "test2", LastName = "test2", Age = 22 };
            array[2] = new Person { Id = 3, FirstName = "test3", LastName = "test3", Age = 23 };
            array[3] = new Person { Id = 4, FirstName = "test4", LastName = "test4", Age = 24 };
            array[4] = new Person { Id = 5, FirstName = "test5", LastName = "test5", Age = 25 };
            var aList = MakeList();
            aList.Init(array);
            Assert.AreEqual(7, aList.Size());
            Assert.AreEqual(value + 1, aList.Get(value));
        }

        [Test]
        public void Can_Init_With_Size_2([Range(0, 1)]int value)
        {
            var array = new Person[2];
            array[0] = new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 };
            array[1] = new Person { Id = 2, FirstName = "test2", LastName = "test2", Age = 22 };
            var aList = MakeList();
            aList.Init(array);
            Assert.AreEqual(2, aList.Size());
            Assert.AreEqual(value + 1, aList.Get(value));
        }

        [Test]
        public void Can_Init_With_Size_1()
        {
            var array = new Person[] { new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 } };
            var aList = MakeList();
            aList.Init(array);
            Assert.AreEqual(1, aList.Size());
            Assert.AreEqual(1, aList.Get(0));
        }

        [Test]
        public void Can_Init_With_Size_0()
        {
            var aList = MakeList();
            aList.Init(new Person[0]);
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
            var array = new Person[5];
            array[0] = new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 };
            array[1] = new Person { Id = 2, FirstName = "test2", LastName = "test2", Age = 22 };
            array[2] = new Person { Id = 3, FirstName = "test3", LastName = "test3", Age = 23 };
            array[3] = new Person { Id = 4, FirstName = "test4", LastName = "test4", Age = 24 };
            array[4] = new Person { Id = 5, FirstName = "test5", LastName = "test5", Age = 25 };
            var aList = MakeList();
            aList.Init(array);
            Assert.AreEqual(array.Length, aList.Size());
        }

        [Test]
        public void Can_Call_ToArray_For_2()
        {
            var array = new Person[5];
            array[0] = new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 };
            array[1] = new Person { Id = 2, FirstName = "test2", LastName = "test2", Age = 22 };
            var aList = MakeList();
            aList.Init(array);
            Assert.AreEqual(array.Length, aList.Size());
        }

        [Test]
        public void Can_Call_ToArray_For_1()
        {
            var array = new Person[] { new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 } };
            var aList = MakeList();
            aList.Init(array);
            Assert.AreEqual(array.Length, aList.Size());
        }

        [Test]
        public void Can_Call_ToArray_For_0()
        {
            var aList = MakeList();
            var array = new Person[0];
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
            var array = new Person[5];
            array[0] = new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 };
            array[1] = new Person { Id = 2, FirstName = "test2", LastName = "test2", Age = 22 };
            array[2] = new Person { Id = 3, FirstName = "test3", LastName = "test3", Age = 23 };
            array[3] = new Person { Id = 4, FirstName = "test4", LastName = "test4", Age = 24 };
            array[4] = new Person { Id = 5, FirstName = "test5", LastName = "test5", Age = 25 };
            var aList = MakeList();
            aList.Init(array);
            var result = aList.MinValue();
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void Can_Get_MinValue_For_2()
        {
            var array = new Person[5];
            array[0] = new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 };
            array[1] = new Person { Id = 2, FirstName = "test2", LastName = "test2", Age = 22 };
            var aList = MakeList();
            aList.Init(array);
            var result = aList.MinValue();
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void Can_Get_MinValue_For_1()
        {
            var array = new Person[] { new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 } };
            var aList = MakeList();
            aList.Init(array);
            var result = aList.MinValue();
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void Can_Get_MinValue_For_0()
        {
            var aList = MakeList();
            var array = new Person[0];
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
            var array = new Person[5];
            array[0] = new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 };
            array[1] = new Person { Id = 2, FirstName = "test2", LastName = "test2", Age = 22 };
            array[2] = new Person { Id = 3, FirstName = "test3", LastName = "test3", Age = 23 };
            array[3] = new Person { Id = 4, FirstName = "test4", LastName = "test4", Age = 24 };
            array[4] = new Person { Id = 5, FirstName = "test5", LastName = "test5", Age = 25 };
            var aList = MakeList();
            aList.Init(array);
            var result = aList.MaxValue();
            Assert.AreEqual(5, result.Id);
        }

        [Test]
        public void Can_Get_MaxValue_For_2()
        {
            var array = new Person[2];
            array[0] = new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 };
            array[1] = new Person { Id = 2, FirstName = "test2", LastName = "test2", Age = 22 };
            var aList = MakeList();
            aList.Init(array);
            var result = aList.MaxValue();
            Assert.AreEqual(2, result.Id);
        }

        [Test]
        public void Can_Get_MaxValue_For_1()
        {
            var array = new Person[] { new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 } };
            var aList = MakeList();
            aList.Init(array);
            var result = aList.MaxValue();
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void Can_Get_MaxValue_For_0()
        {
            var aList = MakeList();
            var array = new Person[0];
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
            var array = new Person[5];
            array[0] = new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 };
            array[1] = new Person { Id = 2, FirstName = "test2", LastName = "test2", Age = 22 };
            array[2] = new Person { Id = 3, FirstName = "test3", LastName = "test3", Age = 23 };
            array[3] = new Person { Id = 4, FirstName = "test4", LastName = "test4", Age = 24 };
            array[4] = new Person { Id = 5, FirstName = "test5", LastName = "test5", Age = 25 };
            var aList = MakeList();
            aList.Init(array);
            var result = aList.MinValueIndex();
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Can_Get_MinValueIndex_For_2()
        {
            var array = new Person[2];
            array[0] = new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 };
            array[1] = new Person { Id = 2, FirstName = "test2", LastName = "test2", Age = 22 };
            var aList = MakeList();
            aList.Init(array);
            var result = aList.MinValueIndex();
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Can_Get_MinValueIndex_For_1()
        {
            var array = new Person[] { new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 } };
            var aList = MakeList();
            aList.Init(array);
            var result = aList.MinValueIndex();
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Can_Get_MinValueIndex_For_0()
        {
            var aList = MakeList();
            var array = new Person[0];
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
            var array = new Person[5];
            array[0] = new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 };
            array[1] = new Person { Id = 2, FirstName = "test2", LastName = "test2", Age = 22 };
            array[2] = new Person { Id = 3, FirstName = "test3", LastName = "test3", Age = 23 };
            array[3] = new Person { Id = 4, FirstName = "test4", LastName = "test4", Age = 24 };
            array[4] = new Person { Id = 5, FirstName = "test5", LastName = "test5", Age = 25 };
            var aList = MakeList();
            aList.Init(array);
            var result = aList.MaxValueIndex();
            Assert.AreEqual(4, result);
        }

        [Test]
        public void Can_Get_MaxValueIndex_For_2()
        {
            var array = new Person[2];
            array[0] = new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 };
            array[1] = new Person { Id = 2, FirstName = "test2", LastName = "test2", Age = 22 };
            var aList = MakeList();
            aList.Init(array);
            var result = aList.MaxValueIndex();
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Can_Get_MaxValueIndex_For_1()
        {
            var array = new Person[] { new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 } };
            var aList = MakeList();
            aList.Init(array);
            var result = aList.MaxValueIndex();
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Can_Get_MaxValueIndex_For_0()
        {
            var aList = MakeList();
            var array = new Person[0];
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
        public void Can_Reverse_For_Many()
        {
            var array = new Person[5];
            array[0] = new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 };
            array[1] = new Person { Id = 2, FirstName = "test2", LastName = "test2", Age = 22 };
            array[2] = new Person { Id = 3, FirstName = "test3", LastName = "test3", Age = 23 };
            array[3] = new Person { Id = 4, FirstName = "test4", LastName = "test4", Age = 24 };
            array[4] = new Person { Id = 5, FirstName = "test5", LastName = "test5", Age = 25 };
            var aList = MakeList();
            aList.Init(array);
            aList.Reverse();
            Assert.AreEqual(aList.Get(0).Id, 5);
            Assert.AreEqual(aList.Get(1).Id, 4);
        }

        [Test]
        public void Can_Reverse_For_2()
        {
            var array = new Person[2];
            array[0] = new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 };
            array[1] = new Person { Id = 2, FirstName = "test2", LastName = "test2", Age = 22 };
            var aList = MakeList();
            aList.Init(array);
            aList.Reverse();
            Assert.AreEqual(aList.Get(0).Id, 2);
            Assert.AreEqual(aList.Get(1).Id, 1);
        }

        [Test]
        public void Can_Reverse_For_1()
        {
            var array = new Person[] { new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 } };
            var aList = MakeList();
            aList.Init(array);
            aList.Reverse();
            Assert.AreEqual(1, aList.Get(0));
        }

        [Test]
        public void Can_Reverse_For_0()
        {
            var aList = MakeList();
            var array = new Person[0];
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
            var array = new Person[5];
            array[0] = new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 };
            array[1] = new Person { Id = 2, FirstName = "test2", LastName = "test2", Age = 22 };
            array[2] = new Person { Id = 3, FirstName = "test3", LastName = "test3", Age = 23 };
            array[3] = new Person { Id = 4, FirstName = "test4", LastName = "test4", Age = 24 };
            array[4] = new Person { Id = 5, FirstName = "test5", LastName = "test5", Age = 25 };
            var aList = MakeList();
            aList.Init(array);
            aList.HalfReverse();
            Assert.AreEqual(aList.Get(0).Id, 5);
            Assert.AreEqual(aList.Get(2).Id, 3);
            Assert.AreEqual(aList.Get(4).Id, 1);
        }

        [Test]
        public void Can_HalfReverse_For_2()
        {
            var array = new Person[2];
            array[0] = new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 };
            array[1] = new Person { Id = 2, FirstName = "test2", LastName = "test2", Age = 22 };
            var aList = MakeList();
            aList.Init(array);
            aList.HalfReverse();
            Assert.AreEqual(aList.Get(0).Id, 2);
            Assert.AreEqual(aList.Get(1).Id, 1);
        }

        [Test]
        public void Can_HalfReverse_For_1()
        {
            var array = new Person[] { new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 } };
            var aList = MakeList();
            aList.Init(array);
            aList.HalfReverse();
            Assert.AreEqual(1, aList.Get(0).Id);
        }

        [Test]
        public void Can_HalfReverse_For_0()
        {
            var aList = MakeList();
            var array = new Person[0];
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
        public void Can_Get_Of_Many([Range(0, 4)]int value)
        {
            var array = new Person[5];
            array[0] = new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 };
            array[1] = new Person { Id = 2, FirstName = "test2", LastName = "test2", Age = 22 };
            array[2] = new Person { Id = 3, FirstName = "test3", LastName = "test3", Age = 23 };
            array[3] = new Person { Id = 4, FirstName = "test4", LastName = "test4", Age = 24 };
            array[4] = new Person { Id = 5, FirstName = "test5", LastName = "test5", Age = 25 };
            var aList = MakeList();
            aList.Init(array);
            var expected = value + 1;
            var actual = aList.Get(value).Id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Can_Get_Of_2([Values(0, 1)]int value)
        {
            var array = new Person[2];
            array[0] = new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 };
            array[1] = new Person { Id = 2, FirstName = "test2", LastName = "test2", Age = 22 };
            var aList = MakeList();
            aList.Init(array);
            var expected = value + 1;
            var actual = aList.Get(value).Id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Can_Get_Of_1()
        {
            var array = new Person[] { new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 } };
            var aList = MakeList();
            aList.Init(array);
            var result = aList.Get(0).Id;
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Can_Get_Of_0()
        {
            var aList = MakeList();
            aList.Init(new Person[0]);
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
            var array = new Person[5];
            array[0] = new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 };
            array[1] = new Person { Id = 2, FirstName = "test2", LastName = "test2", Age = 22 };
            array[2] = new Person { Id = 3, FirstName = "test3", LastName = "test3", Age = 23 };
            array[3] = new Person { Id = 4, FirstName = "test4", LastName = "test4", Age = 24 };
            array[4] = new Person { Id = 5, FirstName = "test5", LastName = "test5", Age = 25 };
            var aList = MakeList();
            aList.Init(array);
            aList.Set(new Person {Id = 6, FirstName = "test6", LastName = "test6", Age = 26}, 3);
            Assert.AreEqual(3, aList.Get(2).Id);
            Assert.AreEqual(6, aList.Get(3).Id);
            Assert.AreEqual(5, aList.Get(4).Id);

        }

        [Test]
        public void Can_Set_To_2([Values(0, 1)]int value)
        {
            var array = new Person[2];
            array[0] = new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 };
            array[1] = new Person { Id = 2, FirstName = "test2", LastName = "test2", Age = 22 };
            var aList = MakeList();
            aList.Init(array);
            aList.Set(new Person { Id = 6, FirstName = "test6", LastName = "test6", Age = 26 }, 1);
            Assert.AreEqual(6, aList.Get(1).Id);
        }

        [Test]
        public void Can_Set_To_1()
        {
            var array = new Person[] { new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 } };
            var aList = MakeList();
            aList.Init(array);
            aList.Set(new Person { Id = 6, FirstName = "test6", LastName = "test6", Age = 26 }, 0);
            Assert.AreEqual(6, aList.Get(0).Id);
        }

        [Test]
        public void Can_Set_To_0()
        {
            var aList = MakeList();
            aList.Init(new Person[0]);
            Assert.Throws<IndexOutOfRangeException>(() => aList.Set(new Person { Id = 6, FirstName = "test6", LastName = "test6", Age = 26 }, 0));
        }

        [Test]
        public void Can_Set_To_Null()
        {
            var aList = MakeList();
            aList = null;
            Assert.Throws<NullReferenceException>(() => aList.Set(new Person { Id = 6, FirstName = "test6", LastName = "test6", Age = 26 }, 0));
        }
        #endregion

        #region Sort
        [Test]
        public void Can_Sort_For_Many([Range(0, 6)]int value)
        {
            var array = new Person[5];
            array[4] = new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 };
            array[3] = new Person { Id = 2, FirstName = "test2", LastName = "test2", Age = 22 };
            array[2] = new Person { Id = 3, FirstName = "test3", LastName = "test3", Age = 23 };
            array[1] = new Person { Id = 4, FirstName = "test4", LastName = "test4", Age = 24 };
            array[0] = new Person { Id = 5, FirstName = "test5", LastName = "test5", Age = 25 };
            var aList = MakeList();
            aList.Init(array);
            aList.Sort();
            Assert.AreEqual(aList.Get(value).Id, value + 1);
        }

        [Test]
        public void Can_Sort_For_2()
        {
            var array = new Person[2];
            array[1] = new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 };
            array[0] = new Person { Id = 2, FirstName = "test2", LastName = "test2", Age = 22 };
            var aList = MakeList();
            aList.Init(array);
            aList.Sort();
            Assert.IsTrue(aList.Get(0).Id < aList.Get(1).Id);
        }

        [Test]
        public void Can_Sort_For_1()
        {
            var array = new Person[] { new Person { Id = 1, FirstName = "test1", LastName = "test1", Age = 21 } };
            var aList = MakeList();
            aList.Init(array);
            aList.Sort();
            Assert.AreEqual(1, aList.Get(0));
        }

        [Test]
        public void Can_Sort_For_0()
        {
            var aList = MakeList();
            aList.Init(new Person[0]);
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
