namespace Victory.CodeGenerator.WinApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_conn = new System.Windows.Forms.Button();
            this.btn_del_conn = new System.Windows.Forms.Button();
            this.btn_add_conn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tb_connstring = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_openpath = new System.Windows.Forms.Button();
            this.btn_selectpath = new System.Windows.Forms.Button();
            this.ck_savepath = new System.Windows.Forms.CheckBox();
            this.tb_filepath = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tb_space = new System.Windows.Forms.TextBox();
            this.tb_templete = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_yulan = new System.Windows.Forms.Button();
            this.tb_tablename = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_myfilename = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_conn);
            this.groupBox1.Controls.Add(this.btn_del_conn);
            this.groupBox1.Controls.Add(this.btn_add_conn);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.tb_connstring);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(26, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 220);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库";
            // 
            // btn_conn
            // 
            this.btn_conn.Location = new System.Drawing.Point(342, 72);
            this.btn_conn.Name = "btn_conn";
            this.btn_conn.Size = new System.Drawing.Size(134, 127);
            this.btn_conn.TabIndex = 3;
            this.btn_conn.Text = "连接/测试";
            this.btn_conn.UseVisualStyleBackColor = true;
            this.btn_conn.Click += new System.EventHandler(this.btn_conn_Click);
            // 
            // btn_del_conn
            // 
            this.btn_del_conn.Location = new System.Drawing.Point(416, 26);
            this.btn_del_conn.Name = "btn_del_conn";
            this.btn_del_conn.Size = new System.Drawing.Size(60, 37);
            this.btn_del_conn.TabIndex = 3;
            this.btn_del_conn.Text = "删除";
            this.btn_del_conn.UseVisualStyleBackColor = true;
            this.btn_del_conn.Click += new System.EventHandler(this.btn_del_conn_Click);
            // 
            // btn_add_conn
            // 
            this.btn_add_conn.Location = new System.Drawing.Point(344, 26);
            this.btn_add_conn.Name = "btn_add_conn";
            this.btn_add_conn.Size = new System.Drawing.Size(66, 37);
            this.btn_add_conn.TabIndex = 3;
            this.btn_add_conn.Text = "新增";
            this.btn_add_conn.UseVisualStyleBackColor = true;
            this.btn_add_conn.Click += new System.EventHandler(this.btn_add_conn_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(91, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(245, 25);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tb_connstring
            // 
            this.tb_connstring.Location = new System.Drawing.Point(91, 72);
            this.tb_connstring.Multiline = true;
            this.tb_connstring.Name = "tb_connstring";
            this.tb_connstring.Size = new System.Drawing.Size(245, 127);
            this.tb_connstring.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "连接字符串：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "常用数据库：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_openpath);
            this.groupBox2.Controls.Add(this.btn_selectpath);
            this.groupBox2.Controls.Add(this.ck_savepath);
            this.groupBox2.Controls.Add(this.tb_filepath);
            this.groupBox2.Location = new System.Drawing.Point(26, 238);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(488, 104);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "文件目录";
            // 
            // btn_openpath
            // 
            this.btn_openpath.Location = new System.Drawing.Point(346, 62);
            this.btn_openpath.Name = "btn_openpath";
            this.btn_openpath.Size = new System.Drawing.Size(130, 32);
            this.btn_openpath.TabIndex = 3;
            this.btn_openpath.Text = "打开";
            this.btn_openpath.UseVisualStyleBackColor = true;
            this.btn_openpath.Click += new System.EventHandler(this.btn_openpath_Click);
            // 
            // btn_selectpath
            // 
            this.btn_selectpath.Location = new System.Drawing.Point(345, 21);
            this.btn_selectpath.Name = "btn_selectpath";
            this.btn_selectpath.Size = new System.Drawing.Size(131, 31);
            this.btn_selectpath.TabIndex = 3;
            this.btn_selectpath.Text = "选择";
            this.btn_selectpath.UseVisualStyleBackColor = true;
            this.btn_selectpath.Click += new System.EventHandler(this.btn_selectpath_Click);
            // 
            // ck_savepath
            // 
            this.ck_savepath.AutoSize = true;
            this.ck_savepath.Checked = true;
            this.ck_savepath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_savepath.Location = new System.Drawing.Point(21, 65);
            this.ck_savepath.Name = "ck_savepath";
            this.ck_savepath.Size = new System.Drawing.Size(75, 21);
            this.ck_savepath.TabIndex = 2;
            this.ck_savepath.Text = "保存目录";
            this.ck_savepath.UseVisualStyleBackColor = true;
            // 
            // tb_filepath
            // 
            this.tb_filepath.Location = new System.Drawing.Point(18, 25);
            this.tb_filepath.Name = "tb_filepath";
            this.tb_filepath.Size = new System.Drawing.Size(320, 23);
            this.tb_filepath.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.treeView1);
            this.groupBox3.Location = new System.Drawing.Point(26, 361);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(488, 260);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "模板";
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(3, 19);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(482, 238);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txt_search);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.listBox2);
            this.groupBox4.Controls.Add(this.listBox1);
            this.groupBox4.Location = new System.Drawing.Point(520, 161);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(530, 460);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // txt_search
            // 
            this.txt_search.Location = new System.Drawing.Point(18, 16);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(496, 23);
            this.txt_search.TabIndex = 1;
            this.txt_search.Enter += new System.EventHandler(this.txt_search_Enter);
            this.txt_search.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_search_KeyUp);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(18, 415);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 39);
            this.button2.TabIndex = 3;
            this.button2.Text = "编辑模板";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(360, 416);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 39);
            this.button1.TabIndex = 3;
            this.button1.Text = "生成代码";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 17;
            this.listBox2.Location = new System.Drawing.Point(277, 56);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(237, 344);
            this.listBox2.TabIndex = 2;
            this.listBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox2_MouseClick);
            this.listBox2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox2_MouseDoubleClick);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(18, 55);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(238, 344);
            this.listBox1.TabIndex = 2;
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // tb_space
            // 
            this.tb_space.Location = new System.Drawing.Point(92, 46);
            this.tb_space.Name = "tb_space";
            this.tb_space.Size = new System.Drawing.Size(417, 23);
            this.tb_space.TabIndex = 1;
            this.tb_space.TextChanged += new System.EventHandler(this.tb_space_TextChanged);
            // 
            // tb_templete
            // 
            this.tb_templete.Location = new System.Drawing.Point(92, 17);
            this.tb_templete.Name = "tb_templete";
            this.tb_templete.ReadOnly = true;
            this.tb_templete.Size = new System.Drawing.Size(417, 23);
            this.tb_templete.TabIndex = 1;
            this.tb_templete.TextChanged += new System.EventHandler(this.tb_space_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "选用模板：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "命名空间：";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btn_yulan);
            this.groupBox5.Controls.Add(this.tb_tablename);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.tb_myfilename);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.tb_space);
            this.groupBox5.Controls.Add(this.tb_templete);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Location = new System.Drawing.Point(520, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(530, 143);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            // 
            // btn_yulan
            // 
            this.btn_yulan.Location = new System.Drawing.Point(436, 106);
            this.btn_yulan.Name = "btn_yulan";
            this.btn_yulan.Size = new System.Drawing.Size(73, 32);
            this.btn_yulan.TabIndex = 3;
            this.btn_yulan.Text = "预览";
            this.btn_yulan.UseVisualStyleBackColor = true;
            this.btn_yulan.Click += new System.EventHandler(this.btn_yulan_Click);
            // 
            // tb_tablename
            // 
            this.tb_tablename.Location = new System.Drawing.Point(92, 108);
            this.tb_tablename.Name = "tb_tablename";
            this.tb_tablename.Size = new System.Drawing.Size(326, 23);
            this.tb_tablename.TabIndex = 1;
            this.tb_tablename.TextChanged += new System.EventHandler(this.tb_space_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "代码预览：";
            // 
            // tb_myfilename
            // 
            this.tb_myfilename.Location = new System.Drawing.Point(92, 77);
            this.tb_myfilename.Name = "tb_myfilename";
            this.tb_myfilename.Size = new System.Drawing.Size(417, 23);
            this.tb_myfilename.TabIndex = 1;
            this.tb_myfilename.TextChanged += new System.EventHandler(this.tb_space_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "自定义文件名：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 646);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "VictoryCode 1.0";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_filepath;
        private System.Windows.Forms.TextBox tb_space;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.TextBox tb_connstring;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn_conn;
        private System.Windows.Forms.Button btn_del_conn;
        private System.Windows.Forms.Button btn_add_conn;
        private System.Windows.Forms.CheckBox ck_savepath;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btn_openpath;
        private System.Windows.Forms.Button btn_selectpath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_templete;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_myfilename;
        private System.Windows.Forms.Button btn_yulan;
        private System.Windows.Forms.TextBox tb_tablename;
        private System.Windows.Forms.Label label6;
    }
}

