using System;

namespace Puddles;

public class Field
{
    public Vector2i Size { get; }
    public char Symbol;
    private readonly char[,] _symbolsPicture;
    public char[,] SymbolsPicture => (char[,])_symbolsPicture.Clone();
    
    public Field(Vector2i size, char symbol)
    {
        if (size.Y <= 0 || size.X <= 0)
        {
            throw new ArgumentException(nameof(size));
        }
        Size = size;
        Symbol = symbol;
        _symbolsPicture = new char[Size.Y, Size.X];
        Clear();
    }
    
    public void PutSymbol(Vector2i position, char symbol)
    {
        if (position.Y < 0 || position.X < 0 || position.Y > Size.Y-1 || position.X > Size.X-1)
        {
            // If symbol go out of the field
            // then just don't print it without error
            return;
        }
        _symbolsPicture[position.Y, position.X] = symbol;
    }
    
    public void Clear()
    {
        for (int y = 0; y < Size.Y; y++)
        {
            for (int x = 0; x < Size.X; x++)
            {
                _symbolsPicture[y, x] = Symbol;
            }
        }
    }
}