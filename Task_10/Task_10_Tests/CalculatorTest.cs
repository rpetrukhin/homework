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
    public class CalculatorTest
    {
        [TestCase("", 0)]
        [TestCase("1 2 +", 3)]
        [TestCase("5 1 2 + 4 * + 3 -", 14)]
        public void Calculate_Test(string expression, double resultExpected)
        {
            var calculator = new Calculator();

            double result = calculator.Calculate(expression);

            Assert.That(result, Is.EqualTo(resultExpected));
        }
    }
}