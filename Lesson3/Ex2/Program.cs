using System;
/// <summary>
/// а) С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке).
/// Требуется подсчитать сумму всех нечетных положительных чисел. Сами числа и сумму вывести на экран, используя tryParse;
///б) Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные.
///При возникновении ошибки вывести сообщение. Напишите соответствующую функцию;
/// </summary>
namespace Lesson3
{
    namespace Ex2
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                var inputManager = new InputManager();
                int value = 0;
                int sum = 0;
                do
                {
                    Console.WriteLine("Введите целое число (или 0 для завершения):");
                    value = inputManager.GetNextInt();
                    if (value > 0 && value.IsOdd())
                    {
                        if (int.MaxValue - value < sum)
                            throw new Exception("Переполнение! Невозможно продолжить работу!");

                        sum += value;
                    }
                } while (value != 0);
                Console.WriteLine($"Сумма нечетных положительных чисел равна {sum}");
            }
        }
    }
}
