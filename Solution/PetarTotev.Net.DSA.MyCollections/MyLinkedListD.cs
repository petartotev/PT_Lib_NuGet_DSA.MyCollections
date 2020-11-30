using System;
using System.Collections;
using System.Collections.Generic;

namespace PetarTotev.Net.DSA.MyCollections
{
    /// <summary>
    /// MyLinkedListD-T- is a "doubly" linked list collection. The "doubly" nodes that form the chain are of type MyNodeD-T-.
    /// </summary>
    /// <typeparam name="T">Any generic type T that is comparable (it implements the IComparable-T- interface).</typeparam>
    public class MyLinkedListD<T> : IEnumerable<T>
    {
        private MyNodeD<T> first;
        private MyNodeD<T> last;

        /// <summary>
        /// MyLinkedListD is a constructor that creates a new instance of MyLinkedListD.
        /// It either receives MyNodeD-T- 'first' and 'last' nodes that are set to the First and Last properties
        /// or it sets them to null if no such parameters are received within the constructor.
        /// </summary>
        /// <param name="first">MyNodeD-T- to be the first node within the collection.</param>
        /// <param name="last">MyNodeD-T- to be the last node within the collection.</param>
        public MyLinkedListD(MyNodeD<T> first = null, MyNodeD<T> last = null)
        {
            this.First = first;
            this.Last = last;
            this.Count = 0;

            if (this.First != null)
            {
                this.Count++;
            }

            if (this.Last != null)
            {
                this.Count++;
            }
        }

        /// <summary>
        /// First is a property that holds the first node of the Doubly Linked List collection.
        /// </summary>
        public MyNodeD<T> First
        {
            get
            {
                return this.first;
            }
            private set
            {
                this.first = value;
            }
        }

        /// <summary>
        /// Last is a property that holds the first node of the Doubly Linked List collection.
        /// </summary>
        public MyNodeD<T> Last
        {
            get
            {
                return this.last;
            }
            private set
            {
                this.last = value;
            }
        }

        /// <summary>
        /// Count is a property that returns the current count of all elements within the collection.
        /// </summary>
        public int Count { get; set; } = 0;

        /// <summary>
        /// AddAfter is a method that receives a MyNodeD 'node' and a T 'newValue'. 
        /// It creates a new node with value equal to 'newValue' and adds it after the 'node' received as method parameter.
        /// Complexity: 3*O(n) = O(n) ValidateIfNodeExists + O(n) ValidateIfNewNodeDoesNotExist + O(n) Find the node and add after.
        /// </summary>
        /// <param name="node">The MyNodeD-T- to add a new node after.</param>
        /// <param name="newValue">Any generic type T that would be the value of a new node to be inserted after the 'node'.</param>
        /// <returns>The new node created wih a value of 'newValue' which was added after the 'node' that came as parameter.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the Count of the Linked List is equal to 0.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the 'node' is not found in the collection.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the 'newNode' already exists in the collection.</exception>
        public MyNodeD<T> AddAfter(MyNodeD<T> node, T newValue)
        {
            MyNodeD<T> newNode = new MyNodeD<T>(newValue);
            this.AddAfter(node, newNode);
            return newNode;
        }

        /// <summary>
        /// AddAfter is a void method that receives a MyNodeD 'node' and MyNodeD 'newNode' as parameters.
        /// It adds the 'newNode' after the 'node' within the collection.
        /// Complexity: 3*O(n) = O(n) ValidateIfNodeExists + O(n) ValidateIfNewNodeDoesNotExist + O(n) Find the node and add after.
        /// </summary>
        /// <param name="node">The MyNodeD-T- after which a 'newNode' would be added.</param>
        /// <param name="newNode">The MyNodeD-T- to add after the 'node'.</param>
        /// <exception cref="InvalidOperationException">Thrown if the Count of the Linked List is equal to 0.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the 'node' is not found in the collection.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the 'newNode' already exists in the collection.</exception>
        public void AddAfter(MyNodeD<T> node, MyNodeD<T> newNode)
        {
            this.ValidateThatNewNodeDoesNotExistInCollection(newNode);
            this.ValidateThatNodeExistsInCollection(node);
            this.ValidateCount();

            MyNodeD<T> current = this.First;

            for (int i = 0; i < this.Count; i++)
            {
                if (current.Equals(node))
                {
                    if (i == this.Count - 1)
                    {
                        this.Last = newNode;
                        this.Last.Previous = current;
                        current.Next = this.Last;
                    }
                    else
                    {
                        var currentNext = current.Next;
                        currentNext.Previous = newNode;
                        newNode.Next = currentNext;
                        newNode.Previous = current;
                        current.Next = newNode;
                    }
                    this.Count++;
                    return;
                }
                current = current.Next;
            }
        }

        /// <summary>
        /// AddBefore is a method that receives a MyNodeD 'node' and a T 'newValue'. 
        /// It creates a new node with value equal to 'newValue' and adds it before the 'node' received as method parameter.
        /// Complexity: 3*O(n) = O(n) ValidateIfNodeExists + O(n) ValidateIfNewNodeDoesNotExist + O(n) Find the node and add before.
        /// </summary>
        /// <param name="node">The MyNodeD-T- to add a new node before.</param>
        /// <param name="newValue">Any generic type T that would be the value of a new node to be inserted before the 'node'.</param>
        /// <returns>The new node created wih a value of 'newValue' which was added before the 'node' that came as parameter.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the Count of the Linked List is equal to 0.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the 'node' is not found in the collection.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the 'newNode' already exists in the collection.</exception>
        public MyNodeD<T> AddBefore(MyNodeD<T> node, T newValue)
        {
            MyNodeD<T> newNode = new MyNodeD<T>(newValue);
            this.AddBefore(node, newNode);
            return newNode;
        }

        /// <summary>
        /// AddBefore is a void method that receives a MyNodeD 'node' and MyNodeD 'newNode' as parameters.
        /// It adds the 'newNode' before the 'node' within the collection.
        /// Complexity: 3*O(n) = O(n) ValidateIfNodeExists + O(n) ValidateIfNewNodeDoesNotExist + O(n) Find the node and add after.
        /// </summary>
        /// <param name="node">The MyNodeD-T- before which a 'newNode' would be added.</param>
        /// <param name="newNode">The MyNodeD-T- to add before the 'node'.</param>
        /// <exception cref="InvalidOperationException">Thrown if the Count of the Linked List is equal to 0.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the 'node' is not found in the collection.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the 'newNode' already exists in the collection.</exception>
        public void AddBefore(MyNodeD<T> node, MyNodeD<T> newNode)
        {
            this.ValidateThatNewNodeDoesNotExistInCollection(newNode);
            this.ValidateThatNodeExistsInCollection(node);
            this.ValidateCount();

            MyNodeD<T> current = this.First;

            for (int i = 0; i < this.Count; i++)
            {
                if (current.Equals(node))
                {
                    if (i == 0)
                    {
                        this.First = newNode;
                        this.First.Next = current;
                        current.Previous = this.First;
                    }
                    else
                    {
                        var currentPrevious = current.Previous;
                        currentPrevious.Next = newNode;
                        newNode.Previous = currentPrevious;
                        current.Previous = newNode;
                        newNode.Next = current;
                    }
                    this.Count++;
                    return;
                }
                current = current.Next;
            }
        }

        /// <summary>
        /// AddFirst is a method that receives a T value, creates a new node with that value and adds it as this.First within the collection.
        /// Complexity: O(1).
        /// </summary>
        /// <param name="value">Any generic type T.</param>
        /// <returns>The newly created node with value T 'value' that was added as the collection's First.</returns>
        public MyNodeD<T> AddFirst(T value)
        {
            MyNodeD<T> newNode = new MyNodeD<T>(value);
            this.AddFirst(newNode);
            return newNode;
        }

        /// <summary>
        /// AddFirst is a method that receives a node 'newNode' and adds it as this.First within the collection.
        /// Complexity: O(1).
        /// </summary>
        /// <param name="newNode">MyNodeD-T- 'newNode' to be added as First.</param>
        public void AddFirst(MyNodeD<T> newNode)
        {
            if (this.Count == 0)
            {
                this.First = this.Last = newNode;
            }
            else
            {
                var currentFirst = this.First;
                this.First = newNode;
                this.First.Next = currentFirst;
                currentFirst.Previous = this.First;
            }
            this.Count++;
        }

        /// <summary>
        /// AddLast is a method that receives a T value, creates a new node with that value and adds it as this.Last.
        /// Complexity: O(1).
        /// </summary>
        /// <param name="value">Any generic type T.</param>
        /// <returns>The newly created node with value T 'value' that was added as the collection's Last.</returns>
        public MyNodeD<T> AddLast(T value)
        {
            MyNodeD<T> newNode = new MyNodeD<T>(value);
            this.AddLast(newNode);
            return newNode;
        }

        /// <summary>
        /// AddLast is a method that receives a node 'newNode' and adds it as this.Last within the collection.
        /// Complexity: O(1).
        /// </summary>
        /// <param name="newNode">MyNodeD-T- 'newNode' to be added as Last.</param>
        public void AddLast(MyNodeD<T> newNode)
        {
            if (this.Count == 0)
            {
                this.First = this.Last = newNode;
            }
            else
            {
                var currentLast = this.Last;
                this.Last = newNode;
                this.Last.Previous = currentLast;
                currentLast.Next = this.Last;
            }
            this.Count++;
        }

        /// <summary>
        /// Clear is a void method that resets the MyLinkedListD by setting the First, the Last and their Next/Previous to null. 
        /// It also sets the Count to 0.
        /// Complexity: O(1).
        /// </summary>
        public void Clear()
        {
            this.First = this.Last = null;
            this.First.Next = this.First.Previous = this.Last.Next = this.Last.Previous = null;
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
        /// Find is a method that receives a T 'value' and returns the first MyNodeD-T- with such value found within the collection 
        /// or it returns null if no such element exists.
        /// Complexity: O(n).
        /// </summary>
        /// <param name="value">Any generic type T.</param>
        /// <returns>MyNodeD-T- if a node with such value is found. If not - returns null.</returns>
        public MyNodeD<T> Find(T value)
        {
            MyNodeD<T> current = this.first;

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

        /// <summary>
        /// Find is a method that receives a T 'value' and returns the last MyNodeD-T- with such value found within the collection 
        /// or it returns null if no such element exists.
        /// Complexity: O(n).
        /// </summary>
        /// <param name="value">Any generic type T.</param>
        /// <returns>MyNodeD-T- if a node with such value is found. If not - returns null.</returns>
        public MyNodeD<T> FindLast(T value)
        {
            MyNodeD<T> current = this.last;

            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (current.Value.Equals(value))
                {
                    return current;
                }

                current = current.Previous;
            }

            return null;
        }

        /// <summary>
        /// Remove is a void method that receives a MyNodeD-T- 'node' and if such node is found - removes it from the collection.
        /// If no such element exists within the Linked List - exception is thrown.
        /// Complexity: O(n).
        /// </summary>
        /// <param name="node">MyNodeD-T- node to be removed from the collection.</param>
        /// <exception cref="InvalidOperationException">Thrown if no such node exists within the collection.</exception>
        public void Remove(MyNodeD<T> node)
        {
            MyNodeD<T> current = this.first;

            for (int i = 0; i < this.Count; i++)
            {
                if (i == 0 && current.Equals(node))
                {
                    this.First = this.First.Next;
                    this.First.Previous = null;
                    this.Count--;
                    return;
                }
                else if (i == this.Count - 1 && current.Equals(node))
                {
                    this.Last = this.Last.Previous;
                    this.Last.Next = null;
                    this.Count--;
                    return;
                }
                else if (current.Equals(node))
                {
                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;
                    this.Count--;
                    return;
                }

                current = current.Next;
            }

            throw new InvalidOperationException("No such node in the LinkedList collection.");
        }

        /// <summary>
        /// Remove is a method that receives a T value and if a node with such value is found - it is removed from the collection.
        /// If so - returns true. If no such element exists - returns false.
        /// Complexity: O(n).
        /// </summary>
        /// <param name="value">Any generic type T.</param>
        /// <returns>A boolean that evaluates if a node with such value is found and removed from the collection.</returns>
        public bool Remove(T value)
        {
            if (this.Count == 0)
            {
                return false;
            }
            else
            {
                MyNodeD<T> current = this.first;

                for (int i = 0; i < this.Count; i++)
                {
                    if (i == 0 && current.Value.Equals(value))
                    {
                        this.First = this.First.Next;
                        this.Count--;
                        return true;
                    }
                    else if (i == this.Count - 1 && current.Value.Equals(value))
                    {
                        this.Last = this.Last.Previous;
                        this.Last.Next = null;
                        this.Count--;
                        return true;
                    }
                    else if (current.Value.Equals(value))
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                        this.Count--;
                        return true;
                    }

                    current = current.Next;
                }

                return false;
            }
        }

        /// <summary>
        /// RemoveFirst is a void method that removes the First element within the Linked List collection.
        /// Complexity: O(1).
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if the Count of collection is equals to 0.</exception>
        public void RemoveFirst()
        {
            ValidateCount();

            this.First = this.First.Next;
            this.First.Previous = null;
            this.Count--;
        }

        /// <summary>
        /// RemoveLast is a void method that removes the Last element within the Linked List collection.
        /// Complexity: O(1).
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if the Count of collection is equals to 0.</exception>
        public void RemoveLast()
        {
            ValidateCount();

            this.Last = this.Last.Previous;
            this.Last.Next = null;
            this.Count--;
        }

        /// <summary>
        /// GetEnumerator is an imperative method for all classes implementing the IEnumerable interface.
        /// Complexity: O(х).
        /// </summary>
        /// <returns>Yield returns the values of all nodes within the Linked List.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            MyNodeD<T> current = this.first;

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

        private void ValidateCount()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Count is 0.");
            }
        }

        private void ValidateThatNewNodeDoesNotExistInCollection(MyNodeD<T> newNode)
        {
            var current = this.First;

            for (int i = 0; i < this.Count; i++)
            {
                if (current.Equals(newNode))
                {
                    throw new InvalidOperationException("The new node you are trying to add already exists in the collection.");
                }

                current = current.Next;
            }
        }

        private void ValidateThatNodeExistsInCollection(MyNodeD<T> node)
        {
            bool isTrue = false;

            var current = this.First;

            for (int i = 0; i < this.Count; i++)
            {
                if (current.Equals(node))
                {
                    isTrue = true;
                    break;
                }

                current = current.Next;
            }

            if (isTrue == false)
            {
                throw new InvalidOperationException("The node you want to add next to does not exist in the collection.");
            }
        }
    }
}