namespace SrDemo.Config
{
    partial class Tagfocus
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.RadioButtonTagfousOff = new System.Windows.Forms.RadioButton();
            this.RadioButtonTagfousOn = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(101, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "设置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(101, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "获取";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RadioButtonTagfousOff
            // 
            this.RadioButtonTagfousOff.AutoSize = true;
            this.RadioButtonTagfousOff.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RadioButtonTagfousOff.Location = new System.Drawing.Point(28, 58);
            this.RadioButtonTagfousOff.Name = "RadioButtonTagfousOff";
            this.RadioButtonTagfousOff.Size = new System.Drawing.Size(51, 18);
            this.RadioButtonTagfousOff.TabIndex = 0;
            this.RadioButtonTagfousOff.Text = "关闭";
            this.RadioButtonTagfousOff.UseVisualStyleBackColor = true;
            // 
            // RadioButtonTagfousOn
            // 
            this.RadioButtonTagfousOn.AutoSize = true;
            this.RadioButtonTagfousOn.Checked = true;
            this.RadioButtonTagfousOn.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RadioButtonTagfousOn.Location = new System.Drawing.Point(28, 25);
            this.RadioButtonTagfousOn.Name = "RadioButtonTagfousOn";
            this.RadioButtonTagfousOn.Size = new System.Drawing.Size(51, 18);
            this.RadioButtonTagfousOn.TabIndex = 0;
            this.RadioButtonTagfousOn.TabStop = true;
            this.RadioButtonTagfousOn.Text = "开启";
            this.RadioButtonTagfousOn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.RadioButtonTagfousOn);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.RadioButtonTagfousOff);
            this.groupBox1.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 91);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tagfocus";
            // 
            // Tagfocus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox1);
            this.Name = "Tagfocus";
            this.Size = new System.Drawing.Size(191, 98);
            this.Load += new System.EventHandler(this.Tagfocus_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton RadioButtonTagfousOff;
        private System.Windows.Forms.RadioButton RadioButtonTagfousOn;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
