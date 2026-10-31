using System;

namespace Puddles;

public class ConsoleUI
{
    public static void PrintField(Field field)
    {
        Console.Write("+-");
        for (int i = 0; i < field.Size.X; i++)
        {
            Console.Write("--");
        }
        Console.WriteLine("+");
        for (int y = 0; y < field.Size.Y; y++)
        {
            Console.Write("| ");
            for (int x = 0; x < field.Size.X; x++)
            {
                Console.Write(field.SymbolsPicture[y, x] + " ");
            }
            Console.WriteLine("|");
        }
        Console.Write("+-");
        for (int i = 0; i < field.Size.X; i++)
        {
            Console.Write("--");
        }
        Console.WriteLine("+");
    }
    
    public static void PrintMainMenu()
    {
        Console.WriteLine("PUDDLES\n");
        Console.WriteLine("1. Play");
        Console.WriteLine("0. Quit");
    }
}