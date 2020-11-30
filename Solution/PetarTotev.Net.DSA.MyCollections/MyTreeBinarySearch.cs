using System;
using System.Collections.Generic;

namespace PetarTotev.Net.DSA.MyCollections
{
    /// <summary>
    /// MyTreeBinarySearch-T- is a tree based structure. 
    /// Each element would have T value, left child and right child of type MyTreeBinarySearch-T-. 
    /// The value of each parent is greater than the value of the left child, but is smaller than the value of the right one.
    /// </summary>
    /// <typeparam name="T">Any generic type T that is comparable (it implements the IComparable-T- interface).</typeparam>
    public class MyTreeBinarySearch<T> where T : IComparable<T>
    {
        private MyNodeBST<T> root;

        /// <summary>
        /// MyTreeBinarySearch constructor creates a new MyTreeBinarySearch and sets this.root to null.
        /// </summary>
        public MyTreeBinarySearch()
        {
            this.root = null;
        }

        private MyTreeBinarySearch(MyNodeBST<T> node)
        {
            this.Copy(node);
        }

        /// <summary>
        /// Contains is a method that receives a T value as a parameter and evaluates if the collection contains such a value.
        /// Complexity: O(log n) / O(n).
        /// </summary>
        /// <param name="value">Any generic type T.</param>
        /// <returns>A boolean that reveals if the value is present in the collection or not.</returns>
        public bool Contains(T value)
        {
            MyNodeBST<T> current = this.root;

            while (current != null)
            {
                int compare = current.Value.CompareTo(value);

                if (compare > 1)
                {
                    current = current.Left;
                }
                else if (compare < 0)
                {
                    current = current.Right;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// DeleteMin is a void method that deletes the element in the binary search tree with the minimum value.
        /// Complexity: O(log n) / O(n).
        /// </summary>
        public void DeleteMin()
        {
            if (this.root == null)
            {
                return;
            }
            if (this.root.Left == null && this.root.Right == null)
            {
                this.root = null;
                return;
            }
            MyNodeBST<T> parent = null;
            MyNodeBST<T> current = this.root;

            while (current.Left != null)
            {
                parent = current;
                current = current.Left;
            }

            if (current.Right != null)
            {
                parent.Left = current.Right;
            }
            else
            {
                parent.Left = null;
            }
        }

        /// <summary>
        /// EachInOrder is a void method that goes through all the nodes of the collection, following the InOrder traversal order.
        /// Once a node is being traversed a void action is being executed using the value of the node.
        /// </summary>
        /// <param name="action">An action to be executed with each value of all nodes of the Binary Search Tree.</param>
        public void EachInOrder(Action<T> action)
        {
            if (this.root != null)
            {
                this.EachInOrder(this.root, action);
            }
        }
        private void EachInOrder(MyNodeBST<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }

        /// <summary>
        /// Insert is a void method that inserts a new Node with T value that comes as a parameter in the method.
        /// Complexity: O(log n) / O(n).
        /// </summary>
        /// <param name="value">Any generic type T that is comparable (it implements the IComparable-T- interface).</param>
        public void Insert(T value)
        {
            if (this.root == null)
            {
                this.root = new MyNodeBST<T>(value);
                return;
            }

            MyNodeBST<T> parent = null;
            MyNodeBST<T> current = this.root;

            while (current != null)
            {
                int compare = current.Value.CompareTo(value);

                if (compare > 0) // current.Value > value
                {
                    parent = current;
                    current = current.Left;
                }
                else if (compare < 0) // current.Value < value
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    return;
                }
            }

            MyNodeBST<T> newNode = new MyNodeBST<T>(value);

            if (parent.Value.CompareTo(value) > 0)
            {
                // parent.Value < value
                parent.Left = newNode;
            }
            else
            {
                // parent.Value < value
                parent.Right = newNode;
            }
        }

        /// <summary>
        /// Range is a method that returns a new List which consists of all values within the binary search tree that are between the T arg1 and T arg2 values - which come as method parameters.
        /// </summary>
        /// <param name="arg1">Any generic type T that is comparable (it implements the IComparable-T- interface).</param>
        /// <param name="arg2">Any generic type T that is comparable (it implements the IComparable-T- interface).</param>
        /// <returns>A new List of T which holds all values within the tree between the T arg1 and T arg2 value.</returns>
        public IEnumerable<T> Range(T arg1, T arg2)
        {
            List<T> result = new List<T>();

            this.Range(this.root, result, arg1, arg2);

            return result;
        }        
        private void Range(MyNodeBST<T> node, List<T> result, T arg1, T arg2)
        {
            if (node == null)
            {
                return;
            }

            int compareLow = node.Value.CompareTo(arg1);
            int compareHigh = node.Value.CompareTo(arg2);

            if (compareLow > 0)
            {
                this.Range(node.Left, result, arg1, arg2);
            }
            if (compareLow >= 0 && compareHigh <= 0)
            {
                result.Add(node.Value);
            }
            if (compareHigh < 0)
            {
                this.Range(node.Right, result, arg1, arg2);
            }
        }

        /// <summary>
        /// Search is a method that searches through the Binary Search Tree for a T item that comes as a parameter. 
        /// Once found - it creates a new MyTreeBinarySearch subtree with the node that has T item value as root and then returns it.
        /// Complexity: O(log n) / O(n).
        /// </summary>
        /// <param name="item">The value that has to be searched through the tree.</param>
        /// <returns>A new MyTreeBinarySearch subtree that has the node with T item as a root.</returns>
        public MyTreeBinarySearch<T> Search(T item)
        {
            MyNodeBST<T> current = this.root;

            while (current != null)
            {
                int compare = current.Value.CompareTo(item);

                if (compare > 0)
                {
                    // current.Value > item
                    current = current.Left;
                }
                else if (compare < 0)
                {
                    // current.value < item
                    current = current.Right;
                }
                else if (compare == 0)
                {
                    return new MyTreeBinarySearch<T>(current);
                }
            }

            return null;
        }

        private void Copy(MyNodeBST<T> node)
        {
            if (node == null)
            {
                return;
            }

            this.Insert(node.Value);
            this.Copy(node.Left);
            this.Copy(node.Right);
        }
    }
}

/* 
       (17)
     /     \
  (9)      (25)
 /    \   /    \
(3) (11) (20) (31)
*/