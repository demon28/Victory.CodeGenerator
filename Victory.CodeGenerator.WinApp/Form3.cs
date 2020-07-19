using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Victory.CodeGenerator.WinApp
{
    public partial class Form3 : Form
    {

        public string TempletePath { get; set; }

        public Form3(string path)
        {
            InitializeComponent();
            TempletePath = path;

            LoadCode();

        }

        private void LoadCode()
        {
            if (string.IsNullOrEmpty(TempletePath))
            {
                return;
            }
            TempletePath = AppDomain.CurrentDomain.BaseDirectory + "Template\\"+ TempletePath;

            this.textBox1.Text = TempletePath;

            string TempString = File.ReadAllText(TempletePath, Encoding.Default);

            this.richTextBox1.Text = TempString;

        }

        

        private void btn_add_conn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty( this.textBox1.Text))
            {
                MessageBox.Show("请配置完整路径（含文件名）");
                return;
            }

            if (!File.Exists(this.textBox1.Text))
            {
                File.Create(this.textBox1.Text);
            } 

           
            File.WriteAllText(TempletePath, this.richTextBox1.Text);

            MessageBox.Show("成功！");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Explorer.exe", "https://github.com/demon28/Victory.CodeGenerator.Web");

        }
    }
}
