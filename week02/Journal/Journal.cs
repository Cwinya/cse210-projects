using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
public class Journal
{
    private List<Entry> entries = new List<Entry>();

    // Add a new entry to the journal
    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    // Display all entries in the journal
    public void Display()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
            return;
        }

        Console.WriteLine("Journal Entries:");
        foreach (var entry in entries)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
        }
        Console.WriteLine("------------------------------");
    }

    // Save the journal entries to a file in JSON format
    public void SaveToFile(string filename)
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, jsonString);
            Console.WriteLine($"Journal saved to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    // Load journal entries from a file in JSON format, replacing current entries
    public void LoadFromFile(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"File {filename} does not exist.");
                return;
            }
            string jsonString = File.ReadAllText(filename);
            entries = JsonSerializer.Deserialize<List<Entry>>(jsonString) ?? new List<Entry>();
            Console.WriteLine($"Journal loaded from {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }
}
