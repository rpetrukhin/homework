﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_9
{
    public class BubbleSort
    {
        private void Swapping(int[] array, int j)
        {
            int a;
            a = array[j];
            array[j] = array[j - 1];
            array[j - 1] = a;
        }

        public int[] RowsSum(int[,] matrix, int n, int m)
        {
            int[] rows = new int[n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    rows[i] += matrix[i, j];
            return rows;
        }

        public int[] RowsMax(int[,] matrix, int n, int m)
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

        public int[] RowsMin(int[,] matrix, int n, int m)
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

        public void SortRowsInAscending(int[] rows, int[] index)
        {
            for (int i = 0; i < rows.Length; i++)
                for (int j = 1; j < rows.Length; j++)
                    if (rows[j] < rows[j - 1])
                    {
                        Swapping(rows, j);
                        Swapping(index, j);
                    }
        }

        public void SortRowsInDescending(int[] rows, int[] index)
        {
            for (int i = 0; i < rows.Length; i++)
                for (int j = 1; j < rows.Length; j++)
                    if (rows[j] > rows[j - 1])
                    {
                        Swapping(rows, j);
                        Swapping(index, j);
                    }
        }

        public delegate int[] StrategyOfSort(int[,] matrix, int n, int m);

        public delegate void OrderOfSort(int[] rows, int[] index);

        public int[,] Sort(int[,] matrix, StrategyOfSort strategyOfSort, OrderOfSort orderOfSort)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int[] rows = new int[n];
            int[] index = new int[n];

            for (int i = 0; i < n; i++)
                index[i] = i;

            rows = strategyOfSort(matrix, n, m);

            orderOfSort(rows, index);

            int[,] matrixOut = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    matrixOut[i, j] = matrix[index[i], j];

            return matrixOut;
        }
    }
}