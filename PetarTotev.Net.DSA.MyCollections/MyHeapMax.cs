using System;
using System.Collections.Generic;

namespace PetarTotev.Net.DSA.MyCollections
{
    /// <summary>
    /// MyHeapMax of T is a Binary Heap with the following property: parent's value is more than the values of its children.
    /// </summary>
    /// <typeparam name="T">Any generic type T that is comparable (it implements the IComparable of T interface).</typeparam>
    public class MyHeapMax<T> where T : IComparable<T>
    {
        private List<T> heap;

        /// <summary>
        /// MyHeapMax is a constructor with no properties that creates a new MyHeapMax and sets this.heap to a new List of T.
        /// </summary>
        public MyHeapMax()
        {
            this.heap = new List<T>();
        }

        /// <summary>
        /// Count is a property that returns the current count of all elements within the collection.
        /// </summary>
        public int Count
        {
            get
            {
                return this.heap.Count;
            }
        }

        /// <summary>
        /// Insert is a void method that inserts a new element (T item) into the max heap collection.
        /// Complexity: O(log n).
        /// </summary>
        /// <param name="item">The generic type element to insert.</param>
        public void Insert(T item)
        {
            this.heap.Add(item);
            this.HeapifyUp(item, this.heap.Count - 1);
        }

        /// <summary>
        /// Peek is a method that "peeks" into the collection and returns the maximum element without removing it from the heap.
        /// Complexity: O(1).
        /// </summary>
        /// <returns>Returns the T item that has the maximum value of all items within the collection.</returns>
        /// <exception cref="InvalidOperationException">Thrown once the Count of the heap is equal to 0.</exception>
        public T Peek()
        {
            if (this.heap.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.heap[0];
        }

        /// <summary>
        /// Pull is a method that returns the maximum element of the collection - removing it from the heap.
        /// Complexity: O(log n).
        /// </summary>
        /// <returns>Returns the T item that has the maximum value of all items within the collection.</returns>
        /// <exception cref="InvalidOperationException">Thrown once the Count of the heap is equal to 0.</exception>
        public T Pull()
        {
            if (this.heap.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T itemToReturn = this.heap[0];
            Swap(0, this.Count - 1);
            this.heap.RemoveAt(this.Count - 1);
            this.HeapifyDown(itemToReturn, 0);

            return itemToReturn;
        }

        /// <summary>
        /// HeapifyDown is a private void method that gets an index and moves the element at that index DOWN as long as its child's value is less than the value of the element.
        /// Complexity: O(log n).
        /// </summary>
        /// <param name="element">A parameter that is not necessary.</param>
        /// <param name="index">An integer that is the index of the child to heapify up.</param>
        private void HeapifyDown(T element, int index)
        {
            int parentIndex = index;

            while (parentIndex < this.Count / 2)
            {
                // Left child.
                int childIndex = (parentIndex * 2) + 1;

                // If Right child exists.
                if (childIndex + 1 < this.Count && IsGreater(childIndex, childIndex + 1))
                {
                    // Right child.
                    childIndex += 1;
                }

                int compare = this.heap[parentIndex].CompareTo(this.heap[childIndex]);

                if (compare < 0)
                {
                    this.Swap(childIndex, parentIndex);
                }

                parentIndex = childIndex;
            }
        }

        /// <summary>
        /// HeapifyUp is a private void method that gets an index and moves the element at that index UP as long as its parent's value is greater than the value of the element. 
        /// Complexity: O(log n).
        /// </summary>
        /// <param name="item">A parameter that is not necessary.</param>
        /// <param name="indexChild">An integer that is the index of the child to heapify up.</param>
        private void HeapifyUp(T item, int indexChild)
        {
            int indexParent = (indexChild - 1) / 2;

            if (indexParent < 0)
            {
                return;
            }

            int compare = this.heap[indexParent].CompareTo(this.heap[indexChild]);

            if (compare < 0)
            {
                Swap(indexParent, indexChild);
                this.HeapifyUp(this.heap[indexParent], indexParent);
            }
        }

        /// <summary>
        /// IsGreater is a private method that gets two indices and returns a boolean value that evaluates if the element at the first index is greater than the element at the second index.
        /// </summary>
        /// <param name="left">An integer that is the index of the first element to evaluate.</param>
        /// <param name="right">An integer that is the index of the second element to evaluate.</param>
        /// <returns></returns>
        private bool IsGreater(int left, int right)
        {
            return this.heap[left].CompareTo(this.heap[right]) < 0;
        }

        /// <summary>
        /// Swap is a private method that swaps two elements with the given indices that are received as method parameters.
        /// </summary>
        /// <param name="index1">An integer that is the index of the first element to swap.</param>
        /// <param name="index2">An integer that is the index of the second element to swap.</param>
        private void Swap(int index1, int index2)
        {
            T temp = this.heap[index1];
            this.heap[index1] = this.heap[index2];
            this.heap[index2] = temp;
        }
    }
}

/* MAX HEAP: 
      25
     /  \
    17  16
   / \  / \
 09 05 08 15
 /
06
*/