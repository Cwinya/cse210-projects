using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/// <summary>
/// Manages the goals, score, and user interaction.
/// Implements abstraction by handling file I/O and goal creation internally.
/// </summary>
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    /// <summary>
    /// Constructor: Initializes the goal list and score.
    /// </summary>
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    // Private helper method to determine the user's level based on their score (Exceeding Requirement: Gamification)
    private (int level, string title) GetLevelTitle()
    {
        if (_score >= 10000) return (4, "Eternal Voyager");
        if (_score >= 5000) return (3, "Quest Knight");
        if (_score >= 1000) return (2, "Diligent Disciple");
        return (1, "Apprentice Seeker");
    }

    /// <summary>
    /// Displays the user's current score and gamification level/title.
    /// </summary>
    public void DisplayPlayerInfo()
    {
        (int level, string title) = GetLevelTitle();
        Console.WriteLine($"\n*** Current Score: {_score} points ***");
        Console.WriteLine($"*** Level {level}: {title} ***\n");
    }

    /// <summary>
    /// Main menu loop for the program.
    /// </summary>
    public void StartProgram()
    {
        int choice = 0;
        LoadGoals(); // Attempt to load goals at startup

        while (choice != 6)
        {
            DisplayPlayerInfo();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1: CreateGoal(); break;
                    case 2: ListGoalDetails(); break;
                    case 3: SaveGoals(); break;
                    case 4: LoadGoals(); break;
                    case 5: RecordEvent(); break;
                    case 6: Console.WriteLine("\nFarewell on your Eternal Quest!"); break;
                    default: Console.WriteLine("Invalid choice. Please try again."); break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
            Console.WriteLine(); // Add a blank line for spacing
        }
    }

    /// <summary>
    /// Iterates through the goal list and displays the details for each goal.
    /// Leverages polymorphism by calling the GetDetailsString() method of each goal object.
    /// </summary>
    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe Goals are:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("You currently have no goals. Create one!");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            // Polymorphic call to the derived class's GetDetailsString() method
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    /// <summary>
    /// Prompts the user to create a new goal of a selected type.
    /// </summary>
    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal (Bonus: Lose points for bad habits)");

        Console.Write("Which type of goal would you like to create? ");
        if (!int.TryParse(Console.ReadLine(), out int typeChoice) || typeChoice < 1 || typeChoice > 4)
        {
            Console.WriteLine("Invalid goal type choice.");
            return;
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write($"What is the base point value associated with this goal (positive value only)? ");
        if (!int.TryParse(Console.ReadLine(), out int points) || points <= 0)
        {
            Console.WriteLine("Invalid point value. Must be a positive number.");
            return;
        }

        switch (typeChoice)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case 2:
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case 3:
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                if (!int.TryParse(Console.ReadLine(), out int target) || target <= 0)
                {
                    Console.WriteLine("Invalid target amount. Must be a positive number.");
                    return;
                }
                Console.Write("What is the bonus amount for completing it? ");
                if (!int.TryParse(Console.ReadLine(), out int bonus) || bonus <= 0)
                {
                    Console.WriteLine("Invalid bonus amount. Must be a positive number.");
                    return;
                }
                _goals.Add(new ChecklistGoal(name, description, points, bonus, target));
                break;
            case 4:
                // Negative goal creation (Exceeding requirement)
                _goals.Add(new NegativeGoal(name, description, points));
                break;
        }
        Console.WriteLine($"\nGoal '{name}' successfully created.");
    }

    /// <summary>
    /// Prompts the user to select a goal and records an event for it.
    /// Leverages polymorphism by calling the RecordEvent() method of the selected goal object.
    /// </summary>
    public void RecordEvent()
    {
        ListGoalDetails();

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record an event for.");
            return;
        }

        Console.Write("Which goal did you accomplish/fail? ");
        if (!int.TryParse(Console.ReadLine(), out int goalIndex) || goalIndex < 1 || goalIndex > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal selectedGoal = _goals[goalIndex - 1];
        // Polymorphic call to the derived class's RecordEvent() method
        int pointsEarned = selectedGoal.RecordEvent();

        if (pointsEarned != 0)
        {
            _score += pointsEarned;
            Console.WriteLine($"You now have {_score} points.");
        }
    }

    /// <summary>
    /// Saves the current score and all goals to a file.
    /// </summary>
    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                // Write the score first
                outputFile.WriteLine(_score);

                // Write each goal using its specific string representation
                foreach (Goal goal in _goals)
                {
                    // Polymorphic call to the derived class's GetStringRepresentation()
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine($"\nGoals successfully saved to '{filename}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nAn error occurred while saving: {ex.Message}");
        }
    }

    /// <summary>
    /// Loads the score and goals from a file.
    /// </summary>
    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? (e.g., goals.txt) ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine($"\nFile '{filename}' not found. Starting with a score of 0.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);

            if (lines.Length == 0)
            {
                Console.WriteLine("\nFile is empty. Starting with a score of 0.");
                return;
            }

            // The first line is always the score
            if (int.TryParse(lines[0], out int loadedScore))
            {
                 _score = loadedScore;
            }
            else
            {
                 Console.WriteLine("Warning: Could not parse score from file. Setting score to 0.");
                 _score = 0;
            }

            _goals.Clear(); // Clear existing goals before loading

            // Process the remaining lines (the goals)
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split('|');
                string goalType = parts[0];
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                Goal newGoal = null;

                // Recreate the specific derived goal object based on the type string
                switch (goalType)
                {
                    case "SimpleGoal":
                        bool isComplete = bool.Parse(parts[4]);
                        newGoal = new SimpleGoal(name, description, points, isComplete);
                        break;
                    case "EternalGoal":
                        newGoal = new EternalGoal(name, description, points);
                        break;
                    case "ChecklistGoal":
                        int bonus = int.Parse(parts[4]);
                        int target = int.Parse(parts[5]);
                        int amountCompleted = int.Parse(parts[6]);
                        newGoal = new ChecklistGoal(name, description, points, bonus, target, amountCompleted);
                        break;
                    case "NegativeGoal":
                        newGoal = new NegativeGoal(name, description, points);
                        break;
                }

                if (newGoal != null)
                {
                    _goals.Add(newGoal);
                }
                else
                {
                    Console.WriteLine($"Warning: Unknown goal type encountered: {goalType}. Skipping line {i+1}.");
                }
            }

            Console.WriteLine($"\nGoals successfully loaded from '{filename}'. Your score is now {_score}.");
        }
        catch (Exception ex)
        {
            // Catch parsing errors or other I/O exceptions
            Console.WriteLine($"\nAn error occurred while loading. Data may be corrupted. Starting new quest. Error: {ex.Message}");
            _goals.Clear();
            _score = 0;
        }
    }
}
