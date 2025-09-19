using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Fractions Project.");
        // Using first constructor
        Fractions fraction1 = new Fractions();
        Console.WriteLine($"The default fraction is: {fraction1.GetFractionString()}");
        Console.WriteLine($"The decimal value is: {fraction1.GetDecimalValue()}");

        // Using second constructor
        Fractions fraction2 = new Fractions(5);
        Console.WriteLine($"The fraction with top 5 is: {fraction2.GetFractionString()}");
        Console.WriteLine($"The decimal value is: {fraction2.GetDecimalValue()}");

        // Using third constructor
        Fractions fraction3 = new Fractions(3, 4);
        Console.WriteLine($"The fraction with top 3 and bottom 4 is: {fraction3.GetFractionString()}");
        Console.WriteLine($"The decimal value is: {fraction3.GetDecimalValue()}");

        // Another test(1/3)
        Fractions fraction4 = new Fractions(1, 3);
        Console.WriteLine($"The fraction with top 1 and bottom 3 is: {fraction4.GetFractionString()}");
        Console.WriteLine($"The decimal value is: {fraction4.GetDecimalValue()}");

        // Test with setters and getters
        fraction4.SetTop(2);
        fraction4.SetBottom(5);
        Console.WriteLine($"After setting new values, the fraction is: {fraction4.GetFractionString()}");
        Console.WriteLine($"The new decimal value is: {fraction4.GetDecimalValue()}");
    }
}