using System;
using System.Collections;
using System.Collections.Generic;

namespace PetarTotev.Net.DSA.MyCollections
{
    /// <summary>
    /// MyList-T- is an implemented System.Collections.Generic List-T-. It is also known as ArrayList, Dynamic Array or ADS List.
    /// </summary>
    /// <typeparam name="T">Any generic type T.</typeparam>
    public class MyList<T> : IEnumerable<T>
    {
        //private List<int> listToCheckImplementationFrom = new List<int>();
        private const int DefaultCapacity = 4;
        private T[] array;

        /// <summary>
        /// MyList is a constructor that creates a new instance of MyList.
        /// It creates a new inner array that has length equal to the capacity received as a constructor parameter.
        /// If no such parameter is received, the length of the array is set to a default capacity of 4.
        /// </summary>
        /// <param name="initialCapacity">Int32 that would be the initial capacity, or length of the inner array.</param>
        public MyList(int initialCapacity = DefaultCapacity)
        {
            if (initialCapacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(initialCapacity));
            }

            this.array = new T[initialCapacity];
        }

        /// <summary>
        /// ~MyList is a destructor that has no special function but to remind you that Destructors do exist.
        /// </summary>
        ~MyList()
        {
            Console.WriteLine("Finalize");
        }

        /// <summary>
        /// [index] would return the value that is hold in the array at the certain index [index].
        /// Complexity: O(1).
        /// </summary>
        /// <param name="index">Int32 that is the index of the array to access or set.</param>
        /// <returns>The T value that is kept at the certain index of the array.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if the index is less than 0 or greater than / equal to the length of the inner array.</exception>
        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.array[index];
            }
            set
            {
                this.ValidateIndex(index);
                this.array[index] = value;
            }
        }

        /// <summary>
        /// Capacity is a property that returns the current length of the array that is the base of the MyList-T-.
        /// </summary>
        public int Capacity
        {
            get
            {
                return this.array.Length;
            }
        }

        /// <summary>
        /// Count is a property that returns the current count of all elements added within the collection.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Add is a void method that adds a new T item within the inner array of the MyList collection.
        /// Complexity: O(1)-amortized!
        /// </summary>
        /// <param name="item">Any generic type T.</param>
        public void Add(T item)
        {
            this.GrowIfNeeded();
            this.array[this.Count] = item;         
            this.Count++;
        }

        /// <summary>
        /// Clear is a void method that resets the array which is the base of the MyList-T- to a new collection with default capacity.
        /// Complexity: O(1).
        /// It also sets the Count to 0.
        /// </summary>
        public void Clear()
        {
            this.array = new T[DefaultCapacity];
            this.Count = 0;
        }

        /// <summary>
        /// Contains is a method that receives a T item as a parameter and evaluates if the collection contains such an item.
        /// Complexity: O(n).
        /// </summary>
        /// <param name="item">Any generic type T.</param>
        /// <returns>A boolean that reveals if the element is present in the collection or not.</returns>
        public bool Contains(T item)
        {
            return this.IndexOf(item) != -1;
        }

        /// <summary>
        /// IndexOf is a method that receives a T item and returns -1 if such item is not found or the index of the first such element looping forward.
        /// Complexity: O(n).
        /// </summary>
        /// <param name="item">Any generic type T.</param>
        /// <returns>The index of the first element equal to the T item looping forward.</returns>
        public int IndexOf(T item)
        {
            for (int i = 0; i < this.array.Length; i++)
            {
                if (this.array[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Insert is a void method that receives an index and an item and inserts the item at the certain index.
        /// Complexity: O(n)-amortized.
        /// </summary>
        /// <param name="index">Int32 that is the index to insert the item to.</param>
        /// <param name="item">Any generic type T.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if the index is less than 0 or greater than / equal to the length of the inner array.</exception>
        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            this.GrowIfNeeded();

            for (int i = this.Count; i > index; i--)
            {
                this.array[i] = this.array[i - 1];
            }

            this.array[index] = item;

            this.Count++;
        }

        /// <summary>
        /// LastIndexOf is a method that receives a T item and returns -1 if such item is not found or the index of the first such element looping backwards.
        /// Complexity: O(n).
        /// </summary>
        /// <param name="item">Any generic type T.</param>
        /// <returns>The last index of the first element equal to the T item looping backwards.</returns>
        public int LastIndexOf(T item)
        {
            for (int i = this.array.Length - 1; i >= 0; i--)
            {
                if (this.array[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Remove is a method that receives an item and removes it, returning true or returns false if such value is not found in the collection.
        /// Complexity: 2*O(n) = O(n) IndexOf(item) + O(n) RemoveAt(index).
        /// </summary>
        /// <param name="item">Any generic type T.</param>
        /// <returns>A boolean that evaluates if such item is found within the MyList collection.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if the index is less than 0 or greater than / equal to the length of the inner array.</exception>
        public bool Remove(T item)
        {
            int indexOfElement = this.IndexOf(item);

            if (indexOfElement == -1)
            {
                return false;
            }

            this.RemoveAt(indexOfElement);

            return true;
        }

        /// <summary>
        /// RemoveAt is a void method that receives an Int32 index and removes the value.
        /// Complexity: O(n).
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="IndexOutOfRangeException">Thrown if the index is less than 0 or greater than / equal to the length of the inner array.</exception>
        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            // It is important to use this.Count - 1 instead of this.array.Length - 1. 
            // Because you don't need to go through the empty part of this.array!
            for (int i = index; i < this.Count - 1; i++) 
            {
                this.array[i] = this.array[i + 1];
            }

            this.array[this.Count - 1] = default;
            this.Count--;
        }

        /// <summary>
        /// GetEnumerator is an imperative method for all classes implementing the IEnumerable interface.
        /// Complexity: O(n).
        /// </summary>
        /// <returns>Yield returns the values within the inner array of the MyList.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.array[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }        

        private void Grow()
        {
            T[] newArray = new T[this.Capacity * 2];

            // Originally it was i < this.array.Length but this.Count will skip the empty part of the collection.
            for (int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.array[i];
            }

            this.array = newArray;
        }

        private void GrowIfNeeded()
        {
            if (this.Capacity == this.Count)
            {
                Grow();
            }
        }

        private void ValidateIndex(int index)
        {
            // This was not working once tested as it was index >= this.array.Length so it did return null instead of exception.
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}