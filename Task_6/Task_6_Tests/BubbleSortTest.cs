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
        public static IEnumerable<TestCaseData> DataSource
        {
           get
            {
                yield return new TestCaseData(new RowsSum(), new Increasing(), new int[3, 3] { { 1, 1, 1 }, { 2, 2, 2 }, { 3, 3, 3 } }).SetName("Sort_IsCorrect_RowsSum_Increasing");

                yield return new TestCaseData(new RowsMax(), new Increasing(), new int[3, 3] { { 1, 1, 1 }, { 2, 2, 2 }, { 3, 3, 3 } }).SetName("Sort_IsCorrect_RowsMax_Increasing");

                yield return new TestCaseData(new RowsMin(), new Increasing(), new int[3, 3] { { 1, 1, 1 }, { 2, 2, 2 }, { 3, 3, 3 } }).SetName("Sort_IsCorrect_RowsMin_Increasing");

                yield return new TestCaseData(new RowsSum(), new Decreasing(), new int[3, 3] { { 3, 3, 3 }, { 2, 2, 2 }, { 1, 1, 1 } }).SetName("Sort_IsCorrect_RowsSum_Decreasing");

                yield return new TestCaseData(new RowsMax(), new Decreasing(), new int[3, 3] { { 3, 3, 3 }, { 2, 2, 2 }, { 1, 1, 1 } }).SetName("Sort_IsCorrect_RowsMax_Decreasing");

                yield return new TestCaseData(new RowsMin(), new Decreasing(), new int[3, 3] { { 3, 3, 3 }, { 2, 2, 2 }, { 1, 1, 1 } }).SetName("Sort_IsCorrect_RowsMin_Decreasing");
            }
        }

        [TestCaseSource(nameof(DataSource))]
        public void Sort_IsCorrect(ISortStrategy sortStrategy, IOrderOfSortStrategy orderOfSortStrategy, int[,] matrixExpected)
        {
            //Arrange
            var bubblesort = new BubbleSort();

            int[,] matrix = new int[3, 3] { { 3, 3, 3 }, { 2, 2, 2 }, { 1, 1, 1 } };

            //Act
            int[,] matrixOut = bubblesort.Sort(matrix, sortStrategy, orderOfSortStrategy);

            //Assert
            Assert.That(matrixOut, Is.EqualTo(matrixExpected));
        }
    }
}