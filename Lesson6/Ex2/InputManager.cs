using System;
namespace Lesson6
{
    namespace Ex2
    {
        public class InputManager
        {
            public InputManager()
            {
            }

            public char GetNextChar(char[] allowable)
            {
                char result = '\0';
                bool success = false;
                while (!success)
                {
                    result = Console.ReadKey().KeyChar;
                    success = Array.IndexOf(allowable, result) >= 0;
                    if (!success)
                        Console.WriteLine("Ошибка! Недопустимый символ!");
                }
                return result;
            }

            public int GetNextInt()
            {
                int result = 0;
                bool success = false;
                while (!success)
                {
                    var str = Console.ReadLine();
                    success = int.TryParse(str, out result);
                    if (!success)
                        Console.WriteLine("Ошибка! Значение не является целым числом!");
                }
                return result;
            }

            public double GetNextDouble()
            {
                double result = 0;
                bool success = false;
                while (!success)
                {
                    var str = Console.ReadLine();
                    success = double.TryParse(str, out result);
                    if (!success)
                        Console.WriteLine("Ошибка! Значение не является double!");
                }
                return result;
            }
        }
    }
}
