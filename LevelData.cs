using System;

namespace Puddles;

public class LevelData
{
    public Vector2i FieldSize { get; set; }
    public Vector2i PlayerPosition { get; set; }
    public List<PuddleData> Puddles { get; set; } = new List<PuddleData>();
    public Vector2i ExitPosition { get; set; }
}

public class PuddleData
{
    public Vector2i Position { get; set; }
    public Vector2i Size { get; set; }
}