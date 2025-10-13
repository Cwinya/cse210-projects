using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ExerciseTracking Project.");
        // Create a list to hold all activities (requires using System.Collections.Generic)
        // Note: The classes Running, StationaryBicycles, and Swimming are available
        // because they are defined in the same project/namespace.
        List<Activity> activities = new List<Activity>();

        // Create at least one activity of each type
        activities.Add(new Running(new DateTime(2025, 10, 8), 30, 4.8));
        activities.Add(new StationaryBicycles(new DateTime(2025, 10, 9), 45, 20.0));
        activities.Add(new Swimming(new DateTime(2025, 10, 10), 60, 40));

        Console.WriteLine("--- Exercise Activity Summary ---");

        // Iterate through the list and call the GetSummary method on each item
        foreach (Activity activity in activities)
        {
            string summary = activity.GetSummary();
            Console.WriteLine(summary);
        }

        Console.WriteLine("---------------------------------");
    }
}