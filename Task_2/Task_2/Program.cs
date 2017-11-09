using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    public class Program1
    {
        public static int InsertBits(int x, int y, int i, int j)
        {
            StringBuilder sbY = new StringBuilder(j - i  + 1);
            for(int k = i - 1; k < j; k++)
                sbY.Append(((y >> k) & 1));

            StringBuilder sbX = new StringBuilder();
            while (x > 0)
            {
                sbX.Append(x % 2);
                x /= 2;
            }

            sbX.Insert(i - 1, sbY);
            string sX = sbX.ToString();

            char[] array = sX.ToCharArray();
            Array.Reverse(array);
            string s = new string(array);

            return Convert.ToInt32(s, 2);
        }

        public static void Test(int x, int y, int i, int j)
        {
            Console.WriteLine(InsertBits(x, y, i, j));
        }
    }

    public class Program2
    {
        private static int Max(int a, int b)
        {
            return (a > b ? a : b);
        }

        public static int MaxOfArray(int[] array, int lengthOfArray)
        {
            if (lengthOfArray == 1)
                return array[0];
            else if (lengthOfArray == 2)
                return Max(array[0], array[1]);
            else
                return Max(array[lengthOfArray - 1], MaxOfArray(array, lengthOfArray - 1));
        }

        public static void Test(int[] array)
        {
            Console.WriteLine("\nMaximum = " + MaxOfArray(array, array.Length));
        }
    }

    public class Program3
    {
        public static int IndexOfEqualSums(int[] array)
        {
            if (array.Length < 3)
                return -1;

            int sumLeft = array[0];
            int sumRight = 0;
            for(int i = 2; i < array.Length; i++)
            {
                sumRight += array[i];
            }

            for(int i = 1; i < array.Length - 1; i++)
            {
                if (sumLeft == sumRight)
                    return i;
                sumLeft += array[i];
                sumRight -= array[i + 1];
            }

            return -1;
        }

        public static void Test(int[] array)
        {
            Console.WriteLine("\nIndex = " + IndexOfEqualSums(array));
        }
    }

    public class Program4
    {
        public static string AlphabetizedString(string s1, string s2)
        {
            StringBuilder sb = new StringBuilder();
            string[] alphabet = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l",
                "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" }; 
            foreach(string symbol in alphabet)
            {
                if (s1.IndexOf(symbol) >= 0 || s2.IndexOf(symbol) >= 0)
                    sb.Append(symbol);
            }
            return sb.ToString();
        }

        public static void Test(string s1, string s2)
        {
            Console.WriteLine(AlphabetizedString(s1, s2));
        }
    }

    public class Program5
    {
        public static string FilterLucky(params int[] array)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i].ToString().IndexOf("7") >= 0)
                    sb.Append(array[i] + ", ");
            }
            return sb.Remove(sb.Length - 2, 2).ToString();
        }

        public static void Test(params int[] array)
        {
            Console.WriteLine(FilterLucky(array));
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Test 1");
            Program1.Test(255, 140, 5, 7);
            Console.WriteLine();

            Console.WriteLine("Test 2");
            int[] array2 = new int[10];
            Random rnd2 = new Random();
            for (int i = 0; i < 10; i++)
            {
                array2[i] = rnd2.Next(0, 100);
                Console.Write(array2[i] + ", ");
            }
            Program2.Test(array2);
            Console.WriteLine();

            Console.WriteLine("Test 3");
            int[] array3 = new int[10];
            Random rnd3 = new Random();
            for (int i = 0; i < 10; i++)
            {
                array3[i] = rnd3.Next(0, 2);
                Console.Write(array3[i] + ", ");
            }
            Program3.Test(array3);
            Console.WriteLine();

            Console.WriteLine("Test 4");
            Program4.Test("hello", "world");
            Console.WriteLine();

            Console.WriteLine("Test 5");
            Program5.Test(1, 4, 7, 13, 71, 106, 701);
        }
    }
}