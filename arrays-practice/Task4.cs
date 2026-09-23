/*
Задание 4.
Создайте массив, в котором хранятся баллы за настольную игру участников команды 1 (в списке 5 элементов, баллы － дробные числа). Создайте аналогичный массив для хранения баллов команды 2.
Выведите на экран с соответствующими комментариями:
А) В какой команде набран самый высокий балл (максимум какого списка больше).
Б) В какой команде набран самый низкий балл (минимум какого списка меньше).
В) В какой команде самый высокий средний балл.
*/

public static class Task4
{
    public static void Run()
    {
        double[] teamA = [ 3.5, 6.8, 4.0, 5.4, 2.9 ];
        double[] teamB = [ 4.6, 4.3, 5.8, 7.1, 2.0 ];
        if (teamA.Max() > teamB.Max()) Console.WriteLine($"В команде А набран самый высокий балл: {teamA.Max()}");
        else if (teamA.Max() < teamB.Max()) Console.WriteLine($"В команде Б набран самый высокий балл: {teamB.Max()}");
        else Console.WriteLine("В командах одинаковый максимальный балл!");
        if (teamA.Min() < teamB.Min()) Console.WriteLine($"В команде А набран самый низкий балл: {teamA.Min()}");
        else if (teamA.Min() > teamB.Min()) Console.WriteLine($"В команде Б набран самый низкий балл: {teamB.Min()}");
        else Console.WriteLine("В командах одинаковый минимальный балл!");
        double middleA = 0.0;
        foreach (double elem in teamA) middleA += elem;
        middleA = middleA / teamA.Length;
        double middleB = 0.0;
        foreach (double elem in teamB) middleB += elem;
        middleB = middleB / teamB.Length;
        if (middleA > middleB) Console.WriteLine($"В команде А самый высокий средний балл: {middleA}");
        else if (middleA < middleB) Console.WriteLine($"В команде Б самый высокий средний балл: {middleB}");
        else Console.WriteLine("В командах одинаковых средний балл!");
    }
}
