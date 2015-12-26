using System.Collections.Generic;
using DataStructures.Concrete.Graphs;

namespace DataStructures.Abstract
{
    public interface IGraph
    {
        int Size { get; }
        void Init(GraphTableNode[] array);
        void AddNode(string city);
        void AddLink(int from, int to, int cost);
        void DelNode(int from);
        void DelLink(int from, int to);
        GraphTableNode[] ToArray();
        string ToString();
        List<int> Way(int from, int to);
    }
}
