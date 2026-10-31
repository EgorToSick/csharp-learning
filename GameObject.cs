using System;

namespace Puddles;

public class GameObject
{
    public Vector2i Position;
    public Vector2i Size;
    public char Symbol;
    
    protected GameObject(Vector2i size, Vector2i position, char symbol)
    {
        if (size.Y <= 0 || size.X <= 0)
        {
            throw new ArgumentException(nameof(size));
        }
        Position = position;
        Size = size;
        Symbol = symbol;
    }
    
    protected GameObject(Vector2i position, char symbol) : this(new Vector2i(1,1), position, symbol)
    {
        
    }
    
    public virtual void PrintOn(Field field)
    {
        for (int y = 0; y < Size.Y; y++)
        {
            for (int x = 0; x < Size.X; x++)
            {
                var posY = Position.Y + y;
                var posX = Position.X + x;
                field.PutSymbol(new Vector2i(posY, posX), Symbol);
            }
        }
    }
    
    public virtual void GetPhysics(GameObject[,] array)
    {
        for (int y = 0; y < Size.Y; y++)
        {
            for (int x = 0; x < Size.X; x++)
            {
                if (Position.Y + y > array.GetLength(0) - 1 || Position.X + x > array.GetLength(1) - 1 || Position.Y + y < 0 || Position.X + x < 0)
                {
                    continue;
                }
                array[Position.Y + y, Position.X + x] = this;
            }
        }
    }
}