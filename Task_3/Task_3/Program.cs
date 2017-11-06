using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    public class NthRoot
    {
        public double init;
        public double eps;

        public NthRoot(double init, double eps)
        {
            this.init = init;
            this.eps = eps;
        }

        public double Pow(double x, int n)
        {
            for (int i = 1; i < n; i++)
                x *= x;
            return x;
        }

        public double NewtonMethod(double number, int n)
        {
            double x;
            double y = init;
            do
            {
                x = y;
                y = 1.0 / n * ((n - 1) * x + number / Pow(x, n - 1));
            } while (Math.Abs(x - y) > eps);
            return y;
        }

        public void Test()
        {
            Console.WriteLine("Newton's method = " + NewtonMethod(8.0, 3));
            Console.WriteLine("Math.Pow method = " + Math.Pow(8.0, 1.0 / 3.0));
        }
    }

    public class BubbleSort
    {
        public int[,] Sort(int[,] matrix, int n, int m, string choice, string orderOfSort)
        {

            int[] rows = new int[n];
            int[] index = new int[n];

            for (int i = 0; i < n; i++)
                index[i] = i;

            switch(choice)
            {
                case "sum":
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < m; j++)
                            rows[i] += matrix[i, j];
                    break;
                case "max":
                    for (int i = 0; i < n; i++)
                    {
                        rows[i] = matrix[i, 0];
                        for (int j = 0; j < m; j++)
                            if (matrix[i, j] > rows[i])
                                rows[i] = matrix[i, j];
                    }
                    break;
                case "min":
                    for (int i = 0; i < n; i++)
                    {
                        rows[i] = matrix[i, 0];
                        for (int j = 0; j < m; j++)
                            if (matrix[i, j] < rows[i])
                                rows[i] = matrix[i, j];
                    }
                    break;
            }

            switch (orderOfSort)
            {
                case "increasing":
                    int a;
                    for (int i = 0; i < n; i++)
                        for (int j = 1; j < n; j++)
                            if (rows[j] < rows[j - 1])
                            {
                                a = rows[j];
                                rows[j] = rows[j - 1];
                                rows[j - 1] = a;

                                a = index[j];
                                index[j] = index[j - 1];
                                index[j - 1] = a;
                            }
                    break;
                case "decreasing":
                    for (int i = 0; i < n; i++)
                        for (int j = 1; j < n; j++)
                            if (rows[j] > rows[j - 1])
                            {
                                a = rows[j];
                                rows[j] = rows[j - 1];
                                rows[j - 1] = a;

                                a = index[j];
                                index[j] = index[j - 1];
                                index[j - 1] = a;
                            }
                    break;
            }

            int[,] matrixOut = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    matrixOut[i, j] = matrix[index[i], j];

            return matrixOut;
        }

        public void Test()
        {
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

            Console.WriteLine("Matrix:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    Console.Write(matrix[i, j] + "   ");

                Console.WriteLine();
            }

            int[,] matrixOut = Sort(matrix, 3, 3, "sum", "increasing");

            Console.WriteLine("Sorted matrix:");
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
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
            nthRoot.Test();
            BubbleSort bubblesort = new BubbleSort();
            bubblesort.Test();
        }
    }
}