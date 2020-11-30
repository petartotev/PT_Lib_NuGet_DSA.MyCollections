using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PetarTotev.Net.DSA.MyCollections
{
    /// <summary>
    /// MyHashSet of TKey is a hash-table-based collection that holds only TKey. Similar to MyDictionary, but it holds TKey, Tkey instead of TKey, TValue pairs.
    /// </summary>
    /// <typeparam name="TKey">Any generic type TKey.</typeparam>
    public class MyHashSet<TKey> : IEnumerable<TKey>
    {
        private MyHashTable<TKey, TKey> hashTable;

        /// <summary>
        /// MyHashSet is a constructor that receives no parameters and sets this.hashTable to a new MyHashTable collection of TKey and TKey.
        /// </summary>
        public MyHashSet()
        {
            this.hashTable = new MyHashTable<TKey, TKey>();
        }

        /// <summary>
        /// MyHashSet is a constructor that receives no parameters and sets this.hashTable to a new MyHashTable collection of TKey and TKey.
        /// Then it saves all elements of the 'collection' constructor parameter into this.hashTable collection.
        /// </summary>
        /// <param name="collection">IEnumerable of MyKeyValuePairs TKey-TKey to be written in the newly created MyHashSet's private this.hashTable base.</param>
        public MyHashSet(IEnumerable<MyKeyValuePair<TKey, TKey>> collection)
        {
            this.hashTable = new MyHashTable<TKey, TKey>();

            foreach (var item in collection)
            {
                this.hashTable.AddOrReplace(item.Key, item.Key);
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
        /// Add is a void method that receives a TKey key and saves it into the private this.hashTable base collection.
        /// Complexity: O(1).
        /// </summary>
        /// <param name="key">Any generic TKey.</param>
        public void Add(TKey key)
        {
            this.hashTable.AddOrReplace(key, key);
        }

        /// <summary>
        /// Remove is a method that receives a TKey key and removes it from the collection.
        /// If such a TKey key is found and removed from the collection returns true, otherwise false.
        /// Complexity: O(1).
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(TKey key)
        {
            return this.hashTable.Remove(key);
        }

        /// <summary>
        /// Clear is a void method that resets the hash table which is the base of the MyHashSet.
        /// </summary>
        public void Clear()
        {
            this.hashTable.Clear();
        }

        /// <summary>
        /// Contains is a method that receives a T(Key) element as a parameter.
        /// Then it evaluates if the collection contains (a key of) such an element.
        /// Complexity: O(1).
        /// </summary>
        /// <param name="key">Any generic type TKey.</param>
        /// <returns>A boolean that reveals if the element is present (as a key) in the collection or not.</returns>
        public bool Contains(TKey key)
        {
            return this.hashTable.ContainsKey(key);
        }

        /// <summary>
        /// Except is a method that takes only the unique elements of this collection which are not present in the outer collection.
        /// </summary>
        /// <param name="outer">The outer collection that should be compared with this.</param>
        /// <returns>A new collection that consists of unique elements contained in this collection but not in the outer one.</returns>
        public MyHashSet<TKey> Except(MyHashSet<TKey> outer)
        {
            return new MyHashSet<TKey>(this.hashTable.Where(x => !outer.Contains(x.Key)));
        }

        /// <summary>
        /// IntersectWith is a method that intersects this collection with the outer collection that comes as a method parameter.
        /// </summary>
        /// <param name="outer">The outer collection that should be intersected with this.</param>
        /// <returns>The new collection that is result of the intersection of the two collections.</returns>
        public MyHashSet<TKey> IntersectWith(MyHashSet<TKey> outer)
        {
            return new MyHashSet<TKey>(this.hashTable.Where(x => outer.Contains(x.Key)));
        }

        /// <summary>
        /// SymmetricExcept is a method that takes only the unique elements from both collection.
        /// </summary>
        /// <param name="outer">The outer collection that should be compared with this one.</param>
        /// <returns>A new collection that consists of only unique elements that only one of the two collections contains.</returns>
        public MyHashSet<TKey> SymmetricExcept(MyHashSet<TKey> outer)
        {
            return this.UnionWith(outer).Except(this.IntersectWith(outer));
        }

        /// <summary>
        /// UnionWith is a method that unites this collection with the outer collection that comes as a method parameter.
        /// </summary>
        /// <param name="outer">The outer collection that should be united with this.</param>
        /// <returns>The new collection that is result of the unification of the two collections.</returns>
        public MyHashSet<TKey> UnionWith(MyHashSet<TKey> outer)
        {
            return new MyHashSet<TKey>(outer.hashTable.Concat(this.hashTable).Distinct());
        }

        /// <summary>
        /// GetEnumerator is an imperative method for all classes implementing the IEnumerable interface.
        /// Complexity: O(n).
        /// </summary>
        /// <returns>Yield returns the TKey keys of the hashTable base collection.</returns>
        public IEnumerator<TKey> GetEnumerator()
        {
            foreach (var key in this.hashTable.Keys)
            {
                yield return key;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
