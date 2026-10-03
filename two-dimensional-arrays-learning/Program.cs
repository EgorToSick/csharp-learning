using System;

namespace ArraysPractice;

class Program
{    
    static void Main(string[] args)
    {
        Console.WriteLine("\nЗадача 1. Заполнение двумерного массива");
        int size;
        while (true)
        {
            Console.Write("Введите размер квадратного двумерного массива: ");
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                size = value;
                if (size <= 0) Console.WriteLine("Число должно быть больше нуля.");
                else break;
            }
            else Console.WriteLine("Число должно быть целым.");
        }
        int[,] arrayTwo = new int[size, size];
        for (int i = 0; i < arrayTwo.GetLength(0); i++)
        {
            for (int j = 0; j < arrayTwo.GetLength(1); j++)
            {
                while (true)
                {
                    Console.Write($"arrayTwo[{i},{j}] = ");
                    if (int.TryParse(Console.ReadLine(), out int value))
                    {
                        arrayTwo[i, j] = value;
                        break;
                    }
                    else Console.WriteLine("Число должно быть целым");
                }
            }
        }
        for (int i = 0; i < arrayTwo.GetLength(0); i++)
        {
            for (int j = 0; j < arrayTwo.GetLength(1); j++)
            {
                Console.Write(arrayTwo[i, j]+" ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("\nЗадача 2. Сложение элементов по строкам и столбцам");
        int[] sumX = new int[arrayTwo.GetLength(0)];
        int[] sumY = new int[arrayTwo.GetLength(1)];
        for (int i = 0; i < arrayTwo.GetLength(0); i++)
        {
            for (int j = 0; j < arrayTwo.GetLength(1); j++)
            {
                sumX[i]+=arrayTwo[i,j];
                sumY[j]+=arrayTwo[i,j];
            }
        }
        Console.WriteLine("Сумма по строкам");
        foreach (int num in sumX) Console.Write(num + " ");
        Console.WriteLine("\nСумма по столбцам");
        foreach (int num in sumY) Console.Write(num + " ");
        Console.WriteLine();
        
        Console.WriteLine("\nЗадача 3. Максимум и минимум с индексами");
        int max = arrayTwo[0,0];
        int min = arrayTwo[0,0];
        for (int i = 0; i<arrayTwo.GetLength(0); i++)
        {
            for (int j = 0; j < arrayTwo.GetLength(1); j++)
            {
                if (arrayTwo[i,j] > max) max = arrayTwo[i,j];
            }
        }
        for (int i = 0; i<arrayTwo.GetLength(0); i++)
        {
            for (int j = 0; j < arrayTwo.GetLength(1); j++)
            {
                if (arrayTwo[i,j] < min) min = arrayTwo[i,j];
            }
        }
        Console.WriteLine($"Вхождения максимального числа {max}:");
        for (int i = 0; i<arrayTwo.GetLength(0); i++)
        {
            for (int j = 0; j < arrayTwo.GetLength(1); j++)
            {
                if (arrayTwo[i,j] == max) Console.Write($"[{i},{j}] ");
            }
        }
        Console.WriteLine();
        Console.WriteLine($"Вхождения минимального числа {min}:");
        for (int i = 0; i<arrayTwo.GetLength(0); i++)
        {
            for (int j = 0; j < arrayTwo.GetLength(1); j++)
            {
                if (arrayTwo[i,j] == min) Console.Write($"[{i},{j}] ");
            }
        }
        Console.WriteLine();
        
        Console.WriteLine("\nЗадача 4. Транспонирование без создания второго массива");
        for (int i = 0; i < arrayTwo.GetLength(0); i++)
        {
            for (int j = 0; j < arrayTwo.GetLength(1); j++)
            {
                if (i < j)
                {
                    int ij = arrayTwo[i, j];
                    int ji = arrayTwo[j, i];
                    arrayTwo[i, j] = ji;
                    arrayTwo[j, i] = ij;
                }
            }
        }
        for (int i = 0; i < arrayTwo.GetLength(0); i++)
        {
            for (int j = 0; j < arrayTwo.GetLength(1); j++)
            {
                Console.Write(arrayTwo[i,j]+" ");
            }
            Console.WriteLine();
        }
    }
}