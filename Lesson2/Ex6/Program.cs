using System;
using System.Collections.Generic;
/// <summary>
/// Александр Семин
/// 
/// Написать программу подсчета количества «Хороших» чисел в диапазоне от 1 до 1 000 000 000.
/// Хорошим называется число, которое делится на сумму своих цифр.
/// Реализовать подсчет времени выполнения программы, используя структуру DateTime.
/// </summary>
namespace Lesson2
{
    namespace Ex6
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                const int maxValue = 1000000000;

                Console.Clear();

                DateTime start = DateTime.Now;

                int goodsCount = 0;
                Console.CursorVisible = false;
                for (var i = 1; i <= maxValue; i++)
                {
                    if (IsGoodNumber(i))
                        goodsCount++;
                }

                Console.WriteLine();
                Console.WriteLine($"Количество \"хороших\" чисел: {goodsCount}");
                Console.WriteLine($"Время выполнения: {(DateTime.Now - start).Milliseconds} миллисекунд");
                Console.CursorVisible = true;

                //Количество "хороших" чисел: 61574510
                //Время выполнения: 934 миллисекунд
            }

            private static bool IsGoodNumber(int value)
            {
                return value % SummOfDigits(value) == 0;
            }

            private static int SummOfDigits(int value)
            {
                int s = 0;
                for (int i = value; i != 0; i /= 10)
                {
                    s += i % 10;
                }
                return s;

            }

            // Попытался ускорить вычисления путем кеширования результатов
            // (Начинаем считать сумму знаков с левого разряда и после подсчета заносим ее в кеш
            // Предполагается, что время уменьшится из-за того, что не не нужно каждый раз пересчитывать суммы младших разррядов)
            // Результат отрицательный: при малом количестве итераций времени затрачивается больше, чем при решении "в лоб",
            // при количестве итераций, равном 1 000 000 000, приложение падает из-за нехватки памяти

            private static Dictionary<string, int> cache = new Dictionary<string, int>
            {
                {string.Empty, 0}
            };

            private static int Summ(string value)
            {
                if (cache.ContainsKey(value))
                    return cache[value];

                int result = Convert.ToInt32(value.Substring(0, 1)) + Summ(value.Substring(1));
                cache[value] = result;

                return result;
            }
        }
    }
}
