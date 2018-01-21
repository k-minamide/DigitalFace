using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DigitalFace.Data
{
    public class NullKeyDictionary<TKey, TValue, TDictionary> : IDictionary<TKey, TValue>
        where TDictionary : IDictionary<TKey, TValue>, new()
    {
        private TDictionary dictionary = new TDictionary();

        private bool hasNullKey = false;

        private KeyValuePair<TKey, TValue> nullKeyValuePair = default(KeyValuePair<TKey, TValue>);

        private void SetValue(TKey key, TValue value)
        {
            if (key == null)
            {
                if (this.IsReadOnly == true)
                { throw new NotSupportedException(); }
                else
                {
                    this.hasNullKey = true;
                    this.nullKeyValuePair = new KeyValuePair<TKey, TValue>(key, value);
                }
            }
            else if (this.dictionary.ContainsKey(key))
            { this.dictionary[key] = value; }
            else
            { this.dictionary.Add(key, value); }
        }

        private void NullKeyClear()
        {
            this.hasNullKey = false;
            this.nullKeyValuePair = default(KeyValuePair<TKey, TValue>);
        }

        public TValue this[TKey key]
        {
            get
            {
                TValue value;

                if (key == null)
                {
                    if (this.hasNullKey == true)
                    { value = this.nullKeyValuePair.Value; }
                    else
                    { throw new ArgumentNullException(nameof(key)); }
                }
                else
                { value = this.dictionary[key]; }

                return value;
            }
            set { this.SetValue(key, value); }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                ICollection<TKey> keys = this.dictionary.Keys;
                if (this.hasNullKey == true) { keys.Add(default(TKey)); }
                return keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                ICollection<TValue> values = this.dictionary.Values;
                if (this.hasNullKey == true) { values.Add(this.nullKeyValuePair.Value); }
                return values;
            }
        }

        public int Count
        {
            get
            {
                int count = this.dictionary.Count;
                if (this.hasNullKey == true) { count++; }
                return count;
            }
        }

        public bool IsReadOnly => this.dictionary.IsReadOnly;

        public void Add(TKey key, TValue value)
        {
            this.SetValue(key, value);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            this.SetValue(item.Key, item.Value);
        }

        public void Clear()
        {
            this.dictionary.Clear();
            this.NullKeyClear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return (item.Key == null && this.hasNullKey == true && item.Value == null ? item.Value == null : item.Value.Equals(this.nullKeyValuePair.Value)) 
                    || this.dictionary.Contains(item);
        }

        public bool ContainsKey(TKey key)
        {
            return key == null ? this.hasNullKey : this.dictionary.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null)
            { throw new ArgumentNullException(nameof(array)); }

            if (arrayIndex < 0)
            { throw new ArgumentOutOfRangeException(nameof(arrayIndex)); }

            if (array.Length > arrayIndex + this.Count)
            { throw new ArgumentException(string.Format("ソース内の要素の数 {0} から使用可能な領域よりも大きい {1} 変換先の末尾に {2} します。", "ICollection < T >", nameof(arrayIndex), nameof(array))); }

            this.dictionary.CopyTo(array, arrayIndex);
            if (this.hasNullKey == true)
            { array[arrayIndex + this.Count] = new KeyValuePair<TKey, TValue>(default(TKey), this.nullKeyValuePair.Value); }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            IEnumerator<KeyValuePair<TKey, TValue>> enumerator;

            if (this.hasNullKey == true)
            {
                List<KeyValuePair<TKey, TValue>> list = new List<KeyValuePair<TKey, TValue>>(dictionary);
                list.Add(new KeyValuePair<TKey, TValue>());
                enumerator = list.GetEnumerator();
            }
            else
            { enumerator = dictionary.GetEnumerator(); }

            return enumerator;
        }

        public bool Remove(TKey key)
        {
            bool ret = false;

            if (key == null)
            {
                this.NullKeyClear();
                ret = true;
            }
            else
            { ret = dictionary.Remove(key); }

            return ret;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            bool ret = false;

            if (item.Equals(this.nullKeyValuePair))
            {
                this.NullKeyClear();
                ret = true;
            }
            else
            { ret = dictionary.Remove(item); }

            return ret;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            bool ret = false;

            if (key == null && this.hasNullKey == true)
            {
                value = this.nullKeyValuePair.Value;
                ret = true;
            }
            else
            { ret = dictionary.TryGetValue(key, out value); }
            return ret;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
