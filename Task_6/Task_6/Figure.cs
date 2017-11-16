using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    public struct Point
    {
        public double x;
        public double y;
    }

    public abstract class Figure
    {
        public abstract double Area();
        public abstract double Perimeter();
    }

    public class Circle : Figure
    {
        private Point _center;
        private double _radius;

        public Circle(Point center, double radius)
        {
            _center = center;
            _radius = radius;
        }

        public override double Area()
        {
            return Math.PI * Math.Pow(_radius, 2.0);
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * _radius;
        }
    }

    public class Triangle : Figure
    {
        private Point[] _points;

        public Triangle(Point p0, Point p1, Point p2)
        {
            _points = new Point[3];
            _points[0] = p0;
            _points[1] = p1;
            _points[2] = p2;
        }

        public override double Area()
        {
            return 0.0;
        }

        public override double Perimeter()
        {
            return 0.0;
        }
    }

    public class Rectangle : Figure
    {
        protected double a;
        protected double b;

        //p0 - upper left point
        //p1 - upper right point
        //p2 - lower right point
        public Rectangle(Point p0, Point p1, Point p2)
        {
            a = p1.x - p0.x;
            b = p1.y - p2.y;
        }

        public override double Area()
        {
            return a * b;
        }

        public override double Perimeter()
        {
            return 2 * (a + b);
        }
    }

    public class Square : Rectangle
    {
        private double _c;

        //p0 - upper left point
        //p1 - upper right point
        //p2 - lower right point
        public Square(Point p0, Point p1, Point p2) : base(p0 , p1, p2)
        {
            if (a == b)
            {
                _c = a;
            }
            else
                throw new Exception("It's not a square");
        }

        public override double Area()
        {
            return Math.Pow(_c, 2.0);
        }

        public override double Perimeter()
        {
            return 4 * _c;
        }
    }
}