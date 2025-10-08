using System;

namespace Shapes
{
    public class Circle : Shape
    {
        // Private member variable for the radius
        private double _radius;

        // Constructor calls the base class constructor with color
        public Circle(string color, double radius) : base(color)
        {
            _radius = radius;
        }

        // Override the GetArea() method
        public override double GetArea()
        {
            // Area of a circle is $\pi * r^2$
            return Math.PI * _radius * _radius;
        }
    }
}