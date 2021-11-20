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

        private void saveFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.Write(richTextBox1.Text);
            }

            MessageBox.Show("Фајлот е успешно снимен!");
        }

        private void btnaa1_Click(object sender, EventArgs e)
        {
            if (fontSize >= 5)
                fontSize--;
            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, fontSize);
        }

        private void btnA2_Click(object sender, EventArgs e)
        {
            if (fontSize <= 25)
                fontSize++;
            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, fontSize);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Текст едитор креиран од Семос група C# ниво 1 септ-ное 2021");
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.SelectionFont = fontDialog1.Font;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.SelectionColor = colorDialog1.Color;
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Дали сте сигурни дека сакате да отворите нов документ?", "Важно", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                richTextBox1.Text = "";
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Files |*.txt";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //File.WriteAllText(openFileDialog1.FileName, richTextBox1.Text);
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFile(openFileDialog1.FileName);
        }

        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Yes)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName);
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegular_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Regular);
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Bold);
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Italic);
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Underline);
        }

        private void btnAddText_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                openFile2(file);
            }
        }

        private void openFile2(string fileName)
        {
            richTextBox1.Text += Environment.NewLine;
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        richTextBox1.Text += line + Environment.NewLine;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Фајлот " + fileName + " не постои!");
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, richTextBox1.Font, Brushes.Black, new PointF(100, 100));
        }
    }
}
