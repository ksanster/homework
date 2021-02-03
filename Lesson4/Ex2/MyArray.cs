using System;
using System.IO;

namespace Lesson4
{
    namespace Ex2
    {
        public class MyArray
        {
            private int[] a;

            public int Max => a.Max();
            public int Min => a.Min();
            public int CountPositiv => a.NumPositive();
            public int Sum => a.Sum();
            public int MaxCount => a.MaxCount();

            public MyArray()
            {
                a = new int[0];
            }

            public MyArray(int n, int first, int step)
            {
                a = new int[n];
                for (int i = 0; i < n; i++)
                {
                    a[i] = first;
                    first += step;
                }
            }

            public MyArray(int n, int el)
            {
                a = new int[n];
                for (int i = 0; i < n; i++)
                {
                    a[i] = el;
                }
            }

            public MyArray(string filename)
            {
                Load(filename);
            }

            public void Load(string filename)
            {
                if (!File.Exists(filename))
                {
                    Console.WriteLine($"Файла {filename} не существует");
                    return;
                }

                string[] lines = File.ReadAllLines(filename);
                a = new int[lines.Length];
                try
                {
                    for (int i = 0; i < lines.Length; i++)
                        a[i] = int.Parse(lines[i]);
                }
                catch (Exception)
                {
                    Console.WriteLine("Неверный формат файла");
                }

            }

            public void Save(string filename)
            {
                string[] lines = new string[a.Length];
                for (var i = 0; i < a.Length; i++)
                {
                    lines[i] = a[i].ToString();
                }
                File.WriteAllLines(filename, lines);
            }

            public void Invert()
            {
                a.Invert();
            }

            public void Multi(int value)
            {
                a.Multi(value);
            }


            public override string ToString()
            {
                return $"[{string.Join(", ", a)}]";
            }
        }
    }
}
