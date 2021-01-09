namespace SrDemo.Config
{
    partial class Carrier
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.radioButtonCattierOff = new System.Windows.Forms.RadioButton();
            this.radioButtonCattierOn = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.radioButtonCattierOff);
            this.groupBox1.Controls.Add(this.radioButtonCattierOn);
            this.groupBox1.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "载波测试";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(93, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 47);
            this.button2.TabIndex = 1;
            this.button2.Text = "设置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // radioButtonCattierOff
            // 
            this.radioButtonCattierOff.AutoSize = true;
            this.radioButtonCattierOff.Checked = true;
            this.radioButtonCattierOff.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButtonCattierOff.Location = new System.Drawing.Point(21, 54);
            this.radioButtonCattierOff.Name = "radioButtonCattierOff";
            this.radioButtonCattierOff.Size = new System.Drawing.Size(51, 18);
            this.radioButtonCattierOff.TabIndex = 0;
            this.radioButtonCattierOff.TabStop = true;
            this.radioButtonCattierOff.Text = "关闭";
            this.radioButtonCattierOff.UseVisualStyleBackColor = true;
            // 
            // radioButtonCattierOn
            // 
            this.radioButtonCattierOn.AutoSize = true;
            this.radioButtonCattierOn.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButtonCattierOn.Location = new System.Drawing.Point(21, 25);
            this.radioButtonCattierOn.Name = "radioButtonCattierOn";
            this.radioButtonCattierOn.Size = new System.Drawing.Size(51, 18);
            this.radioButtonCattierOn.TabIndex = 0;
            this.radioButtonCattierOn.Text = "开启";
            this.radioButtonCattierOn.UseVisualStyleBackColor = true;
            // 
            // Carrier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox1);
            this.Name = "Carrier";
            this.Size = new System.Drawing.Size(198, 93);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButtonCattierOff;
        private System.Windows.Forms.RadioButton radioButtonCattierOn;
    }
}
