using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop
{
    public partial class Form1 : Form
    {
        private string path = "NoFile";
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "HTML Document (*.html)|*.html";
            if (openFile.ShowDialog() == DialogResult.Cancel) return;
            this.path = openFile.FileName;
            webBrowser1.Navigate(path);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double X) && double.TryParse(textBox2.Text, out double Y))
            {
                if (path != "NoFile")
                {
                    string[] fileNameSplit = this.path.Split('\\');
                    string fileName = fileNameSplit[fileNameSplit.Length - 1];
                    if (fileName == "firstPage.html")
                    {
                        // Обработка первого рисунка
                        if (X * X + Y * Y <= 4) 
                        {
                            if (X > 0 && Y > 0 || X < 0 && Y < 0)
                            {
                                if (Math.Abs(X) + Math.Abs(Y) > 2)
                                {
                                    MessageBox.Show("Принадлежит");
                                    toolStripStatusLabel1.Text = "Принадлежит";
                                }
                                else if (Math.Abs(X) + Math.Abs(Y) == 2)
                                {
                                    MessageBox.Show("На границе");
                                    toolStripStatusLabel1.Text = "На границе";
                                }
                                else
                                {
                                    MessageBox.Show("Не принадлежит");
                                    toolStripStatusLabel1.Text = "Не принадлежит";
                                }
                            }
                            else if (X < 0 && Y > 0 || X > 0 && Y < 0)
                            {
                                if (Math.Abs(X) + Math.Abs(Y) < 2)
                                {
                                    MessageBox.Show("Принадлежит");
                                    toolStripStatusLabel1.Text = "Принадлежит";
                                }
                                else if (Math.Abs(X) + Math.Abs(Y) == 2)
                                {
                                    MessageBox.Show("На границе");
                                    toolStripStatusLabel1.Text = "На границе";
                                }
                                else
                                {
                                    MessageBox.Show("Не принадлежит");
                                    toolStripStatusLabel1.Text = "Не принадлежит";
                                }
                            }
                            else
                            {
                                MessageBox.Show("На границе");
                                toolStripStatusLabel1.Text = "На границе";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Не принадлежит");
                            toolStripStatusLabel1.Text = "Не принадлежит";
                        }
                    }
                    else if (fileName == "secondPage.html")
                    {
                        // Обработка второго рисунка
                        if (Y < 2 - X * X && Y > X && X < 0) {
                            MessageBox.Show("Принадлежит");
                            toolStripStatusLabel1.Text = "Принадлежит";
                        }
                        else if ((Y == 2 - X * X) && X == 0)
                        {
                            MessageBox.Show("На границе");
                            toolStripStatusLabel1.Text = "На границе";
                        }
                        else if ((Y == 2 - X * X) && Y == X || X == 0 && Y == 0)
                        {
                            MessageBox.Show("На границе");
                            toolStripStatusLabel1.Text = "На границе";
                        }
                        else
                        {
                            if (Y <= 2 - X * X && Y > 0 && X <= Math.Sqrt(2))
                            {
                                MessageBox.Show("Принадлежит");
                                toolStripStatusLabel1.Text = "Принадлежит";
                            }

                            else if (Y == X && Math.Abs(Y) == 2 - X * X)
                            {
                                MessageBox.Show("На границе");
                                toolStripStatusLabel1.Text = "На границе";
                            }
                            else 
                            {
                                MessageBox.Show("Не принадлежит");
                                toolStripStatusLabel1.Text = "Не принадлежит";
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Загружен неопознанный html документ!");
                        toolStripStatusLabel1.Text = "Загружен неопознанный html документ!";
                    }
                }
                else
                {
                    MessageBox.Show("Сначала нужно загрузить html документ!");
                    toolStripStatusLabel1.Text = "Сначала нужно загрузить html документ!";
                }
            }
            else
            {
                MessageBox.Show("Входные данные должны быть действительными числами!");
                toolStripStatusLabel1.Text = "Входные данные должны быть действительными числами!";
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработчик: Затевков И.А. Пксп-120\nНомер варианта: 3");
        }
    }
}
