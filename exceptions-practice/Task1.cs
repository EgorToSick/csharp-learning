/*
Задача 1
Сложение двух чисел
Базовая задача на исключение по типу данных.
*/

public static class Task1
{
    public static void Run()
    {
        int a;
        int b;
        Console.WriteLine("\nЗадача 1. Сложение двух чисел");
        while (true)
        {
            try
            {
                Console.Write("Введите целое число a: ");
                a = int.Parse(Console.ReadLine());
                break;
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Ошибка типа данных! Повторите попытку");
            }
        }
        while (true)
        {
            try
            {
                Console.Write("Введите целое число b: ");
                b = int.Parse(Console.ReadLine());
                break;
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Ошибка типа данных! Повторите попытку");
            }
        }
        int c = a + b;
        Console.WriteLine($"{a} + {b} = {c}");
    }
}