using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PetarTotev.Net.DSA.MyCollections
{
    /// <summary>
    /// 
    /// </summary>
    public class MyTreeRedBlack<T> where T : IComparable
    {
        private const bool RED = true;
        private const bool BLACK = false;

        private MyNodeRBT root;

        private MyNodeRBT FindElement(T element)
        {
            MyNodeRBT current = this.root;

            while (current != null)
            {
                if (current.Value.CompareTo(element) > 0)
                {
                    current = current.Left;
                }
                else if (current.Value.CompareTo(element) < 0)
                {
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        private void PreOrderCopy(MyNodeRBT node)
        {
            if (node == null)
            {
                return;
            }

            this.Insert(node.Value);
            this.PreOrderCopy(node.Left);
            this.PreOrderCopy(node.Right);
        }              

        private void Range(MyNodeRBT node, Queue<T> queue, T startRange, T endRange)
        {
            if (node == null)
            {
                return;
            }

            int nodeInLowerRange = startRange.CompareTo(node.Value);
            int nodeInHigherRange = endRange.CompareTo(node.Value);

            if (nodeInLowerRange < 0)
            {
                this.Range(node.Left, queue, startRange, endRange);
            }
            if (nodeInLowerRange <= 0 && nodeInHigherRange >= 0)
            {
                queue.Enqueue(node.Value);
            }
            if (nodeInHigherRange > 0)
            {
                this.Range(node.Right, queue, startRange, endRange);
            }
        }

        private void EachInOrder(MyNodeRBT node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }

        private int Count(MyNodeRBT node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Count;
        }

        private MyTreeRedBlack(MyNodeRBT node)
        {
            this.PreOrderCopy(node);
        }

        /// <summary>
        /// 
        /// </summary>
        public MyTreeRedBlack()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
            this.root.Color = BLACK;
        }

        private MyNodeRBT Insert(T element, MyNodeRBT node)
        {
            if (node == null)
            {
                node = new MyNodeRBT(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Insert(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Insert(element, node.Right);
            }

            if (IsRed(node.Right) && !IsRed(node.Left))
            {
                node = this.RotateLeft(node);
            }
            if (IsRed(node.Left) && IsRed(node.Left.Left))
            {
                node = this.RotateRight(node);
            }
            if (IsRed(node.Left) && IsRed(node.Right))
            {
                node = this.FlipColors(node);
            }

            node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);
            return node;
        }

        private MyNodeRBT RotateLeft(MyNodeRBT node)
        {
            var temp = node.Right;
            node.Right = temp.Left;
            temp.Left = node;

            temp.Color = node.Color;
            node.Color = RED;
            node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);

            return temp;
        }

        private MyNodeRBT RotateRight(MyNodeRBT node)
        {
            var temp = node.Left;
            node.Left = temp.Right;
            temp.Right = node;

            temp.Color = node.Color;
            node.Color = RED;
            node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);

            return temp;
        }

        private MyNodeRBT FlipColors(MyNodeRBT node)
        {
            node.Color = RED;
            node.Left.Color = BLACK;
            node.Right.Color = BLACK;

            return node;
        }

        private bool IsRed(MyNodeRBT node)
        {
            if (node == null)
            {
                return false;
            }

            return node.Color;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool Contains(T element)
        {
            MyNodeRBT current = this.FindElement(element);

            return current != null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.root, action);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public MyTreeRedBlack<T> Search(T element)
        {
            MyNodeRBT current = this.FindElement(element);

            return new MyTreeRedBlack<T>(current);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteMin()
        {
            if (this.root == null)
            {
                throw new InvalidOperationException();
            }

            this.root = this.DeleteMin(this.root);
        }

        private MyNodeRBT DeleteMin(MyNodeRBT node)
        {
            if (node.Left == null)
            {
                return node.Right;
            }

            node.Left = this.DeleteMin(node.Left);
            node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);

            return node;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startRange"></param>
        /// <param name="endRange"></param>
        /// <returns></returns>
        public IEnumerable<T> Range(T startRange, T endRange)
        {
            Queue<T> queue = new Queue<T>();

            this.Range(this.root, queue, startRange, endRange);

            return queue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public virtual void Delete(T element)
        {
            if (this.root == null)
            {
                throw new InvalidOperationException();
            }
            this.root = this.Delete(element, this.root);
        }

        private MyNodeRBT Delete(T element, MyNodeRBT node)
        {
            if (node == null)
            {
                return null;
            }

            int compare = element.CompareTo(node.Value);

            if (compare < 0)
            {
                node.Left = this.Delete(element, node.Left);
            }
            else if (compare > 0)
            {
                node.Right = this.Delete(element, node.Right);
            }
            else
            {
                if (node.Right == null)
                {
                    return node.Left;
                }
                if (node.Left == null)
                {
                    return node.Right;
                }

                MyNodeRBT temp = node;
                node = this.FindMin(temp.Right);
                node.Right = this.DeleteMin(temp.Right);
                node.Left = temp.Left;

            }
            node.Count = this.Count(node.Left) + this.Count(node.Right) + 1;

            return node;
        }

        private MyNodeRBT FindMin(MyNodeRBT node)
        {
            if (node.Left == null)
            {
                return node;
            }

            return this.FindMin(node.Left);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteMax()
        {
            if (this.root == null)
            {
                throw new InvalidOperationException();
            }

            this.root = this.DeleteMax(this.root);
        }

        private MyNodeRBT DeleteMax(MyNodeRBT node)
        {
            if (node.Right == null)
            {
                return node.Left;
            }

            node.Right = this.DeleteMax(node.Right);
            node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);

            return node;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return this.Count(this.root);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public int Rank(T element)
        {
            return this.Rank(element, this.root);
        }

        private int Rank(T element, MyNodeRBT node)
        {
            if (node == null)
            {
                return 0;
            }

            int compare = element.CompareTo(node.Value);

            if (compare < 0)
            {
                return this.Rank(element, node.Left);
            }

            if (compare > 0)
            {
                return 1 + this.Count(node.Left) + this.Rank(element, node.Right);
            }

            return this.Count(node.Left);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rank"></param>
        /// <returns></returns>
        public T Select(int rank)
        {
            MyNodeRBT node = this.Select(rank, this.root);
            if (node == null)
            {
                throw new InvalidOperationException();
            }

            return node.Value;
        }

        private MyNodeRBT Select(int rank, MyNodeRBT node)
        {
            if (node == null)
            {
                return null;
            }

            int leftCount = this.Count(node.Left);
            if (leftCount == rank)
            {
                return node;
            }

            if (leftCount > rank)
            {
                return this.Select(rank, node.Left);
            }
            else
            {
                return this.Select(rank - (leftCount + 1), node.Right);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public T Ceiling(T element)
        {

            return this.Select(this.Rank(element) + 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public T Floor(T element)
        {
            return this.Select(this.Rank(element) - 1);
        }

        private class MyNodeRBT
        {
            public MyNodeRBT(T value, bool color = RED)
            {
                this.Value = value;
                this.Color = color;
            }

            public T Value { get; }
            public MyNodeRBT Left { get; set; }
            public MyNodeRBT Right { get; set; }

            public bool Color { get; set; }

            public int Count { get; set; }
        }
    }
}
