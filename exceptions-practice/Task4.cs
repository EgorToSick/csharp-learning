/*
Задача 4
Вы — искатель сокровищ, который отправился в древний лабиринт. 
В лабиринте вам нужно выполнить несколько заданий, чтобы пройти дальше. 
Каждое задание — арифметическая операция или условие, 
а в конце — подсчет общего количества собранных монет. 
В процессе могут возникнуть ошибки (например, деление на ноль, 
некорректный ввод или неправильный выбор).
Создать консольную программу, которая:
1.	Просит пользователя ввести количество монет (N), которые он планирует 
заработать по итогу испытаний.
2.	Выполняет три испытания:
•	Испытание 1: Деление числа 100 на введенное пользователем число 
(делить на 0 нельзя!) если получается целое число — проходит дальше. 
Иначе: завершение испытаний.
•	Испытание 2: Условие — если введённое число больше 50, выводит 
сообщение "Достаточно богат, проходи дальше", иначе — "Мало монет".
•	Испытание 3: Пользователь вводит 5 чисел (монет), и программа 
подсчитывает их сумму. Если сумма введённых и первого числа (N) оказалась 
чётным числом, он побеждает и забирает свои желанные монеты. Иначе: 
количество монет аннулируется.

*/
public static class Task4
{
    public static void Run()
    {
        Console.WriteLine("\nЗадача 4. Искатель сокровищ");
        int coins;
        Console.WriteLine("Ты искатель сокровищ, который отправился в древний лабиринт.");
        while (true)
        {
            try
            {
                Console.Write("Сколько хочешь заработать?\nВвод: ");
                coins = int.Parse(Console.ReadLine());
                if (coins<0) Console.WriteLine("Минус монеты? Это значит отдать? Введи положительное!");
                else break;
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Монеты - это целое число!");
            }
            catch
            {
                Console.WriteLine("Непредвиденная ошибка!");
            }
        }
        Console.WriteLine("Испытание 1. Деление числа 100 на введённое число.");
        try
        {
            float result1 = 100 / (float)coins;
            if (100 % coins == 0)
            {
                Console.WriteLine($"Получается целое число {(int)result1}");
                Console.WriteLine("Идём дальше!");
            }
            else
            {
                Console.WriteLine("Целого числа не получается! Завершение путешествия.");
                goto endOfProgram;
            }
        }
        catch (System.FormatException)
        {
            Console.WriteLine("Ошибка формата");
        }
        catch (System.DivideByZeroException)
        {
            Console.WriteLine("Деление на 0! Ты реально не хочешь заработать? Твоё путешествие закончено.");
            goto endOfProgram;
        }
        catch
        {
            Console.WriteLine("Непредвиденная ошибка!");
        }

        Console.WriteLine("Испытание 2. Монет больше 50-ти?");
        if (coins > 50) Console.WriteLine("Больше! Идём дальше!");
        else { Console.WriteLine("Не больше! Твоё путешествие закончено! "); goto endOfProgram; }

        Console.WriteLine("Испытание 3. Введи пять чисел, обозначающих количество монет.");
        int sumCoins = 0;
        sumCoins = 0;
        for (int i = 0; i < 5; i++)
        {
            while (true)
            {
                try
                {
                    Console.Write($"Число {i + 1}: ");
                    int userInput = int.Parse(Console.ReadLine());
                    if (userInput<0) Console.WriteLine("Минус монеты? Это значит отдать? Введи положительное!");
                    else { sumCoins += userInput; break; }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Монеты - это целое число!");
                }
                catch
                {
                    Console.WriteLine("Непредвиденная ошибка!");
                }
            }
        }
        if ((sumCoins + coins) % 2 == 0)
        {
            Console.WriteLine("Отлично! Сумма введённых чисел и изначального количества монет является чётным числом!");
            Console.WriteLine("Ты успешно прошёл все испытания!");
            Console.WriteLine($"Забирай свои монеты: {coins}");
        }
        else
        {
            Console.WriteLine("Сумма введённых чисел и изначального количества монет не является чётным числом!");
            Console.WriteLine("Мы аннулируем твои монеты!");
        }
        endOfProgram:
        Console.Write("");
    }
}