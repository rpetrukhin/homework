using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10
{
    public class FibonacciNumbers
    {
        private IEnumerable<int> Count(uint n)
        {
            int a = 1;
            int b = 1;
            int c;

            yield return a;

            if (n == 1)
                yield break;

            yield return b;

            for (uint i = 3; i <= n; i++)
            {
                c = a + b;
                yield return c;
                a = b;
                b = c;
            }
        }

        public int[] Recording(uint n)
        {
            if (n == 0)
                return new int[1] { 0 };

            int[] numbers = new int[n];
            int i = 0;

            foreach(int number in Count(n))
            {
                numbers[i] = number;
                i++;
            }

            return numbers;
        }
    }
}