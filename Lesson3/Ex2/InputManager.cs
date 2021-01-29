using System;
namespace Lesson3
{
    namespace Ex2
    {
        public class InputManager
        {
            public InputManager()
            {
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
        }
    }
}
