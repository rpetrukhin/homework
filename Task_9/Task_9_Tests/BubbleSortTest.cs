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
    public class BubbleSortTest
    {
        public static IEnumerable<TestCaseData> DataSource
        {
            get
            {
                yield return new TestCaseData(new BubbleSort.StrategyOfSort(new BubbleSort().RowsSum), new BubbleSort.OrderOfSort(new BubbleSort().SortRowsInAscending), new int[3, 3] { { 1, 1, 1 }, { 2, 2, 2 }, { 3, 3, 3 } }).SetName("Sort_IsCorrect_RowsSum_Ascending");

                yield return new TestCaseData(new BubbleSort.StrategyOfSort(new BubbleSort().RowsMax), new BubbleSort.OrderOfSort(new BubbleSort().SortRowsInAscending), new int[3, 3] { { 1, 1, 1 }, { 2, 2, 2 }, { 3, 3, 3 } }).SetName("Sort_IsCorrect_RowsMax_Ascending");

                yield return new TestCaseData(new BubbleSort.StrategyOfSort(new BubbleSort().RowsMin), new BubbleSort.OrderOfSort(new BubbleSort().SortRowsInAscending), new int[3, 3] { { 1, 1, 1 }, { 2, 2, 2 }, { 3, 3, 3 } }).SetName("Sort_IsCorrect_RowsMin_Ascending");

                yield return new TestCaseData(new BubbleSort.StrategyOfSort(new BubbleSort().RowsSum), new BubbleSort.OrderOfSort(new BubbleSort().SortRowsInDescending), new int[3, 3] { { 3, 3, 3 }, { 2, 2, 2 }, { 1, 1, 1 } }).SetName("Sort_IsCorrect_RowsSum_Descending");

                yield return new TestCaseData(new BubbleSort.StrategyOfSort(new BubbleSort().RowsMax), new BubbleSort.OrderOfSort(new BubbleSort().SortRowsInDescending), new int[3, 3] { { 3, 3, 3 }, { 2, 2, 2 }, { 1, 1, 1 } }).SetName("Sort_IsCorrect_RowsMax_Descending");

                yield return new TestCaseData(new BubbleSort.StrategyOfSort(new BubbleSort().RowsMin), new BubbleSort.OrderOfSort(new BubbleSort().SortRowsInDescending), new int[3, 3] { { 3, 3, 3 }, { 2, 2, 2 }, { 1, 1, 1 } }).SetName("Sort_IsCorrect_RowsMin_Descending");
            }
        }

        [TestCaseSource(nameof(DataSource))]
        public void Sort_IsCorrect(BubbleSort.StrategyOfSort strategyOfSort, BubbleSort.OrderOfSort orderOfSort, int[,] matrixExpected)
        {
            //Arrange
            var bubblesort = new BubbleSort();

            int[,] matrix = new int[3, 3] { { 3, 3, 3 }, { 2, 2, 2 }, { 1, 1, 1 } };

            //Act
            int[,] matrixOut = bubblesort.Sort(matrix, strategyOfSort, orderOfSort);

            //Assert
            Assert.That(matrixOut, Is.EqualTo(matrixExpected));
        }
    }
}