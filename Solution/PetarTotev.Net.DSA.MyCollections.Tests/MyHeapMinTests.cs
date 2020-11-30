namespace PetarTotev.Net.DSA.MyCollections.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;

    class MyHeapMinTests
    {
        [Test]
        public void TestHeapifyUpAddOne()
        {
            var integerHeap = new MyHeapMin<int>();
            integerHeap.Insert(13);
            Assert.AreEqual(13, integerHeap.Peek());
        }

        [Test]
        public void TestHeapifyUpAddMany()
        {
            var integerHeap = new MyHeapMin<int>();
            var elements = new List<int>() { 15, 6, 9, 5, 25, 8, 17, 16 };
            foreach (var el in elements)
            {
                integerHeap.Insert(el);
            }
            Assert.AreEqual(5, integerHeap.Peek());
        }

        [Test]
        public void TestSizeShouldBeCorrect()
        {
            var integerHeap = new MyHeapMin<int>();
            var elements = new List<int>() { 15, 25, 6, 9, 5, 8, 17, 16 };
            foreach (var el in elements)
            {
                integerHeap.Insert(el);
            }
            Assert.AreEqual(8, integerHeap.Count);
        }

        [Test]
        public void TestDequeueSingleElement()
        {
            var priorityQueue = new MyHeapMin<int>();
            priorityQueue.Insert(13);
            Assert.AreEqual(13, priorityQueue.Pull());
        }

        [Test]
        public void TestDequeueMultipleElements()
        {
            var queue = new MyHeapMin<int>();
            var elements = new List<int>() { 15, 25, 6, 9, 5, 8, 17, 16 };
            foreach (var element in elements)
            {
                queue.Insert(element);
            }
            int[] expected = { 5, 6, 8, 9, 15, 16, 17, 25 };
            int index = 0;
            Assert.AreEqual(expected.Length, queue.Count);
            while (queue.Count != 0)
            {
                Assert.AreEqual(expected[index++], queue.Pull());
            }
        }
    }
}
