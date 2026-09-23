/*
Задание 5.
В массиве x хранятся значения  5 аргументов функции f(x)=3x+1.
Создайте массив y, заполненными соответствующими значениями для каждого x.
Расчёты должны быть автоматизированными.
Пример:
x	-1	0	1	2	3
y	-2	1	4	7	10
*/

public static class Task5
{
    public static void Run()
    {
        double[] x = [ -1, 0, 1, 2, 3 ];
        double[] y = new double[5];
        for (uint i = 0; i < x.Length; i++) y[i] = 3*x[i]+1;
        Console.Write("x: ");
        foreach (double elem in x) Console.Write(elem + " ");
        Console.Write("\ny: ");
        foreach (double elem in y) Console.Write(elem + " ");
    }
}