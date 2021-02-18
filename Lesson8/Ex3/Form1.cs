using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Ex3
{
    public partial class MainForm : Form
    {
        private List<Student> students = new List<Student>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(dialog.FileName);
                students.Clear();
                listView.Items.Clear();
                foreach (var line in lines)
                {
                    var student = Student.Create(line);
                    students.Add(student);
                    var item = new ListViewItem();
                    item.Text = student.firstName + " " + student.lastName;
                    listView.Items.Add(item);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var serializer = new XmlSerializer(typeof(List<Student>));
                using (var stream = new FileStream(dialog.FileName, FileMode.Create, FileAccess.Write))
                {
                    serializer.Serialize(stream, students);
                }
            }
        }
    }
}
