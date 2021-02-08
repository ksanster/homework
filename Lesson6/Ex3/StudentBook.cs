using System;
using System.Collections.Generic;
using System.IO;

namespace Lesson6
{
    namespace Ex3
    {
        public class StudentBook
        {
            public List<Student> Students { get; } = new List<Student>();

            public StudentBook()
            {
            }

            public void Load(string Path)
            {
                string[] lines = File.ReadAllLines(Path);
                Students.Clear();
                foreach(var line in lines)
                {
                    Students.Add(Student.Create(line));
                }
            }

            public int Calc(Func<Student, bool> func)
            {
                int result = 0;
                foreach (var student in Students)
                {
                    if (func(student))
                        result++;
                }
                return result;
            }

            public int CalcByAge(int age)
            {
                return Calc(s => s.age == age);
            }

            public void SortByAge()
            {
                Sort((s1, s2) => s1.age.CompareTo(s2.age));
            }

            public void SortByAgeAndCourse()
            {
                Sort((s1, s2) =>
               {
                   int compare = s1.age.CompareTo(s2.age);
                   if (compare != 0)
                       return compare;

                   return s1.course.CompareTo(s2.course);
               });
            }

            private void Sort(Comparison<Student> comparison)
            {
                Students.Sort(comparison);
            }

            public override string ToString()
            {
                return string.Join<Student>("\n", Students);
            }

        }
    }
}
