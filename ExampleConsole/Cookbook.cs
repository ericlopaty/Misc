using System;

namespace ExampleConsole
{
    public class Cookbook
    {
        public Cookbook()
        {
        }

        //c# cookbook 1.1
        public static bool IsApproximatelyEqualTo(
            double numerator,
            double denominator,
            double dblValue,
            double epsilon)
        {
            double difference = Math.Abs((numerator / denominator) - dblValue);
            if (difference < epsilon)
                return true;
            else
                return false;
        }

        //c# cookbook 1.2
        public static double ConvertDegreesToRadians(double degrees)
        {
            double radians = (Math.PI / 180) * degrees;
            return radians;
        }

        //c# cookbook 1.3
        public static double ConvertRadiansToDegrees(double radians)
        {
            double degrees = (180 / Math.PI) * radians;
            return degrees;
        }

        //c# cookbook 1.4
        public static void DemoBitWiseComplement()
        {
            byte y = 1;
            byte result = (byte)~y;
            Console.WriteLine(result.ToString());

            y = 1;
            Console.WriteLine("~y=" + ~y);
        }

        //c# cookbook, 1.5
        public static bool IsEven(int intValue)
        {
            return (intValue & 1) == 0;
        }

        public static bool IsOdd(int intValue)
        {
            return (intValue & 1) == 1;
        }

        //c# cookbook, 1.6
        // example does not work because ints are signed.
        public static int GetMSB(int intValue)
        {
            //return intValue & 0xFFFF0000;
            return 0;
        }

        public static int GetLSB(int intValue)
        {
            return intValue & 0x0000FFFF;
        }

        //c# cookbook, 1.7
        public static void Example_1_7()
        {
            string base2 = "11";
            string base8 = "17";
            string base10 = "110";
            string base16 = "11FF";

            Console.WriteLine("Convert.ToInt32(base2,2)=" + Convert.ToInt32(base2, 2));
            Console.WriteLine("Convert.ToInt32(base8,8)=" + Convert.ToInt32(base8, 8));
            Console.WriteLine("Convert.ToInt32(base10,10)=" + Convert.ToInt32(base10, 10));
            Console.WriteLine("Convert.ToInt32(base16,16)=" + Convert.ToInt32(base16, 16));
        }

        //c# cookbook, 1.8

        //c# cookbook, 1.9

        //c# cookbook, 1.10

        //c# cookbook, 1.11
        public static double CtoF(double celsius)
        {
            return ((0.9 / 0.5) * celsius) + 32;
        }

        public static double FtoC(double fahrenheit)
        {
            return (0.5 / 0.9) * (fahrenheit - 32);
        }

        //c# cookbook, 1.12

        //c# cookbook, 1.13

        //c# cookbook, 1.14

        //c# cookbook, 1.15

    }
}
