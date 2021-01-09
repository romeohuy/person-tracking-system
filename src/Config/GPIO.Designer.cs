namespace SrDemo.Config
{
    partial class GPIO
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
            this.groupBox_gpio = new System.Windows.Forms.GroupBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.gpio4_cb = new System.Windows.Forms.CheckBox();
            this.radioButton_gpio4_high = new System.Windows.Forms.RadioButton();
            this.radioButton_gpio4_low = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.gpio3_cb = new System.Windows.Forms.CheckBox();
            this.radioButton_gpio3_high = new System.Windows.Forms.RadioButton();
            this.radioButton_gpio3_low = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.gpio2_cb = new System.Windows.Forms.CheckBox();
            this.radioButton_gpio2_high = new System.Windows.Forms.RadioButton();
            this.radioButton_gpio2_low = new System.Windows.Forms.RadioButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.gpio1_cb = new System.Windows.Forms.CheckBox();
            this.radioButton_gpio1_high = new System.Windows.Forms.RadioButton();
            this.radioButton_gpio1_low = new System.Windows.Forms.RadioButton();
            this.button_gpio_set = new System.Windows.Forms.Button();
            this.button_gpio_get = new System.Windows.Forms.Button();
            this.groupBox_gpio.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_gpio
            // 
            this.groupBox_gpio.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_gpio.Controls.Add(this.panel7);
            this.groupBox_gpio.Controls.Add(this.panel5);
            this.groupBox_gpio.Controls.Add(this.panel4);
            this.groupBox_gpio.Controls.Add(this.panel6);
            this.groupBox_gpio.Controls.Add(this.button_gpio_set);
            this.groupBox_gpio.Controls.Add(this.button_gpio_get);
            this.groupBox_gpio.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox_gpio.ForeColor = System.Drawing.Color.Navy;
            this.groupBox_gpio.Location = new System.Drawing.Point(3, 3);
            this.groupBox_gpio.Name = "groupBox_gpio";
            this.groupBox_gpio.Size = new System.Drawing.Size(515, 97);
            this.groupBox_gpio.TabIndex = 5;
            this.groupBox_gpio.TabStop = false;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.gpio4_cb);
            this.panel7.Controls.Add(this.radioButton_gpio4_high);
            this.panel7.Controls.Add(this.radioButton_gpio4_low);
            this.panel7.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel7.Location = new System.Drawing.Point(224, 61);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(206, 26);
            this.panel7.TabIndex = 52;
            // 
            // gpio4_cb
            // 
            this.gpio4_cb.AutoSize = true;
            this.gpio4_cb.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpio4_cb.Location = new System.Drawing.Point(5, 4);
            this.gpio4_cb.Name = "gpio4_cb";
            this.gpio4_cb.Size = new System.Drawing.Size(88, 18);
            this.gpio4_cb.TabIndex = 45;
            this.gpio4_cb.Text = "GPIO4输出";
            this.gpio4_cb.UseVisualStyleBackColor = true;
            // 
            // radioButton_gpio4_high
            // 
            this.radioButton_gpio4_high.AutoSize = true;
            this.radioButton_gpio4_high.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_gpio4_high.Location = new System.Drawing.Point(117, 4);
            this.radioButton_gpio4_high.Name = "radioButton_gpio4_high";
            this.radioButton_gpio4_high.Size = new System.Drawing.Size(37, 18);
            this.radioButton_gpio4_high.TabIndex = 49;
            this.radioButton_gpio4_high.Text = "高";
            this.radioButton_gpio4_high.UseVisualStyleBackColor = true;
            // 
            // radioButton_gpio4_low
            // 
            this.radioButton_gpio4_low.AutoSize = true;
            this.radioButton_gpio4_low.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_gpio4_low.Location = new System.Drawing.Point(163, 4);
            this.radioButton_gpio4_low.Name = "radioButton_gpio4_low";
            this.radioButton_gpio4_low.Size = new System.Drawing.Size(37, 18);
            this.radioButton_gpio4_low.TabIndex = 50;
            this.radioButton_gpio4_low.Text = "低";
            this.radioButton_gpio4_low.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.gpio3_cb);
            this.panel5.Controls.Add(this.radioButton_gpio3_high);
            this.panel5.Controls.Add(this.radioButton_gpio3_low);
            this.panel5.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel5.Location = new System.Drawing.Point(12, 61);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(206, 26);
            this.panel5.TabIndex = 52;
            // 
            // gpio3_cb
            // 
            this.gpio3_cb.AutoSize = true;
            this.gpio3_cb.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpio3_cb.Location = new System.Drawing.Point(5, 4);
            this.gpio3_cb.Name = "gpio3_cb";
            this.gpio3_cb.Size = new System.Drawing.Size(88, 18);
            this.gpio3_cb.TabIndex = 45;
            this.gpio3_cb.Text = "GPIO3输出";
            this.gpio3_cb.UseVisualStyleBackColor = true;
            // 
            // radioButton_gpio3_high
            // 
            this.radioButton_gpio3_high.AutoSize = true;
            this.radioButton_gpio3_high.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_gpio3_high.Location = new System.Drawing.Point(118, 4);
            this.radioButton_gpio3_high.Name = "radioButton_gpio3_high";
            this.radioButton_gpio3_high.Size = new System.Drawing.Size(37, 18);
            this.radioButton_gpio3_high.TabIndex = 49;
            this.radioButton_gpio3_high.Text = "高";
            this.radioButton_gpio3_high.UseVisualStyleBackColor = true;
            // 
            // radioButton_gpio3_low
            // 
            this.radioButton_gpio3_low.AutoSize = true;
            this.radioButton_gpio3_low.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_gpio3_low.Location = new System.Drawing.Point(164, 4);
            this.radioButton_gpio3_low.Name = "radioButton_gpio3_low";
            this.radioButton_gpio3_low.Size = new System.Drawing.Size(37, 18);
            this.radioButton_gpio3_low.TabIndex = 50;
            this.radioButton_gpio3_low.Text = "低";
            this.radioButton_gpio3_low.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.gpio2_cb);
            this.panel4.Controls.Add(this.radioButton_gpio2_high);
            this.panel4.Controls.Add(this.radioButton_gpio2_low);
            this.panel4.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel4.Location = new System.Drawing.Point(224, 23);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(206, 26);
            this.panel4.TabIndex = 21;
            // 
            // gpio2_cb
            // 
            this.gpio2_cb.AutoSize = true;
            this.gpio2_cb.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpio2_cb.Location = new System.Drawing.Point(5, 4);
            this.gpio2_cb.Name = "gpio2_cb";
            this.gpio2_cb.Size = new System.Drawing.Size(88, 18);
            this.gpio2_cb.TabIndex = 45;
            this.gpio2_cb.Text = "GPIO2输入";
            this.gpio2_cb.UseVisualStyleBackColor = true;
            // 
            // radioButton_gpio2_high
            // 
            this.radioButton_gpio2_high.AutoSize = true;
            this.radioButton_gpio2_high.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_gpio2_high.Location = new System.Drawing.Point(117, 4);
            this.radioButton_gpio2_high.Name = "radioButton_gpio2_high";
            this.radioButton_gpio2_high.Size = new System.Drawing.Size(37, 18);
            this.radioButton_gpio2_high.TabIndex = 46;
            this.radioButton_gpio2_high.Text = "高";
            this.radioButton_gpio2_high.UseVisualStyleBackColor = true;
            // 
            // radioButton_gpio2_low
            // 
            this.radioButton_gpio2_low.AutoSize = true;
            this.radioButton_gpio2_low.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_gpio2_low.Location = new System.Drawing.Point(163, 4);
            this.radioButton_gpio2_low.Name = "radioButton_gpio2_low";
            this.radioButton_gpio2_low.Size = new System.Drawing.Size(37, 18);
            this.radioButton_gpio2_low.TabIndex = 47;
            this.radioButton_gpio2_low.Text = "低";
            this.radioButton_gpio2_low.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.gpio1_cb);
            this.panel6.Controls.Add(this.radioButton_gpio1_high);
            this.panel6.Controls.Add(this.radioButton_gpio1_low);
            this.panel6.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel6.Location = new System.Drawing.Point(12, 23);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(206, 26);
            this.panel6.TabIndex = 51;
            // 
            // gpio1_cb
            // 
            this.gpio1_cb.AutoSize = true;
            this.gpio1_cb.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpio1_cb.Location = new System.Drawing.Point(5, 4);
            this.gpio1_cb.Name = "gpio1_cb";
            this.gpio1_cb.Size = new System.Drawing.Size(88, 18);
            this.gpio1_cb.TabIndex = 45;
            this.gpio1_cb.Text = "GPIO1输入";
            this.gpio1_cb.UseVisualStyleBackColor = true;
            // 
            // radioButton_gpio1_high
            // 
            this.radioButton_gpio1_high.AutoSize = true;
            this.radioButton_gpio1_high.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_gpio1_high.Location = new System.Drawing.Point(118, 4);
            this.radioButton_gpio1_high.Name = "radioButton_gpio1_high";
            this.radioButton_gpio1_high.Size = new System.Drawing.Size(37, 18);
            this.radioButton_gpio1_high.TabIndex = 43;
            this.radioButton_gpio1_high.Text = "高";
            this.radioButton_gpio1_high.UseVisualStyleBackColor = true;
            // 
            // radioButton_gpio1_low
            // 
            this.radioButton_gpio1_low.AutoSize = true;
            this.radioButton_gpio1_low.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_gpio1_low.Location = new System.Drawing.Point(164, 4);
            this.radioButton_gpio1_low.Name = "radioButton_gpio1_low";
            this.radioButton_gpio1_low.Size = new System.Drawing.Size(37, 18);
            this.radioButton_gpio1_low.TabIndex = 44;
            this.radioButton_gpio1_low.Text = "低";
            this.radioButton_gpio1_low.UseVisualStyleBackColor = true;
            // 
            // button_gpio_set
            // 
            this.button_gpio_set.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_gpio_set.Location = new System.Drawing.Point(442, 62);
            this.button_gpio_set.Name = "button_gpio_set";
            this.button_gpio_set.Size = new System.Drawing.Size(60, 25);
            this.button_gpio_set.TabIndex = 44;
            this.button_gpio_set.Text = "设置";
            this.button_gpio_set.UseVisualStyleBackColor = true;
            this.button_gpio_set.Click += new System.EventHandler(this.button_gpio_set_Click);
            // 
            // button_gpio_get
            // 
            this.button_gpio_get.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_gpio_get.Location = new System.Drawing.Point(442, 24);
            this.button_gpio_get.Name = "button_gpio_get";
            this.button_gpio_get.Size = new System.Drawing.Size(60, 25);
            this.button_gpio_get.TabIndex = 43;
            this.button_gpio_get.Text = "获取";
            this.button_gpio_get.UseVisualStyleBackColor = true;
            this.button_gpio_get.Click += new System.EventHandler(this.button_gpio_get_Click);
            // 
            // GPIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox_gpio);
            this.Name = "GPIO";
            this.Size = new System.Drawing.Size(524, 104);
            this.groupBox_gpio.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_gpio;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.CheckBox gpio4_cb;
        private System.Windows.Forms.RadioButton radioButton_gpio4_high;
        private System.Windows.Forms.RadioButton radioButton_gpio4_low;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox gpio3_cb;
        private System.Windows.Forms.RadioButton radioButton_gpio3_high;
        private System.Windows.Forms.RadioButton radioButton_gpio3_low;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox gpio2_cb;
        private System.Windows.Forms.RadioButton radioButton_gpio2_high;
        private System.Windows.Forms.RadioButton radioButton_gpio2_low;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.CheckBox gpio1_cb;
        private System.Windows.Forms.RadioButton radioButton_gpio1_high;
        private System.Windows.Forms.RadioButton radioButton_gpio1_low;
        private System.Windows.Forms.Button button_gpio_set;
        private System.Windows.Forms.Button button_gpio_get;
    }
}
