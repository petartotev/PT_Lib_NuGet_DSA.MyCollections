using System;

namespace PetarTotev.Net.DSA.MyCollections
{
    /// <summary>
    /// MyKeyValuePair of TKey, TValue is a pair that consists of a Key and a Value. 
    /// The class overrides Equals, GetHashCode and ToString methods.
    /// </summary>
    /// <typeparam name="TKey">Any generic type TKey.</typeparam>
    /// <typeparam name="TValue">Any generic type TValue.</typeparam>
    public class MyKeyValuePair<TKey, TValue>
    {
        /// <summary>
        /// MyKeyValuePair is a constructor that creates a new instance of MyKeyValuePair.
        /// It sets the Key property to the Tkey key parameter and the Value property to the TValue value parameter.
        /// </summary>
        /// <param name="key">Any generic TKey.</param>
        /// <param name="value">Any generic TValue</param>
        public MyKeyValuePair(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }

        /// <summary>
        /// Key is a property that holds the key of this MyKeyValuePair.
        /// </summary>
        public TKey Key { get; set; }

        /// <summary>
        /// Value is a property that holds the value of this MyKeyValuePair.
        /// </summary>
        public TValue Value { get; set; }

        /// <summary>
        /// Equals() is a method overriden to return a bool.
        /// The bool would evaluate if the obj parameter, cast to MyKeyValuePair has its Key equal to this.Key and its Value equal to this.Value.
        /// </summary>
        /// <param name="obj">An object to be cast to MyKeyValuePair and to be evaluated to this MyKeyValuePair.</param>
        /// <returns>A boolean to show if the (MyKeyValuePair)obj key and value and this MyKeyValuePair key and value are equal.</returns>
        public override bool Equals(object obj)
        {
            MyKeyValuePair<TKey, TValue> external = (MyKeyValuePair<TKey, TValue>)obj;

            bool areElementsEqual = Object.Equals(this.Key, external.Key) && Object.Equals(this.Value, external.Value);

            return areElementsEqual;
        }

        /// <summary>
        /// GetHashCode is a method that returns an integer which combines the hash codes of this.Key and this.Value in a private method. 
        /// </summary>
        /// <returns>A new integer that is produced by a private method as an equation of the hash codes of this.Key and this.Value.</returns>
        public override int GetHashCode()
        {
            return this.CombineHashCodes(this.Key.GetHashCode(), this.Value.GetHashCode());
        }

        /// <summary>
        /// ToString() is a method overriden to return a string representing the Key and Value property in brackets, separated by comma.
        /// </summary>
        /// <returns>A string representing the Key and Value property in brackets, separated by comma.</returns>
        public override string ToString()
        {
            return $"<{this.Key},{this.Value}>";
        }

        private int CombineHashCodes(int v1, int v2)
        {
            return ((v1 << 5) + v1) ^ v2;
        }
    }
}
