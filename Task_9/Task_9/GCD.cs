using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Task_9
{
    public class GCD
    {
        public int EuclideanAlgorithm(int a, int b)
        {
            int c;
            while (b != 0)
            {
                c = b;
                b = a % b;
                a = c;
            }
            return a;
        }

        public int SteinAlgorithm(int a, int b)
        {
            if (a == 0)
                return b;

            if (b == 0)
                return a;

            if (a == b)
                return a;

            if (a == 1 || b == 1)
                return 1;

            if ((a & 1) == 0)
            {
                if ((b & 1) == 0)
                    return SteinAlgorithm(a >> 1, b >> 1) << 1;
                else
                    return SteinAlgorithm(a >> 1, b);
            }
            else
            {
                if ((b & 1) == 0)
                    return SteinAlgorithm(a, b >> 1);
                else
                    return SteinAlgorithm(b, a > b ? a - b : b - a);
            }
        }

        public delegate int AlgorithmType(int a, int b);

        public Tuple<int, double> Computation(AlgorithmType algorithmType, params int[] numbers)
        {
            Stopwatch time = new Stopwatch();
            time.Start();

            if (numbers.Length < 2)
            {
                time.Stop();
                return Tuple.Create(-1, time.Elapsed.TotalMilliseconds);
            }

            int d = algorithmType(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length; i++)
            {
                d = algorithmType(numbers[i], d);
            }

            time.Stop();
            return Tuple.Create(Math.Abs(d), time.Elapsed.TotalMilliseconds);
        }
    }
}