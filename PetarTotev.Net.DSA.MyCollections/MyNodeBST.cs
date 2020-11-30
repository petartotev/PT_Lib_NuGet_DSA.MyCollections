namespace PetarTotev.Net.DSA.MyCollections
{
    /// <summary>
    /// MyNodeBST of T is a Node class that is used with MyTreeBinarySearch of T and MyTreeBinarySearch2 of T. 
    /// A node has a value, a left node and a right node.
    /// </summary>
    /// <typeparam name="T">Any generic type T.</typeparam>
    public class MyNodeBST<T>
    {
        /// <summary>
        /// MyNodeBST is a constructor that creates a new instance of MyNodeBST-T-.
        /// It receives a T 'value'and 2 nodes of type MyNodeBST-T- 'left' and 'right' that are set to null if no such parameter is received. 
        /// </summary>
        /// <param name="value">Any generic type T.</param>
        /// <param name="left">MyNodeBST-T- node that is set to null by default if no such method parameter is received.</param>
        /// <param name="right">MyNodeBST-T- node that is set to null by default if no such method parameter is received.</param>
        public MyNodeBST(T value, MyNodeBST<T> left = null, MyNodeBST<T> right = null)
        {            
            this.Left = left;
            this.Right = right;
            this.Value = value;
        }

        /// <summary>
        /// Left is a property that keeps a reference to a node of type MyNodeBST-T- that would be the left child of this node.
        /// </summary>
        public MyNodeBST<T> Left { get; set; }

        /// <summary>
        /// Right is a property that keeps a reference to a node of type MyNodeBST-T- that would be the right child of this node.
        /// </summary>
        public MyNodeBST<T> Right { get; set; }

        /// <summary>
        /// Value is a property that holds the value of this node.
        /// </summary>
        public T Value { get; set; }
    }
}
