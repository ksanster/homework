using System;
/// <summary>
///Александр Семин
/// 
/// Изменить программу вывода функции так, чтобы можно было передавать функции типа double (double,double).
/// Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
/// </summary>
namespace Lesson6
{
    namespace Ex1
    {
        public delegate double Fun(double a, double x);

        class MainClass
        {
            public static void Main(string[] args)
            {
                double mult = .5;
                Console.WriteLine($"Таблица функции {mult} * Sin:");
                Table(MySin, mult, -2, 2);

                Console.WriteLine($"Таблица функции {mult} * x^2:");
                Table((a, x) => a * x * x, mult, -2, 2);
            }

            public static void Table(Fun F, double a, double x, double b)
            {
                Console.WriteLine("----- X ----- Y -----");
                while (x <= b)
                {
                    Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(a, x));
                    x += 1;
                }
                Console.WriteLine("---------------------");
            }

            public static double MySin(double x, double a)
            {
                return a * Math.Sin(x);
            }

        }
    }
}
