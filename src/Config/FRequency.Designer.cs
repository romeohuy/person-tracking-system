namespace SrDemo.Config
{
    partial class FRequency
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
            this.checkBox_region_save = new System.Windows.Forms.CheckBox();
            this.button_set_region = new System.Windows.Forms.Button();
            this.button_get_region = new System.Windows.Forms.Button();
            this.comboBox_region = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox_region_save
            // 
            this.checkBox_region_save.AutoSize = true;
            this.checkBox_region_save.Checked = true;
            this.checkBox_region_save.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_region_save.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_region_save.ForeColor = System.Drawing.Color.Navy;
            this.checkBox_region_save.Location = new System.Drawing.Point(139, 25);
            this.checkBox_region_save.Name = "checkBox_region_save";
            this.checkBox_region_save.Size = new System.Drawing.Size(50, 18);
            this.checkBox_region_save.TabIndex = 35;
            this.checkBox_region_save.Text = "保存";
            this.checkBox_region_save.UseVisualStyleBackColor = true;
            // 
            // button_set_region
            // 
            this.button_set_region.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_set_region.ForeColor = System.Drawing.Color.Navy;
            this.button_set_region.Location = new System.Drawing.Point(285, 22);
            this.button_set_region.Name = "button_set_region";
            this.button_set_region.Size = new System.Drawing.Size(60, 25);
            this.button_set_region.TabIndex = 34;
            this.button_set_region.Text = "设置";
            this.button_set_region.UseVisualStyleBackColor = true;
            this.button_set_region.Click += new System.EventHandler(this.button_set_region_Click);
            // 
            // button_get_region
            // 
            this.button_get_region.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_get_region.ForeColor = System.Drawing.Color.Navy;
            this.button_get_region.Location = new System.Drawing.Point(208, 22);
            this.button_get_region.Name = "button_get_region";
            this.button_get_region.Size = new System.Drawing.Size(60, 25);
            this.button_get_region.TabIndex = 33;
            this.button_get_region.Text = "获取";
            this.button_get_region.UseVisualStyleBackColor = true;
            this.button_get_region.Click += new System.EventHandler(this.button_get_region_Click);
            // 
            // comboBox_region
            // 
            this.comboBox_region.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_region.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_region.ForeColor = System.Drawing.Color.Navy;
            this.comboBox_region.FormattingEnabled = true;
            this.comboBox_region.Items.AddRange(new object[] {
            "China1",
            "China2",
            "Europe",
            "USA",
            "Korea",
            "Japan"});
            this.comboBox_region.Location = new System.Drawing.Point(16, 23);
            this.comboBox_region.Name = "comboBox_region";
            this.comboBox_region.Size = new System.Drawing.Size(97, 22);
            this.comboBox_region.TabIndex = 31;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_region);
            this.groupBox1.Controls.Add(this.checkBox_region_save);
            this.groupBox1.Controls.Add(this.button_get_region);
            this.groupBox1.Controls.Add(this.button_set_region);
            this.groupBox1.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 58);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "频率区域";
            // 
            // FRequency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox1);
            this.Name = "FRequency";
            this.Size = new System.Drawing.Size(370, 64);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_region_save;
        private System.Windows.Forms.Button button_set_region;
        private System.Windows.Forms.Button button_get_region;
        private System.Windows.Forms.ComboBox comboBox_region;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
