// Derived class for Swimming
public class Swimming : Activity
{
    private int _numberOfLaps;

    public Swimming(DateTime date, int lengthInMinutes, int numberOfLaps)
        : base(date, lengthInMinutes, "Swimming")
    {
        _numberOfLaps = numberOfLaps;
    }

    public override double GetDistance()
    {
        return (_numberOfLaps * LAP_POOL_LENGTH_METERS) / METERS_PER_KILOMETER;
    }

    public override double GetSpeed()
    {
        double distanceKm = GetDistance();
        if (LengthInMinutes == 0) return 0;
        return (distanceKm / LengthInMinutes) * 60.0;
    }

    public override double GetPace()
    {
        double distanceKm = GetDistance();
        if (distanceKm == 0) return 0;
        return LengthInMinutes / distanceKm;
    }
}