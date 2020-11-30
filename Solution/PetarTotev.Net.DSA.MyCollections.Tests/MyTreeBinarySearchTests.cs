namespace PetarTotev.Net.DSA.MyCollections.Tests
{
    using NUnit.Framework;
    using PetarTotev.Net.DSA.MyCollections;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class MyTreeBinarySearchTests
    {
        [Test]
        public void Insert_Single_TraverseInOrder()
        {
            // Arrange
            MyTreeBinarySearch<int> bst = new MyTreeBinarySearch<int>();
            bst.Insert(1);

            // Act
            List<int> nodes = new List<int>();
            bst.EachInOrder(nodes.Add);

            // Assert
            int[] expectedNodes = new int[] { 1 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void Insert_Multiple_TraverseInOrder()
        {
            // Arrange
            MyTreeBinarySearch<int> bst = new MyTreeBinarySearch<int>();
            bst.Insert(2);
            bst.Insert(1);
            bst.Insert(3);

            // Act
            List<int> nodes = new List<int>();
            bst.EachInOrder(nodes.Add);

            // Assert
            int[] expectedNodes = new int[] { 1, 2, 3 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void Contains_ExistingElement_ShouldReturnTrue()
        {
            // Arrange
            MyTreeBinarySearch<int> bst = new MyTreeBinarySearch<int>();
            bst.Insert(2);
            bst.Insert(1);
            bst.Insert(3);

            // Act
            bool contains = bst.Contains(1);

            // Assert
            Assert.IsTrue(contains);
        }

        [Test]
        public void Contains_NonExistingElement_ShouldReturnFalse()
        {
            // Arrange
            MyTreeBinarySearch<int> bst = new MyTreeBinarySearch<int>();
            bst.Insert(2);
            bst.Insert(1);
            bst.Insert(3);

            // Act
            bool contains = bst.Contains(5);

            // Assert
            Assert.IsFalse(contains);
        }

        [Test]
        public void Insert_Multiple_DeleteMin_Should_Work_Correctly()
        {
            // Arrange
            MyTreeBinarySearch<int> bst = new MyTreeBinarySearch<int>();
            bst.Insert(2);
            bst.Insert(1);
            bst.Insert(3);

            // Act
            bst.DeleteMin();
            List<int> nodes = new List<int>();
            bst.EachInOrder(nodes.Add);

            // Assert
            int[] expectedNodes = new int[] { 2, 3 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void DeleteMin_Empty_Tree_Should_Work_Correctly()
        {
            // Arrange
            MyTreeBinarySearch<int> bst = new MyTreeBinarySearch<int>();

            // Act
            bst.DeleteMin();
            List<int> nodes = new List<int>();
            bst.EachInOrder(nodes.Add);

            // Assert
            int[] expectedNodes = new int[] { };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void DeleteMin_One_Element_Should_Work_Correctly()
        {
            // Arrange
            MyTreeBinarySearch<int> bst = new MyTreeBinarySearch<int>();
            bst.Insert(1);

            // Act
            bst.DeleteMin();
            List<int> nodes = new List<int>();
            bst.EachInOrder(nodes.Add);

            // Assert
            int[] expectedNodes = new int[] { };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void Search_NonExistingElement_ShouldReturnEmptyTree()
        {
            // Arrange
            MyTreeBinarySearch<int> bst = new MyTreeBinarySearch<int>();

            // Act
            MyTreeBinarySearch<int> result = bst.Search(5);

            Assert.IsNull(result, null);
        }


        [Test]
        public void Search_ExistingElement_ShouldReturnSubTree()
        {
            // Arrange
            MyTreeBinarySearch<int> bst = new MyTreeBinarySearch<int>();

            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(1);
            bst.Insert(4);
            bst.Insert(8);
            bst.Insert(9);
            bst.Insert(37);
            bst.Insert(39);
            bst.Insert(45);

            // Act
            MyTreeBinarySearch<int> result = bst.Search(5);
            List<int> nodes = new List<int>();
            result.EachInOrder(nodes.Add);

            // Assert
            int[] expectedNodes = new int[] { 1, 3, 4, 5, 8, 9 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void Range_ExistingElements_ShouldReturnCorrectElements()
        {
            MyTreeBinarySearch<int> bst = new MyTreeBinarySearch<int>();

            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(1);
            bst.Insert(4);
            bst.Insert(8);
            bst.Insert(9);
            bst.Insert(37);
            bst.Insert(39);
            bst.Insert(45);

            // Act
            IEnumerable<int> result = bst.Range(4, 37);

            // Assert
            int[] expectedNodes = new int[] { 4, 5, 8, 9, 10, 37 };
            CollectionAssert.AreEqual(expectedNodes, result.ToArray());
        }

        [Test]
        public void Range_ExistingElements_ShouldReturnCorrectCount()
        {
            MyTreeBinarySearch<int> bst = new MyTreeBinarySearch<int>();

            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(1);
            bst.Insert(4);
            bst.Insert(8);
            bst.Insert(9);
            bst.Insert(37);
            bst.Insert(39);
            bst.Insert(45);

            // Act
            IEnumerable<int> result = bst.Range(4, 37);

            // Assert
            int[] expectedNodes = new int[] { 4, 5, 8, 9, 10, 37 };
            Assert.AreEqual(expectedNodes.Length, result.ToArray().Length);
        }
    }

}
