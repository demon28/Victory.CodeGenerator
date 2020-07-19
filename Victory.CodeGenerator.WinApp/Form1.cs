using Victory.CodeGenerator.Facade;
using Victory.CodeGenerator.Facade.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Victory.CodeGenerator.WinApp
{
    public partial class Form1 : Form
    {


        string Filepath = string.Empty;
        string temppath = AppDomain.CurrentDomain.BaseDirectory + "Template\\";
        static SqlSugar.DbType dbType;
        JsonModel json;

        public Form1()
        {
            InitializeComponent();
            LoadJsonFile();
            PaintTreeView(this.treeView1, temppath);
          
          
        }


        public Form1(string path)
        {
            Filepath = path;
            InitializeComponent();

            this.tb_filepath.Text = Filepath;
            LoadJsonFile();
            PaintTreeView(this.treeView1, temppath);
  

        }



        private void PaintTreeView(TreeView treeView1, string fullPath)
        {
            try
            {
                treeView1.Nodes.Clear(); //清空TreeView

                DirectoryInfo dirs = new DirectoryInfo(fullPath); //获得程序所在路径的目录对象
                DirectoryInfo[] dir = dirs.GetDirectories();//获得目录下文件夹对象
                FileInfo[] file = dirs.GetFiles();//获得目录下文件对象
                int dircount = dir.Count();//获得文件夹对象数量
                int filecount = file.Count();//获得文件对象数量

                //循环文件夹
                for (int i = 0; i < dircount; i++)
                {
                    treeView1.Nodes.Add(dir[i].Name);
                    string pathNode = fullPath + "\\" + dir[i].Name;
                    GetMultiNode(treeView1.Nodes[i], pathNode);
                }

                //循环文件
                for (int j = 0; j < filecount; j++)
                {
                    treeView1.Nodes.Add(file[j].Name);
                }

                treeView1.ExpandAll();
               


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n出错的位置为：Form1.PaintTreeView()");
            }
        }


        private bool GetMultiNode(TreeNode treeNode, string path)
        {
            if (Directory.Exists(path) == false)
            { return false; }

            DirectoryInfo dirs = new DirectoryInfo(path); //获得程序所在路径的目录对象
            DirectoryInfo[] dir = dirs.GetDirectories();//获得目录下文件夹对象
            FileInfo[] file = dirs.GetFiles();//获得目录下文件对象
            int dircount = dir.Count();//获得文件夹对象数量
            int filecount = file.Count();//获得文件对象数量
            int sumcount = dircount + filecount;

            if (sumcount == 0)
            { return false; }

            //循环文件夹
            for (int j = 0; j < dircount; j++)
            {
                treeNode.Nodes.Add(dir[j].Name);
                string pathNodeB = path + "\\" + dir[j].Name;
                GetMultiNode(treeNode.Nodes[j], pathNodeB);
            }

            //循环文件
            for (int j = 0; j < filecount; j++)
            {
                //展示所有文件
                treeNode.Nodes.Add(file[j].Name);

            }
            return true;
        }



      

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tb_space_TextChanged(object sender, EventArgs e)
        {
            JsonHelper helper = new JsonHelper();

            helper.SetSpace(this.tb_space.Text);


        }

        private void btn_add_conn_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();

            f2.myRefresh += new Form2.Refreshs(LoadJsonFile);

            f2.ShowDialog();
        }

        private void LoadJsonFile()
        {
            this.comboBox1.Items.Clear();
            this.comboBox1.Text = string.Empty;
            this.tb_connstring.Text = string.Empty;

            JsonHelper helper = new JsonHelper();
            json = helper.Read();


            this.tb_filepath.Text = json.FilePath;
            this.tb_space.Text = json.NameSpace;

            if (json.ConnectionString.Count() <= 0)
            {
                return;
            }

          

            foreach (var item in json.ConnectionString)
            {
                comboBox1.Items.Add(item.name);
            }

            //设置默认值
            comboBox1.SelectedItem = comboBox1.Items[comboBox1.Items.Count - 1];

            this.tb_connstring.Text = json.ConnectionString[comboBox1.SelectedIndex].conn;
        }

        private void btn_del_conn_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tb_connstring.Text = json.ConnectionString[comboBox1.SelectedIndex].conn;
        }


        public List<string> DbTables;

        private void btn_conn_Click(object sender, EventArgs e)
        {

            var conn= json.ConnectionString[comboBox1.SelectedIndex].conn;
            var type = (Facade.Enums.DbTypes)Enum.Parse(typeof(Facade.Enums.DbTypes), json.ConnectionString[comboBox1.SelectedIndex].type);

            var db= Facade.DbFactory.DbOperation(type, conn);

            DatabaseSchema tabs = db.GetDatabaseSchema();

            listBox1.DataSource = tabs.Tables;
            listBox1.DisplayMember = "Name";

            DbTables = new List<string>();
            for (int i = 0; i < tabs.Tables.Count; i++)
            {
                DbTables.Add(tabs.Tables[i].Name);
            }


            this.txt_search.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.txt_search.AutoCompleteSource = AutoCompleteSource.CustomSource;
            string[] names = DbTables.ToArray();
            this.txt_search.AutoCompleteCustomSource.AddRange(names);

        }

        private void btn_selectpath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.tb_filepath.Text = path.SelectedPath;


            JsonHelper helper = new JsonHelper();
            helper.SetPath(this.tb_filepath.Text.Trim());

        }

        private void btn_openpath_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("Explorer.exe", tb_filepath.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("拒绝访问！");
            }

        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var dr = (Facade.Interfaces.ITableSchema)this.listBox1.SelectedItem;

            listBox2.Items.Add(dr.Name);
        }

        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listBox2.Items.Remove(listBox2.SelectedItem);
        }

        private void txt_search_Enter(object sender, EventArgs e)
        {

        }

        private void txt_search_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (listBox2.Items.Contains(txt_search.Text))
                {
                    return;
                }
                listBox2.Items.Add(txt_search.Text.ToUpper());
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
          this.tb_templete.Text=   e.Node.Parent.Text + "\\" + e.Node.Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            Form3 form = new Form3(this.tb_templete.Text);
            form.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (listBox2.Items.Count <= 0)
            {
                MessageBox.Show("请选择您要生成的数据表");
                return;
            }
            if (string.IsNullOrEmpty(this.tb_templete.Text))
            {
                MessageBox.Show("请选择模板！");
                return;
            }
            if (string.IsNullOrEmpty( tb_filepath.Text))
            {
                MessageBox.Show("请选择文件存放路径！");
                return;
            }


            List<string> list = new List<string>();
            foreach (var item in listBox2.Items)
            {
                list.Add(item.ToString());
            }


            var dbitem=  json.ConnectionString[this.comboBox1.SelectedIndex];
            var type = (Facade.Enums.DbTypes)Enum.Parse(typeof(Enums.DbTypes), dbitem.type);
            var dbconn = dbitem.conn;
            var space = this.tb_space.Text;
            var template = temppath + this.tb_templete.Text;
            var savepath = this.tb_filepath.Text;
            var myfilename = this.tb_myfilename.Text;
            Facade.CodeBuilder builder = new CodeBuilder(list,space,dbconn, type, template,savepath, myfilename);


            if (builder.Build())
            {
                MessageBox.Show("代码已全部生成！");   
                return;
            }
            MessageBox.Show("生成失败！");

        }

        private void listBox2_MouseClick(object sender, MouseEventArgs e)
        {
            this.tb_tablename.Text = this.listBox2.SelectedItem.ToString();
        }

        private void btn_yulan_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(this.tb_tablename.Text))
            {
                MessageBox.Show("在listbox2选择表名！");
                return;
            }

            if (string.IsNullOrEmpty(this.tb_templete.Text))
            {
                MessageBox.Show("请选择模板！");
                return;
            }
            var dbitem = json.ConnectionString[this.comboBox1.SelectedIndex];
            var type = (Facade.Enums.DbTypes)Enum.Parse(typeof(Enums.DbTypes), dbitem.type);
            var dbconn = dbitem.conn;
            var space = this.tb_space.Text;
            var template = temppath + this.tb_templete.Text;
            var savepath = this.tb_filepath.Text;
            var myfilename = this.tb_myfilename.Text;

            Form4 form4 = new Form4(this.tb_tablename.Text, space, dbconn, type, template, savepath, myfilename);

            form4.Show();
        }
    }
}
