using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// Entry class represents a single journal entry with date, prompt, and response


// Journal class manages a list of entries and provides methods to add, display, save, and load entries

partial class Program
{
    // List of prompts for journal entries
    static readonly List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    static void Main(string[] args)
    {
        Journal journal = new Journal();
        Random random = new Random();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option (1-5): ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Show a random prompt and get user response
                    string prompt = prompts[random.Next(prompts.Count)];
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Your response: ");
                    string? response = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(response))
                    {
                        Entry entry = new Entry
                        {
                            Date = DateTime.Now,
                            Prompt = prompt,
                            Response = response.Trim()
                        };
                        journal.AddEntry(entry);
                        Console.WriteLine("Entry added.");
                    }
                    else
                    {
                        Console.WriteLine("Empty response. Entry not added.");
                    }
                    break;

                case "2":
                    // Display all journal entries
                    journal.Display();
                    break;

                case "3":
                    // Save journal to file
                    Console.Write("Enter filename to save journal (e.g., journal.json): ");
                    string? saveFilename = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(saveFilename))
                    {
                        journal.SaveToFile(saveFilename.Trim());
                    }
                    else
                    {
                        Console.WriteLine("Invalid filename. Save cancelled.");
                    }
                    break;

                case "4":
                    // Load journal from file
                    Console.Write("Enter filename to load journal (e.g., journal.json): ");
                    string? loadFilename = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(loadFilename))
                    {
                        journal.LoadFromFile(loadFilename.Trim());
                    }
                    else
                    {
                        Console.WriteLine("Invalid filename. Load cancelled.");
                    }
                    break;

                case "5":
                    // Quit the program
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please choose 1-5.");
                    break;
            }
        }
    }
}
