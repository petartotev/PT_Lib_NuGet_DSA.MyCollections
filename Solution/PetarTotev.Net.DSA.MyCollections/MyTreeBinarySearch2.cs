using System;
using System.Collections.Generic;

namespace PetarTotev.Net.DSA.MyCollections
{
    /// <summary>
    /// MyTreeBinarySearch2-T- is a tree based structure. 
    /// Each element would have T value, left child and right child of type MyTreeBinarySearch2-T-. 
    /// The value of each parent is greater than the value of the left child, but is smaller than the value of the right one.
    /// MyTreeBinarySearch2-T- is quite the same as MyTreeBinarySearch-T-, but expanded and improved with additional functionality.
    /// </summary>
    /// <typeparam name="T">Any generic type T that is comparable (it implements the IComparable-T- interface).</typeparam>
    public class MyTreeBinarySearch2<T> where T : IComparable<T>
    {
        private int count;

        /// <summary>
        /// MyTreeBinarySearch2 is a constructor that creates a new MyTreeBinarySearch2 and sets the Root property to null.
        /// </summary>
        public MyTreeBinarySearch2()
        {
            this.Root = null;
        }

        /// <summary>
        /// MyTreeBinarySearch2 is a constructor that creates a new MyTreeBinarySearch2.
        /// Then it copies the root that comes as a method parameter and all of its children to this new MyTreeBinarySearch2 tree.
        /// </summary>
        public MyTreeBinarySearch2(MyNodeBST<T> root)
        {
            this.Copy(root);
        }

        /// <summary>
        /// Root is a property that returns the root of this.
        /// </summary>
        public MyNodeBST<T> Root { get; private set; }

        /// <summary>
        /// LeftChild is a property that returs the left child of this.
        /// </summary>
        public MyNodeBST<T> LeftChild { get; private set; }

        /// <summary>
        /// RightChild is a property that returns the right child of this.
        /// </summary>
        public MyNodeBST<T> RightChild { get; private set; }

        /// <summary>
        /// Value is a property that returns the value of this root.
        /// </summary>
        public T Value => this.Root.Value;

        /// <summary>
        /// Count is a property that returns the current count of all elements within the collection.
        /// </summary>
        public int Count
        {
            get
            {
                return this.count;
            }
        }

        /// <summary>
        /// Contains is a method that receives a T element as a parameter and evaluates if the collection contains such an element.
        /// Complexity: O(log n) / O(n).
        /// </summary>
        /// <param name="element">Any generic type T.</param>
        /// <returns>A boolean that reveals if the element is present in the collection or not.</returns>
        public bool Contains(T element)
        {
            MyNodeBST<T> current = this.Root;

            while (current != null)
            {
                int compare = current.Value.CompareTo(element);

                if (compare > 0)
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
        /// DeleteMax is a void method that deletes the element in the binary search tree with the maximum value.
        /// Complexity: O(log n) / O(n).
        /// </summary>
        public void DeleteMax()
        {
            if (this.Root == null)
            {
                throw new InvalidOperationException();
            }
            else if (this.Root.Left == null && this.Root.Right == null)
            {
                this.Root = null;
                count--;
            }
            else if (this.Root.Right == null && this.Root.Left != null)
            {
                this.Root = this.Root.Left;
                count--;
            }
            else
            {
                DeleteMaxRecursive(this.Root);
                count--;
            }
        }
        private void DeleteMaxRecursive(MyNodeBST<T> node)
        {
            if (node.Right.Right == null)
            {
                if (node.Right.Left == null)
                {
                    node.Right = null;
                }
                else
                {
                    node.Right = node.Right.Left;
                    node.Right.Left = null;
                    node.Right.Right = null;
                }
                return;
            }

            DeleteMaxRecursive(node.Right);
        }

        /// <summary>
        /// DeleteMin is a void method that deletes the element in the binary search tree with the minimum value.
        /// Complexity: O(log n) / O(n).
        /// </summary>
        public void DeleteMin()
        {
            if (this.Root == null)
            {
                throw new InvalidOperationException();
            }
            else if (this.Root.Left == null && this.Root.Right == null)
            {
                this.Root = null;
                count--;
            }
            else if (this.Root.Left == null && this.Root.Right != null)
            {
                this.Root = this.Root.Right;
                count--;
            }
            else
            {
                DeleteMinRecursive(this.Root);
                count--;
            }
        }
        private void DeleteMinRecursive(MyNodeBST<T> node)
        {
            if (node.Left.Left == null)
            {
                if (node.Left.Right == null)
                {
                    node.Left = null;
                }
                else
                {
                    node.Left = node.Left.Right;
                    node.Left.Left = null;
                    node.Left.Right = null;
                }
                return;
            }

            DeleteMinRecursive(node.Left);
        }

        /// <summary>
        /// EachInOrder is a void method that goes through all the nodes of the collection, following the InOrder traversal order.
        /// Once a node is being traversed a void action is being executed using the value of the node.
        /// </summary>
        /// <param name="action">An action to be executed with each value of all nodes of the Binary Search Tree.</param>
        public void EachInOrder(Action<T> action)
        {
            EachInOrderRecursive(this.Root, action);
        }
        private void EachInOrderRecursive(MyNodeBST<T> node, Action<T> action)
        {
            if (node != null)
            {
                EachInOrderRecursive(node.Left, action);
                action(node.Value);
                EachInOrderRecursive(node.Right, action);
            }
        }

        /// <summary>
        /// GetRank is a method that goes through the Binary Search Tree.
        /// It calculates the count of all elements with values less than the value of the element that comes as a method parameter.
        /// </summary>
        /// <param name="value">Any generic type T that is comparable (it implements the IComparable-T- interface).</param>
        /// <returns>An integer equal to the count of all elements with values less than the value of the T element method parameter.</returns>
        public int GetRank(T value)
        {
            int number = 0;
            GetRankRecursive(this.Root, value, ref number);
            return number;
        }
        private void GetRankRecursive(MyNodeBST<T> node, T element, ref int number)
        {
            if (node == null)
            {
                return;
            }
            if (node.Value.CompareTo(element) < 0)
            {
                number++;
            }

            GetRankRecursive(node.Left, element, ref number);
            GetRankRecursive(node.Right, element, ref number);
        }

        /// <summary>
        /// Insert is a void method that inserts a new Node with T value that comes as a parameter in the method.
        /// Complexity: O(log n) / O(n).
        /// </summary>
        /// <param name="value">Any generic type T that is comparable (it implements the IComparable-T- interface).</param>
        public void Insert(T value)
        {
            if (this.Root == null)
            {
                this.Root = new MyNodeBST<T>(value);
                count++;
                return;
            }

            MyNodeBST<T> parent = null;
            MyNodeBST<T> current = this.Root;

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
                count++;
                if (this.LeftChild == null)
                {
                    this.LeftChild = newNode;
                }
            }
            else
            {
                // parent.Value < value
                parent.Right = newNode;
                count++;
                if (this.RightChild == null)
                {
                    this.RightChild = newNode;
                }
            }
        }

        /// <summary>
        /// Range is a method that returns a new List which consists of all values within the binary search tree that are between the T lower and T upper values - which come as method parameters.
        /// </summary>
        /// <param name="lower">Any generic type T that is comparable (it implements the IComparable-T- interface).</param>
        /// <param name="upper">Any generic type T that is comparable (it implements the IComparable-T- interface).</param>
        /// <returns>Returns a new List of T which holds all values within the tree between the T lower and T upper value.</returns>
        public List<T> Range(T lower, T upper)
        {
            List<T> list = new List<T>();
            RangeRecursive(this.Root, list, lower, upper);
            return list;
        }
        private void RangeRecursive(MyNodeBST<T> node, List<T> list, T lower, T upper)
        {
            if (node == null)
            {
                return;
            }
            else
            {
                RangeRecursive(node.Left, list, lower, upper);
                if (node.Value.CompareTo(lower) >= 0 && node.Value.CompareTo(upper) <= 0)
                {
                    list.Add(node.Value);
                }
                RangeRecursive(node.Right, list, lower, upper);
            }
        }

        /// <summary>
        /// Search is a method that searches through the Binary Search Tree for a T item that comes as a parameter. 
        /// Once found - it creates a new MyTreeBinarySearch subtree with the node that has T element value as root and then returns it.
        /// Complexity: O(log n) / O(n).
        /// </summary>
        /// <param name="element">The value that has to be searched through the tree.</param>
        /// <returns>A new MyTreeBinarySearch subtree that has the node with T element as a root.</returns>
        public MyTreeBinarySearch2<T> Search(T element)
        {
            MyNodeBST<T> current = this.Root;

            while (current != null)
            {
                int compare = current.Value.CompareTo(element);

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
                    return new MyTreeBinarySearch2<T>(current);
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