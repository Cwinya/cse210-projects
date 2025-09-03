using System;

class Program
{
    static void Main(string[] args)
    {
        /*
        Ask the user for a series of numbers, and append each one to a list. Stop when they enter 0. (Remember: You should not add 0 to the list. If you do, later calculations and operations will not be correct.)

        Once you have a list, have your program do the following:
        Compute the sum, or total, of the numbers in the list.

        Compute the average of the numbers in the list.

        Find the maximum, or largest, number in the list.
        */
        /*
        Have the user enter both positive and negative numbers, then find the smallest positive number (the positive number that is closest to zero).

        Sort the numbers in the list and display the new, sorted list. Hint: There are C# libraries that can help you here, try searching the internet for them.
        */
        Console.WriteLine("Hello World! This is the Exercise4 Project.");
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a series of numbers, and enter 0 when finished: ");
        int input;
        while (true)
        {
            input = int.Parse(Console.ReadLine());
            if (input == 0) break;
            numbers.Add(input);
        }
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        double average = (double)sum / numbers.Count;
        int max = numbers[0];
        foreach (int num in numbers)
        {
            if (num > max) max = num;
        }
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        /*
        Have the user enter both positive and negative numbers, then find the smallest positive number (the positive number that is closest to zero).

        Sort the numbers in the list and display the new, sorted list. Hint: There are C# libraries that can help you here, try searching the internet for them
        */
        int? smallestPositive = null;
        foreach (int num in numbers)
        {
            if (num > 0 && (smallestPositive == null || num < smallestPositive))
            {
                smallestPositive = num;
            }
        }
        if (smallestPositive != null)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        numbers.Sort();
        Console.WriteLine("The sorted list is: ");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}