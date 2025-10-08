namespace Shapes
{
    public class Square : Shape
    {
        // Private member variable for the side length
        private double _side;

        // Constructor calls the base class constructor with color
        public Square(string color, double side) : base(color)
        {
            _side = side;
        }

        // Override the GetArea() method
        public override double GetArea()
        {
            // Area of a square is side * side
            return _side * _side;
        }
    }
}