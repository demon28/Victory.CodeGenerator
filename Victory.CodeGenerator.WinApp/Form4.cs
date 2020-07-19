using Victory.CodeGenerator.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Victory.CodeGenerator.WinApp
{
    public partial class Form4 : Form
    {


        public string TableName { get; set; }
        public Form4(string tablename, string space, string dbconn, Facade.Enums.DbTypes type, string template, string savepath, string myfilename)
        {
            InitializeComponent();
            TableName = tablename;

            List<string> list = new List<string>();
            list.Add(tablename);
           

            Facade.CodeBuilder builder = new CodeBuilder(list, space, dbconn, type, template, savepath, myfilename);
            richTextBox1.SelectionFont = new Font("楷体", 18, FontStyle.Bold);
            this.richTextBox1.Text = builder.PerView();

        }

        
    }
}
