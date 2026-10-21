using System;

namespace TicTacToeOop;

public enum Symbols
    {
        X,
        O
    }

public class Player
{
    private static int _countOfPlayers = 0;
    
    public string Name { get; private set; }
    public int Score { get; private set; }
    public Symbols Symbol { get; private set; }
    
    public Player(string name, Symbols symbol)
    {
        if (string.IsNullOrWhiteSpace(name))
            name = $"Player{_countOfPlayers+1}";
        Name = name;
        Symbol = symbol;
        _countOfPlayers++;
    }
    
    public static void ClearPlayers()
    {
        _countOfPlayers = 0;
    }
}