using System;
using System.Globalization;
using System.Text.RegularExpressions;

/// <summary>
/// Александр Семин
/// 
/// Создать программу, которая будет проверять корректность ввода логина.
/// Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры,
/// при этом цифра не может быть первой:
/// а) без использования регулярных выражений;
/// б) с использованием регулярных выражений.
/// </summary>
namespace Lesson5
{
    namespace Ex1
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                string login;
                while (true)
                {
                    Console.Write("Введите логин: ");
                    login = Console.ReadLine();
                    if (string.IsNullOrEmpty(login))
                        break;

                    Console.WriteLine();
                    //var authStr = AuthCommon(login) ? "authorized" : "not authorized";
                    Console.WriteLine("{0} {1}",
                        login,
                        AuthRegexp(login) ? "authorized" : "not authorized");
                }
            }

            private static bool AuthRegexp(string login)
            {
                return Regex.IsMatch(login, @"^[A-Za-z][A-Za-z0-9]{1,9}$");
            }

            private static bool AuthCommon(string login)
            {
                var length = login.Length;
                if (length < 2 || length > 10)
                    return false;
                login = login.ToLower();
                for (var i = 0; i < length; i++)
                {
                    var item = login[i];
                    if (IsDigit(item))
                    {
                        if (i == 0)
                            return false;

                        continue;
                    }

                    if (!IsLatinLetter(item))
                        return false;
                }
                return true;
            }

            //Наверное лучше было бы использовать UnicodeCategory, но не нашел там категории "только латинские буквы"
            private static bool IsLatinLetter(Char value)
            {
                return value >= 48 && value < 58;
            }

            private static bool IsDigit(Char value)
            {
                return value >= 97 && value < 123;
            }
        }
    }
}
