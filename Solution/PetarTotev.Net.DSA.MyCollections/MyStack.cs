using System;
using System.Collections;
using System.Collections.Generic;

namespace PetarTotev.Net.DSA.MyCollections
{
    /// <summary>
    /// MyStack-T- is a collection based on the principle Last-In-First-Out (LIFO). 
    /// A stack in which the element that was pushed first would be pulled last.
    /// </summary>
    /// <typeparam name="T">Any generic type T.</typeparam>
    public class MyStack<T> : IEnumerable<T>
    {
        private MyNodeS<T> tail;

        /// <summary>
        /// MyStack is a constructor that creates a new instance of MyStack. It receives no parameters.
        /// It sets the tail of the base LinkedList collection to null and its Count property to 0.
        /// </summary>
        public MyStack()
        {
            this.tail = null;
            this.Count = 0;
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
            var currentNode = this.tail;

            if (this.Count == 0)
            {
                return false;
            }

            for (int i = 0; i < this.Count; i++)
            {
                if (currentNode.Value.Equals(item))
                {
                    return true;
                }

                currentNode = currentNode.Next;
            }
            return false;
        }

        /// <summary>
        /// Contains is a method that receives a MyNodeD-T- item as a parameter and evaluates if the collection contains such a node.
        /// Complexity: O(n).
        /// </summary>
        /// <param name="item">A MyNodeD-T- "doubly" node item.</param>
        /// <returns>A boolean that reveals if the item is present in the collection or not.</returns>
        public bool Contains(MyNodeD<T> item)
        {
            var currentNode = this.tail;

            if (this.Count == 0)
            {
                return false;
            }

            for (int i = 0; i < this.Count; i++)
            {
                if (currentNode.Equals(item))
                {
                    return true;
                }

                currentNode = currentNode.Next;
            }
            return false;
        }

        /// <summary>
        /// Peek is a method that takes the tail element of the singly LinkedList.
        /// It returns its value without taking the element out of the collection.
        /// Complexity: O(1).
        /// </summary>
        /// <returns>The value of the element that is the tail (last) of the base collection.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the Count of the stack is equal to 0.</exception>
        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty so there is nothing to peek.");
            }
            else
            {
                var valueToReturn = this.tail.Value;
                return valueToReturn;
            }
        }

        /// <summary>
        /// Pop is a method that takes the tail element of the singly LinkedList.
        /// It takes it out of the collection and returns its value.
        /// Complexity: O(1).
        /// </summary>
        /// <returns>The value of the element that is "popped" out of the base collection.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the Count of the stack is equal to 0.</exception>
        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty so there is nothing to pop.");
            }
            else
            {
                var valueToReturn = this.tail.Value;
                this.tail = this.tail.Next;
                this.Count--;
                return valueToReturn;
            }
        }

        /// <summary>
        /// Push is a void method to insert a new item of T within the singly LinkedList as a tail (last).
        /// Complexity: O(1).
        /// </summary>
        /// <param name="item">The value of the MyNodeS to be created and set as the new tail of the singly LinkedList.</param>
        public void Push(T item)
        {
            if (this.tail == null)
            {
                this.tail = new MyNodeS<T>(item);
                this.Count++;
            }
            else
            {
                var currentLast = this.tail;
                this.tail = new MyNodeS<T>(item);
                this.tail.Next = currentLast;
                this.Count++;
            }
        }

        /// <summary>
        /// GetEnumerator is an imperative method for all classes implementing the IEnumerable interface.
        /// Complexity: O(n).
        /// </summary>
        /// <returns>Yield returns the values of all MyNodeS elements within the base singly LinkedList.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.tail;

            for (int i = 0; i < this.Count; i++)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
