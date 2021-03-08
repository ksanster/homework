using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3
{
    public class Student
    {
        public static Student Create(string row)
        {
            var items = row.Split(new char[] { ';' }, StringSplitOptions.None);
            return new Student(items[0], items[1], items[2], items[3], items[4], int.Parse(items[5]), int.Parse(items[6]), int.Parse(items[7]), items[8]);
        }

        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public int course;
        public string department;
        public int group;
        public string city;
        public int age;
        
        public Student()
        {

        }

        public Student(string firstName, string lastName, string university, string faculty, string department, int age, int course, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.course = course;
            this.age = age;
            this.group = group;
            this.city = city;
        }

        public override string ToString()
        {
            return $"{lastName} {firstName} [age:{age}, course:{course}]";
        }
    }
}
