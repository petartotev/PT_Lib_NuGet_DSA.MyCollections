using System;
using System.Collections;
using System.Collections.Generic;

namespace PetarTotev.Net.DSA.MyCollections
{
    /// <summary>
    /// MyQueue-T- is a collection based on the principle First-In-First-Out (FIFO). 
    /// A queue in which the element that was queued first would get dequeued first.
    /// </summary>
    /// <typeparam name="T">Any generic type T.</typeparam>
    public class MyQueue<T> : IEnumerable<T>
    {
        private MyNodeD<T> first;
        private MyNodeD<T> last;

        /// <summary>
        /// MyQueue is a constructor that creates a new instance of MyQueue. It receives no parameters.
        /// It sets the first and the last element of inner LinkedList collection to null and its Count property to 0.
        /// </summary>
        public MyQueue()
        {
            this.Count = 0;
            this.first = null;
            this.last = null;
        }

        /// <summary>
        /// Count is a property that returns the current count of all elements within the collection.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Contains is a method that receives a T item as a parameter and evaluates if the collection contains such an item.
        /// Complexity: O(n).
        /// </summary>
        /// <param name="item">Any generic type T.</param>
        /// <returns>A boolean that reveals if the item is present in the collection or not.</returns>
        public bool Contains(T item)
        {
            var current = this.first;

            for (int i = 0; i < this.Count; i++)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }

                current = current.Previous;
            }

            return false;
        }

        /// <summary>
        /// Enqueue is a void method that receives a value of T and creates a new MyNodeD of T with this value.
        /// Then it adds it as the inner collection's last.
        /// Complexity: O(1).
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            MyNodeD<T> toInsert = new MyNodeD<T>(item);

            if (this.Count == 0)
            {
                this.first = this.last = toInsert;
            }
            else if (this.Count == 1)
            {
                this.last = toInsert;
                this.last.Next = this.first;
                this.first.Previous = this.last;
            }
            else
            {
                var currlast = this.last;
                this.last = toInsert;
                this.last.Next = currlast;
                currlast.Previous = this.last;
            }
            this.Count++;
        }

        /// <summary>
        /// Dequeue is a method that receives no parameters. 
        /// It returns the value T of the first element within the inner Linked List collection.
        /// The method also removes the element from the collection.
        /// Complexity: O(1).
        /// </summary>
        /// <returns>The value of the element that is the first within the inner Linked List collection.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the Count of the queue is equal to 0.</exception>
        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty so there is nothing to dequeue.");
            }
            if (this.Count == 1)
            {
                var valueToReturn = this.first.Value;

                this.first = this.last;
                this.first.Next = this.first.Previous = this.last.Next = this.last.Previous = null;

                this.Count--;

                return valueToReturn;
            }
            else
            {
                var newFirst = this.first.Previous;
                var currFirst = this.first;

                newFirst.Next = null;
                this.first = newFirst;

                this.Count--;

                return currFirst.Value;
            }
        }

        /// <summary>
        /// Peek is a method that receives no parameters. 
        /// It returns the value T of the first element within the inner Linked List collection.
        /// The method does not remove the element from the collection.
        /// Complexity: O(1).
        /// </summary>
        /// <returns>The value of the element that is the first within the inner Linked List collection.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the Count of the queue is equal to 0.</exception>
        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty so there is nothing to peek.");
            }
            else
            {
                return this.first.Value;
            }
        }

        /// <summary>
        /// GetEnumerator is an imperative method for all classes implementing the IEnumerable interface.
        /// Complexity: O(n).
        /// </summary>
        /// <returns>Yield returns the values of all MyNodeD elements within the base doubly LinkedList.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.first;

            for (int i = 0; i < this.Count; i++)
            {
                yield return currentNode.Value;

                currentNode = currentNode.Previous;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
