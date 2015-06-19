using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqQueries
{
    class Program
    {
        List<Student> students = null;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.InitDataSource();
            //p.DoQuery();
            p.PruProfileQueries();
            //p.LocalServerQueries();
            PressEnterToContinue();
        }

        static void PressEnterToContinue()
        {
            Console.WriteLine("Press ENTER to continue.");
            Console.ReadLine();
        }

        void LocalServerQueries()
        {
            GeneralDataContext db = new GeneralDataContext();

            var query =
                from number in db.Numbers
                select number;

            foreach (var row in query)
            {
                Console.WriteLine("{0}: {1,4} {2,4} {3}", row.RowID, row.RandomNumber, row.HexNumber, row.WordNumber);
            }

            Number n = new Number
            {
                RandomNumber = 1,
                HexNumber = "1",
                WordNumber = "One"
            };
            db.Numbers.InsertOnSubmit(n);
            db.SubmitChanges();            
        }

        void PruProfileQueries()
        {
            PruProfileDataContext pp = new PruProfileDataContext();

            //var keyNameQuery =
            //    from keyName in pp.TblKeyNames
            //    orderby keyName.PruAppName, keyName.PruKeyId
            //    select keyName;
            //
            //int i = 0;
            //foreach (TblKeyName key in keyNameQuery)
            //{
            //    Console.WriteLine("{0} {1} {2} {3}", i++, key.PruAppName, key.PruKeyId, key.PruKeyName);
            //}
            //Console.ReadLine();

            //var appValuesQuery =
            //    from x in pp.usp_GetAllAppInfo("NB")
            //    select x;
            //foreach (var x in appValuesQuery)
            //{
            //    Console.WriteLine("{0}: {1}", x.PruKeyName, x.PruKeyValue);
            //}

            var q = pp.usp_IsDBO("NB");
            Console.WriteLine(q.ToString());
            q = pp.usp_IsAdmin("NB");
            Console.WriteLine(q.ToString());

        }

        void DoQuery()
        {
            var studentQuery =
                from student in students
                where student.Scores[0] > 90 && student.Scores[3] < 80
                orderby student.Last ascending
                select student;

            foreach (Student student in studentQuery)
            {
                Console.WriteLine("{0}, {1}", student.Last, student.First);
            }
            Console.WriteLine("----------------------");

            var studentQuery2 =
                from student in students
                group student by student.Last[0];

            foreach (var studentGroup in studentQuery2)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (Student student in studentGroup)
                {
                    Console.WriteLine("    {0}, {1}", student.Last, student.First);
                }
            }
            Console.WriteLine("----------------------");

            foreach (var studentGroup in studentQuery2)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (var student in studentGroup)
                {
                    Console.WriteLine("   {0}, {1}",
                        student.Last, student.First);
                }
            }
            Console.WriteLine("----------------------");

            var studentQuery3 =
                from student in students
                group student by student.Last[0] into studentGroup
                orderby studentGroup.Key
                select studentGroup;

            foreach (var group in studentQuery3)
            {
                Console.WriteLine(group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine("   {0}, {1}",
                        student.Last, student.First);
                }
            }
            Console.WriteLine("----------------------");

            var studentQuery4 =
                from student in students
                let totalScore = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
                where totalScore / 4 < student.Scores[0]
                orderby student.Last, student.First
                select student.Last + ", " + student.First;

            foreach (string s in studentQuery4)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("----------------------");

            var studentQuery6 =
                from student in students
                let totalScore = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
                select totalScore;
            double averageScore = studentQuery6.Average();
            Console.WriteLine("Class average score = {0}", averageScore);
            Console.WriteLine("----------------------");

            IEnumerable<string> studentQuery7 =
                from student in students
                where student.Last == "Garcia"
                select student.First;
            Console.WriteLine("The Garcias in the class are:");
            foreach (string s in studentQuery7)
                Console.WriteLine(s);
            Console.WriteLine("----------------------");

            var studentQuery8 =
                from student in students
                let x = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
                where x > averageScore
                select new { id = student.ID, score = x };
            foreach (var item in studentQuery8)
                Console.WriteLine("ID: {0}, Name: {1}", item.id, item.score);
            Console.WriteLine("----------------------");
        }

        void InitDataSource()
        {
            // Create a data source by using a collection initializer.
            students = new List<Student>
            {
               new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
               new Student {First="Claire", Last="O’Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
               new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
               new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
               new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
               new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
               new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
               new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
               new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
               new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
               new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
               new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}},
            };
        }
    }
}

public class Student
{
    public string First { get; set; }
    public string Last { get; set; }
    public int ID { get; set; }
    public List<int> Scores;
}

