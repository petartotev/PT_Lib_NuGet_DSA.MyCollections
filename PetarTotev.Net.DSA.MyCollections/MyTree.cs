using System;
using System.Collections.Generic;

namespace PetarTotev.Net.DSA.MyCollections
{
    /// <summary>
    /// MyTree-T- is a tree based structure - a MyTree-T- element would have a List-MyTree-T-- collection of children.
    /// </summary>
    /// <typeparam name="T">Any generic type T.</typeparam>
    public class MyTree<T>
    {
        /// <summary>
        /// MyTree is a constructor that creates a new instance of MyTree.
        /// It receives 2 parameters - a generic T value and 0, 1 or more children of type MyTree.
        /// It sets the Value property equal to value and the Children property to a new List of MyTree with 'children' as the List elements.
        /// </summary>
        /// <param name="value">Any generic type T.</param>
        /// <param name="children">A number of MyTree elements to be used for the Children property by saving them into a new List.</param>
        public MyTree(T value, params MyTree<T>[] children)
        {
            this.Value = value;
            this.Children = new List<MyTree<T>>(children);
        }

        /// <summary>
        /// Value is a property that returns the value of this MyTree.
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Children is a property that returns an IList collection of MyTrees that are the children of this MyTree.
        /// </summary>
        public IList<MyTree<T>> Children { get; private set; }

        /// <summary>
        /// GetBFS is a private method that traverses through the MyTree and gets the Breadth-First-Search order of all its elements.
        /// </summary>
        /// <returns>An IEnumerable collection with all the T values of the elements of the MyTree, ordered by BFS.</returns>
        public IEnumerable<T> GetBFS()
        {
            List<T> orderBFS = new List<T>();

            orderBFS.Add(this.Value);

            this.BFS(this, orderBFS);

            return orderBFS;
        }

        private void BFS(MyTree<T> myTree, List<T> orderBFS)
        {
            foreach (var child in myTree.Children)
            {
                orderBFS.Add(child.Value);
            }

            foreach (var child in myTree.Children)
            {
                BFS(child, orderBFS);
            }
        }

        /// <summary>
        /// GetDFS is a private method that traverses through the MyTree and gets the Depth-First-Search order of all its elements.
        /// </summary>
        /// <returns>An IEnumerable collection with all the T values of the elements of the MyTree, ordered by DFS.</returns>
        public IEnumerable<T> GetDFS()
        {
            List<T> orderDFS = new List<T>();

            this.DFS(this, orderDFS);

            return orderDFS;
        }

        private void DFS(MyTree<T> myTree, List<T> orderDFS)
        {
            foreach (var child in myTree.Children)
            {
                DFS(child, orderDFS);
            }

            orderDFS.Add(myTree.Value);
        }

        /// <summary>
        /// Each is a method that traverses recursively through the structure of the MyTree.
        /// It executes an action for each next MyTree subtree.
        /// </summary>
        /// <param name="action">The action void delegate to execute for each node during traversal.</param>
        public void Each(Action<T> action)
        {
            action(this.Value);

            foreach (var child in this.Children)
            {
                child.Each(action);
            }
        }

        /// <summary>
        /// Print is a recursive void method that uses Console.WriteLine() to print the structure of the MyTree on multiple console lines.
        /// The Print method receives an indent integer as a parameter or takes 0 as a default value for it.
        /// It is incremented and multiplied by 2 with each further nest.
        /// </summary>
        /// <param name="indent">An integer that is the "step" to move each child further to the right. By default it is set to 0.</param>
        public void Print(int indent = 0)
        {
            Console.Write(new string(' ', 2 * indent));
            Console.WriteLine(this.Value);

            foreach (var child in this.Children)
            {
                child.Print(indent + 1);
            }
        }
    }
}

/* 
            (7)
         /   |   \
     (19)  (21)  (14)
    /  |  \      /   \
 (1) (12) (31) (23)  (6)
*/