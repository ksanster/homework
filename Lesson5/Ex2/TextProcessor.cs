using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Lesson5
{
    namespace Ex2
    {
        //Раз уж в задании говорится про статический класс - наверное лучше сделать сразу методами расширения
        public static class TextProcessor
        {
            public static string[] WordsShorterThan(this string text, int length)
            {
                var result = new List<string>();
                var words = text.SplitToWords();
                foreach (var word in words)
                {
                    if (word.Length > length)
                        continue;

                    result.Add(word);
                }
                return result.ToArray();
            }
            public static string[] WordsEndsWithLetter(this string text, char letter)
            {
                var result = new List<string>();
                var words = text.SplitToWords();
                foreach (var word in words)
                {
                    if (Regex.IsMatch(word, $"{letter}$"))
                        result.Add(word);
                }
                return result.ToArray();
            }
            public static string WordWithMaxLength(this string text)
            {
                var maxLength = 0;
                var result = string.Empty;
                var words = text.SplitToWords();
                foreach (var word in words)
                {
                    if (word.Length > maxLength)
                    {
                        result = word;
                        maxLength = word.Length;
                    }
                }
                return result;
            }

            public static string PhraseFromWordWithMaxLength(this string text)
            {
                var words = text.SplitToWords();
                int maxLength = 0;
                foreach (var word in words)
                {
                    if (word.Length > maxLength)
                        maxLength = word.Length;
                }

                var builder = new StringBuilder();
                foreach (var word in words)
                {
                    if (word.Length < maxLength)
                        continue;

                    if (builder.Length != 0)
                        builder.Append(" ");

                    builder.Append(word);
                }
                return builder.ToString();
            }

            public static string[] SplitToWords(this string text)
            {
                char[] separators = new char[] { ' ', '.', ',', '!', '?', '»', '«', '"', '\'', '\r', '\n', '\t', ')'};
                return text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
