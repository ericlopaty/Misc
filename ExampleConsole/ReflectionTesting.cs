using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ExampleConsole
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Field |
        AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Enum | AttributeTargets.Delegate |
        AttributeTargets.Interface | AttributeTargets.Struct,
        AllowMultiple = true)]
    public class ChapterAttribute : System.Attribute
    {
        private int number;

        public ChapterAttribute()
        {
            this.number = 0;
        }

        public ChapterAttribute(int chapterNumber)
        {
            this.number = chapterNumber;
        }

        public int Number
        {
            get
            {
                return this.number;
            }
            set
            {
                this.number = value;
            }
        }
    }

    [Chapter(18)]
    class ReflectionTesting
    {
        public static void Dispatch()
        {
            //One();
            //Two();
            LateBinding();
        }

        public static void LateBinding()
        {
            Type mathType=Type.GetType("System.Math");
            //Object theObject = Activator.CreateInstance(mathType);
            Type[] paramInfo=new Type[1];
            paramInfo[0]=Type.GetType("System.Double");
            MethodInfo cosine=mathType.GetMethod("Cos",paramInfo);
            Object[] parameters = new Object[1];
            parameters[0] = 0;  // 45 * (Math.PI / 180.0);
            Object returnVal = cosine.Invoke(mathType, parameters);
            Console.WriteLine("the cosing of 45 is {0}", returnVal);
        }

        static void One()
        {
            MemberInfo info = typeof(Student);
            object[] attributes;
            attributes = info.GetCustomAttributes(typeof(ChapterAttribute), false);
            foreach (object attribute in attributes)
            {
                ChapterAttribute chap = (ChapterAttribute)attribute;
                Console.WriteLine(chap.Number);
            }
        }

        static void Two()
        {
            Assembly a = Assembly.Load("mscorlib.dll");
            Type[] types = a.GetTypes();
            foreach (Type t in types)
            {
                Console.WriteLine(t.ToString());
            }
            Console.WriteLine("{0} types found", types.Length);
            Console.WriteLine("---------------------");
            Type type = Type.GetType("System.Reflection.Assembly");
            Console.WriteLine("type is {0}", type);
            MemberInfo[] members = type.GetMembers();
            foreach (MemberInfo member in members)
            {
                Console.WriteLine("member {0} is {1}", member, member.MemberType);
            }
            Console.WriteLine("{0} members found", members.Length);
            Console.WriteLine("---------------------");
            members = type.GetMethods();
            foreach (MemberInfo member in members)
            {
                Console.WriteLine("member {0} is {1}", member, member.MemberType);
            }
            Console.WriteLine("{0} members found", members.Length);
            Console.WriteLine("---------------------");
            members = type.FindMembers(
                MemberTypes.Method, 
                BindingFlags.IgnoreCase|BindingFlags.Public|BindingFlags.Static|BindingFlags.NonPublic|BindingFlags.Instance|BindingFlags.DeclaredOnly, 
                Type.FilterName, "Get*");
            foreach (MemberInfo member in members)
            {
                Console.WriteLine("member {0} is {1}", member, member.MemberType);
            }
            Console.WriteLine("{0} members found", members.Length);
            Console.WriteLine("---------------------");

        }
    }
}
