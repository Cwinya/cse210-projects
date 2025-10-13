using System.Collections.Generic;

// Base class for all activities
public abstract class Activity
{
    // Private attributes shared by all activities
    private DateTime _date;
    private int _lengthInMinutes;
    private string _activityType;

    // Constant for the lap pool length in meters
    protected const double LAP_POOL_LENGTH_METERS = 50.0;
    // Constant for converting meters to kilometers
    protected const double METERS_PER_KILOMETER = 1000.0;

    // Constructor
    public Activity(DateTime date, int lengthInMinutes, string activityType)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
        _activityType = activityType;
    }

    // Public getter for length in minutes, useful for calculations in derived classes
    protected int LengthInMinutes => _lengthInMinutes;

    // Abstract methods to be overridden by derived classes
    public abstract double GetDistance(); // In kilometers
    public abstract double GetSpeed();    // In kilometers per hour (kph)
    public abstract double GetPace();     // In minutes per kilometer (min/km)

    // Method to produce the summary string
    public virtual string GetSummary()
    {
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        return $"{_date.ToString("dd MMM yyyy")} {_activityType} ({_lengthInMinutes} min): " +
               $"Distance {distance:F1} km, Speed: {speed:F1} kph, Pace: {pace:F2} min per km";
    }
}