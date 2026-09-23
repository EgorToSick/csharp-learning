/*
Задание 6.
Напишите программу, реализующую «интерактивное» меню для работы с массивом из 5 целых чисел.
- Если человек введёт 1, выведите на экран весь список.
- Если человек введёт 2, выведите на экран длину списка.
- Если человек введёт 3, выведите на экран первый и последний элемент списка.
- Если человек введёт 4, попрощайтесь с ним и завершите выполнение программы.
*/

public static class Task6
{
    public static void Run()
    {
        int[] massive = new int[5];
        byte choice;
        while (true)
        {
            Console.Write("1. Вывести список\n");
            Console.Write("2. Заполнить список\n");
            Console.Write("3. Вывести длину списка\n");
            Console.Write("4. Вывести первый и последний элементы списка\n");
            Console.Write("0. Завершить программу\n");
            Console.WriteLine("\nВвод: ");
            choice = byte.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("[ ");
                    foreach (int elem in massive) Console.Write(elem + " ");
                    Console.Write("]\n");
                    break;
                case 2:
                    for (byte i = 0; i < massive.Length; i++)
                    {
                        Console.WriteLine($"Введите число с индексом {i}: ");
                        int userInput = int.Parse(Console.ReadLine());
                        massive[i] = userInput;
                    }
                    Console.WriteLine("Заполнение списка завершено.");
                    break;
                case 3:
                    Console.WriteLine($"Длина списка: {massive.Length}");
                    break;
                case 4:
                    Console.WriteLine($"Первый элемент списка: {massive[0]}");
                    Console.WriteLine($"Последний элемент списка: {massive[^1]}");
                    break;
            }
            if (choice == 0)
            {
                Console.WriteLine("Завершение программы. До свидания!");
                break;
            }
        }
    }
}