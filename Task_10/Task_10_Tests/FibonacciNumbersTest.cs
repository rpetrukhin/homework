using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task_10;

namespace Task_10_Tests
{
    [TestFixture]
    public class FibonacciNumbersTest
    {
        [Test]
        public void Recording_Test()
        {
            var fibonacciNumbers = new FibonacciNumbers();
            int[] numbersExpected = new int[10] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 };

            int[] numbers = fibonacciNumbers.Recording(10);

            Assert.That(numbers, Is.EqualTo(numbersExpected));
        }
    }
}