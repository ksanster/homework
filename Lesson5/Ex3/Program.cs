using System;
using System.Collections.Generic;
/// <summary>
/// Александр Семин
///
/// Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой. Регистр можно не учитывать:
/// 
/// а) с использованием методов C#;
/// б) *разработав собственный алгоритм.
/// </summary>
namespace Lesson5
{
    namespace Ex3
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                var s1 = "АПЕЛЬСИН";
                var s2 = "СПАНИЕЛЬ";
                Console.WriteLine("{0}, {1}: {2}",
                    s1,
                    s2,
                    IsAnagramm1(s1, s2) ? "анаграммы" : "не анаграммы");

                s2 = "СПОНИЕЛЬ";
                Console.WriteLine("{0}, {1}: {2}",
                    s1,
                    s2,
                    IsAnagramm2(s1, s2) ? "анаграммы" : "не анаграммы");
            }


            // Предварительная сортировка внесет дополнительную задержку, но заметно это будет только на больших словах и больших объемах данных
            private static bool IsAnagramm1(string s1, string s2)
            {
                if (s1.Length != s2.Length)
                    return false;

                var chars1 = s1.ToCharArray();
                var chars2 = s2.ToCharArray();
                Array.Sort(chars1);
                Array.Sort(chars2);

                return string.Join(string.Empty, chars1) == string.Join(string.Empty, chars2);
            }

            private static bool IsAnagramm2(string s1, string s2)
            {
                if (s1.Length != s2.Length)
                    return false;

                var chars1 = s1.ToCharArray();
                var chars2 = s2.ToCharArray();
                var hash = new Dictionary<char, int>();

                foreach (var item in chars1)
                {
                    if (!hash.ContainsKey(item))
                        hash[item] = 0;

                    hash[item]++;
                }

                foreach (var item in chars2)
                {
                    if (!hash.ContainsKey(item))
                        hash[item] = 0;

                    hash[item]--;
                }

                foreach ( var pair in hash)
                {
                    if (pair.Value < 0)
                        return false;
                }
                return true;
            }

        }
    }
}
