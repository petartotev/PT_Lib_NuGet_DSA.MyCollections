using System.Collections;
using System.Collections.Generic;

namespace PetarTotev.Net.DSA.MyCollections
{
    /// <summary>
    /// MyDictionary-TKey, TValue- is a hash table based collection.
    /// </summary>
    /// <typeparam name="TKey">Any generic type TKey.</typeparam>
    /// <typeparam name="TValue">Any generic type TValue.</typeparam>
    public class MyDictionary<TKey, TValue> : IEnumerable<MyKeyValuePair<TKey, TValue>>
    {
        private MyHashTable<TKey, TValue> hashTable;

        /// <summary>
        /// MyDictionary is a constructor that creates a new MyDictionary and sets this.hashTable to a new MyHashTable-TKey, TValue-.
        /// </summary>
        public MyDictionary()
        {
            this.hashTable = new MyHashTable<TKey, TValue>();
        }

        /// <summary>
        /// MyDictionary is a constructor that creates a new MyDictionary and sets this.hashTable to a new MyHashTable of TKey, TValue.
        /// Then it writes down all the elements contained in the 'collection' constructor parameter into this.hashTable.
        /// </summary>
        public MyDictionary(IEnumerable<MyKeyValuePair<TKey, TValue>> collection)
        {
            this.hashTable = new MyHashTable<TKey, TValue>();

            foreach (var item in collection)
            {
                this.hashTable.AddOrReplace(item.Key, item.Value);
            }
        }

        /// <summary>
        /// Count is a property that returns the current count of all elements within the collection.
        /// </summary>
        public int Count
        {
            get
            {
                return this.hashTable.Count;
            }
        }

        /// <summary>
        /// Capacity is a property that returns this.hashTable array capacity.
        /// </summary>
        public int Capacity
        {
            get
            {
                return this.hashTable.Capacity;
            }
        }

        /// <summary>
        /// [TKey key] returns a value contained in this TKey.
        /// </summary>
        /// <param name="key">Any generic type TKey.</param>
        /// <returns>A TValue that is a part of the KeyValuePair with a key equal to TKey key.</returns>
        public TValue this[TKey key]
        {
            get
            {
                return this.hashTable.Find(key).Value;
            }
            set
            {
                this.hashTable.AddOrReplace(key, value);
            }
        }

        /// <summary>
        /// Keys is a property that returns an IEnumerable collection of all the keys within the collection. 
        /// </summary>
        public IEnumerable<TKey> Keys
        {
            get
            {
                return this.hashTable.Keys;
            }
        }

        /// <summary>
        /// Values is a property that returns an IEnumerable collection of all the values within the collection. 
        /// </summary>
        public IEnumerable<TValue> Values
        {
            get
            {
                return this.hashTable.Values;
            }
        }

        /// <summary>
        /// Add is a void method that inserts a new key-value pair within this.hashTable base collection.
        /// Complexity: O(1).
        /// </summary>
        /// <param name="key">Any generic type TKey.</param>
        /// <param name="value">Any generic type TValue.</param>
        public void Add(TKey key, TValue value)
        {
            this.hashTable.Add(key, value);
        }

        /// <summary>
        /// Clear is a void method that resets the hash table that is the base of the MyDictionary.
        /// </summary>
        public void Clear()
        {
            this.hashTable.Clear();
        }

        /// <summary>
        /// ContainsKey is a method that receives a TKey element as a parameter and evaluates if the collection contains such a key.
        /// Complexity: O(1).
        /// </summary>
        /// <param name="key">Any generic type TKey.</param>
        /// <returns>A boolean that reveals if the element is present as a key in the dictionary or not.</returns>
        public bool ContainsKey(TKey key)
        {
            return this.hashTable.ContainsKey(key);
        }

        /// <summary>
        /// ContainsValue is a method that receives a TValue element as a parameter and evaluates 
        /// if the collection contains such an element.
        /// Complexity: O(n).
        /// </summary>
        /// <param name="value">Any generic type TValue.</param>
        /// <returns>A boolean that reveals if the element is present as a value in the dictionary or not.</returns>
        public bool ContainsValue(TValue value)
        {
            return this.hashTable.ContainsValue(value);
        }

        /// <summary>
        /// Remove is a method that returns bool if an element TKey key is contained in the collection and is successfully removed from it.
        /// Complexity: O(1).
        /// </summary>
        /// <param name="key">Any generic type TKey.</param>
        /// <returns>A boolean that evaluates if such TKey key is found in the collection and is removed successfully.</returns>
        public bool Remove(TKey key)
        {
            return this.hashTable.Remove(key);
        }

        /// <summary>
        /// TryGetValue is a method that returns true if such TKey key is found and sets the TValue value as equal to the TKey key value.
        /// Complexity: O(1).
        /// </summary>
        /// <param name="key">Any generic type TKey.</param>
        /// <param name="value">Any generic type TValue.</param>
        /// <returns>True if such TKey key is found and the TValue value is set to TKey key's value. False if such key is not found and the TValue value is set to its default.</returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            return this.hashTable.TryGetValue(key, out value);
        }

        /// <summary>
        /// GetEnumerator is an imperative method for all classes implementing the IEnumerable interface.
        /// Complexity: O(n).
        /// </summary>
        /// <returns>Yield returns the hashTable base collection.</returns>
        public IEnumerator<MyKeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return this.hashTable.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
