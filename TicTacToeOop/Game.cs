using System;

namespace TicTacToeOop;

public class Game
{
    private readonly Board _board;
    private readonly Player _playerX;
    private readonly Player _playerO;
    public Player CurrentPlayer { get; private set; }
    public Player Winner { get; private set; }
    public bool IsOver { get; private set; }
    
    public Game(string playerXName, string playerOName)
    {
        _board = new Board();
        _playerX = new Player(playerXName, Symbols.X);
        _playerO = new Player(playerOName, Symbols.O);
        CurrentPlayer = _playerX;
        Winner = null;
        IsOver = false;
    }
    
    public bool MakeMove(int i, int j)
    {
        if (IsOver)
        {
            return false;
        }
        if (_board.CanMoveTo(i, j))
        {
            _board.MakeMoveTo(i, j, CurrentPlayer.Symbol);
            if (_board.HasLine(CurrentPlayer.Symbol))
            {
                Winner = CurrentPlayer;
                IsOver = true;
            }
            else if (_board.IsFull())
            {
                IsOver = true;
            }
            else
            {
                SwitchPlayer();
            }
            return true;
        }
        else
        {
            return false;
        }
    }
    
    private void SwitchPlayer()
    {
        if (CurrentPlayer == _playerX)
        {
            CurrentPlayer = _playerO;
        }
        else
        {
            CurrentPlayer = _playerX;
        }
    }
    
    public CellStates[,] BoardCellStates()
    {
        return _board.GetCellStates();
    }
}