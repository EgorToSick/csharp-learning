Console.WriteLine("Учебные задания по работе с массивами");

while (true)
{
    Console.Write("\n1. Вывести задание 1\n");
    Console.Write("2. Вывести задание 2\n");
    Console.Write("3. Вывести задание 3\n");
    Console.Write("4. Вывести задание 4\n");
    Console.Write("5. Вывести задание 5\n");
    Console.Write("6. Вывести задание 6\n");
    Console.Write("0. Выйти");
    Console.Write("\nВвод: ");
    byte userInput = byte.Parse(Console.ReadLine());
    switch (userInput)
    {
        case 1:
            Console.WriteLine($"Запускаем задание {userInput}");
            Task1.Run();
            Console.WriteLine($"\nЗадание {userInput} завершено");
            break;
        case 2:
            Console.WriteLine($"Запускаем задание {userInput}");
            Task2.Run();
            Console.WriteLine($"\nЗадание {userInput} завершено");
            break;
        case 3:
            Console.WriteLine($"Запускаем задание {userInput}");
            Task3.Run();
            Console.WriteLine($"\nЗадание {userInput} завершено");
            break;
        case 4:
            Console.WriteLine($"Запускаем задание {userInput}");
            Task4.Run();
            Console.WriteLine($"\nЗадание {userInput} завершено");
            break;
        case 5:
            Console.WriteLine($"Запускаем задание {userInput}");
            Task5.Run();
            Console.WriteLine($"\nЗадание {userInput} завершено");
            break;
        case 6:
            Console.WriteLine($"Запускаем задание {userInput}");
            Task6.Run();
            Console.WriteLine($"\nЗадание {userInput} завершено");
            break;
    }
    if (userInput == 0) break;
}