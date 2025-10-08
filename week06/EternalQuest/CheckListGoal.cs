using System;

/// <summary>
/// Represents a goal that must be accomplished a certain number of times to be complete.
/// Inherits from Goal.
/// </summary>
public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    /// <summary>
    /// Constructor for a ChecklistGoal.
    /// </summary>
    public ChecklistGoal(string name, string description, int points, int bonus, int target) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    /// <summary>
    /// Loading constructor for a ChecklistGoal.
    /// </summary>
    public ChecklistGoal(string name, string description, int points, int bonus, int target, int amountCompleted) : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    /// <summary>
    /// Overrides the base method. Records the event, increments count, and awards bonus if complete.
    /// This is an example of polymorphism.
    /// </summary>
    public override int RecordEvent()
    {
        if (IsComplete())
        {
            Console.WriteLine($"\nGoal '{GetShortName()}' is already complete ({_amountCompleted}/{_target} recorded). No additional points awarded.");
            return 0;
        }

        _amountCompleted++;
        int pointsEarned = _points;

        if (IsComplete())
        {
            pointsEarned += _bonus;
            Console.WriteLine($"\n*** Phenomenal! You completed your checklist goal '{GetShortName()}' and earned {_points} base points PLUS a {_bonus} bonus! Total: {pointsEarned} points! ***");
        }
        else
        {
            Console.WriteLine($"\n*** You recorded '{GetShortName()}' and earned {_points} points! Progress: {_amountCompleted}/{_target} ***");
        }

        return pointsEarned;
    }

    /// <summary>
    /// Overrides the base method. Returns true if the target has been met.
    /// </summary>
    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    /// <summary>
    /// Overrides the base method. Returns the display string, including current progress.
    /// </summary>
    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {GetShortName()} ({GetDescription()}) --- Currently completed {_amountCompleted}/{_target}";
    }

    /// <summary>
    /// Overrides the base method. Returns the savable string representation.
    /// Uses '|' as a separator for saving/loading.
    /// </summary>
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{GetShortName()}|{GetDescription()}|{_points}|{_bonus}|{_target}|{_amountCompleted}";
    }
}
