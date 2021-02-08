using System;
using System.IO;
/// <summary>
/// Александр Семин
///
/// Разработать класс Message, содержащий следующие статические методы для обработки текста:
/// а) Вывести только те слова сообщения, которые содержат не более n букв.
/// б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
/// в) Найти самое длинное слово сообщения.
/// г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
/// Продемонстрируйте работу программы на текстовом файле с вашей программой.
/// </summary>
namespace Lesson5
{
    namespace Ex2
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                const int Length = 5;
                const char Letter = 'я';
                const string Path = "../../Data/data.txt";

                string[] lines = File.ReadAllLines(Path);
                string text = string.Join("\n", lines);

                Console.WriteLine($"Слова, содержащие не больше {Length} букв: {string.Join(" ", text.WordsShorterThan(Length))}");
                Console.WriteLine();
                Console.WriteLine($"Слова, заканчивающииеся на {Letter}: {string.Join(" ", text.WordsEndsWithLetter(Letter))}");
                Console.WriteLine();
                Console.WriteLine($"Самое длинное слово: {text.WordWithMaxLength()}");
                Console.WriteLine();
                Console.WriteLine($"Строка из самых длинных слов: {text.PhraseFromWordWithMaxLength()}");
            }
        }
    }
}
