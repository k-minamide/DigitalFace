using System;
using System.Collections;
using System.Collections.Generic;

namespace DigitalFace.Processes
{
    public abstract class ExecuteListBase<T> : ExecuteBase<IList<T>>, IList<T>
    {
        public ExecuteListBase() { base.Setting = new List<T>(); }

        public ExecuteListBase(T setting) { base.Setting = new List<T>() { setting }; }

        public ExecuteListBase(IEnumerable<T> settings) { base.Setting = new List<T>(settings); }

        #region public inheritance

        public int Count { get { return ((IList<T>)base.Setting).Count; } }

        public T this[int index]
        {
            get { return ((IList<T>)base.Setting)[index]; }
            set { ((IList<T>)base.Setting)[index] = value; }
        }

        public int IndexOf(T item) { return ((IList<T>)base.Setting).IndexOf(item); }

        public void Insert(int index, T item) { ((IList<T>)base.Setting).Insert(index, item); }

        public void RemoveAt(int index) { ((IList<T>)base.Setting).RemoveAt(index); }

        public void Add(T item) { ((IList<T>)base.Setting).Add(item); }

        public void Clear() { ((IList<T>)base.Setting).Clear(); }

        public bool Contains(T item) { return ((IList<T>)base.Setting).Contains(item); }

        public bool Remove(T item) { return ((IList<T>)base.Setting).Remove(item); }

        #endregion

        #region ICollection<T>

        void ICollection<T>.CopyTo(T[] array, int arrayIndex) { ((ICollection<T>)base.Setting).CopyTo(array, arrayIndex); }

        bool ICollection<T>.IsReadOnly { get { return ((ICollection<T>)base.Setting).IsReadOnly; } }

        #endregion

        #region IEnumerable<T>

        IEnumerator<T> IEnumerable<T>.GetEnumerator() { return ((IEnumerable<T>)base.Setting).GetEnumerator(); }

        #endregion

        #region IEnumerable

        IEnumerator IEnumerable.GetEnumerator() { return ((IEnumerable)base.Setting).GetEnumerator(); }

        #endregion
    }
}
