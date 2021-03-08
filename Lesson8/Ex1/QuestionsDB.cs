using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ex1
{
    public class QuestionsDB
    {
        private List<Question> list = new List<Question>();
        private string fileName;

        public List<Question> List => list;
        public int Count => list.Count;
        public string FileName 
        {
            set => fileName = value;
        }

        public QuestionsDB(string fileName)
        {
            this.fileName = fileName;
            if (!string.IsNullOrEmpty(fileName) && File.Exists(fileName))
                Load();
        }

        // При использовании DataGridView эти методы неактуальны, он берет на себя управление содержимым списка
        public void Add(string text, bool isTrue)
        {
            list.Add(new Question(text, isTrue));
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < list.Count)
            {
                list.RemoveAt(index);
            }
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Save()
        {
            var result = false;
            // Тут мне не совсем понятно, что произойдет, если вывалится exception на serializer.Serialize()
            // Закроется ли поток корректно, потому что вышли из using {} 
            // Или нужно дописывать Finally-блок и закрывать его там? 
            try
            {
                var serializer = new XmlSerializer(typeof(List<Question>));
                using (var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    serializer.Serialize(stream, list);
                }
                result = true;
            }
            catch (Exception e)
            {
                throw;
            }

            return result;
        }

        public bool Load()
        {
            var result = false;
            try
            {
                var serializer = new XmlSerializer(typeof(List<Question>));
                using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    var raw = (List<Question>)serializer.Deserialize(stream);
                    list.Clear();
                    foreach (var question in raw)
                    {
                        list.Add(question);
                    }
                }
                result = true;
            }
            catch (Exception e)
            {
                throw;
            }
            return result;
         }

    }
}
