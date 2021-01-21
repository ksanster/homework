using System;
/*
    Александр Семин.

    Ввести вес и рост человека.
    Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); где m — масса тела в килограммах, h — рост в метрах
 */
namespace Lesson1
{
    namespace Ex2
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                Console.Clear();

                Console.WriteLine("Введите рост в метрах: ");
                double height = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите вес в килограммах: ");
                double weight = Convert.ToDouble(Console.ReadLine());

                if (weight <= 0)
                    throw new ArgumentException("Неверное значение массы");

                if (height <= 0)
                    throw new ArgumentException("Неверное значение роста");

                double imt = CalcIMT(weight, height);
                Console.WriteLine($"Индекс массы тела: {imt.ToString("F4")}");

            }

            private static double CalcIMT(double m, double h)
            {
                return m / (h * h);
            }
        }
    }
}
