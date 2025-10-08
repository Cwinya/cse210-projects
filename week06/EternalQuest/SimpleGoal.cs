using System;

/// <summary>
/// Represents a one-time goal that can be completed once.
/// Inherits from Goal.
/// </summary>
public class SimpleGoal : Goal
{
    private bool _isComplete;

    /// <summary>
    /// Constructor for a SimpleGoal.
    /// </summary>
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    /// <summary>
    /// Loading constructor for a SimpleGoal.
    /// </summary>
    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    /// <summary>
    /// Overrides the base method. Records the event and returns points only if not already complete.
    /// This is an example of polymorphism.
    /// </summary>
    public override int RecordEvent()
    {
        if (!IsComplete())
        {
            _isComplete = true;
            Console.WriteLine($"\n*** Congratulations! You completed '{GetShortName()}' and earned {_points} points! ***");
            return _points;
        }
        else
        {
            Console.WriteLine($"\nGoal '{GetShortName()}' is already complete. No additional points awarded.");
            return 0;
        }
    }

    /// <summary>
    /// Overrides the base method. Returns the completion status.
    /// </summary>
    public override bool IsComplete()
    {
        return _isComplete;
    }

    /// <summary>
    /// Overrides the base method. Returns the display string.
    /// </summary>
    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {GetShortName()} ({GetDescription()})";
    }

    /// <summary>
    /// Overrides the base method. Returns the savable string representation.
    /// Uses '|' as a separator for saving/loading.
    /// </summary>
    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{GetShortName()}|{GetDescription()}|{_points}|{_isComplete}";
    }
}
