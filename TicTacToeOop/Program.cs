using System;

namespace TicTacToeOop;

class Program
{
    static void RunGame()
    {
        Console.WriteLine("Задайте игроков\n");
        Console.Write("Крестики: ");
        string playerXName = Console.ReadLine();
        Console.Write("Нолики: ");
        string playerOName = Console.ReadLine();
        Game game = new Game(playerXName, playerOName);
        bool quit = false;
        while (!game.IsOver && !quit)
        {
            Console.Clear();
            Console.WriteLine("Игра\n");
            Console.WriteLine($"Ход {game.CurrentPlayer.Name} ({game.CurrentPlayer.Symbol})\n");
            ConsoleUI.PrintBoard(game.BoardCellStates());
            Console.WriteLine("\n");
            Console.Write("Ввод: ");
            if (int.TryParse(Console.ReadLine(), out int userInput))
            {
                if (userInput == 0)
                {
                    quit = true;
                    continue;
                }
                int row = (userInput-1)/3;
                int col = (userInput-1)%3;
                if (row < 0 || row > 2 || col < 0 || col > 2)
                {
                    Console.WriteLine("Ход невозможен: за пределами поля.");
                    Console.Write("Нажмите Enter, чтобы продолжить.");
                    Console.ReadLine();
                }
                else if (game.MakeMove(row, col) == false)
                {
                    Console.WriteLine("Эта ячейка занята.");
                    Console.Write("Нажмите Enter, чтобы продолжить.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.Write("Ошибка преобразования данных.\n"+
                "Нажмите Enter, чтобы продолжить.");
                Console.ReadLine();
            }
        }
        Console.Clear();
        if (game.IsOver)
        {
            if (game.Winner != null)
            {
                Console.WriteLine($"Победа игрока {game.Winner.Name} ({game.Winner.Symbol})\n");
            }
            else
            {
                Console.WriteLine($"Ничья\n");
            }
            ConsoleUI.PrintBoard(game.BoardCellStates());
            Console.WriteLine("\n");
            Console.Write("Нажмите Enter, чтобы продолжить.");
            Console.ReadLine();
        }
        Player.ClearPlayers();
    }
    
    static void Main(string[] args)
    {
        bool quit = false;
        while (!quit)
        {
            Console.Clear();
            ConsoleUI.PrintMenu();
            if (int.TryParse(Console.ReadLine(), out int userInput))
            {
                switch (userInput)
                {
                    case 1:
                        Console.Clear();
                        RunGame();
                        break;
                    case 2:
                        Console.Clear();
                        ConsoleUI.ShowRules();
                        Console.Write("Нажмите Enter, чтобы продолжить.");
                        Console.ReadLine();
                        break;
                    case 0:
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Введите корректное значение пункта меню.");
                        Console.Write("Нажмите Enter, чтобы продолжить.");
                        Console.ReadLine();
                        break;
                }
            }
            else
            { 
                Console.WriteLine("Ошибка преобразования данных.");
                Console.Write("Нажмите Enter, чтобы продолжить.");
                Console.ReadLine();
            }
        }
    }
}