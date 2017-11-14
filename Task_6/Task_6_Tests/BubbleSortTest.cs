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
    public class BubbleSortTest
    {
        [Test]
        public void Sort_IsCorrect()
        {
            //Arrange
            var bubblesort = new BubbleSort();

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

            var sortStrategy = new RowsSum();
            var orderOfSortStrategy = new Increasing();

            //Act
            int[,] matrixOut = bubblesort.Sort(matrix, sortStrategy, orderOfSortStrategy);

            //Assert
            Assert.That(matrixOut, Is.EqualTo(matrixExpected));
        }
    }
}
