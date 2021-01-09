namespace SrDemo.Config
{
    partial class FastID
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.fastID_off_rb = new System.Windows.Forms.RadioButton();
            this.button6 = new System.Windows.Forms.Button();
            this.fastID_on_rb = new System.Windows.Forms.RadioButton();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Controls.Add(this.fastID_off_rb);
            this.groupBox4.Controls.Add(this.button6);
            this.groupBox4.Controls.Add(this.fastID_on_rb);
            this.groupBox4.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.ForeColor = System.Drawing.Color.Navy;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(168, 98);
            this.groupBox4.TabIndex = 57;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "FastID";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button5.Location = new System.Drawing.Point(98, 61);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(54, 23);
            this.button5.TabIndex = 1;
            this.button5.Text = "设置";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // fastID_off_rb
            // 
            this.fastID_off_rb.AutoSize = true;
            this.fastID_off_rb.Checked = true;
            this.fastID_off_rb.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fastID_off_rb.Location = new System.Drawing.Point(19, 63);
            this.fastID_off_rb.Name = "fastID_off_rb";
            this.fastID_off_rb.Size = new System.Drawing.Size(51, 18);
            this.fastID_off_rb.TabIndex = 0;
            this.fastID_off_rb.TabStop = true;
            this.fastID_off_rb.Text = "关闭";
            this.fastID_off_rb.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button6.Location = new System.Drawing.Point(98, 22);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(54, 23);
            this.button6.TabIndex = 1;
            this.button6.Text = "获取";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // fastID_on_rb
            // 
            this.fastID_on_rb.AutoSize = true;
            this.fastID_on_rb.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fastID_on_rb.Location = new System.Drawing.Point(19, 24);
            this.fastID_on_rb.Name = "fastID_on_rb";
            this.fastID_on_rb.Size = new System.Drawing.Size(51, 18);
            this.fastID_on_rb.TabIndex = 0;
            this.fastID_on_rb.Text = "开启";
            this.fastID_on_rb.UseVisualStyleBackColor = true;
            // 
            // FastID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox4);
            this.Name = "FastID";
            this.Size = new System.Drawing.Size(174, 104);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.RadioButton fastID_off_rb;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.RadioButton fastID_on_rb;
    }
}
