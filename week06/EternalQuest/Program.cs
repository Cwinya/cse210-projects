using System;

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