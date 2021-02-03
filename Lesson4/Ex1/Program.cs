using System;
/// <summary>
/// Александр Семин
///
/// Дан целочисленный массив из 20 элементов.
/// Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно.
/// Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых хотя бы одно число делится на 3.
/// В данной задаче под парой подразумевается два подряд идущих элемента массива.
/// Например, для массива из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4.
/// </summary>
namespace Lesson4
{
    namespace Ex1
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                const int min = -10000;
                const int max = 10000;
                const int denominator = 3;
                int[] ar = CreateAndFill(20, min, max);
                //int[] ar = { 6, 2, 9, -3, 6 };
                int result = CountOfPairs(ar, denominator);

                Console.WriteLine($"Для массива [{string.Join(", ", ar)}]");
                Console.WriteLine($"количество пар цифр, делящихся на {denominator}, равно {result}");
            }

            private static int CountOfPairs(int[] arr, int denominator)
            {
                int result = 0;
                var numIt = arr.Length - 1;
                for (int i = 0; i < numIt; i++)
                {
                    var condition1 = (arr[i] % denominator == 0);
                    var condition2 = (arr[i + 1] % denominator == 0);
                    if (condition1 || condition2)
                        result++;
                }

                return result;
            }

            private static int[] CreateAndFill(int length, int min, int max)
            {
                int[] result = new int[length];
                Random rnd = new Random();
                for (int i = 0; i < length; i++)
                {
                    result[i] = rnd.Next(min, max);
                }

                return result;
            }
        }
    }
}
