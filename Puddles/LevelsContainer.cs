using System;

namespace Puddles;

public static class LevelsContainer
{
    private static readonly string[] _levels = new string[]
    {
        "levels/level1.json",
        "levels/level2.json",
        "levels/level3.json",
    };
    
    public static int Count => _levels.Length;
    
    public static string GetLevel(int index)
    {
        if (index < 0 || index > _levels.Length-1)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
        return _levels[index];
    }
} 