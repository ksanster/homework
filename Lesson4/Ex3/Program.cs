using System;
using System.IO;

/// <summary>
/// Александр Семин
/// Решить задачу с логинами из предыдущего урока,
/// только логины и пароли считать из файла в массив.
/// Создайте структуру Account, содержащую Login и Password.
/// </summary>
namespace Lesson4
{
    namespace Ex3
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                const string Path = "../../Data/accounts.txt";

                string[] accounts = File.ReadAllLines(Path);
                foreach (var line in accounts)
                {
                    Account account = ParseAccount(line);
                    if (Authorize(account))
                        Console.WriteLine($"{account.Login} авторизован");
                    else
                        Console.WriteLine($"{account.Login} не авторизован");
                }
            }

            private static bool Authorize(Account account)
            {
                const string TrueLogin = "root";
                const string TruePassword = "GeekBrains";
                return account.Login == TrueLogin && account.Password == TruePassword;
            }

            private static Account ParseAccount(string raw)
            {
                Account result = new Account();
                var list = raw.Split(new char[] { ',' }, 2, StringSplitOptions.RemoveEmptyEntries);
                if (list.Length >= 2)
                {
                    result.Login = list[0];
                    result.Password = list[1];
                }
                return result;

            }
        }
    }
}
