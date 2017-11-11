using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task_2;

namespace Task_2_Tests
{
    [TestFixture]
    public class InsertionBitsTest
    {
        [TestCase(255, 140, 5, 7, 1935)]
        public void InsertBits(int x, int y, int i, int j, int resultExpected)
        {
            int result = 0;

            result = InsertionBits.InsertBits(x, y, i, j);

            Assert.AreEqual(resultExpected, result);
        }
    }

    [TestFixture]
    public class MaxElementInArrayTest
    {
        [Test]
        public void MaxOfArray()
        {
            int[] array = new int[10];
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                array[i] = rnd.Next(0, 100);
            }
            int resultExpected = array.Max();

            int result = MaxElementInArray.MaxOfArray(array, array.Length);

            Assert.AreEqual(resultExpected, result);
        }
    }

    [TestFixture]
    public class EqualSumsTest
    {
        [Test]
        public void IndexOfEqualSums()
        {
            int[] array = new int[5];
            array[1] = 1;
            array[4] = 1;

            int result = EqualSums.IndexOfEqualSums(array);

            Assert.AreEqual(2, result);
        }
    }

    [TestFixture]
    public class StringOfAlphabetSymbolsTest
    {
        [TestCase("hello", "world", "dehlorw")]
        [TestCase("", "", "")]
        public void AlphabetizedString(string s1, string s2, string sExpected)
        {
            string s;

            s = StringOfAlphabetSymbols.AlphabetizedString(s1, s2);

            Assert.AreEqual(sExpected, s);
        }
    }

    [TestFixture]
    public class LuckyTest
    {
        [TestCase(1, 4, 7, 13, 71, 106, 701)]
        public void FilterLucky(params int[] array)
        {
            string s;

            s = Lucky.FilterLucky(array);

            Assert.AreEqual("7, 71, 701", s);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}