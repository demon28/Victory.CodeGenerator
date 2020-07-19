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
    public partial class Form2 : Form
    {


        //定义委托
        public delegate void Refreshs();

        //定义事件
        public event Refreshs myRefresh;

        string address
        {
            get { return this.tb_ip.Text; }
            set { this.address = value; }
        }
        string instance { get { return this.tb_shili.Text; } set { this.instance = value; } }
        string account { get { return this.tb_id.Text; } set { this.account = value; } }
        string pwd { get { return this.tb_pwd.Text; } set { this.pwd = value; } }

        string conn { get { return this.tb_conn.Text; } set { this.pwd = value; } }

        string type { get { return this.cb_type.Text; } set { this.type = value; } }

        Facade.Enums.DbTypes dbType { get { return (Facade.Enums.DbTypes)Enum.Parse(typeof(Facade.Enums.DbTypes), this.cb_type.Text); } set { this.dbType = value; } }



        public Form2()
        {
            InitializeComponent();
            BindDbType();
        }

        private void BindDbType()
        {
            foreach (string s in Enum.GetNames(typeof(Facade.Enums.DbTypes)))
            {
                cb_type.Items.Add(s);
            }
            cb_type.SelectedIndex = 0;
        }


        public bool Check() {

            return string.IsNullOrEmpty(instance) || string.IsNullOrEmpty(conn) ;
        
        }


        private void btn_test_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                MessageBox.Show("实例名 和 字符串不能为空！");
                return;
            }


            try
            {

           
            var db = Facade.DbFactory.DbOperation(this.dbType, this.conn);

            if (db.GetDatabaseSchema().Tables.Count > 0)
            {
                MessageBox.Show("连接成功！");
                return;
            }
            MessageBox.Show("连接失败！");

            }
            catch (Exception)
            {
                MessageBox.Show("连接失败！");
             
            }

        }
        public void SetConnString()
        {
            Facade.Model.OperationModel model = new Facade.Model.OperationModel()
            {
                account = account,
                instance = instance,
                ip = address,
                pwd = pwd
            };

            var str = Facade.BuilderConnString.ConnString(dbType, model);

            tb_conn.Text = str;


        }
        private void cb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetConnString();
        }

        private void tb_shili_TextChanged(object sender, EventArgs e)
        {
            SetConnString();
        }

        private void tb_ip_TextChanged(object sender, EventArgs e)
        {
            SetConnString();
        }

        private void tb_pwd_TextChanged(object sender, EventArgs e)
        {
            SetConnString();
        }

        private void tb_id_TextChanged(object sender, EventArgs e)
        {
            SetConnString();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

                JsonHelper helper = new JsonHelper();

                helper.Add(new Facade.Model.ConnectionString()
                {
                     conn=conn,
                      name=instance,
                       type= type
                });


                DialogResult result = MessageBox.Show("添加成功,是否关闭窗口！", "提示", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    myRefresh();
                    this.Close();
                }



           
        }
    }
}
