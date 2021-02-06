using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Александр Семин
///
/// На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней
/// школы.В первой строке сообщается количество учеников N, которое не меньше 10, но не
/// превосходит 100, каждая из следующих N строк имеет следующий формат:
/// < Фамилия > < Имя > < оценки >,
/// где < Фамилия > — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не
/// более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по
/// пятибалльной системе. <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом.
/// Пример входной строки:
/// Иванов Петр 4 5 3
/// Требуется написать как можно более эффективную программу, которая будет выводить на экран
/// фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики,
/// набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.
/// </summary>
namespace Ex4
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string Path = "../../Data/data.txt";
            string[] lines = File.ReadAllLines(Path);


            var hash = new Dictionary<double, List<Student>>();
            var averages = new double[lines.Length];
            var index = 0;
            foreach (var line in lines)
            {
                var student = Student.Create(line);
                var value = student.AverageRate;
                averages[index++] = value;

                if (!hash.ContainsKey(value))
                    hash.Add(value, new List<Student>());

                hash[value].Add(student);
            }

            Array.Sort(averages);
            index = 0;
            foreach(var value in averages)
            {
                if (index++ >= 3)
                    break;

                var list = hash[value];
                foreach (var student in list)
                {
                    Console.WriteLine($"{student.Name} (средний балл:{student.AverageRate.ToString("F2")})");
                }
            }

        }
    }
}
