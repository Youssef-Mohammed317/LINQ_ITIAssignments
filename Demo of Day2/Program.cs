namespace Demo_of_Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region LINQ In Action

            //IEnumerable<Course> courses = SampleData.Courses.Filter(c => c.Hours > 30);

            //foreach(Course course in courses)
            //{
            //    Console.WriteLine($"Name:{course.Name} \t Hours:{course.Hours} \t Dept:{course.Department.Name}");
            //}


            //var names = SampleData.Courses.Filter(c => c.Hours > 30).Choose(c => c.Name);

            //foreach(var name in names)
            //{
            //    Console.WriteLine($"Name:{name}");
            //}

            //var query = SampleData.Courses.Choose(c => new { c.Name, c.Hours }); // here the mean reason of var you don't now the data type of anonyms returned object
            //foreach(var item in query)
            //{
            //    Console.WriteLine($"Name:{item.Name} \t Hours:{item.Hours}");
            //}

            #endregion

            #region PipeLine

            //var query = SampleData.Courses
            //    .Where(c => c.Hours > 30)
            //    .Select(c => new { c.Name, c.Hours });

            //var query = SampleData.Courses
            //    .Select(c => new { c.Name, c.Hours })
            //    .Where(c => c.Hours > 30); // you can't add condition on what you don't selected

            //foreach (var item in query)
            //{
            //    Console.WriteLine($"Name:{item.Name} \t Hours:{item.Hours}");
            //}

            #endregion

            #region Query Operator & Query Exepression & Take & Skip

            //var query = SampleData.Courses
            //    .Where(c => c.Hours > 30)
            //    .Select(c => new { c.Name, c.Hours });
            //.Take(2); // take the first 2 result
            //.Skip(2); // skip the first 2 result

            //var query =
            //    (from crs in SampleData.Courses
            //     where crs.Hours > 30
            //     select crs);
            //.Take(2);
            //.Skip(2); // only way to add these condtions to query exepressions

            //var query = SampleData.Courses
            //    .TakeWhile(c => c.Hours > 30); // take until the condition is not valid then stop

            //var query = SampleData.Courses
            //    .SkipWhile(c => c.Hours > 30);
            //foreach (var item in query)
            //{
            //    Console.WriteLine($"Name:{item.Name} \t Hours:{item.Hours}");
            //}
            #endregion

            #region Aggregate Funcitons

            //int count = SampleData.Courses.Count();
            //int count = SampleData.Courses.Count(c => c.Hours > 30);
            //int count = SampleData.Courses.Where(c => c.Hours > 30).Count();

            //int totalHours = SampleData.Courses.Where(c => c.Department.Name == "SD").Sum(c => c.Hours);

            //int totalHours =
            //    (from crs in SampleData.Courses
            //    where crs.Department.Name == "SD"
            //    select crs.Hours).Sum();

            //Course course = SampleData.Courses.Max(); // threw an exceptions

            //int maxHours = SampleData.Courses.Max(c => c.Hours);

            #endregion

            #region Join

            //var query =
            //    from crs in SampleData.Courses
            //    from dept in SampleData.Departments
            //    where crs.Department.Name == dept.Name
            //    select new { CrsName = crs.Name, DeptName = dept.Name };

            //var query =
            //    from crs in SampleData.Courses
            //    join dept in SampleData.Departments
            //    on crs.Department.Name equals dept.Name
            //    select new { CrsName = crs.Name, DeptName = dept.Name };

            #endregion

            #region First & Last

            Course? crs = SampleData.Courses.Where(c => c.Hours == 30)
                //.First(); // but can give error if there is no course with 30 hours
                //.FirstOrDefault();  // can return default
                //.Last();
                .LastOrDefault();

            #endregion

            #region Sub Query

            //var query =
            //    from sub in SampleData.Subjects
            //    select new
            //    {
            //        SubName = sub.Name,
            //        Courses = from crs in SampleData.Courses
            //                  where crs.Subject.Name == sub.Name
            //                  select crs
            //    };

            //foreach (var sub in query)
            //{
            //    Console.WriteLine($"Subject: {sub.SubName} \t Total Hours:{sub.Courses.Sum(c => c.Hours)}");
            //    foreach (var cr in sub.Courses)
            //    {
            //        Console.WriteLine($"Course:{cr.Name} \t Hours:{cr.Hours}");
            //    }
            //    Console.WriteLine("--------------");
            //}

            #endregion

            #region Order by

            //var query = SampleData.Courses
            //    .Where(c => c.Hours > 30)
            //    .Select(c => new { c.Name, c.Hours })
            //    //.OrderBy(c => c.Hours); // hours ascending
            //    .OrderByDescending(c => c.Hours); // hours descending
            //var query =
            //    from c in SampleData.Courses
            //    where c.Hours > 30
            //    orderby c.Hours
            //    select c;

            // order by hours desc then by name asc
            //var query = SampleData.Courses
            //    .Where(c => c.Hours > 30)
            //    .Select(c => new { c.Name, c.Hours })
            //    .OrderByDescending(c => c.Hours)
            //    .ThenBy(c => c.Name); // the right sol
            //.OrderBy(c => c.Name); // invalid sol
            //var query =
            //    from c in SampleData.Courses
            //    where c.Hours > 30
            //    orderby c.Hours descending, c.Name ascending
            //    select c;

            #endregion

            #region Eager Execution

            //var query = SampleData.Courses
            //    .Where(c => c.Hours > 30)
            //    .Select(c => new { c.Hours, c.Name })
            //    .ToList();
            //    //.ToArray();

            #endregion

            #region Group By

            //var query =
            //    from c in SampleData.Courses
            //    group c by c.Subject.Name;

            //foreach( var c in query)
            //{
            //    //Console.WriteLine($"Key:{c.Key} \t Total Hours:{c.Sum(c => c.Hours)}");

            //    foreach(var x in c)
            //    {
            //        Console.WriteLine($"Name:{x.Name} \t Hours:{x.Hours}");
            //    }
            //    Console.WriteLine("-------------------");
            //}

            //var query =
            //    from c in SampleData.Courses
            //    group c by c.Subject.Name into g
            //    where g.Sum(c => c.Hours) > 50
            //    select new { SubName = g.Key, Courses = g, TotalHours = g.Sum(c => c.Hours) };

            //var query =
            //    from c in SampleData.Courses
            //    group c by c.Subject.Name into g
            //    let totalHours = g.Sum(c => c.Hours)
            //    where totalHours > 50
            //    select new { SubName = g.Key, Courses = g, TotalHours = totalHours };

            //foreach ( var c in query)
            //{
            //    Console.WriteLine($"Key:{c.SubName} \t Total Hours:{c.TotalHours}");

            //    foreach(var x in c.Courses)
            //    {
            //        Console.WriteLine($"Name:{x.Name} \t Hours:{x.Hours}");
            //    }
            //    Console.WriteLine("-------------------");
            //}

            #endregion

            #region Casting

            // method 1
            //var query = SampleData.Courses.Cast<Course>().ToList();

            //method 2
            var query =
                from Course c in SampleData.Courses
                select c;

            foreach (var course in query)
            {
                Console.WriteLine(course.Hours);
            }

            #endregion
        }
    }
}
