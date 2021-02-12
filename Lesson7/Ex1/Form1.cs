using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ex1
{
    public partial class MainForm : Form
    {
        private int operand = 0;
        private int guessed = 0;
        private int step = 0;
        private Random rnd = new Random();
        private Stack<int> stack = new Stack<int>();

        public int Operand
        {
            get => operand;
            set
            {
                operand = value;
                //Правильнее использовать data binding, но пока не до конца с ним разобрался
                lblValue.Text = operand.ToString();
            }
        }

        public MainForm()
        {
            InitializeComponent();
            Operand = 0;
        }

        private void GameStart()
        {
            guessed = rnd.Next(1, 100);
            step = 0;
            Operand = 0;
            MessageBox.Show($"Получите число {guessed}");
        }

        private void Clear()
        {
            stack.Clear();
            Operand = 0;
            guessed = 0;
            step = 0;
        }

        private void CheckGameEnd()
        {
            if (guessed == 0)
                return;

            step++;
            if (Operand == guessed)
            {
                MessageBox.Show($"Вы выиграли! Потребовалось ходов: {step}");
                Clear();
                return;
            }
            if (Operand > guessed)
            {
                MessageBox.Show($"Вы проиграли! Потребовалось ходов: {step}");
                Clear();
                return;
            }
        }

        private void menuPlay_Click(object sender, EventArgs e)
        {
            GameStart();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            stack.Push(Operand);
            Operand++;
            CheckGameEnd();
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            stack.Push(Operand);
            Operand *= 2;
            CheckGameEnd();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (stack.Count == 0)
                return;

            if (step > 0)
                step--;

            Operand = stack.Pop();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
