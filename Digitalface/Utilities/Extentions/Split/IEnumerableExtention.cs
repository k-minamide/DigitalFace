using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Digitalface.Utilities.Extentions.Split
{
    public static class IEnumerableExtention
    {
        public static int Count(this IEnumerable source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int ret = 0;

            if (source is ICollection)
            {
                ret = ((ICollection)source).Count;
            }
            else
            {
                IEnumerator enumerator = source.GetEnumerator();
                enumerator.Reset();
                while(enumerator.MoveNext())
                {
                    ret++;
                }
            }

            return ret;
        }

        public static ICollection ToCollection(this System.Collections.IEnumerable source)
        {
            ICollection ret = null;

            if (source != null)
            {
                if (source is ICollection)
                {
                    ret = (ICollection)source;
                }
                else
                {
                    int index = 0;
                    object[] array = new object[source.Count()];
                    foreach (var element in source)
                    {
                        array[index] = element;
                        index++;
                    }

                    ret = array;
                }
            }

            return ret;
        }


        public static ICollection<T> ToCollection<T>(this IEnumerable<T> source)
        {
            ICollection<T> ret = null;

            if (source != null)
            {
                if (source is ICollection<T>)
                {
                    ret = (ICollection<T>)source;
                }
                else
                {
                    ret = source.ToArray();
                }
            }

            return ret;
        }

        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, T separator)
        {
            List<IEnumerable<T>> ret = new List<IEnumerable<T>>();

            List<T> splitElement = null;
            if (source != null)
            {
                splitElement = new List<T>();
                foreach (var sourceElement in source)
                {
                    if (separator == null && sourceElement == null
                        || separator != null && separator.Equals(sourceElement))
                    {
                        ret.Add(splitElement);
                        splitElement = new List<T>();
                    }
                    else
                    {
                        splitElement.Add(sourceElement);
                    }
                }
            }
            ret.Add(splitElement);

            return ret;
        }

        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, IEnumerable<T> separator)
        {
            List<IEnumerable<T>> ret = new List<IEnumerable<T>>();

            List<T> splitElement = null;
            List<T> splitSeparatorElement = null;
            if (source != null)
            {
                if (separator != null)
                {
                    splitElement = new List<T>();
                    splitSeparatorElement = new List<T>();

                    var sourceEnumerator = source.GetEnumerator();
                    T sourceElement = default(T);
                    while (sourceEnumerator.MoveNext())
                    {
                        sourceElement = sourceEnumerator.Current;

                        foreach(var separatorElement in separator)
                        {
                            if ((splitElement == null && sourceElement == null)
                                || (splitElement != null && splitElement.Equals(sourceElement)))
                            {
                                splitSeparatorElement.Add(separatorElement);

                                ret.Add(splitElement);
                                splitElement = new List<T>();
                            }
                            else
                            {
                                splitElement.Add(sourceElement);
                            }
                        }


                    }

                    foreach (var sourceElement in source)
                    {
                        if ((separator == null && sourceElement == null)
                            || (separator != null && separator.Equals(sourceElement)))
                        {
                            ret.Add(splitElement);
                            splitElement = new List<T>();
                        }
                        else
                        {
                            splitElement.Add(sourceElement);
                        }
                    }
                }
                else
                {
                    splitElement = new List<T>(source);
                }
            }
            ret.Add(splitElement);

            return ret;
        }
    }
}
