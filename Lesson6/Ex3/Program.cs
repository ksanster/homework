using System;
using System.IO;
/// <summary>
/// Александр Семин
/// 
/// Переделать программу «Пример использования коллекций» для решения следующих задач:
/// 
/// а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
/// б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (частотный массив);
/// в) отсортировать список по возрасту студента;
/// г) *отсортировать список по курсу и возрасту студента;
/// д) разработать единый метод подсчета количества студентов по различным параметрам выбора с помощью делегата и методов предикатов.
/// </summary>
namespace Lesson6
{
    namespace Ex3
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                const string Path = "../../Data/students.csv";

                var book = new StudentBook();
                book.Load(Path);

                Console.WriteLine(book);
                Console.WriteLine();

                book.SortByAge();
                Console.WriteLine("Отсортированный по возрасту");
                Console.WriteLine(book);
                Console.WriteLine();

                book.SortByAgeAndCourse();
                Console.WriteLine("Отсортированный по возрасту и курсу");
                Console.WriteLine(book);
                Console.WriteLine();

                var count = book.Calc(s => s.course == 5 || s.course == 6);
                Console.WriteLine($"Студентов на 5 и 6 курсах: {count}");
                Console.WriteLine();

                for (int i = 18; i <= 20; i++)
                {
                    count = book.Calc(s => s.age == i);
                    Console.WriteLine($"Студентов в возрасте {i} лет: {count}");
                }
            }
        }
    }
}
