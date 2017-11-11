using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    public class InsertionBits
    {
        public static int InsertBits(int x, int y, int i, int j)
        {
            string sY = Convert.ToString(y, 2);
            sY = sY.Substring(sY.Length - j, j - i + 1);

            string sX = Convert.ToString(x, 2);
            sX = sX.Insert(sX.Length - i + 1, sY);

            return Convert.ToInt32(sX, 2);
        }
    }

    public class MaxElementInArray
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
    }

    public class EqualSums
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
    }

    public class StringOfAlphabetSymbols
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
    }

    public class Lucky
    {
        public static string FilterLucky(params int[] array)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i].ToString().IndexOf("7") >= 0)
                    sb.AppendFormat("{0}, ", array[i]);
            }
            return sb.Remove(sb.Length - 2, 2).ToString();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}