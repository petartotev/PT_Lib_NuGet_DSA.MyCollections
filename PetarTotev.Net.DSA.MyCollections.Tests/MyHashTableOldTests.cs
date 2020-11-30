namespace PetarTotev.Net.DSA.MyCollections.Tests
{
    using NUnit.Framework;
    using PetarTotev.Net.DSA.MyCollections;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class MyHashTableTests
    {
        [Test]
        public void Add_EmptyHashTable_NoDuplicates_ShouldAddElement()
        {
            // Arrange
            MyHashTable<string, int> hashTable = new MyHashTable<string, int>();

            // Act
            MyKeyValuePair<string, int>[] elements = {
            new MyKeyValuePair<string, int>("Peter", 5),
            new MyKeyValuePair<string, int>("Maria", 6),
            new MyKeyValuePair<string, int>("George", 4),
            new MyKeyValuePair<string, int>("Kiril", 5)
        };
            foreach (MyKeyValuePair<string, int> element in elements)
            {
                hashTable.Add(element.Key, element.Value);
            }

            // Assert
            List<MyKeyValuePair<string, int>> actualElements = hashTable.ToList();
            CollectionAssert.AreEquivalent(elements, actualElements);
        }

        [Test]
        public void Add_EmptyHashTable_Duplicates_ShouldThrowException()
        {
            // Arrange
            // Act
            Assert.Throws<ArgumentException>(() => new MyHashTable<string, string> { { "Peter", "first" }, { "Peter", "second" } });
        }

        [Test]
        public void Add_1000_Elements_Grow_ShouldWorkCorrectly()
        {
            // Arrange
            MyHashTable<string, int> hashTable = new MyHashTable<string, int>(1);

            // Act
            List<MyKeyValuePair<string, int>> expectedElements = new List<MyKeyValuePair<string, int>>();
            for (int i = 0; i < 1000; i++)
            {
                hashTable.Add("key" + i, i);
                expectedElements.Add(new MyKeyValuePair<string, int>("key" + i, i));
            }

            // Assert
            List<MyKeyValuePair<string, int>> actualElements = hashTable.ToList();
            CollectionAssert.AreEquivalent(expectedElements, actualElements);
        }

        [Test]
        public void AddOrReplace_WithDuplicates_ShouldWorkCorrectly()
        {
            // Arrange
            MyHashTable<string, int> hashTable = new MyHashTable<string, int>();

            // Act
            hashTable.AddOrReplace("Peter", 555);
            hashTable.AddOrReplace("Maria", 999);
            hashTable.AddOrReplace("Maria", 123);
            hashTable.AddOrReplace("Maria", 6);
            hashTable.AddOrReplace("Peter", 5);

            // Assert
            MyKeyValuePair<string, int>[] expectedElements = {
            new MyKeyValuePair<string, int>("Peter", 5),
            new MyKeyValuePair<string, int>("Maria", 6)
        };
            List<MyKeyValuePair<string, int>> actualElements = hashTable.ToList();
            CollectionAssert.AreEquivalent(expectedElements, actualElements);
        }

        [Test]
        public void Count_Empty_Add_Remove_ShouldWorkCorrectly()
        {
            // Arrange
            MyHashTable<string, int> hashTable = new MyHashTable<string, int>();

            // Assert
            Assert.AreEqual(0, hashTable.Count);

            // Act & Assert
            hashTable.Add("Peter", 555);
            hashTable.AddOrReplace("Peter", 555);
            hashTable.AddOrReplace("Ivan", 555);
            Assert.AreEqual(2, hashTable.Count);

            // Act & Assert
            hashTable.Remove("Peter");
            Assert.AreEqual(1, hashTable.Count);

            // Act & Assert
            hashTable.Remove("Peter");
            Assert.AreEqual(1, hashTable.Count);

            // Act & Assert
            hashTable.Remove("Ivan");
            Assert.AreEqual(0, hashTable.Count);
        }

        [Test]
        public void Get_ExistingElement_ShouldReturnTheValue()
        {
            // Arrange
            MyHashTable<int, string> hashTable = new MyHashTable<int, string> { { 555, "Peter" } };

            // Act
            string actualValue = hashTable.Get(555);

            // Assert
            Assert.AreEqual("Peter", actualValue);
        }

        [Test]
        public void Get_NonExistingElement_ShouldThrowException()
        {
            // Arrange
            MyHashTable<int, string> hashTable = new MyHashTable<int, string>();

            // Act
            Assert.Throws<KeyNotFoundException>(() => hashTable.Get(12345));
        }

        [Test]
        public void Indexer_ExistingElement_ShouldReturnTheValue()
        {
            // Arrange
            MyHashTable<int, string> hashTable = new MyHashTable<int, string> { { 555, "Peter" } };

            // Act
            string actualValue = hashTable[555];

            // Assert
            Assert.AreEqual("Peter", actualValue);
        }

        [Test]
        public void Indexer_NonExistingElement_ShouldThrowException()
        {
            // Arrange
            MyHashTable<int, string> hashTable = new MyHashTable<int, string>();
            string value;
            // Act
            Assert.Throws<KeyNotFoundException>(() => value = hashTable[12345]);
        }

        [Test]
        public void Indexer_AddReplace_WithDuplicates_ShouldWorkCorrectly()
        {
            // Arrange
            MyHashTable<string, int> hashTable = new MyHashTable<string, int>
            {
                ["Peter"] = 555,
                ["Maria"] = 999,
                ["Maria"] = 123,
                ["Maria"] = 6,
                ["Peter"] = 5
            };

            // Act

            // Assert
            MyKeyValuePair<string, int>[] expectedElements = {
            new MyKeyValuePair<string, int>("Peter", 5),
            new MyKeyValuePair<string, int>("Maria", 6)
        };
            List<MyKeyValuePair<string, int>> actualElements = hashTable.ToList();
            CollectionAssert.AreEquivalent(expectedElements, actualElements);
        }

        [Test]
        public void Capacity_Grow_ShouldWorkCorrectly()
        {
            // Arrange
            MyHashTable<string, int> hashTable = new MyHashTable<string, int>(2);

            // Assert
            Assert.AreEqual(2, hashTable.Capacity);

            // Act
            hashTable.Add("Peter", 123);
            hashTable.Add("Maria", 456);

            // Assert
            Assert.AreEqual(4, hashTable.Capacity);

            // Act
            hashTable.Add("Tanya", 555);
            hashTable.Add("George", 777);

            // Assert
            Assert.AreEqual(8, hashTable.Capacity);
        }

        [Test]
        public void TryGetValue_ExistingElement_ShouldReturnTheValue()
        {
            // Arrange
            MyHashTable<int, string> hashTable = new MyHashTable<int, string> { { 555, "Peter" } };

            // Act
            bool result = hashTable.TryGetValue(555, out string value);

            // Assert
            Assert.AreEqual("Peter", value);
            Assert.IsTrue(result);
        }

        [Test]
        public void TryGetValue_NonExistingElement_ShouldReturnFalse()
        {
            // Arrange
            MyHashTable<int, string> hashTable = new MyHashTable<int, string>();

            // Act
            bool result = hashTable.TryGetValue(555, out string value);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Find_ExistingElement_ShouldReturnTheElement()
        {
            // Arrange
            MyHashTable<string, DateTime> hashTable = new MyHashTable<string, DateTime>();
            string name = "Maria";
            DateTime date = new DateTime(1995, 7, 18);
            hashTable.Add(name, date);

            // Act
            MyKeyValuePair<string, DateTime> element = hashTable.Find(name);

            // Assert
            MyKeyValuePair<string, DateTime> expectedElement = new MyKeyValuePair<string, DateTime>(name, date);
            Assert.AreEqual(expectedElement, element);
        }

        [Test]
        public void Find_NonExistingElement_ShouldReturnNull()
        {
            // Arrange
            MyHashTable<string, DateTime> hashTable = new MyHashTable<string, DateTime>();

            // Act
            MyKeyValuePair<string, DateTime> element = hashTable.Find("Maria");

            // Assert
            Assert.IsNull(element);
        }

        [Test]
        public void ContainsKey_ExistingElement_ShouldReturnTrue()
        {
            // Arrange
            MyHashTable<DateTime, string> hashTable = new MyHashTable<DateTime, string>();
            DateTime date = new DateTime(1995, 7, 18);
            hashTable.Add(date, "Some value");

            // Act
            bool containsKey = hashTable.ContainsKey(date);

            // Assert
            Assert.IsTrue(containsKey);
        }

        [Test]
        public void ContainsKey_NonExistingElement_ShouldReturnFalse()
        {
            // Arrange
            MyHashTable<DateTime, string> hashTable = new MyHashTable<DateTime, string>();
            DateTime date = new DateTime(1995, 7, 18);

            // Act
            bool containsKey = hashTable.ContainsKey(date);

            // Assert
            Assert.IsFalse(containsKey);
        }

        [Test]
        public void Remove_ExistingElement_ShouldWorkCorrectly()
        {
            // Arrange
            MyHashTable<string, double> hashTable = new MyHashTable<string, double> { { "Peter", 12.5 }, { "Maria", 99.9 } };

            // Assert
            Assert.AreEqual(2, hashTable.Count);

            // Act
            bool removed = hashTable.Remove("Peter");

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(1, hashTable.Count);
        }

        [Test]
        public void Remove_NonExistingElement_ShouldWorkCorrectly()
        {
            // Arrange
            MyHashTable<string, double> hashTable = new MyHashTable<string, double> { { "Peter", 12.5 }, { "Maria", 99.9 } };

            // Assert
            Assert.AreEqual(2, hashTable.Count);

            // Act
            bool removed = hashTable.Remove("George");

            // Assert
            Assert.IsFalse(removed);
            Assert.AreEqual(2, hashTable.Count);
        }

        [Test]
        public void Remove_5000_Elements_ShouldWorkCorrectly()
        {
            // Arrange
            MyHashTable<string, int> hashTable = new MyHashTable<string, int>();
            List<string> keys = new List<string>();
            int count = 5000;
            for (int i = 0; i < count; i++)
            {
                string key = Guid.NewGuid().ToString();
                keys.Add(key);
                hashTable.Add(key, i);
            }

            // Assert
            Assert.AreEqual(count, hashTable.Count);

            // Act & Assert
            keys.Reverse();
            foreach (string key in keys)
            {
                hashTable.Remove(key);
                count--;
                Assert.AreEqual(count, hashTable.Count);
            }

            // Assert
            List<MyKeyValuePair<string, int>> expectedElements = new List<MyKeyValuePair<string, int>>();
            List<MyKeyValuePair<string, int>> actualElements = hashTable.ToList();
            CollectionAssert.AreEquivalent(expectedElements, actualElements);
        }

        [Test]
        public void Clear_ShouldWorkCorrectly()
        {
            // Arrange
            MyHashTable<string, int> hashTable = new MyHashTable<string, int>();

            // Assert
            Assert.AreEqual(0, hashTable.Count);

            // Act
            hashTable.Clear();

            // Assert
            Assert.AreEqual(0, hashTable.Count);

            // Arrange
            hashTable.Add("Peter", 5);
            hashTable.Add("George", 7);
            hashTable.Add("Maria", 3);

            // Assert
            Assert.AreEqual(3, hashTable.Count);

            // Act
            hashTable.Clear();

            // Assert
            Assert.AreEqual(0, hashTable.Count);
            List<MyKeyValuePair<string, int>> expectedElements = new List<MyKeyValuePair<string, int>>();
            List<MyKeyValuePair<string, int>> actualElements = hashTable.ToList();
            CollectionAssert.AreEquivalent(expectedElements, actualElements);

            hashTable.Add("Peter", 5);
            hashTable.Add("George", 7);
            hashTable.Add("Maria", 3);

            // Assert
            Assert.AreEqual(3, hashTable.Count);
        }

        [Test]
        public void Keys_ShouldWorkCorrectly()
        {
            // Arrange
            MyHashTable<string, double> hashTable = new MyHashTable<string, double>();

            // Assert
            CollectionAssert.AreEquivalent(new string[0], hashTable.Keys.ToArray());

            // Arrange
            hashTable.Add("Peter", 12.5);
            hashTable.Add("Maria", 99.9);
            hashTable["Peter"] = 123.45;

            // Act
            IEnumerable<string> keys = hashTable.Keys;

            // Assert
            string[] expectedKeys = { "Peter", "Maria" };
            CollectionAssert.AreEquivalent(expectedKeys, keys.ToArray());
        }

        [Test]
        public void Values_ShouldWorkCorrectly()
        {
            // Arrange
            MyHashTable<string, double> hashTable = new MyHashTable<string, double>();

            // Assert
            CollectionAssert.AreEquivalent(new string[0], hashTable.Values.ToArray());

            // Arrange
            hashTable.Add("Peter", 12.5);
            hashTable.Add("Maria", 99.9);
            hashTable["Peter"] = 123.45;

            // Act
            IEnumerable<double> values = hashTable.Values;

            // Assert
            double[] expectedValues = { 99.9, 123.45 };
            CollectionAssert.AreEquivalent(expectedValues, values.ToArray());
        }
    }
}
