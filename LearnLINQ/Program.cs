using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;
using System.Data.SqlClient;

namespace LearnLINQ
{
    [Table (Name="customer")]
    public class Customer
    {
        [Column(IsPrimaryKey = true)]
        public int ID;
        [Column]
        public string Name;
    }

    [Table(Name = "customer")]
    public class Customer2
    {
        string _name;

        [Column(IsPrimaryKey = true)]
        public int ID;
        [Column(Storage = "_name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }

    class Program
    {
        string[] presidents = { "Washington, George", "Adams, John", "Jefferson, Thomas", "Madison, James", "Monroe, James", "Adams, John Quincy", "Jackson, Andrew", "Van Buren, Martin", "Harrison, William Henry", "Tyler, John", "Polk, James K.", "Taylor, Zachary", "Fillmore, Millard", "Pierce, Franklin", "Buchanan, James", "Lincoln, Abraham", "Johnson, Andrew", "Grant, Ulysses S.", "Hayes, Rutherford B.", "Garfield, James A.", "Arthur, Chester A.", "Cleveland, Grover", "Harrison, Benjamin", "McKinley, William", "Roosevelt, Theodore", "Taft, William Howard", "Wilson, Woodrow", "Harding, Warren G.", "Coolidge, Calvin", "Hoover, Herbert", "Roosevelt, Franklin D.", "Truman, Harry S.", "Eisenhower, Dwight D.", "Kennedy, John F.", "Johnson, Lyndon B.", "Nixon, Richard", "Ford, Gerald", "Carter, Jimmy", "Reagan, Ronald", "Bush, George H. W.", "Clinton, Bill", "Bush, George W.", "Obama, Barack" };
        static string connect = "Data Source=EL_LT_1\\SQLEXPRESS2008;Initial Catalog=General;Integrated Security=True";

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Nine();
            PressEnter();
        }

        void Nine()
        {
            var dataContext = new DataContext(connect);
            Table<Customer2> customers =
                dataContext.GetTable<Customer2>();

            IQueryable<string> query1 = from c in customers
                                        where c.Name.Contains("a")
                                        orderby c.Name.Length
                                        select c.Name.ToUpper();
            Dump(query1);

            Console.WriteLine(customers.Count());

            Customer2 cust = customers.Single(c => c.ID == 2);
            Console.WriteLine(cust.Name);

            cust.Name = "Updated Name";
            dataContext.SubmitChanges();

            Dump(query1);

            var dataContext2 = new DataContext(connect);
            Table<Customer> customers2 = dataContext2.GetTable<Customer>();
            Customer a = customers2.OrderBy(c => c.Name).First();
            Customer b = customers2.OrderBy(c => c.ID).First();




        }

        void Eight()
        {
            var dataContext = new DataContext(connect);
            Table<Customer> customers =
                dataContext.GetTable<Customer>();
            IQueryable<string> query1 = from c in customers
                                        where c.Name.Contains("a")
                                        orderby c.Name.Length
                                        select c.Name.ToUpper();
            Dump(query1);
        }

        void Seven()
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

            IEnumerable<ProjectionItem> temp =
                from n in names
                select new ProjectionItem
                {
                    Original = n,
                    NoVowel = Regex.Replace(n, "[aeiou]", "")
                };

            IEnumerable<string> query1 =
                from item in temp
                where item.NoVowel.Length > 2
                select item.Original;
            Dump(query1);

            var intermediate1 = from n in names
                                select new
                                {
                                    Original = n,
                                    NoVwoel = Regex.Replace(n, "[aeiou]", "")
                                };
            IEnumerable<string> query2 =
                from item in intermediate1
                where item.NoVwoel.Length > 2
                select item.Original;
            Dump(query2);

            var query3 = from n in names
                         select new { Original = n, NoVowel = Regex.Replace(n, "[aeiou]", "") }
                             into temp2
                             where temp2.NoVowel.Length > 2
                             select temp2.Original;
            Dump(query3);

            IEnumerable<string> query4 =
                from n in names
                let noVowel = Regex.Replace(n, "[aeiou]", "")
                where noVowel.Length > 2
                orderby noVowel
                select n;
            Dump(query4);

        
        }

        void Six()
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

            //var filtered = names.Where(n => n.Contains("a"));
            //var sorted = filtered.OrderBy(n => n);
            //var query = sorted.Select(n => n.ToUpper());
            //Dump(query);

            IEnumerable<string> query1 = names
                .Select(n => Regex.Replace(n, "[aeiou]", ""))
                .Where(n => n.Length > 2)
                .OrderBy(n => n);
            Dump(query1);

            IEnumerable<string> query2 =
                from n in names
                where n.Length > 2
                orderby n
                select Regex.Replace(n, "[aeiou]", "");
            Dump(query2);

            IEnumerable<string> query3 =
                from n in names
                select Regex.Replace(n, "[aeiou]", "");
            query3 = from n in query3
                     where n.Length > 2
                     orderby n
                     select n;
            Dump(query3);

            IEnumerable<string> query4 =
                from n in names
                select Regex.Replace(n, "[aeiou]", "")
                    into noVowel
                    where noVowel.Length > 2
                    orderby noVowel
                    select noVowel;
            Dump(query4);

            IEnumerable<string> query5 =
                from n1 in
                    (from n2 in names select Regex.Replace(n2, "[aeiou]", ""))
                where n1.Length > 2 orderby n1 select n1;
            Dump(query5);           


        }

        void Five()
        {
            Out("Subqueries");

            string[] musicians = { "Roger Waters", "David Gilmour", "Rick Wright" };

            // sort by last name
            IEnumerable<string> query1 = musicians.OrderBy(m => m.Split().Last());
            Dump(query1);

            // return the shortest names
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            IEnumerable<string> query2 = names
                .Where(n => n.Length ==
                    names.OrderBy(n2 => n2.Length)
                    .Select(n2 => n2.Length).First());
            Dump(query2);

            // return the shortest names
            IEnumerable<string> query3 =
                from n in names
                where n.Length ==
                (from n2 in names
                 orderby n2.Length
                 select n2.Length).First()
                select n;
            Dump(query3);

            IEnumerable<string> query4 =
                from n in names
                where n.Length == names.OrderBy(n2 => n2.Length).First().Length
                select n;
            Dump(query4);

            IEnumerable<string> query5 =
                from n in names
                where n.Length == names.Min(n2 => n2.Length)
                select n;
            Dump(query5);

            int shortest = names.Min(n => n.Length);
            IEnumerable<string> query6 = from n in names
                                         where n.Length == shortest
                                         select n;
            Dump(query6);
        }

        public void Four()
        {
            Out("Deferred Execution");

            var numbers = new List<int>();

            numbers.Add(1);

            Console.WriteLine(numbers.Where(n => n < 2).Count());  // immediate execution

            IEnumerable<int> query = numbers.Select(n => n * 10);   // doesn't execute yet

            Console.Write("|");
            Dump(query);

            numbers.Add(2);

            Console.Write("|");
            Dump(query);

            numbers.Clear();

            Console.Write("|");
            Dump(query);

            Console.WriteLine("Frozen Results");

            var numbers2 = new List<int>() { 1, 2 };

            List<int> timesTen = numbers2
                .Select(n => n * 10)
                .ToList();
            Console.Write("|");
            Dump(timesTen);

            timesTen.Add(3);

            Console.Write("|");
            Dump(timesTen);

            Out("Count: " + timesTen.Count);

            Out("Outer Variables");

            int[] numbers3 = { 1, 2, 3 };
            int factor = 10;
            var query2 = numbers3.Select(n => n * factor);
            factor = 20;
            Dump(query2);

            IEnumerable<char> query3 = "Not what you might expect";
            foreach (char vowel in "aeiou")
            {
                char t = vowel;
                query3 = query3.Where(c => c != t);
            }
        }

        public void Three()
        {
            // comprehension queries

            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

            IEnumerable<string> query =
                from n in names
                where n.Contains("a")
                orderby n.Length
                select n.ToUpper();
            Dump(query);

            int c = (from name in names
                     where name.Contains("a")
                     select name).Count();
            Out(c.ToString());
            Console.WriteLine();
        }

        public void Two()
        {
            // chaining queries

            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

            IEnumerable<string> query1 = names
                .Where(n => n.Contains("a"))
                .OrderBy(n => n.Length)
                .Select(n => n.ToUpper());
            Dump(query1);

            var filtered = names.Where(n => n.Contains("a"));
            var ordered = filtered.OrderBy(n => n.Length);
            var selected = ordered.Select(n => n.ToUpper());
            Dump(selected);

            IEnumerable<int> query2 = names.Select(n => n.Length);
            Dump(query2);

            IEnumerable<string> query3 = names.Take(2);
            Dump(query3);

            IEnumerable<string> query4 = names.Skip(2);
            Dump(query4);

            IEnumerable<string> query5 = names.Reverse();
            Dump(query5);

            Out(names.First());
            Out(names.Last());
            Out(names.ElementAt(0));
            Console.WriteLine();

            int[] numbers = { 10, 9, 8, 7, 6 };
            Out(numbers.Count().ToString());
            Console.WriteLine(numbers.Min());
            Console.WriteLine(numbers.Contains(9));
            Console.WriteLine(numbers.Any());
            Console.WriteLine(numbers.Any(n => n % 2 == 1));
            Console.WriteLine();
        }

        public void One()
        {
            // getting started

            string[] names = { "Tom", "Dick", "Harry" };

            IEnumerable<string> filteredNames1 = 
                names.Where(n => n.Length >= 4);
            Dump(filteredNames1);

            var filteredNames2 = names.Where(n => n.Length >= 4);
            Dump(filteredNames2);
        }

        static void Dump(IEnumerable<string> col)
        {
            foreach (string n in col)
                Console.Write(n + "|");
            Console.WriteLine();
        }

        static void Dump(IEnumerable<int> col)
        {
            foreach (int n in col)
                Console.Write(n + "|");
            Console.WriteLine();
        }

        static void PressEnter()
        {
            Console.WriteLine();
            Console.Write("[Press ENTER]");
            Console.ReadLine();
        }

        static void Out(string s)
        {
            Console.WriteLine(s);
        }
    }

    class ProjectionItem
    {
        public string Original;
        public string NoVowel;
    }
}

