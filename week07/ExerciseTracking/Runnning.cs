// Derived class for Running
public class Running : Activity
{
    private double _distance; // Stored in kilometers

    public Running(DateTime date, int lengthInMinutes, double distanceKm)
        : base(date, lengthInMinutes, "Running")
    {
        _distance = distanceKm;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        if (LengthInMinutes == 0) return 0;
        return (_distance / LengthInMinutes) * 60.0;
    }

    public override double GetPace()
    {
        if (_distance == 0) return 0;
        return LengthInMinutes / _distance;
    }
}
