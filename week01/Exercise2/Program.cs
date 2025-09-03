using System;

class Program
{
    static void Main(string[] args)
    {
        /*Add to your code the ability to include a "+" or "-" next to the letter grade, such as B+ or A-. For each grade, you'll know it is a "+" if the last digit is >= 7. You'll know it is a minus if the last digit is < 3 and otherwise it has no sign.

        After your logic to determine the grade letter, add another section to determine the sign. Save this sign into a variable. Then, display both the grade letter and the sign in one print statement.

        Hint: To get the last digit, you could divide the number by 10, and get the remainder. You might review the standard math operators and find the one that does division and gives you the remainder.

        At this point, don't worry about the exceptional cases of A+, F+, or F-.

        Recognize that there is no A+ grade, only A and A-. Add some additional logic to your program to detect this case and handle it correctly.

        Similarly, recognize that there is no F+ or F- grades, only F. Add additional logic to your program to detect these cases and handle them correctly.
        Console.WriteLine("Hello World! This is the Exercise2 Project.");
        */
        Console.Write("What is your grade? ");
        string gradeInput = Console.ReadLine();
        int grade = int.Parse(gradeInput);
        string letter = "";
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        if (grade >= 70)
        {
            Console.WriteLine($"You received a {letter}.");
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Unfortunately, you did not pass. Better luck next time!");
        }

        string sign = "";
        int lastDigit = grade % 10;
        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }

        if (letter == "A" && sign == "+")
        {
            sign = "";
        }
        else if (letter == "F")
        {
            sign = "";
        }

        Console.WriteLine($"You received a {letter}{sign}.");
    }
}