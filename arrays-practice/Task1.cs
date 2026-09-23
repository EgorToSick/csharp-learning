/*Задание 1.
Преподавателю физики требуется обработать отметки 5 учеников за экзамен. Отметки － целые числа 2, 3, 4, 5. 
Заполните массив размера 5 отметками, также введёнными с клавиатуры.
Выведите на экран с соответствующими комментариями:
А) Количество учеников, которые получили «5». Если таких учеников нет, выведите на экран текст «Отличники не найдены».
Б) Количество учеников, которые не справились с экзаменом. Если таких учеников нет, выведите на экран текст «Все ученики справились с экзаменом».
В) Количество учеников, которые получили «3» и «4».
Г) Средний балл по классу.
*/

public static class Task1
{
    public static void Run()
    {
        byte[] marks = new byte[5];
        for (byte i = 0; i < marks.Length; i++)
        {
            Console.WriteLine($"Введите отметку {i+1}: ");
            byte userInput = Byte.Parse(Console.ReadLine());
            if ((userInput >= 1) && (userInput <= 5)) marks[i] = userInput;
        }
        int great = marks.Count(x => x == 5);
        if (great > 0) Console.WriteLine($"{great} отличников");
        else Console.WriteLine("Отличники не найдены");
        int fail = marks.Count(x => x == 2);
        if (fail > 0) Console.WriteLine($"{fail} учеников не справилось в экзаменом");
        else Console.WriteLine("Все ученики справились с экзаменом");
        int three = marks.Count(x => x == 3);
        int four = marks.Count(x => x == 4);
        int others = three + four;
        Console.WriteLine($"{others} учеников получили \"3\" или \"4\"");
        double sum = 0;
        foreach (byte x in marks) sum += x;
        sum = sum / marks.Length;
        Console.WriteLine($"Средний балл по классу равен {sum}");
    }
}