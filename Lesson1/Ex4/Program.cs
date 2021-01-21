using System;

/*
    Александр Семин.

    Написать программу обмена значениями двух переменных.
    а) с использованием третьей переменной;
    б) *без использования третьей переменной.
*/
namespace Lesson1
{
    namespace Ex4
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                double a = 112;
                double b = 35;
                Console.WriteLine($"Сначала а={a}, b={b}");
                #region a
                double c = a;
                a = b;
                b = c;
                Console.WriteLine($"Сейчас а={a}, b={b}");
                #endregion
                #region b
                a = a + b;
                b = a - b;
                a = a - b;
                Console.WriteLine($"А теперь а={a}, b={b}");
                #endregion
            }
        }
    }
}
