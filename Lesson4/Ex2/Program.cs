using System;
/// <summary>
/// Александр Семин
///
/// а) Дописать класс для работы с одномерным массивом.
/// Реализовать конструктор, создающий массив заданной размерности и заполняющий массив числами от начального значения с заданным шагом.
/// Создать свойство Sum, которые возвращают сумму элементов массива,
/// метод Inverse, меняющий знаки у всех элементов массива,
/// метод Multi, умножающий каждый элемент массива на определенное число,
/// свойство MaxCount, возвращающее количество максимальных элементов.
/// В Main продемонстрировать работу класса.

/// б)Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл
/// </summary>
namespace Lesson4
{
    namespace Ex2
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                const string Path = "../../Data/array.txt";

                var arr = new MyArray(Path);
                //var arr = new MyArray(10, -10, 2);
                //var arr = new MyArray(10, 10);
                Console.WriteLine(arr);
                Console.WriteLine($"Sum={arr.Sum}");
                Console.WriteLine($"Max={arr.Max}, MaxCount={arr.MaxCount}");

                arr.Invert();
                Console.WriteLine($"After invert:");
                Console.WriteLine(arr);

                arr.Multi(2);
                Console.WriteLine($"After mult:");
                Console.WriteLine(arr);
                arr.Save(Path);
            }
        }
    }
}
