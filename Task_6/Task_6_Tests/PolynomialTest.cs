using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task_6;

namespace Task_6_Tests
{
    [TestFixture]
    public class PolynomialTest
    {
        [Test]
        public void Polynomial_ExceptionIsCorrect()
        {
            var ex = Assert.Throws<Exception>(() => new Polynomial(1));

            Assert.That(ex.Message, Is.EqualTo("It's a polynomial with degree smaller than 1"));
        }

        [Test]
        public void OperatorEquals_IsCorrect()
        {
            var polynomFirst = new Polynomial(3, 1, 2);
            var polynomSecond = new Polynomial(3, 1, 2);

            Assert.That(polynomFirst == polynomSecond, Is.EqualTo(true));
        }

        [Test]
        public void OperatorPlus_SumIsCorrect()
        {
            var polynomFirst = new Polynomial(3, 1, 2);
            var polynomSecond = new Polynomial(4, 4, 1, 5, 7);
            var polynomExpected = new Polynomial(4, 4, 4, 6, 9);

            var polynom = polynomFirst + polynomSecond;

            Assert.That(polynom == polynomExpected, Is.EqualTo(true));
        }

        [Test]
        public void OperatorPlus_ThrowsException()
        {
            var polynomFirst = new Polynomial(Int32.MaxValue, 1, 2);
            var polynomSecond = new Polynomial(4, 4, Int32.MaxValue, 5, 7);

            Assert.That(() => polynomFirst + polynomSecond, Throws.Exception);
        }

        [Test]
        public void OperatorMinus_ResidualIsCorrect()
        {
            var polynomFirst = new Polynomial(3, 1, 2);
            var polynomSecond = new Polynomial(4, 4, 1, 5, 7);
            var polynomExpected = new Polynomial(-4, -4, 2, -4, -5);

            var polynom = polynomFirst - polynomSecond;

            Assert.That(polynom == polynomExpected, Is.EqualTo(true));
        }

        [Test]
        public void OperatorMinus_ThrowsException()
        {
            var polynomFirst = new Polynomial(-5, 1, 2);
            var polynomSecond = new Polynomial(4, 4, Int32.MaxValue, 5, 7);

            Assert.That(() => polynomFirst - polynomSecond, Throws.Exception);
        }

        [Test]
        public void OperatorMultiplication_CompositionIsCorrect()
        {
            var polynomFirst = new Polynomial(3, 1, 2);
            var polynomSecond = new Polynomial(4, 4, 1, 5, 7);
            var polynomExpected = new Polynomial(12, 16, 15, 24, 28, 17, 14);

            var polynom = polynomFirst * polynomSecond;

            Assert.That(polynom == polynomExpected, Is.EqualTo(true));
        }

        [Test]
        public void OperatorMultiplication_ThrowsException()
        {
            var polynomFirst = new Polynomial(Int32.MaxValue, 1, 2);
            var polynomSecond = new Polynomial(4, 4, Int32.MaxValue, 5, 7);

            Assert.That(() => polynomFirst * polynomSecond, Throws.Exception);
        }
    }
}