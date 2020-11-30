using System;
using System.Collections;
using System.Collections.Generic;

namespace PetarTotev.Net.DSA.MyCollections
{
    /// <summary>
    /// MyLinkedListS-T- is a "singly" linked list collection. The "singly" nodes that form the chain are of type MyNodeS-T-.
    /// </summary>
    /// <typeparam name="T">Any generic type T that is comparable (it implements the IComparable-T- interface).</typeparam>
    public class MyLinkedListS<T> : IEnumerable<T>
    {
        private MyNodeS<T> head;
        private MyNodeS<T> tail;

        /// <summary>
        /// MyLinkedListS is a constructor that creates a new instance of MyLinkedListS.
        /// It receives 2 MyNodeS-T- parameters - 'head' and 'tail'. They are set to null if not received as constructor parameters.
        /// </summary>
        /// <param name="head">MyNodeS-T- that is set as the head of the Linked List.</param>
        /// <param name="tail">MyNodeS-T- that is set as the tail of the Linked List.</param>
        public MyLinkedListS(MyNodeS<T> head = null, MyNodeS<T> tail = null)
        {
            this.Count = 0;

            this.head = head;
            this.tail = tail;

            if (this.head != null)
            {
                this.Count++;
            }

            if (this.tail != null)
            {
                this.Count++;
            }
        }

        /// <summary>
        /// Count is a property that returns the current count of all elements within the collection.
        /// </summary>
        public int Count { get; set; } = 0;

        /// <summary>
        /// AddFirst is a void method that receives a T value and sets a new MyNodeS-T- with this value as the HEAD of the Linked List.
        /// Complexity: O(1).
        /// </summary>
        /// <param name="value">Any generic type T.</param>
        public void AddFirst(T value)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new MyNodeS<T>(value);
            }
            else
            {
                var currentHead = this.head;
                this.head = new MyNodeS<T>(value);
                this.head.Next = currentHead;
            }
            this.Count++;
        }

        /// <summary>
        /// AddLast is a void method that receives a T value and sets a new MyNodeS-T- with this value as the TAIL of the Linked List.
        /// Complexity: O(1).
        /// </summary>
        /// <param name="value">Any generic type T.</param>
        public void AddLast(T value)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new MyNodeS<T>(value);
            }
            else
            {
                var currentTail = this.tail;
                this.tail = new MyNodeS<T>(value);
                currentTail.Next = this.tail;
            }
            this.Count++;
        }

        /// <summary>
        /// Clear is a void method that resets the MyLinkedListS by setting the head, the tail and their Nexts to null. 
        /// It also sets the Count to 0.
        /// Complexity: O(1).
        /// </summary>
        public void Clear()
        {
            this.head = this.tail = null;
            this.head.Next = this.tail.Next = null;
            this.Count = 0;
        }

        /// <summary>
        /// Contains is a method that receives a T value as a parameter and evaluates if the collection contains such a value.
        /// Complexity: O(n).
        /// </summary>
        /// <param name="value">Any generic type T.</param>
        /// <returns>A boolean that reveals if the value is present in the collection or not.</returns>
        public bool Contains(T value)
        {
            if (this.Find(value) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// GetFirst is a method that receives no parameters and returns the value of the HEAD element of the Linked List.
        /// Complexity: O(1).
        /// </summary>
        /// <returns>The T value of the head of the Linked List collection.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the Count of the Linked List is equal to 0.</exception>
        public T GetFirst()
        {
            ValidateCount();

            return this.head.Value;
        }

        /// <summary>
        /// GetLast is a method that receives no parameters and returns the value of the TAIL element of the Linked List.
        /// Complexity: O(1).
        /// </summary>
        /// <returns>The T value of the head of the Linked List collection.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the Count of the Linked List is equal to 0.</exception>
        public T GetLast()
        {
            ValidateCount();

            return this.tail.Value;
        }

        /// <summary>
        /// RemoveFirst is a method that returns no parameters. 
        /// It removes the head of the Linked List and sets the head.Next as the new head.
        /// Complexity: O(1).
        /// </summary>
        /// <returns>The value of the removed ex-head of the collection.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the Count of the Linked List is equal to 0.</exception>
        public T RemoveFirst()
        {
            ValidateCount();

            var valueToReturn = this.head.Value;
            this.head = this.head.Next;
            this.Count--;

            return valueToReturn;
        }

        /// <summary>
        /// RemoveFirst is a method that returns no parameters. 
        /// It removes the tail of the Linked List and sets the second-to-last node as the new tail.
        /// Complexity: O(n). 
        /// </summary>
        /// <returns>The value of the removed ex-tail of the collection.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the Count of the Linked List is equal to 0.</exception>
        public T RemoveLast()
        {
            ValidateCount();

            var valueToReturn = this.tail.Value;

            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                this.tail = FindSecondToLastElement();
                this.tail.Next = null;
            }

            this.Count--;

            return valueToReturn;
        }

        /// <summary>
        /// GetEnumerator is an imperative method for all classes implementing the IEnumerable interface.
        /// Complexity: O(n).
        /// </summary>
        /// <returns>Yield returns the values of all nodes within the Linked List.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;

            for (int i = 0; i < this.Count; i++)
            {
                yield return current.Value;

                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private MyNodeS<T> Find(T value)
        {
            MyNodeS<T> current = this.head;

            for (int i = 0; i < this.Count; i++)
            {
                if (current.Value.Equals(value))
                {
                    return current;
                }

                current = current.Next;
            }

            return null;
        }

        private MyNodeS<T> FindSecondToLastElement()
        {
            MyNodeS<T> current = this.head;

            while (current.Next != this.tail)
            {
                current = current.Next;
            }

            return current;
        }

        private void ValidateCount()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
