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
        protected Point[] points;
        public abstract double Area();
        public abstract double Perimeter();
    }

    public class Circle : Figure
    {
        private double _radius;

        public Circle(Point center, double radius)
        {
            points = new Point[1];
            points[0] = center;
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
        public Triangle(Point[] points)
        {
            if (points.Length == 3)
                this.points = points;
            else
                throw new Exception("It's not a triangle");
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

        public Rectangle(Point[] points)
        {
            if (points.Length == 4)
            {
                this.points = points;
                a = points[1].x - points[0].x;
                b = points[2].y - points[1].y;
            }
            else
                throw new Exception("It's not a rectangle");
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

        public Square(Point[] points) : base(points)
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