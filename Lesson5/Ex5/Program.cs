using System;
using System.Collections.Generic;
using System.IO;
/// <summary>
/// Александр Семин
/// 
/// Написать игру «Верю. Не верю».
/// В файле хранятся вопрос и ответ, правда это или нет.
/// Например: «Шариковую ручку изобрели в древнем Египте», «Да».
/// Компьютер загружает эти данные, случайным образом выбирает 5 вопросов и задаёт их игроку.
/// Игрок отвечает Да или Нет на каждый вопрос и набирает баллы за каждый правильный ответ.
/// </summary>

namespace Lesson5
{
    namespace Ex5
    {
        class MainClass
        {
            //Можно более красиво выводить вопросы, печатать расширенные ответы, но наверное это лишнее для задания
            public static void Main(string[] args)
            {
                const string Path = "../../Data/data.txt";
                string[] lines = File.ReadAllLines(Path);
                List<Question> questions = new List<Question>();
                foreach ( var line in lines)
                {
                    questions.Add( Question.Create(line) );
                }


                int score = 0;
                int count = 5;
                Random rnd = new Random();
                while (count-- > 0)
                {
                    if (questions.Count == 0)
                        break;

                    var index = rnd.Next(0, questions.Count);
                    var question = questions[index];
                    questions.Remove(question);
                    Console.WriteLine($"{question.Text} [y/n]");
                    char answer;
                    while (true)
                    {
                        answer = Console.ReadKey().KeyChar;
                        Console.WriteLine();
                        if (answer == 'y' || answer == 'n')
                            break;

                        Console.WriteLine("Нажмите 'y', если согласны или 'n' если нет");
                    }
                    if (answer == 'y' && question.IsTrue || !question.IsTrue)
                        score++;
                }

                Console.WriteLine($"Поздравляем! Заработано очков: {score}!");
            }
        }
    }
}
