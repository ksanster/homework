using System;

/// <summary>
/// Александр Семин
/// 
/// Написать метод подсчета количества цифр числа.
/// </summary>
namespace Lesson2
{
    namespace Ex2
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                for (var i = 0; i < 20; i++)
                {
                    Console.WriteLine($"Число:{i}, количество разрядов:{NumDigits(i)}");
                }
            }

            private static int NumDigits(int value)
            {
                int result = 0;
                do
                {
                    result++;
                    value /= 10;

                } while (value > 0);
                return result;
            }
        }
    }
}