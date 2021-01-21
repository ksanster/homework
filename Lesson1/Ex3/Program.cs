using System;

/*
Александр Семин.

Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2
по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2).
Вывести результат, используя спецификатор формата .2f (с двумя знаками после запятой)

*/
namespace Lesson1
{
    namespace Ex3
    {

        class MainClass
        {
            public static void Main(string[] args)
            {
                var p1 = new Point();
                var p2 = new Point(5, 5);
                var distance = CalcDistance(p1, p2);

                Console.WriteLine($"Расстояние между [{p1.X}, {p1.Y}] и [{p2.X}, {p2.Y}] равно {distance.ToString("F2")}");
            }

            private static double CalcDistance(Point p1, Point p2)
            {
                return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
            }
        }
    }
}
