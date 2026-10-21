using System;

namespace TicTacToeOop;

public class ConsoleUI
{
    public static void PrintMenu()
    {
        Console.WriteLine("Крестики-нолики!\n");
        
        Console.WriteLine("1. Играть");
        Console.WriteLine("2. Правила игры");
        Console.WriteLine("0. Выйти из игры");
        
        Console.Write("\nВвод: ");
    }
    
    public static void PrintBoard(CellStates[,] states)
    {
        for (int i = 0; i < states.GetLength(0); i++)
        {
            for (int j = 0; j < states.GetLength(1); j++)
            {
                if (states[i,j] == CellStates.Empty)
                {
                    Console.Write($" {i*3+j+1} ");
                }
                else if (states[i,j] == CellStates.O)
                {
                    Console.Write(" O ");
                }
                else if (states[i,j] == CellStates.X)
                {
                    Console.Write(" X ");
                }
                if (j < states.GetLength(1)-1)
                {
                    Console.Write("|");
                }
            }
            if (i < states.GetLength(0)-1)
            {
                Console.WriteLine("\n-----------");
            }
        }
    }
    
    public static void ShowRules()
    {
        Console.WriteLine("Правила игры\n");
        Console.WriteLine("Игра ведётся на поле размером 3 на 3 ячейки. " +
        "Два игрока поочерёдно ставят свои символы (крестик или нолик) в ячейки поля. "+
        "Задача игрока - первым поставить ряд из трёх своих символов. Кто первый - тот победил.\n"+
        "\nВо время игры введите 0, чтобы выйти.\n");
    }
}