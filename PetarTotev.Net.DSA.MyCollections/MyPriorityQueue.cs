using System;
using System.Collections.Generic;

namespace PetarTotev.Net.DSA.MyCollections
{
    /// <summary>
    /// MyPriorityQueue of T is a Max (Binary) Heap that has a HeapifyDown() method.
    /// </summary>
    /// <typeparam name="T">Any generic type T that is comparable (it implements the IComparable of T interface).</typeparam>
    public class MyPriorityQueue<T> where T : IComparable<T>
    {      
        private List<T> priorityQueue;

        /// <summary>
        /// MyPriorityQueue is a constructor that creates a new instance of MyPriorityQueue.
        /// It sets the inner collection this.priorityQueue to a new List of T;
        /// </summary>
        public MyPriorityQueue()
        {
            this.priorityQueue = new List<T>();
        }

        /// <summary>
        /// Count is a property that returns the current count of all elements within the collection.
        /// </summary>
        public int Count
        {
            get
            {
                return this.priorityQueue.Count;
            }
        }

        /// <summary>
        /// Add is a void method that receives a T element and inserts it at th eend into the inner collection (max heap).
        /// Then it heapifies it by swapping with its parent as long as the parent is greater than the element.
        /// Complexity: O(log n).
        /// </summary>
        /// <param name="element">Any generic type T.</param>
        public void Add(T element)
        {
            this.priorityQueue.Add(element);
            this.HeapifyUp(element, this.priorityQueue.Count - 1);
        }

        /// <summary>
        /// Dequeue is a method that receives no parameters and returns a T value.
        /// The value returned is the maximum one (the root) within the max heap (at index 0).
        /// It is dequeued from the collection.
        /// Complexity: O(log n).
        /// </summary>
        /// <returns>The maximum value within the priority queue (max heap).</returns>
        public T Dequeue()
        {
            var firstElement = this.Peek();
            this.Swap(0, this.Count - 1);
            this.priorityQueue.RemoveAt(this.Count - 1);
            this.HeapifyDown(firstElement, 0);
            return firstElement;
        }

        /// <summary>
        /// Peek is a method that receives no parameters and returns a T value.
        /// The value returned is the maximum one (the root) within the max heap (at index 0).
        /// Peek does not remove it from the collection.
        /// Complexity: O(1).
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (this.priorityQueue.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.priorityQueue[0];
        }

        /// <summary>
        /// HeapifyDown is a private void method that gets an index and moves the element at that index DOWN 
        /// as long as its child's value is less than the value of the element. 
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

                int compare = this.priorityQueue[parentIndex].CompareTo(this.priorityQueue[childIndex]);

                if (compare < 0)
                {
                    this.Swap(childIndex, parentIndex);
                }

                parentIndex = childIndex;
            }
        }

        /// <summary>
        /// HeapifyUp is a private void method that gets an index and moves the element at that index UP 
        /// as long as its parent's value is greater than the value of the element. 
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

            int compare = this.priorityQueue[indexParent].CompareTo(this.priorityQueue[indexChild]);

            if (compare < 0)
            {
                Swap(indexParent, indexChild);
                this.HeapifyUp(this.priorityQueue[indexParent], indexParent);
            }
        }

        private bool IsGreater(int left, int right)
        {
            return this.priorityQueue[left].CompareTo(this.priorityQueue[right]) < 0;
        }

        private void Swap(int index1, int index2)
        {
            T temp = this.priorityQueue[index1];
            this.priorityQueue[index1] = this.priorityQueue[index2];
            this.priorityQueue[index2] = temp;
        }
    }
}
