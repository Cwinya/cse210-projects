// Derived class for Stationary Cycling
public class StationaryBicycles : Activity
{
    private double _speed; // Stored in kilometers per hour (kph)

    public StationaryBicycles(DateTime date, int lengthInMinutes, double speedKph)
        : base(date, lengthInMinutes, "Stationary Cycling")
    {
        _speed = speedKph;
    }

    public override double GetDistance()
    {
        return (_speed / 60.0) * LengthInMinutes;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        if (_speed == 0) return 0;
        return 60.0 / _speed;
    }
}
