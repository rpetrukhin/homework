using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program1
    {
        static int InsertBits(int x, int y, int i, int j)
        {
            StringBuilder sbY = new StringBuilder();
            for(int k = i - 1; k < j; k++)
                sbY.Append(((y >> k) & 1));

            int copyX = x;
            int digitX = 1;
            while (copyX / 2 > 0)
            {
                copyX /= 2;
                digitX++;
            }

            StringBuilder sbX = new StringBuilder();
            for (int k = 0; k < digitX; k++)
                sbX.Append(((x >> k) & 1));

            string sY = sbY.ToString();
            string sX = sbX.ToString().Insert(i - 1, sY);

            char[] array = sX.ToCharArray();
            Array.Reverse(array);
            string s = new string(array);

            return Convert.ToInt32(s, 2);
        }

        public static void Test()
        {
            Console.WriteLine(InsertBits(255, 140, 5, 7));
        }
    }

    class Program2
    {
        static int Max(int a, int b)
        {
            return (a > b ? a : b);
        }

        static int MaxOfArray(int[] array, int lengthOfArray)
        {
            if (lengthOfArray == 1)
                return array[0];
            else if (lengthOfArray == 2)
                return Max(array[0], array[1]);
            else
                return Max(array[lengthOfArray - 1], MaxOfArray(array, lengthOfArray - 1));
        }

        public static void Test()
        {
            int n = 10;
            int[] array = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = rnd.Next(0,100);
                Console.Write(array[i] + ", ");
            }
            Console.WriteLine("\nMaximum = " + MaxOfArray(array, array.Length));
        }
    }

    class Program3
    {
        static int IndexOfEqualSums(int[] array)
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

        public static void Test()
        {
            int n = 10;
            int[] array = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = rnd.Next(0, 2);
                Console.Write(array[i] + ", ");
            }
            Console.WriteLine("\nIndex = " + IndexOfEqualSums(array));
        }
    }

    class Program4
    {
        static string AlphabetizedString(string s1, string s2)
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

        public static void Test()
        {
            Console.WriteLine(AlphabetizedString("hello", "world"));
        }
    }

    class Program5
    {
        static string FilterLucky(params int[] array)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i].ToString().IndexOf("7") >= 0)
                    sb.Append(array[i] + ", ");
            }
            return sb.Remove(sb.Length - 2, 2).ToString();
        }

        public static void Test()
        {
            Console.WriteLine(FilterLucky(1,4,7,13,71,106,701));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {            
            Program1.Test();
            Program2.Test();
            Program3.Test();
            Program4.Test();
            Program5.Test();
        }
    }
}