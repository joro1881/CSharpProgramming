//Implement a set of extension methods for 
//IEnumerable<T> that implement the following
//group functions: sum, product, min, max, average.

using System;
using System.Collections.Generic;
using System.Linq;

namespace IEnumerableExtension
{
    public static class ExtensionIEnum
    {
        public static T Product<T>(this IEnumerable<T> seq)
        {
            dynamic result = 1;
            foreach (var item in seq)
            {
                result *= item;
            }
            return result;
        }

        public static T Sum<T>(this IEnumerable<T> seq)
        {
            dynamic result = 0;
            foreach (var item in seq)
            {
                result += item;
            }
            return result;
        }

        public static T Average<T>(this IEnumerable<T> seq)
        {
            dynamic result = 0;
            foreach (var item in seq)
            {
                result += item;
            }
            return result / seq.Count();
        }

        public static T Min<T>(this IEnumerable<T> seq)
        {
            dynamic min = seq.ElementAt(0);
            for (int i = 0; i < seq.Count(); i++)
            {
                if (min > seq.ElementAt(i))
                {
                    min = seq.ElementAt(i);
                }
            }
            return min;
        }

        public static T Max<T>(this IEnumerable<T> seq)
        {
            dynamic max = seq.ElementAt(0);
            for (int i = 0; i < seq.Count(); i++)
            {
                if (max < seq.ElementAt(i))
                {
                    max = seq.ElementAt(i);
                }
            }
            return max;
        }
    }
}
