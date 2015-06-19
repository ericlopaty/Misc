using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace ExampleConsole
{
    [Chapter(9)]
    public static class ArraysAndCollections
    {
        public static void Dispatch()
        {
            Demo6();
        }

        public static void Demo6()
        {
            Hashtable hash = new Hashtable();
            hash.Add("John", new Employee(1, "John", 100));
            hash.Add("George", new Employee(2, "George", 200));
            hash.Add("Paul", new Employee(3, "Paul", 300));
            Employee ringo=new Employee(4,"Ringo",400);
            hash.Add("Ringo", ringo);

            Console.WriteLine(hash.Contains("Paul"));
            Console.WriteLine(hash["Ringo"]);
            Console.WriteLine(hash.ContainsValue(ringo));

            foreach (DictionaryEntry d in hash)
                Console.WriteLine(d.Key+": "+d.Value);

            foreach (object key in hash.Keys)
                Console.WriteLine(key);

            foreach (object values in hash.Values)
                Console.WriteLine(values);
        }

        public static void MultiDimensional()
        {
            int[,] r1 = new int[3, 4];

            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 4; y++)
                    r1[x, y] = x + y;

            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 4; y++)
                    Console.WriteLine("[{0},{1}]={2}", x, y, r1[x, y]);
            Console.WriteLine();

            r1 = new int[,] { { 1, 2, 3, 4 }, { 2, 3, 4, 5 }, { 3, 4, 5, 6 } };
            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 4; y++)
                    Console.WriteLine("[{0},{1}]={2}", x, y, r1[x, y]);
            Console.WriteLine();

            int[][] r2 = new int[3][];
            r2[0] = new int[2];
            r2[1] = new int[3];
            r2[2] = new int[4];
            r2[2][3] = 55;
            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 4; y++)
                    Console.WriteLine("[{0}][{1}]={2}", x, y, r2[x][y]);
        }

        public static void Demo1()
        {
            int[] intArray;
            Employee[] empArray;

            intArray = new int[5];
            empArray = new Employee[3];

            for (int i = 0; i < intArray.Length; i++)
                Console.WriteLine(intArray[i]);
            for (int i = 0; i < empArray.Length; i++)
                empArray[i] = new Employee(i * 5);
            for (int i = 0; i < empArray.Length; i++)
                Console.WriteLine(empArray[i]);
            foreach (Employee e in empArray)
                Console.WriteLine(e);

            intArray = new int[] { 2, 4, 6, 8, 10 };
            // intArray = {1,3,5,7,9};  (should work?)
            for (int i = 0; i < intArray.Length; i++)
                Console.WriteLine(intArray[i]);
        }

        public static void Demo2()
        {
            Console.WriteLine(Max(1, 2, 3, 4, 5));
        }

        public static void Demo3()
        {
            string[] fubar = new string[] { "John", "Paul", "George", "Ringo" };
            foreach (string s in fubar)
                Console.WriteLine(s);
            Console.WriteLine();
            Array.Sort(fubar);
            foreach (string s in fubar)
                Console.WriteLine(s);
            Console.WriteLine();
            Array.Reverse(fubar);
            foreach (string s in fubar)
                Console.WriteLine(s);
            Console.WriteLine();
        }

        public static int Max(params int[] values)
        {
            int max = 0;
            foreach (int i in values)
                if (i > max)
                    max = i;
            return max;
        }

        public static void Demo4()
        {
            EmployeeList list = new EmployeeList();
            list.Add(new Employee(1, "John",3484));
            list.Add(new Employee(2, "Paul",3498));
            list.Add(new Employee(3, "George",98754));
            list.Add(new Employee(4, "Ringo",82398));

            Console.WriteLine(list.Count);
            Console.WriteLine();

            for (int i = 0; i < list.Count; i++)
                Console.WriteLine(list[i]);
            Console.WriteLine();

            Console.WriteLine("using indexer with int");
            list[0].EmployeeName = "JOHN";
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine(list[i]);
            Console.WriteLine();

            Console.WriteLine("using indexer with string");
            list["JO"].EmployeeName = "john";
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine(list[i]);
            Console.WriteLine();

            Console.WriteLine("using enumerator");
            foreach (Employee emp in list)
                Console.WriteLine(emp);
            Console.WriteLine();

            Console.WriteLine("sort");
            ArrayList t = new ArrayList();
            t.Add(new Employee(1, "John", 800));
            t.Add(new Employee(2, "Paul", 700));
            t.Add(new Employee(3, "George", 600));
            t.Add(new Employee(4, "Ringo", 500));
            foreach (Employee e in t)
                Console.WriteLine(e);
            Console.WriteLine();
            t.Sort();
            foreach (Employee e in t)
                Console.WriteLine(e);
            Console.WriteLine();

            Console.WriteLine("custom comparer");
            Employee.EmployeeComparer c = Employee.GetComparer();
            c.WhichComparison = Employee.EmployeeComparer.ComparisonType.EmployeeName;
            t.Sort(c);
            foreach (Employee e in t)
                Console.WriteLine(e);
            Console.WriteLine();
        }

        public static void Demo5()
        {
            Queue q = new Queue();
            q.Enqueue(new Employee(1, "John", 100));
            q.Enqueue(new Employee(2, "Paul", 200));
            q.Enqueue(new Employee(3, "George", 300));
            q.Enqueue(new Employee(4, "Ringo", 400));

            Console.WriteLine("queue members");
            IEnumerator enumerator=q.GetEnumerator();
            while (enumerator.MoveNext())
                Console.WriteLine(enumerator.Current);

            Console.WriteLine("queue peek");
            Console.WriteLine(q.Peek());

            Console.WriteLine("dequeue");
            while (q.Count > 0)
            {
                object o = q.Dequeue();
                Employee e = o as Employee;
                if (e != null)
                    Console.WriteLine(e);
            }

            Stack s = new Stack();
            s.Push(new Employee(1, "John", 100));
            s.Push(new Employee(2, "Paul", 200));
            s.Push(new Employee(3, "George", 300));
            s.Push(new Employee(4, "Ringo", 400));

            Console.WriteLine("stack members");
            enumerator = s.GetEnumerator();
            while (enumerator.MoveNext())
                Console.WriteLine(enumerator.Current);

            Console.WriteLine("stack peek");
            Console.WriteLine(s.Peek());

            Console.WriteLine("pop");
            while (s.Count > 0)
            {
                object o = s.Pop();
                Employee e = o as Employee;
                if (e != null)
                    Console.WriteLine(e);
            }
        }
    }

    [Chapter(9)]
    public class EmployeeList : IEnumerable
    {
        private ArrayList employees;

        private class EmployeeListEnumerator : IEnumerator
        {
            public EmployeeListEnumerator(EmployeeList employees)
            {
                this.employees = employees;
                index = -1;
            }

            public bool MoveNext()
            {
                index++;
                return index < employees.Count;
            }

            public void Reset()
            {
                index = -1;
            }

            public object Current
            {
                get
                {
                    return employees[index];
                }
            }

            private EmployeeList employees;
            private int index;
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)new EmployeeListEnumerator(this);
        }

        public EmployeeList()
        {
            employees = new ArrayList();
        }

        public void Add(Employee employee)
        {
            employees.Add(employee);
        }

        public Employee this[int index]
        {
            get
            {
                return (Employee)employees[index];
            }
            set
            {
                employees[index] = value;
            }
        }

        public Employee this[string index]
        {
            get
            {
                return this[FindString(index)];
            }
            set
            {
                this[FindString(index)] = value;
            }
        }

        private int FindString(string employeeName)
        {
            for (int i = 0; i < employees.Count; i++)
                if (((Employee)employees[i]).EmployeeName.StartsWith(employeeName))
                    return i;
            return -1;
        }

        public int Count
        {
            get
            {
                return employees.Count;
            }
        }
    }

    [Chapter(9)]
    public class Employee : IComparable
    {
        int employeeID;
        string employeeName;
        int salary;

        public Employee(int employeeID, string employeeName, int salary)
        {
            this.employeeID = employeeID;
            this.employeeName = employeeName;
            this.salary = salary;
        }

        public Employee(int employeeID)
        {
            this.employeeID = employeeID;
            this.employeeName = "Unknown";
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}, (${2})", employeeID, employeeName, salary);
        }

        public string EmployeeName
        {
            get
            {
                return employeeName;
            }
            set
            {
                employeeName = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return employeeID;
            }
            set
            {
                employeeID = value;
            }
        }

        public int Salary
        {
            get
            {
                return salary;
            }
            set
            {
                salary = value;
            }
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            Employee rhs = (Employee)obj;
            return this.salary.CompareTo(rhs.salary);
        }

        #endregion

        #region Custom IComparer

        public static EmployeeComparer GetComparer()
        {
            return new Employee.EmployeeComparer();
        }

        public int CompareTo(Employee rhs, Employee.EmployeeComparer.ComparisonType which)
        {
            switch (which)
            {
                case Employee.EmployeeComparer.ComparisonType.EmployeeID:
                    return this.employeeID.CompareTo(rhs.employeeID);
                    break;
                case Employee.EmployeeComparer.ComparisonType.EmployeeName:
                    return this.employeeName.CompareTo(rhs.employeeName);
                    break;
                case Employee.EmployeeComparer.ComparisonType.EmployeeSalary:
                    return this.salary.CompareTo(rhs.salary);
                    break;
            }
            return 0;
        }

        public class EmployeeComparer : IComparer
        {
            public enum ComparisonType
            {
                EmployeeID, EmployeeName, EmployeeSalary
            }

            public int Compare(object lhs, object rhs)
            {
                Employee l = (Employee)lhs;
                Employee r = (Employee)rhs;
                return l.CompareTo(r, WhichComparison);
            }

            public Employee.EmployeeComparer.ComparisonType WhichComparison
            {
                get
                {
                    return whichComparison;
                }
                set
                {
                    whichComparison = value;
                }
            }

            private Employee.EmployeeComparer.ComparisonType whichComparison;
        }

        #endregion
    }
}
