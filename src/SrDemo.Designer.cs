using System.Windows.Forms;
namespace SrDemo
{


    partial class SrDemo
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        class ListViewNF : System.Windows.Forms.ListView
        {
            public ListViewNF()
            {
                // 开启双缓冲
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

                // Enable the OnNotifyMessage event so we get a chance to filter out 
                // Windows messages before they get to the form's WndProc
                this.SetStyle(ControlStyles.EnableNotifyMessage, true);
            }

            protected override void OnNotifyMessage(Message m)
            {
                //Filter out the WM_ERASEBKGND message
                if (m.Msg != 0x14)
                {
                    base.OnNotifyMessage(m);
                }

            }
  
        }
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
        /// 
    
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("工作模式和基本参数");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("设备地址和网络参数");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("MQTT基本参数");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("恢复出厂设置");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("设备相关指令测试");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("心跳");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("通用参数", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("射频功率");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("区域和频率");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("天线工作时间");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Tagfocus");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("标签基本操作");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("QT标签");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("模块相关测试指令");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("同时读取EPC和TID");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("FastID");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("批量写标读标");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Map");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("超高频读写器参数", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("设备出厂参数设置");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("超高频射频参数设置");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("超高频读写标签测试");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("2.4G测试");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("9200模块版本");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("透传数据");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("测试专用", new System.Windows.Forms.TreeNode[] {
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23,
            treeNode24,
            treeNode25});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SrDemo));
            this.listView_oper_log = new System.Windows.Forms.ListView();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.timer_scan = new System.Windows.Forms.Timer(this.components);
            this.timer_md_query_Tick = new System.Windows.Forms.Timer(this.components);
            this.groupBox_multidevice = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.PortOpen_b = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.labelReaderReportEpcCounts = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.connect_b = new System.Windows.Forms.Button();
            this.LabelIDTime = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.reader_port_tb = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.LabelCurrentTimes = new System.Windows.Forms.Label();
            this.LabelIDSpeed = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.listView_md_addr = new System.Windows.Forms.ListView();
            this.LabelIDCounts = new System.Windows.Forms.Label();
            this.LabelCurrentTime = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26_total = new System.Windows.Forms.Label();
            this.currentDev_l = new System.Windows.Forms.Label();
            this.refresh_b = new System.Windows.Forms.Button();
            this.keepalive = new System.Windows.Forms.Timer(this.components);
            this.button12 = new System.Windows.Forms.Button();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统功能配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mQTTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.人员管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.show_EPC_t = new System.Windows.Forms.Timer(this.components);
            this.TimerShowID = new System.Windows.Forms.Timer(this.components);
            this.tabPageArgs = new System.Windows.Forms.TabPage();
            this.panel11 = new System.Windows.Forms.FlowLayoutPanel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabPageActive = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.IsAutocheckBox = new System.Windows.Forms.CheckBox();
            this.tagtype_tb = new System.Windows.Forms.TextBox();
            this.label102 = new System.Windows.Forms.Label();
            this.label99 = new System.Windows.Forms.Label();
            this.channel_tb = new System.Windows.Forms.TextBox();
            this.label103 = new System.Windows.Forms.Label();
            this.button32 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.label100 = new System.Windows.Forms.Label();
            this.recv_tb = new System.Windows.Forms.TextBox();
            this.label104 = new System.Windows.Forms.Label();
            this.FilterCheckBox = new System.Windows.Forms.CheckBox();
            this.fd = new System.Windows.Forms.TextBox();
            this.buttonStartIDMonitor = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBoxshowIDType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ListViewID = new SrDemo.ListViewNF();
            this.ItemNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemDev = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemTem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemRemove = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemRSSI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemPower = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemBattery = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabScan = new System.Windows.Forms.TabPage();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonModuleTest = new System.Windows.Forms.RadioButton();
            this.radioButtonMachineTest = new System.Windows.Forms.RadioButton();
            this.AdvanceGroup = new System.Windows.Forms.GroupBox();
            this.AntSetbutton = new System.Windows.Forms.Button();
            this.labletest = new System.Windows.Forms.Label();
            this.NoAnt = new System.Windows.Forms.CheckBox();
            this.testbtn = new System.Windows.Forms.Button();
            this.SelectAntcheckBox1 = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.SelectAntcheckBox2 = new System.Windows.Forms.CheckBox();
            this.SelectAntcheckBox3 = new System.Windows.Forms.CheckBox();
            this.button_time_fliecabinet = new System.Windows.Forms.Button();
            this.SelectAntcheckBox4 = new System.Windows.Forms.CheckBox();
            this.ComboBoxShowStyle = new System.Windows.Forms.ComboBox();
            this.Text_time_fliecabinet = new System.Windows.Forms.TextBox();
            this.buttonStartMonitor = new System.Windows.Forms.Button();
            this.singleEPC_rb = new System.Windows.Forms.CheckBox();
            this.allreader_cb = new System.Windows.Forms.CheckBox();
            this.listView_md_epc = new SrDemo.ListViewNF();
            this.Num = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AntID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EPC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RSSI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Count = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DevID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Dir = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.issame = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_md_clear = new System.Windows.Forms.Button();
            this.button_md_stop = new System.Windows.Forms.Button();
            this.button_md_start = new System.Windows.Forms.Button();
            this.sourceDataSaveBt = new System.Windows.Forms.Button();
            this.StartSaveExcel = new System.Windows.Forms.Button();
            this.MultiFunctionMode = new System.Windows.Forms.Button();
            this.Maintable = new System.Windows.Forms.TabControl();
            this.page_quickstart = new System.Windows.Forms.TabPage();
            this.pannel_quickstart = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button8 = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.progressBar4 = new System.Windows.Forms.ProgressBar();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.label22 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timerMonitor = new System.Windows.Forms.Timer(this.components);
            this.timerIDMonitor = new System.Windows.Forms.Timer(this.components);
            this.timerMessage = new System.Windows.Forms.Timer(this.components);
            this.sourceDataSave = new System.Windows.Forms.Timer(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox_multidevice.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabPageArgs.SuspendLayout();
            this.tabPageActive.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabScan.SuspendLayout();
            this.panel1.SuspendLayout();
            this.AdvanceGroup.SuspendLayout();
            this.Maintable.SuspendLayout();
            this.page_quickstart.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView_oper_log
            // 
            this.listView_oper_log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.listView_oper_log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView_oper_log.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView_oper_log.GridLines = true;
            this.listView_oper_log.HideSelection = false;
            this.listView_oper_log.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listView_oper_log.Location = new System.Drawing.Point(16, 624);
            this.listView_oper_log.MultiSelect = false;
            this.listView_oper_log.Name = "listView_oper_log";
            this.listView_oper_log.Size = new System.Drawing.Size(1314, 98);
            this.listView_oper_log.TabIndex = 1;
            this.listView_oper_log.UseCompatibleStateImageBehavior = false;
            this.listView_oper_log.View = System.Windows.Forms.View.Details;
            this.listView_oper_log.SelectedIndexChanged += new System.EventHandler(this.listView_oper_log_SelectedIndexChanged);
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
            // timer_md_query_Tick
            // 
            this.timer_md_query_Tick.Interval = 50;
            this.timer_md_query_Tick.Tick += new System.EventHandler(this.timer_md_query_Tick_Tick);
            // 
            // groupBox_multidevice
            // 
            this.groupBox_multidevice.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox_multidevice.Controls.Add(this.button7);
            this.groupBox_multidevice.Controls.Add(this.label15);
            this.groupBox_multidevice.Controls.Add(this.label1);
            this.groupBox_multidevice.Controls.Add(this.comboBox1);
            this.groupBox_multidevice.Controls.Add(this.comboBox7);
            this.groupBox_multidevice.Controls.Add(this.PortOpen_b);
            this.groupBox_multidevice.Controls.Add(this.button9);
            this.groupBox_multidevice.Controls.Add(this.labelReaderReportEpcCounts);
            this.groupBox_multidevice.Controls.Add(this.label2);
            this.groupBox_multidevice.Controls.Add(this.label20);
            this.groupBox_multidevice.Controls.Add(this.label10);
            this.groupBox_multidevice.Controls.Add(this.connect_b);
            this.groupBox_multidevice.Controls.Add(this.LabelIDTime);
            this.groupBox_multidevice.Controls.Add(this.label12);
            this.groupBox_multidevice.Controls.Add(this.label3);
            this.groupBox_multidevice.Controls.Add(this.reader_port_tb);
            this.groupBox_multidevice.Controls.Add(this.label8);
            this.groupBox_multidevice.Controls.Add(this.LabelCurrentTimes);
            this.groupBox_multidevice.Controls.Add(this.LabelIDSpeed);
            this.groupBox_multidevice.Controls.Add(this.label7);
            this.groupBox_multidevice.Controls.Add(this.label9);
            this.groupBox_multidevice.Controls.Add(this.listView_md_addr);
            this.groupBox_multidevice.Controls.Add(this.LabelIDCounts);
            this.groupBox_multidevice.Controls.Add(this.LabelCurrentTime);
            this.groupBox_multidevice.Controls.Add(this.label11);
            this.groupBox_multidevice.Controls.Add(this.label6);
            this.groupBox_multidevice.Controls.Add(this.label5);
            this.groupBox_multidevice.Controls.Add(this.label25);
            this.groupBox_multidevice.Controls.Add(this.label26_total);
            this.groupBox_multidevice.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox_multidevice.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox_multidevice.Location = new System.Drawing.Point(5, 4);
            this.groupBox_multidevice.Name = "groupBox_multidevice";
            this.groupBox_multidevice.Size = new System.Drawing.Size(300, 619);
            this.groupBox_multidevice.TabIndex = 1;
            this.groupBox_multidevice.TabStop = false;
            this.groupBox_multidevice.Text = "连接设备";
            this.groupBox_multidevice.Enter += new System.EventHandler(this.groupBox_multidevice_Enter);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(216, 389);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 25);
            this.button7.TabIndex = 130;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click_4);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Firebrick;
            this.label15.Location = new System.Drawing.Point(174, 593);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 19);
            this.label15.TabIndex = 129;
            this.label15.Text = "label15";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(175, 512);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 17);
            this.label1.TabIndex = 128;
            this.label1.Text = "S";
            this.label1.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft YaHei", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.ForeColor = System.Drawing.Color.DarkBlue;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(64, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(97, 23);
            this.comboBox1.TabIndex = 9;
            // 
            // comboBox7
            // 
            this.comboBox7.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox7.ForeColor = System.Drawing.Color.DarkBlue;
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(64, 60);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(97, 25);
            this.comboBox7.TabIndex = 8;
            // 
            // PortOpen_b
            // 
            this.PortOpen_b.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PortOpen_b.Location = new System.Drawing.Point(231, 60);
            this.PortOpen_b.Name = "PortOpen_b";
            this.PortOpen_b.Size = new System.Drawing.Size(62, 27);
            this.PortOpen_b.TabIndex = 7;
            this.PortOpen_b.Text = "打开";
            this.PortOpen_b.UseVisualStyleBackColor = true;
            this.PortOpen_b.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button9.Location = new System.Drawing.Point(168, 60);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(53, 27);
            this.button9.TabIndex = 7;
            this.button9.Text = "设置";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // labelReaderReportEpcCounts
            // 
            this.labelReaderReportEpcCounts.AutoSize = true;
            this.labelReaderReportEpcCounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelReaderReportEpcCounts.ForeColor = System.Drawing.Color.DarkBlue;
            this.labelReaderReportEpcCounts.Location = new System.Drawing.Point(105, 596);
            this.labelReaderReportEpcCounts.Name = "labelReaderReportEpcCounts";
            this.labelReaderReportEpcCounts.Size = new System.Drawing.Size(17, 17);
            this.labelReaderReportEpcCounts.TabIndex = 123;
            this.labelReaderReportEpcCounts.Text = "0";
            this.labelReaderReportEpcCounts.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(153, 520);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 120;
            this.label2.Text = "张/秒";
            this.label2.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(10, 96);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(164, 17);
            this.label20.TabIndex = 5;
            this.label20.Text = "请单击选择要操作的读写器：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.DarkGreen;
            this.label10.Location = new System.Drawing.Point(174, 460);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 17);
            this.label10.TabIndex = 119;
            this.label10.Text = "张/秒";
            this.label10.Visible = false;
            // 
            // connect_b
            // 
            this.connect_b.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.connect_b.Location = new System.Drawing.Point(231, 27);
            this.connect_b.Name = "connect_b";
            this.connect_b.Size = new System.Drawing.Size(62, 27);
            this.connect_b.TabIndex = 4;
            this.connect_b.Text = "连接";
            this.connect_b.UseVisualStyleBackColor = true;
            this.connect_b.Click += new System.EventHandler(this.connect_b_Click);
            // 
            // LabelIDTime
            // 
            this.LabelIDTime.AutoSize = true;
            this.LabelIDTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelIDTime.ForeColor = System.Drawing.Color.Red;
            this.LabelIDTime.Location = new System.Drawing.Point(101, 502);
            this.LabelIDTime.Name = "LabelIDTime";
            this.LabelIDTime.Size = new System.Drawing.Size(19, 20);
            this.LabelIDTime.TabIndex = 114;
            this.LabelIDTime.Text = "0";
            this.LabelIDTime.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.DarkGreen;
            this.label12.Location = new System.Drawing.Point(10, 596);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 17);
            this.label12.TabIndex = 122;
            this.label12.Text = "上报数量：";
            this.label12.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.DarkGreen;
            this.label3.Location = new System.Drawing.Point(20, 511);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 115;
            this.label3.Text = "工作时间：";
            this.label3.Visible = false;
            // 
            // reader_port_tb
            // 
            this.reader_port_tb.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.reader_port_tb.ForeColor = System.Drawing.Color.DarkBlue;
            this.reader_port_tb.Location = new System.Drawing.Point(168, 27);
            this.reader_port_tb.Name = "reader_port_tb";
            this.reader_port_tb.Size = new System.Drawing.Size(53, 23);
            this.reader_port_tb.TabIndex = 3;
            this.reader_port_tb.Text = "6000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(100, 507);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 25);
            this.label8.TabIndex = 108;
            this.label8.Text = "0";
            this.label8.Visible = false;
            // 
            // LabelCurrentTimes
            // 
            this.LabelCurrentTimes.AutoSize = true;
            this.LabelCurrentTimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelCurrentTimes.ForeColor = System.Drawing.Color.Red;
            this.LabelCurrentTimes.Location = new System.Drawing.Point(103, 458);
            this.LabelCurrentTimes.Name = "LabelCurrentTimes";
            this.LabelCurrentTimes.Size = new System.Drawing.Size(17, 17);
            this.LabelCurrentTimes.TabIndex = 109;
            this.LabelCurrentTimes.Text = "0";
            this.LabelCurrentTimes.Visible = false;
            // 
            // LabelIDSpeed
            // 
            this.LabelIDSpeed.AutoSize = true;
            this.LabelIDSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelIDSpeed.ForeColor = System.Drawing.Color.Red;
            this.LabelIDSpeed.Location = new System.Drawing.Point(100, 445);
            this.LabelIDSpeed.Name = "LabelIDSpeed";
            this.LabelIDSpeed.Size = new System.Drawing.Size(19, 20);
            this.LabelIDSpeed.TabIndex = 113;
            this.LabelIDSpeed.Text = "0";
            this.LabelIDSpeed.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.DarkGreen;
            this.label7.Location = new System.Drawing.Point(20, 520);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 107;
            this.label7.Text = "速      度";
            this.label7.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.DarkGreen;
            this.label9.Location = new System.Drawing.Point(21, 459);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 17);
            this.label9.TabIndex = 112;
            this.label9.Text = "速     度";
            this.label9.Visible = false;
            // 
            // listView_md_addr
            // 
            this.listView_md_addr.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView_md_addr.BackColor = System.Drawing.Color.White;
            this.listView_md_addr.Font = new System.Drawing.Font("Microsoft YaHei", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView_md_addr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.listView_md_addr.GridLines = true;
            this.listView_md_addr.HideSelection = false;
            this.listView_md_addr.HoverSelection = true;
            this.listView_md_addr.Location = new System.Drawing.Point(6, 118);
            this.listView_md_addr.Name = "listView_md_addr";
            this.listView_md_addr.Size = new System.Drawing.Size(285, 251);
            this.listView_md_addr.TabIndex = 0;
            this.listView_md_addr.UseCompatibleStateImageBehavior = false;
            this.listView_md_addr.View = System.Windows.Forms.View.Details;
            this.listView_md_addr.SelectedIndexChanged += new System.EventHandler(this.listView_md_addr_SelectedIndexChanged);
            this.listView_md_addr.DoubleClick += new System.EventHandler(this.listView_md_addr_DoubleClick);
            // 
            // LabelIDCounts
            // 
            this.LabelIDCounts.AutoSize = true;
            this.LabelIDCounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelIDCounts.ForeColor = System.Drawing.Color.Red;
            this.LabelIDCounts.Location = new System.Drawing.Point(103, 397);
            this.LabelIDCounts.Name = "LabelIDCounts";
            this.LabelIDCounts.Size = new System.Drawing.Size(19, 20);
            this.LabelIDCounts.TabIndex = 111;
            this.LabelIDCounts.Text = "0";
            this.LabelIDCounts.Visible = false;
            // 
            // LabelCurrentTime
            // 
            this.LabelCurrentTime.AutoSize = true;
            this.LabelCurrentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelCurrentTime.ForeColor = System.Drawing.Color.DarkGreen;
            this.LabelCurrentTime.Location = new System.Drawing.Point(19, 466);
            this.LabelCurrentTime.Name = "LabelCurrentTime";
            this.LabelCurrentTime.Size = new System.Drawing.Size(68, 17);
            this.LabelCurrentTime.TabIndex = 109;
            this.LabelCurrentTime.Text = "时      间";
            this.LabelCurrentTime.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.DarkGreen;
            this.label11.Location = new System.Drawing.Point(21, 406);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 17);
            this.label11.TabIndex = 110;
            this.label11.Text = "标签总数：";
            this.label11.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(10, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "串口号:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(10, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "服务器:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.ForeColor = System.Drawing.Color.DarkGreen;
            this.label25.Location = new System.Drawing.Point(21, 397);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(76, 17);
            this.label25.TabIndex = 7;
            this.label25.Text = "标签总数：";
            this.label25.Visible = false;
            this.label25.Click += new System.EventHandler(this.label25_Click);
            // 
            // label26_total
            // 
            this.label26_total.AutoSize = true;
            this.label26_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.5F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26_total.ForeColor = System.Drawing.Color.Red;
            this.label26_total.Location = new System.Drawing.Point(103, 389);
            this.label26_total.Name = "label26_total";
            this.label26_total.Size = new System.Drawing.Size(27, 29);
            this.label26_total.TabIndex = 97;
            this.label26_total.Text = "0";
            this.label26_total.Visible = false;
            // 
            // currentDev_l
            // 
            this.currentDev_l.AutoSize = true;
            this.currentDev_l.BackColor = System.Drawing.SystemColors.Control;
            this.currentDev_l.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.currentDev_l.ForeColor = System.Drawing.Color.Blue;
            this.currentDev_l.Location = new System.Drawing.Point(457, 626);
            this.currentDev_l.Name = "currentDev_l";
            this.currentDev_l.Size = new System.Drawing.Size(192, 24);
            this.currentDev_l.TabIndex = 98;
            this.currentDev_l.Text = "Device:0.0.0.0:0000";
            // 
            // refresh_b
            // 
            this.refresh_b.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refresh_b.ForeColor = System.Drawing.Color.Green;
            this.refresh_b.Location = new System.Drawing.Point(640, 139);
            this.refresh_b.Name = "refresh_b";
            this.refresh_b.Size = new System.Drawing.Size(23, 50);
            this.refresh_b.TabIndex = 6;
            this.refresh_b.Text = "刷新";
            this.refresh_b.UseVisualStyleBackColor = true;
            this.refresh_b.Visible = false;
            this.refresh_b.Click += new System.EventHandler(this.button8_Click);
            // 
            // keepalive
            // 
            this.keepalive.Interval = 5000;
            this.keepalive.Tick += new System.EventHandler(this.keepalive_Tick);
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button12.ForeColor = System.Drawing.Color.Blue;
            this.button12.Location = new System.Drawing.Point(1253, 625);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(76, 26);
            this.button12.TabIndex = 101;
            this.button12.Text = "English";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click_1);
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(49, 26);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(49, 26);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(49, 26);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 配置ToolStripMenuItem
            // 
            this.配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据库ToolStripMenuItem,
            this.系统功能配置ToolStripMenuItem,
            this.mQTTToolStripMenuItem});
            this.配置ToolStripMenuItem.Name = "配置ToolStripMenuItem";
            this.配置ToolStripMenuItem.Size = new System.Drawing.Size(49, 26);
            this.配置ToolStripMenuItem.Text = "配置";
            // 
            // 数据库ToolStripMenuItem
            // 
            this.数据库ToolStripMenuItem.Name = "数据库ToolStripMenuItem";
            this.数据库ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.数据库ToolStripMenuItem.Text = "数据库";
            this.数据库ToolStripMenuItem.Click += new System.EventHandler(this.数据库ToolStripMenuItem_Click);
            // 
            // 系统功能配置ToolStripMenuItem
            // 
            this.系统功能配置ToolStripMenuItem.Name = "系统功能配置ToolStripMenuItem";
            this.系统功能配置ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.系统功能配置ToolStripMenuItem.Text = "系统功能配置";
            this.系统功能配置ToolStripMenuItem.Click += new System.EventHandler(this.系统功能配置ToolStripMenuItem_Click);
            // 
            // mQTTToolStripMenuItem
            // 
            this.mQTTToolStripMenuItem.Name = "mQTTToolStripMenuItem";
            this.mQTTToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.mQTTToolStripMenuItem.Text = "MQTT";
            this.mQTTToolStripMenuItem.Click += new System.EventHandler(this.mQTTToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.帮助ToolStripMenuItem,
            this.配置ToolStripMenuItem,
            this.功能ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1344, 30);
            this.menuStrip1.TabIndex = 102;
            this.menuStrip1.Visible = false;
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // 功能ToolStripMenuItem
            // 
            this.功能ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件管理ToolStripMenuItem,
            this.人员管理ToolStripMenuItem});
            this.功能ToolStripMenuItem.Name = "功能ToolStripMenuItem";
            this.功能ToolStripMenuItem.Size = new System.Drawing.Size(49, 26);
            this.功能ToolStripMenuItem.Text = "功能";
            // 
            // 文件管理ToolStripMenuItem
            // 
            this.文件管理ToolStripMenuItem.Name = "文件管理ToolStripMenuItem";
            this.文件管理ToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.文件管理ToolStripMenuItem.Text = "文件管理";
            this.文件管理ToolStripMenuItem.Click += new System.EventHandler(this.文件管理ToolStripMenuItem_Click);
            // 
            // 人员管理ToolStripMenuItem
            // 
            this.人员管理ToolStripMenuItem.Name = "人员管理ToolStripMenuItem";
            this.人员管理ToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.人员管理ToolStripMenuItem.Text = "人员管理";
            this.人员管理ToolStripMenuItem.Click += new System.EventHandler(this.人员管理ToolStripMenuItem_Click);
            // 
            // show_EPC_t
            // 
            this.show_EPC_t.Interval = 5000;
            this.show_EPC_t.Tick += new System.EventHandler(this.show_EPC_t_Tick);
            // 
            // TimerShowID
            // 
            this.TimerShowID.Interval = 1000;
            this.TimerShowID.Tick += new System.EventHandler(this.TimerShowID_Tick);
            // 
            // tabPageArgs
            // 
            this.tabPageArgs.Controls.Add(this.panel11);
            this.tabPageArgs.Controls.Add(this.treeView1);
            this.tabPageArgs.Location = new System.Drawing.Point(4, 26);
            this.tabPageArgs.Name = "tabPageArgs";
            this.tabPageArgs.Size = new System.Drawing.Size(1017, 592);
            this.tabPageArgs.TabIndex = 10;
            this.tabPageArgs.Text = "参数设置";
            this.tabPageArgs.UseVisualStyleBackColor = true;
            // 
            // panel11
            // 
            this.panel11.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panel11.Location = new System.Drawing.Point(220, 5);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(886, 580);
            this.panel11.TabIndex = 1;
            this.panel11.Paint += new System.Windows.Forms.PaintEventHandler(this.panel11_Paint_1);
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ForeColor = System.Drawing.Color.Navy;
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "workmode";
            treeNode1.Text = "工作模式和基本参数";
            treeNode2.Name = "tansferinfo";
            treeNode2.Text = "设备地址和网络参数";
            treeNode3.ForeColor = System.Drawing.Color.Black;
            treeNode3.Name = "mqtt";
            treeNode3.Text = "MQTT基本参数";
            treeNode4.Name = "factory";
            treeNode4.Text = "恢复出厂设置";
            treeNode5.Name = "commandtest1";
            treeNode5.Text = "设备相关指令测试";
            treeNode6.Name = "heart";
            treeNode6.Text = "心跳";
            treeNode7.ForeColor = System.Drawing.Color.Blue;
            treeNode7.Name = "common";
            treeNode7.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            treeNode7.Text = "通用参数";
            treeNode8.Name = "power";
            treeNode8.Text = "射频功率";
            treeNode9.Name = "frequency";
            treeNode9.Text = "区域和频率";
            treeNode10.Name = "antwork";
            treeNode10.Text = "天线工作时间";
            treeNode11.Name = "tagfocus";
            treeNode11.Text = "Tagfocus";
            treeNode12.Name = "readwrite";
            treeNode12.Text = "标签基本操作";
            treeNode13.Name = "qt";
            treeNode13.Text = "QT标签";
            treeNode14.Name = "commandtest2";
            treeNode14.Text = "模块相关测试指令";
            treeNode15.Name = "节点0";
            treeNode15.Text = "同时读取EPC和TID";
            treeNode16.Name = "fastid";
            treeNode16.Text = "FastID";
            treeNode17.Name = "batchtag";
            treeNode17.Text = "批量写标读标";
            treeNode18.Name = "gpsmap";
            treeNode18.Text = "Map";
            treeNode19.BackColor = System.Drawing.Color.White;
            treeNode19.ForeColor = System.Drawing.Color.Blue;
            treeNode19.Name = "rfid";
            treeNode19.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            treeNode19.Text = "超高频读写器参数";
            treeNode20.Name = "test1";
            treeNode20.Text = "设备出厂参数设置";
            treeNode21.Name = "test4";
            treeNode21.Text = "超高频射频参数设置";
            treeNode22.Name = "test5";
            treeNode22.Text = "超高频读写标签测试";
            treeNode23.Name = "test6";
            treeNode23.Text = "2.4G测试";
            treeNode24.Name = "test7";
            treeNode24.Text = "9200模块版本";
            treeNode25.Name = "throughdata";
            treeNode25.Text = "透传数据";
            treeNode26.ForeColor = System.Drawing.Color.Blue;
            treeNode26.Name = "test";
            treeNode26.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            treeNode26.Text = "测试专用";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode19,
            treeNode26});
            this.treeView1.Size = new System.Drawing.Size(213, 581);
            this.treeView1.TabIndex = 0;
            this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // tabPageActive
            // 
            this.tabPageActive.Controls.Add(this.groupBox1);
            this.tabPageActive.Controls.Add(this.FilterCheckBox);
            this.tabPageActive.Controls.Add(this.fd);
            this.tabPageActive.Controls.Add(this.buttonStartIDMonitor);
            this.tabPageActive.Controls.Add(this.button4);
            this.tabPageActive.Controls.Add(this.button3);
            this.tabPageActive.Controls.Add(this.button2);
            this.tabPageActive.Controls.Add(this.comboBoxshowIDType);
            this.tabPageActive.Controls.Add(this.label4);
            this.tabPageActive.Controls.Add(this.ListViewID);
            this.tabPageActive.Location = new System.Drawing.Point(4, 26);
            this.tabPageActive.Name = "tabPageActive";
            this.tabPageActive.Size = new System.Drawing.Size(1017, 592);
            this.tabPageActive.TabIndex = 11;
            this.tabPageActive.Text = "有源标签盘存";
            this.tabPageActive.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.IsAutocheckBox);
            this.groupBox1.Controls.Add(this.tagtype_tb);
            this.groupBox1.Controls.Add(this.label102);
            this.groupBox1.Controls.Add(this.label99);
            this.groupBox1.Controls.Add(this.channel_tb);
            this.groupBox1.Controls.Add(this.label103);
            this.groupBox1.Controls.Add(this.button32);
            this.groupBox1.Controls.Add(this.button31);
            this.groupBox1.Controls.Add(this.label100);
            this.groupBox1.Controls.Add(this.recv_tb);
            this.groupBox1.Controls.Add(this.label104);
            this.groupBox1.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox1.Location = new System.Drawing.Point(586, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 80);
            this.groupBox1.TabIndex = 128;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "2.4G";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox1.ForeColor = System.Drawing.Color.Navy;
            this.checkBox1.Location = new System.Drawing.Point(185, 53);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(74, 19);
            this.checkBox1.TabIndex = 33;
            this.checkBox1.Text = "断电保存";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // IsAutocheckBox
            // 
            this.IsAutocheckBox.AutoSize = true;
            this.IsAutocheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IsAutocheckBox.ForeColor = System.Drawing.Color.Navy;
            this.IsAutocheckBox.Location = new System.Drawing.Point(87, 52);
            this.IsAutocheckBox.Name = "IsAutocheckBox";
            this.IsAutocheckBox.Size = new System.Drawing.Size(98, 19);
            this.IsAutocheckBox.TabIndex = 32;
            this.IsAutocheckBox.Text = "开机自动循环";
            this.IsAutocheckBox.UseVisualStyleBackColor = true;
            // 
            // tagtype_tb
            // 
            this.tagtype_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tagtype_tb.ForeColor = System.Drawing.Color.Navy;
            this.tagtype_tb.Location = new System.Drawing.Point(45, 47);
            this.tagtype_tb.Name = "tagtype_tb";
            this.tagtype_tb.Size = new System.Drawing.Size(35, 21);
            this.tagtype_tb.TabIndex = 31;
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label102.ForeColor = System.Drawing.Color.Navy;
            this.label102.Location = new System.Drawing.Point(6, 53);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(34, 15);
            this.label102.TabIndex = 30;
            this.label102.Text = "类型：";
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label99.ForeColor = System.Drawing.Color.Navy;
            this.label99.Location = new System.Drawing.Point(306, 21);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(101, 15);
            this.label99.TabIndex = 29;
            this.label99.Text = "MHz(2400-2480)";
            // 
            // channel_tb
            // 
            this.channel_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.channel_tb.ForeColor = System.Drawing.Color.Navy;
            this.channel_tb.Location = new System.Drawing.Point(217, 14);
            this.channel_tb.Name = "channel_tb";
            this.channel_tb.Size = new System.Drawing.Size(83, 21);
            this.channel_tb.TabIndex = 28;
            // 
            // label103
            // 
            this.label103.AutoSize = true;
            this.label103.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label103.ForeColor = System.Drawing.Color.Navy;
            this.label103.Location = new System.Drawing.Point(161, 20);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(55, 15);
            this.label103.TabIndex = 27;
            this.label103.Text = "信道频率";
            // 
            // button32
            // 
            this.button32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button32.ForeColor = System.Drawing.Color.Navy;
            this.button32.Location = new System.Drawing.Point(370, 46);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(46, 28);
            this.button32.TabIndex = 26;
            this.button32.Text = "设置";
            this.button32.UseVisualStyleBackColor = true;
            this.button32.Click += new System.EventHandler(this.button32_Click);
            // 
            // button31
            // 
            this.button31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button31.ForeColor = System.Drawing.Color.Navy;
            this.button31.Location = new System.Drawing.Point(323, 46);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(41, 28);
            this.button31.TabIndex = 25;
            this.button31.Text = "获取";
            this.button31.UseVisualStyleBackColor = true;
            this.button31.Click += new System.EventHandler(this.button31_Click_1);
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label100.ForeColor = System.Drawing.Color.Navy;
            this.label100.Location = new System.Drawing.Point(111, 21);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(43, 15);
            this.label100.TabIndex = 24;
            this.label100.Text = "(0~63)";
            // 
            // recv_tb
            // 
            this.recv_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recv_tb.ForeColor = System.Drawing.Color.Navy;
            this.recv_tb.Location = new System.Drawing.Point(65, 15);
            this.recv_tb.Name = "recv_tb";
            this.recv_tb.Size = new System.Drawing.Size(40, 21);
            this.recv_tb.TabIndex = 23;
            // 
            // label104
            // 
            this.label104.AutoSize = true;
            this.label104.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label104.ForeColor = System.Drawing.Color.Navy;
            this.label104.Location = new System.Drawing.Point(6, 21);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(55, 15);
            this.label104.TabIndex = 18;
            this.label104.Text = "射频衰减";
            // 
            // FilterCheckBox
            // 
            this.FilterCheckBox.AutoSize = true;
            this.FilterCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FilterCheckBox.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.FilterCheckBox.Location = new System.Drawing.Point(268, 18);
            this.FilterCheckBox.Name = "FilterCheckBox";
            this.FilterCheckBox.Size = new System.Drawing.Size(50, 19);
            this.FilterCheckBox.TabIndex = 127;
            this.FilterCheckBox.Text = "过滤";
            this.FilterCheckBox.UseVisualStyleBackColor = true;
            this.FilterCheckBox.CheckedChanged += new System.EventHandler(this.FilterCheckBox_CheckedChanged);
            // 
            // fd
            // 
            this.fd.Enabled = false;
            this.fd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fd.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.fd.Location = new System.Drawing.Point(346, 14);
            this.fd.Name = "fd";
            this.fd.Size = new System.Drawing.Size(151, 21);
            this.fd.TabIndex = 123;
            // 
            // buttonStartIDMonitor
            // 
            this.buttonStartIDMonitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonStartIDMonitor.ForeColor = System.Drawing.Color.MediumBlue;
            this.buttonStartIDMonitor.Location = new System.Drawing.Point(503, 13);
            this.buttonStartIDMonitor.Name = "buttonStartIDMonitor";
            this.buttonStartIDMonitor.Size = new System.Drawing.Size(77, 63);
            this.buttonStartIDMonitor.TabIndex = 122;
            this.buttonStartIDMonitor.Text = "开始计时";
            this.buttonStartIDMonitor.UseVisualStyleBackColor = true;
            this.buttonStartIDMonitor.Click += new System.EventHandler(this.button5_Click_2);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.button4.Location = new System.Drawing.Point(92, 17);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 51);
            this.button4.TabIndex = 121;
            this.button4.Text = "停止";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.button3.Location = new System.Drawing.Point(6, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(79, 51);
            this.button3.TabIndex = 121;
            this.button3.Text = "开始盘存";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_2);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.button2.Location = new System.Drawing.Point(178, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 51);
            this.button2.TabIndex = 120;
            this.button2.Text = "清除";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // comboBoxshowIDType
            // 
            this.comboBoxshowIDType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxshowIDType.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.comboBoxshowIDType.FormattingEnabled = true;
            this.comboBoxshowIDType.Items.AddRange(new object[] {
            "累计显示",
            "单位时间显示"});
            this.comboBoxshowIDType.Location = new System.Drawing.Point(350, 48);
            this.comboBoxshowIDType.Name = "comboBoxshowIDType";
            this.comboBoxshowIDType.Size = new System.Drawing.Size(147, 23);
            this.comboBoxshowIDType.TabIndex = 117;
            this.comboBoxshowIDType.SelectedIndexChanged += new System.EventHandler(this.comboBoxshowIDType_SelectedIndexChanged);
            this.comboBoxshowIDType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxshowIDType_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label4.Location = new System.Drawing.Point(263, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 116;
            this.label4.Text = "数据显示方式:";
            // 
            // ListViewID
            // 
            this.ListViewID.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ItemNum,
            this.ItemID,
            this.ItemDev,
            this.ItemTem,
            this.ItemRemove,
            this.ItemRSSI,
            this.ItemPower,
            this.ItemBattery,
            this.ItemCount,
            this.ItemTime,
            this.columnHeader1});
            this.ListViewID.GridLines = true;
            this.ListViewID.HideSelection = false;
            this.ListViewID.Location = new System.Drawing.Point(3, 90);
            this.ListViewID.Name = "ListViewID";
            this.ListViewID.Size = new System.Drawing.Size(1010, 493);
            this.ListViewID.TabIndex = 0;
            this.ListViewID.UseCompatibleStateImageBehavior = false;
            this.ListViewID.View = System.Windows.Forms.View.Details;
            this.ListViewID.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListViewID_ColumnClick);
            this.ListViewID.SelectedIndexChanged += new System.EventHandler(this.ListViewID_SelectedIndexChanged);
            // 
            // ItemNum
            // 
            this.ItemNum.Text = "序号";
            this.ItemNum.Width = 50;
            // 
            // ItemID
            // 
            this.ItemID.Text = "ID";
            this.ItemID.Width = 130;
            // 
            // ItemDev
            // 
            this.ItemDev.Text = "设备号";
            this.ItemDev.Width = 130;
            // 
            // ItemTem
            // 
            this.ItemTem.Text = "温度";
            this.ItemTem.Width = 0;
            // 
            // ItemRemove
            // 
            this.ItemRemove.Text = "防拆位";
            this.ItemRemove.Width = 80;
            // 
            // ItemRSSI
            // 
            this.ItemRSSI.Text = "场强";
            // 
            // ItemPower
            // 
            this.ItemPower.Text = "功率";
            this.ItemPower.Width = 80;
            // 
            // ItemBattery
            // 
            this.ItemBattery.Text = "电量";
            this.ItemBattery.Width = 90;
            // 
            // ItemCount
            // 
            this.ItemCount.Text = "读取次数";
            this.ItemCount.Width = 80;
            // 
            // ItemTime
            // 
            this.ItemTime.Text = "发送间隔";
            this.ItemTime.Width = 0;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "上次读取时间";
            this.columnHeader1.Width = 160;
            // 
            // tabScan
            // 
            this.tabScan.Controls.Add(this.checkBox2);
            this.tabScan.Controls.Add(this.button5);
            this.tabScan.Controls.Add(this.button1);
            this.tabScan.Controls.Add(this.panel1);
            this.tabScan.Controls.Add(this.AdvanceGroup);
            this.tabScan.Controls.Add(this.buttonStartMonitor);
            this.tabScan.Controls.Add(this.refresh_b);
            this.tabScan.Controls.Add(this.singleEPC_rb);
            this.tabScan.Controls.Add(this.allreader_cb);
            this.tabScan.Controls.Add(this.listView_md_epc);
            this.tabScan.Controls.Add(this.button_md_clear);
            this.tabScan.Controls.Add(this.button_md_stop);
            this.tabScan.Controls.Add(this.button_md_start);
            this.tabScan.Location = new System.Drawing.Point(4, 26);
            this.tabScan.Name = "tabScan";
            this.tabScan.Padding = new System.Windows.Forms.Padding(3);
            this.tabScan.Size = new System.Drawing.Size(1017, 592);
            this.tabScan.TabIndex = 1;
            this.tabScan.Text = "超高频标签盘存";
            this.tabScan.UseVisualStyleBackColor = true;
            this.tabScan.Click += new System.EventHandler(this.tabScan_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox2.ForeColor = System.Drawing.Color.DarkBlue;
            this.checkBox2.Location = new System.Drawing.Point(458, 7);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(60, 19);
            this.checkBox2.TabIndex = 138;
            this.checkBox2.Text = "ASCII";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Visible = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(274, 54);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(88, 25);
            this.button5.TabIndex = 137;
            this.button5.Text = "停止读温度";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_9);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(274, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 25);
            this.button1.TabIndex = 136;
            this.button1.Text = "开始读温度";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_4);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonModuleTest);
            this.panel1.Controls.Add(this.radioButtonMachineTest);
            this.panel1.Location = new System.Drawing.Point(458, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(70, 47);
            this.panel1.TabIndex = 134;
            this.panel1.Visible = false;
            // 
            // radioButtonModuleTest
            // 
            this.radioButtonModuleTest.AutoSize = true;
            this.radioButtonModuleTest.Enabled = false;
            this.radioButtonModuleTest.Location = new System.Drawing.Point(9, 3);
            this.radioButtonModuleTest.Name = "radioButtonModuleTest";
            this.radioButtonModuleTest.Size = new System.Drawing.Size(50, 21);
            this.radioButtonModuleTest.TabIndex = 0;
            this.radioButtonModuleTest.Text = "模块";
            this.radioButtonModuleTest.UseVisualStyleBackColor = true;
            this.radioButtonModuleTest.Visible = false;
            this.radioButtonModuleTest.CheckedChanged += new System.EventHandler(this.radioButtonModuleTest_CheckedChanged);
            // 
            // radioButtonMachineTest
            // 
            this.radioButtonMachineTest.AutoSize = true;
            this.radioButtonMachineTest.Enabled = false;
            this.radioButtonMachineTest.Location = new System.Drawing.Point(9, 26);
            this.radioButtonMachineTest.Name = "radioButtonMachineTest";
            this.radioButtonMachineTest.Size = new System.Drawing.Size(50, 21);
            this.radioButtonMachineTest.TabIndex = 0;
            this.radioButtonMachineTest.Text = "整机";
            this.radioButtonMachineTest.UseVisualStyleBackColor = true;
            this.radioButtonMachineTest.Visible = false;
            this.radioButtonMachineTest.CheckedChanged += new System.EventHandler(this.radioButtonMachineTest_CheckedChanged);
            // 
            // AdvanceGroup
            // 
            this.AdvanceGroup.Controls.Add(this.AntSetbutton);
            this.AdvanceGroup.Controls.Add(this.labletest);
            this.AdvanceGroup.Controls.Add(this.NoAnt);
            this.AdvanceGroup.Controls.Add(this.testbtn);
            this.AdvanceGroup.Controls.Add(this.SelectAntcheckBox1);
            this.AdvanceGroup.Controls.Add(this.label14);
            this.AdvanceGroup.Controls.Add(this.SelectAntcheckBox2);
            this.AdvanceGroup.Controls.Add(this.SelectAntcheckBox3);
            this.AdvanceGroup.Controls.Add(this.button_time_fliecabinet);
            this.AdvanceGroup.Controls.Add(this.SelectAntcheckBox4);
            this.AdvanceGroup.Controls.Add(this.ComboBoxShowStyle);
            this.AdvanceGroup.Controls.Add(this.Text_time_fliecabinet);
            this.AdvanceGroup.ForeColor = System.Drawing.Color.DarkGreen;
            this.AdvanceGroup.Location = new System.Drawing.Point(534, 1);
            this.AdvanceGroup.Name = "AdvanceGroup";
            this.AdvanceGroup.Size = new System.Drawing.Size(477, 87);
            this.AdvanceGroup.TabIndex = 133;
            this.AdvanceGroup.TabStop = false;
            this.AdvanceGroup.Visible = false;
            // 
            // AntSetbutton
            // 
            this.AntSetbutton.Location = new System.Drawing.Point(243, 23);
            this.AntSetbutton.Name = "AntSetbutton";
            this.AntSetbutton.Size = new System.Drawing.Size(69, 25);
            this.AntSetbutton.TabIndex = 130;
            this.AntSetbutton.Text = "设置天线";
            this.AntSetbutton.UseVisualStyleBackColor = true;
            this.AntSetbutton.Click += new System.EventHandler(this.AntSetbutton_Click);
            // 
            // labletest
            // 
            this.labletest.AutoSize = true;
            this.labletest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labletest.ForeColor = System.Drawing.Color.Red;
            this.labletest.Location = new System.Drawing.Point(4, 2);
            this.labletest.Name = "labletest";
            this.labletest.Size = new System.Drawing.Size(151, 17);
            this.labletest.TabIndex = 129;
            this.labletest.Text = "非工程测试人员勿动：";
            this.labletest.Visible = false;
            // 
            // NoAnt
            // 
            this.NoAnt.AutoSize = true;
            this.NoAnt.Location = new System.Drawing.Point(389, 24);
            this.NoAnt.Name = "NoAnt";
            this.NoAnt.Size = new System.Drawing.Size(87, 21);
            this.NoAnt.TabIndex = 128;
            this.NoAnt.Text = "不区分天线";
            this.NoAnt.UseVisualStyleBackColor = true;
            this.NoAnt.Visible = false;
            // 
            // testbtn
            // 
            this.testbtn.Location = new System.Drawing.Point(317, 22);
            this.testbtn.Name = "testbtn";
            this.testbtn.Size = new System.Drawing.Size(64, 26);
            this.testbtn.TabIndex = 124;
            this.testbtn.Text = "测试";
            this.testbtn.UseVisualStyleBackColor = true;
            this.testbtn.Visible = false;
            this.testbtn.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // SelectAntcheckBox1
            // 
            this.SelectAntcheckBox1.AutoSize = true;
            this.SelectAntcheckBox1.Location = new System.Drawing.Point(16, 24);
            this.SelectAntcheckBox1.Name = "SelectAntcheckBox1";
            this.SelectAntcheckBox1.Size = new System.Drawing.Size(56, 21);
            this.SelectAntcheckBox1.TabIndex = 126;
            this.SelectAntcheckBox1.Text = "Ant1";
            this.SelectAntcheckBox1.UseVisualStyleBackColor = true;
            this.SelectAntcheckBox1.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(170, 54);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 17);
            this.label14.TabIndex = 128;
            this.label14.Text = "ms";
            this.label14.Visible = false;
            // 
            // SelectAntcheckBox2
            // 
            this.SelectAntcheckBox2.AutoSize = true;
            this.SelectAntcheckBox2.Location = new System.Drawing.Point(73, 24);
            this.SelectAntcheckBox2.Name = "SelectAntcheckBox2";
            this.SelectAntcheckBox2.Size = new System.Drawing.Size(56, 21);
            this.SelectAntcheckBox2.TabIndex = 126;
            this.SelectAntcheckBox2.Text = "Ant2";
            this.SelectAntcheckBox2.UseVisualStyleBackColor = true;
            this.SelectAntcheckBox2.Visible = false;
            // 
            // SelectAntcheckBox3
            // 
            this.SelectAntcheckBox3.AutoSize = true;
            this.SelectAntcheckBox3.Location = new System.Drawing.Point(129, 24);
            this.SelectAntcheckBox3.Name = "SelectAntcheckBox3";
            this.SelectAntcheckBox3.Size = new System.Drawing.Size(56, 21);
            this.SelectAntcheckBox3.TabIndex = 126;
            this.SelectAntcheckBox3.Text = "Ant3";
            this.SelectAntcheckBox3.UseVisualStyleBackColor = true;
            this.SelectAntcheckBox3.Visible = false;
            // 
            // button_time_fliecabinet
            // 
            this.button_time_fliecabinet.Location = new System.Drawing.Point(14, 51);
            this.button_time_fliecabinet.Name = "button_time_fliecabinet";
            this.button_time_fliecabinet.Size = new System.Drawing.Size(89, 26);
            this.button_time_fliecabinet.TabIndex = 118;
            this.button_time_fliecabinet.Text = "设置刷新间隔";
            this.button_time_fliecabinet.UseVisualStyleBackColor = true;
            this.button_time_fliecabinet.Visible = false;
            this.button_time_fliecabinet.Click += new System.EventHandler(this.button_time_fliecabinet_Click);
            // 
            // SelectAntcheckBox4
            // 
            this.SelectAntcheckBox4.AutoSize = true;
            this.SelectAntcheckBox4.Location = new System.Drawing.Point(185, 24);
            this.SelectAntcheckBox4.Name = "SelectAntcheckBox4";
            this.SelectAntcheckBox4.Size = new System.Drawing.Size(56, 21);
            this.SelectAntcheckBox4.TabIndex = 126;
            this.SelectAntcheckBox4.Text = "Ant4";
            this.SelectAntcheckBox4.UseVisualStyleBackColor = true;
            this.SelectAntcheckBox4.Visible = false;
            // 
            // ComboBoxShowStyle
            // 
            this.ComboBoxShowStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ComboBoxShowStyle.ForeColor = System.Drawing.Color.DarkGreen;
            this.ComboBoxShowStyle.FormattingEnabled = true;
            this.ComboBoxShowStyle.Items.AddRange(new object[] {
            "测试按钮专用显示",
            "定时显示—适用主从模式",
            "触发定时显示—适用于触发模式",
            "累计显示—适用主从模式",
            "通道门—适用于通道门模式"});
            this.ComboBoxShowStyle.Location = new System.Drawing.Point(202, 51);
            this.ComboBoxShowStyle.Name = "ComboBoxShowStyle";
            this.ComboBoxShowStyle.Size = new System.Drawing.Size(267, 23);
            this.ComboBoxShowStyle.TabIndex = 112;
            this.ComboBoxShowStyle.Visible = false;
            this.ComboBoxShowStyle.SelectedIndexChanged += new System.EventHandler(this.ComboBoxShowStyle_SelectedIndexChanged);
            // 
            // Text_time_fliecabinet
            // 
            this.Text_time_fliecabinet.ForeColor = System.Drawing.Color.DarkGreen;
            this.Text_time_fliecabinet.Location = new System.Drawing.Point(109, 52);
            this.Text_time_fliecabinet.Name = "Text_time_fliecabinet";
            this.Text_time_fliecabinet.Size = new System.Drawing.Size(59, 23);
            this.Text_time_fliecabinet.TabIndex = 117;
            this.Text_time_fliecabinet.Text = "1000";
            this.Text_time_fliecabinet.Visible = false;
            this.Text_time_fliecabinet.TextChanged += new System.EventHandler(this.Text_time_fliecabinet_TextChanged);
            // 
            // buttonStartMonitor
            // 
            this.buttonStartMonitor.Location = new System.Drawing.Point(923, 122);
            this.buttonStartMonitor.Name = "buttonStartMonitor";
            this.buttonStartMonitor.Size = new System.Drawing.Size(75, 26);
            this.buttonStartMonitor.TabIndex = 121;
            this.buttonStartMonitor.Text = "开始计时";
            this.buttonStartMonitor.UseVisualStyleBackColor = true;
            this.buttonStartMonitor.Visible = false;
            this.buttonStartMonitor.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // singleEPC_rb
            // 
            this.singleEPC_rb.AutoSize = true;
            this.singleEPC_rb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.singleEPC_rb.ForeColor = System.Drawing.Color.DarkBlue;
            this.singleEPC_rb.Location = new System.Drawing.Point(374, 52);
            this.singleEPC_rb.Name = "singleEPC_rb";
            this.singleEPC_rb.Size = new System.Drawing.Size(78, 19);
            this.singleEPC_rb.TabIndex = 111;
            this.singleEPC_rb.Text = "单次读标";
            this.singleEPC_rb.UseVisualStyleBackColor = true;
            this.singleEPC_rb.Visible = false;
            // 
            // allreader_cb
            // 
            this.allreader_cb.AutoSize = true;
            this.allreader_cb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.allreader_cb.ForeColor = System.Drawing.Color.DarkBlue;
            this.allreader_cb.Location = new System.Drawing.Point(374, 24);
            this.allreader_cb.Name = "allreader_cb";
            this.allreader_cb.Size = new System.Drawing.Size(78, 19);
            this.allreader_cb.TabIndex = 111;
            this.allreader_cb.Text = "所有设备";
            this.allreader_cb.UseVisualStyleBackColor = true;
            this.allreader_cb.Visible = false;
            // 
            // listView_md_epc
            // 
            this.listView_md_epc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Num,
            this.AntID,
            this.EPC,
            this.PC,
            this.RSSI,
            this.Count,
            this.DevID,
            this.LastTime,
            this.Dir,
            this.issame,
            this.TID});
            this.listView_md_epc.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView_md_epc.ForeColor = System.Drawing.Color.Navy;
            this.listView_md_epc.FullRowSelect = true;
            this.listView_md_epc.GridLines = true;
            this.listView_md_epc.HideSelection = false;
            this.listView_md_epc.Location = new System.Drawing.Point(2, 90);
            this.listView_md_epc.Name = "listView_md_epc";
            this.listView_md_epc.Size = new System.Drawing.Size(1015, 495);
            this.listView_md_epc.TabIndex = 110;
            this.listView_md_epc.UseCompatibleStateImageBehavior = false;
            this.listView_md_epc.View = System.Windows.Forms.View.Details;
            this.listView_md_epc.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_md_epc_ColumnClick);
            this.listView_md_epc.SelectedIndexChanged += new System.EventHandler(this.listView_md_epc_SelectedIndexChanged);
            this.listView_md_epc.DoubleClick += new System.EventHandler(this.listView_md_epc_DoubleClick);
            this.listView_md_epc.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_md_epc_MouseDoubleClick);
            // 
            // Num
            // 
            this.Num.Text = "序号";
            this.Num.Width = 61;
            // 
            // AntID
            // 
            this.AntID.Text = "天线号";
            this.AntID.Width = 52;
            // 
            // EPC
            // 
            this.EPC.Text = "EPC";
            this.EPC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.EPC.Width = 255;
            // 
            // PC
            // 
            this.PC.Text = "EPC长度";
            // 
            // RSSI
            // 
            this.RSSI.Text = "场强";
            // 
            // Count
            // 
            this.Count.Text = "读取次数";
            this.Count.Width = 61;
            // 
            // DevID
            // 
            this.DevID.Text = "设备号";
            this.DevID.Width = 119;
            // 
            // LastTime
            // 
            this.LastTime.Text = "上次读取时间";
            this.LastTime.Width = 156;
            // 
            // Dir
            // 
            this.Dir.Text = "方向";
            this.Dir.Width = 41;
            // 
            // issame
            // 
            this.issame.Text = "温度";
            this.issame.Width = 100;
            // 
            // TID
            // 
            this.TID.Text = "TID";
            this.TID.Width = 200;
            // 
            // button_md_clear
            // 
            this.button_md_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_md_clear.ForeColor = System.Drawing.Color.DarkGreen;
            this.button_md_clear.Location = new System.Drawing.Point(190, 14);
            this.button_md_clear.Name = "button_md_clear";
            this.button_md_clear.Size = new System.Drawing.Size(78, 64);
            this.button_md_clear.TabIndex = 6;
            this.button_md_clear.Text = "清除";
            this.button_md_clear.UseVisualStyleBackColor = true;
            this.button_md_clear.Click += new System.EventHandler(this.button_md_clear_Click);
            // 
            // button_md_stop
            // 
            this.button_md_stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_md_stop.ForeColor = System.Drawing.Color.DarkBlue;
            this.button_md_stop.Location = new System.Drawing.Point(101, 14);
            this.button_md_stop.Name = "button_md_stop";
            this.button_md_stop.Size = new System.Drawing.Size(83, 64);
            this.button_md_stop.TabIndex = 5;
            this.button_md_stop.Text = "停止";
            this.button_md_stop.UseVisualStyleBackColor = true;
            this.button_md_stop.Click += new System.EventHandler(this.button_md_stop_Click);
            // 
            // button_md_start
            // 
            this.button_md_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_md_start.ForeColor = System.Drawing.Color.DarkBlue;
            this.button_md_start.Location = new System.Drawing.Point(9, 14);
            this.button_md_start.Name = "button_md_start";
            this.button_md_start.Size = new System.Drawing.Size(86, 64);
            this.button_md_start.TabIndex = 3;
            this.button_md_start.Text = "循环查询EPC";
            this.button_md_start.UseVisualStyleBackColor = true;
            this.button_md_start.Click += new System.EventHandler(this.button_md_start_Click);
            // 
            // sourceDataSaveBt
            // 
            this.sourceDataSaveBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sourceDataSaveBt.ForeColor = System.Drawing.Color.DarkGreen;
            this.sourceDataSaveBt.Location = new System.Drawing.Point(997, 625);
            this.sourceDataSaveBt.Name = "sourceDataSaveBt";
            this.sourceDataSaveBt.Size = new System.Drawing.Size(120, 26);
            this.sourceDataSaveBt.TabIndex = 132;
            this.sourceDataSaveBt.Text = "开始保存原始数据";
            this.sourceDataSaveBt.UseVisualStyleBackColor = true;
            this.sourceDataSaveBt.Visible = false;
            this.sourceDataSaveBt.Click += new System.EventHandler(this.button7_Click_2);
            // 
            // StartSaveExcel
            // 
            this.StartSaveExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StartSaveExcel.ForeColor = System.Drawing.Color.DarkGreen;
            this.StartSaveExcel.Location = new System.Drawing.Point(869, 625);
            this.StartSaveExcel.Name = "StartSaveExcel";
            this.StartSaveExcel.Size = new System.Drawing.Size(120, 26);
            this.StartSaveExcel.TabIndex = 130;
            this.StartSaveExcel.Text = "保存列表到Excel";
            this.StartSaveExcel.UseVisualStyleBackColor = true;
            this.StartSaveExcel.Visible = false;
            this.StartSaveExcel.Click += new System.EventHandler(this.button6_Click_3);
            // 
            // MultiFunctionMode
            // 
            this.MultiFunctionMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MultiFunctionMode.ForeColor = System.Drawing.Color.DarkBlue;
            this.MultiFunctionMode.Location = new System.Drawing.Point(312, 625);
            this.MultiFunctionMode.Name = "MultiFunctionMode";
            this.MultiFunctionMode.Size = new System.Drawing.Size(133, 26);
            this.MultiFunctionMode.TabIndex = 129;
            this.MultiFunctionMode.Text = "多功能模式";
            this.MultiFunctionMode.UseVisualStyleBackColor = true;
            this.MultiFunctionMode.Visible = false;
            this.MultiFunctionMode.Click += new System.EventHandler(this.button5_Click_5);
            // 
            // Maintable
            // 
            this.Maintable.Controls.Add(this.tabScan);
            this.Maintable.Controls.Add(this.tabPageActive);
            this.Maintable.Controls.Add(this.tabPageArgs);
            this.Maintable.Controls.Add(this.page_quickstart);
            this.Maintable.Controls.Add(this.tabPage1);
            this.Maintable.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Maintable.Location = new System.Drawing.Point(307, 4);
            this.Maintable.Name = "Maintable";
            this.Maintable.SelectedIndex = 0;
            this.Maintable.Size = new System.Drawing.Size(1025, 622);
            this.Maintable.TabIndex = 97;
            this.Maintable.Visible = false;
            this.Maintable.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.Maintable.Selected += new System.Windows.Forms.TabControlEventHandler(this.Maintable_Selected);
            // 
            // page_quickstart
            // 
            this.page_quickstart.Controls.Add(this.pannel_quickstart);
            this.page_quickstart.Location = new System.Drawing.Point(4, 26);
            this.page_quickstart.Name = "page_quickstart";
            this.page_quickstart.Size = new System.Drawing.Size(1017, 592);
            this.page_quickstart.TabIndex = 12;
            this.page_quickstart.Text = "快速开始";
            this.page_quickstart.UseVisualStyleBackColor = true;
            // 
            // pannel_quickstart
            // 
            this.pannel_quickstart.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pannel_quickstart.Location = new System.Drawing.Point(3, 3);
            this.pannel_quickstart.Name = "pannel_quickstart";
            this.pannel_quickstart.Size = new System.Drawing.Size(1102, 554);
            this.pannel_quickstart.TabIndex = 0;
            this.pannel_quickstart.Paint += new System.Windows.Forms.PaintEventHandler(this.pannel_quickstart_Paint_1);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.label29);
            this.tabPage1.Controls.Add(this.label28);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.label27);
            this.tabPage1.Controls.Add(this.label26);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.progressBar4);
            this.tabPage1.Controls.Add(this.progressBar3);
            this.tabPage1.Controls.Add(this.progressBar2);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1.ForeColor = System.Drawing.Color.Navy;
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1017, 592);
            this.tabPage1.TabIndex = 13;
            this.tabPage1.Text = "天线匹配度";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button8);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(633, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(205, 145);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "天线检测";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(98, 54);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 43);
            this.button8.TabIndex = 3;
            this.button8.Text = "设置";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click_3);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(22, 92);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(51, 19);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "关闭";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(22, 35);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(51, 19);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "开启";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(71, 213);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(0, 15);
            this.label29.TabIndex = 21;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(70, 165);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(0, 15);
            this.label28.TabIndex = 20;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(70, 103);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(0, 15);
            this.label21.TabIndex = 19;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(70, 36);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(0, 15);
            this.label19.TabIndex = 18;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(454, 213);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(0, 15);
            this.label27.TabIndex = 17;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(454, 158);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(0, 15);
            this.label26.TabIndex = 16;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(454, 99);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(0, 15);
            this.label24.TabIndex = 15;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(454, 35);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(0, 15);
            this.label23.TabIndex = 14;
            // 
            // progressBar4
            // 
            this.progressBar4.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar4.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.progressBar4.Location = new System.Drawing.Point(138, 207);
            this.progressBar4.Name = "progressBar4";
            this.progressBar4.Size = new System.Drawing.Size(292, 25);
            this.progressBar4.TabIndex = 13;
            // 
            // progressBar3
            // 
            this.progressBar3.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar3.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.progressBar3.Location = new System.Drawing.Point(138, 158);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(292, 25);
            this.progressBar3.TabIndex = 12;
            // 
            // progressBar2
            // 
            this.progressBar2.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar2.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.progressBar2.Location = new System.Drawing.Point(138, 99);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(292, 25);
            this.progressBar2.TabIndex = 11;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(23, 213);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(45, 15);
            this.label22.TabIndex = 10;
            this.label22.Text = "天线4:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(22, 158);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(45, 15);
            this.label18.TabIndex = 9;
            this.label18.Text = "天线3:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(22, 99);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 15);
            this.label17.TabIndex = 8;
            this.label17.Text = "天线2:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(22, 35);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 15);
            this.label16.TabIndex = 7;
            this.label16.Text = "天线1:";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(936, 7);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 25);
            this.button6.TabIndex = 6;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click_5);
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar1.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.progressBar1.Location = new System.Drawing.Point(138, 31);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(292, 25);
            this.progressBar1.TabIndex = 5;
            // 
            // timerMonitor
            // 
            this.timerMonitor.Interval = 1000;
            this.timerMonitor.Tick += new System.EventHandler(this.timerMonitor_Tick);
            // 
            // timerIDMonitor
            // 
            this.timerIDMonitor.Interval = 1000;
            this.timerIDMonitor.Tick += new System.EventHandler(this.timerIDMonitor_Tick);
            // 
            // timerMessage
            // 
            this.timerMessage.Interval = 1000;
            this.timerMessage.Tick += new System.EventHandler(this.timerMessage_Tick);
            // 
            // sourceDataSave
            // 
            this.sourceDataSave.Interval = 2000;
            this.sourceDataSave.Tick += new System.EventHandler(this.sourceDataSave_Tick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.Control;
            this.label13.Location = new System.Drawing.Point(1149, 632);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 13);
            this.label13.TabIndex = 133;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SrDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1344, 739);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.MultiFunctionMode);
            this.Controls.Add(this.sourceDataSaveBt);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.StartSaveExcel);
            this.Controls.Add(this.currentDev_l);
            this.Controls.Add(this.Maintable);
            this.Controls.Add(this.listView_oper_log);
            this.Controls.Add(this.groupBox_multidevice);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1350, 765);
            this.Name = "SrDemo";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sanray UHF+2.4G ReaderManagementV2.0.3";
            this.Load += new System.EventHandler(this.SrDemo_Load);
            this.groupBox_multidevice.ResumeLayout(false);
            this.groupBox_multidevice.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPageArgs.ResumeLayout(false);
            this.tabPageActive.ResumeLayout(false);
            this.tabPageActive.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabScan.ResumeLayout(false);
            this.tabScan.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.AdvanceGroup.ResumeLayout(false);
            this.AdvanceGroup.PerformLayout();
            this.Maintable.ResumeLayout(false);
            this.page_quickstart.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.ListView listView_oper_log;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Timer timer_scan;
        private System.Windows.Forms.Timer timer_md_query_Tick;
        //  private System.Windows.Forms.ListView listView_label;
        private GroupBox groupBox_multidevice;
        private ListView listView_md_addr;
        private TextBox reader_port_tb;
        private Label label6;
        private Label label5;
        private Button connect_b;
        private Label currentDev_l;
        private Label label20;
        private Button refresh_b;
        private Button PortOpen_b;
        private Button button9;
        private Timer keepalive;
        private Button button12;
        private ComboBox comboBox7;
        private ToolStripMenuItem 文件ToolStripMenuItem;
        private ToolStripMenuItem 编辑ToolStripMenuItem;
        private ToolStripMenuItem 帮助ToolStripMenuItem;
        private ToolStripMenuItem 配置ToolStripMenuItem;
        private ToolStripMenuItem 数据库ToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 功能ToolStripMenuItem;
        private ToolStripMenuItem 文件管理ToolStripMenuItem;
        private ToolStripMenuItem 人员管理ToolStripMenuItem;
        private Timer show_EPC_t;
        private Timer TimerShowID;
        private ToolStripMenuItem 系统功能配置ToolStripMenuItem;
        private ToolStripMenuItem mQTTToolStripMenuItem;
        private TabPage tabPageArgs;
        private TreeView treeView1;
        private TabPage tabPageActive;
        private Button button4;
        private Button button3;
        private Button button2;
        private Label label10;
        private ComboBox comboBoxshowIDType;
        private Label label4;
        private Label LabelIDTime;
        private Label label3;
        private Label LabelIDSpeed;
        private Label label9;
        private Label LabelIDCounts;
        private Label label11;
        private ColumnHeader ItemNum;
        private ColumnHeader ItemID;
        private ColumnHeader ItemDev;
        private ColumnHeader ItemTem;
        private ColumnHeader ItemRemove;
        private ColumnHeader ItemRSSI;
        private ColumnHeader ItemPower;
        private ColumnHeader ItemBattery;
        private ColumnHeader ItemCount;
        private ColumnHeader ItemTime;
        private ColumnHeader columnHeader1;
        private TabPage tabScan;
        private Label label2;
        private Button button_time_fliecabinet;
        private TextBox Text_time_fliecabinet;
        private ComboBox ComboBoxShowStyle;
        private CheckBox singleEPC_rb;
        private CheckBox allreader_cb;
        private ColumnHeader Num;
        private ColumnHeader AntID;
        private ColumnHeader EPC;
        private ColumnHeader PC;
        private ColumnHeader RSSI;
        private ColumnHeader Count;
        private ColumnHeader issame;
        private ColumnHeader DevID;
        private ColumnHeader LastTime;
        private ColumnHeader Dir;
        private Label LabelCurrentTimes;
        private Label LabelCurrentTime;
        private Label label8;
        private Label label7;
        private Label label26_total;
        private Label label25;
        private Button button_md_clear;
        private Button button_md_stop;
        private Button button_md_start;
        private TabControl Maintable;
        private Button buttonStartMonitor;
        private Timer timerMonitor;
        private Button buttonStartIDMonitor;
        private Timer timerIDMonitor;
        private Label label12;
        private Label labelReaderReportEpcCounts;
        private Timer timerMessage;
        private FlowLayoutPanel panel11;
        private Button testbtn;
        private CheckBox SelectAntcheckBox4;
        private CheckBox SelectAntcheckBox2;
        private CheckBox SelectAntcheckBox3;
        private CheckBox SelectAntcheckBox1;
        private ColumnHeader TID;
        private RadioButton radioButtonMachineTest;
        private RadioButton radioButtonModuleTest;
        private CheckBox NoAnt;
        private Label labletest;
        private Label label14;
        private TabPage page_quickstart;
        private Button MultiFunctionMode;
        private FlowLayoutPanel pannel_quickstart;
        private TextBox fd;
        private Button StartSaveExcel;
        private Button sourceDataSaveBt;
        private Timer sourceDataSave;
        private CheckBox FilterCheckBox;
        private Label label1;
        private GroupBox AdvanceGroup;
        private Button AntSetbutton;
        private Label label13;
        private ComboBox comboBox1;
        private Panel panel1;
        private GroupBox groupBox1;
        private Label label104;
        private TextBox recv_tb;
        private Label label100;
        private Button button31;
        private Button button32;
        private Timer timer1;
        private Label label103;
        private TextBox channel_tb;
        private Label label99;
        private Label label102;
        private TextBox tagtype_tb;
        private CheckBox IsAutocheckBox;
        private CheckBox checkBox1;
        private Label label15;
        private Button button5;
        private Button button1;
        private TabPage tabPage1;
        private SrDemo.ListViewNF listView_md_epc;
        private SrDemo.ListViewNF ListViewID;
        private ProgressBar progressBar1;
        private Button button6;
        private ProgressBar progressBar4;
        private ProgressBar progressBar3;
        private ProgressBar progressBar2;
        private Label label22;
        private Label label18;
        private Label label17;
        private Label label16;
        private Label label27;
        private Label label26;
        private Label label24;
        private Label label23;
        private Label label29;
        private Label label28;
        private Label label21;
        private Label label19;
        private GroupBox groupBox2;
        private Button button8;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private CheckBox checkBox2;
        private Button button7;

        //111        private SrDemo.SrDemo.ListViewNF listView_md_epc;
    }
}

