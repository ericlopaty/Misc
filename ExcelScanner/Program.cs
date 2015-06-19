using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Office.Interop.Excel;
using System.IO;

// http://support.microsoft.com/kb/302084

namespace ExcelScanner
{
    class Program
    {
        List<Student> students;
        List<Teacher> teachers;

        static void Main(string[] args)
        {
            Program p = new Program();
            //p.InitCollections();
            //p.LinqTest4();
            //p.PopulateTable();
            p.ExcelDump();
            Console.ReadLine();
        }

        void PopulateTable()
        {
            Application xlApp = null;
            Workbook workBook = null;
            Worksheet sheet = null;
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "ExcelScanner.xlsx");
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                workBook = xlApp.Workbooks.Open(filePath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", false, false, 0, true, false, false);
                sheet = (Worksheet)workBook.Worksheets[1];
                Range range = sheet.get_Range("A2", "C1001");
                System.Array a = (System.Array)range.Cells.Value2;

                GeneralDataContext db = new GeneralDataContext();

                Number row;
                
                for (int r = a.GetLowerBound(0); r <= a.GetUpperBound(0); r++)
                {
                    row = new Number
                    {
                        RandomNumber = int.Parse(a.GetValue(r, 1).ToString()),
                        HexNumber = a.GetValue(r, 2).ToString(),
                        WordNumber = (string)a.GetValue(r, 3).ToString()
                    };
                    db.Numbers.InsertOnSubmit(row);
                    db.SubmitChanges();
                    Console.WriteLine(row.RandomNumber);
                }
                workBook.Close(false, null, null);
            }
            catch (Exception x)
            {
                Console.WriteLine("{0}", x.Message);
            }
            finally
            {
                if (xlApp != null)
                    xlApp.Quit();
            }
        }

        void LinqTest1()
        {
            int[] numbers = new int[] { 0, 1, 2, 3, 4, 5, 6 };

            var numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;

            foreach (int num in numQuery)
            {
                Console.WriteLine("{0,1} ", num);
            }
        }

        void LinqTest2()
        {
            int[] numbers = new int[] { 0, 1, 2, 3, 4, 5, 6 };

            var evenNumQuery =
                from num in numbers
                where (num % 2) == 0
                select num;

            int evenNumCount = evenNumQuery.Count();
            Console.WriteLine(evenNumCount);
        }

        void LinqTest3()
        {
            students = new List<Student>() {
                new Student {First = "Svetlana", Last = "Omelchenko", ID = 111, Street = "123 Main Street", City = "Seattle", Scores = new List<int> {97, 92, 81, 60}},
                new Student {First = "Claire", Last = "O’Donnell", ID = 112, Street = "124 Main Street", City = "Redmond", Scores = new List<int> {75, 84, 91, 39}},
                new Student {First = "Sven", Last = "Mortensen", ID = 113, Street = "125 Main Street", City = "Lake City", Scores = new List<int> {88, 94, 65, 91}}
            };

            teachers = new List<Teacher>() {
                new Teacher {First = "Ann", Last = "Beebe", ID = 945, City = "Seattle"},
                new Teacher {First = "Alex", Last = "Robinson", ID = 956, City = "Redmond"},
                new Teacher {First = "Michiyo", Last = "Sato", ID = 972, City = "Tacoma"}
            };

            var peopleInSeattle = (
                from student in students
                where student.City == "Seattle"
                select student.Last)
                .Concat(from teacher in teachers
                        where teacher.City == "Seattle"
                        select teacher.Last);
            Console.WriteLine("The following students and teachers live in Seattle:");
            foreach (var person in peopleInSeattle)
            {
                Console.WriteLine(person);
            }
        }

        void LinqTest4()
        {
            students = new List<Student>() {
                new Student {First = "Svetlana", Last = "Omelchenko", ID = 111, Street = "123 Main Street", City = "Seattle", Scores = new List<int> {97, 92, 81, 60}},
                new Student {First = "Claire", Last = "O’Donnell", ID = 112, Street = "124 Main Street", City = "Redmond", Scores = new List<int> {75, 84, 91, 39}},
                new Student {First = "Sven", Last = "Mortensen", ID = 113, Street = "125 Main Street", City = "Lake City", Scores = new List<int> {88, 94, 65, 91}}
            };

            // Create the query.
            var studentsToXML = new XElement("Root",
                from student in students
                let x = String.Format("{0},{1},{2},{3}", student.Scores[0],
                        student.Scores[1], student.Scores[2], student.Scores[3])
                select new XElement("student",
                    new XElement("First", student.First),
                    new XElement("Last", student.Last),
                    new XElement("Scores", x)
                    )
                    );

            Console.WriteLine(studentsToXML);
        }

        void ExcelDump()
        {
            Application xlApp = null;
            Workbook workBook = null;
            Worksheet sheet = null;
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "ExcelScanner.xlsx");
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                workBook = xlApp.Workbooks.Open(filePath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", false, false, 0, true, false, false);
                sheet = (Worksheet)workBook.Worksheets[1];
                Range range = sheet.get_Range("A1", "C26");
                System.Array a = (System.Array)range.Cells.Value2;
                for (int r = a.GetLowerBound(0); r <= a.GetUpperBound(0); r++)
                {
                    for (int c = a.GetLowerBound(1); c <= a.GetUpperBound(1); c++)
                    {
                        Console.WriteLine("Row: {0} Col: {1} Value: {2}", r, c, a.GetValue(r, c));
                    }
                }
                workBook.Close(false, null, null);
            }
            catch (Exception x)
            {
                Console.WriteLine("{0}", x.Message);
            }
            finally
            {
                if (xlApp != null)
                    xlApp.Quit();
            }
        }

        void InitCollections()
        {
        }
    }

    class Student
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int ID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public List<int> Scores;
    }

    class Teacher
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int ID { get; set; }
        public string City { get; set; }
    }
}

