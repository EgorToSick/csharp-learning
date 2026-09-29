/*
Задача 3
Снятие средств с банковского счёта
Ручная генерация исключения с помощью throw.
*/
public static class Task3
{
    public static void Run()
    {
        Console.WriteLine("\nЗадача 2. Снятие средств с банковского счёта");
        decimal balance = 100.00m;
        while (true)
        {
            try
            {
                Console.WriteLine($"{balance} рублей на балансе.\nСколько денег вы хотите снять?");
                Console.Write("Ввод: ");
                decimal take = decimal.Parse(Console.ReadLine());
                if (take <= balance)
                {
                    balance -= take;
                    Console.WriteLine("Деньги были сняты");
                    Console.WriteLine($"Теперь на балансе: {balance}");
                    break;
                }
                else throw new Exception("Недостаточно средств!");
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Ошибка типа данных! Повторите попытку");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}