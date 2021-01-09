namespace SrDemo
{
    partial class DataBaseSetting
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
            this.groupBox30 = new System.Windows.Forms.GroupBox();
            this.data_PWD_tb = new System.Windows.Forms.TextBox();
            this.data_user_tb = new System.Windows.Forms.TextBox();
            this.data_name_tb = new System.Windows.Forms.TextBox();
            this.data_server_tb = new System.Windows.Forms.TextBox();
            this.label72 = new System.Windows.Forms.Label();
            this.button22 = new System.Windows.Forms.Button();
            this.label71 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.checkBoxCreatTables = new System.Windows.Forms.CheckBox();
            this.groupBox30.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox30
            // 
            this.groupBox30.Controls.Add(this.checkBoxCreatTables);
            this.groupBox30.Controls.Add(this.data_PWD_tb);
            this.groupBox30.Controls.Add(this.data_user_tb);
            this.groupBox30.Controls.Add(this.data_name_tb);
            this.groupBox30.Controls.Add(this.data_server_tb);
            this.groupBox30.Controls.Add(this.label72);
            this.groupBox30.Controls.Add(this.button22);
            this.groupBox30.Controls.Add(this.label71);
            this.groupBox30.Controls.Add(this.label70);
            this.groupBox30.Controls.Add(this.label84);
            this.groupBox30.Location = new System.Drawing.Point(12, 12);
            this.groupBox30.Name = "groupBox30";
            this.groupBox30.Size = new System.Drawing.Size(324, 271);
            this.groupBox30.TabIndex = 9;
            this.groupBox30.TabStop = false;
            this.groupBox30.Text = "数据库信息配置";
            // 
            // data_PWD_tb
            // 
            this.data_PWD_tb.Location = new System.Drawing.Point(115, 166);
            this.data_PWD_tb.Name = "data_PWD_tb";
            this.data_PWD_tb.PasswordChar = '*';
            this.data_PWD_tb.Size = new System.Drawing.Size(203, 21);
            this.data_PWD_tb.TabIndex = 1;
            this.data_PWD_tb.Text = "xysql123";
            // 
            // data_user_tb
            // 
            this.data_user_tb.Location = new System.Drawing.Point(115, 116);
            this.data_user_tb.Name = "data_user_tb";
            this.data_user_tb.Size = new System.Drawing.Size(203, 21);
            this.data_user_tb.TabIndex = 1;
            this.data_user_tb.Text = "sa";
            // 
            // data_name_tb
            // 
            this.data_name_tb.Location = new System.Drawing.Point(115, 70);
            this.data_name_tb.Name = "data_name_tb";
            this.data_name_tb.Size = new System.Drawing.Size(203, 21);
            this.data_name_tb.TabIndex = 1;
            this.data_name_tb.Text = "test";
            // 
            // data_server_tb
            // 
            this.data_server_tb.Location = new System.Drawing.Point(115, 26);
            this.data_server_tb.Name = "data_server_tb";
            this.data_server_tb.Size = new System.Drawing.Size(203, 21);
            this.data_server_tb.TabIndex = 1;
            this.data_server_tb.Text = "(local)";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(18, 166);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(41, 12);
            this.label72.TabIndex = 0;
            this.label72.Text = "密码：";
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(184, 214);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(82, 40);
            this.button22.TabIndex = 2;
            this.button22.Text = "确定";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(18, 119);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(53, 12);
            this.label71.TabIndex = 0;
            this.label71.Text = "sa用户：";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(18, 73);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(53, 12);
            this.label70.TabIndex = 0;
            this.label70.Text = "数据库：";
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(18, 29);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(53, 12);
            this.label84.TabIndex = 0;
            this.label84.Text = "服务器：";
            // 
            // checkBoxCreatTables
            // 
            this.checkBoxCreatTables.AutoSize = true;
            this.checkBoxCreatTables.Location = new System.Drawing.Point(32, 227);
            this.checkBoxCreatTables.Name = "checkBoxCreatTables";
            this.checkBoxCreatTables.Size = new System.Drawing.Size(120, 16);
            this.checkBoxCreatTables.TabIndex = 3;
            this.checkBoxCreatTables.Text = "为数据库创建表格";
            this.checkBoxCreatTables.UseVisualStyleBackColor = true;
            // 
            // DataBaseSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 292);
            this.Controls.Add(this.groupBox30);
            this.Name = "DataBaseSetting";
            this.Text = "DataBaseSetting";
            this.groupBox30.ResumeLayout(false);
            this.groupBox30.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox30;
        private System.Windows.Forms.TextBox data_PWD_tb;
        private System.Windows.Forms.TextBox data_user_tb;
        private System.Windows.Forms.TextBox data_name_tb;
        private System.Windows.Forms.TextBox data_server_tb;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.CheckBox checkBoxCreatTables;
    }
}