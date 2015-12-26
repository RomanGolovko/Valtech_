using System;
using System.Collections.Generic;
using DataStructures.Abstract;
using DataStructures.Concrete.Graphs;
using NUnit.Framework;

namespace DataStructuresTest
{
    [TestFixture(typeof(GraphTable))]
    public class GraphsTests<T> where T : IGraph, new()
    {
        IGraph MakeGraph()
        {
            return new T();
        }

        #region Size
        [Test]
        public void Can_Get_Size_To_Many()
        {
            var graph = MakeGraph();
            var cities = new GraphTableNode[4]
            {
                new GraphTableNode { City = "Dnepropetrovsk", Links = new int[] { 0, 500, 300, 0 } },
                new GraphTableNode { City = "Kiev", Links = new int[] { 0, 0, 200, 700 } },
                new GraphTableNode { City = "Harkov", Links = new int[] { 250, 0, 0, 500 } },
                new GraphTableNode { City = "Odessa", Links = new int[] { 450, 0, 0, 0 } }
            };
            graph.Init(cities);
            Assert.AreEqual(4, graph.Size);
        }

        [Test]
        public void Can_Get_Size_To_2()
        {
            var graph = MakeGraph();
            var cities = new GraphTableNode[2]
            {
                new GraphTableNode { City = "Dnepropetrovsk", Links = new int[] { 0, 500 } },
                new GraphTableNode { City = "Kiev", Links = new int[] { 0, 0 } }
            };
            graph.Init(cities);
            Assert.AreEqual(2, graph.Size);
        }

        [Test]
        public void Can_Get_Size_To_1()
        {
            var graph = MakeGraph();
            var cities = new GraphTableNode[1]
            {
                new GraphTableNode { City = "Dnepropetrovsk", Links = new int[] { 0 } },
            };
            graph.Init(cities);
            Assert.AreEqual(1, graph.Size);
        }

        [Test]
        public void Can_Get_Size_To_0()
        {
            var graph = MakeGraph();
            Assert.AreEqual(0, graph.Size);
        }

        [Test]
        public void Can_Get_Size_To_Null()
        {
            var graph = MakeGraph();
            graph = null;
            Assert.Throws<NullReferenceException>(() => graph.Size.ToString());
        }
        #endregion

        #region Init
        [Test]
        public void Can_Init_Of_Many()
        {
            var graph = MakeGraph();
            var cities = new GraphTableNode[4]
            {
                new GraphTableNode { City = "Dnepropetrovsk", Links = new int[] { 0, 500, 300, 0 } },
                new GraphTableNode { City = "Kiev", Links = new int[] { 0, 0, 200, 700 } },
                new GraphTableNode { City = "Harkov", Links = new int[] { 250, 0, 0, 500 } },
                new GraphTableNode { City = "Odessa", Links = new int[] { 450, 0, 0, 0 } }
            };
            graph.Init(cities);
            Assert.AreEqual(4, graph.Size);
        }

        [Test]
        public void Can_Init_Of_2()
        {
            var graph = MakeGraph();
            var cities = new GraphTableNode[2]
            {
                new GraphTableNode { City = "Dnepropetrovsk", Links = new int[] { 0, 500 } },
                new GraphTableNode { City = "Kiev", Links = new int[] { 0, 0 } }
            };
            graph.Init(cities);
            Assert.AreEqual(2, graph.Size);
        }

        [Test]
        public void Can_Init_Of_1()
        {
            var graph = MakeGraph();
            var cities = new GraphTableNode[1]
            {
                new GraphTableNode { City = "Dnepropetrovsk", Links = new int[] { 0 } },
            };
            graph.Init(cities);
            Assert.AreEqual(1, graph.Size);
        }

        [Test]
        public void Can_Init_Of_0()
        {
            var graph = MakeGraph();
            graph.Init(new GraphTableNode[0]);
            Assert.AreEqual(0, graph.Size);
        }

        [Test]
        public void Can_Init_Of_Null()
        {
            var graph = MakeGraph();
            Assert.Throws<NullReferenceException>(() => graph.Init(null));
        }
        #endregion

        #region AddNode
        [Test]
        public void Can_Add_Node_To_Many()
        {
            var graph = MakeGraph();
            var cities = new GraphTableNode[4]
            {
                new GraphTableNode { City = "Dnepropetrovsk", Links = new int[] { 0, 500, 300, 0 } },
                new GraphTableNode { City = "Kiev", Links = new int[] { 0, 0, 200, 700 } },
                new GraphTableNode { City = "Harkov", Links = new int[] { 250, 0, 0, 500 } },
                new GraphTableNode { City = "Odessa", Links = new int[] { 450, 0, 0, 0 } }
            };
            graph.Init(cities);
            graph.AddNode("Dniprodzerzhinsk");
            Assert.AreEqual(5, graph.Size);
        }

        [Test]
        public void Can_Add_Node_To_2()
        {
            var graph = MakeGraph();
            var cities = new GraphTableNode[2]
            {
                new GraphTableNode { City = "Dnepropetrovsk", Links = new int[] { 0, 500 } },
                new GraphTableNode { City = "Kiev", Links = new int[] { 0, 0 } }
            };
            graph.Init(cities);
            graph.AddNode("Dniprodzerzhinsk");
            Assert.AreEqual(3, graph.Size);
        }

        [Test]
        public void Can_Add_Node_To_1()
        {
            var graph = MakeGraph();
            var cities = new GraphTableNode[1]
            {
                new GraphTableNode { City = "Dnepropetrovsk", Links = new int[] { 0 } },
                    };
            graph.Init(cities);
            graph.AddNode("Dniprodzerzhinsk");
            Assert.AreEqual(2, graph.Size);
        }

        [Test]
        public void Can_Add_Node_To_0()
        {
            var graph = MakeGraph();
            graph.AddNode("Dniprodzerzhinsk");
            Assert.AreEqual(1, graph.Size);
        }

        [Test]
        public void Can_Add_Node_To_Null()
        {
            var graph = MakeGraph();
            graph = null;
            Assert.Throws<NullReferenceException>(() => graph.AddNode("Dniprodzerzhinsk"));
        }
        #endregion

        #region AddLink
        [Test]
        public void Can_Add_Link_To_Many()
        {
            var graph = MakeGraph();
            var cities = new GraphTableNode[4]
            {
                new GraphTableNode { City = "Dnepropetrovsk", Links = new int[] { 0, 500, 300, 0 } },
                new GraphTableNode { City = "Kiev", Links = new int[] { 0, 0, 200, 700 } },
                new GraphTableNode { City = "Harkov", Links = new int[] { 250, 0, 0, 500 } },
                new GraphTableNode { City = "Odessa", Links = new int[] { 450, 0, 0, 0 } }
            };
            graph.Init(cities);
            graph.AddLink(2, 2, 150);
            var result = graph.ToArray();
            Assert.AreEqual(150, result[1].Links[1]);
        }

        [Test]
        public void Can_Add_Link_To_2()
        {
            var graph = MakeGraph();
            var cities = new GraphTableNode[2]
            {
                new GraphTableNode { City = "Dnepropetrovsk", Links = new int[] { 0, 500 } },
                new GraphTableNode { City = "Kiev", Links = new int[] { 0, 0 } }
            };
            graph.Init(cities);
            graph.AddLink(1, 1, 150);
            var result = graph.ToArray();
            Assert.AreEqual(150, result[0].Links[0]);
        }

        [Test]
        public void Can_Add_Link_To_1()
        {
            var graph = MakeGraph();
            var cities = new GraphTableNode[1]
            {
                new GraphTableNode { City = "Dnepropetrovsk", Links = new int[] { 0 } }
            };
            graph.Init(cities);
            Assert.Throws<ArgumentNullException>(() => graph.AddLink(1, 1, 1));
        }

        [Test]
        public void Can_Add_Link_To_0()
        {
            var graph = MakeGraph();
            Assert.Throws<ArgumentNullException>(() => graph.AddLink(1, 1, 1));
        }

        [Test]
        public void Can_Add_Link_To_Null()
        {
            var graph = MakeGraph();
            graph = null;
            Assert.Throws<NullReferenceException>(() => graph.AddLink(1, 1, 1));
        }
        #endregion

        #region DelNode
        [Test]
        public void Can_Del_Node_To_Many()
        {
            var graph = MakeGraph();
            var cities = new GraphTableNode[4]
            {
                new GraphTableNode { City = "Dnepropetrovsk", Links = new int[] { 0, 500, 300, 0 } },
                new GraphTableNode { City = "Kiev", Links = new int[] { 0, 0, 200, 700 } },
                new GraphTableNode { City = "Harkov", Links = new int[] { 250, 0, 0, 500 } },
                new GraphTableNode { City = "Odessa", Links = new int[] { 450, 0, 0, 0 } }
            };
            graph.Init(cities);
            graph.DelNode(4);
            Assert.AreEqual(3, graph.Size);
        }

        [Test]
        public void Can_Del_Node_To_2()
        {
            var graph = MakeGraph();
            var cities = new GraphTableNode[2]
            {
                new GraphTableNode { City = "Dnepropetrovsk", Links = new int[] { 0, 500 } },
                new GraphTableNode { City = "Kiev", Links = new int[] { 0, 0 } }
            };
            graph.Init(cities);
            graph.DelNode(1);
            Assert.AreEqual(1, graph.Size);
        }

        [Test]
        public void Can_Del_Node_To_1()
        {
            var graph = MakeGraph();
            var cities = new GraphTableNode[1]
            {
                new GraphTableNode { City = "Dnepropetrovsk", Links = new int[] { 0 } }
                    };
            graph.Init(cities);
            graph.DelNode(1);
            Assert.AreEqual(0, graph.Size);
        }

        [Test]
        public void Can_Del_Node_To_0()
        {
            var graph = MakeGraph();
            Assert.Throws<ArgumentNullException>(() => graph.DelNode(1));
        }

        [Test]
        public void Can_Del_Node_To_Null()
        {
            var graph = MakeGraph();
            graph = null;
            Assert.Throws<NullReferenceException>(() => graph.DelNode(1));
        }
        #endregion

        #region DelLink
        [Test]
        public void Can_Del_Link_To_Many()
        {
            var graph = MakeGraph();
            var cities = new GraphTableNode[4]
            {
                new GraphTableNode { City = "Dnepropetrovsk", Links = new int[] { 0, 500, 300, 0 } },
                new GraphTableNode { City = "Kiev", Links = new int[] { 0, 0, 200, 700 } },
                new GraphTableNode { City = "Harkov", Links = new int[] { 250, 0, 0, 500 } },
                new GraphTableNode { City = "Odessa", Links = new int[] { 450, 0, 0, 0 } }
            };
            graph.Init(cities);
            graph.DelLink(2, 3);
            var result = graph.ToArray();
            Assert.AreEqual(0, result[1].Links[2]);
        }

        [Test]
        public void Can_Del_Link_To_2()
        {
            var graph = MakeGraph();
            var cities = new GraphTableNode[2]
            {
                new GraphTableNode { City = "Dnepropetrovsk", Links = new int[] { 0, 500 } },
                new GraphTableNode { City = "Kiev", Links = new int[] { 0, 0 } }
            };
            graph.Init(cities);
            graph.DelLink(1, 2);
            var result = graph.ToArray();
            Assert.AreEqual(0, result[0].Links[1]);
        }

        [Test]
        public void Can_Del_Link_To_1()
        {
            var graph = MakeGraph();
            var cities = new GraphTableNode[1]
            {
                new GraphTableNode { City = "Dnepropetrovsk", Links = new int[] { 0 } }
            };
            graph.Init(cities);

            Assert.Throws<ArgumentNullException>(() => graph.DelLink(0, 0));
        }

        [Test]
        public void Can_Del_Link_To_0()
        {
            var graph = MakeGraph();
            Assert.Throws<ArgumentNullException>(() => graph.DelLink(0, 0));
        }

        [Test]
        public void Can_Del_Link_To_Null()
        {
            var graph = MakeGraph();
            graph = null;
            Assert.Throws<NullReferenceException>(() => graph.DelLink(0, 0));
        }
        #endregion

        #region ToArray
        [Test]
        public void Can_Get_ToArray_Of_Many()
        {
            var graph = MakeGraph();
            var cities = new GraphTableNode[4]
            {
                new GraphTableNode { City = "Dnepropetrovsk", Links = new int[] { 0, 500, 300, 0 } },
                new GraphTableNode { City = "Kiev", Links = new int[] { 0, 0, 200, 700 } },
                new GraphTableNode { City = "Harkov", Links = new int[] { 250, 0, 0, 500 } },
                new GraphTableNode { City = "Odessa", Links = new int[] { 450, 0, 0, 0 } }
            };
            graph.Init(cities);
            CollectionAssert.AreEqual(cities, graph.ToArray());
        }

        [Test]
        public void Can_Get_ToArray_Of_2()
        {
            var graph = MakeGraph();
            var cities = new GraphTableNode[2]
            {
                new GraphTableNode { City = "Dnepropetrovsk", Links = new int[] { 0, 500 } },
                new GraphTableNode { City = "Kiev", Links = new int[] { 0, 0 } }
            };
            graph.Init(cities);
            CollectionAssert.AreEqual(cities, graph.ToArray());
        }

        [Test]
        public void Can_Get_ToArray_Of_1()
        {
            var graph = MakeGraph();
            var cities = new GraphTableNode[1]
            {
                new GraphTableNode { City = "Dnepropetrovsk", Links = new int[] { 0 } }
            };
            graph.Init(cities);
            CollectionAssert.AreEqual(cities, graph.ToArray());
        }

        [Test]
        public void Can_Get_ToArray_Of_0()
        {
            var graph = MakeGraph();
            Assert.Throws<ArgumentNullException>(() => graph.ToArray());
        }

        [Test]
        public void Can_Get_ToArray_Of_Null()
        {
            var graph = MakeGraph();
            graph = null;
            Assert.Throws<NullReferenceException>(() => graph.ToArray());
        }
        #endregion

        #region ToString
        [Test]
        public void Can_Get_String_Of_Many()
        {
            var graph = MakeGraph();
            var cities = new GraphTableNode[4]
            {
                new GraphTableNode { City = "Dnepropetrovsk", Links = new int[] { 0, 500, 300, 0 } },
                new GraphTableNode { City = "Kiev", Links = new int[] { 0, 0, 200, 700 } },
                new GraphTableNode { City = "Harkov", Links = new int[] { 250, 0, 0, 500 } },
                new GraphTableNode { City = "Odessa", Links = new int[] { 450, 0, 0, 0 } }
            };
            graph.Init(cities);
            Assert.AreEqual("Dnepropetrovsk Kiev Harkov Odessa", graph.ToString());
        }

        [Test]
        public void Can_Get_String_Of_2()
        {
            var graph = MakeGraph();
            var cities = new GraphTableNode[2]
            {
                new GraphTableNode { City = "Dnepropetrovsk", Links = new int[] { 0, 500, 300, 0 } },
                new GraphTableNode { City = "Kiev", Links = new int[] { 0, 0, 200, 700 } }
            };
            graph.Init(cities);
            Assert.AreEqual("Dnepropetrovsk Kiev", graph.ToString());
        }

        [Test]
        public void Can_Get_String_Of_1()
        {
            var graph = MakeGraph();
            var cities = new GraphTableNode[1]
            {
                new GraphTableNode { City = "Dnepropetrovsk", Links = new int[] { 0, 500, 300, 0 } }
            };
            graph.Init(cities);
            Assert.AreEqual("Dnepropetrovsk", graph.ToString());
        }

        [Test]
        public void Can_Get_String_Of_0()
        {
            var graph = MakeGraph();
            Assert.Throws<ArgumentNullException>(() => graph.ToString());
        }

        [Test]
        public void Can_Get_String_Of_Null()
        {
            var graph = MakeGraph();
            graph = null;
            Assert.Throws<NullReferenceException>(() => graph.ToString());
        }
        #endregion

        #region Way
        [Test]
        public void Can_Get_Way_Of_Many()
        {
            var graph = MakeGraph();
            var cities = new[]
            {
                new GraphTableNode { City = "Dnepropetrovsk", Links = new[] { 0, 500, 300, 0 } },
                new GraphTableNode { City = "Kiev", Links = new[] { 0, 0, 200, 700 } },
                new GraphTableNode { City = "Harkov", Links = new[] { 250, 0, 0, 500 } },
                new GraphTableNode { City = "Odessa", Links = new[] { 450, 0, 0, 0 } }
            };
            graph.Init(cities);
            var expected = new List<int> { 0, 300, 300};
            var actual = graph.Way(1, 3);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Can_Get_Way_Of_2()
        {
            var graph = MakeGraph();
            var cities = new[]
            {
                new GraphTableNode { City = "Dnepropetrovsk", Links = new[] { 0, 500 } },
                new GraphTableNode { City = "Kiev", Links = new[] { 0, 0 } }
            };
            graph.Init(cities);
            var expected = new List<int> { 0, 500 };
            var actual = graph.Way(1, 2);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Can_Get_Way_Of_1()
        {
            var graph = MakeGraph();
            var cities = new GraphTableNode[1]
            {
                new GraphTableNode { City = "Dnepropetrovsk", Links = new int[] { 0 } },
            };
            graph.Init(cities);
            var expected = new List<int> { 0 };
            var actual = graph.Way(0,0);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Can_Get_Way_Of_0()
        {
            var graph = MakeGraph();
            Assert.Throws<ArgumentNullException>(() => graph.Way(0, 0));
        }

        [Test]
        public void Can_Get_Way_Of_Null()
        {
            var graph = MakeGraph();
            graph = null;
            Assert.Throws<NullReferenceException>(() => graph.Way(0, 0));
        }
        #endregion
    }
}
