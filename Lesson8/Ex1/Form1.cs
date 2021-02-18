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
    public partial class MainForm : Form
    {
        private QuestionsDB dataBase;
        public MainForm()
        {
            InitializeComponent();
            dataBase = new QuestionsDB(string.Empty);
            BindData();
        }

        private void Create()
        {
            var dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView.Rows.Clear();
                dataBase.FileName = dialog.FileName;
            }
        }

        private void Load()
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView.DataSource = null;
                dataBase.FileName = dialog.FileName;
                if (!dataBase.Load())
                {
                    MessageBox.Show("Не могу открыть файл");
                    return;
                }
                BindData();
            }
        }

        private void SaveAs()
        {
            var dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                dataBase.FileName = dialog.FileName;
                if (!dataBase.Save())
                    MessageBox.Show("Не могу сохранить файл");
            }
        }

        private void BindData()
        {
            var bindingList = new BindingList<Question>(dataBase.List);
            dataGridView.DataSource = new BindingSource(bindingList, null);
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new AboutForm();
            frm.Show();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var index = dataGridView.CurrentCell.RowIndex;
            dataGridView.Rows.RemoveAt(index);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear all rows?", "Attention!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                dataGridView.Rows.Clear();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataBase.Save();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Create();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Load();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new GameForm();
            form.Show();
            form.Initialize(dataBase.List);
        }
    }
}
