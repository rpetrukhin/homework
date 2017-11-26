using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task_9;

namespace Task_9_Tests
{
    [TestFixture]
    public class GCDTest
    {
        [TestCase(6, 78, 294, 570, 36)]
        public void Computation_EuclideanAlgorithmTest(int resultExpected, params int[] numbers)
        {
            GCD gcd = new GCD();
            GCD.AlgorithmType algorythmType = gcd.EuclideanAlgorithm;

            int result = gcd.Computation(algorythmType, numbers).Item1;

            Assert.AreEqual(resultExpected, result);
        }

        [TestCase(6, 78, 294, 570, 36)]
        public void Computation_SteinAlgorithmTest(int resultExpected, params int[] numbers)
        {
            GCD gcd = new GCD();
            GCD.AlgorithmType algorythmType = gcd.SteinAlgorithm;

            int result = gcd.Computation(algorythmType, numbers).Item1;

            Assert.AreEqual(resultExpected, result);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}
