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

namespace notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Input a Text.");
            }
            else
            {
                saveTXT.FileName = "Any File";
                saveTXT.DefaultExt = ".txt";
                saveTXT.Filter = "Text File (*.txt)|*.txt|Any File (*.*)|*.*";

                DialogResult result = saveTXT.ShowDialog();

                if (result == DialogResult.OK)
                {
                    FileStream fs = new FileStream(saveTXT.FileName, FileMode.Create);

                    StreamWriter writer = new StreamWriter(fs);
                    writer.Write(textBox1.Text);
                    writer.Close();
                }
                else
                {
                    MessageBox.Show("Operation was Canceled");
                }
            }
        }

      
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {

                DialogResult result = MessageBox.Show("There is text inside the text area. Continue Load?", "Notepad", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                   
                }
                else
                {
                    openFile.DefaultExt = ".txt";
                    openFile.Filter = "Any File (*.*)|*.*";
                    DialogResult resultb = openFile.ShowDialog();
                    if (resultb == DialogResult.OK)
                    {
                        StreamReader sr = new StreamReader(openFile.FileName);
                        textBox1.Text = sr.ReadToEnd();
                        sr.Close();
                    }
                }
            }
            else
            {
                openFile.DefaultExt = ".txt";
                openFile.Filter = "Text File (*.txt)|*.txt|Any File (*.*)|*.*";
                DialogResult resultb = openFile.ShowDialog();
                if (resultb == DialogResult.OK)
                {
                    StreamReader sr = new StreamReader(openFile.FileName);
                    textBox1.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
            
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = textBox1.Font;
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog1.Font;
            }
        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.ClearUndo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.SelectedText);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + Clipboard.GetText();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void inputTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + DateTime.Now.ToString();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox1.Text)) {

                if (MessageBox.Show("There is text inside the text area, Cancel Operation?", "Notepad", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    textBox1.Text = "";
                }
                else
                {

                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Show();
        }

        private void aaa1_Load(object sender, EventArgs e)
        {

        }
    }
}
