using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Text_Editor
{
    public partial class Form1 : Form
    {
        string openFileName = "";
        int fontSize = 12;
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Дали сте сигурни дека сакате да отворите нов документ?", "Важно", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                textBox1.Text = "";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                openFileName = openFileDialog.FileName;
                openFile(openFileName);
            }
        }

        private void openFile(string fileName)
        {
            textBox1.Text = "";
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        textBox1.Text += line + Environment.NewLine;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Фајлот " + fileName + " не постои!");
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile(openFileName);
        }

        private void saveFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.Write(textBox1.Text);
            }

            MessageBox.Show("Фајлот е успешно снимен!");
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string file = saveFileDialog.FileName;
                saveFile(file);
            }
        }

        private void btnaa1_Click(object sender, EventArgs e)
        {
            if (fontSize >= 5)
                fontSize--;
            textBox1.Font = new Font(textBox1.Font.FontFamily, fontSize);
        }

        private void btnA2_Click(object sender, EventArgs e)
        {
            if (fontSize <= 25)
                fontSize++;
            textBox1.Font = new Font(textBox1.Font.FontFamily, fontSize);
        }
    }
}
