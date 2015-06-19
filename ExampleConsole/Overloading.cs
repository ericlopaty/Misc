using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleConsole
{
    [Chapter(6)]
    static class Overloading
    {
        public static void Dispatch()
        {
            Fraction f1 = new Fraction(3, 4);
            Console.WriteLine("f1: {0}", f1.ToString());
            Fraction.FractionArtist fa = new Fraction.FractionArtist();
            fa.DrawFraction(f1);

            Console.WriteLine("-----------");

            Fraction f = new Fraction(3, 4);
            Console.WriteLine(f);
            Fraction f2 = new Fraction(2, 4);
            Fraction f3 = f + f2;
            Console.WriteLine(f3);
            Console.WriteLine(f == f2);
            Console.WriteLine(f != f2);
            Fraction f4 = new Fraction(3, 4);
            Console.WriteLine(f == f4);
            Console.WriteLine(f != f4);
            Fraction f5 = 7;
            Console.WriteLine(f5);
            Fraction f6 = f + 1;
            Console.WriteLine(f6);
        }
    }

    [Chapter(6)]
    class Fraction
    {
        protected int numerator, denominator;

        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public Fraction(int wholeNumber)
        {
            this.numerator = wholeNumber;
            this.denominator = 1;
        }

        public override string ToString()
        {
            return string.Format("[{0}/{1}]", numerator, denominator);
        }

        //converts an integer to a fraction
        public static implicit operator Fraction(int wholeNumber)
        {
            return new Fraction(wholeNumber);
        }

        public static explicit operator int(Fraction fraction)
        {
            return fraction.numerator / fraction.denominator;
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            return a.numerator == b.numerator && a.denominator == b.denominator;
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Fraction))
                return false;
            return this == (Fraction)obj;
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            if (a.denominator == b.denominator)
                return new Fraction(a.numerator + b.numerator, a.denominator);
            int firstProduct = a.numerator * b.denominator;
            int secondProduct = b.numerator * a.denominator;
            return new Fraction(firstProduct + secondProduct, a.denominator * b.denominator);
        }

        internal class FractionArtist
        {
            public void DrawFraction(Fraction f)
            {
                Console.WriteLine("[{0}/{1}]", f.numerator, f.denominator);
            }
        }
    }
}
