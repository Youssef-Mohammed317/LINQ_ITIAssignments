
using System.Reflection;

namespace Assignment_of_Day02
{
    internal class Program
    {
        static public void FindBooksSorted(string AuthorName,string storingMethod,string storingWay)
        {
            PropertyInfo? prop = typeof(Book).GetProperty(char.ToUpper(storingMethod[0]) + storingMethod.Substring(1));

            if(prop == null)
            {
                prop = typeof(Book).GetProperty("Price");
            }

            var query = SampleData.Books
                    .Where(b => b.Authors.Where(a => a.FirstName.ToLower() == AuthorName.ToLower() || a.LastName.ToLower() == AuthorName.ToLower()).Any());



            if (storingWay.ToLower().Contains("asc"))
            {
                query = query.OrderBy(b => prop?.GetValue(b));
            }
            else if (storingWay.ToLower().Contains("desc"))
            {
                query = query.OrderByDescending(b => prop?.GetValue(b));
            }

            foreach (var b in query)
            {
                Console.WriteLine($"Title:{b.Title}");
                foreach (var a in b.Authors)
                {
                    Console.WriteLine($"Authors:{a.FirstName} {a.LastName}");
                }
                Console.WriteLine(prop?.GetValue(b) ?? "NoValue");
            }

        }
        static void Main(string[] args)
        {

            #region Q1:Display book title and its ISBN.

            //var query = SampleData.Books.Select(book => new { book.Title, book.Isbn });

            //foreach(var item in query)
            //{
            //    Console.WriteLine($"Title: {item.Title} \t ISBN:{item.Isbn}");
            //}

            #endregion

            #region Q2:Display the first 3 books with price more than 25.

            //var query = SampleData.Books.Where(b => b.Price > 25).Take(3);

            //foreach (var item in query)
            //{
            //    Console.WriteLine($"Title: {item.Title} \t Price:{item.Price}");
            //}

            #endregion

            #region Q3:Display Book title along with its publisher name. (Using 2 methods).

            // method 1
            //var query = SampleData.Books.Select(b => new { b.Title, Publisher = b.Publisher.Name });

            // method 2
            //var query =
            //    from b in SampleData.Books
            //    select new { b.Title, Publisher = b.Publisher.Name };

            //foreach (var item in query)
            //{
            //    Console.WriteLine($"Title: {item.Title} \t Publisher:{item.Publisher}");
            //}

            #endregion

            #region Q4:Find the number of books which cost more than 20.

            //var query = SampleData.Books.Where(b => b.Price > 20).Count();
            //var query = SampleData.Books.Count(b => b.Price > 20);

            //Console.WriteLine($"Number of Books:{query}");

            #endregion

            #region Q5:Display book title, price and subject name sorted by its subject name ascending and by its price descending.

            //var query = SampleData.Books.Select(b => new { b.Title, b.Price, Subject = b.Subject.Name })
            //    .OrderBy(b => b.Subject).ThenByDescending(b => b.Price);

            //foreach (var item in query)
            //{
            //    Console.WriteLine($"Title:{item.Title} \t Price:{item.Price} \t Subject:{item.Subject}");
            //}

            #endregion

            #region Q6:Display All subjects with books related to this subject. (Using 2 methods).

            // method 1
            //var query =
            //    from book in SampleData.Books
            //    group book by book.Subject.Name;

            //foreach(var item in query)
            //{
            //    Console.WriteLine($"Subject:{item.Key}");
            //    foreach(var book in item)
            //    {
            //        Console.WriteLine(book);
            //    }
            //    Console.WriteLine("--------------");
            //}

            // method 2
            //var query =
            //    from book in SampleData.Books
            //    group book by book.Subject.Name into g
            //    select new { Subject = g.Key, Books = g };

            //foreach (var item in query)
            //{
            //    Console.WriteLine($"Subject:{item.Subject}");
            //    foreach (var book in item.Books)
            //    {
            //        Console.WriteLine(book);
            //    }
            //    Console.WriteLine("--------------");
            //}

            #endregion

            #region Q7:Try to display book title & price (from book objects) returned from GetBooks Function.

            //var query = SampleData.GetBooks().Cast<Book>().Select(b => new { b.Title, b.Price });

            //var query =
            //    from Book b in SampleData.GetBooks()
            //    select new { b.Title, b.Price };

            //foreach (var item in query)
            //{
            //    Console.WriteLine($"Title: {item.Title} \t Price:{item.Price}");
            //}

            #endregion

            #region Q8:Display books grouped by publisher & Subject.

            //var query =
            //    from book in SampleData.Books
            //    group book by book.Subject.Name into subGroup
            //    from PuplisherGroup in
            //    from book in subGroup
            //    group book by book.Publisher.Name
            //    group PuplisherGroup by subGroup.Key;

            //foreach (var item in query)
            //{
            //    Console.WriteLine($"Subject:{item.Key}");

            //    foreach (var itm in item)
            //    {
            //        Console.WriteLine($"Publisher:{itm.Key}");

            //        foreach(var book in itm)
            //        {
            //            Console.WriteLine($"Title:{book.Title} \t Subject:{book.Subject.Name} \t Publisher:{book.Publisher.Name}");
            //        }
            //        Console.WriteLine("*************");
            //    }
            //    Console.WriteLine("---------------------------");
            //}

            //var query =
            //    SampleData.Books.GroupBy(b => b.Subject.Name)
            //    .Select(subGroup => new
            //    {
            //        subGroup.Key,
            //        PuplisherGroup = subGroup.GroupBy(b => b.Publisher.Name)
            //    });

            //foreach (var item in query)
            //{
            //    Console.WriteLine($"Subject:{item.Key}");

            //    foreach (var itm in item.PuplisherGroup)
            //    {
            //        Console.WriteLine($"Publisher:{itm.Key}");

            //        foreach (var book in itm)
            //        {
            //            Console.WriteLine($"Title:{book.Title} \t Subject:{book.Subject.Name} \t Publisher:{book.Publisher.Name}");
            //        }
            //        Console.WriteLine("*************");
            //    }
            //    Console.WriteLine("---------------------------");
            //}

            #endregion

            #region Bouns

            //Console.WriteLine("Authors:");
            //foreach(var auth in SampleData.Authors)
            //{
            //    Console.Write($"\t{auth.FirstName} {auth.LastName}");
            //}

            //Console.WriteLine();

            //PropertyInfo[] props = typeof(Book).GetProperties();
            //Console.WriteLine("Properties of Book class That you can sort by it(ascending or descending):");
            //foreach (var prop in props)
            //{
            //    Console.Write($"\t{prop.Name}");
            //}

            //Console.WriteLine("\n----------------------------------");
            //Console.Write("Enter The Name of Author: ");
            //string AuthorName = Console.ReadLine() ?? SampleData.Authors.First().FirstName;
            //Console.Write("Enter The Method of Sorting: ");
            //string storingMethod = Console.ReadLine() ?? "Price";
            //Console.Write("Enter The Order Of Sorting (asc or desc): ");
            //string storingWay = Console.ReadLine() ?? "";
            //Console.WriteLine("\n----------------------------------");
            //FindBooksSorted(AuthorName, storingMethod, storingWay);

            #endregion
        }
    }
}
