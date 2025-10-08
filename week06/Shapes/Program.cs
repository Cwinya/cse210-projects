using System;
using System.Collections.Generic;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step: Test the Square class (Part of the instructions)
            // Square testSquare = new Square("Blue", 5.0);
            // Console.WriteLine($"Test Square Color: {testSquare.GetColor()}"); // Expected: Blue
            // Console.WriteLine($"Test Square Area: {testSquare.GetArea()}");  // Expected: 25.0

            // Step: Test the Rectangle and Circle classes (Part of the instructions)
            // Rectangle testRect = new Rectangle("Green", 4.0, 6.0);
            // Console.WriteLine($"Test Rectangle Color: {testRect.GetColor()}"); // Expected: Green
            // Console.WriteLine($"Test Rectangle Area: {testRect.GetArea()}");   // Expected: 24.0

            // Circle testCircle = new Circle("Red", 3.0);
            // Console.WriteLine($"Test Circle Color: {testCircle.GetColor()}"); // Expected: Red
            // Console.WriteLine($"Test Circle Area: {testCircle.GetArea()}");   // Expected: Approx 28.27

            // -----------------------------------------------------------------

            // Step: Build a List and demonstrate Polymorphism

            // Create a list to hold shapes (List<Shape>)
            List<Shape> shapes = new List<Shape>();

            // Add different shapes to the list
            shapes.Add(new Square("Red", 4.0));
            shapes.Add(new Rectangle("Blue", 5.0, 8.0));
            shapes.Add(new Circle("Yellow", 2.5));
            shapes.Add(new Square("Green", 10.0));
            shapes.Add(new Rectangle("Purple", 3.0, 7.0));

            Console.WriteLine("--- Polymorphism Demonstration ---");
            Console.WriteLine("Iterating through a list of 'Shape' objects:");
            Console.WriteLine("----------------------------------");

            // Iterate through the list of shapes
            foreach (Shape shape in shapes)
            {
                // Polymorphism in action: 
                // The correct GetArea() method (Square, Rectangle, or Circle)
                // is called automatically based on the object's actual type.
                string typeName = shape.GetType().Name; // Get the actual class name for display

                Console.WriteLine($"Shape Type: \t{typeName}");
                Console.WriteLine($"Color: \t\t{shape.GetColor()}");
                Console.WriteLine($"Area: \t\t{shape.GetArea():F2}"); // :F2 formats to 2 decimal places
                Console.WriteLine("----------------------------------");
            }
        }
    }
}