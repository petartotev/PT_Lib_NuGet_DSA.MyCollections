using System;
using System.Collections.Generic;
using System.Text;

namespace PetarTotev.Net.DSA.MyCollections
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyNodeAVL<T> where T : IComparable<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public T Value;

        /// <summary>
        /// 
        /// </summary>
        public MyNodeAVL<T> Left;

        /// <summary>
        /// 
        /// </summary>
        public MyNodeAVL<T> Right;

        /// <summary>
        /// 
        /// </summary>
        public int Height;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public MyNodeAVL(T value)
        {
            this.Value = value;
            this.Height = 1;
        }
    }
}
