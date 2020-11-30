namespace PetarTotev.Net.DSA.MyCollections
{
    /// <summary>
    /// MyNodeD of T is a "doubly" Node class that suits the needs of MyLinkedListD of T - a "doubly" linked list collection. 
    /// Each node has a value, a next node and a previous node.
    /// </summary>
    /// <typeparam name="T">Any generic type T that is comparable (it implements the IComparable of T interface).</typeparam>
    public class MyNodeD<T>
    {
        /// <summary>
        /// MyNodeD is a constructor that takes 3 parameters - T value, MyNodeD of T next and MyNodeD of T previous.
        /// The 'next' and 'previous' nodes are set to null by default if not received as method parameters.
        /// The constructor sets Next property = 'next', Previous property = 'previous' and 'Value' property = 'value'.
        /// </summary>
        /// <param name="value">Any generic type T.</param>
        /// <param name="next">MyNodeD of T that is set to null if not received as a method parameter.</param>
        /// <param name="previous">MyNodeD of T that is set to null if not received as a method parameter.</param>
        public MyNodeD(T value, MyNodeD<T> next = null, MyNodeD<T> previous = null)
        {            
            this.Next = next;
            this.Previous = previous;
            this.Value = value;
        }

        /// <summary>
        /// Next is a property that holds the 'address' to another MyNodeD of T that chains the doubly Linked List ahead.
        /// </summary>
        public MyNodeD<T> Next { get; set; }

        /// <summary>
        /// Previous is a property that holds the 'address' to another MyNodeD of T  that chains the doubly Linked List behind.
        /// </summary>
        public MyNodeD<T> Previous { get; set; }

        /// <summary>
        /// Value is a property of type T that holds the value of the node itself.
        /// </summary>
        public T Value { get; set; }
    }
}
