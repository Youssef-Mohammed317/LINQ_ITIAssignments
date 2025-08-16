using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Of_Day1
{
    internal static class Extensions
    {
        public static IEnumerable<T> Filter<T>(this List<T> list, Predicate<T> predicate)
        {
            //List<T> result = new List<T>();
            foreach (var item in list)
            {
                if (predicate.Invoke(item))
                    //result.Add(item);
                    yield return item; // using yield return to create an iterator
            }
            //return result;
        }

        public static string RemoveVowels(this string str)
        {
            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            foreach(char c in str)
            {
                if (vowels.Contains(c))
                {
                    str = str.Replace(c.ToString(), string.Empty);
                }
            }
            return str;
        }

        public static char GetMiddleCharacter(this string str)
        {
            return str.Length % 2 == 0 
                ? str[str.Length / 2 - 1] 
                : str[str.Length / 2];
        }

        public static void PrintMe(this char c)
        {
            Console.WriteLine($"Character: {c}");
        }

        public static IEnumerable<int> Sequence()
        {
            // sub routine
            //List<int> list = new List<int> { 1, 2, 3 };
            //return list;

            // ko routine
            Console.WriteLine("Return 1...........");
            yield return 1;

            Console.WriteLine("Return 2...........");
            yield return 2;

            Console.WriteLine("Return 3...........");
            yield return 3;
        }

    }
}
