#define DEBUG

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleConsole
{
    class Program
    {
        // public - visible outside the class
        // private - only visible within the class
        // protected - visible to derived classes
        // internal - visible within assembly
        // internal protected - visible within assembly and derived classes

        static void Main(string[] args)
        {
            ReflectionTesting.Dispatch();   // chap 18
            //Database.Dispatch();
            //FileIO.Dispatch();    // chap 13
            //EnvironmentInfo.Dispatch();
            //Events.Dispatch();  // chap 12
            //Delegates.Dispatch();   // chap 12            
            //Exceptions.Dispatch();    // chap 11
            //RegularExpressions.Dispatch();    //chap 10
            //StringExamples.Dispatch();    // chap 10
            //ArraysAndCollections.Dispatch();  // chap 9
            //Interfaces.Dispatch();   // chap 8
            //Structs.Dispatch(); // chap 7            
            //Overloading.Dispatch(); // chap 6
            //RegistryFunctions.Dispatch(); // extra                        
            //Miscellaneous.Dispatch();
            //TimeTester.Dispatch();
            //InheritanceTesting.BasicInheritance();
            //InheritanceTesting.Polymorph();
            //SmallClassTester.OverrideToString();
            //Miscellaneous.Boxing();
            Console.WriteLine();
            Console.WriteLine("Press ENTER to continue.");
            Console.ReadLine();
        }

        public static void Divider(string msg)
        {
            int screenWidth = Console.WindowWidth;
            if (msg.Length > 0)
                Console.Write(string.Format("\n{0}[ {1} ]{2}\n\n",
                    "=====", msg, "".PadRight(screenWidth - (msg.Length + 10), '=')));
            else
                Console.WriteLine("".PadRight(screenWidth - 1, '='));
        }
    }
}
