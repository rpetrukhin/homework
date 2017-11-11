using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task_4;

namespace Task_4_Tests
{
    [TestFixture]
    public class DoubleExtensionTest
    {
        [TestCase(-312.3125, "1100000001110011100001010000000000000000000000000000000000000000")]
        [TestCase(0.0, "0000000000000000")]
        public void ToBinary(double value, string sExpected)
        {
            //There is an example at the bottom of the page
            //https://neerc.ifmo.ru/wiki/index.php?title=Представление_вещественных_чисел

            string s = value.ToBinary();

            Assert.AreEqual(sExpected, s);
        }
    }

    [TestFixture]
    public class GCDTest
    {
        [TestCase(6, 78, 294, 570, 36)]
        public void EuclideanAlgorithm(int resultExpected, params int[] numbers)
        {
            GCD gcd = new GCD();

            int result = gcd.EuclideanAlgorithm(numbers).Item1;

            Assert.AreEqual(resultExpected, result);
        }

        [TestCase(6, 78, 294, 570, 36)]
        public void SteinAlgorithm(int resultExpected, params int[] numbers)
        {
            GCD gcd = new GCD();

            int result = gcd.EuclideanAlgorithm(numbers).Item1;

            Assert.AreEqual(resultExpected, result);
        }
    }

    [TestFixture]
    public class StringExtensionTest
    {
        [TestCase("Kathy")]
        public void SayHello(string name)
        {
            string sExpected = "Hello, Kathy!";

            string s = name.SayHello();

            Assert.AreEqual(sExpected, s);
        }

        [TestCase("Kathy")]
        public void SayGoodbye(string name)
        {
            string sExpected = "Goodbye, Kathy. See you again soon!";

            string s = name.SayGoodbye();

            Assert.AreEqual(sExpected, s);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}
