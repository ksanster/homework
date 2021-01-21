using System;
/*
    Александр Семин.

    Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). В результате вся информация выводится в одну строчку.

    а) используя склеивание;
    б) используя форматированный вывод;
    в) *используя вывод со знаком $.
    */
namespace Lesson1
{
    namespace Ex1
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                Console.Clear();

                Console.WriteLine("Введите имя: ");
                string name = Console.ReadLine();
                Console.WriteLine("Введите фамилию: ");
                string surname = Console.ReadLine();
                Console.WriteLine("Введите возраст: ");
                string age = Console.ReadLine();
                Console.WriteLine("Введите рост: ");
                string height = Console.ReadLine();
                Console.WriteLine("Введите вес: ");
                string weight = Console.ReadLine();

                Console.WriteLine(name + " " + surname + ". Возраст: " + age + ", рост: " + height + ", вес: " + weight + ".");
                Console.WriteLine(string.Format("{0} {1}. Возраст: {2}, рост: {3}, вес: {4}.", name, surname, age, height, weight));
                Console.WriteLine($"{name} {surname}. Возраст: {age}, рост: {height}, вес: {weight}.");
            }
        }
    }
}
