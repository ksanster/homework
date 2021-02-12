using System;
using System.Windows.Forms;

namespace Ex2
{
    public partial class MainForm : Form
    {
        private int guessed = 0;
        private int step = 0;
        private Random rnd = new Random();

        public int Operand  
        {
            get
            {
                if (string.IsNullOrEmpty(inputBox.Text))
                    return 0;
                if (!int.TryParse(inputBox.Text, out var result))
                {
                    inputBox.Text = string.Empty;
                    return 0;
                }
                return result;

            }
        }

            
        public MainForm()
        {
            InitializeComponent();
            GameStart();
        }
        private void Clear()
        {
            step = 0;
            guessed = 0;
            lblTryResult.Text = string.Empty;
            inputBox.Text = string.Empty;
            btnInput.Enabled = true;
            inputBox.Enabled = true;
        }

        private void GameStart()
        {
            Clear();
            guessed = rnd.Next(1, 100);
        }

        private void CheckGameEnd()
        {
            if (Operand < 1 || Operand > 100)
            {
                lblTryResult.Text = "Ошибка! Введите число от 1 до 100";
                inputBox.Text = string.Empty;
                return;
            }
             step++;
            if (Operand == guessed)
            {
                btnInput.Enabled = false;
                inputBox.Enabled = false;
                lblTryResult.Text = $"Вы выиграли! Потребовалось ходов: {step}";
                return;
            }
            lblTryResult.Text = (Operand > guessed) ? "Перебор!" : "Недобор!";
        }

        private void inputBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CheckGameEnd();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            CheckGameEnd();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            GameStart();
        }
    }
}
