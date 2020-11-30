using System;
using System.Collections.Generic;

namespace PetarTotev.Net.DSA.MyCollections
{
    /// <summary>
    /// MyTreeBinary-T- is a tree based structure.
    /// Each element would have T value, left child and right child of type MyTreeBinary-T-.
    /// </summary>
    /// <typeparam name="T">Any generic type T.</typeparam>
    public class MyTreeBinary<T>
    {
        /// <summary>
        /// MyTreeBinary is a constructor that creates a new instance of MyTreeBinary.
        /// It receives T value, MyTreeBinary left and MyTreeBinary right and sets them to the properties Left, Right and Value.
        /// If left and right values are not passed as parameters to the constructor they are automatically set to null.
        /// </summary>
        /// <param name="value">Any generic type T.</param>
        /// <param name="left">MyTreeBinary of T to be declared as the Left Child of this MyTreeBinary of T.</param>
        /// <param name="right">MyTreeBinary of T to be declared as the Right Child of this MyTreeBinary of T.</param>
        public MyTreeBinary(T value, MyTreeBinary<T> left = null, MyTreeBinary<T> right = null)
        {
            this.Left = left;
            this.Right = right;
            this.Value = value;
        }

        /// <summary>
        /// Left is a property that returns MyTreeBinary of T - the Left Child of this MyTreeBinary of T.
        /// </summary>
        public MyTreeBinary<T> Left { get; set; }

        /// <summary>
        /// Right is a property that returns MyTreeBinary of T - the Right Child of this MyTreeBinary of T.
        /// </summary>
        public MyTreeBinary<T> Right { get; set; }

        /// <summary>
        /// Value is a property that returns the value of this MyTreeBinary.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// ListPreOrder method goes through the nodes of the tree always printing the parent first, before the left and right child.
        /// It traverses in the following order: parent -> left child -> right child.
        /// </summary>
        /// <returns>An IEnumerable collection of all the values of the nodes, based on the PreOrder traversal.</returns>
        public IEnumerable<T> ListPreOrder()
        {
            List<T> listPreOrder = new List<T>();
            PreOrder(this, listPreOrder);
            return listPreOrder;
        }

        private void PreOrder(MyTreeBinary<T> tree, IList<T> listPreOrder)
        {
            if (tree != null)
            {
                listPreOrder.Add(tree.Value);
                PreOrder(tree.Left, listPreOrder);
                PreOrder(tree.Right, listPreOrder);
            }
        }

        /// <summary>
        /// ListInOrder method goes through the nodes of the tree always printing the parent in the middle of the left and right child.
        /// It traverses in the following order: left child -> parent -> right child.
        /// </summary>
        /// <returns>An IEnumerable collection of all the values of the nodes, based on the InOrder traversal.</returns>
        public IEnumerable<T> ListInOrder()
        {
            List<T> listInOrder = new List<T>();
            InOrder(this, listInOrder);
            return listInOrder;
        }

        private void InOrder(MyTreeBinary<T> tree, IList<T> listInOrder)
        {
            if (tree != null)
            {
                InOrder(tree.Left, listInOrder);
                listInOrder.Add(tree.Value);
                InOrder(tree.Right, listInOrder);
            }
        }

        /// <summary>
        /// ListPostOrder method goes through the nodes of the tree always printing the parent last, after the left and right child.
        /// It traverses in the following order: left child -> right child -> parent.
        /// </summary>
        /// <returns>An IEnumerable collection of all the values of the nodes, based on the PostOrder traversal.</returns>
        public IEnumerable<T> ListPostOrder()
        {
            List<T> listPostOrder = new List<T>();
            PostOrder(this, listPostOrder);
            return listPostOrder;
        }

        private void PostOrder(MyTreeBinary<T> tree, IList<T> listPostOrder)
        {
            if (tree != null)
            {
                PostOrder(tree.Left, listPostOrder);
                PostOrder(tree.Right, listPostOrder);
                listPostOrder.Add(tree.Value);
            }
        }

        /// <summary>
        /// Print is a recursive void method that uses Console.WriteLine() to print the structure of the MyTree on multiple console lines.
        /// The Print method receives an indent integer as a parameter or takes 0 as a default value for it.
        /// It is incremented and multiplied by 2 with each further nest.
        /// </summary>
        /// <param name="tree">A MyTreeBinary of T to be the starting point of printing.</param>
        /// <param name="indent">An integer that is the "step" to move each child further to the right. By default it is set to 0.</param>
        public void Print(MyTreeBinary<T> tree, int indent = 0)
        {
            Console.Write(new string(' ', indent * 2));
            Console.WriteLine(tree.Value);

            if (tree.Left != null)
            {
                Print(tree.Left, indent + 1);
            }
            if (tree.Right != null)
            {
                Print(tree.Right, indent + 1);
            }
        }
    }
}

/* 
       (17)
     /      \
  (9)       (25)
 /    \    /    \
(3) (11)  (20) (31)

 PreOrder: 17 9 3 11 25 20 31
  InOrder: 3 9 11 17 20 25 31
PostOrder: 3 11 9 20 31 25 17
*/
