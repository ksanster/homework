using System;
using System.Collections.Generic;

namespace Lesson4
{
    namespace Ex2
    {
        public static class ArrayExtensions
        {
            public static long Sum(this int[] arr)
            {
                int result = 0;
                foreach (int i in arr)
                {
                    result += i;
                }
                return result;
            }

            public static int MaxCount(this int[] arr)
            {
                int max = int.MinValue;
                Dictionary<int, int> counts = new Dictionary<int, int>();
                for (int i = 0; i < arr.Length; i++)
                {
                    var value = arr[i];
                    if (!counts.ContainsKey(value))
                        counts[value] = 1;
                    else
                        counts[value]++;

                    if (value > max)
                        max = value;
                }
                return counts[max];
            }

            public static void Invert(this int[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = -arr[i];
                }
            }

            public static void Multi(this int[] arr, int value)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = value * arr[i];
                }
            }

            public static int Max(this int[] arr)
            {
                int max = arr[0];
                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i] > max)
                        max = arr[i];
                }
                return max;
            }

            public static int Min(this int[] arr)
            {
                int min = arr[0];
                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i] < min)
                        min = arr[i];
                }
                return min;
            }

            public static int NumPositive(this int[] arr)
            {
                int count = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] > 0)
                        count++;
                }
                return count;

            }
        }
    }
}
