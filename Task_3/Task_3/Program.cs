using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    public enum Choice
    {
        Sum,
        Min,
        Max
    }

    public enum OrderOfSort
    {
        Increasing,
        Decreasing
    }

    public class NthRoot
    {
        private double init;
        private double eps;

        public NthRoot(double init, double eps)
        {
            this.init = init;
            this.eps = eps;
        }

        private double Pow(double x, uint n)
        {
            for (int i = 1; i < n; i++)
                x *= x;
            return x;
        }

        public double? NewtonMethod(double number, uint n)
        {
            if (n == 0)
                return null;

            if (number < 0 && n % 2 == 0)
                return null;

            double x;
            double y = init;
            do
            {
                x = y;
                y = 1.0 / n * ((n - 1) * x + number / Pow(x, n - 1));
            } while (Math.Abs(x - y) > eps);
            return y;
        }

        public void Test(double number, uint n)
        {
            Console.WriteLine("Newton's method = " + NewtonMethod(number, n));
            Console.WriteLine("Math.Pow method = " + Math.Pow(number, 1.0 / n));
        }
    }

    public class BubbleSort
    {
        private void Swapping(int[] array, int j)
        {
            int a;
            a = array[j];
            array[j] = array[j - 1];
            array[j - 1] = a;
        }

        private int[] RowsSum(int[,] matrix, int n, int m)
        {
            int[] rows = new int[n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    rows[i] += matrix[i, j];
            return rows;
        }

        private int[] RowsMax(int[,] matrix, int n, int m)
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

        private int[] RowsMin(int[,] matrix, int n, int m)
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

        public int[,] Sort(int[,] matrix, Choice choice, OrderOfSort orderOfSort)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int[] rows = new int[n];
            int[] index = new int[n];

            for (int i = 0; i < n; i++)
                index[i] = i;

            switch(choice)
            {
                case Choice.Sum:
                    rows = RowsSum(matrix, n, m);
                    break;
                case Choice.Max:
                    rows = RowsMax(matrix, n, m);
                    break;
                case Choice.Min:
                    rows = RowsMin(matrix, n, m);
                    break;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (orderOfSort == OrderOfSort.Increasing)
                    {
                        if (rows[j] < rows[j - 1])
                        {
                            Swapping(rows, j);
                            Swapping(index, j);
                        }
                    }
                    else
                    {
                        if (rows[j] > rows[j - 1])
                        {
                            Swapping(rows, j);
                            Swapping(index, j);
                        }
                    }
                }
            }

            int[,] matrixOut = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    matrixOut[i, j] = matrix[index[i], j];

            return matrixOut;
        }

        public void Test(int[,] matrix, Choice choice, OrderOfSort orderOfSort)
        {
            Console.WriteLine("Matrix:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j] + "   ");

                Console.WriteLine();
            }

            int[,] matrixOut = Sort(matrix, choice, orderOfSort);

            Console.WriteLine("Sorted matrix:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrixOut[i, j] + "   ");

                Console.WriteLine();
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            NthRoot nthRoot = new NthRoot(8.0, 0.01);
            nthRoot.Test(8.0, 3);

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
            bubblesort.Test(matrix, Choice.Sum, OrderOfSort.Increasing);
        }
    }
}