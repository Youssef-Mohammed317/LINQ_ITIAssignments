using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_of_Day2
{
    internal static class Extensoins
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            foreach(var i in list)
            {
                // yield ko routine deferd execution
                if(predicate(i)) yield return i;
            }
        }

        public static IEnumerable<TResult> Choose<TSource,TResult>(this IEnumerable<TSource> source, Func<TSource,TResult> chooser)
        {
            // method to convert choose to egar execution
            //List<TSource> list = new List<TSource>();
            //foreach(var x in source)
            //{
            //    list.Add(x);
            //}

            foreach(var i in source)
            {
                yield return chooser(i);
            }
        }
    }
}
