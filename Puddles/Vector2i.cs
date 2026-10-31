using System;
using System.Text.Json.Serialization;

namespace Puddles;

public readonly struct Vector2i : IEquatable<Vector2i>
{
    public int Y { get; }
    public int X { get; }
    
    // Initializing of object of Vector2i type must look like [Y, X].
    // I made this decision because work with Array[,] start with lines (like Y in 2D-space). 
    [JsonConstructor] // Need for constructing from JSON
    public Vector2i(int y, int x)
    {
        Y = y;
        X = x;
    }
    
    public Vector2i(int a) : this(a, a)
    {
        
    }
    
    public override string ToString()
    {
        return $"({Y}, {X})";
    }
    
    public static Vector2i operator + (Vector2i a, Vector2i b)
    {
        return new Vector2i(a.Y + b.Y, a.X + b.X);
    }
    
    public static Vector2i operator - (Vector2i a, Vector2i b)
    {
        return new Vector2i(a.Y - b.Y, a.X - b.X);
    }
    
    public static Vector2i operator * (Vector2i a, int k)
    {
        return new Vector2i(a.Y * k, a.X * k);
    }
    
    public static Vector2i operator * (int k, Vector2i a)
    {
        return new Vector2i(k * a.Y, k * a.X);
    }
    
    public static bool operator == (Vector2i a, Vector2i b)
    {
        return (a.Y == b.Y && a.X == b.X);
    }
    
    public static bool operator != (Vector2i a, Vector2i b)
    {
        return !(a == b);
    }
    
    public bool Equals(Vector2i a)
    {
        return this == a;
    }
    
    public override bool Equals(object? o)
    {
        return o is Vector2i && Equals(o);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Y, X);
    }
    
}