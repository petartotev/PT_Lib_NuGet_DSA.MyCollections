using System;
using System.Collections.Generic;
using System.Text;

namespace PetarTotev.Net.DSA.MyCollections
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyTreeAVL<T> where T : IComparable<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public MyNodeAVL<T> Root { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            var node = this.Search(this.Root, item);
            return node != null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Insert(T item)
        {
            this.Root = this.Insert(this.Root, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.Root, action);
        }

        private MyNodeAVL<T> Insert(MyNodeAVL<T> node, T item)
        {
            if (node == null)
            {
                return new MyNodeAVL<T>(item);
            }

            int cmp = item.CompareTo(node.Value);
            if (cmp < 0)
            {
                node.Left = this.Insert(node.Left, item);
            }
            else if (cmp > 0)
            {
                node.Right = this.Insert(node.Right, item);
            }

            node = Balance(node);

            UpdateHeight(node);

            return node;
        }

        private MyNodeAVL<T> Search(MyNodeAVL<T> node, T item)
        {
            if (node == null)
            {
                return null;
            }

            int cmp = item.CompareTo(node.Value);
            if (cmp < 0)
            {
                return Search(node.Left, item);
            }
            else if (cmp > 0)
            {
                return Search(node.Right, item);
            }

            return node;
        }

        private void EachInOrder(MyNodeAVL<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }

        private MyNodeAVL<T> RotateRight(MyNodeAVL<T> node)
        {
            var left = node.Left;
            node.Left = left.Right;
            left.Right = node;

            UpdateHeight(node);

            return left;
        }

        private MyNodeAVL<T> RotateLeft(MyNodeAVL<T> node)
        {
            var right = node.Right;
            node.Right = right.Left;
            right.Left = node;

            UpdateHeight(node);

            return right;
        }

        private void UpdateHeight(MyNodeAVL<T> node)
        {
            if (node != null)
            {
                node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
            }
        }

        private int Height(MyNodeAVL<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Height;
        }

        private MyNodeAVL<T> Balance(MyNodeAVL<T> node)
        {
            if (node == null)
            {
                return null;
            }

            var balance = Height(node.Left) - Height(node.Right);

            if (balance > 1)
            {
                var childBalance = Height(node.Left.Left) - Height(node.Left.Right);

                if (childBalance < 0)
                {
                    node.Left = RotateLeft(node.Left);
                }

                node = RotateRight(node);
            }
            else if (balance < -1)
            {
                var childBalance = Height(node.Right.Left) - Height(node.Right.Right);

                if (childBalance > 0)
                {
                    node.Right = RotateRight(node.Right);
                }

                node = RotateLeft(node);
            }

            return node;
        }
    }
}
