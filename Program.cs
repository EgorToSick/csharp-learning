using System;
using System.Text.Json;
using Microsoft.Win32.SafeHandles;

namespace Puddles;

class Program
{
    static void Game(string levelPath)
    {
        try
        {
            Game game = new Game(levelPath);
            bool inGame = true;
            while (inGame)
            {
                Console.Clear();
                game.PrintScene();
                Vector2i direction = new Vector2i(0);
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.Spacebar:
                    case ConsoleKey.NumPad0:
                    case ConsoleKey.D0:
                        inGame = false;
                        break;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                    case ConsoleKey.NumPad8:
                        direction = new Vector2i(-1, 0);
                        break;
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                    case ConsoleKey.NumPad4:
                        direction = new Vector2i(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                    case ConsoleKey.NumPad2:
                        direction = new Vector2i(1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                    case ConsoleKey.NumPad6:
                        direction = new Vector2i(0, 1);
                        break;
                    default:
                        break;
                }
                game.MovePlayerIn(direction);
                if (game.PlayerEscaped())
                {
                    inGame = false;
                    Console.Clear();
                    Console.WriteLine("You are escaped!");
                    Console.ReadKey(true);
                }
            }
        }
        catch
        {
            Console.Clear();
            Console.WriteLine("ERROR: Maybe level is not exists.");
            Console.ReadKey();
            return;
        }
    }
    
    static void ChooseLevel()
    {
        int levelNum = 0;
        bool inGame = true;
        bool chooseLevel = true;
        while (chooseLevel)
        {
            Console.Clear();
            Console.WriteLine("Choose the level\n");
            Console.WriteLine($"-- Level {levelNum+1} --\n");
            Console.WriteLine("<- left | right ->\n");
            Console.WriteLine("1. Choose");
            Console.WriteLine("2. Own level");
            Console.WriteLine("0. Cancel");
            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.A || key == ConsoleKey.LeftArrow || key == ConsoleKey.NumPad4)
            {
                if (levelNum > 0)
                    {
                        levelNum--;
                    }
            }
            else if (key == ConsoleKey.D || key == ConsoleKey.RightArrow || key == ConsoleKey.NumPad6)
            {
                if (levelNum < LevelsContainer.Count-1)
                    {
                        levelNum++;
                    }
            }
            else if (key == ConsoleKey.D1)
            {
                chooseLevel = false;
            }
            else if (key == ConsoleKey.D2)
            {
                Console.Clear();
                Console.WriteLine("(Empty line - cancel)");
                Console.Write("Enter the level path: ");
                string value = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(value))
                {
                    Game(value);
                }                
            }
            else if (key == ConsoleKey.D0)
            {
                chooseLevel = false;
                inGame = false;
            }
        }
        if (inGame)
        {
            Game(LevelsContainer.GetLevel(levelNum));
        }
    }
    
    static void Main(string[] args)
    {
        bool quit = false;
        while (!quit)
        {
            Console.Clear();
            ConsoleUI.PrintMainMenu();
            var userInput = Console.ReadKey(true);
            switch (userInput.Key)
            {
                case ConsoleKey.D1:
                    ChooseLevel();
                    break;
                case ConsoleKey.D0:
                    quit = true;
                    break;
            }
        }
    }
}