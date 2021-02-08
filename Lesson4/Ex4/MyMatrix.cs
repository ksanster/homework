using System;
using System.IO;

namespace Lesson4
{
    namespace Ex4
    {
        public class MyMatrix
        {
            private int[,] arr;

            public int Min => GetMinValue(out var i, out var j);
            public int Max => GetMaxValue(out var i, out var j);

            public MyMatrix(int cols, int rows, int min, int max)
            {
                arr = new int[rows, cols];
                Fill(min, max);
            }

            public MyMatrix(string filename)
            {
                Load(filename);
            }

            private void Fill(int min, int max)
            {
                int rows = arr.GetLength(0);
                int cols = arr.GetLength(1);
                Random rnd = new Random();
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        arr[i, j] = rnd.Next(min, max);
                    }
                }
            }

            public void Load(string filename)
            {
                if (!File.Exists(filename))
                {
                    Console.WriteLine($"Файла {filename} не существует");
                    return;
                }

                string[] lines = File.ReadAllLines(filename);
                if (lines.Length < 2)
                {
                    Console.WriteLine($"Неверный формат файла {filename}");
                    return;
                }

                try
                {
                    int cols = int.Parse(lines[0]);
                    int rows = int.Parse(lines[1]);
                    arr = new int[rows, cols];

                    int index = 2;
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            arr[i, j] = int.Parse(lines[index++]);
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"Неверный формат файла {filename}");
                }
            }

            public void Save(string filename)
            {
                int rows = arr.GetLength(0);
                int cols = arr.GetLength(1);

                string[] lines = new string[rows * cols + 2];
                lines[0] = cols.ToString();
                lines[1] = rows.ToString();

                int index = 2;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        lines[index++] = arr[i, j].ToString();
                    }
                }
                try
                {
                    File.WriteAllLines(filename, lines);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка записи в файл {filename}");
                    Console.WriteLine(e.Message);
                }
                
            }

            public long Sum()
            {
                long result = 0;
                int rows = arr.GetLength(0);
                int cols = arr.GetLength(1);
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        result += arr[i, j];
                    }
                }
                return result;
            }

            public long SumBigger(int value)
            {
                long result = 0;
                int rows = arr.GetLength(0);
                int cols = arr.GetLength(1);
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (arr[i, j] > value)
                        {
                            result += arr[i, j];
                        }
                            
                    }
                }
                return result;
            }

            public int GetMinValue(out int row, out int col)
            {
                int result = arr[0, 0];
                int rows = arr.GetLength(0);
                int cols = arr.GetLength(1);

                row = 0;
                col = 0;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (result > arr[i, j])
                        {
                            result = arr[i, j];
                            row = i;
                            col = j;
                        }
                    }
                }
                return result;
            }


            public int GetMaxValue(out int row, out int col)
            {
                int result = arr[0, 0];
                int rows = arr.GetLength(0);
                int cols = arr.GetLength(1);

                row = 0;
                col = 0;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (result < arr[i, j])
                        {
                            result = arr[i, j];
                            row = i;
                            col = j;
                        }
                    }
                }
                return result;
            }

            public override string ToString()
            {
                string result = string.Empty;
                int rows = arr.GetLength(0);
                int cols = arr.GetLength(1);
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        result += arr[i, j].ToString();
                        if (j < cols - 1)
                            result += ", ";
                    }
                    result += "\n";
                }
                return result;
            }
        }
    }
}
