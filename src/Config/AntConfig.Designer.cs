namespace SrDemo.Config
{
    partial class AntConfig
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.Get_ant_mes = new System.Windows.Forms.Button();
            this.button_set_ant = new System.Windows.Forms.Button();
            this.textBox_ant1_worktime = new System.Windows.Forms.TextBox();
            this.textBox_waittime = new System.Windows.Forms.TextBox();
            this.textBox_ant2_worktime = new System.Windows.Forms.TextBox();
            this.textBox_ant4_worktime = new System.Windows.Forms.TextBox();
            this.textBox_ant3_worktime = new System.Windows.Forms.TextBox();
            this.checkBox_ant1 = new System.Windows.Forms.CheckBox();
            this.checkBox_ant2 = new System.Windows.Forms.CheckBox();
            this.label48 = new System.Windows.Forms.Label();
            this.checkBox_ant3 = new System.Windows.Forms.CheckBox();
            this.checkBox_ant4 = new System.Windows.Forms.CheckBox();
            this.groupBox16.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox16
            // 
            this.groupBox16.BackColor = System.Drawing.Color.Transparent;
            this.groupBox16.Controls.Add(this.Get_ant_mes);
            this.groupBox16.Controls.Add(this.button_set_ant);
            this.groupBox16.Controls.Add(this.textBox_ant1_worktime);
            this.groupBox16.Controls.Add(this.textBox_waittime);
            this.groupBox16.Controls.Add(this.textBox_ant2_worktime);
            this.groupBox16.Controls.Add(this.textBox_ant4_worktime);
            this.groupBox16.Controls.Add(this.textBox_ant3_worktime);
            this.groupBox16.Controls.Add(this.checkBox_ant1);
            this.groupBox16.Controls.Add(this.checkBox_ant2);
            this.groupBox16.Controls.Add(this.label48);
            this.groupBox16.Controls.Add(this.checkBox_ant3);
            this.groupBox16.Controls.Add(this.checkBox_ant4);
            this.groupBox16.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox16.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox16.Location = new System.Drawing.Point(3, 3);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(724, 46);
            this.groupBox16.TabIndex = 21;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "四通道读写器";
            this.groupBox16.Enter += new System.EventHandler(this.groupBox16_Enter);
            // 
            // Get_ant_mes
            // 
            this.Get_ant_mes.Location = new System.Drawing.Point(823, 20);
            this.Get_ant_mes.Name = "Get_ant_mes";
            this.Get_ant_mes.Size = new System.Drawing.Size(56, 29);
            this.Get_ant_mes.TabIndex = 47;
            this.Get_ant_mes.Text = "获取";
            this.Get_ant_mes.UseVisualStyleBackColor = true;
            this.Get_ant_mes.Click += new System.EventHandler(this.Get_ant_mes_Click);
            // 
            // button_set_ant
            // 
            this.button_set_ant.Location = new System.Drawing.Point(756, 20);
            this.button_set_ant.Name = "button_set_ant";
            this.button_set_ant.Size = new System.Drawing.Size(56, 29);
            this.button_set_ant.TabIndex = 42;
            this.button_set_ant.Text = "设置";
            this.button_set_ant.UseVisualStyleBackColor = true;
            this.button_set_ant.Click += new System.EventHandler(this.button_set_ant_Click);
            // 
            // textBox_ant1_worktime
            // 
            this.textBox_ant1_worktime.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_ant1_worktime.ForeColor = System.Drawing.Color.Navy;
            this.textBox_ant1_worktime.Location = new System.Drawing.Point(75, 19);
            this.textBox_ant1_worktime.MaxLength = 5;
            this.textBox_ant1_worktime.Name = "textBox_ant1_worktime";
            this.textBox_ant1_worktime.Size = new System.Drawing.Size(44, 23);
            this.textBox_ant1_worktime.TabIndex = 4;
            this.textBox_ant1_worktime.Text = "300";
            this.textBox_ant1_worktime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_waittime
            // 
            this.textBox_waittime.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_waittime.ForeColor = System.Drawing.Color.Navy;
            this.textBox_waittime.Location = new System.Drawing.Point(645, 19);
            this.textBox_waittime.MaxLength = 5;
            this.textBox_waittime.Name = "textBox_waittime";
            this.textBox_waittime.Size = new System.Drawing.Size(44, 23);
            this.textBox_waittime.TabIndex = 34;
            this.textBox_waittime.Text = "0";
            this.textBox_waittime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_ant2_worktime
            // 
            this.textBox_ant2_worktime.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_ant2_worktime.ForeColor = System.Drawing.Color.Navy;
            this.textBox_ant2_worktime.Location = new System.Drawing.Point(214, 19);
            this.textBox_ant2_worktime.MaxLength = 5;
            this.textBox_ant2_worktime.Name = "textBox_ant2_worktime";
            this.textBox_ant2_worktime.Size = new System.Drawing.Size(44, 23);
            this.textBox_ant2_worktime.TabIndex = 23;
            this.textBox_ant2_worktime.Text = "300";
            this.textBox_ant2_worktime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_ant4_worktime
            // 
            this.textBox_ant4_worktime.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_ant4_worktime.ForeColor = System.Drawing.Color.Navy;
            this.textBox_ant4_worktime.Location = new System.Drawing.Point(492, 19);
            this.textBox_ant4_worktime.MaxLength = 5;
            this.textBox_ant4_worktime.Name = "textBox_ant4_worktime";
            this.textBox_ant4_worktime.Size = new System.Drawing.Size(44, 23);
            this.textBox_ant4_worktime.TabIndex = 29;
            this.textBox_ant4_worktime.Text = "300";
            this.textBox_ant4_worktime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_ant3_worktime
            // 
            this.textBox_ant3_worktime.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_ant3_worktime.ForeColor = System.Drawing.Color.Navy;
            this.textBox_ant3_worktime.Location = new System.Drawing.Point(354, 19);
            this.textBox_ant3_worktime.MaxLength = 5;
            this.textBox_ant3_worktime.Name = "textBox_ant3_worktime";
            this.textBox_ant3_worktime.Size = new System.Drawing.Size(44, 23);
            this.textBox_ant3_worktime.TabIndex = 26;
            this.textBox_ant3_worktime.Text = "300";
            this.textBox_ant3_worktime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBox_ant1
            // 
            this.checkBox_ant1.AutoSize = true;
            this.checkBox_ant1.Checked = true;
            this.checkBox_ant1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_ant1.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_ant1.ForeColor = System.Drawing.Color.Navy;
            this.checkBox_ant1.Location = new System.Drawing.Point(21, 21);
            this.checkBox_ant1.Name = "checkBox_ant1";
            this.checkBox_ant1.Size = new System.Drawing.Size(115, 18);
            this.checkBox_ant1.TabIndex = 0;
            this.checkBox_ant1.Text = "Ant1           ms";
            this.checkBox_ant1.UseVisualStyleBackColor = true;
            this.checkBox_ant1.CheckedChanged += new System.EventHandler(this.checkBox_ant1_CheckedChanged);
            // 
            // checkBox_ant2
            // 
            this.checkBox_ant2.AutoSize = true;
            this.checkBox_ant2.Checked = true;
            this.checkBox_ant2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_ant2.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_ant2.ForeColor = System.Drawing.Color.Navy;
            this.checkBox_ant2.Location = new System.Drawing.Point(160, 21);
            this.checkBox_ant2.Name = "checkBox_ant2";
            this.checkBox_ant2.Size = new System.Drawing.Size(115, 18);
            this.checkBox_ant2.TabIndex = 22;
            this.checkBox_ant2.Text = "Ant2           ms";
            this.checkBox_ant2.UseVisualStyleBackColor = true;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label48.ForeColor = System.Drawing.Color.Navy;
            this.label48.Location = new System.Drawing.Point(579, 23);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(120, 14);
            this.label48.TabIndex = 33;
            this.label48.Text = "等待时间:           ms";
            // 
            // checkBox_ant3
            // 
            this.checkBox_ant3.AutoSize = true;
            this.checkBox_ant3.Checked = true;
            this.checkBox_ant3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_ant3.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_ant3.ForeColor = System.Drawing.Color.Navy;
            this.checkBox_ant3.Location = new System.Drawing.Point(299, 21);
            this.checkBox_ant3.Name = "checkBox_ant3";
            this.checkBox_ant3.Size = new System.Drawing.Size(115, 18);
            this.checkBox_ant3.TabIndex = 25;
            this.checkBox_ant3.Text = "Ant3           ms";
            this.checkBox_ant3.UseVisualStyleBackColor = true;
            // 
            // checkBox_ant4
            // 
            this.checkBox_ant4.AutoSize = true;
            this.checkBox_ant4.Checked = true;
            this.checkBox_ant4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_ant4.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_ant4.ForeColor = System.Drawing.Color.Navy;
            this.checkBox_ant4.Location = new System.Drawing.Point(438, 21);
            this.checkBox_ant4.Name = "checkBox_ant4";
            this.checkBox_ant4.Size = new System.Drawing.Size(115, 18);
            this.checkBox_ant4.TabIndex = 28;
            this.checkBox_ant4.Text = "Ant4           ms";
            this.checkBox_ant4.UseVisualStyleBackColor = true;
            // 
            // AntConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox16);
            this.Name = "AntConfig";
            this.Size = new System.Drawing.Size(733, 53);
            this.Load += new System.EventHandler(this.AntConfig_Load);
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.Button Get_ant_mes;
        private System.Windows.Forms.Button button_set_ant;
        private System.Windows.Forms.TextBox textBox_ant1_worktime;
        private System.Windows.Forms.TextBox textBox_waittime;
        private System.Windows.Forms.TextBox textBox_ant2_worktime;
        private System.Windows.Forms.TextBox textBox_ant4_worktime;
        private System.Windows.Forms.TextBox textBox_ant3_worktime;
        private System.Windows.Forms.CheckBox checkBox_ant1;
        private System.Windows.Forms.CheckBox checkBox_ant2;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.CheckBox checkBox_ant3;
        private System.Windows.Forms.CheckBox checkBox_ant4;
    }
}
