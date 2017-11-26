using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10
{
    public struct Point : IComparable<Point>
    {
        private int _x;
        private int _y;

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int CompareTo(Point another)
        {
            var xComparison = _x.CompareTo(another._x);

            if (xComparison != 0)
                return xComparison;

            return _y.CompareTo(another._y);
        }
    }
}