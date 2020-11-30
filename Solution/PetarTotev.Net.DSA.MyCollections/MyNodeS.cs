namespace PetarTotev.Net.DSA.MyCollections
{
    /// <summary>
    /// MyNodeS of T is a "singly" Node class that suits the needs of MyLinkedListS of T - a "singly" linked list collection. Each node has a value and a next node.
    /// </summary>
    /// <typeparam name="T">Any generic type T that is comparable (it implements the IComparable of T interface).</typeparam>
    public class MyNodeS<T>
    {
        /// <summary>
        /// MyNodeS is a constructor that receives 2 parameters - T 'value' and MyNodeS of T 'next' 
        /// 'next' is set to null if not received as a parameter.
        /// The constructor sets the Next property equal to 'next' and the Value property equal to 'value'.
        /// </summary>
        /// <param name="value">Any generic type T.</param>
        /// <param name="next">MyNodeS of T that is set to null if not received as a method parameter.</param>
        public MyNodeS(T value, MyNodeS<T> next = null)
        {            
            this.Next = next;
            this.Value = value;
        }

        /// <summary>
        /// Next is a property of type MyNodeS of T that keeps the 'address' of another node of the same type as a reference that makes the link.
        /// </summary>
        public MyNodeS<T> Next { get; set; }

        /// <summary>
        /// Value is a property of type T that holds the value of the node itself.
        /// </summary>
        public T Value { get; set; }
    }
}
