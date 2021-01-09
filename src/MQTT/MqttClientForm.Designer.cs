namespace SrDemo.MQTT
{
    partial class MqttClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.TextBoxPublishMsg = new System.Windows.Forms.TextBox();
            this.textBoxRecvMsg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "登录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(31, 150);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "发送消息";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TextBoxPublishMsg
            // 
            this.TextBoxPublishMsg.Location = new System.Drawing.Point(149, 127);
            this.TextBoxPublishMsg.Multiline = true;
            this.TextBoxPublishMsg.Name = "TextBoxPublishMsg";
            this.TextBoxPublishMsg.Size = new System.Drawing.Size(283, 75);
            this.TextBoxPublishMsg.TabIndex = 1;
            // 
            // textBoxRecvMsg
            // 
            this.textBoxRecvMsg.Location = new System.Drawing.Point(149, 242);
            this.textBoxRecvMsg.Multiline = true;
            this.textBoxRecvMsg.Name = "textBoxRecvMsg";
            this.textBoxRecvMsg.Size = new System.Drawing.Size(283, 75);
            this.textBoxRecvMsg.TabIndex = 2;
            this.textBoxRecvMsg.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "接收订阅许消息";
            // 
            // MqttClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 418);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxRecvMsg);
            this.Controls.Add(this.TextBoxPublishMsg);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "MqttClientForm";
            this.Text = "MqttClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox TextBoxPublishMsg;
        private System.Windows.Forms.TextBox textBoxRecvMsg;
        private System.Windows.Forms.Label label1;
    }
}