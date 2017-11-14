using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    public interface ISortStrategy
    {
        int[] CreateRows(int[,] matrix, int n, int m);
    }

    public class RowsSum : ISortStrategy
    {
        public int[] CreateRows(int[,] matrix, int n, int m)
        {
            int[] rows = new int[n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    rows[i] += matrix[i, j];
            return rows;
        }
    }

    public class RowsMax : ISortStrategy
    {
        public int[] CreateRows(int[,] matrix, int n, int m)
        {
            int[] rows = new int[n];
            for (int i = 0; i < n; i++)
            {
                rows[i] = matrix[i, 0];
                for (int j = 0; j < m; j++)
                    if (matrix[i, j] > rows[i])
                        rows[i] = matrix[i, j];
            }
            return rows;
        }
    }

    public class RowsMin : ISortStrategy
    {
        public int[] CreateRows(int[,] matrix, int n, int m)
        {
            int[] rows = new int[n];
            for (int i = 0; i < n; i++)
            {
                rows[i] = matrix[i, 0];
                for (int j = 0; j < m; j++)
                    if (matrix[i, j] < rows[i])
                        rows[i] = matrix[i, j];
            }
            return rows;
        }
    }

    public interface IOrderOfSortStrategy
    {
        void SortRowsAndIndexes(int[] rows, int[] index);
    }

    public class Increasing : IOrderOfSortStrategy
    {
        private void Swapping(int[] array, int j)
        {
            int a;
            a = array[j];
            array[j] = array[j - 1];
            array[j - 1] = a;
        }

        public void SortRowsAndIndexes(int[] rows, int[] index)
        {
            for (int i = 0; i < rows.Length; i++)
                for (int j = 1; j < rows.Length; j++)
                    if (rows[j] < rows[j - 1])
                    {
                        Swapping(rows, j);
                        Swapping(index, j);
                    }
        }
    }

    public class Decreasing : IOrderOfSortStrategy
    {
        private void Swapping(int[] array, int j)
        {
            int a;
            a = array[j];
            array[j] = array[j - 1];
            array[j - 1] = a;
        }

        public void SortRowsAndIndexes(int[] rows, int[] index)
        {
            for (int i = 0; i < rows.Length; i++)
                for (int j = 1; j < rows.Length; j++)
                    if (rows[j] > rows[j - 1])
                    {
                        Swapping(rows, j);
                        Swapping(index, j);
                    }
        }
    }

    public class BubbleSort
    {
        public int[,] Sort(int[,] matrix, ISortStrategy sortStrategy, IOrderOfSortStrategy orderOfSortStrategy)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int[] rows = new int[n];
            int[] index = new int[n];

            for (int i = 0; i < n; i++)
                index[i] = i;

            rows = sortStrategy.CreateRows(matrix, n, m);

            orderOfSortStrategy.SortRowsAndIndexes(rows, index);

            int[,] matrixOut = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    matrixOut[i, j] = matrix[index[i], j];

            return matrixOut;
        }
    }
}