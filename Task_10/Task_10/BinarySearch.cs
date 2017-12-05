using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10
{
    public class BinarySearch
    {
        public int BinarySearchMethod<T>(T[] array, T x) where T : IComparable
        {
            if (array == null || x == null)
                return -1;

            Array.Sort(array);

            if ((array.Length == 0) || (x.CompareTo(array[0]) == -1) || (x.CompareTo(array[array.Length - 1]) == 1))
                return -1;

            int first = 0;
            int last = array.Length;
            int mid;

            while (first < last)
            {
                mid = first + (last - first) / 2;

                if (x.CompareTo(array[mid]) <= 0)
                    last = mid;
                else
                    first = mid + 1;
            }

            if (array[last].CompareTo(x) == 0)
                return last;
            else
                return -1;
        }
    }
}