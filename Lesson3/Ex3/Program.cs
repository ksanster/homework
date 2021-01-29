using System;
/// <summary>
/// Описать класс дробей - рациональных чисел, являющихся отношением двух целых чисел.
/// Предусмотреть методы сложения, вычитания, умножения и деления дробей.
/// Написать программу, демонстрирующую все разработанные элементы класса. 
/// **Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение
/// ArgumentException("Знаменатель не может быть равен 0");
/// Добавить упрощение дробей.
/// </summary>
namespace Lesson3
{
    namespace Ex3
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                Fraction v1 = new Fraction(1, 2);
                Fraction v2 = new Fraction(2, 3);

                Console.WriteLine("Операции с дробями");
                Console.WriteLine($"{v1} + {v2} = {v1 + v2}");
                Console.WriteLine($"{v1} - {v2} = {v1 - v2}");
                Console.WriteLine($"{v1} * {v2} = {v1 * v2}");
                Console.WriteLine($"{v1} / {v2} = {v1 / v2}");

                v1 = new Fraction();
                v1.Numerator = 4;
                v1.Denominator = 6;

                Console.WriteLine($"[4/6] after reduct is {v1}");
            }
        }
    }
}
