using System;

namespace TicTacToe;

enum GameStates { MainMenu, Help, Game }

class Program
{
    static void PaintField(char[,] field)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (field[i,j]=='.') Console.Write($" {i*3+j+1} ");
                else Console.Write($" {field[i,j]} ");
                if (j < 2) Console.Write("|");
            }
            if (i < 2) Console.WriteLine("\n---+---+---");
        }
        Console.WriteLine();
    }
    static void DrawMainMenu()
    {
        Console.WriteLine("Главное меню\n");
        Console.Write("1. Играть\n");
        Console.Write("2. Правила игры\n");
        Console.Write("0. Выйти\n");
        Console.Write("Ввод: ");
    }
    static bool CanMakeMove(char[,] field, int userInput)
    {
        int i = 0;
        int j = 0;
        switch (userInput)
        {
            case 1: i = 0; j = 0; break;
            case 2: i = 0; j = 1; break;
            case 3: i = 0; j = 2; break;
            case 4: i = 1; j = 0; break;
            case 5: i = 1; j = 1; break;
            case 6: i = 1; j = 2; break;
            case 7: i = 2; j = 0; break;
            case 8: i = 2; j = 1; break;
            case 9: i = 2; j = 2; break;
        }
        if (field[i,j] != '.') return false;
        return true;
    }
    static void MakeMove(int userInput, char[,] field, bool currentPlayer)
    {
        int i = 0;
        int j = 0;
        switch (userInput)
        {
            case 1: i = 0; j = 0; break;
            case 2: i = 0; j = 1; break;
            case 3: i = 0; j = 2; break;
            case 4: i = 1; j = 0; break;
            case 5: i = 1; j = 1; break;
            case 6: i = 1; j = 2; break;
            case 7: i = 2; j = 0; break;
            case 8: i = 2; j = 1; break;
            case 9: i = 2; j = 2; break;
        }
        if (field[i,j] == '.')
        {
            if (currentPlayer) field[i, j] = 'X';
            else field[i, j] = 'O';
        }
    }
    static bool IsCurrentPlayerWin(char[,] field, bool currentPlayer)
    {
        char pl;
        if (currentPlayer) pl = 'X';
        else pl = 'O';
        if ((field[0,0] == pl) && (field[0,1] == pl) && (field[0,2] == pl)) return true;
        if ((field[1,0] == pl) && (field[1,1] == pl) && (field[1,2] == pl)) return true;
        if ((field[2,0] == pl) && (field[2,1] == pl) && (field[2,2] == pl)) return true;
        if ((field[0,0] == pl) && (field[1,0] == pl) && (field[2,0] == pl)) return true;
        if ((field[0,1] == pl) && (field[1,1] == pl) && (field[2,1] == pl)) return true;
        if ((field[0,2] == pl) && (field[1,2] == pl) && (field[2,2] == pl)) return true;
        if ((field[0,0] == pl) && (field[1,1] == pl) && (field[2,2] == pl)) return true;
        if ((field[0,2] == pl) && (field[1,1] == pl) && (field[2,0] == pl)) return true;
        return false;
    }
    static bool IsWinIsNobodys(char[,] field)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (field[i,j]=='.')
                {
                    return false;
                }
            }
        }
        return true;
    }
    static void ClearField(char[,] field)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                field[i, j] = '.';
            }
        }
    }
    static void Game(char[,] field)
    {
        ClearField(field);
        bool inGame = true;
        bool currentPlayer = true; // true - крестики, false - нолики
        while (inGame)
        {
            Console.WriteLine("Игра\n");
            Console.Write("Ход ");
            if (currentPlayer) Console.WriteLine("крестиков\n");
            else Console.WriteLine("ноликов\n");
            PaintField(field);
            Console.Write("0. Выйти в меню\n");
            Console.Write("Ввод: ");
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                int userInput = value;
                if ((userInput > 0) && (userInput < 10))
                {
                    if (CanMakeMove(field, userInput))
                    {
                        MakeMove(userInput, field, currentPlayer);
                        if (IsCurrentPlayerWin(field, currentPlayer))
                        {
                            inGame = false;
                            Console.Clear();
                            Console.Write("Победили ");
                            if (currentPlayer) Console.WriteLine("крестики!");
                            else Console.WriteLine("нолики!");
                            PaintField(field);
                            Console.Write("Нажмите Enter, чтобы продолжить.");
                            Console.ReadLine();
                        }
                        else if (IsWinIsNobodys(field))
                        {
                            inGame = false;
                            Console.Clear();
                            Console.WriteLine("Ничья!");
                            PaintField(field);
                            Console.Write("Нажмите Enter, чтобы продолжить.");
                            Console.ReadLine();
                        }
                        currentPlayer = !currentPlayer;
                    }
                    else 
                    {
                        Console.Write("Это поле занято.\nНажмите Enter, чтобы продолжить.");
                        Console.ReadLine();
                    }
                }
                else if (userInput == 0) inGame = false;                            
                else 
                {
                    Console.WriteLine("Введите число из предложенных.");
                    Console.Write("Нажмите Enter, чтобы продолжить.");
                    Console.ReadLine();
                }
            }
            else 
            {
                Console.WriteLine("Ошибка преобразования данных.");
                Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                Console.ReadLine();
            }
            Console.Clear();
        }
    }
    static void Main(string[] args)
    {
        Console.Clear();
        GameStates currentGameState = GameStates.MainMenu;
        char[,] field = new char[3, 3];
        ClearField(field);
        Console.WriteLine("Крестики-нолики!\n");
        
        bool quitGame = false;
        while (!quitGame)
        {
            switch (currentGameState)
            {
                case GameStates.MainMenu:
                bool inMainMenu = true;
                    while (inMainMenu)
                    {
                        DrawMainMenu();
                        if (int.TryParse(Console.ReadLine(), out int value))
                        {
                            int userInput = value;
                            switch (userInput)
                            {
                                case 0:
                                    quitGame = true;
                                    inMainMenu = false;
                                    break;
                                case 1:
                                    currentGameState = GameStates.Game;
                                    inMainMenu = false;
                                    break;
                                case 2:
                                    currentGameState = GameStates.Help;
                                    inMainMenu = false;
                                    break;
                                default:
                                    Console.WriteLine("Введите число из предложенных.");
                                    break;
                            }
                        }
                        else 
                        {
                            Console.WriteLine("Ошибка преобразования данных.");
                            Console.Write("Нажмите Enter, чтобы продолжить.");
                            Console.ReadLine();
                        }
                        Console.Clear();
                    }
                    break;
                case GameStates.Help:
                    Console.Clear();
                    Console.WriteLine("Правила игры\n");
                    Console.WriteLine("Игра ведётся на поле размером 3 на 3 клетки. Задача игроков - поставить свои знаки (крестики или нолики) в трёх клетках подряд в любом направлении. Игроки ходят по очереди. Первый ход всегда у крестиков.");
                    Console.Write("Нажмите Enter, чтобы вернуться.");
                    Console.ReadLine();
                    Console.Clear();
                    currentGameState = GameStates.MainMenu;
                    break;
                case GameStates.Game:
                    Game(field);
                    currentGameState = GameStates.MainMenu;
                    break;
            }
        }
    }
}