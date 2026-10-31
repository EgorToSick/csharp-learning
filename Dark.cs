using System;

namespace Puddles;

public class Dark : GameObject
{
    private Player _player;
    
    public Dark(Field field, Player player, char symbol) : base(new Vector2i(field.Size.Y, field.Size.X), new Vector2i(0), symbol)
    {
        _player = player;
    }

    public override void PrintOn(Field field)
    {
        int radius = _player.RadiusOfVision;
        int centerY = _player.Position.Y;
        int centerX = _player.Position.X;
        
        for (int y = 0; y < Size.Y; y++)
        {
            for (int x = 0; x < Size.X; x++)
            {
                int dy = y - centerY;
                int dx = x - centerX;
                
                if (dy * dy + dx * dx > radius * radius)
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
        return;
    }
}