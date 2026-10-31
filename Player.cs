using System;

namespace Puddles;

// Directions can used for calculating new position
// of player to move him or for calculating direction
// from different between positions
public static class Directions
{
    public static readonly Vector2i LEFT = new Vector2i(0, -1);
    public static readonly Vector2i RIGHT = new Vector2i(0, 1);
    public static readonly Vector2i UP = new Vector2i(-1, 0);
    public static readonly Vector2i DOWN = new Vector2i(1, 0);
}

public class Player : GameObject
{
    public int RadiusOfVision { get; }
    
    public Player(Vector2i startPosition, char symbol, int radiusOfVision) : base(startPosition, symbol)
    {
        if (radiusOfVision <= 0)
        {
            throw new ArgumentException($"Radius of player's vision couldn't be lesser than 1. {nameof(radiusOfVision)}");
        }
        RadiusOfVision = radiusOfVision;
    }
    
    public void MoveTo(Vector2i newPosition)
    {
        Position = newPosition;
    }

    public override void PrintOn(Field field)
    {
        field.PutSymbol(Position, Symbol);
    }
}