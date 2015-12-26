using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTreeBLL
{
    public class Node
    {
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int value)
        {
            Value = value;
        }
    }

    public class BinaryTree
    {
        public Node Head { get; private set; }
        public int Size { get; set; }

        public int Height(Node node)
        {
            var count = 0;
            var leftHeight = 0;
            var rightHeight = 0;
            if (node == null)
            {
                return 0;
            }

            if (node.Left != null)
            {
                leftHeight = Height(node.Left);
            }

            if (node.Right != null)
            {
                rightHeight = Height(node.Right);
            }

            count = Math.Max(leftHeight, rightHeight) + 1;
            return count;
        }

        public int Width(Node node)
        {
            var maxWidth = 0;
            var height = Height(node);
            for (var i = 0; i < height; i++)
            {
                var width = GetWidth(node, i);
                if (width > maxWidth)
                {
                    maxWidth = width;
                }
            }
            return maxWidth;
        }

        private int GetWidth(Node node, int level)
        {
            if (node == null)
            {
                return 0;
            }

            if (level == 1)
            {
                return 1;
            }
            else if (level > 1)
            {
                return GetWidth(node.Left, level - 1) + GetWidth(node.Right, level - 1);
            }

            var count = GetWidth(node.Right, level - 1);
            return count;
        }

        public void Clear()
        {
            Head = null;
            Size = 0;
        }

        public void Init(int[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentNullException();
            }

            foreach (var element in array)
            {
                Add(element);
            }
        }

        public int[] ToArray()
        {
            var array = new int[Size];
            for (var i = 0; i < Size; i++)
            {
                if (Head == null)
                {
                    throw new ArgumentNullException();
                }

                var stack = new Stack<Node>();
                var current = Head;
                var goLeftNext = true;
                stack.Push(current);
                while (stack.Count > 0)
                {
                    if (goLeftNext)
                    {
                        while (current.Left != null)
                        {
                            array[i] = current.Value;
                            stack.Push(current);
                            current = current.Left;
                        }
                    }

                    if (current.Right != null)
                    {
                        current = current.Right;
                        goLeftNext = true;
                    }
                    else
                    {
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }

            return array;
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            var array = ToArray();

            foreach (var element in array)
            {
                str.Append(element + " ");
            }
            return str.ToString();
        }

        public void Add(int value)
        {
            if (Head == null)
            {
                Head = new Node(value);
            }
            else
            {
                AddTo(Head, value);
            }
            Size++;
        }

        private void AddTo(Node node, int value)
        {
            if (node.Value > value)
            {
                if (node.Left == null)
                {
                    node.Left = new Node(value);
                }
                else
                {
                    AddTo(node.Left, value);
                }
            }
            else if (node.Value < value)
            {
                if (node.Right == null)
                {
                    node.Right = new Node(value);
                }
                else
                {
                    AddTo(node.Right, value);
                }
            }
        }

        public bool Contains(int value)
        {
            Node parent;
            return FindElement(value, out parent) != null;
        }

        private Node FindElement(int value, out Node parent)
        {
            var current = Head;
            parent = null;

            while (current != null)
            {
                if (current.Value > value)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (current.Value < value)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }
            return current;
        }

        public void Del(int value)
        {
            Node parent;

            var current = FindElement(value, out parent);
            if (current == null)
            {
                return;
            }
            Size--;

            if (current.Right == null)
            {
                if (parent == null)
                {
                    Head = current.Left;
                }
                else
                {
                    if (parent.Value > current.Value)
                    {
                        parent.Left = current.Left;
                    }
                    else if (parent.Value < current.Value)
                    {
                        parent.Right = current.Left;
                    }
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                if (parent == null)
                {
                    Head = current.Right;
                }
                else
                {
                    if (parent.Value > current.Value)
                    {
                        parent.Left = current.Right;
                    }
                    else if (parent.Value < current.Value)
                    {
                        parent.Right = current.Right;
                    }
                }
            }
            else
            {
                var leftMost = current.Left;
                var leftMostParent = leftMost.Left;

                while (leftMost.Left != null)
                {
                    leftMostParent = leftMost;
                    leftMost = leftMost.Left;
                }

                leftMostParent.Left = leftMost.Right;
                leftMost.Left = current.Left;
                leftMost.Right = current.Right;

                if (parent == null)
                {
                    Head = leftMost;
                }
                else
                {
                    if (parent.Value > current.Value)
                    {
                        parent.Left = leftMost;
                    }
                    else if (parent.Value < current.Value)
                    {
                        parent.Right = leftMost;
                    }
                }
            }
        }

        public int Nodes()
        {
            if (Head == null)
            {
                throw new ArgumentNullException();
            }

            var count = 0;
            var stack = new Stack<Node>();
            var current = Head;
            var goLeftNext = true;
            stack.Push(current);
            while (stack.Count > 0)
            {
                if (goLeftNext)
                {
                    while (current.Left != null)
                    {
                        stack.Push(current);
                        current = current.Left;
                    }
                }

                if (current.Right != null)
                {
                    current = current.Right;
                    goLeftNext = true;
                }
                else
                {
                    current = stack.Pop();
                    if (current.Left != null || current.Right != null)
                    {
                        count++;
                    }
                    goLeftNext = false;
                }
            }
            return count;
        }

        public int Leaves()
        {
            if (Head == null)
            {
                throw new ArgumentNullException();
            }

            var count = 0;
            var stack = new Stack<Node>();
            var current = Head;
            var goLeftNext = true;
            stack.Push(current);
            while (stack.Count > 0)
            {
                if (goLeftNext)
                {
                    while (current.Left != null)
                    {
                        stack.Push(current);
                        current = current.Left;
                    }
                }

                if (current.Right != null)
                {
                    current = current.Right;
                    goLeftNext = true;
                }
                else
                {
                    current = stack.Pop();
                    if (current.Left == null && current.Right == null)
                    {
                        count++;
                    }
                    goLeftNext = false;
                }
            }
            return count;
        }

        public string Reverse()
        {
            return ToString().Reverse().ToString();
        }

        public Node Loop(Node node, int width)
        {
            var stack = new Stack<Node>();
            var current = Head;
            var goLeftNext = true;
            stack.Push(current);
            while (stack.Count > 0)
            {
                if (goLeftNext)
                {
                    while (current.Left != null)
                    {
                        stack.Push(current);
                        current = current.Left;
                    }
                }

                if (current.Right != null)
                {
                    current = current.Right;
                    goLeftNext = true;
                }
                else
                {
                    current = stack.Pop();
                    goLeftNext = false;
                }
            }
            return current;
        }
    }
}
