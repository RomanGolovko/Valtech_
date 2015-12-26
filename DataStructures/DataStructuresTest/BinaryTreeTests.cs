using System;
using DataStructures.Concrete.BinaryTrees;
using NUnit.Framework;

namespace DataStructuresTest
{
    [TestFixture]
    public class BinaryTreeTests
    {
        #region Size
        [Test]
        public void Can_Get_Size_Of_Many()
        {
            int[] array = { 9, 5, 1, 14, 6 };
            var tree = new BinaryTree();
            tree.Init(array);
            Assert.AreEqual(5, tree.Size);
        }
        [Test]
        public void Can_Get_Size_Of_2()
        {
            int[] array = { 9, 5 };
            var tree = new BinaryTree();
            tree.Init(array);
            Assert.AreEqual(2, tree.Size);
        }
        [Test]
        public void Can_Get_Size_Of_1()
        {
            var tree = new BinaryTree();
            tree.Add(7);
            Assert.AreEqual(1, tree.Size);
        }
        [Test]
        public void Can_Get_Size_Of_0()
        {
            var tree = new BinaryTree();
            Assert.AreEqual(0, tree.Size);
        }
        [Test]
        public void Can_Get_Size_Of_Null()
        {
            BinaryTree tree = null;
            Assert.Throws<NullReferenceException>(() => tree.Init(new int[0]));
        }
        #endregion

        #region Height
        [Test]
        public void Can_Get_Height_Of_Many()
        {
            int[] array = { 9, 5, 1, 14, 6 };
            var tree = new BinaryTree();
            tree.Init(array);
            Assert.AreEqual(3, tree.Height());
        }
        [Test]
        public void Can_Get_Height_Of_2()
        {
            int[] array = { 9, 5 };
            var tree = new BinaryTree();
            tree.Init(array);
            Assert.AreEqual(2, tree.Height());
        }
        [Test]
        public void Can_Get_Height_Of_1()
        {
            var tree = new BinaryTree();
            tree.Add(7);
            Assert.AreEqual(1, tree.Height());
        }
        [Test]
        public void Can_Get_Height_Of_0()
        {
            var tree = new BinaryTree();
            Assert.AreEqual(0, tree.Height());
        }
        [Test]
        public void Can_Get_Height_Of_Null()
        {
            BinaryTree tree = null;
            Assert.Throws<NullReferenceException>(() => tree.Height());
        }
        #endregion

        #region Width
        [Test]
        public void Can_Get_Width_Of_Many()
        {
            int[] array = { 9, 5, 1, 14, 6 };
            var tree = new BinaryTree();
            tree.Init(array);
            Assert.AreEqual(2, tree.Width());
        }
        [Test]
        public void Can_Get_Width_Of_2()
        {
            int[] array = { 9, 5 };
            var tree = new BinaryTree();
            tree.Init(array);
            Assert.AreEqual(1, tree.Width());
        }
        [Test]
        public void Can_Get_Width_Of_1()
        {
            var tree = new BinaryTree();
            tree.Add(7);
            Assert.AreEqual(1, tree.Width());
        }
        [Test]
        public void Can_Get_Width_Of_0()
        {
            var tree = new BinaryTree();
            Assert.AreEqual(0, tree.Width());
        }
        [Test]
        public void Can_Get_Width_Of_Null()
        {
            BinaryTree tree = null;
            Assert.Throws<NullReferenceException>(() => tree.Width());
        }
        #endregion

        #region Clear
        [Test]
        public void Can_Clear_Many()
        {
            int[] array = { 9, 5, 1, 14, 6 };
            var tree = new BinaryTree();
            tree.Init(array);
            tree.Clear();
            Assert.AreEqual(0, tree.Size);
        }
        [Test]
        public void Can_Clear_2()
        {
            int[] array = { 9, 5 };
            var tree = new BinaryTree();
            tree.Init(array);
            tree.Clear();
            Assert.AreEqual(0, tree.Size);
        }
        [Test]
        public void Can_Clear_1()
        {
            var tree = new BinaryTree();
            tree.Add(7);
            tree.Clear();
            Assert.AreEqual(0, tree.Size);
        }
        [Test]
        public void Can_Clear_0()
        {
            var tree = new BinaryTree();
            tree.Clear();
            Assert.AreEqual(0, tree.Size);
        }
        [Test]
        public void Can_Clear_Null()
        {
            BinaryTree tree = null;
            Assert.Throws<NullReferenceException>(() => tree.Init(new int[0]));
        }
        #endregion

        #region Init
        [Test]
        public void Can_Init_Of_Many()
        {
            int[] array = { 9, 5, 1, 14, 6 };
            var tree = new BinaryTree();
            tree.Init(array);
            Assert.AreEqual(5, tree.Size);
            Assert.IsTrue(tree.Contains(14));
        }
        [Test]
        public void Can_Init_Of_2()
        {
            int[] array = { 9, 5 };
            var tree = new BinaryTree();
            tree.Init(array);
            Assert.AreEqual(2, tree.Size);
            Assert.IsTrue(tree.Contains(9));
        }
        [Test]
        public void Can_Init_Of_1()
        {
            var tree = new BinaryTree();
            tree.Add(7);
            Assert.AreEqual(1, tree.Size);
            Assert.IsTrue(tree.Contains(7));
        }
        [Test]
        public void Can_Init_Of_0()
        {
            var tree = new BinaryTree();
            Assert.Throws<ArgumentNullException>(() => tree.Init(new int[0]));
        }
        [Test]
        public void Can_Init_Null()
        {
            BinaryTree tree = null;
            Assert.Throws<NullReferenceException>(() => tree.Init(new int[0]));
        }
        #endregion

        #region ToArray
        [Test]
        public void Can_Get_Array_From_Many()
        {
            int[] array = { 9, 5, 1, 14, 6 };
            var tree = new BinaryTree();
            tree.Init(array);
            int[] expected = { 1, 5, 6, 9, 14 };
            var actual = tree.ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
        [Test]
        public void Can_Get_Array_From_2()
        {
            int[] array = { 9, 5 };
            var tree = new BinaryTree();
            tree.Init(array);
            int[] expected = { 5, 9 };
            var actual = tree.ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
        [Test]
        public void Can_Get_Array_From_1()
        {
            var tree = new BinaryTree();
            tree.Add(7);
            int[] expected = { 7 };
            var actual = tree.ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
        [Test]
        public void Can_Get_Array_From_0()
        {
            var tree = new BinaryTree();
            Assert.Throws<ArgumentNullException>(() => tree.ToArray());
        }
        [Test]
        public void Can_Get_Array_From_Null()
        {
            BinaryTree tree = null;
            Assert.Throws<NullReferenceException>(() => tree.ToArray());
        }
        #endregion

        #region ToString
        [Test]
        public void Can_Get_String_From_Many()
        {
            int[] array = { 9, 5, 1, 14, 6 };
            var tree = new BinaryTree();
            tree.Init(array);
            var expected = "1 5 6 9 14";
            var actual = tree.ToString();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Can_Get_String_From_2()
        {
            int[] array = { 9, 5 };
            var tree = new BinaryTree();
            tree.Init(array);
            var expected = "5 9";
            var actual = tree.ToString();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Can_Get_String_From_1()
        {
            var tree = new BinaryTree();
            tree.Add(7);
            var expected = "7";
            var actual = tree.ToString();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Can_Get_String_From_0()
        {
            var tree = new BinaryTree();
            Assert.Throws<ArgumentNullException>(() => tree.ToString());
        }
        [Test]
        public void Can_Get_String_From_Null()
        {
            BinaryTree tree = null;
            Assert.Throws<NullReferenceException>(() => tree.ToString());
        }
        #endregion

        #region Add
        [Test]
        public void Can_Add_To_Many()
        {
            int[] array = { 9, 5, 1, 14, 6 };
            var tree = new BinaryTree();
            tree.Init(array);
            tree.Add(19);
            Assert.AreEqual(6, tree.Size);
            Assert.IsTrue(tree.Contains(19));
        }
        [Test]
        public void Can_Add_To_2()
        {
            int[] array = { 9, 5 };
            var tree = new BinaryTree();
            tree.Init(array);
            tree.Add(19);
            Assert.AreEqual(3, tree.Size);
            Assert.IsTrue(tree.Contains(19));
        }
        [Test]
        public void Can_Add_To_1()
        {
            var tree = new BinaryTree();
            tree.Add(7);
            tree.Add(19);
            Assert.AreEqual(2, tree.Size);
            Assert.IsTrue(tree.Contains(19));
        }
        [Test]
        public void Can_Add_To_0()
        {
            var tree = new BinaryTree();
            tree.Add(19);
            Assert.AreEqual(1, tree.Size);
            Assert.IsTrue(tree.Contains(19));
        }
        [Test]
        public void Can_Add_To_Null()
        {
            BinaryTree tree = null;
            Assert.Throws<NullReferenceException>(() => tree.Add(19));
        }
        #endregion

        #region Del
        [Test]
        public void Can_Del_To_Many()
        {
            int[] array = { 9, 5, 1, 14, 6 };
            var tree = new BinaryTree();
            tree.Init(array);
            tree.Del(14);
            Assert.AreEqual(4, tree.Size);
            Assert.IsFalse(tree.Contains(14));
        }
        [Test]
        public void Can_Del_To_2()
        {
            int[] array = { 9, 5 };
            var tree = new BinaryTree();
            tree.Init(array);
            tree.Del(5);
            Assert.AreEqual(1, tree.Size);
            Assert.IsFalse(tree.Contains(5));
        }
        [Test]
        public void Can_Del_To_1()
        {
            var tree = new BinaryTree();
            tree.Add(7);
            tree.Del(7);
            Assert.AreEqual(0, tree.Size);
            Assert.IsFalse(tree.Contains(7));
        }
        [Test]
        public void Can_Del_To_0()
        {
            var tree = new BinaryTree();
            tree.Del(0);
            Assert.AreEqual(0, tree.Size);
            Assert.IsFalse(tree.Contains(0));
        }
        [Test]
        public void Can_Del_To_Null()
        {
            BinaryTree tree = null;
            Assert.Throws<NullReferenceException>(() => tree.Del(19));
        }

        #endregion

        #region Nodes
        [Test]
        public void Can_Get_Nodes_Count_Of_Many()
        {
            int[] array = { 9, 5, 1, 14, 6 };
            var tree = new BinaryTree();
            tree.Init(array);
            Assert.AreEqual(3, tree.Nodes());
        }
        [Test]
        public void Can_Get_Nodes_Count_Of_2()
        {
            int[] array = { 5, 9 };
            var tree = new BinaryTree();
            tree.Init(array);
            Assert.AreEqual(1, tree.Nodes());
        }
        [Test]
        public void Can_Get_Nodes_Count_Of_1()
        {
            var tree = new BinaryTree();
            tree.Add(7);
            Assert.AreEqual(0, tree.Nodes());
        }
        [Test]
        public void Can_Get_Nodes_Count_Of_0()
        {
            var tree = new BinaryTree();
            Assert.Throws<ArgumentNullException>(() => tree.Nodes());
        }
        [Test]
        public void Can_Get_Nodes_Count_Of_Null()
        {
            BinaryTree tree = null;
            Assert.Throws<NullReferenceException>(() => tree.Nodes());
        }
        #endregion

        #region Leaves
        [Test]
        public void Can_Get_Leaves_Count_Of_Many()
        {
            int[] array = { 9, 5, 1, 14, 6 };
            var tree = new BinaryTree();
            tree.Init(array);
            Assert.AreEqual(3, tree.Leaves());
        }
        [Test]
        public void Can_Get_Leaves_Count_Of_2()
        {
            int[] array = { 9, 5 };
            var tree = new BinaryTree();
            tree.Init(array);
            Assert.AreEqual(1, tree.Leaves());
        }
        [Test]
        public void Can_Get_Leaves_Count_Of_1()
        {
            var tree = new BinaryTree();
            tree.Add(7);
            Assert.AreEqual(1, tree.Leaves());
        }
        [Test]
        public void Can_Get_Leaves_Count_Of_0()
        {
            var tree = new BinaryTree();
            Assert.Throws<ArgumentNullException>(() => tree.Nodes());
        }
        [Test]
        public void Can_Get_Leaves_Count_Of_Null()
        {
            BinaryTree tree = null;
            Assert.Throws<NullReferenceException>(() => tree.Nodes());
        }
        #endregion

        #region Reverse
        [Test]
        public void Can_Reverse_Many()
        {
            int[] array = { 9, 5, 1, 14, 6 };
            var tree = new BinaryTree();
            tree.Init(array);
            var expected = "14 9 6 5 1";
            var actual = tree.Reverse();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Can_Reverse_From_2()
        {
            int[] array = { 9, 5 };
            var tree = new BinaryTree();
            tree.Init(array);
            var expected = "9 5";
            var actual = tree.Reverse();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Can_Reverse_From_1()
        {
            var tree = new BinaryTree();
            tree.Add(7);
            var expected = "7";
            var actual = tree.Reverse();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Can_Reverse_From_0()
        {
            var tree = new BinaryTree();
            Assert.Throws<ArgumentNullException>(() => tree.Reverse());
        }
        [Test]
        public void Can_Reverse_Null()
        {
            BinaryTree tree = null;
            Assert.Throws<NullReferenceException>(() => tree.Reverse());
        }
        #endregion
    }
}
