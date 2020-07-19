namespace Victory.CodeGenerator.WinApp
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_test = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.tb_conn = new System.Windows.Forms.TextBox();
            this.tb_pwd = new System.Windows.Forms.TextBox();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.tb_ip = new System.Windows.Forms.TextBox();
            this.tb_shili = new System.Windows.Forms.TextBox();
            this.cb_type = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "类 型：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "地 址：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "实 例：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "账 号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "密 码：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "字符串：";
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(49, 288);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(134, 42);
            this.btn_test.TabIndex = 1;
            this.btn_test.Text = "测试连接";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(327, 288);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(134, 42);
            this.btn_save.TabIndex = 1;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // tb_conn
            // 
            this.tb_conn.Location = new System.Drawing.Point(67, 171);
            this.tb_conn.Multiline = true;
            this.tb_conn.Name = "tb_conn";
            this.tb_conn.Size = new System.Drawing.Size(394, 97);
            this.tb_conn.TabIndex = 2;
            // 
            // tb_pwd
            // 
            this.tb_pwd.Location = new System.Drawing.Point(67, 142);
            this.tb_pwd.Name = "tb_pwd";
            this.tb_pwd.Size = new System.Drawing.Size(394, 23);
            this.tb_pwd.TabIndex = 3;
            this.tb_pwd.TextChanged += new System.EventHandler(this.tb_pwd_TextChanged);
            // 
            // tb_id
            // 
            this.tb_id.Location = new System.Drawing.Point(67, 113);
            this.tb_id.Name = "tb_id";
            this.tb_id.Size = new System.Drawing.Size(394, 23);
            this.tb_id.TabIndex = 3;
            this.tb_id.TextChanged += new System.EventHandler(this.tb_id_TextChanged);
            // 
            // tb_ip
            // 
            this.tb_ip.Location = new System.Drawing.Point(67, 84);
            this.tb_ip.Name = "tb_ip";
            this.tb_ip.Size = new System.Drawing.Size(394, 23);
            this.tb_ip.TabIndex = 3;
            this.tb_ip.TextChanged += new System.EventHandler(this.tb_ip_TextChanged);
            // 
            // tb_shili
            // 
            this.tb_shili.Location = new System.Drawing.Point(67, 55);
            this.tb_shili.Name = "tb_shili";
            this.tb_shili.Size = new System.Drawing.Size(394, 23);
            this.tb_shili.TabIndex = 3;
            this.tb_shili.TextChanged += new System.EventHandler(this.tb_shili_TextChanged);
            // 
            // cb_type
            // 
            this.cb_type.FormattingEnabled = true;
            this.cb_type.Location = new System.Drawing.Point(67, 22);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(394, 25);
            this.cb_type.TabIndex = 4;
            this.cb_type.SelectedIndexChanged += new System.EventHandler(this.cb_type_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 368);
            this.Controls.Add(this.cb_type);
            this.Controls.Add(this.tb_shili);
            this.Controls.Add(this.tb_ip);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.tb_pwd);
            this.Controls.Add(this.tb_conn);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox tb_conn;
        private System.Windows.Forms.TextBox tb_pwd;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.TextBox tb_ip;
        private System.Windows.Forms.TextBox tb_shili;
        private System.Windows.Forms.ComboBox cb_type;
    }
}