using System;
using System.Linq;

namespace Ex4
{
    public class Student
    {
        public static Student Create (string row)
        {
            var items = row.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (items.Length < 2)
                throw new ArgumentException("Wrong format");

            var result = new Student
            {
                Name = $"{items[0]} {items[1]}",
                Rates = new int[items.Length - 2]
            };
            for (var i = 2; i < items.Length; i++)
            {
                result.Rates[i - 2] = int.Parse(items[i]);
            }
            return result;
        }

        public string Name { get; set; }
        public int[] Rates { get; set; }

        public double AverageRate => Rates.Average();

    }
}
