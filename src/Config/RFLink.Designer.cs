namespace SrDemo.Config
{
    partial class RFLink
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
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.rf_link_profile_index = new System.Windows.Forms.ComboBox();
            this.Set_RF_link_profile = new System.Windows.Forms.Button();
            this.Get_RF_Link_profile = new System.Windows.Forms.Button();
            this.label42 = new System.Windows.Forms.Label();
            this.groupBox17.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox17
            // 
            this.groupBox17.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox17.Controls.Add(this.checkBox1);
            this.groupBox17.Controls.Add(this.rf_link_profile_index);
            this.groupBox17.Controls.Add(this.Set_RF_link_profile);
            this.groupBox17.Controls.Add(this.Get_RF_Link_profile);
            this.groupBox17.Controls.Add(this.label42);
            this.groupBox17.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox17.ForeColor = System.Drawing.Color.Navy;
            this.groupBox17.Location = new System.Drawing.Point(6, 2);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(268, 95);
            this.groupBox17.TabIndex = 53;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "RF 链路设置";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(17, 63);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(87, 20);
            this.checkBox1.TabIndex = 57;
            this.checkBox1.Text = "断电保存";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // rf_link_profile_index
            // 
            this.rf_link_profile_index.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rf_link_profile_index.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rf_link_profile_index.ForeColor = System.Drawing.Color.Navy;
            this.rf_link_profile_index.FormattingEnabled = true;
            this.rf_link_profile_index.Items.AddRange(new object[] {
            "DSB_ASK / FM0 / 40KHZ",
            "PR _ASK / Miller4 / 250KHZ",
            "PR _ASK / Miller4 / 300KHZ",
            "DSB_ASK / FM0 / 400KHZ"});
            this.rf_link_profile_index.Location = new System.Drawing.Point(50, 25);
            this.rf_link_profile_index.Name = "rf_link_profile_index";
            this.rf_link_profile_index.Size = new System.Drawing.Size(209, 22);
            this.rf_link_profile_index.TabIndex = 56;
            // 
            // Set_RF_link_profile
            // 
            this.Set_RF_link_profile.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Set_RF_link_profile.ForeColor = System.Drawing.Color.Navy;
            this.Set_RF_link_profile.Location = new System.Drawing.Point(193, 60);
            this.Set_RF_link_profile.Name = "Set_RF_link_profile";
            this.Set_RF_link_profile.Size = new System.Drawing.Size(64, 26);
            this.Set_RF_link_profile.TabIndex = 8;
            this.Set_RF_link_profile.Text = "设置";
            this.Set_RF_link_profile.UseVisualStyleBackColor = true;
            this.Set_RF_link_profile.Click += new System.EventHandler(this.Set_RF_link_profile_Click);
            // 
            // Get_RF_Link_profile
            // 
            this.Get_RF_Link_profile.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Get_RF_Link_profile.ForeColor = System.Drawing.Color.Navy;
            this.Get_RF_Link_profile.Location = new System.Drawing.Point(126, 60);
            this.Get_RF_Link_profile.Name = "Get_RF_Link_profile";
            this.Get_RF_Link_profile.Size = new System.Drawing.Size(61, 26);
            this.Get_RF_Link_profile.TabIndex = 7;
            this.Get_RF_Link_profile.Text = "获取";
            this.Get_RF_Link_profile.UseVisualStyleBackColor = true;
            this.Get_RF_Link_profile.Click += new System.EventHandler(this.Get_RF_Link_profile_Click);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label42.ForeColor = System.Drawing.Color.Navy;
            this.label42.Location = new System.Drawing.Point(11, 29);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(35, 14);
            this.label42.TabIndex = 3;
            this.label42.Text = "数据:";
            // 
            // RFLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox17);
            this.Name = "RFLink";
            this.Size = new System.Drawing.Size(279, 101);
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.ComboBox rf_link_profile_index;
        private System.Windows.Forms.Button Set_RF_link_profile;
        private System.Windows.Forms.Button Get_RF_Link_profile;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
