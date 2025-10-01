using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Homework Project.");

        Assignment assignment1 = new Assignment("Samuel Bennett", "Multiplication");
        string summary1 = assignment1.GetSummary();
        Console.WriteLine(summary1);
        Console.WriteLine();

        MathAssignment mathAssignment1 = new MathAssignment(
            "Roberto Rodriguez",
            "Fraction",
            "7.3",
            "8-19"
        );

        string summary2 = mathAssignment1.GetSummary();
        Console.WriteLine(summary2);

        string homeworkList = mathAssignment1.GetHomeworkList();
        Console.WriteLine(homeworkList);
        Console.WriteLine();

        WritingAssignment writingAssignment1 = new WritingAssignment(
            "Mary Waters",
            "European History",
            "The Causes of World War II"
        );

        string summary3 = writingAssignment1.GetSummary();
        Console.WriteLine(summary3);

        string writingInfo = writingAssignment1.GetwritingInformation();
        Console.WriteLine(writingInfo);
        Console.WriteLine();
    }
}