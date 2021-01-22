namespace SrDemo
{
    partial class SrDemo
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SrDemo));
            this.gbCOM = new System.Windows.Forms.GroupBox();
            this.cbBaute = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCOM = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label_firmware_version = new System.Windows.Forms.Label();
            this.label_hardware_version = new System.Windows.Forms.Label();
            this.listView_oper_log = new System.Windows.Forms.ListView();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.timer_scan = new System.Windows.Forms.Timer(this.components);
            this.timer_auto = new System.Windows.Forms.Timer(this.components);
            this.tabOp = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txbid = new System.Windows.Forms.TextBox();
            this.grvShow = new System.Windows.Forms.DataGridView();
            this.btnshowDB = new System.Windows.Forms.Button();
            this.btnSaveDB = new System.Windows.Forms.Button();
            this.btnclear = new System.Windows.Forms.Button();
            this.Write_USER = new System.Windows.Forms.Button();
            this.textBox_data_USER = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_data_RFU = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_data_TID = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox_data_EPC = new System.Windows.Forms.TextBox();
            this.Write_EPC = new System.Windows.Forms.Button();
            this.button_data_read = new System.Windows.Forms.Button();
            this.tabScan = new System.Windows.Forms.TabPage();
            this.button_clear = new System.Windows.Forms.Button();
            this.listView_label = new System.Windows.Forms.ListView();
            this.button_query = new System.Windows.Forms.Button();
            this.label_query_speed = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label_query_time = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label_tags_total = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_multi_time = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.radioButton_single = new System.Windows.Forms.RadioButton();
            this.radioButton_multi = new System.Windows.Forms.RadioButton();
            this.label23 = new System.Windows.Forms.Label();
            this.tabDemo = new System.Windows.Forms.TabControl();
            this.pbSr = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxStudents = new System.Windows.Forms.ComboBox();
            this.gbCOM.SuspendLayout();
            this.tabOp.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvShow)).BeginInit();
            this.tabScan.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabDemo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSr)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCOM
            // 
            this.gbCOM.Controls.Add(this.cbBaute);
            this.gbCOM.Controls.Add(this.label2);
            this.gbCOM.Controls.Add(this.cbCOM);
            this.gbCOM.Controls.Add(this.label1);
            this.gbCOM.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCOM.Location = new System.Drawing.Point(13, 116);
            this.gbCOM.Margin = new System.Windows.Forms.Padding(4);
            this.gbCOM.Name = "gbCOM";
            this.gbCOM.Padding = new System.Windows.Forms.Padding(4);
            this.gbCOM.Size = new System.Drawing.Size(178, 100);
            this.gbCOM.TabIndex = 14;
            this.gbCOM.TabStop = false;
            this.gbCOM.Text = "COM";
            // 
            // cbBaute
            // 
            this.cbBaute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaute.FormattingEnabled = true;
            this.cbBaute.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cbBaute.Location = new System.Drawing.Point(76, 59);
            this.cbBaute.Margin = new System.Windows.Forms.Padding(4);
            this.cbBaute.Name = "cbBaute";
            this.cbBaute.Size = new System.Drawing.Size(81, 24);
            this.cbBaute.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Baudrate:";
            // 
            // cbCOM
            // 
            this.cbCOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCOM.FormattingEnabled = true;
            this.cbCOM.Location = new System.Drawing.Point(76, 25);
            this.cbCOM.Margin = new System.Windows.Forms.Padding(4);
            this.cbCOM.Name = "cbCOM";
            this.cbCOM.Size = new System.Drawing.Size(81, 24);
            this.cbCOM.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "PORT:";
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(54, 224);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(81, 37);
            this.btnConnect.TabIndex = 16;
            this.btnConnect.Text = "Open";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label_firmware_version
            // 
            this.label_firmware_version.AutoSize = true;
            this.label_firmware_version.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_firmware_version.Location = new System.Drawing.Point(15, 310);
            this.label_firmware_version.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_firmware_version.Name = "label_firmware_version";
            this.label_firmware_version.Size = new System.Drawing.Size(68, 17);
            this.label_firmware_version.TabIndex = 1;
            this.label_firmware_version.Text = "Firmware:";
            // 
            // label_hardware_version
            // 
            this.label_hardware_version.AutoSize = true;
            this.label_hardware_version.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_hardware_version.Location = new System.Drawing.Point(15, 279);
            this.label_hardware_version.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_hardware_version.Name = "label_hardware_version";
            this.label_hardware_version.Size = new System.Drawing.Size(71, 17);
            this.label_hardware_version.TabIndex = 0;
            this.label_hardware_version.Text = "Hardware:";
            // 
            // listView_oper_log
            // 
            this.listView_oper_log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.listView_oper_log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView_oper_log.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_oper_log.GridLines = true;
            this.listView_oper_log.HideSelection = false;
            this.listView_oper_log.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listView_oper_log.Location = new System.Drawing.Point(202, 360);
            this.listView_oper_log.Margin = new System.Windows.Forms.Padding(4);
            this.listView_oper_log.MultiSelect = false;
            this.listView_oper_log.Name = "listView_oper_log";
            this.listView_oper_log.Size = new System.Drawing.Size(1058, 130);
            this.listView_oper_log.TabIndex = 1;
            this.listView_oper_log.UseCompatibleStateImageBehavior = false;
            this.listView_oper_log.View = System.Windows.Forms.View.Details;
            // 
            // groupBox8
            // 
            this.groupBox8.Location = new System.Drawing.Point(7, 7);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(343, 87);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "groupBox8";
            // 
            // groupBox9
            // 
            this.groupBox9.Location = new System.Drawing.Point(366, 7);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(343, 87);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "groupBox7";
            // 
            // timer_scan
            // 
            this.timer_scan.Interval = 1000;
            this.timer_scan.Tick += new System.EventHandler(this.timer_scan_Tick);
            // 
            // timer_auto
            // 
            this.timer_auto.Interval = 1000;
            this.timer_auto.Tick += new System.EventHandler(this.timer_auto_Tick);
            // 
            // tabOp
            // 
            this.tabOp.BackColor = System.Drawing.Color.White;
            this.tabOp.Controls.Add(this.groupBox7);
            this.tabOp.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabOp.Location = new System.Drawing.Point(4, 24);
            this.tabOp.Margin = new System.Windows.Forms.Padding(4);
            this.tabOp.Name = "tabOp";
            this.tabOp.Padding = new System.Windows.Forms.Padding(4);
            this.tabOp.Size = new System.Drawing.Size(1057, 329);
            this.tabOp.TabIndex = 3;
            this.tabOp.Text = "Advanced operation";
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox7.Controls.Add(this.comboBoxStudents);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.btnUpdate);
            this.groupBox7.Controls.Add(this.txbid);
            this.groupBox7.Controls.Add(this.grvShow);
            this.groupBox7.Controls.Add(this.btnshowDB);
            this.groupBox7.Controls.Add(this.btnSaveDB);
            this.groupBox7.Controls.Add(this.btnclear);
            this.groupBox7.Controls.Add(this.Write_USER);
            this.groupBox7.Controls.Add(this.textBox_data_USER);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.label12);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.textBox_data_RFU);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.textBox_data_TID);
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Controls.Add(this.textBox_data_EPC);
            this.groupBox7.Controls.Add(this.Write_EPC);
            this.groupBox7.Controls.Add(this.button_data_read);
            this.groupBox7.Location = new System.Drawing.Point(4, 8);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox7.Size = new System.Drawing.Size(1051, 315);
            this.groupBox7.TabIndex = 12;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Read/Write ";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(346, 262);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 46);
            this.btnUpdate.TabIndex = 41;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txbid
            // 
            this.txbid.Location = new System.Drawing.Point(81, 59);
            this.txbid.Name = "txbid";
            this.txbid.Size = new System.Drawing.Size(53, 23);
            this.txbid.TabIndex = 40;
            // 
            // grvShow
            // 
            this.grvShow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvShow.Location = new System.Drawing.Point(463, 178);
            this.grvShow.Name = "grvShow";
            this.grvShow.Size = new System.Drawing.Size(581, 130);
            this.grvShow.TabIndex = 39;
            // 
            // btnshowDB
            // 
            this.btnshowDB.Location = new System.Drawing.Point(346, 203);
            this.btnshowDB.Name = "btnshowDB";
            this.btnshowDB.Size = new System.Drawing.Size(75, 53);
            this.btnshowDB.TabIndex = 38;
            this.btnshowDB.Text = "Show DB";
            this.btnshowDB.UseVisualStyleBackColor = true;
            this.btnshowDB.Click += new System.EventHandler(this.btnshowDB_Click);
            // 
            // btnSaveDB
            // 
            this.btnSaveDB.Location = new System.Drawing.Point(254, 202);
            this.btnSaveDB.Name = "btnSaveDB";
            this.btnSaveDB.Size = new System.Drawing.Size(75, 53);
            this.btnSaveDB.TabIndex = 37;
            this.btnSaveDB.Text = "Save DB";
            this.btnSaveDB.UseVisualStyleBackColor = true;
            this.btnSaveDB.Click += new System.EventHandler(this.btnSaveDB_Click);
            // 
            // btnclear
            // 
            this.btnclear.Location = new System.Drawing.Point(156, 203);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(75, 52);
            this.btnclear.TabIndex = 36;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // Write_USER
            // 
            this.Write_USER.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Write_USER.Location = new System.Drawing.Point(507, 131);
            this.Write_USER.Margin = new System.Windows.Forms.Padding(4);
            this.Write_USER.Name = "Write_USER";
            this.Write_USER.Size = new System.Drawing.Size(112, 27);
            this.Write_USER.TabIndex = 2;
            this.Write_USER.Text = "Write USER";
            this.Write_USER.UseVisualStyleBackColor = true;
            this.Write_USER.Click += new System.EventHandler(this.Write_USER_Click_1);
            // 
            // textBox_data_USER
            // 
            this.textBox_data_USER.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_data_USER.Location = new System.Drawing.Point(82, 133);
            this.textBox_data_USER.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_data_USER.MaxLength = 64;
            this.textBox_data_USER.Name = "textBox_data_USER";
            this.textBox_data_USER.Size = new System.Drawing.Size(411, 21);
            this.textBox_data_USER.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(18, 136);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 15);
            this.label9.TabIndex = 35;
            this.label9.Text = "USER:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(721, 136);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 15);
            this.label12.TabIndex = 29;
            this.label12.Text = "RFU:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(721, 92);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 15);
            this.label6.TabIndex = 29;
            this.label6.Text = "TID:";
            // 
            // textBox_data_RFU
            // 
            this.textBox_data_RFU.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_data_RFU.Location = new System.Drawing.Point(784, 133);
            this.textBox_data_RFU.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_data_RFU.Name = "textBox_data_RFU";
            this.textBox_data_RFU.ReadOnly = true;
            this.textBox_data_RFU.Size = new System.Drawing.Size(234, 21);
            this.textBox_data_RFU.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(18, 92);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 29;
            this.label5.Text = "EPC:";
            // 
            // textBox_data_TID
            // 
            this.textBox_data_TID.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_data_TID.Location = new System.Drawing.Point(784, 86);
            this.textBox_data_TID.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_data_TID.Name = "textBox_data_TID";
            this.textBox_data_TID.ReadOnly = true;
            this.textBox_data_TID.Size = new System.Drawing.Size(234, 21);
            this.textBox_data_TID.TabIndex = 28;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(373, 29);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(280, 23);
            this.label16.TabIndex = 33;
            this.label16.Text = "FOUR CARD MEMORY AREA";
            // 
            // textBox_data_EPC
            // 
            this.textBox_data_EPC.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_data_EPC.Location = new System.Drawing.Point(81, 89);
            this.textBox_data_EPC.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_data_EPC.MaxLength = 24;
            this.textBox_data_EPC.Name = "textBox_data_EPC";
            this.textBox_data_EPC.Size = new System.Drawing.Size(234, 21);
            this.textBox_data_EPC.TabIndex = 3;
            // 
            // Write_EPC
            // 
            this.Write_EPC.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Write_EPC.Location = new System.Drawing.Point(507, 85);
            this.Write_EPC.Margin = new System.Windows.Forms.Padding(4);
            this.Write_EPC.Name = "Write_EPC";
            this.Write_EPC.Size = new System.Drawing.Size(112, 27);
            this.Write_EPC.TabIndex = 4;
            this.Write_EPC.Text = "Write EPC";
            this.Write_EPC.UseVisualStyleBackColor = true;
            this.Write_EPC.Click += new System.EventHandler(this.Write_EPC_Click);
            // 
            // button_data_read
            // 
            this.button_data_read.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_data_read.Location = new System.Drawing.Point(19, 203);
            this.button_data_read.Margin = new System.Windows.Forms.Padding(4);
            this.button_data_read.Name = "button_data_read";
            this.button_data_read.Size = new System.Drawing.Size(110, 52);
            this.button_data_read.TabIndex = 22;
            this.button_data_read.Text = "Read";
            this.button_data_read.UseVisualStyleBackColor = true;
            this.button_data_read.Click += new System.EventHandler(this.button_data_read_Click);
            // 
            // tabScan
            // 
            this.tabScan.BackColor = System.Drawing.Color.White;
            this.tabScan.Controls.Add(this.button_clear);
            this.tabScan.Controls.Add(this.listView_label);
            this.tabScan.Controls.Add(this.button_query);
            this.tabScan.Controls.Add(this.label_query_speed);
            this.tabScan.Controls.Add(this.label43);
            this.tabScan.Controls.Add(this.label_query_time);
            this.tabScan.Controls.Add(this.label35);
            this.tabScan.Controls.Add(this.label_tags_total);
            this.tabScan.Controls.Add(this.groupBox2);
            this.tabScan.Controls.Add(this.label23);
            this.tabScan.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabScan.Location = new System.Drawing.Point(4, 24);
            this.tabScan.Margin = new System.Windows.Forms.Padding(4);
            this.tabScan.Name = "tabScan";
            this.tabScan.Padding = new System.Windows.Forms.Padding(4);
            this.tabScan.Size = new System.Drawing.Size(1057, 329);
            this.tabScan.TabIndex = 2;
            this.tabScan.Text = "Tags Query";
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(684, 76);
            this.button_clear.Margin = new System.Windows.Forms.Padding(4);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(90, 37);
            this.button_clear.TabIndex = 42;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // listView_label
            // 
            this.listView_label.BackColor = System.Drawing.Color.White;
            this.listView_label.ForeColor = System.Drawing.Color.Black;
            this.listView_label.GridLines = true;
            this.listView_label.HideSelection = false;
            this.listView_label.Location = new System.Drawing.Point(4, 120);
            this.listView_label.Margin = new System.Windows.Forms.Padding(4);
            this.listView_label.Name = "listView_label";
            this.listView_label.Size = new System.Drawing.Size(1048, 205);
            this.listView_label.TabIndex = 2;
            this.listView_label.UseCompatibleStateImageBehavior = false;
            this.listView_label.View = System.Windows.Forms.View.Details;
            this.listView_label.DoubleClick += new System.EventHandler(this.listView_label_DoubleClick);
            // 
            // button_query
            // 
            this.button_query.Location = new System.Drawing.Point(566, 76);
            this.button_query.Margin = new System.Windows.Forms.Padding(4);
            this.button_query.Name = "button_query";
            this.button_query.Size = new System.Drawing.Size(90, 37);
            this.button_query.TabIndex = 41;
            this.button_query.Text = "Query";
            this.button_query.UseVisualStyleBackColor = true;
            this.button_query.Click += new System.EventHandler(this.button_query_Click);
            // 
            // label_query_speed
            // 
            this.label_query_speed.AutoSize = true;
            this.label_query_speed.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_query_speed.ForeColor = System.Drawing.Color.Blue;
            this.label_query_speed.Location = new System.Drawing.Point(486, 76);
            this.label_query_speed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_query_speed.Name = "label_query_speed";
            this.label_query_speed.Size = new System.Drawing.Size(22, 21);
            this.label_query_speed.TabIndex = 40;
            this.label_query_speed.Text = "0";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(346, 82);
            this.label43.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(72, 16);
            this.label43.TabIndex = 39;
            this.label43.Text = "Speed(p/s):";
            // 
            // label_query_time
            // 
            this.label_query_time.AutoSize = true;
            this.label_query_time.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_query_time.ForeColor = System.Drawing.Color.Blue;
            this.label_query_time.Location = new System.Drawing.Point(298, 76);
            this.label_query_time.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_query_time.Name = "label_query_time";
            this.label_query_time.Size = new System.Drawing.Size(22, 21);
            this.label_query_time.TabIndex = 38;
            this.label_query_time.Text = "0";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(174, 82);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(73, 16);
            this.label35.TabIndex = 37;
            this.label35.Text = "Times（s）：";
            // 
            // label_tags_total
            // 
            this.label_tags_total.AutoSize = true;
            this.label_tags_total.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_tags_total.ForeColor = System.Drawing.Color.Blue;
            this.label_tags_total.Location = new System.Drawing.Point(122, 76);
            this.label_tags_total.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_tags_total.Name = "label_tags_total";
            this.label_tags_total.Size = new System.Drawing.Size(22, 21);
            this.label_tags_total.TabIndex = 36;
            this.label_tags_total.Text = "0";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Controls.Add(this.textBox_multi_time);
            this.groupBox2.Controls.Add(this.label44);
            this.groupBox2.Controls.Add(this.label36);
            this.groupBox2.Controls.Add(this.radioButton_single);
            this.groupBox2.Controls.Add(this.radioButton_multi);
            this.groupBox2.Location = new System.Drawing.Point(4, 8);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1047, 57);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Query type";
            // 
            // textBox_multi_time
            // 
            this.textBox_multi_time.Location = new System.Drawing.Point(565, 19);
            this.textBox_multi_time.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_multi_time.MaxLength = 9;
            this.textBox_multi_time.Name = "textBox_multi_time";
            this.textBox_multi_time.Size = new System.Drawing.Size(74, 23);
            this.textBox_multi_time.TabIndex = 38;
            this.textBox_multi_time.Text = "0";
            this.textBox_multi_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_multi_time.Visible = false;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(481, 24);
            this.label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(267, 16);
            this.label44.TabIndex = 42;
            this.label44.Text = "Frequency:                     (0 means unlimited)";
            this.label44.Visible = false;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(389, 74);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(0, 16);
            this.label36.TabIndex = 40;
            // 
            // radioButton_single
            // 
            this.radioButton_single.AutoSize = true;
            this.radioButton_single.Location = new System.Drawing.Point(98, 23);
            this.radioButton_single.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_single.Name = "radioButton_single";
            this.radioButton_single.Size = new System.Drawing.Size(60, 20);
            this.radioButton_single.TabIndex = 39;
            this.radioButton_single.Text = "Single";
            this.radioButton_single.UseVisualStyleBackColor = true;
            // 
            // radioButton_multi
            // 
            this.radioButton_multi.AutoSize = true;
            this.radioButton_multi.Checked = true;
            this.radioButton_multi.Location = new System.Drawing.Point(255, 24);
            this.radioButton_multi.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_multi.Name = "radioButton_multi";
            this.radioButton_multi.Size = new System.Drawing.Size(47, 20);
            this.radioButton_multi.TabIndex = 39;
            this.radioButton_multi.TabStop = true;
            this.radioButton_multi.Text = "MU";
            this.radioButton_multi.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(33, 82);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(85, 16);
            this.label23.TabIndex = 12;
            this.label23.Text = "Tags counts：";
            // 
            // tabDemo
            // 
            this.tabDemo.Controls.Add(this.tabScan);
            this.tabDemo.Controls.Add(this.tabOp);
            this.tabDemo.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDemo.Location = new System.Drawing.Point(199, -1);
            this.tabDemo.Margin = new System.Windows.Forms.Padding(4);
            this.tabDemo.Name = "tabDemo";
            this.tabDemo.SelectedIndex = 0;
            this.tabDemo.Size = new System.Drawing.Size(1065, 357);
            this.tabDemo.TabIndex = 0;
            // 
            // pbSr
            // 
            this.pbSr.Image = ((System.Drawing.Image)(resources.GetObject("pbSr.Image")));
            this.pbSr.Location = new System.Drawing.Point(1, 1);
            this.pbSr.Margin = new System.Windows.Forms.Padding(4);
            this.pbSr.Name = "pbSr";
            this.pbSr.Size = new System.Drawing.Size(197, 86);
            this.pbSr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSr.TabIndex = 1;
            this.pbSr.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(18, 170);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 42;
            this.label3.Text = "Student:";
            // 
            // comboBoxStudents
            // 
            this.comboBoxStudents.FormattingEnabled = true;
            this.comboBoxStudents.Location = new System.Drawing.Point(104, 167);
            this.comboBoxStudents.Name = "comboBoxStudents";
            this.comboBoxStudents.Size = new System.Drawing.Size(316, 24);
            this.comboBoxStudents.TabIndex = 43;
            // 
            // SrDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1267, 492);
            this.Controls.Add(this.listView_oper_log);
            this.Controls.Add(this.label_firmware_version);
            this.Controls.Add(this.label_hardware_version);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.gbCOM);
            this.Controls.Add(this.pbSr);
            this.Controls.Add(this.tabDemo);
            this.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "SrDemo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ATD TECH UHF READER";
            this.Load += new System.EventHandler(this.SrDemo_Load);
            this.gbCOM.ResumeLayout(false);
            this.gbCOM.PerformLayout();
            this.tabOp.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvShow)).EndInit();
            this.tabScan.ResumeLayout(false);
            this.tabScan.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabDemo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCOM;
        private System.Windows.Forms.ComboBox cbCOM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbBaute;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label_firmware_version;
        private System.Windows.Forms.Label label_hardware_version;
        private System.Windows.Forms.ListView listView_oper_log;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Timer timer_scan;
        private System.Windows.Forms.Timer timer_auto;
        private System.Windows.Forms.TabPage tabOp;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button Write_EPC;
        private System.Windows.Forms.TabPage tabScan;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.ListView listView_label;
        private System.Windows.Forms.Button button_query;
        private System.Windows.Forms.Label label_query_speed;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label_query_time;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label_tags_total;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_multi_time;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.RadioButton radioButton_single;
        private System.Windows.Forms.RadioButton radioButton_multi;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TabControl tabDemo;
        private System.Windows.Forms.PictureBox pbSr;
        private System.Windows.Forms.TextBox textBox_data_EPC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_data_RFU;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button Write_USER;
        private System.Windows.Forms.TextBox textBox_data_USER;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_data_TID;
        private System.Windows.Forms.Button button_data_read;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btnSaveDB;
        private System.Windows.Forms.Button btnshowDB;
        private System.Windows.Forms.DataGridView grvShow;
        private System.Windows.Forms.TextBox txbid;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox comboBoxStudents;
        private System.Windows.Forms.Label label3;
    }
}

