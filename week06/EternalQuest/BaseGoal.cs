using System;

/// <summary>
/// The abstract base class for all types of goals.
/// Implements encapsulation by keeping attributes private.
/// </summary>
public abstract class Goal
{
    // Encapsulated private member variables
    private string _shortName;
    private string _description;
    protected int _points; // Use protected for easy access in derived classes for scoring

    /// <summary>
    /// Constructor for the Goal base class.
    /// </summary>
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Public method to access the goal's short name
    public string GetShortName()
    {
        return _shortName;
    }

    // Public method to access the goal's description
    public string GetDescription()
    {
        return _description;
    }

    /// <summary>
    /// Abstract method to be overridden by derived classes.
    /// Returns the points earned from the event.
    /// </summary>
    public abstract int RecordEvent();

    /// <summary>
    /// Virtual method to determine if a goal is complete.
    /// Returns false by default, to be overridden by SimpleGoal and ChecklistGoal.
    /// This is an example of polymorphism.
    /// </summary>
    public virtual bool IsComplete()
    {
        return false;
    }

    /// <summary>
    /// Abstract method to be overridden by derived classes.
    /// Returns a string detailing the goal's status (e.g., "[X] Read scriptures --- Completed 5/10 times").
    /// </summary>
    public abstract string GetDetailsString();

    /// <summary>
    /// Abstract method to be overridden by derived classes.
    /// Returns a string representation of the goal for saving to a file.
    /// </summary>
    public abstract string GetStringRepresentation();
}
