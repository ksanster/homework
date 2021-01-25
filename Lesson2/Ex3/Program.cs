using System;
/// <summary>
/// Александр Семин
/// 
/// С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.
/// </summary>
namespace Lesson2
{
    namespace Ex3
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                int value;
                int result = 0;
                do
                {
                    if (!InputNextValue(out value))
                        continue;

                    if (value < 0 || !IsOdd(value))
                        continue;

                    result += value;
                } while (value != 0);
                Console.WriteLine($"Сумма нечетных положительных чисел равна {result}");
            }

            private static bool IsOdd(int value)
            {
                return value % 2 != 0;
            }

            private static bool InputNextValue(out int value)
            {
                bool success = false;
                try
                {
                    Console.WriteLine("Введите целое число (или 0 для завершения):");
                    value = Convert.ToInt32(
                                        Console.ReadLine());
                    success = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка! Значение не является целым числом!");
                    value = -1;
                }
                return success;
            }
        }
    }

}
