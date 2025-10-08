using System;

/// <summary>
/// Represents an ongoing goal that is never completed but is recorded repeatedly.
/// Inherits from Goal.
/// </summary>
public class EternalGoal : Goal
{
    /// <summary>
    /// Constructor for an EternalGoal.
    /// </summary>
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        // No unique state variables needed
    }
    
    // IsComplete() is inherited from the base Goal class and remains false, as it's an eternal goal.

    /// <summary>
    /// Overrides the base method. Records the event and always returns the points.
    /// This is an example of polymorphism.
    /// </summary>
    public override int RecordEvent()
    {
        Console.WriteLine($"\n*** You recorded '{GetShortName()}' and earned {_points} points! Keep up the great work! ***");
        return _points;
    }

    /// <summary>
    /// Overrides the base method. Returns the display string.
    /// </summary>
    public override string GetDetailsString()
    {
        // Eternal goals never show [X] because they are never finished
        return $"[ ] {GetShortName()} ({GetDescription()}) --- Eternal";
    }

    /// <summary>
    /// Overrides the base method. Returns the savable string representation.
    /// Uses '|' as a separator for saving/loading.
    /// </summary>
    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{GetShortName()}|{GetDescription()}|{_points}";
    }
}
