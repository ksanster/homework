using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex1
{
    /// <summary>
    /// Не стал повторять интерфес загрузки файла с вопросами, сделал прямую передачу списка 
    /// </summary>
    public partial class GameForm : Form
    {
        private const int MaxQuestions = 5;
        private Queue<Question> questions = new Queue<Question>();
        private int score;
        private int numQuestions;
        private Question current;

        public GameForm()
        {
            InitializeComponent();
        }

        public void Initialize(List<Question> list)
        {
            if (list == null || list.Count == 0)
                throw new ArgumentException("Пустой список вопросов!");

            var rnd = new Random();
            var tmp = list.ToList<Question>();
            numQuestions = Math.Min(tmp.Count, MaxQuestions);
            score = 0;
            questions.Clear();
            for (var i = 0; i < numQuestions; i++)
            {
                var index = rnd.Next(0, tmp.Count);
                questions.Enqueue(tmp[index]);
                tmp.RemoveAt(index);
            }

            ShowNext();
        }

        private void ShowNext()
        {
            btnYes.Enabled = questions.Count > 0;
            btnNo.Enabled = questions.Count > 0;
            if (questions.Count == 0)
            {
                ShowResult();
                return;
            }
            current = questions.Dequeue();
            lblQuestion.Text = current.Text;
        }

        private void ShowResult()
        {
            lblQuestion.Text = $"Игра закончена! Правильных ответов: {score} из {numQuestions}";
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (current.IsTrue)
                score++;

            ShowNext();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            if (!current.IsTrue)
                score++;

            ShowNext();

        }
    }
}
