using System;

/// <summary>
/// Александр Семин
/// 
/// a) Разработать рекурсивный метод, который выводит на экран числа от a до b (a<b);
/// б) Разработать рекурсивный метод, который считает сумму чисел от a до b.
/// </summary>
namespace Lesson2
{
    namespace Ex7
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                int from = 1;
                int to = 5;
                Console.WriteLine($"Сумма чисел от {from} до {to} равна {Summ(from, to)}");
            }

            private static int Summ(int from, int to)
            {
                if (from > to)
                    return 0;

                Console.WriteLine(from);
                return from + Summ(from + 1, to);
            }
        }
    }
}