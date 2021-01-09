namespace SrDemo.Config
{
    partial class Temperaturecs
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
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.button1_get_temperature = new System.Windows.Forms.Button();
            this.label_temperature = new System.Windows.Forms.Label();
            this.groupBox19.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox19
            // 
            this.groupBox19.BackColor = System.Drawing.Color.Transparent;
            this.groupBox19.Controls.Add(this.button1_get_temperature);
            this.groupBox19.Controls.Add(this.label_temperature);
            this.groupBox19.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox19.ForeColor = System.Drawing.Color.DarkGreen;
            this.groupBox19.Location = new System.Drawing.Point(3, 3);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(187, 66);
            this.groupBox19.TabIndex = 54;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "温度";
            // 
            // button1_get_temperature
            // 
            this.button1_get_temperature.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1_get_temperature.ForeColor = System.Drawing.Color.DarkGreen;
            this.button1_get_temperature.Location = new System.Drawing.Point(93, 20);
            this.button1_get_temperature.Name = "button1_get_temperature";
            this.button1_get_temperature.Size = new System.Drawing.Size(78, 32);
            this.button1_get_temperature.TabIndex = 43;
            this.button1_get_temperature.Text = "获取";
            this.button1_get_temperature.UseVisualStyleBackColor = true;
            this.button1_get_temperature.Click += new System.EventHandler(this.button1_get_temperature_Click);
            // 
            // label_temperature
            // 
            this.label_temperature.AutoSize = true;
            this.label_temperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_temperature.ForeColor = System.Drawing.Color.DarkGreen;
            this.label_temperature.Location = new System.Drawing.Point(22, 22);
            this.label_temperature.Name = "label_temperature";
            this.label_temperature.Size = new System.Drawing.Size(58, 33);
            this.label_temperature.TabIndex = 39;
            this.label_temperature.Text = "0.0";
            // 
            // Temperaturecs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox19);
            this.Name = "Temperaturecs";
            this.Size = new System.Drawing.Size(198, 77);
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.Button button1_get_temperature;
        private System.Windows.Forms.Label label_temperature;
    }
}
