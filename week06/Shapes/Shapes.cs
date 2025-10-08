namespace Shapes
{
    public class Shape
    {
        // Private member variable for color
        private string _color;

        // Constructor
        public Shape(string color)
        {
            _color = color;
        }

        // Getter for color
        public string GetColor()
        {
            return _color;
        }

        // Setter for color
        public void SetColor(string color)
        {
            _color = color;
        }

        // Virtual method for GetArea().
        // Derived classes will override this to provide specific area calculations.
        public virtual double GetArea()
        {
            // Base class implementation returns 0.0 as a default.
            return 0.0;
        }
    }
}