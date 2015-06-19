using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleConsole
{
    [Chapter(12)]
    class Delegates
    {
        public static void Dispatch()
        {
            //SimpleDelegates();
            //ArrayOfDelegates();
            MulticastDelegates();
        }

        public static void MulticastDelegates()
        {
            ClassWithDelegate.StringDelegate writer,logger,transmitter;
            ClassWithDelegate.StringDelegate multi;
            writer=new ClassWithDelegate.StringDelegate(ImplementingClass.WriteString);
            logger=new ClassWithDelegate.StringDelegate(ImplementingClass.LogString);
            transmitter=new ClassWithDelegate.StringDelegate(ImplementingClass.TransmitString);
            writer("string passed to writer.");
            logger("string passed to logger.");
            transmitter("string passed to transmitter.");
            Console.WriteLine("combining writer and logger");
            multi = writer + logger;
            multi("string passed to writer/logger");
            Console.WriteLine("adding transmitter");
            multi += transmitter;
            multi("string passed to all");
            Console.WriteLine("removing writer");
            multi -= writer;
            multi("string passed to remaining.");

        }

        public static void SimpleDelegates()
        {
            Program.Divider("delegates");
            Student lauren = new Student("lauren");
            Student abby = new Student("abby");
            Dog pippin = new Dog(70);
            Dog jasmine = new Dog(90);
            Pair studentPair = new Pair(lauren, abby);
            Pair dogPair = new Pair(pippin, jasmine);
            Console.WriteLine("students:\t\t\t{0}", studentPair);
            Console.WriteLine("dogs:\t\t\t{0}", dogPair);
            Pair.WhichIsFirst studentDelegate = new Pair.WhichIsFirst(Student.WhichStudentComesFirst);
            Pair.WhichIsFirst dogDelegate = new Pair.WhichIsFirst(Dog.WhichDogComesFirst);
            studentPair.Sort(studentDelegate);
            dogPair.ReverseSort(dogDelegate);
            Console.WriteLine("students:\t\t\t{0}", studentPair);
            Console.WriteLine("dogs:\t\t\t{0}", dogPair);
            Program.Divider("");
            studentPair = new Pair(lauren, abby);
            dogPair = new Pair(pippin, jasmine);
            Console.WriteLine("students:\t\t\t{0}", studentPair);
            Console.WriteLine("dogs:\t\t\t{0}", dogPair);
            studentPair.Sort(Student.OrderStudents);
            dogPair.ReverseSort(Dog.OrderDogs);
            Console.WriteLine("students:\t\t\t{0}", studentPair);
            Console.WriteLine("dogs:\t\t\t{0}", dogPair);
        }

        public static void ArrayOfDelegates()
        {
            Image image = new Image();
            ImageProcessor processor = new ImageProcessor(image);
            processor.AddToEffects(processor.BlurEffect);
            processor.AddToEffects(processor.RotateEffect);
            processor.AddToEffects(processor.SharpenEffect);
            processor.AddToEffects(processor.FilterEffect);
            processor.ProcessImages();
        }
    }

    //---- Multicast Delegates

    [Chapter(12)]
    public class ClassWithDelegate
    {
        public delegate void StringDelegate(string s);
    }

    [Chapter(12)]
    public class ImplementingClass
    {
        public static void WriteString(string s)
        {
            Console.WriteLine("writing string: {0}",s);
        }

        public static void LogString(string s)
        {
            Console.WriteLine("logging string: {0}",s);
        }

        public static void TransmitString(string s)
        {
            Console.WriteLine("transmitting string: {0}",s);
        }
    }

    //---- Array of Delegates

    [Chapter(12)]
    public class Image
    {
        public Image()
        {
            Console.WriteLine("an image created");
        }
    }

    [Chapter(12)]
    public class ImageProcessor
    {
        public delegate void DoEffect();

        public DoEffect BlurEffect = new DoEffect(Blur);
        public DoEffect SharpenEffect = new DoEffect(Sharpen);
        public DoEffect FilterEffect = new DoEffect(Filter);
        public DoEffect RotateEffect = new DoEffect(Rotate);

        public ImageProcessor(Image image)
        {
            this.image = image;
            arrayOfEffects = new DoEffect[10];
        }

        public void AddToEffects(DoEffect effect)
        {
            if (numEffectsRegistered >= 10)
            {
                throw new Exception("too many effects");
            }
            arrayOfEffects[numEffectsRegistered++] = effect;
        }

        public static void Blur()
        {
            Console.WriteLine("blur...");
        }

        public static void Sharpen()
        {
            Console.WriteLine("sharpen...");
        }

        public static void Filter()
        {
            Console.WriteLine("filter...");
        }

        public static void Rotate()
        {
            Console.WriteLine("rotate...");
        }

        public void ProcessImages()
        {
            for (int i = 0; i < numEffectsRegistered; i++)
            {
                arrayOfEffects[i]();
            }
        }

        private DoEffect[] arrayOfEffects;
        private Image image;
        private int numEffectsRegistered;
    }
    
    //---- Simple Delegates

    public enum Comparison
    {
        theFirstComesFirst=1,
        theSecondComesFirst=2
    }

    [Chapter(12)]
    public class Pair
    {
        private object[] thePair = new object[2];

        public delegate ExampleConsole.Comparison WhichIsFirst(object o1, object o2);

        public void Sort(WhichIsFirst sortFunction)
        {
            if (sortFunction(thePair[0], thePair[1]) == Comparison.theSecondComesFirst)
            {
                Swap(ref thePair[0], ref thePair[1]);
            }
        }

        public void ReverseSort(WhichIsFirst sortFunction)
        {
            if (sortFunction(thePair[0],thePair[1])==ExampleConsole.Comparison.theFirstComesFirst)
            {
                Swap(ref thePair[0], ref thePair[1]);
            }
        }

        public static void Swap(ref object a, ref object b)
        {
            object c = a;
            a = b;
            b = c;
        }

        public Pair(object first, object second)
        {
            thePair[0] = first;
            thePair[1] = second;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", thePair[0].ToString(), thePair[1].ToString());
        }
    }

    [Chapter(12)]
    [Chapter(9999)]
    public class Student
    {
        private string name;

        public Student(string name)
        {
            this.name = name;
        }

        public static ExampleConsole.Comparison WhichStudentComesFirst(object o1, object o2)
        {
            Student s1 = (Student)o1;
            Student s2 = (Student)o2;
            return string.Compare(s1.name, s2.name) < 0 ? ExampleConsole.Comparison.theFirstComesFirst : ExampleConsole.Comparison.theSecondComesFirst;
        }

        //delegate which must be instantiated
        //public static readonly Pair.WhichIsFirst OrderStudents = new Pair.WhichIsFirst(Student.WhichStudentComesFirst);

        //static delegate
        public static Pair.WhichIsFirst OrderStudents
        {
            get
            {
                return new Pair.WhichIsFirst(WhichStudentComesFirst);
            }
        }

        public override string ToString()
        {
            return name;
        }
    }

    [Chapter(12)]
    public class Dog
    {
        private int weight;

        public Dog(int weight)
        {
            this.weight = weight;
        }

        public static ExampleConsole.Comparison WhichDogComesFirst(object o1, object o2)
        {
            Dog d1 = (Dog)o1;
            Dog d2 = (Dog)o2;
            return d1.weight < d2.weight ? ExampleConsole.Comparison.theFirstComesFirst : ExampleConsole.Comparison.theSecondComesFirst;
        }

        //delegate which must be instantiated
        //public static readonly Pair.WhichIsFirst OrderDogs = new Pair.WhichIsFirst(Dog.WhichDogComesFirst);

        //static delegate
        public static Pair.WhichIsFirst OrderDogs
        {
            get
            {
                return new Pair.WhichIsFirst(WhichDogComesFirst);
            }
        }

        public override string ToString()
        {
            return weight.ToString();
        }
    }    
}
