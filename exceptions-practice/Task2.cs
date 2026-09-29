/*
Задача 2
Попросите пользователя ввести число от 1 до 10.
Обработайте неправильный ввод (например, буквы, или число вне диапазона).
В случае ошибки — повторяйте запрос, пока пользователь не введет корректное число.
*/
public static class Task2
{
    public static void Run()
    {
        Console.WriteLine("\nЗадача 2. Проверка числа на диапазон");
        float num;
        while (true)
        {
            try
            {
                Console.Write("Введите число в диапазоне от 1 до 10: ");
                num = float.Parse(Console.ReadLine());
                if ((num >= 1) && (num <= 10))
                {
                    Console.WriteLine("Успешный ввод");
                    break;
                }
                else Console.WriteLine("Не в диапазоне");
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Не является числом");
            }
        }
    }
}