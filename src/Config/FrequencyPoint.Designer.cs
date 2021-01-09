namespace SrDemo.Config
{
    partial class FrequencyPoint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrequencyPoint));
            this.label53 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.button_create_fp = new System.Windows.Forms.Button();
            this.textBox_fp_interval = new System.Windows.Forms.TextBox();
            this.textBox_fp_max = new System.Windows.Forms.TextBox();
            this.textBox_fp_min = new System.Windows.Forms.TextBox();
            this.button_fp_clear = new System.Windows.Forms.Button();
            this.button_fp_example = new System.Windows.Forms.Button();
            this.button_set_fp = new System.Windows.Forms.Button();
            this.button_get_fp = new System.Windows.Forms.Button();
            this.richTextBox_frequency_point = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label53.ForeColor = System.Drawing.Color.Navy;
            this.label53.Location = new System.Drawing.Point(371, 22);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(55, 14);
            this.label53.TabIndex = 45;
            this.label53.Text = "信道间隔";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label47.ForeColor = System.Drawing.Color.Navy;
            this.label47.Location = new System.Drawing.Point(194, 22);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(31, 14);
            this.label47.TabIndex = 44;
            this.label47.Text = "最大";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.ForeColor = System.Drawing.Color.Navy;
            this.label19.Location = new System.Drawing.Point(16, 22);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(31, 14);
            this.label19.TabIndex = 43;
            this.label19.Text = "最小";
            // 
            // button_create_fp
            // 
            this.button_create_fp.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_create_fp.ForeColor = System.Drawing.Color.Navy;
            this.button_create_fp.Location = new System.Drawing.Point(657, 43);
            this.button_create_fp.Name = "button_create_fp";
            this.button_create_fp.Size = new System.Drawing.Size(65, 22);
            this.button_create_fp.TabIndex = 42;
            this.button_create_fp.Text = "创建";
            this.button_create_fp.UseVisualStyleBackColor = true;
            this.button_create_fp.Click += new System.EventHandler(this.button_create_fp_Click);
            // 
            // textBox_fp_interval
            // 
            this.textBox_fp_interval.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_fp_interval.ForeColor = System.Drawing.Color.Navy;
            this.textBox_fp_interval.Location = new System.Drawing.Point(436, 18);
            this.textBox_fp_interval.MaxLength = 7;
            this.textBox_fp_interval.Name = "textBox_fp_interval";
            this.textBox_fp_interval.Size = new System.Drawing.Size(54, 23);
            this.textBox_fp_interval.TabIndex = 41;
            this.textBox_fp_interval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_fp_max
            // 
            this.textBox_fp_max.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_fp_max.ForeColor = System.Drawing.Color.Navy;
            this.textBox_fp_max.Location = new System.Drawing.Point(230, 18);
            this.textBox_fp_max.MaxLength = 7;
            this.textBox_fp_max.Name = "textBox_fp_max";
            this.textBox_fp_max.Size = new System.Drawing.Size(54, 23);
            this.textBox_fp_max.TabIndex = 40;
            this.textBox_fp_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_fp_min
            // 
            this.textBox_fp_min.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_fp_min.ForeColor = System.Drawing.Color.Navy;
            this.textBox_fp_min.Location = new System.Drawing.Point(54, 18);
            this.textBox_fp_min.MaxLength = 7;
            this.textBox_fp_min.Name = "textBox_fp_min";
            this.textBox_fp_min.Size = new System.Drawing.Size(57, 23);
            this.textBox_fp_min.TabIndex = 35;
            this.textBox_fp_min.Text = " ";
            this.textBox_fp_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_fp_clear
            // 
            this.button_fp_clear.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_fp_clear.ForeColor = System.Drawing.Color.Navy;
            this.button_fp_clear.Location = new System.Drawing.Point(657, 103);
            this.button_fp_clear.Name = "button_fp_clear";
            this.button_fp_clear.Size = new System.Drawing.Size(65, 22);
            this.button_fp_clear.TabIndex = 39;
            this.button_fp_clear.Text = "清除";
            this.button_fp_clear.UseVisualStyleBackColor = true;
            this.button_fp_clear.Click += new System.EventHandler(this.button_fp_clear_Click);
            // 
            // button_fp_example
            // 
            this.button_fp_example.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_fp_example.ForeColor = System.Drawing.Color.Navy;
            this.button_fp_example.Location = new System.Drawing.Point(657, 73);
            this.button_fp_example.Name = "button_fp_example";
            this.button_fp_example.Size = new System.Drawing.Size(65, 22);
            this.button_fp_example.TabIndex = 38;
            this.button_fp_example.Text = "案例";
            this.button_fp_example.UseVisualStyleBackColor = true;
            this.button_fp_example.Click += new System.EventHandler(this.button_fp_example_Click);
            // 
            // button_set_fp
            // 
            this.button_set_fp.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_set_fp.ForeColor = System.Drawing.Color.Navy;
            this.button_set_fp.Location = new System.Drawing.Point(657, 163);
            this.button_set_fp.Name = "button_set_fp";
            this.button_set_fp.Size = new System.Drawing.Size(65, 22);
            this.button_set_fp.TabIndex = 37;
            this.button_set_fp.Text = "设置";
            this.button_set_fp.UseVisualStyleBackColor = true;
            this.button_set_fp.Click += new System.EventHandler(this.button_set_fp_Click);
            // 
            // button_get_fp
            // 
            this.button_get_fp.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_get_fp.ForeColor = System.Drawing.Color.Navy;
            this.button_get_fp.Location = new System.Drawing.Point(657, 133);
            this.button_get_fp.Name = "button_get_fp";
            this.button_get_fp.Size = new System.Drawing.Size(65, 22);
            this.button_get_fp.TabIndex = 36;
            this.button_get_fp.Text = "获取";
            this.button_get_fp.UseVisualStyleBackColor = true;
            this.button_get_fp.Click += new System.EventHandler(this.button_get_fp_Click);
            // 
            // richTextBox_frequency_point
            // 
            this.richTextBox_frequency_point.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox_frequency_point.ForeColor = System.Drawing.Color.Navy;
            this.richTextBox_frequency_point.Location = new System.Drawing.Point(12, 43);
            this.richTextBox_frequency_point.Name = "richTextBox_frequency_point";
            this.richTextBox_frequency_point.Size = new System.Drawing.Size(609, 142);
            this.richTextBox_frequency_point.TabIndex = 34;
            this.richTextBox_frequency_point.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 201);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(609, 228);
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.richTextBox_frequency_point);
            this.groupBox1.Controls.Add(this.label53);
            this.groupBox1.Controls.Add(this.button_get_fp);
            this.groupBox1.Controls.Add(this.label47);
            this.groupBox1.Controls.Add(this.button_set_fp);
            this.groupBox1.Controls.Add(this.button_fp_example);
            this.groupBox1.Controls.Add(this.button_create_fp);
            this.groupBox1.Controls.Add(this.button_fp_clear);
            this.groupBox1.Controls.Add(this.textBox_fp_interval);
            this.groupBox1.Controls.Add(this.textBox_fp_min);
            this.groupBox1.Controls.Add(this.textBox_fp_max);
            this.groupBox1.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(732, 196);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "频率";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(496, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 14);
            this.label3.TabIndex = 48;
            this.label3.Text = "KHz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(290, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 14);
            this.label2.TabIndex = 47;
            this.label2.Text = "KHz";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(117, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 14);
            this.label1.TabIndex = 46;
            this.label1.Text = "KHz";
            // 
            // FrequencyPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FrequencyPoint";
            this.Size = new System.Drawing.Size(738, 432);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button button_create_fp;
        private System.Windows.Forms.TextBox textBox_fp_interval;
        private System.Windows.Forms.TextBox textBox_fp_max;
        private System.Windows.Forms.TextBox textBox_fp_min;
        private System.Windows.Forms.Button button_fp_clear;
        private System.Windows.Forms.Button button_fp_example;
        private System.Windows.Forms.Button button_set_fp;
        private System.Windows.Forms.Button button_get_fp;
        private System.Windows.Forms.RichTextBox richTextBox_frequency_point;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
