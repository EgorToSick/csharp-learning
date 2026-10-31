using System;
using System.Text.Json;

namespace Puddles;

public class Game
{
    private Field _field { get; }
    private Renderer _renderer { get; }
    private Player _player { get; }
    private ExitPoint _exitPoint { get; }
    private GameObject[,] _objects { get; }
    
    public Game(string levelPath)
    {
        LevelData? levelData = JsonSerializer.Deserialize<LevelData>(File.ReadAllText(levelPath));
        if (levelData is null)
        {
            throw new NullReferenceException($"Level data should not be null. {nameof(levelData)}");
        }
        _field = new Field(levelData.FieldSize, ' ');
        _renderer = new Renderer(_field);
        _objects = new GameObject[_field.Size.Y, _field.Size.X];
        foreach (PuddleData pData in levelData.Puddles)
        {
            _renderer.AddToBuffer(new Puddle(pData.Size, pData.Position, 'O'));
        }
        _player = new Player(levelData.PlayerPosition, '.', 2);
        _renderer.AddToBuffer(_player);
        _renderer.AddToBuffer(new Dark(_field, _player, '*'));
        _exitPoint = new ExitPoint(levelData.ExitPosition, 'E');
        _renderer.AddToBuffer(_exitPoint);
        foreach (GameObject obj in _renderer.Buffer)
        {
            obj.GetPhysics(_objects);
        }
    }
    
    public void PrintScene()
    {
        _renderer.Render();
    }
    
    public void MovePlayerIn(Vector2i direction)
    {
        var newPosition = _player.Position + direction;
        if (PlayerCanMoveTo(newPosition))
        {
            _player.MoveTo(newPosition);
        }
    }
    
    private bool PlayerCanMoveTo(Vector2i newPosition)
    {
        if (newPosition.Y < 0 || newPosition.X < 0 || newPosition.Y > _field.Size.Y-1 || newPosition.X > _field.Size.X-1)
        {
            return false;
        }
        for (int y = 0; y < _field.Size.Y; y++)
            {
                for (int x = 0; x < _field.Size.X; x++)
                {
                    GameObject obj = _objects[y, x];
                    if (obj is Puddle && y == newPosition.Y && x == newPosition.X)
                    {
                        return false;
                    }
                }
            }
        return true;
    } 
    
    public bool PlayerEscaped()
    {
        if (_player.Position == _exitPoint.Position)
        {
            return true;
        }
        return false;
    }
}