using System;

/// <summary>
/// A bonus goal type that tracks bad habits, resulting in a loss of points when recorded.
/// Inherits from Goal. (Exceeding requirement)
/// </summary>
public class NegativeGoal : Goal
{
    /// <summary>
    /// Constructor for a NegativeGoal.
    /// </summary>
    public NegativeGoal(string name, string description, int points) : base(name, description, points)
    {
        // No unique state variables needed
    }

    /// <summary>
    /// Overrides the base method. Records the event and returns a NEGATIVE point value.
    /// This is an example of polymorphism.
    /// </summary>
    public override int RecordEvent()
    {
        int pointsLost = -_points;
        Console.WriteLine($"\n!!! WARNING: You recorded '{GetShortName()}' and LOST {_points} points. Try harder next time! !!!");
        return pointsLost;
    }

    // IsComplete() is inherited from the base Goal class and remains false, as it's an ongoing habit.

    /// <summary>
    /// Overrides the base method. Returns the display string, showing a warning indicator.
    /// </summary>
    public override string GetDetailsString()
    {
        // Use [!] to indicate a goal that tracks bad habits
        return $"[!] {GetShortName()} ({GetDescription()}) --- Negative Habit (-{_points} points per record)";
    }

    /// <summary>
    /// Overrides the base method. Returns the savable string representation.
    /// Uses '|' as a separator for saving/loading.
    /// </summary>
    public override string GetStringRepresentation()
    {
        return $"NegativeGoal|{GetShortName()}|{GetDescription()}|{_points}";
    }
}
