using System;
using System.Collections.Generic;
using System.Text;
using DataStructures.Abstract;

namespace DataStructures.Concrete.Graphs
{
    public class GraphTableNode
    {
        public string City { get; set; }
        public int[] Links { get; set; }
    }
    public class GraphTable : IGraph
    {
        private GraphTableNode[] _cities;
        public int Size { get; private set; }

        public GraphTable()
        {
            _cities = new GraphTableNode[0];
            Size = 0;
        }

        public void Init(GraphTableNode[] array)
        {
            if (array == null)
            {
                throw new NullReferenceException();
            }

            _cities = array;
            Size = array.Length;
        }

        public void AddNode(string city)
        {
            Size++;
            var temp = new GraphTableNode[Size];
            Array.Copy(_cities, temp, _cities.Length);
            _cities = temp;
            _cities[Size - 1] = new GraphTableNode { City = city, Links = new int[Size] };
        }

        public void AddLink(int from, int to, int cost)
        {
            if (Size <= 1)
            {
                throw new ArgumentNullException();
            }

            _cities[from - 1].Links[to - 1] = cost;
        }

        public void DelNode(int from)
        {
            if (Size == 0)
            {
                throw new ArgumentNullException();
            }

            foreach (var t in _cities)
            {
                t.Links[@from - 1] = 0;
            }

            var temp = new GraphTableNode[Size - 1];

            for (var i = 0; i < temp.Length; i++)
            {
                if (i >= from - 1)
                {
                    temp[i] = _cities[i + 1];
                    for (var j = 0; j < Size - 1; j++)
                    {
                        if (j >= from - 1)
                        {
                            temp[i].Links[j] = _cities[i].Links[j + 1];
                        }
                        else
                        {
                            temp[i].Links[j] = _cities[i].Links[j];
                        }
                    }
                }
                else
                {
                    temp[i] = _cities[i];
                    for (var j = 0; j < Size - 1; j++)
                    {
                        if (j >= from - 1)
                        {
                            temp[i].Links[j] = _cities[i].Links[j + 1];
                        }
                        else
                        {
                            temp[i].Links[j] = _cities[i].Links[j];
                        }
                    }
                }
            }
            Size--;
        }

        public void DelLink(int from, int to)
        {
            if (Size <= 1)
            {
                throw new ArgumentNullException();
            }

            _cities[from - 1].Links[to - 1] = 0;
        }

        public GraphTableNode[] ToArray()
        {
            if (Size == 0)
            {
                throw new ArgumentNullException();
            }
            var temp = new GraphTableNode[Size];
            bool[] visited = new bool[Size];
            Queue<GraphTableNode> turn = new Queue<GraphTableNode>();
            turn.Enqueue(_cities[0]);
            visited[0] = true;
            var index = 0;

            while (turn.Count != 0)
            {
                var item = turn.Dequeue();
                temp[index] = item;
                index++;

                for (var i = 0; i < Size; i++)
                {
                    for (var j = 0; j < Size; j++)
                    {
                        if (visited[i]) continue;
                        visited[i] = true;
                        turn.Enqueue(_cities[i]);
                    }
                }
            }
            return temp;
        }

        public override string ToString()
        {
            if (_cities == null)
            {
                throw new NullReferenceException();
            }

            if (Size == 0)
            {
                throw new ArgumentNullException();
            }

            var str = new StringBuilder();
            var temp = ToArray();

            foreach (var item in temp)
            {
                str.Append(item.City + " ");
            }

            return str.ToString().Trim();
        }

        public List<int> Way(int from, int to)
        {
            switch (Size)
            {
                case 0:
                    throw new ArgumentNullException();
                case 1:
                    return new List<int> { 0 };
                default:
                    var distance = new List<int>();
                    var visited = new bool[Size];
                    for (var i = @from - 1; i < to; i++)
                    {
                        distance.Add(int.MaxValue);
                        visited[i] = false;
                    }

                    distance[@from - 1] = 0;
                    var index = -1;
                    for (var i = @from - 1; i < to; i++)
                    {
                        var min = int.MaxValue;
                        for (var j = @from - 1; j < to; j++)
                        {
                            if (visited[j] || distance[j] > min) continue;
                            min = distance[j];
                            index = j;
                        }

                        visited[index] = true;
                        for (var j = @from - 1; j < to; j++)
                        {
                            if (!visited[j] && _cities[index].Links[j] > -1 &&
                                distance[index] != int.MaxValue &&
                                distance[index] + _cities[index].Links[j] < distance[j])
                            {
                                distance[j] = distance[index] + _cities[index].Links[j];
                            }
                        }
                    }
                    return distance;
            }
        }
    }
}
