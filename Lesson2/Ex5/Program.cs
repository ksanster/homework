using System;
/// <summary>
/// Александр Семин
/// 
/// Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или все в норме;
/// Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
/// </summary>
namespace Lesson2
{
    namespace Ex5
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                const double minBound = 18.5;
                const double maxBound = 25;

                var imt = CalcIMT(out var weight, out var height);
                Console.WriteLine(string.Format("Ваш индекс массы тела равен {0:F3}", imt));
                if (imt >= minBound && imt <= maxBound)
                {
                    Console.WriteLine("Это соответствует норме");
                    return;
                }
                double delta;
                if (imt < minBound)
                {
                    delta = minBound * height * height - weight;
                    Console.WriteLine(string.Format("Вам необходимо набрать еще по крайней мере {0:F2} кг", delta));
                }
                else
                {
                    delta = weight - maxBound * height * height;
                    Console.WriteLine(string.Format("Вам необходимо сбросить по крайней мере {0:F2} кг", delta));
                }
            }

            private static double CalcIMT(out double weight, out double height)
            {
                Console.WriteLine("Введите рост в метрах: ");
                height = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите вес в килограммах: ");
                weight = Convert.ToDouble(Console.ReadLine());

                if (weight <= 0)
                    throw new ArgumentException("Неверное значение массы");

                if (height <= 0)
                    throw new ArgumentException("Неверное значение роста");

                return weight / (height * height);
            }

        }
    }
}
