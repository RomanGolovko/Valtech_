using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Concrete.BinaryTrees
{
    public class NodeBT
    {
        public int Value { get; set; }
        public NodeBT Left { get; set; }
        public NodeBT Right { get; set; }

        public NodeBT(int value)
        {
            Value = value;
        }
    }

    public class BinaryTree
    {
        private NodeBT _head;
        public int Size { get; set; }

        public int Height()
        {
            var result = Height(_head);
            return result;
        }

        private int Height(NodeBT node)
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

        public int Width()
        {
            var result = Width(_head);
            return result;
        }
        private int Width(NodeBT node)
        {
            var maxWidth = 0;
            var height = Height(node);
            for (var i = 1; i <= height; i++)
            {
                var width = GetWidth(node, i);
                if (width > maxWidth)
                {
                    maxWidth = width;
                }
            }
            return maxWidth;
        }

        private int GetWidth(NodeBT node, int level)
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
            _head = null;
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
                if (_head == null)
                {
                    throw new ArgumentNullException();
                }

                var stack = new Stack<NodeBT>();
                var current = _head;
                var goLeftNext = true;
                stack.Push(current);
            var i = 0;
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

                    array[i++] = current.Value;

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
            return str.ToString().Trim();
        }

        public void Add(int value)
        {
            if (_head == null)
            {
                _head = new NodeBT(value);
            }
            else
            {
                AddTo(_head, value);
            }
            Size++;
        }

        private void AddTo(NodeBT node, int value)
        {
            if (node.Value > value)
            {
                if (node.Left == null)
                {
                    node.Left = new NodeBT(value);
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
                    node.Right = new NodeBT(value);
                }
                else
                {
                    AddTo(node.Right, value);
                }
            }
        }

        public bool Contains(int value)
        {
            NodeBT parent;
            return FindElement(value, out parent) != null;
        }

        private NodeBT FindElement(int value, out NodeBT parent)
        {
            var current = _head;
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
            NodeBT parent;

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
                    _head = current.Left;
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
                    _head = current.Right;
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
                    _head = leftMost;
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
            if (_head == null)
            {
                throw new ArgumentNullException();
            }

            var count = 0;
            var stack = new Stack<NodeBT>();
            var current = _head;
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

                if (current.Left != null || current.Right != null)
                {
                    count++;
                }
            }
            return count;
        }

        public int Leaves()
        {
            if (_head == null)
            {
                throw new ArgumentNullException();
            }

            var count = 0;
            var stack = new Stack<NodeBT>();
            var current = _head;
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
                    if (current.Left == null && current.Right == null)
                    {
                        count++;
                    }

                    current = stack.Pop();
                    goLeftNext = false;
                }

            }
            return count;
        }

        public string Reverse()
        {
            var result = ToArray();
            var temp = new int[result.Length];
            for (int i = result.Length - 1, j = 0; i >= 0; i--, j++)
            {
                temp[j] = result[i];
            }

            var str = new StringBuilder();
            var array = ToArray();

            foreach (var element in temp)
            {
                str.Append(element + " ");
            }
            return str.ToString().Trim();
        }
    }
}
