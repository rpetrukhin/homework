using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task_3;

namespace Task_3_Tests
{
    [TestFixture]
    public class NthRootTest
    {
        [TestCase(8.0, (uint)3)]
        public void NewtonMethod(double number, uint n)
        {
            NthRoot nthRoot = new NthRoot(8.0, 0.01);

            double? result = nthRoot.NewtonMethod(number, n);
            double resultExpected = Math.Pow(number, 1.0 / n);

            Assert.True(Math.Abs((result ?? 0.0) - resultExpected) < 0.01);
        }
    }

    [TestFixture]
    public class BubbleSortTest
    {
        [Test]
        public void Sort()
        {
            //Arrange
            BubbleSort bubblesort = new BubbleSort();

            int[,] matrix = new int[3, 3];
            matrix[0, 0] = 3;
            matrix[0, 1] = 3;
            matrix[0, 2] = 3;
            matrix[1, 0] = 2;
            matrix[1, 1] = 2;
            matrix[1, 2] = 2;
            matrix[2, 0] = 1;
            matrix[2, 1] = 1;
            matrix[2, 2] = 1;

            int[,] matrixExpected = new int[3, 3];
            matrixExpected[0, 0] = 1;
            matrixExpected[0, 1] = 1;
            matrixExpected[0, 2] = 1;
            matrixExpected[1, 0] = 2;
            matrixExpected[1, 1] = 2;
            matrixExpected[1, 2] = 2;
            matrixExpected[2, 0] = 3;
            matrixExpected[2, 1] = 3;
            matrixExpected[2, 2] = 3;

            //Act
            int [,] matrixOut = bubblesort.Sort(matrix, Choice.Sum, OrderOfSort.Increasing);

            //Assert
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Assert.AreEqual(matrixExpected[i, j], matrixOut[i, j]);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}