using System;

namespace Puddles;

public class Puddle : GameObject
{
    private bool[,] _alphaMask;
    
    public Puddle(Vector2i size, Vector2i position, char symbol, bool[,] alphaMask) : base(size, position, symbol)
    {
        if (alphaMask.GetLength(0) != size.Y || alphaMask.GetLength(1) != size.X)
        {
            throw new ArgumentException($"Parameters do not match: {nameof(size)}, {nameof(alphaMask)}.");
        }
        _alphaMask = alphaMask;
    }
    
    public Puddle(Vector2i size, Vector2i position, char symbol) : base(size, position, symbol)
    {
        _alphaMask = new bool[size.Y, size.X];
        for (int y = 0; y < size.Y; y++)
        {
            for (int x = 0; x < size.X; x++)
            {
                _alphaMask[y, x] = true;
            }
        }
    }
    
    public override void PrintOn(Field field)
    {
        for (int y = 0; y < Size.Y; y++)
        {
            for (int x = 0; x < Size.X; x++)
            {
                if (_alphaMask[y, x] == true)
                {
                    var posY = Position.Y + y;
                    var posX = Position.X + x;
                    field.PutSymbol(new Vector2i(posY, posX), Symbol);
                }
            }
        }
    }
    
    public override void GetPhysics(GameObject[,] array)
    {
        for (int y = 0; y < Size.Y; y++)
        {
            for (int x = 0; x < Size.X; x++)
            {
                if (_alphaMask[y, x] == false)
                {
                    continue;
                }
                if (Position.Y + y > array.GetLength(0) - 1 || Position.X + x > array.GetLength(1) - 1 || Position.Y + y < 0 || Position.X + x < 0)
                {
                    continue;
                }
                array[Position.Y + y, Position.X + x] = this;
            }
        }
    }
}