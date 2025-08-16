namespace Demo_Of_Day1
{
    internal class Program
    {

        static public List<T> Filter<T>(List<T> list,Predicate<T> predicate)
        {
            List<T> result = new List<T>();
            foreach (var item in list)
            {
                if(predicate.Invoke(item)) 
                    result.Add(item);
            }
            return result;
        }

        static void Main(string[] args)
        {
            #region Implicitly typed lacal variable (var) 
            //when you don't want to specify the type at the left side

            //var number = 10; // variable type is inferred as int
            //var price = 19.99; // variable type is inferred as double
            //var num = 5.5f; // variable type is inferred as float
            //var name = "John"; // variable type is inferred as string
            //var isActive = true; // variable type is inferred as bool
            //var numbers = new[] { 1, 2, 3, 4, 5 }; // variable type is inferred as int[]

            //number = "Hello"; // Error: Cannot implicitly convert type 'string' to 'int'

            //Dictionary<string,List<Employee>> employees = new Dictionary<string, List<Employee>>();
            //var employees = new Dictionary<string, List<Employee>>();

            #endregion

            #region Anonymous Objects 

            // you don't know the type at compile time
            //var obj = new { Name = "John", Age = 30 }; // Anonymous type with properties Name and Age
            //var e = new { Name = "Jone", Age = 25 };

            //obj = e; // This is valid because both obj and e are of the same anonymous type

            //var ee = new { Name = "Jone", Age = 25, Address = "123 Main St" }; // This is a different anonymous type

            //// obj = ee; // Error: Cannot implicitly convert type 'anonymous type with 3 properties' to 'anonymous type with 2 properties'

            #endregion

            #region Extension Methods

            //var list = new List<int> { 1, 2, -3, 4, 5, 6, -7, 8, 9 };

            //Filter(list,c => c > 0); // old way

            //list.Filter(c => c > 0); // new way

            //string str = "Hello World!";
            //string msg = str.RemoveVowels();
            //Console.WriteLine(msg);

            //string str = "Hello World!";

            //string msg = str.RemoveVowels();

            //char middleChar = msg.GetMiddleCharacter();

            //middleChar.PrintMe(); // This will print the middle character of the string without vowels

            //str.RemoveVowels().GetMiddleCharacter().PrintMe(); // Chaining methods

            #endregion

            #region Ko Routine vs Subroutine

            //IEnumerable<int> list = Extensions.Sequence();

            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}

            //var list = new List<int> { 1, 2, -3, 4, 5, 6, -7, 8, 9 };

            //IEnumerable<int> newList = list.Filter(c => c > 0);

            //// new list is an iterator, it will not execute until you iterate over it

            //foreach (var item in newList)
            //{
            //    Console.WriteLine(item);
            //}


            //var list = new List<int> { 1, 2, -3, 4, 5, 6, -7, 8, 9 };

            //IEnumerable<int> newList = list.Filter(c => c % 2 == 0);

            //foreach (var item in newList)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("---------------------");

            //list[0] = 10; // subroutine no change in the newList 
            //              // ko routine change in the newList

            //foreach (var item in newList)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion
        }
    }
}
