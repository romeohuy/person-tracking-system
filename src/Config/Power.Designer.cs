namespace SrDemo.Config
{
    partial class Power
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox_power = new System.Windows.Forms.GroupBox();
            this.comboBox_write_power = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.comboBox_read_power = new System.Windows.Forms.ComboBox();
            this.button_power_set = new System.Windows.Forms.Button();
            this.button_power_get = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox_power.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_power
            // 
            this.groupBox_power.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_power.Controls.Add(this.comboBox_write_power);
            this.groupBox_power.Controls.Add(this.label18);
            this.groupBox_power.Controls.Add(this.comboBox_read_power);
            this.groupBox_power.Controls.Add(this.button_power_set);
            this.groupBox_power.Controls.Add(this.button_power_get);
            this.groupBox_power.Controls.Add(this.label16);
            this.groupBox_power.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox_power.ForeColor = System.Drawing.Color.Navy;
            this.groupBox_power.Location = new System.Drawing.Point(3, 3);
            this.groupBox_power.Name = "groupBox_power";
            this.groupBox_power.Size = new System.Drawing.Size(206, 87);
            this.groupBox_power.TabIndex = 2;
            this.groupBox_power.TabStop = false;
            // 
            // comboBox_write_power
            // 
            this.comboBox_write_power.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_write_power.ForeColor = System.Drawing.Color.Navy;
            this.comboBox_write_power.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.comboBox_write_power.Location = new System.Drawing.Point(88, 51);
            this.comboBox_write_power.Name = "comboBox_write_power";
            this.comboBox_write_power.Size = new System.Drawing.Size(45, 23);
            this.comboBox_write_power.TabIndex = 18;
            this.comboBox_write_power.Text = "30";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(17, 55);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 15);
            this.label18.TabIndex = 17;
            this.label18.Text = "写标签";
            // 
            // comboBox_read_power
            // 
            this.comboBox_read_power.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_read_power.ForeColor = System.Drawing.Color.Navy;
            this.comboBox_read_power.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.comboBox_read_power.Location = new System.Drawing.Point(88, 21);
            this.comboBox_read_power.Name = "comboBox_read_power";
            this.comboBox_read_power.Size = new System.Drawing.Size(45, 23);
            this.comboBox_read_power.TabIndex = 16;
            this.comboBox_read_power.Text = "30";
            // 
            // button_power_set
            // 
            this.button_power_set.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_power_set.Location = new System.Drawing.Point(150, 51);
            this.button_power_set.Name = "button_power_set";
            this.button_power_set.Size = new System.Drawing.Size(47, 22);
            this.button_power_set.TabIndex = 8;
            this.button_power_set.Text = "设置";
            this.button_power_set.UseVisualStyleBackColor = true;
            this.button_power_set.Click += new System.EventHandler(this.button_power_set_Click);
            // 
            // button_power_get
            // 
            this.button_power_get.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_power_get.Location = new System.Drawing.Point(150, 21);
            this.button_power_get.Name = "button_power_get";
            this.button_power_get.Size = new System.Drawing.Size(47, 22);
            this.button_power_get.TabIndex = 7;
            this.button_power_get.Text = "获取";
            this.button_power_get.UseVisualStyleBackColor = true;
            this.button_power_get.Click += new System.EventHandler(this.button_power_get_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(16, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 15);
            this.label16.TabIndex = 3;
            this.label16.Text = "读标签";
            // 
            // Power
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox_power);
            this.Name = "Power";
            this.Size = new System.Drawing.Size(214, 93);
            this.groupBox_power.ResumeLayout(false);
            this.groupBox_power.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_power;
        private System.Windows.Forms.ComboBox comboBox_write_power;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox comboBox_read_power;
        private System.Windows.Forms.Button button_power_set;
        private System.Windows.Forms.Button button_power_get;
        private System.Windows.Forms.Label label16;
    }
}
