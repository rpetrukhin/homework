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
    public class BinarySearchTest
    {
        [Test]
        public void BinarySearchMethod_Test()
        {
            var binarySearch = new BinarySearch();

            int[] array = new int[10];
            for (int i = 0; i < 10; i++)
                array[i] = i;

            string s = "abcdefghijklmnop";

            Assert.That(binarySearch.BinarySearchMethod<int>(array, 5), Is.EqualTo(5));
            Assert.That(binarySearch.BinarySearchMethod<char>(s.ToCharArray(), 'h'), Is.EqualTo(7));
        }
    }
}