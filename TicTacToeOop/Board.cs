using System;

namespace TicTacToeOop;

public enum CellStates
{
    Empty,
    X,
    O
}

public class Board
{
    private CellStates[,] _board = new CellStates[3,3];
    
    public Board()
    {
        for (int i = 0; i < _board.GetLength(0); i++)
        {
            for (int j = 0; j < _board.GetLength(1); j++)
            {
                _board[i, j] = CellStates.Empty;
            }
        }
    }
    
    public bool CanMoveTo(int i, int j)
    {
        if (_board[i, j] == CellStates.Empty)
            return true;
        return false;
    }
    
    public void MakeMoveTo(int i, int j, Symbols symbol)
    {
        if (i < 0 || i > 2)
            throw new ArgumentException(nameof(i));
        if (j < 0 || j > 2)
            throw new ArgumentException(nameof(j));
        if (symbol == Symbols.O)
        {
            _board[i, j] = CellStates.O;
        }
        else if (symbol == Symbols.X)
        {
            _board[i, j] = CellStates.X;
        }
    }
    
    public bool HasLine(Symbols symbol)
    {
        CellStates state;
        if (symbol == Symbols.O) state = CellStates.O;
        else state = CellStates.X;
        if (_board[0,0] == state && _board[0,1] == state && _board[0,2] == state) return true;
        if (_board[1,0] == state && _board[1,1] == state && _board[1,2] == state) return true;
        if (_board[2,0] == state && _board[2,1] == state && _board[2,2] == state) return true;
        if (_board[0,0] == state && _board[1,0] == state && _board[2,0] == state) return true;
        if (_board[0,1] == state && _board[1,1] == state && _board[2,1] == state) return true;
        if (_board[0,2] == state && _board[1,2] == state && _board[2,2] == state) return true;
        if (_board[0,0] == state && _board[1,1] == state && _board[2,2] == state) return true;
        if (_board[0,2] == state && _board[1,1] == state && _board[2,0] == state) return true;
        return false;
    }
    
    public bool IsFull()
    {
        foreach (CellStates field in _board)
        {
            if (field == CellStates.Empty)
            {
                return false;
            }
        }
        return true;
    }
    
    public CellStates[,] GetCellStates()
    {
        return (CellStates[,])_board.Clone();
    }
}