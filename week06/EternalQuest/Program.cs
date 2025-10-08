using System;
// I created a NegativeGoal.cs program that tracks bad habits, resulting in a loss of points when recorded then deducts points from the total score.
// This is for the stretch challenge activity

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the EternalQuest Project.");
        Console.Clear();
        Console.WriteLine("Welcome to the Eternal Quest Program!");

        // Instantiate the GoalManager and start the application loop
        GoalManager manager = new GoalManager();
        manager.StartProgram();
    }
}