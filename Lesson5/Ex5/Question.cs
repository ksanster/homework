using System;
namespace Lesson5
{
    namespace Ex5
    {
        public class Question
        {
            public static Question Create(string value)
            {
                //В данном варианте в вопросе не может быть запятых, требует доработки
                char[] separators = {','};
                var items = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                return new Question(items[0], items[1].ToLower() == "да");
            }

            public string Text { get; }
            public bool IsTrue { get; }
            public Question(string text, bool isTrue)
            {
                Text = text;
                IsTrue = isTrue;
            }
        }
    }
}

