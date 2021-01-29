using System;

/*
    Александр Семин.
    Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры
    Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса
*/
namespace Lesson3
{
    namespace Ex1
    {
        public class MainClass
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("Операции cо структурой");
                Complex s1;
                s1.re = 2.0;
                s1.im = 5.0;
                Complex s2;
                s2.re = 5.0;
                s2.im = 10.0;
                Console.WriteLine($"{s1} + {s2} = {s1.Add(s2)}");
                Console.WriteLine($"{s1} - {s2} = {s1.Sub(s2)}");

                var c1 = new ComplexClass(1, 2);
                var c2 = new ComplexClass(.5, 2);
                Console.WriteLine("Операции с классом");
                Console.WriteLine($"{c1} + {c2} = {c1 + c2}");
                Console.WriteLine($"{c1} - {c2} = {c1 - c2}");
                Console.WriteLine($"0.5 * {c1} = {0.5 * c1}");
                Console.WriteLine($"{c1} * 0.5 = {c1 * 0.5}");
            }
        }
    }
}