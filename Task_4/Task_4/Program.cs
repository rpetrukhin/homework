using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    public static class DoubleExtension
    {
        private static string ToBinFrac(double x, int len)
        {
            StringBuilder sb = new StringBuilder();
            int a;
            int i = 0;

            while (i < len)
            {
                x *= 2;
                a = (int)Math.Truncate(x);
                sb.Append(a);
                x -= a;
                i++;
            }

            return sb.ToString();
        }

        public static string ToBinary(this double value)
        {
            if (value == 0)
                return new string('0', 16);

            const int orderSize = 11;
            const int mantissaSize = 52;
            const int shift = 1023;

            int intOfDouble = (int)Math.Truncate(Math.Abs(value));
            double fracOfDouble = Math.Abs(value) - intOfDouble;

            string intOfDoubleBin = Convert.ToString(intOfDouble, 2);
            string fracOfDoubleBin = ToBinFrac(fracOfDouble, mantissaSize - intOfDoubleBin.Length + 1);

            string order = Convert.ToString(intOfDoubleBin.Length - 1 + shift, 2);
            string zeros = new string('0', orderSize - order.Length);
            string order11Bits = zeros + order;

            string sign = (Math.Sign(value) == 1) ? "0" : "1";

            string strBin = sign + order11Bits + intOfDoubleBin.Substring(1, intOfDoubleBin.Length - 1) + fracOfDoubleBin;
            return strBin;
        }

        public static void Test(double value)
        {
            Console.WriteLine("Binary representation of double: {0}", value.ToBinary());
        }
    }

    public class GCD
    {
        private int EuclideanAlgorithm(int a, int b)
        {
            int c;
            while (b != 0)
            {
                c = b;
                b = a % b;
                a = c;
            }
            return a;
        }

        public Tuple<int, double> EuclideanAlgorithm(params int[] numbers)
        {
            Stopwatch time = new Stopwatch();
            time.Start();

            if (numbers.Length < 2)
            {
                time.Stop();
                return Tuple.Create(-1, time.Elapsed.TotalMilliseconds);
            }

            int d = EuclideanAlgorithm(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length; i++)
            {
                d = EuclideanAlgorithm(numbers[i], d);
            }

            time.Stop();
            return Tuple.Create(Math.Abs(d), time.Elapsed.TotalMilliseconds);
        }

        private int SteinAlgorithm(int a, int b)
        {
            if (a == 0)
                return b;

            if (b == 0)
                return a;

            if (a == b)
                return a;

            if (a == 1 || b == 1)
                return 1;

            if ((a & 1) == 0)
            {
                if ((b & 1) == 0)
                    return SteinAlgorithm(a >> 1, b >> 1) << 1;
                else
                    return SteinAlgorithm(a >> 1, b);
            }
            else
            {
                if ((b & 1) == 0)
                    return SteinAlgorithm(a, b >> 1);
                else
                    return SteinAlgorithm(b, a > b ? a - b : b - a);
            }
        }

        //The third possibility to return more than one value from the method is to use the <<ref>> instead of the <<out>>
        public int SteinAlgorithm(out double time, params int[] numbers)
        {
            Stopwatch timeElapsed = new Stopwatch();
            timeElapsed.Start();

            if (numbers.Length < 2)
            {
                timeElapsed.Stop();
                time = timeElapsed.Elapsed.TotalMilliseconds;
                return -1;
            }

            int d = SteinAlgorithm(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length; i++)
            {
                d = SteinAlgorithm(numbers[i], d);
            }

            timeElapsed.Stop();
            time = timeElapsed.Elapsed.TotalMilliseconds;
            return Math.Abs(d);
        }

        public void Test(params int[] numbers)
        {
            var gcd = Tuple.Create(0, (double)0);
            gcd = EuclideanAlgorithm(numbers);
            Console.WriteLine("GCD of input numbers by Euclidean algorithm = {0}, time = {1}",
                gcd.Item1, gcd.Item2);

            double time;
            Console.WriteLine("GCD of input numbers by Stein algorithm = {0}, time = {1}", 
                SteinAlgorithm(out time, numbers), time);
        }
    }

    public static class StringExtension
    {
        public static string SayHello(this string name)
        {
            return String.Format("Hello, {0}!", name);
        }

        public static string SayGoodbye(this string name)
        {
            return String.Format("Goodbye, {0}. See you again soon!", name);
        }

        public static void Test(string name)
        {
            Console.WriteLine(name.SayHello());
            Console.WriteLine(name.SayGoodbye());
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            //There is an example at the bottom of the page
            //https://neerc.ifmo.ru/wiki/index.php?title=Представление_вещественных_чисел 
            DoubleExtension.Test(-312.3125);
            Console.WriteLine();

            GCD gcd = new GCD();
            gcd.Test(78, 294, 570, 36);
            Console.WriteLine();

            StringExtension.Test("Kathy");
        }
    }
}
