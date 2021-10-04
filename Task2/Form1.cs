using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int wordLength = int.Parse(textBox1.Text);

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    string content = File.ReadAllText(filePath);

                    var matches = Regex.Matches(content, @"\b[\w]+\b");

                    List<string> result = new List<string>();



                    foreach (Match match in matches)
                    {
                        if(match.Length == wordLength)
                        {
                            result.Add(match.Value);
                        }
                    }


                    string dir = Path.GetDirectoryName(filePath);
                    string ext = Path.GetExtension(filePath);
                    string baseName = Path.GetFileNameWithoutExtension(filePath);

                    string resultPath = Path.Combine(dir, baseName + "_result" + ext);

                    File.WriteAllLines(resultPath, result.ToArray());

                    MessageBox.Show("Результат сохранён в " + resultPath);
                }
            }
        }
    }
}
