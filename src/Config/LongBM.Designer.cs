namespace SrDemo.Config
{
    partial class LongBM
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.new_mac_tb = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label97 = new System.Windows.Forms.Label();
            this.LongDevIDlabel = new System.Windows.Forms.Label();
            this.button13 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.new_mac_tb);
            this.groupBox2.Controls.Add(this.label57);
            this.groupBox2.Controls.Add(this.textBox15);
            this.groupBox2.Controls.Add(this.label97);
            this.groupBox2.Controls.Add(this.LongDevIDlabel);
            this.groupBox2.Controls.Add(this.button13);
            this.groupBox2.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(1, 5);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(470, 75);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "出厂参数";
            // 
            // new_mac_tb
            // 
            this.new_mac_tb.Enabled = false;
            this.new_mac_tb.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.new_mac_tb.ForeColor = System.Drawing.Color.Navy;
            this.new_mac_tb.Location = new System.Drawing.Point(211, 42);
            this.new_mac_tb.Name = "new_mac_tb";
            this.new_mac_tb.Size = new System.Drawing.Size(155, 23);
            this.new_mac_tb.TabIndex = 91;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label57.ForeColor = System.Drawing.Color.Navy;
            this.label57.Location = new System.Drawing.Point(170, 45);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(35, 14);
            this.label57.TabIndex = 90;
            this.label57.Text = "MAC";
            // 
            // textBox15
            // 
            this.textBox15.Enabled = false;
            this.textBox15.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox15.ForeColor = System.Drawing.Color.Navy;
            this.textBox15.Location = new System.Drawing.Point(99, 42);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(65, 23);
            this.textBox15.TabIndex = 89;
            this.textBox15.Text = "5860";
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label97.ForeColor = System.Drawing.Color.Navy;
            this.label97.Location = new System.Drawing.Point(6, 45);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(79, 14);
            this.label97.TabIndex = 88;
            this.label97.Text = "读写器型号：";
            // 
            // LongDevIDlabel
            // 
            this.LongDevIDlabel.AutoSize = true;
            this.LongDevIDlabel.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LongDevIDlabel.ForeColor = System.Drawing.Color.Navy;
            this.LongDevIDlabel.Location = new System.Drawing.Point(6, 22);
            this.LongDevIDlabel.Name = "LongDevIDlabel";
            this.LongDevIDlabel.Size = new System.Drawing.Size(59, 14);
            this.LongDevIDlabel.TabIndex = 87;
            this.LongDevIDlabel.Text = "长编码 ：";
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button13.ForeColor = System.Drawing.Color.Navy;
            this.button13.Location = new System.Drawing.Point(385, 25);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(76, 34);
            this.button13.TabIndex = 66;
            this.button13.Text = "获取";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // LongBM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "LongBM";
            this.Size = new System.Drawing.Size(480, 91);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LongDevIDlabel;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.TextBox new_mac_tb;
    }
}
