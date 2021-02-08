using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
/// <summary>
/// Александр Семин
///
/// Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
/// 
/// а) Сделайте меню с различными функциями и предоставьте пользователю выбор, для какой функции и на каком отрезке находить минимум.
/// б) Используйте массив(или список) делегатов, в котором хранятся различные функции.
/// в) *Переделайте функцию Load, чтобы она возвращала массив считанных значений. Пусть она возвращает минимум через параметр.
/// </summary>
namespace Lesson6
{
    namespace Ex2
    {

        public class MainClass
        {
            private class FunctionDescriptor
            {
                public char Id { get; }
                public string Description { get; }
                public Func<double, double> Function { get; }

                public FunctionDescriptor(char id, string description, Func<double, double> func)
                {
                    Id = id;
                    Description = description;
                    Function = func;
                }
            }

            private static Dictionary<char, FunctionDescriptor> functions = new Dictionary<char, FunctionDescriptor>();

            static MainClass()
            {
                var descriptor = new FunctionDescriptor('s', "square", x => x * x);
                functions[descriptor.Id] = descriptor;

                descriptor = new FunctionDescriptor('r', "root", x => Math.Sqrt(x));
                functions[descriptor.Id] = descriptor;

                descriptor = new FunctionDescriptor('i', "sin", x => Math.Sin(x));
                functions[descriptor.Id] = descriptor;

                descriptor = new FunctionDescriptor('o', "cos", x => Math.Cos(x));
                functions[descriptor.Id] = descriptor;
            }

            public static void Main(string[] args)
            {
                const string Path = "../../Data/data.bin";
                var inputManager = new InputManager();
                Console.Write("Выберите функцию. [");
                foreach (var pair in functions)
                {
                    Console.Write(string.Format("{0}:{1}; ", pair.Value.Id.ToString(), pair.Value.Description));
                }
                Console.CursorLeft -= 2;
                Console.Write("]: ");
                var id = inputManager.GetNextChar(functions.Keys.ToArray());
                var func = functions[id].Function;
                Console.WriteLine();

                Console.Write("Начало диапазона: ");
                var a = inputManager.GetNextDouble();
                Console.WriteLine();

                Console.Write("Конец диапазона: ");
                var b = inputManager.GetNextDouble();
                Console.WriteLine();

                Console.Write("Шаг: ");
                var h = inputManager.GetNextDouble();
                Console.WriteLine();

                SaveFunc(Path, func, a, b, h);

                var values = Load(Path, out var min);
                foreach (var value in values)
                {
                    Console.WriteLine("| {0,8:0.000} |", value);
                }
                Console.WriteLine($"Минимальное значение: {min}");
            }

            private static void SaveFunc(string fileName, Func<double, double> func, double a, double b, double h)
            {
                FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                double x = a;
                while (x <= b)
                {
                    Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, func(x));
                    bw.Write(func(x));
                    x += h;
                }
                bw.Close();
                fs.Close();
                Console.WriteLine();
            }

            private static double[] Load(string fileName, out double min)
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader bw = new BinaryReader(fs);
                min = double.MaxValue;
                double d;
                long count = fs.Length / sizeof(double);
                double[] result = new double[count];
                for (int i = 0; i < count; i++)
                {
                    result[i] = bw.ReadDouble();
                    
                    if (result[i] < min)
                        min = result[i];
                }
                bw.Close();
                fs.Close();
                return result;
            }
        }
    }
}
