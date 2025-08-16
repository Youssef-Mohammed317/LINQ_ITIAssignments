using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_of_Day1
{
    internal static class ExtentionMethods
    {
        public static int Reverse(this int number)
        {
            int reversed = 0;
            while (number > 0)
            {
                int digit = number % 10;
                reversed = reversed * 10 + digit;
                number /= 10;
            }
            return reversed;
        }
        public static int NoOfDigit(this int number)
        {
            //if (number == 0) return 1; // Special case for zero
            //int count = 0;
            //while (number > 0)
            //{
            //    count++;
            //    number /= 10;
            //}
            //return count;

            return number.ToString().Length;
        }

        public static string Trim(this string str)
        {
            return str.TrimStart().TrimEnd();
        }

        public static T? Max<T>(this IEnumerable<T> source) where T : IComparable<T>
        {
            T? max = default(T);

            foreach (var item in source)
            {
                if (max == null || item.CompareTo(max) > 0)
                {
                    max = item;
                }
            }

            return max;
        }
    }
}
