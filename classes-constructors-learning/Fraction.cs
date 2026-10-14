using System;

namespace CSharpOopLearning;

public class Fraction
{
    public int Numerator { get; }
    public int Denominator { get; }
    public double Value => (double)Numerator/Denominator;
    
    public Fraction(int number) : this(number, 1)
    {
        
    }
    
    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0) throw new ArgumentException("Ноль в знаменателе.");
        Numerator = numerator;
        Denominator = denominator;
    }
    
    public Fraction(Fraction other) : this(other.Numerator, other.Denominator)
    {
        
    }
    
    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }
    
    public Fraction Add(Fraction other)
    {
        int newFractionDenominator = Denominator * other.Denominator;
        int newFractionNumerator = Numerator * other.Denominator + other.Numerator * Denominator;
        Fraction newFraction = new Fraction(newFractionNumerator, newFractionDenominator);
        return newFraction.Reduce();
    }
    
    public Fraction Subtract(Fraction other)
    {
        int newFractionDenominator = Denominator * other.Denominator;
        int newFractionNumerator = Numerator * other.Denominator - other.Numerator * Denominator;
        Fraction newFraction = new Fraction(newFractionNumerator, newFractionDenominator);
        return newFraction.Reduce();
    }
    
    public Fraction Multiply(Fraction other)
    {
        Fraction newFraction = new Fraction(Numerator * other.Numerator, Denominator * other.Denominator);
        return newFraction.Reduce();
    }
    
    public Fraction Divide(Fraction other)
    {
        Fraction newFraction = new Fraction(Numerator * other.Denominator, Denominator * other.Numerator);
        return newFraction.Reduce();
    }
    
    public Fraction Reduce()
    {
        int gcd = Gcd(Math.Abs(Numerator), Math.Abs(Denominator));
        int sign = Denominator < 0 ? -1 : 1;
        return new Fraction(sign * Numerator / gcd, sign * Denominator / gcd);
    }
    
    private static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}