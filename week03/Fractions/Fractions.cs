using System;

public class Fractions
{
    // Private attributes for numerator and denominator
    private int _top;
    private int _bottom;

    // Constructor to initialize the fraction
    public Fractions()
    {
        _top = 1;
        _bottom = 1;
    }

    public Fractions(int top)
    {
        _top = top;
        _bottom = 1;
    }

    public Fractions(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getters and Setters
    public int GetTop()
    {
        return _top;
    }
    public void SetTop(int top)
    {
        _top = top;
    }
    public int GetBottom()
    {
        return _bottom;
    }
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }
    // Return fraction as a string
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }
    // Return decimal value of the fraction
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}