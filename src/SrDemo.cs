//#define ENGLISH
//#define Test

#define CN

//#define Module

#define NoYuan


using System;
using System.ComponentModel;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;             //thread
using System.IO.Ports;              //SerialPort
using System.Net;
using System.Net.Sockets;
using NetFrame.Net.TCP.Sock.Asynchronous;
using System.Resources;
using System.Globalization;
using System.Configuration;
using SrDemo.Config;
using RankOrStatisticDatum;
using Currency.ADO.DataBaseOperation;
using SrDemo.Business;
using SrDemo.Log;
using System.Timers;
using SrDemo.Business;
using System.IO;
using System.Text;
using System.Drawing.Text;
using System.Linq;
using Newtonsoft.Json;
using TrackPerson.DAL;
using TrackPerson.DAL.Entities;


namespace SrDemo
{

    //声明页面左边时间和速度Timer控件的委托
    //public delegate void UpdateTextDelegate()

    public partial class SrDemo : Form
    {
        //将控件属性通过控制器Controllor与model绑定起来
        //当model的值改变时，控件对应的属性会发生改变，当控件的值改变时，对应的model属性值发生改变
        //同时出发属性值改变事件  PropertyChanged

        public Reader ReaderControllor = new Reader();
        //    private Clients Clients;
        private const int OPER_OK = 0;          // 表示sr api函数是否成功执行
        private int m_connect_type = 0;
        private const int READ_FLAG = 1;
        private const int WRITE_FLAG = 2;

        //  private volatile List<tag> tags_list = new List<tag>(1000);
        //   private volatile List<tag_mc> md_epc_list = new List<tag_mc>(1000);
        //private volatile List<_epc_t> epcs_list = new List<_epc_t>(1000);
        private volatile List<string[]> epcstr_list = new List<string[]>(1000);
        private volatile List<string[]> IDtr_list = new List<string[]>(1000);
        private volatile List<string[]> sourceEpcStrList = new List<string[]>(1000);
        private int tags_count_persecond = 0;
        private volatile List<string[]> checkEpcList = new List<string[]>(1000);

        private volatile List<string[]> lastEpcStrList = new List<string[]>(1000);

        private volatile List<string[]> QJCS = new List<string[]>(1000);

        List<AsyncSocketState> clients;           //客户端信息

        //List<ListViewItem> listView_md_addrDatabase = new List<ListViewItem>();
        // 标签显示项
        private const int listView_label_Num = 0;
        private const int listView_label_AntID = 1;
        private const int listView_label_EPC = 2;
        private const int listView_label_TID = 3;
        private const int listView_label_PC = 4;
        private const int listView_label_RSSI = 5;
        private const int listView_label_Count = 6;
        private const int listView_label_Last_Time = 7;

        SynchronizationContext m_SyncContext = null;

        public static string WorkState = "正常状态";

        private const int listView_md_State = 3;

        //多设备标签显示项
        private const int listView_md_epc_Num = 0;
        private const int listView_md_epc_AntID = 1;
        private const int listView_md_epc_EPC = 2;
        private const int listView_md_epc_PC = 3;
        private const int listView_md_epc_Rssi = 4;
        private const int listView_md_epc_Count = 5;
        private const int listView_md_epc_DevID = 6;
        private const int listView_md_epc_Last_Time = 7;
        private const int listView_md_epc_Direction = 8;
        private const int listView_md_epc_Temp = 9;
        private const int listView_md_epc_TID = 10;
        // 网络模块显示项
        private const int listView_net_Num = 0;
        private const int listView_net_MAC = 1;
        private const int listView_net_IP = 2;


        //多设备标签显示项
        private const int listView_Num = 0;
        private const int listView_ID = 1;
        private const int listView_dev = 2;
        private const int listView_tem = 3;
        private const int listView_remove = 4;
        private const int listView_RSSI = 5;
        private const int listView_power = 6;
        private const int listView_battery = 7;
        private const int listView_md_id_Count = 8;
        private const int listView_md_id_Last_Time = 9;


        public static string path;
        PrivateFontCollection pfc = new PrivateFontCollection();  // LED字体

        MySorter mySorter = new MySorter();   //ListView排序

        // ListView虚拟模式缓冲 [无源]
        protected List<ListViewItem> ItemsSource
        {
            get;
            private set;
        }

        protected List<ListViewItem> CurrentCacheItemsSource
        {
            get;
            private set;
        }

        // ListView虚拟模式缓冲  [有源]
        protected List<ListViewItem> ItemsSource_ID
        {
            get;
            private set;
        }

        protected List<ListViewItem> CurrentCacheItemsSource_ID
        {
            get;
            private set;
        }

        private TrackingDAL _trackingDal = new TrackingDAL();
        private TrackingClientDAL _trackingClientDal = new TrackingClientDAL();
        private List<TrackingClient> _clientConnecteds = new List<TrackingClient>();
        public SrDemo()
        {
            InitializeComponent();

            InintManagement();           //初始化为超高频设备操作界面    取消

            this.ItemsSource = new List<ListViewItem>();
            this.CurrentCacheItemsSource = new List<ListViewItem>();

            this.ItemsSource_ID = new List<ListViewItem>();
            this.CurrentCacheItemsSource_ID = new List<ListViewItem>();

            LoadListViewItems(this.CurrentCacheItemsSource);

            LoadListViewItems_ID(this.CurrentCacheItemsSource_ID);


            string HostName = Dns.GetHostName(); //得到主机名
            IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
            for (int i = 0; i < IpEntry.AddressList.Length; i++)
            {
                //从IP地址列表中筛选出IPv4类型的IP地址
                //AddressFamily.InterNetwork表示此IP为IPv4,
                //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    this.comboBox1.Items.Add(IpEntry.AddressList[i].ToString());
                }
            }
            if (this.comboBox1.Items.Count == 0)
            {
                this.comboBox1.Items.Clear();
                this.comboBox1.Text = "192.168.1.168";
            }
            else
            {
                this.comboBox1.SelectedIndex = 0;
            }

            label13.Text = "SDK 版本:" + ReaderControllor.Get_SDK();



           string QQ = Application.StartupPath.ToString();

           path = QQ + "\\LcdD.ttf";
          
           pfc.AddFontFile(path);
           //实例化字体             
           Font f = new Font(pfc.Families[0], 25, FontStyle.Bold);
          
            //设置字体 ------无源界面           
           label26_total.Font = f;
           label8.Font = f;
           LabelCurrentTimes.Font = f;
            // 有源界面
           LabelIDTime.Font = f;
           LabelIDCounts.Font = f;
           LabelIDSpeed.Font = f;
          // labelReaderReportEpcCounts.Font = f;
          // LabelCurrentTimes.Font = f;

            //  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //  this.Font = new System.Drawing.Font("Microsoft Sans Serif", AdjustResolution(), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));  
            //操作 log
            this.listView_oper_log.Columns.Add("序号", 80, HorizontalAlignment.Left);//Num
            this.listView_oper_log.Columns.Add("时间", 150, HorizontalAlignment.Left);//Time
            this.listView_oper_log.Columns.Add("执行结果", 900, HorizontalAlignment.Left);//Operation Result
            this.listView_oper_log.GridLines = true;
            this.listView_oper_log.FullRowSelect = true;
            this.listView_oper_log.MultiSelect = false;


            this.listView_md_addr.Columns.Add("No", 28, HorizontalAlignment.Left);
            this.listView_md_addr.Columns.Add("IP", 93, HorizontalAlignment.Left);
            this.listView_md_addr.Columns.Add("Port",42, HorizontalAlignment.Left);
            this.listView_md_addr.Columns.Add("DeviceID", 90, HorizontalAlignment.Left);
            this.listView_md_addr.Columns.Add("Sta",35, HorizontalAlignment.Left);
            this.listView_md_addr.GridLines = true;
            this.listView_md_addr.FullRowSelect = true;
            this.listView_md_addr.MultiSelect = false;
          


            Control.CheckForIllegalCrossThreadCalls = false;
            m_SyncContext = SynchronizationContext.Current;


            timer_scan.Enabled = true;

           
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CN");
            UpDataMainFormUILanguage();

            ReaderControllor.cmd.MultiEPC_Event += ShowEPC;

            // 乔佳 2018-7-26 整机模块事件触发函数
            ReaderControllor.cmd.AllModule_Event += new InformHandle(this.AllModule); // 整机
            ReaderControllor.cmd.Module_Event += new InformHandle(this.Module);    // 模块
            // 乔佳 2018-11-1 存储过滤触发函数
            ReaderControllor.cmd.StrogeFilter_Event += new InformHandle(this.StrogeFilter);    // 模块

            WorkMode.AutoReadTags_Event += new InformHandleWorkMode(this.StartTimer);  

            treeView1.ExpandAll();

            string[] names = SerialPort.GetPortNames();
            foreach (string name in names)
            {
                comboBox7.Items.Add(name);
                comboBox7.SelectedIndex = 0;
            }

            timerTest.Elapsed += new System.Timers.ElapsedEventHandler(timerTestclick);

            //       this.tabPage7.Parent = null;

            UpdateDisplayStyleBox();
                //            this.page_quickstart.Parent = Maintable;
                //            tabPageArgs.Parent = null;
                this.page_quickstart.Parent = null;
#if ENGLISH
            this.Text = "UHF+2.4G ReaderManagementV2.0.3";
            Text_time_fliecabinet.Text = "1000";
            button12_Click_1(button12, new EventArgs());
            button_time_fliecabinet_Click(button_time_fliecabinet, new EventArgs());
           // MultiFunctionMode.Visible = false;
           // buttonStartIDMonitor.Visible = false;
#endif
#if !Test
            treeView1.Nodes[2].Remove();
#endif

#if NoYuan
                Maintable.Visible = true;
                MultiFunctionMode.Visible = true;
                label25.Visible = true;
                label26_total.Visible = true;
                LabelCurrentTime.Visible = true;
                LabelCurrentTimes.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label2.Visible = true;
#endif
                Maintable.TabPages[3].Parent = null;//隐藏天线匹配度


                //LoadlistView_md_addr();
        }

        private async void LoadlistView_md_addr()
        {
            var trackingClients = new List<TrackingClient>();
            if (_clientConnecteds.Any() == false)
            {
                trackingClients = await _trackingClientDal.GetAllClients();
            }

            foreach (var trackingClient in trackingClients)
            {
                try
                {
                    IPAddress ipaddress = IPAddress.Parse(trackingClient.ClientIP);
                    if (ReaderControllor.ServerStart(ipaddress, trackingClient.Port))
                    {
                        connect_b.Text = stop;
                        serverisstart = true;
                        keepalive.Enabled = true;               //模块循环读取EPC时发送查询数据会使模块停止工作
                        if ((serialisstart || serverisstart) && ((_IsActiveDatabaseWork) || (_IsRfidDatabaseWork) || (_IsCommandDatabaseWork)))
                        {
                            timer_md_query_Tick.Enabled = true;
                        }
                        TimerShowID.Enabled = true;
                        show_EPC_t.Enabled = true;

                        UpdateLog(creatserver + success);
                        if (isLogOpen)
                        {
                            EventLog.WriteEvent(creatserver + success, null);
                        }
                    }

                    _clientConnecteds.Add(trackingClient);
                    //var listViewItem = new ListViewItem(index.ToString());
                    ////listViewItem.Text = trackingClient.Id.ToString();
                    //listViewItem.SubItems.Add(trackingClient.ClientNo);
                    //listViewItem.SubItems.Add(trackingClient.ClientIP);
                    //listViewItem.SubItems.Add(trackingClient.Port.ToString());
                    //listViewItem.SubItems.Add(trackingClient.DeviceID);
                    //listViewItem.SubItems.Add(trackingClient.Status);
                    //listView_md_addrDatabase.Add(listViewItem);
                    //index++;
                }
                catch (Exception ex)
                {
                    UpdateLog(Invalid);
                    if (isLogOpen)
                        ErrorLog.WriteError(Invalid);
                }
                Thread.Sleep(2000);
            }
        }

        //设置listview属性和虚拟模式事件   [无源]
        private void LoadListViewItems(List<ListViewItem> items)
        {

            listView_md_epc.VirtualListSize = items.Count;
            listView_md_epc.VirtualMode = true;
            listView_md_epc.RetrieveVirtualItem += new RetrieveVirtualItemEventHandler(listView_RetrieveVirtualItem);

        }

        void listView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (this.CurrentCacheItemsSource == null || this.CurrentCacheItemsSource.Count == 0)
            {
                return;
            }

            e.Item = this.CurrentCacheItemsSource[e.ItemIndex];
            if (e.ItemIndex == this.CurrentCacheItemsSource.Count)
            {
                this.CurrentCacheItemsSource = null;
            }
        }


        //设置listview属性和虚拟模式事件  [有源]
        private void LoadListViewItems_ID(List<ListViewItem> items)
        {

            ListViewID.VirtualListSize = items.Count;
            ListViewID.VirtualMode = true;
            ListViewID.RetrieveVirtualItem += new RetrieveVirtualItemEventHandler(listView_RetrieveVirtualItem_ID);

        }

        void listView_RetrieveVirtualItem_ID(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (this.CurrentCacheItemsSource_ID == null || this.CurrentCacheItemsSource_ID.Count == 0)
            {
                return;
            }

            e.Item = this.CurrentCacheItemsSource_ID[e.ItemIndex];
            if (e.ItemIndex == this.CurrentCacheItemsSource_ID.Count)
            {
                this.CurrentCacheItemsSource_ID = null;
            }
        }


        public void StrogeFilter(object sender, EventArgs e)
        {
            listView_md_epc.VirtualListSize = 0;
            this.ItemsSource.Clear();
            this.CurrentCacheItemsSource.Clear();
            this.Refresh();

            epcstr_list.Clear();
            listView_md_epc.Items.Clear();
            EpctotalnumBack = 0;
            label26_total.Text = "0";
            if (!isRFIDTimerStart) LabelCurrentTimes.Text = "0";
            label8.Text = "0";
        }



        // 乔佳 2018-7-26 整机模块事件所触发函数
        public void AllModule(object sender, EventArgs e)
        {
            this.radioButtonMachineTest.Checked = true;
        }

        public void Module(object sender, EventArgs e)
        {
            this.radioButtonModuleTest.Checked = true;
        }



        // 无源设置完自动模式后立即开始计时
        public void StartTimer(object sender, EventArgs e)
        {
            if (IsHaveYuan == false)      // 无源
            {

                Last_Num = NNNum = 0;

                LabelCurrentTimes.Text = "0";
                MonitorTime = 0;
                button_md_clear_Click(sender, (EventArgs)e);
                // button_md_stop_Click(sender, (EventArgs)e);
                SetMode = 0;
                timerMonitor.Enabled = false;
                timerMonitor.Stop();

                if (DataMark == true && IsStart == false)
                {
                    DataMark = false;

                    if (timerMonitor.Enabled == false)
                    {
                        this.Invoke(new Action(() =>
                        {
                            timerMonitor.Enabled = true;
                            timerMonitor.Start();
                        }));

                    }
                }
            }

            else        // 有源
            {
                Last_IDNum = HaveYuanSpeed = 0;

                button4_Click_1(sender, (EventArgs)e);
                button2_Click_1(sender, (EventArgs)e);
                buttonStartIDMonitor.Text = "开始计时";
                MonitorTime = 1;


                if (TimerShowID.Enabled == false)
                {
                    this.Invoke(new Action(() =>
                    {
                        TimerShowID.Enabled = true;
                        TimerShowID.Start();
                    }));
                }


                if (timerIDMonitor.Enabled == false)
                {
                    this.Invoke(new Action(() =>
                   {
                        timerIDMonitor.Enabled = true;
                        timerIDMonitor.Start();
                   }));
                }



            }

        }




            public void UpdateDisplayStyleBox()
        {
            ComboBoxShowStyle.Items.Clear();
            ComboBoxShowStyle.Items.Add(SpecialDisplay);
            ComboBoxShowStyle.Items.Add(TimingDisplay);
            ComboBoxShowStyle.Items.Add(TriggerDisplay);
            ComboBoxShowStyle.Items.Add(CumulativeDisplay);
            ComboBoxShowStyle.Items.Add(ChannelGate);
           // ComboBoxShowStyle.SelectedIndex = 3;
        }

        private float AdjustResolution()
        {
            int SW = Screen.PrimaryScreen.Bounds.Width;
            float size = 11F;
            if (SW != 1920)
            {
                size = (float)((SW / 1920) * 11);
            }
            return size;
        }

        public static string ExportToExcel(System.Data.DataTable dt, string path)
        {
            string result = string.Empty;
            System.IO.StreamWriter sw = new System.IO.StreamWriter(path, false, System.Text.Encoding.GetEncoding("gb2312"));

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int k = 0; k < dt.Columns.Count; k++)
            {
                // 添加列名称  
                sb.Append(dt.Columns[k].ColumnName.ToString() + "\t");
            }
            sb.Append(Environment.NewLine);
            // 添加行数据  
            for (int q = 0; q < dt.Rows.Count; q++)
            {
                DataRow row = dt.Rows[q];
                for (int w = 0; w < dt.Columns.Count; w++)
                {
                    // 根据列数追加行数据  
                    sb.Append(row[w].ToString() + "\t");
                }
                sb.Append(Environment.NewLine);
            }
            sw.Write(sb.ToString());
            sw.Flush();
            sw.Close();
            sw.Dispose();
            return result;       
        }


        string dev_version = "";

        byte[] testproto;
        int DEVIDCount = 0;
        string COM_DevID = "";
        public static bool DataMark = false; // 接到响应数据标志

        public static int SetMode = 0; // 设置工作模式清除变量
        public static bool IsAutoMode = false; // 自动模式变量

        long HaveYuanSpeed = 0;
        //根据不同的工作模式EPC处理方式
        public void ShowEPC(object sender, Command.ShowEPCEventArgs e)
        {
            //  UpdateLog(e.CommandRespond);
            //  string[] result = e.CommandRespond.Split(',');  
            string[] result = (e.CommandRespond + "," + flag).Split(',');           //每条命令后面加一个flag  用于循环盘存EPC显示
            byte type = Convert.ToByte(result[1], 16);
            switch (type)
            {
                case Types.START_MULTI_EPC_RESPOND:
                case Types.START_SINGLE_EPC_RESPOND:
                    if (isSourceDataSave)
                    {
                        GetSourceData(result);
                        UpdateMultiEPC(result); // 开始保存原始数据
                        NNNum = NNNum + 1;     // 记录每秒读标速度
                        if (IsTagDoor == true)
                        {updatedoor();
                        }
                    }
                    else
                    {
                       UpdateMultiEPC(result);
                       NNNum = NNNum + 1;
                       if (IsTagDoor == true)
                       {
                           updatedoor();
                       }
                    }
                    dev_version = "97";
                    break;
                case Types.START_Temp_EPC:
                    UpdateMultiEPC(result);
                    NNNum = NNNum + 1;
                    break;
                case Types.AntPercentage:
                    GetAntCompatibility(result);
                    break;

                case Types.GET_MULTI_ID:                  //2.4G
                    UpdateMultiID(result);
                    HaveYuanSpeed = HaveYuanSpeed + 1;
                    dev_version = "F1";
                    break;
                case Types.STOP_MULTI_EPC_RESPOND:
                    UpdateSetParameters(result, multiepc);
                    break;
                case Types.GET_ACCESS_DIR_RESPOND:
                    UpdateAccessDir(result);
                    break;
                case Types.SET_POWER_RESPOND:
                    UpdateSetParameters(result, Power);
                    break;
                case Types.SET_GPIO_RESPOND:
                    UpdateSetParameters(result, Gpio);
                    break;
                case Types.SET_GEN2_RESPOND:
                    UpdateSetParameters(result, GEN2);
                    break;
                case Types.SET_WORK_ANT_RESPOND:
                    UpdateSetParameters(result, Workant);
                    break;
                case Types.SET_FREQUENCY_AREA_RESPOND:
                    UpdateSetParameters(result, fRequency);
                    break;
                case Types.SET_FASTID_RESPOND:
                    UpdateSetParameters(result, "FastID");
                    break;
                case Types.SET_QT_RESPOND:
                    UpdateSetQT(result);
                    break;
                case Types.SET_COMMUNICATION_INFO_RESPOND:
                    UpdateSetParameters(result, CommunicationInfo);
                    break;
                case Types.SET_CARRIER_RESPOND:
                    UpdateSetParameters(result, "Carrier");
                    break;
                case Types.SET_TAGFOCUS_RESPOND:
                    UpdateSetParameters(result, "Tagfocus");
                    break;
                case Types.SET_MAC_ADD_RESPOND:
                    UpdateSetParameters(result, "MAC");
                    break;
                case Types.SET_SIM_RESPOND:
                    UpdateSetParameters(result, "4G");
                    break;
                case Types.SET_WIFI_RESPOND:
                    UpdateSetParameters(result, "wifi");
                    break;
                case Types.SET_WORK_MODE_RESPOND:
                    UpdateSetParameters(result, Workmode);
                    break;
                case Types.SET_RF_LINK_RESPOND:
                    UpdateSetParameters(result, "RF-Link");
                    break;
                case Types.SET_MQTT_RESPOND:
                    UpdateSetParameters(result, "MQTT");
                    break;
                case Types.SET_MQTT_THEME_RESPOND:
                    UpdateSetParameters(result, "MQTT Theme");
                    break;
                case Types.SET_EPC_RESPOND:
                    UpdateSetParameters(result, "EPC对比");
                    break;
                case Types.GET_FREQUENCY_POINT_RESPOND:
                    UpdateFrequencyPiont(result);
                    break;
                case Types.DOWN_DATA_RESPOND:
                    UpdateDownData(result);
                    GetHaveYuanData(result);
                    break;
                case Types.GET_FREQUENCY_AREA_RESPOND:
                    UpdateFrequencyArea(result);
                    break;
                case Types.GET_TEMPERATURE_RESPOND:
                    UpdateTemperature(result);
                    break;
                case Types.GET_GPIO_RESPOND:
                    UpdateGPIO(result);
                    break;
                case Types.GET_GEN2_RESPPOND:
                    UpdateGen2(result);
                    break;
                case Types.GET_HARD_VERSION_RESPOND:
                    UpdateHardVersion(result);
                    break;
                case Types.GET_FIRM_VERSION_RESPOND:
                    UpdateFirmVersion(result);
                    // 20180820 乔佳 上电区分有源无源
                    if (IsMoudleBB == false)
                    {
                        HaveYuanNoYuan(result);
                    }
                    break;
                case Types.GET_POWER_RESPOND:
                    if (result[3] == "9")
                    {
                        UpdatePower_Four(result);
                    }
                    else
                    {
                        UpdatePower(result);
                    }
                    break;
                case Types.GET_EAT:
                    UpdateEAT(result);
                    break;
                case Types.SET_EAT:
                    SET_EAT(result, "EPCAndTID");
                    break;
                case Types.GET_GPS:
                    UpdateMap(result);
                    break;
                case Types.GET_WORK_ANT_RESPOND:
                    UpdateWorkAnt(result);
                    break;
                case Types.GET_CARRIER_RESPOND:
                    UpdateCarrier(result);
                    break;
                case Types.READ_TAGS_RESPOND:
                    UpdateReadTags(result);
                    break;
                case Types.WRITE_TAGS_RESPOND:
                    UpdateWriteTags(result);
                    break;
                case Types.LOCK_TAGS_RESPOND:
                    UpdateLockTags(result);
                    break;
                case Types.KILL_TAGS_RESPOND:
                    UpdateKillTags(result);
                    break;
                case Types.GET_WORK_INTERRUPTED_RESPOND:
                    UpdateWorkInterrupted(result);
                    break;
                case Types.SET_WORK_TIME_RESPOND:
                    UpdateSetParameters(result, Worktime);
                    break;
                case Types.GET_WORK_TIME_RESPOND:
                    UpdateWorkTime(result);
                    break;
                case Types.GET_FASTID_RESPOND:
                    UpdateFastID(result);
                    break;
                case Types.GET_RF_LINK_RESPOND:
                    UpdateRFLinkl(result);
                    break;
                case Types.GET_QT_RESPOND:
                    UpdateQT(result);
                    break;
                case Types.GET_TAGFOCUS_RESPOND:
                    UpdateTagfocus(result);
                    break;
                case Types.GET_WORK_MODE_RESPOND:
                    UpdateWorkMode(result);
                    break;
                case Types.GET_COMMUNICATION_INFO_RESPOND:
                    UpdateComInfo(result);
                    break;
                case Types.GET_MAC_ADD_RESPOND:

                      COM_DevID = PrivateStringFormat.shortTolongNum(result[4]);

                                string bz_str = "";
                                if (COM_DevID.Length < 15)
                                {
                                    int bz_len = 15 - COM_DevID.Length;

                                    for (int i = 0; i < bz_len; i++)
                                    {
                                        bz_str += "0";
                                    }

                                    COM_DevID = COM_DevID.Substring(0, 2) + bz_str + COM_DevID.Substring(2, 11);
                                }

                    //if (DEVIDCount == 0)
                    //{
                    //    COM_DevID = PrivateStringFormat.shortTolongNum(result[4]); ;
                    //    DEVIDCount++;
                    //}
                    //else
                    //{
                        UpdateLBM(result); // 乔佳 2018-7-27 网络参数页面获取长编码
                        UpdateMac(result);
                   // }
                    break;
                case Types.GET_SIM_RESPOND:
                    UpdateSIM(result);
                    break;
                case Types.GET_WIFI_RESPOND:
                    UpdateWifi(result);
                    break;
                case Types.GET_MQTT_RESPOND:
                    UpdateMQTT(result);
                    break;
                case Types.GET_MQTT_THEME_RESPOND:
                    UpdateMQTTheme(result);
                    break;
                case Types.GET_EPC_RESPOND:
                    UpdateWorkModeEPC(result);
                    break;
                case Types.SET_MODULE_VERSION_9200_RESPOND:
                    UpdateSetModuleVersion_9200(result);
                    break;
                case Types.GET_MODULE_VERSION_9200_RESPOND:
                    UpdateModuleVersion_9200(result);
                    break;
                case Types.Storage_Dev_Send:
                    if (result[3] == "8")
                    {
                        UpdateBatchTag(result);
                    }
                    else if (result[3] == "6")
                    {
                        UpdateWriteBatchTag(result);
                    }
                    break;
                default:
                    break;
            }
            //  db.InsertCommand(result);
            /*   if (Clients != null)
               {
                   Clients.GetReaderRespond(result);
               }*/
            if (SetMode == 1)        // 设置工作模式后清零 标签总数，时间，速度
            {
                if (IsHaveYuan == false)      // 无源
                {
                    Last_Num = NNNum = 0;   // 速度清零

                    LabelCurrentTimes.Text = "0";
                    MonitorTime = 0;
                    button_md_clear_Click(sender, (EventArgs)e);
                    button_md_stop_Click(sender, (EventArgs)e);

                }

                else    // 有源 
                {

                    if (IsAutoMode == false)  //设置功率判断当前是否为自动模式
                    {

                        button4_Click_1(sender, (EventArgs)e);
                        button2_Click_1(sender, (EventArgs)e);

                        LabelIDTime.Text = "0";

                        Last_IDNum = HaveYuanSpeed = 0;    // 速度清零

                        if (timerIDMonitor.Enabled == true)
                        {
                            this.Invoke(new Action(() =>
                            {
                                timerIDMonitor.Enabled = false;
                                timerIDMonitor.Stop();
                            }));

                        }
                    }

                    else
                    {
                        button2_Click_1(sender, (EventArgs)e);

                        LabelIDTime.Text = "0";

                        MonitorTime = 0;
                        Last_IDNum = HaveYuanSpeed = 0;    // 速度清零

                    }

                }

                SetMode = 0;
            }
        }











        string LastAction = "End";

        private void UpdateAccessDir(string[] result)
        {
#if CN
            LabelCurrentTime.Text = "方      向";
#endif

#if ENGLISH
             LabelCurrentTime.Text = "Direction";
#endif
            label26_total.Text = result[5];
            if (result[3] == "170")
            {
#if CN
                LabelCurrentTimes.Text = "进入";
#endif

#if ENGLISH
                LabelCurrentTimes.Text = "In";
#endif
                
            }
            else if (result[3] == "85")
            {
#if CN
                LabelCurrentTimes.Text = "出去";
#endif

#if ENGLISH
                LabelCurrentTimes.Text = "Out";
#endif
              
            }

            if (result[4] == "1" && LastAction == "Start")
            {
                IsTagDoor = false;
                LastAction = "End";
                label26_total.Text = result[5];
                m_SyncContext.Post(UpdateAccessDoorEPC, result);
            }
            else
            {
                listView_md_epc.VirtualListSize = 0;

                this.ItemsSource.Clear();
                this.CurrentCacheItemsSource.Clear();
                this.Refresh();

                targedoorDev = result[0];
                IsTagDoor = true;
                LastAction = "Start";
            }

        }

        bool IsTagDoor = false;

        string targedoorDev ="";

        private void UpdateAccessDoorEPC(object state)
        {
           // this.listView_md_epc.BeginUpdate();

            string[] targeDoor = (string[])state;
         
            //listView_md_epc.VirtualListSize = 0;

            //this.ItemsSource.Clear();
            //this.CurrentCacheItemsSource.Clear();
            //this.Refresh();

            string time = DateTime.Now.ToString();
            string ListDeviceIdstr;
            lock (epcstr_list)
            {
                for (int index = 0; index < epcstr_list.Count; index++)
                {
                    if (targeDoor[0] == epcstr_list[index][0])
                    {

                        try
                        {
                            if ((CurrentCacheItemsSource[index].SubItems[2].Text == epcstr_list[index][5]) && (CurrentCacheItemsSource[index].SubItems[6].Text == PrivateStringFormat.shortTolongNum(epcstr_list[index][0])))
                            {
                                //   viewitem.SubItems[listView_md_epc_AntID].Text = epcstr_list[index][4];
                                CurrentCacheItemsSource[index].SubItems[5].Text = epcstr_list[index][11];
                                CurrentCacheItemsSource[index].SubItems[7].Text = epcstr_list[index][12];
                                CurrentCacheItemsSource[index].SubItems[4].Text = epcstr_list[index][7];
                                CurrentCacheItemsSource[index].SubItems[8].Text = epcstr_list[index][9];
                            }
                        }
                        catch
                        {
                            ListViewItem item = new ListViewItem((this.listView_md_epc.Items.Count + 1).ToString("D6"));
                            item.SubItems.Add(epcstr_list[index][4]);
                            item.SubItems.Add(epcstr_list[index][5]);
                            item.SubItems.Add(epcstr_list[index][6]);
                            item.SubItems.Add(epcstr_list[index][7]);
                            item.SubItems.Add(epcstr_list[index][11]);                      
                           // item.SubItems.Add(epcstr_list[index][0]);
                            ListDeviceIdstr = PrivateStringFormat.shortTolongNum(epcstr_list[index][0]);
                            item.SubItems.Add(ListDeviceIdstr);
                            item.SubItems.Add(epcstr_list[index][12]);
                            item.SubItems.Add(epcstr_list[index][9]);
                            item.SubItems.Add(""); // 温度
                            item.SubItems.Add(epcstr_list[index][13]);


                            CurrentCacheItemsSource.Add(item);

                     
                           // this.listView_md_epc.Items[this.listView_md_epc.Items.Count - 1].Selected = true;
                            // this.listView_md_epc.Items[this.listView_md_epc.Items.Count - 1].BackColor = System.Drawing.Color.FromArgb(red, green, blue);
                        }

                        listView_md_epc.VirtualListSize = CurrentCacheItemsSource.Count;
                        listView_md_epc.Invalidate();

                        this.listView_md_epc.Items[this.listView_md_epc.Items.Count - 1].EnsureVisible();

                       // label26_total.Text = listView_md_epc.Items.Count.ToString();
                    }
                }


                for (int i = 0; i < epcstr_list.Count; i++)
                {
                    if (targeDoor[0] == epcstr_list[i][0])
                    {
                        epcstr_list.RemoveAt(i);
                        i--;
                    }
                   // label26_total.Text = listView_md_epc.Items.Count.ToString();
                }

            //    label26_total.Text = listView_md_epc.Items.Count.ToString();
            }
           // this.listView_md_epc.EndUpdate();

        }

        private void GetSourceData(string[] result)
        {
            lock (sourceEpcStrList)
            {
                sourceEpcStrList.Add(result);
            }
        }

        private void UpdateWorkModeEPC(string[] result)
        {
            if (workModeView != null)
            {
                workModeView.UpdateEPCView(result);
            }
        }

        private void UpdateRFLinkl(string[] result)
        {
            if (rflinkView != null)
            {
                rflinkView.UpdateView(result, "RF-Link");
            }
        }



        private void UpdateDownData(string[] subinfo)              //参数一被新增的
        {
            int offset = 3;
            byte commandtype = Convert.ToByte(subinfo[offset + 0], 16);
            switch (commandtype)
            {
                case Activetypes.INIT_PARAMETER:
                    UpdateSetParameters(subinfo, "Init");
                    break;
                case Activetypes.START_CARRER_DETECTION:
                case Activetypes.STOP_CARRER_DETECTION:
                case Activetypes.RESTART:
                case Activetypes.SIMPLE_FLITER:
                    InitParameter(subinfo);
                    break;
                case Activetypes.READ_INFO:
                    ReadInfo(subinfo);
                    break;
                case Activetypes.MODULE_VERSION:
                    //     ModuleVersion(data, offset, len, clientstate);
                    break;
                default:
                    break;
            }
        }

        private void InitParameter(string[] subinfo)
        {
            UpdateLog("操作成功");
        }

        private void UpdateMultiID(string[] result)
        {

            if (monitor)
            {
                bool isexit = false;
                for (int index = 0; index < IDtr_list.Count; index++)
                {
                    if ((IDtr_list[index][4] == result[4]) && (IDtr_list[index][0] == result[0]))
                    {
                        result[10] = (long.Parse(IDtr_list[index][10]) + 1).ToString("D6");
                        IDtr_list[index] = result;
                        isexit = true;
                        break;
                    }
                }
                if (!isexit)
                {
                    IDtr_list.Add(result);
                }
            }
            if (_IsActiveDatabaseWork)
            {
                //   db.InsertToDataTables(result, 1);
            }
        }

        private void ReadInfo(string[] subinfo)
        {
            if (set_24G == false)
            {
                recv_tb.Text = subinfo[7];

                if (subinfo[4] == "66")
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
                if (byte.Parse(subinfo[8]) == 0x00) // 开机自动循环   1
                {
                    IsAutocheckBox.Checked = true;
                }
                else
                {
                    IsAutocheckBox.Checked = false;
                }
                channel_tb.Text = (ushort.Parse(subinfo[9]) + 2400).ToString();  // 9 2400+30
                tagtype_tb.Text = subinfo[10];        //  5
            }



           // textBox1.Text = subinfo[7];
            if (parameterInitView != null)
            {
                parameterInitView.UpdateView(subinfo, lanInit);
            }
        }




        private void UpdateMap(string[] result)
        {
            if (mapView != null)
            {
                mapView.UpdateView(result);
            }
        }

        private void UpdateEAT(string[] result)
        {
            if (eatView != null)
            {
                eatView.UpdateView(result, "EPCAndTID");
            }
        }

        private void SET_EAT(string[] result, string type)
        {
            if (result[0] == ErrorNum.success)
            {
                UpdateLog(set + type + success);
            }
            else
            {
                UpdateLog(set + type + failed);
            }
        }



        private void UpdateComInfo(string[] subinfo)
        {

            if (communicationView != null)
            {
                communicationView.UpdateView(subinfo, lanInfo);
            }
        }

        private void UpdateSetQT(string[] result)
        {
            if (qtView != null)
            {
                qtView.UpdateView(result, "QT");
            }
        }

        private void UpdateMac(string[] result)
        {
            if (macAndDevView != null)
            {
                macAndDevView.UpdateView(result, "MAC DEV");
            }
        }
        private void UpdateSIM(string[] subinfo)
        {
            if (simView != null)
            {
                simView.UpdateView(subinfo, "4G");
            }
        }
        private void UpdateWifi(string[] subinfo)
        {
            if (wifiView != null)
            {
                wifiView.UpdateView(subinfo, "Wifi");
            }
        }
        private void UpdateMQTT(string[] sub)
        {
            if (mqtt != null)
            {
                mqtt.UpdateViewMQTT(sub);
            }
        }
        private void UpdateMQTTheme(string[] sub)
        {
            if (mqtt != null)
            {
                mqtt.UpdateViewMQTTThem(sub);
            }
        }
        // 乔佳 2018-7-27 网络参数页面获取长编码
        private void UpdateLBM(string[] result)
        {
            if (lbm != null)
            {
                lbm.UpdateView(result, "MAC DEV");
           }
        }



        private void UpdateSetParameters(string[] result, string type)
        {
            int offset = 2;
            switch (type)
            {
                case "Multi EPC":
                case "循环查询EPC":
                    /*     string pwd = "";
                         byte fliter = 0x00;
                         string fliterdata = "";
                         byte bank = 0x01;
                         ushort startadd = 0x02;
                         ushort readlen = 0x06;
                         ReaderControllor.ReadTags();*/
                    if (WorkState == "特殊标签工作状态")
                    {
                        if (this.tagAccessView != null)
                        {
                            this.tagAccessView.ReadTag();
                        }
                    }
                    if (result[offset + 0] == ErrorNum.success)
                    {
                        UpdateLog(stop + type + success);
                    }
                    else
                    {
                        UpdateLog(set + type + failed);
                    }
                    break;
                case "Carrier":
                    if (WorkState == "特殊标签工作状态")
                    {
                        if (!SetCarrierOn)
                        {
                            if (this.tagAccessView != null)
                            {
                                this.tagAccessView.ReadTag();
                            }
                        }
                    }
                    if (result[offset + 0] == ErrorNum.success)
                    {
                        UpdateLog(set + type + success);
                    }
                    else
                    {
                        UpdateLog(set + type + failed);
                    }
                    break;
                default:
                    if (result[offset + 0] == ErrorNum.success)
                    {
                        UpdateLog(set + type + success);
                    }
                    else
                    {
                        UpdateLog(set + type + failed);
                    }
                    break;
            }
            if (SrDemo.isLogOpen)
            {
                EventLog.WriteEvent("设置读写器" + type + "数据接收" + "成功", null);
            }

        }








        private string flag = "0";
        long NNNum = 0;
        public int CSSS = 0;
        private void UpdateMultiEPC(string[] result)
        {               
            if (result[3] == Types.STOP_FLAG)                          //触发停止命令 立刻停止刷新 epcstr_list中的数据 
            {

                m_SyncContext.Post(UpdateEpc, flag);
                DataMark = false;
                try
                {

                    flag = (long.Parse(flag) + 1).ToString();
                }
                catch
                {
                    flag = "0";
                }
                labelReaderReportEpcCounts.Text = result[4];
                return;
            }

            if (result.Length < 15)                      //正常标签数据 但是长度不够 错误数据
            {
                return;
            }

            // ASCII显示
            //if (checkBox2.Checked == true)
            //{
            //    string strS = "-";
            //    char[] strSplit = strS.ToCharArray();
            //    string[] strValue = result[5].Split(strSplit);
            //    string hexstring = "";
            //    for (int i = 0; i < strValue.Length; i++)
            //    {
            //        hexstring += strValue[i];
            //    }
            //    byte[] byt_hex = strToToHexByte(hexstring);
            //    string str_ascii = System.Text.Encoding.Default.GetString(byt_hex);
            //    result[5] = str_ascii;
            //}

            bool isexit = false;
            lock (epcstr_list)
            {

                if (NoAnt.Checked == true)
                {
                    for (int index = 0; index < epcstr_list.Count; index++)              //标签数据加入显示队列中
                    {
                        if ((epcstr_list[index][5] == result[5]) && (epcstr_list[index][0] == result[0]))
                        {                                              
                            result[11] = (long.Parse(epcstr_list[index][11]) + long.Parse(result[11])).ToString("D6");                         
                            epcstr_list[index] = result;
                            isexit = true;


                            if (IsStop == false && DataMark == false)
                            {
                                DataMark = true;
                            }

                            break;
                        }

                    }
                    if (!isexit)
                    {
                       // lock (epcstr_list)
                      //  {
                            epcstr_list.Add(result);
                     //   }

                    }                 
                }
                else
                {
                    for (int index = 0; index < epcstr_list.Count; index++)              //标签数据加入显示队列中
                    {                     
                        if ((epcstr_list[index][5] == result[5]) && (epcstr_list[index][0] == result[0]) && (epcstr_list[index][4] == result[4]) && (epcstr_list[index][13] == result[13]))
                        {                         
                            result[11] = (long.Parse(epcstr_list[index][11]) + long.Parse(result[11])).ToString("D6");
                            epcstr_list[index] = result;
                            isexit = true;

                            if (IsStop == false && DataMark == false)
                            {
                                DataMark = true;                        
                            }
                       
                            break;
                        }
                    }
                    if (!isexit)
                    {
                       // lock (epcstr_list)
                       // {
                        epcstr_list.Add(result);
                        // }
                    }
  
                }
            }
            if (_IsRfidDatabaseWork)                              //配置信息中如果启用了  EPC存储功能  则开启存储
            {
                // db.InsertToDataTables(result, 0);
            }
        }


        /// <summary>
        /// 字符串转16进制字节数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        private static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace("-", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }




        private void Displayimmediately(string counts)
        {
            if (counts == "0")
            {
                label26_total.Text = "无标签";
            }
            long totalnum1 = 0;
            label26_total.Text = counts;
            for (int index = 0; index < epcstr_list.Count; index++)
            {
                bool Exist = false;
                int item_index = 0;
                totalnum1 += long.Parse(epcstr_list[index][11]);
                foreach (ListViewItem viewitem in this.listView_md_epc.Items)
                {
                    if ((viewitem.SubItems[listView_md_epc_EPC].Text == epcstr_list[index][5]) && (viewitem.SubItems[listView_md_epc_DevID].Text == epcstr_list[index][0]))
                    {
                        viewitem.SubItems[listView_md_epc_AntID].Text = epcstr_list[index][4];
                        viewitem.SubItems[listView_md_epc_Count].Text = epcstr_list[index][11];
                        viewitem.SubItems[listView_md_epc_Last_Time].Text = epcstr_list[index][8];
                        viewitem.SubItems[listView_md_epc_Rssi].Text = epcstr_list[index][7];
                        viewitem.SubItems[listView_md_epc_Direction].Text = epcstr_list[index][9];
                        Exist = true;
                        break;
                    }
                    item_index++;
                }
                if (!Exist)
                {
                    ListViewItem item = new ListViewItem((this.listView_md_epc.Items.Count + 1).ToString());
                    item.SubItems.Add(epcstr_list[index][4]);
                    item.SubItems.Add(epcstr_list[index][5]);
                    item.SubItems.Add(epcstr_list[index][6]);
                    item.SubItems.Add(epcstr_list[index][7]);
                    item.SubItems.Add(epcstr_list[index][11]);
                    item.SubItems.Add(epcstr_list[index][0]);
                    item.SubItems.Add(epcstr_list[index][8]);
                    item.SubItems.Add(epcstr_list[index][9]);
                    item.SubItems.Add(epcstr_list[index][13]);
                    this.listView_md_epc.Items.Add(item);
                    this.listView_md_epc.Items[this.listView_md_epc.Items.Count - 1].EnsureVisible();
                   // this.listView_md_epc.Items[this.listView_md_epc.Items.Count - 1].Selected = true;
                    // this.listView_md_epc.Items[this.listView_md_epc.Items.Count - 1].BackColor = System.Drawing.Color.FromArgb(red, green, blue);
                }
            }

        }

        private void UpdateGPIO(string[] result)
        {
            if (gpioView != null)
            {
                gpioView.UpdateView(result, "GPIO");
            }
        }
        private void UpdateFrequencyPiont(string[] result)
        {

            if (frequencyPointView != null)
            {
                frequencyPointView.UpdateView(result, lanFRequency);
            }

        }
        private void UpdateFrequencyArea(string[] result)
        {

            if (frequencyAreaView != null)
            {
                frequencyAreaView.UpdateView(result, lanArea);
            }
        }
        private void UpdateTemperature(string[] result)
        {

            if (temperatureView != null)
            {
                temperatureView.UpdateView(result, lanTem);
            }
        }
        private void UpdateGen2(string[] gen2)
        {
            if (gen2View != null)
            {
                gen2View.UpdateView(gen2, "Gen2");
            }
        }
        private void UpdateHardVersion(string[] result)
        {
            if (ver != null)
            {
                ver.UpdateHardVersionView(result, ModuleHardVersion);
            }
        }
        private void UpdateFirmVersion(string[] result)
        {
            if (ver != null)
            {
                ver.UpdateFirmVersionView(result, ModuleFirmVersion);
            }
        }
        private static string MoudleBB = "";
        public static bool IsMoudleBB = false;
        private void HaveYuanNoYuan(string[] result)
        {
            if (result[2] == ErrorNum.success)
            {
                MoudleBB = result[3];
                IsMoudleBB = true;
            }
        }




        private void UpdatePower(string[] substring)
        {

            if (powerView != null)
            {
                powerView.UpdateView(substring, lanPower);
            }
        }


        private void UpdatePower_Four(string[] substring)
        {

            if (powerfourView != null)
            {
                powerfourView.UpdateView(substring, lanPower);
            }
        }


        private void UpdateCarrier(string[] result)
        {
            if (carrierview != null)
            {
                carrierview.UpdateView(result, lanCarrier);
            }
            UpdateLog(get + "carrier" + success);
        }
        private bool isSimple = true;
        private void UpdateWorkAnt(string[] result)
        {

            if (workAntView != null)
            {
                byte offsetlen = 3;
                if (result[offsetlen] == "1")                       //四通道
                {
//                    if (!isSimple)
                    {
                        workAntView.UpdateViewAnt(result, "四通道天线");
                    }
  /*                  else
                    {
                        antConfigView.UpdateViewAnt(result, "四通道天线");
                    }
*/
                }

                else if (result[offsetlen] == "8")                //64通道
                    workAntView.UpdateView(result, "64通道天线");
                else
                    workAntView.UpdateView16(result, "通道天线");
            }
        }
        private void UpdateReadTags(string[] subreaddate)
        {

            if (tagAccessView != null)
            {
                tagAccessView.UpdateViewReadTag(subreaddate, datasource, _IsCommandDatabaseWork, lanReadWrite);
            }
        }
        private void UpdateWriteTags(string[] result)
        {

            if (tagAccessView != null)
            {
                tagAccessView.UpdateViewWriteTag(result, datasource, _IsCommandDatabaseWork, lanReadWrite);
            }
        }
        private void UpdateLockTags(string[] result)
        {
            if (tagAccessView != null)
            {
                tagAccessView.UpdateViewKLockTag(result, lanReadWrite);
            }

        }
        private void UpdateKillTags(string[] result)
        {
            if (tagAccessView != null)
            {
                tagAccessView.UpdateViewKillTag(result, lanReadWrite);
            }
        }
        private void UpdateWorkInterrupted(string[] result)
        {
            if (workAntView != null)
            {
                workAntView.UpdateViewWorkInterrupted(result, lanWorkAnt);
            }
        }
        private void UpdateWorkTime(string[] result)
        {
            if (workAntView != null)
            {
                workAntView.UpdateViewWorkTime(result, lanWorkAnt);
            }
        }
        private void UpdateFastID(string[] result)
        {
            if (fastIDView != null)
            {
                fastIDView.UpdateView(result, "FastID");
            }
        }
        private void UpdateQT(string[] result)
        {

        }

        private void UpdateTagfocus(string[] result)
        {
            if (tagfocusView != null)
            {
                tagfocusView.UpdateView(result, "Tagfocus");
            }
        }

        private void UpdateModuleVersion_9200(string[] result)
        {
            if (moudleversionView != null)
            {
                moudleversionView.UpdateView(result);
            }
        }

        private void UpdateBatchTag(string[] result)
        {
            if (batchtagView != null)
            {
                batchtagView.UpdateView(result);
            }
        }


        private void UpdateWriteBatchTag(string[] result)
        {
            if (result[2] == "1")
            {
                UpdateLog("批量写入标签成功");
            }
            else
            {
                UpdateLog("批量写入标签失败");
            }
        }


        private void UpdateSetModuleVersion_9200(string[] result)
        {
            if (result[2] == "1")
            {
                UpdateLog("设置9200模块版本成功");
            }
            else
            {
                UpdateLog("设置9200模块版本失败");
            }
        }



        private void UpdateWorkMode(string[] submode)
        {
            if (workModeView != null)
            {
                workModeView.UpdateView(submode, lanWorkMode);
            }
        }






        private void listView_label_DoubleClick(object sender, EventArgs e)
        {
            //  textBox_tag_epc.Text = listView_md_epc.SelectedItems[0].SubItems[listView_label_EPC].Text.Replace("-", "");
        }



        private void set_count()
        {
            lock ((object)tags_count_persecond)
            {
                ++tags_count_persecond;
            }

        }

        private void reset_count()
        {
            lock ((object)tags_count_persecond)
            {
                tags_count_persecond = 0;
            }
        }

        private int get_count()
        {
            return tags_count_persecond;
        }

        // 清空列表



        private string epc_format(byte[] epc, char epc_len)
        {
            string str_epc = "";
            for (int index = 0; index < epc_len; index++)
            {
                str_epc += epc[index].ToString("X2");
                if (index < epc_len - 1)
                {
                    str_epc += "-";
                }
            }
            return str_epc;
        }

        private string tid_format(byte[] tid, int tid_len)
        {
            string str_epc = "";
            for (int index = 0; index < tid_len; index++)
            {
                str_epc += tid[index].ToString("X2");
                if (index < tid_len - 1)
                {
                    str_epc += "-";
                }
            }
            return str_epc;
        }


        private double rssi_calculate(byte rssi_msb, byte rssi_lsb)
        {
            ushort temp_rssi = (ushort)(((ushort)rssi_msb << 8) + (ushort)rssi_lsb);
            double sh_rssi = (double)(short)temp_rssi / 10;

            return sh_rssi;
        }


        private ushort pc_calculate(byte pc_msb, byte pc_lsb)
        {
            ushort temp_pc = (ushort)((((ushort)pc_msb) << 8) + (ushort)pc_lsb);

            return temp_pc;
        }




        public void UpdateLog(string strLog)
        {
            try
            {
                lock (listView_oper_log)
                {
                    string strDateTime = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
                    ListViewItem item = new ListViewItem((this.listView_oper_log.Items.Count + 1).ToString());
                    item.SubItems.Add(strDateTime);
                    item.SubItems.Add(strLog);
                    this.listView_oper_log.Items.Add(item);
                    this.listView_oper_log.Items[this.listView_oper_log.Items.Count - 1].EnsureVisible();
                    this.listView_oper_log.Items[this.listView_oper_log.Items.Count - 1].Selected = true;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteError(ex.ToString());
            }
        }


        private void set_connect_type(int connect_type)
        {
            m_connect_type = connect_type;
        }

        private int get_connect_type()
        {
            return m_connect_type;
        }
        // 开始


        const string MULTI_START_LABEL = "Query";
        const string MULTI_STOP_LABEL = "Stop";

        private void button_md_add_Click(object sender, EventArgs e)
        {


        }

        private void button_md_move_Click(object sender, EventArgs e)
        {

        }
        private bool mc_query_start = false;
        int row = 0;
        private void listView_md_addr_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView_md_addr.SelectedItems.Count > 0)
                {
                    row = listView_md_addr.SelectedIndices[0];
                }
                CustomControl.WorkingReader = currentclient = clients[row];
                if (currentclient.types == connect.net)
                {
                    if (currentclient.dev != null && currentclient.dev != "")
                    {
                        currentDev_l.Text = "Device:" + PrivateStringFormat.shortTolongNum(currentclient.dev);//+ currentclient.dev + "    "
                    }
                }
                else
                {
                    //  currentDev_l.Text = "Device:" + currentclient.com;
                    currentDev_l.Text = "Device:" + COM_DevID;
                }
            }
            catch 
            {
                if (listView_md_addr.SelectedItems.Count > 0)
                {
                    row = listView_md_addr.SelectedIndices[0];
                }

                int aa = row;
                string dd = "";

                CustomControl.WorkingReader = currentclient = clients[row-1];
                if (currentclient.types == connect.net)
                {
                    if (currentclient.dev != null && currentclient.dev != "")
                    {
                        currentDev_l.Text = "Device:" + PrivateStringFormat.shortTolongNum(currentclient.dev);//+ currentclient.dev + "    "
                    }
                }
                else
                {
                    //  currentDev_l.Text = "Device:" + currentclient.com;
                    currentDev_l.Text = "Device:" + COM_DevID;
                }

            }

        }

        void hex2string(byte[] src_hex, int src_len, byte[] dist_string, int dist_len)
        {
            int i;
            byte uc;
            for (i = 0; i < src_len; i++)
            {
                if (i * 2 >= dist_len) break;
                uc = (byte)((src_hex[i] & 0xF0) >> 4);
                if (uc < 0x0A)
                    uc += 0x30;
                else
                    uc += 0x37;
                dist_string[i * 2] = uc;
                uc = (byte)(src_hex[i] & 0x0F);
                if (uc < 0x0A)
                    uc += 0x30;
                else
                    uc += 0x37;
                if (i * 2 + 1 >= dist_len) break;
                dist_string[i * 2 + 1] = uc;
            }
        }

        public static bool isLogOpen = false;
        public static bool IsStart = false; // 是否点击开始读标
        private void button_md_start_Click(object sender, EventArgs e)
        {
            IsStop = false;
            IsStart = true;
            NNNum = Last_Num = 0;
            allreader_cb.Enabled = false;
            singleEPC_rb.Enabled = false;
           // timer1.Enabled = false;
           // timer1.Enabled = true;
/*        
            if (SelectAntcheckBox1.Checked == true || SelectAntcheckBox2.Checked == true || SelectAntcheckBox3.Checked == true || SelectAntcheckBox4.Checked == true)
            {
                try
                {
                    byte workant = 0;
                    if (SelectAntcheckBox1.Checked == true)
                    {
                        workant |= 0x01;
                    }
                    if (SelectAntcheckBox2.Checked == true)
                    {
                        workant |= 0x02;
                    }
                    if (SelectAntcheckBox3.Checked == true)
                    {
                        workant |= 0x04;
                    }
                    if (SelectAntcheckBox4.Checked == true)
                    {
                        workant |= 0x08;
                    }
                    string result = ReaderControllor.SetWorkAnt(currentclient, workant);
                    if (isLogOpen)
                    {
                        if (result == ErrorNum.SEND_OK)
                        {
                            EventLog.WriteEvent("设置天线工作状态命令发送成功", null);
                        }
                        else
                        {
                            EventLog.WriteEvent("设置天线工作状态命令发送失败", null);
                        }
                    }
                }
                catch (Exception ex)
                {
                    UpdateLog(ex.ToString());
                    if (isLogOpen)
                    {
                        ErrorLog.WriteError(ex.ToString());
                    }
                }
            }
*/
            try
            {
                string result = string.Empty;
                if (allreader_cb.Checked == true)              //操作所有读写器
                {
                    if (singleEPC_rb.Checked == true)
                    {
                        result = ReaderControllor.SingleEPC();
                    }
                    else
                    {
                        result = ReaderControllor.StartMultiEPC();
                    }
                }
                else                                           //操作单台读写器
                {
                    if (singleEPC_rb.Checked == true)
                    {
                        result = ReaderControllor.SingleEPC(currentclient);
                    } 
                    else
                    {
                        result = ReaderControllor.StartMultiEPC(currentclient);
                    }
                }
                if (result == ErrorNum.SEND_OK)
                {
                    UpdateLog(start + multiepc + success);
                    if (isLogOpen)
                    {
                        EventLog.WriteEvent("开始循环查询EPC命令发送成功", null);
                    }
                    if(!isRFIDTimerStart)button5_Click_1(sender, (EventArgs)e);
                }
                else
                {
                    UpdateLog(start + multiepc + failed);
                    if (isLogOpen)
                    {
                        EventLog.WriteEvent("开始循环查询EPC命令发送失败", null);
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateLog(ex.ToString());
                if (isLogOpen)
                {
                    ErrorLog.WriteError(ex.ToString());
                }
            }
        }



        public static bool IsStop = false; // 是否点击停止按钮
        private void button_md_stop_Click(object sender, EventArgs e)
        {
            IsStop = true;
            DataMark = IsStart = false;
            allreader_cb.Enabled = true;
            singleEPC_rb.Enabled = true;
            timerMonitor.Enabled = false;
            timerMonitor.Stop();
            try
            {
                if (allreader_cb.Checked == true)              //操作所有读写器
                {
                    if (singleEPC_rb.Checked == true)
                    {
                        ;
                    }
                    else
                    {
                        if (ReaderControllor.StopMultiEPC() == ErrorNum.SEND_FAILED)
                        {
                            if (isLogOpen)
                            {
                                EventLog.WriteEvent(stop + multiepc + failed, null);
                            }
                        }
                        else
                        {
                            if (isLogOpen)
                            {
                                EventLog.WriteEvent(stop + multiepc + success, null);
                            }
                        }
                    }
                }
                else                                           //操作单台读写器
                {
                    if (singleEPC_rb.Checked == true)
                    {
                        ;
                    }
                    else
                    {
                        if (ReaderControllor.StopMultiEPC(currentclient) == ErrorNum.SEND_FAILED)
                        {

                            if (isLogOpen)
                            {
                                EventLog.WriteEvent(stop + multiepc + failed, null);
                            }
                        }
                        else
                        {
                            if (isLogOpen)
                            {
                                EventLog.WriteEvent(stop + multiepc + success, null);
                            }
                        }
                    }
                }
              
                if (isRFIDTimerStart) button5_Click_1(sender, (EventArgs)e);
            }
            catch (Exception ex)
            {
                UpdateLog(ex.ToString());
                if (isLogOpen)
                {
                    ErrorLog.WriteError(ex.ToString());
                }
            }
        }



        //更新数据库数据
        private void timer_md_query_Tick_Tick(object sender, EventArgs e)
        {
            //直接显示
            if (_IsRfidDatabaseWork)
            {
                // db.InsertMultiData(0);
            }
            if (_IsActiveDatabaseWork)
            {
                //  db.InsertMultiData(1);
            }

        }

        private void UpdataDateBase()
        {
            //  db.InsertMultiData();
        }
       
        private long totalnumBack = 0;
        private static long EpctotalnumBack = 0;
        private void UpdateIDAccumulateOld()
        {
            this.ListViewID.BeginUpdate();

            string ListDeviceIdstr = "";

            string Batterystr = "";

            lock (IDtr_list)
            {

                for (int index = 0; index < IDtr_list.Count; index++)
                {
                    if ((fd.Enabled == true) && fd.Text != null && fd.Text != "")
                    {
                        if (!IDtr_list[index][4].Contains(fd.Text))
                        {
                            continue;
                        }
                    }
                    bool Exist = false;

                    try
                    {
                        if ((CurrentCacheItemsSource_ID[index].SubItems[1].Text == IDtr_list[index][4]))
                        {
                            CurrentCacheItemsSource_ID[index].SubItems[3].Text = IDtr_list[index][3];
                            CurrentCacheItemsSource_ID[index].SubItems[4].Text = IDtr_list[index][7];
                            CurrentCacheItemsSource_ID[index].SubItems[5].Text = IDtr_list[index][5];
                            CurrentCacheItemsSource_ID[index].SubItems[6].Text = IDtr_list[index][6];
                            if (IDtr_list[index][9] == "255")
                            {
                                Batterystr = "电量正常";
                            }
                            else
                            {
                                Batterystr = "低电量报警";
                            }
                            CurrentCacheItemsSource_ID[index].SubItems[7].Text = Batterystr;
                            CurrentCacheItemsSource_ID[index].SubItems[8].Text = IDtr_list[index][10];
                            CurrentCacheItemsSource_ID[index].SubItems[10].Text = IDtr_list[index][12];
                            Exist = true;
                        }

                        ListViewID.VirtualListSize = CurrentCacheItemsSource_ID.Count;
                        ListViewID.Invalidate();
                        this.ListViewID.Items[this.ListViewID.Items.Count - 1].EnsureVisible();
                    }
                    catch
                    {
                        ListViewItem item = new ListViewItem((this.ListViewID.Items.Count + 1).ToString("D6"));

                        item.SubItems.Add(IDtr_list[index][4]);      // ID    1
                        if (radioButtonModuleTest.Checked == true) ListDeviceIdstr = IDtr_list[index][0];
                        else
                        {
                            ListDeviceIdstr = PrivateStringFormat.shortTolongNum(IDtr_list[index][0]);

                            string bz_str = "";
                            if (ListDeviceIdstr.Length < 15)
                            {
                                int bz_len = 15 - ListDeviceIdstr.Length;

                                for (int i = 0; i < bz_len; i++)
                                {
                                    bz_str += "0";
                                }

                                ListDeviceIdstr = ListDeviceIdstr.Substring(0, 2) + bz_str + ListDeviceIdstr.Substring(2, 11);
                            }
                        }
                        item.SubItems.Add(ListDeviceIdstr);      //设备号           2
                        item.SubItems.Add(IDtr_list[index][3]);  // 假温度          3
                        item.SubItems.Add(IDtr_list[index][7]);  // 防拆位          4
                        item.SubItems.Add(IDtr_list[index][5]);  // 场强            5
                        item.SubItems.Add(IDtr_list[index][6]);  // 功率            6
                        if (IDtr_list[index][9] == "255")
                        {
                            Batterystr = "电量正常";
                        }
                        else
                        {
                            Batterystr = "低电量报警";
                        }
                        item.SubItems.Add(Batterystr);                  // 电量    7
                        item.SubItems.Add(IDtr_list[index][10]);       // 读取次数   8
                        item.SubItems.Add(IDtr_list[index][8]);        // 发送间隔    9
                        item.SubItems.Add(IDtr_list[index][12]);       // 上次读取时间  10


                        CurrentCacheItemsSource_ID.Add(item);

                        ListViewID.VirtualListSize = CurrentCacheItemsSource_ID.Count;
                        ListViewID.Invalidate();

                        this.ListViewID.Items[this.ListViewID.Items.Count - 1].EnsureVisible();

                        // this.ListViewID.Items[this.ListViewID.Items.Count - 1].Selected = true;
                    }
                }
                LabelIDCounts.Text = ListViewID.Items.Count.ToString();
            }

            this.ListViewID.EndUpdate();
        }



        private void UpdateIDAccumulate()
        {
            this.ListViewID.BeginUpdate();

            string ListDeviceIdstr = "";

            string Batterystr = "";

            lock (IDtr_list)
            {

                for (int index = 0; index < IDtr_list.Count; index++)
                {
                    if ((fd.Enabled == true) && fd.Text != null && fd.Text != "")
                    {
                        if (!IDtr_list[index][4].Contains(fd.Text))
                        {
                            continue;
                        }
                    }
                    bool Exist = false;

                    foreach (ListViewItem viewitem in this.CurrentCacheItemsSource_ID)
                    {

                        if ((viewitem.SubItems[1].Text == IDtr_list[index][4]))
                        {
                            viewitem.SubItems[3].Text = IDtr_list[index][3];
                            viewitem.SubItems[4].Text = IDtr_list[index][7];
                            viewitem.SubItems[5].Text = IDtr_list[index][5];
                            viewitem.SubItems[6].Text = IDtr_list[index][6];
                            if (IDtr_list[index][9] == "255")
                            {
                                Batterystr = "电量正常";
                            }
                            else
                            {
                                Batterystr = "低电量报警";
                            }
                            viewitem.SubItems[7].Text = Batterystr;
                            viewitem.SubItems[8].Text = IDtr_list[index][10];
                            viewitem.SubItems[10].Text = IDtr_list[index][12];
                            Exist = true;
                            break;
                        }
                    }

                    ListViewID.VirtualListSize = CurrentCacheItemsSource_ID.Count;
                    ListViewID.Invalidate();

                    if (!Exist)
                    {
                        ListViewItem item = new ListViewItem((this.ListViewID.Items.Count + 1).ToString("D6"));

                        item.SubItems.Add(IDtr_list[index][4]);      // ID    1
                        if (radioButtonModuleTest.Checked == true) ListDeviceIdstr = IDtr_list[index][0];
                        else
                        {
                            ListDeviceIdstr = PrivateStringFormat.shortTolongNum(IDtr_list[index][0]);

                            string bz_str = "";
                            if (ListDeviceIdstr.Length < 15)
                            {
                                int bz_len = 15 - ListDeviceIdstr.Length;

                                for (int i = 0; i < bz_len; i++)
                                {
                                    bz_str += "0";
                                }

                                ListDeviceIdstr = ListDeviceIdstr.Substring(0, 2) + bz_str + ListDeviceIdstr.Substring(2, 11);
                            }
                        }
                        item.SubItems.Add(ListDeviceIdstr);      //设备号           2
                        item.SubItems.Add(IDtr_list[index][3]);  // 假温度          3
                        item.SubItems.Add(IDtr_list[index][7]);  // 防拆位          4
                        item.SubItems.Add(IDtr_list[index][5]);  // 场强            5
                        item.SubItems.Add(IDtr_list[index][6]);  // 功率            6
                        if (IDtr_list[index][9] == "255")
                        {
                            Batterystr = "电量正常";
                        }
                        else
                        {
                            Batterystr = "低电量报警";
                        }
                        item.SubItems.Add(Batterystr);                  // 电量    7
                        item.SubItems.Add(IDtr_list[index][10]);       // 读取次数   8
                        item.SubItems.Add(IDtr_list[index][8]);        // 发送间隔    9
                        item.SubItems.Add(IDtr_list[index][12]);       // 上次读取时间  10


                        CurrentCacheItemsSource_ID.Add(item);

                        ListViewID.VirtualListSize = CurrentCacheItemsSource_ID.Count;
                        ListViewID.Invalidate();

                        this.ListViewID.Items[this.ListViewID.Items.Count - 1].EnsureVisible();

                        // this.ListViewID.Items[this.ListViewID.Items.Count - 1].Selected = true;
                    }
                }
                LabelIDCounts.Text = ListViewID.Items.Count.ToString();
            }

            this.ListViewID.EndUpdate();
        }




        private byte showIDType = 0x00;
        private void UpdateIDOld()
        {
            this.ListViewID.BeginUpdate();

            long totalnum1 = 0;

            string ListDeviceIdstr;
            string Batterystr = "";

            lock (IDtr_list)
            {

                ListViewID.Items.Clear();
                for (int index = 0; index < IDtr_list.Count; index++)
                {
                    if ((fd.Enabled == true) && fd.Text != null && fd.Text != "")
                    {
                        if (!IDtr_list[index][4].Contains(fd.Text))
                        {
                            continue;
                        }
                    }
                    bool Exist = false;
                    totalnum1 += long.Parse(IDtr_list[index][10]);


                    try
                    {
                        if ((CurrentCacheItemsSource_ID[index].SubItems[1].Text == IDtr_list[index][4]))
                        {
                            CurrentCacheItemsSource_ID[index].SubItems[3].Text = IDtr_list[index][3];
                            CurrentCacheItemsSource_ID[index].SubItems[4].Text = IDtr_list[index][7];
                            CurrentCacheItemsSource_ID[index].SubItems[5].Text = IDtr_list[index][5];
                            CurrentCacheItemsSource_ID[index].SubItems[6].Text = IDtr_list[index][6];
                            if (IDtr_list[index][9] == "255")
                            {
                                Batterystr = "电量正常";
                            }
                            else
                            {
                                Batterystr = "低电量报警";
                            }
                            CurrentCacheItemsSource_ID[index].SubItems[7].Text = Batterystr;
                            CurrentCacheItemsSource_ID[index].SubItems[8].Text = IDtr_list[index][10];
                            CurrentCacheItemsSource_ID[index].SubItems[10].Text = IDtr_list[index][12];
                            Exist = true;
                        }

                        ListViewID.VirtualListSize = CurrentCacheItemsSource_ID.Count;
                        ListViewID.Invalidate();
                        this.ListViewID.Items[this.ListViewID.Items.Count - 1].EnsureVisible();
                    }
                    catch
                    {
                        ListViewItem item = new ListViewItem((this.ListViewID.Items.Count + 1).ToString("D6"));

                        item.SubItems.Add(IDtr_list[index][4]);      // ID    1
                        if (radioButtonModuleTest.Checked == true) ListDeviceIdstr = IDtr_list[index][0];
                        else
                        {
                            ListDeviceIdstr = PrivateStringFormat.shortTolongNum(IDtr_list[index][0]);

                            string bz_str = "";
                            if (ListDeviceIdstr.Length < 15)
                            {
                                int bz_len = 15 - ListDeviceIdstr.Length;

                                for (int i = 0; i < bz_len; i++)
                                {
                                    bz_str += "0";
                                }

                                ListDeviceIdstr = ListDeviceIdstr.Substring(0, 2) + bz_str + ListDeviceIdstr.Substring(2, 11);
                            }
                        }
                        item.SubItems.Add(ListDeviceIdstr);      //设备号           2
                        item.SubItems.Add(IDtr_list[index][3]);  // 假温度          3
                        item.SubItems.Add(IDtr_list[index][7]);  // 防拆位          4
                        item.SubItems.Add(IDtr_list[index][5]);  // 场强            5
                        item.SubItems.Add(IDtr_list[index][6]);  // 功率            6
                        if (IDtr_list[index][9] == "255")
                        {
                            Batterystr = "电量正常";
                        }
                        else
                        {
                            Batterystr = "低电量报警";
                        }
                        item.SubItems.Add(Batterystr);                  // 电量    7
                        item.SubItems.Add(IDtr_list[index][10]);       // 读取次数   8
                        item.SubItems.Add(IDtr_list[index][8]);        // 发送间隔    9
                        item.SubItems.Add(IDtr_list[index][12]);       // 上次读取时间  10


                        CurrentCacheItemsSource_ID.Add(item);

                        ListViewID.VirtualListSize = CurrentCacheItemsSource_ID.Count;
                        ListViewID.Invalidate();

                        this.ListViewID.Items[this.ListViewID.Items.Count - 1].EnsureVisible();
                    }
                }

                LabelIDCounts.Text = ListViewID.Items.Count.ToString();
                IDtr_list.Clear();
            }

            this.ListViewID.EndUpdate();
        }

        private void UpdateID()
        {
            this.ListViewID.BeginUpdate();

            long totalnum1 = 0;

            string ListDeviceIdstr;
            string Batterystr = "";

            lock (IDtr_list)
            {

                ListViewID.Items.Clear();
                for (int index = 0; index < IDtr_list.Count; index++)
                {
                    if ((fd.Enabled == true) && fd.Text != null && fd.Text != "")
                    {
                        if (!IDtr_list[index][4].Contains(fd.Text))
                        {
                            continue;
                        }
                    }
                    bool Exist = false;
                    totalnum1 += long.Parse(IDtr_list[index][10]);


                    foreach (ListViewItem viewitem in this.CurrentCacheItemsSource_ID)
                    {
                        if ((viewitem.SubItems[1].Text == IDtr_list[index][4]))
                        {
                            viewitem.SubItems[3].Text = IDtr_list[index][3];
                            viewitem.SubItems[4].Text = IDtr_list[index][7];
                            viewitem.SubItems[5].Text = IDtr_list[index][5];
                            viewitem.SubItems[6].Text = IDtr_list[index][6];
                            if (IDtr_list[index][9] == "255")
                            {
                                Batterystr = "电量正常";
                            }
                            else
                            {
                                Batterystr = "低电量报警";
                            }
                            viewitem.SubItems[7].Text = Batterystr;
                            viewitem.SubItems[8].Text = IDtr_list[index][10];
                            viewitem.SubItems[10].Text = IDtr_list[index][12];
                            Exist = true;
                            break;
                        }
                    }

                    ListViewID.VirtualListSize = CurrentCacheItemsSource_ID.Count;
                    ListViewID.Invalidate();

                    if (!Exist)
                    {
                        ListViewItem item = new ListViewItem((this.ListViewID.Items.Count + 1).ToString("D6"));

                        item.SubItems.Add(IDtr_list[index][4]);      // ID    1
                        if (radioButtonModuleTest.Checked == true) ListDeviceIdstr = IDtr_list[index][0];
                        else
                        {
                            ListDeviceIdstr = PrivateStringFormat.shortTolongNum(IDtr_list[index][0]);

                            string bz_str = "";
                            if (ListDeviceIdstr.Length < 15)
                            {
                                int bz_len = 15 - ListDeviceIdstr.Length;

                                for (int i = 0; i < bz_len; i++)
                                {
                                    bz_str += "0";
                                }

                                ListDeviceIdstr = ListDeviceIdstr.Substring(0, 2) + bz_str + ListDeviceIdstr.Substring(2, 11);
                            }
                        }
                        item.SubItems.Add(ListDeviceIdstr);      //设备号           2
                        item.SubItems.Add(IDtr_list[index][3]);  // 假温度          3
                        item.SubItems.Add(IDtr_list[index][7]);  // 防拆位          4
                        item.SubItems.Add(IDtr_list[index][5]);  // 场强            5
                        item.SubItems.Add(IDtr_list[index][6]);  // 功率            6
                        if (IDtr_list[index][9] == "255")
                        {
                            Batterystr = "电量正常";
                        }
                        else
                        {
                            Batterystr = "低电量报警";
                        }
                        item.SubItems.Add(Batterystr);                  // 电量    7
                        item.SubItems.Add(IDtr_list[index][10]);       // 读取次数   8
                        item.SubItems.Add(IDtr_list[index][8]);        // 发送间隔    9
                        item.SubItems.Add(IDtr_list[index][12]);       // 上次读取时间  10


                        CurrentCacheItemsSource_ID.Add(item);

                        ListViewID.VirtualListSize = CurrentCacheItemsSource_ID.Count;
                        ListViewID.Invalidate();

                        this.ListViewID.Items[this.ListViewID.Items.Count - 1].EnsureVisible();
                    }
                }

                LabelIDCounts.Text = ListViewID.Items.Count.ToString();
                IDtr_list.Clear();
            }

            this.ListViewID.EndUpdate();
        }




        private static long epcLogNum = 0;
        /// <summary>
        /// 刷新指定的数据
        /// </summary>
        /// <param name="e">指定数据标志</param>
        /// 
        private void UpdateEpcOld(object e)
        {
            this.listView_md_epc.BeginUpdate();

            long totalnum1 = 0;
            string temflag = (string)e;
            //listView_md_epc.Items.Clear();
            int ShowNum = 0;
            string time = DateTime.Now.ToString();
            string ListDeviceIdstr;
            LabelCurrentTime.Text = "时      间";
            lock (epcstr_list)
            {
                for (int index = 0; index < epcstr_list.Count; index++)
                {
                    bool Exist = false;
                    if (epcstr_list[index][14] == temflag)
                    {
                        //插入excel 
                        if (startWriteToTxt)
                        {
                            epcLogNum++;
                            //   string CommandText = "Insert Into [Sheet1$] Values('" + epcstr_list.Count.ToString() + "', '" + epcstr_list[index][5] + "','" + epcstr_list[index][11] + "', '" + epcstr_list[index][12] + "', '" + epcstr_list[index][12] + "')";
                            //   excelOperate.Insert(CommandText);
                            string epcData = epcLogNum.ToString().PadRight(10, ' ') + epcstr_list.Count.ToString().PadRight(5, ' ') + epcstr_list[index][4].PadRight(5, ' ') + epcstr_list[index][5].PadRight(40, ' ') + epcstr_list[index][6].PadRight(10, ' ') + epcstr_list[index][7].PadRight(10, ' ')
                                 + epcstr_list[index][11].PadRight(5, ' ') + epcstr_list[index][0].PadRight(15, ' ') + epcstr_list[index][12].PadRight(30, ' ') + epcstr_list[index][9].PadRight(5, ' ') + epcstr_list[index][13].PadRight(5, ' ');
                            EPCLog.WriteEvent(epcData);
                        }
                        totalnum1 += long.Parse(epcstr_list[index][11]);
                        ShowNum++;
                        }
                        try
                        {
                            ListDeviceIdstr = epcstr_list[index][0];
                            if (ListDeviceIdstr != "")
                            {
                                ListDeviceIdstr = PrivateStringFormat.shortTolongNum(epcstr_list[index][0]);

                                string bz_str = "";
                                if (ListDeviceIdstr.Length < 15)
                                {
                                    int bz_len = 15 - ListDeviceIdstr.Length;

                                    for (int i = 0; i < bz_len; i++)
                                    {
                                        bz_str += "0";
                                    }

                                    ListDeviceIdstr = ListDeviceIdstr.Substring(0, 2) + bz_str + ListDeviceIdstr.Substring(2, 11);
                                }
                            }
                            if ((CurrentCacheItemsSource[index].SubItems[2].Text == epcstr_list[index][5]) && (CurrentCacheItemsSource[index].SubItems[6].Text == ListDeviceIdstr))
                            {
                                CurrentCacheItemsSource[index].SubItems[5].Text = epcstr_list[index][11];
                                CurrentCacheItemsSource[index].SubItems[7].Text = epcstr_list[index][12];
                                CurrentCacheItemsSource[index].SubItems[4].Text = epcstr_list[index][7];
                                CurrentCacheItemsSource[index].SubItems[8].Text = epcstr_list[index][9];
                                CurrentCacheItemsSource[index].SubItems[9].Text = epcstr_list[index][14];
                            }

                            CurrentCacheItemsSource.Clear();

                            listView_md_epc.VirtualListSize = CurrentCacheItemsSource.Count;
                            listView_md_epc.Invalidate();

                            this.listView_md_epc.Items[this.listView_md_epc.Items.Count - 1].EnsureVisible();
                        }
                        catch
                        {
                            ListViewItem item = new ListViewItem((this.listView_md_epc.Items.Count + 1).ToString("D6"));

                            item.SubItems.Add(epcstr_list[index][4]);
                            item.SubItems.Add(epcstr_list[index][5]);
                            item.SubItems.Add(epcstr_list[index][6]);
                            item.SubItems.Add(epcstr_list[index][7]);
                            item.SubItems.Add(epcstr_list[index][11]);
                            if (radioButtonModuleTest.Checked == true) item.SubItems.Add(epcstr_list[index][0]);
                            else
                            {
                                ListDeviceIdstr = PrivateStringFormat.shortTolongNum(epcstr_list[index][0]);

                                string bz_str = "";
                                if (ListDeviceIdstr.Length < 15)
                                {
                                    int bz_len = 15 - ListDeviceIdstr.Length;

                                    for (int i = 0; i < bz_len; i++)
                                    {
                                        bz_str += "0";
                                    }

                                    ListDeviceIdstr = ListDeviceIdstr.Substring(0, 2) + bz_str + ListDeviceIdstr.Substring(2, 11);
                                }
                                item.SubItems.Add(ListDeviceIdstr);
                            }
                            item.SubItems.Add(epcstr_list[index][12]);
                            item.SubItems.Add(epcstr_list[index][9]);
                            item.SubItems.Add(""); // 温度
                            item.SubItems.Add(epcstr_list[index][13]);

                            CurrentCacheItemsSource.Add(item);

                            listView_md_epc.VirtualListSize = CurrentCacheItemsSource.Count;
                            listView_md_epc.Invalidate();

                            this.listView_md_epc.Items[this.listView_md_epc.Items.Count - 1].EnsureVisible();
                        }
                    
                }

                label26_total.Text = listView_md_epc.Items.Count.ToString();

                //插入数据到excel
                if (ShowEPCStyle == Types.TRIGGER_DISPLAY)
                {
                    for (int index = 0; index < epcstr_list.Count; index++)             //清除已经显示的数据
                    {
                        if (epcstr_list[index][14] == temflag)
                        {
                            epcstr_list.RemoveAt(index);
                        }
                    }
                }
                else if (ShowEPCStyle == Types.TIMING_DISPLAY)
                {
                    epcstr_list.Clear();
                }
                if (totalnum1 != 0)
                {
                    label26_total.Text = listView_md_epc.Items.Count.ToString();
                }
            }

            this.listView_md_epc.EndUpdate();
        }


        private void UpdateEpc(object e)
        {
           this.listView_md_epc.BeginUpdate();

            long totalnum1 = 0;
            string temflag = (string)e;
            listView_md_epc.Items.Clear();
             CurrentCacheItemsSource.Clear();

            listView_md_epc.VirtualListSize = CurrentCacheItemsSource.Count;
            listView_md_epc.Invalidate();

            int ShowNum = 0;
            string time = DateTime.Now.ToString();
            string ListDeviceIdstr;
#if CN
            LabelCurrentTime.Text = "时      间";
#endif

#if ENGLISH
            LabelCurrentTime.Text = "Time";
#endif
            lock (epcstr_list)
            {
                lock (CurrentCacheItemsSource)
                {
                for (int index = 0; index < epcstr_list.Count; index++)
                {
                    bool Exist = false;
                    if (epcstr_list[index][15] == temflag)
                    {
                        //插入excel 
                        if (startWriteToTxt)
                        {
                            epcLogNum++;
                            //   string CommandText = "Insert Into [Sheet1$] Values('" + epcstr_list.Count.ToString() + "', '" + epcstr_list[index][5] + "','" + epcstr_list[index][11] + "', '" + epcstr_list[index][12] + "', '" + epcstr_list[index][12] + "')";
                            //   excelOperate.Insert(CommandText);
                            string epcData = epcLogNum.ToString().PadRight(10, ' ') + epcstr_list.Count.ToString().PadRight(5, ' ') + epcstr_list[index][4].PadRight(5, ' ') + epcstr_list[index][5].PadRight(40, ' ') + epcstr_list[index][6].PadRight(10, ' ') + epcstr_list[index][7].PadRight(10, ' ')
                                 + epcstr_list[index][11].PadRight(5, ' ') + epcstr_list[index][0].PadRight(15, ' ') + epcstr_list[index][12].PadRight(30, ' ') + epcstr_list[index][9].PadRight(5, ' ') + epcstr_list[index][13].PadRight(5, ' ');
                            EPCLog.WriteEvent(epcData);
                        }
                        totalnum1 += long.Parse(epcstr_list[index][11]);
                        ShowNum++;
                    }
                        ListDeviceIdstr = epcstr_list[index][0];
                        if (ListDeviceIdstr != "")
                        {
                            ListDeviceIdstr = PrivateStringFormat.shortTolongNum(epcstr_list[index][0]);

                            string bz_str = "";
                            if (ListDeviceIdstr.Length < 15)
                            {
                                int bz_len = 15 - ListDeviceIdstr.Length;

                                for (int i = 0; i < bz_len; i++)
                                {
                                    bz_str += "0";
                                }

                                ListDeviceIdstr = ListDeviceIdstr.Substring(0, 2) + bz_str + ListDeviceIdstr.Substring(2, 11);
                            }
                        }

                        foreach (ListViewItem viewitem in this.CurrentCacheItemsSource)
                        {
                            if ((viewitem.SubItems[listView_md_epc_EPC].Text == epcstr_list[index][5]) && (viewitem.SubItems[listView_md_epc_DevID].Text == ListDeviceIdstr) && (viewitem.SubItems[listView_md_epc_AntID].Text == epcstr_list[index][4]) && (viewitem.SubItems[listView_md_epc_TID].Text == epcstr_list[index][13]))
                            {
                                viewitem.SubItems[listView_md_epc_Count].Text = epcstr_list[index][11];
                                viewitem.SubItems[listView_md_epc_Last_Time].Text = epcstr_list[index][12];
                                viewitem.SubItems[listView_md_epc_Rssi].Text = epcstr_list[index][7];
                                viewitem.SubItems[listView_md_epc_Direction].Text = epcstr_list[index][9];
                                viewitem.SubItems[listView_md_epc_Temp].Text = epcstr_list[index][14];
                                Exist = true;
                                break;
                            }
                        }

                      //  CurrentCacheItemsSource.Clear();

                        listView_md_epc.VirtualListSize = CurrentCacheItemsSource.Count;
                        listView_md_epc.Invalidate();

                        if (!Exist)
                        {
                            ListViewItem item = new ListViewItem((this.listView_md_epc.Items.Count + 1).ToString("D6"));

                            item.SubItems.Add(epcstr_list[index][4]);
                            item.SubItems.Add(epcstr_list[index][5]);
                            item.SubItems.Add(epcstr_list[index][6]);
                            item.SubItems.Add(epcstr_list[index][7]);
                            item.SubItems.Add(epcstr_list[index][11]);

                            if (radioButtonModuleTest.Checked == true) item.SubItems.Add(epcstr_list[index][0]);
                            else
                            {
                                ListDeviceIdstr = PrivateStringFormat.shortTolongNum(epcstr_list[index][0]);

                                string bz_str = "";
                                if (ListDeviceIdstr.Length < 15)
                                {
                                    int bz_len = 15 - ListDeviceIdstr.Length;

                                    for (int i = 0; i < bz_len; i++)
                                    {
                                        bz_str += "0";
                                    }

                                    ListDeviceIdstr = ListDeviceIdstr.Substring(0, 2) + bz_str + ListDeviceIdstr.Substring(2, 11);
                                }
                                item.SubItems.Add(ListDeviceIdstr);
                            }
                            item.SubItems.Add(epcstr_list[index][12]);
                            item.SubItems.Add(epcstr_list[index][9]);
                            item.SubItems.Add(epcstr_list[index][14]); // 温度
                            item.SubItems.Add(epcstr_list[index][13]);

                            CurrentCacheItemsSource.Add(item);

                            //Insert To DB 
                            var tracking = new Tracking()
                            {
                                Num = (this.listView_md_epc.Items.Count + 1).ToString(),
                                AntID = epcstr_list[index][4],
                                EPC = epcstr_list[index][5],
                                PC = epcstr_list[index][6],
                                RSSI = epcstr_list[index][7],
                                Count = epcstr_list[index][11],
                                DevID = (radioButtonModuleTest.Checked == true) ? epcstr_list[index][0] : ListDeviceIdstr,
                                CreatedDateTime = DateTime.Now,
                                Dir = epcstr_list[index][9],
                                IsSame = epcstr_list[index][14],
                                TID = epcstr_list[index][13]
                            };

                            _trackingDal.Insert(tracking);
                
                            listView_md_epc.VirtualListSize = CurrentCacheItemsSource.Count;
                            listView_md_epc.Invalidate();

                            this.listView_md_epc.Items[this.listView_md_epc.Items.Count - 1].EnsureVisible();
                        }


                    
                }



                //插入数据到excel
                if (ShowEPCStyle == Types.TRIGGER_DISPLAY)
                {
                    for (int index = 0; index < epcstr_list.Count; index++)             //清除已经显示的数据
                    {
                        if (epcstr_list[index][14] == temflag)
                        {
                            epcstr_list.RemoveAt(index);
                        }
                    }
                }
                else if (ShowEPCStyle == Types.TIMING_DISPLAY)
                {
                    epcstr_list.Clear();
                }
                if (totalnum1 != 0)
                {
                    label26_total.Text = listView_md_epc.Items.Count.ToString();
                }
            }
            }

            this.listView_md_epc.EndUpdate();
        }

        /// <summary>
        /// 循环查询EPC累计显示
        /// </summary>
        private void UpdateEpcAddOld(object e)
        {
            this.listView_md_epc.BeginUpdate();

            # region  时间字体显示
            long totalnum1 = 0;

#if CN
            LabelCurrentTime.Text = "时      间";
#endif

#if ENGLISH
            LabelCurrentTime.Text = "Time";
#endif

            #endregion

            string ListDeviceIdstr = "";

            lock (epcstr_list)
            {
                lock (CurrentCacheItemsSource)
                {
                for (int index = 0; index < epcstr_list.Count; index++)
                {
                    try
                    {
                        ListDeviceIdstr = epcstr_list[index][0];
                        if (ListDeviceIdstr != "")
                        {
                            ListDeviceIdstr = PrivateStringFormat.shortTolongNum(epcstr_list[index][0]);

                            string bz_str = "";
                            if (ListDeviceIdstr.Length < 15)
                            {
                                int bz_len = 15 - ListDeviceIdstr.Length;

                                for (int i = 0; i < bz_len; i++)
                                {
                                    bz_str += "0";
                                }

                                ListDeviceIdstr = ListDeviceIdstr.Substring(0, 2) + bz_str + ListDeviceIdstr.Substring(2, 11);
                            }
                        }

                        if (NoAnt.Checked == true)
                        {
                            if ((CurrentCacheItemsSource[index].SubItems[2].Text == epcstr_list[index][5]) && (CurrentCacheItemsSource[index].SubItems[6].Text == ListDeviceIdstr))
                            {
                                CurrentCacheItemsSource[index].SubItems[5].Text = epcstr_list[index][11];
                                CurrentCacheItemsSource[index].SubItems[7].Text = epcstr_list[index][12];
                                CurrentCacheItemsSource[index].SubItems[4].Text = epcstr_list[index][7];
                                CurrentCacheItemsSource[index].SubItems[8].Text = epcstr_list[index][9];
                                //CurrentCacheItemsSource[index].SubItems[9].Text = epcstr_list[index][14];
                            }
                        }
                        else
                        {
                            if ((CurrentCacheItemsSource[index].SubItems[2].Text == epcstr_list[index][5]) && (CurrentCacheItemsSource[index].SubItems[6].Text == ListDeviceIdstr) && (CurrentCacheItemsSource[index].SubItems[1].Text == epcstr_list[index][4]))
                            {
                                CurrentCacheItemsSource[index].SubItems[5].Text = epcstr_list[index][11];
                                CurrentCacheItemsSource[index].SubItems[7].Text = epcstr_list[index][12];
                                CurrentCacheItemsSource[index].SubItems[4].Text = epcstr_list[index][7];
                                CurrentCacheItemsSource[index].SubItems[8].Text = epcstr_list[index][9];
                                // CurrentCacheItemsSource[index].SubItems[8].Text = epcstr_list[index][14];   // Temp 
                            }
                        }


                        listView_md_epc.VirtualListSize = CurrentCacheItemsSource.Count;
                        listView_md_epc.Invalidate();

                        this.listView_md_epc.Items[this.listView_md_epc.Items.Count - 1].EnsureVisible();
                    }
                    catch
                    {
                        ListViewItem item = new ListViewItem((this.listView_md_epc.Items.Count + 1).ToString("D6"));

                        item.SubItems.Add(epcstr_list[index][4]);
                        item.SubItems.Add(epcstr_list[index][5]);
                        item.SubItems.Add(epcstr_list[index][6]);
                        item.SubItems.Add(epcstr_list[index][7]);

                        item.SubItems.Add(epcstr_list[index][11]);
                        if (radioButtonModuleTest.Checked == true) item.SubItems.Add(epcstr_list[index][0]);
                        else
                        {
                            ListDeviceIdstr = PrivateStringFormat.shortTolongNum(epcstr_list[index][0]);

                            string bz_str = "";
                            if (ListDeviceIdstr.Length < 15)
                            {
                                int bz_len = 15 - ListDeviceIdstr.Length;

                                for (int i = 0; i < bz_len; i++)
                                {
                                    bz_str += "0";
                                }

                                ListDeviceIdstr = ListDeviceIdstr.Substring(0, 2) + bz_str + ListDeviceIdstr.Substring(2, 11);
                            }
                            item.SubItems.Add(ListDeviceIdstr);
                        }
                        item.SubItems.Add(epcstr_list[index][12]);
                        item.SubItems.Add(epcstr_list[index][9]);
                        item.SubItems.Add(""); // 温度
                        item.SubItems.Add(epcstr_list[index][13]);

                        CurrentCacheItemsSource.Add(item);

                        listView_md_epc.VirtualListSize = CurrentCacheItemsSource.Count;
                        listView_md_epc.Invalidate();

                        this.listView_md_epc.Items[this.listView_md_epc.Items.Count - 1].EnsureVisible();
                    }
                }


                if (listView_md_epc.Items.Count != 0)
                {
                    label26_total.Text = listView_md_epc.Items.Count.ToString();
                }
            }
            }

            this.listView_md_epc.EndUpdate();
        }

        private void UpdateEpcAdd(object e)
        {
          // this.listView_md_epc.BeginUpdate();

            # region  时间字体显示
            long totalnum1 = 0;

#if CN
            LabelCurrentTime.Text = "时      间";
#endif

#if ENGLISH
            LabelCurrentTime.Text = "Time";
#endif

            #endregion

            string ListDeviceIdstr = "";

            lock (epcstr_list)
            {
                for (int index = 0; index < epcstr_list.Count; index++)
                {
                    bool Exist = false;

                    ListDeviceIdstr = epcstr_list[index][0];
                    if (ListDeviceIdstr != "")
                    {
                        ListDeviceIdstr = PrivateStringFormat.shortTolongNum(epcstr_list[index][0]);

                        string bz_str = "";
                        if (ListDeviceIdstr.Length < 15)
                        {
                            int bz_len = 15 - ListDeviceIdstr.Length;

                            for (int i = 0; i < bz_len; i++)
                            {
                                bz_str += "0";
                            }

                            ListDeviceIdstr = ListDeviceIdstr.Substring(0, 2) + bz_str + ListDeviceIdstr.Substring(2, 11);
                        }
                    }

                    if (NoAnt.Checked == true)
                    {
                        foreach (ListViewItem viewitem in this.CurrentCacheItemsSource)
                        {
                            if ((viewitem.SubItems[listView_md_epc_EPC].Text == epcstr_list[index][5]) && (viewitem.SubItems[listView_md_epc_DevID].Text == ListDeviceIdstr) && (viewitem.SubItems[listView_md_epc_TID].Text == epcstr_list[index][13]))
                            {
                                viewitem.SubItems[listView_md_epc_Count].Text = epcstr_list[index][11];
                                viewitem.SubItems[listView_md_epc_Last_Time].Text = epcstr_list[index][12];
                                viewitem.SubItems[listView_md_epc_Rssi].Text = epcstr_list[index][7];
                                viewitem.SubItems[listView_md_epc_Direction].Text = epcstr_list[index][9];
                                viewitem.SubItems[listView_md_epc_Temp].Text = epcstr_list[index][14];
                                Exist = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        foreach (ListViewItem viewitem in this.CurrentCacheItemsSource)
                        {
                            if ((viewitem.SubItems[listView_md_epc_EPC].Text == epcstr_list[index][5]) && (viewitem.SubItems[listView_md_epc_DevID].Text == ListDeviceIdstr) && (viewitem.SubItems[listView_md_epc_AntID].Text == epcstr_list[index][4]) && (viewitem.SubItems[listView_md_epc_TID].Text == epcstr_list[index][13]))
                            {
                                viewitem.SubItems[listView_md_epc_Count].Text = epcstr_list[index][11];
                                viewitem.SubItems[listView_md_epc_Last_Time].Text = epcstr_list[index][12];
                                viewitem.SubItems[listView_md_epc_Rssi].Text = epcstr_list[index][7];
                                viewitem.SubItems[listView_md_epc_Direction].Text = epcstr_list[index][9];
                                viewitem.SubItems[listView_md_epc_Temp].Text = epcstr_list[index][14];
                                Exist = true;
                                break;
                            }
                        }
                    }


                    listView_md_epc.VirtualListSize = CurrentCacheItemsSource.Count;
                    listView_md_epc.Invalidate();

                    if (!Exist)
                    {
                        ListViewItem item = new ListViewItem((this.listView_md_epc.Items.Count + 1).ToString("D6"));

                        item.SubItems.Add(epcstr_list[index][4]);
                        item.SubItems.Add(epcstr_list[index][5]);
                        item.SubItems.Add(epcstr_list[index][6]);
                        item.SubItems.Add(epcstr_list[index][7]);

                        item.SubItems.Add(epcstr_list[index][11]);
                        if (radioButtonModuleTest.Checked == true) item.SubItems.Add(epcstr_list[index][0]);
                        else
                        {
                            ListDeviceIdstr = PrivateStringFormat.shortTolongNum(epcstr_list[index][0]);

                            string bz_str = "";
                            if (ListDeviceIdstr.Length < 15)
                            {
                                int bz_len = 15 - ListDeviceIdstr.Length;

                                for (int i = 0; i < bz_len; i++)
                                {
                                    bz_str += "0";
                                }

                                ListDeviceIdstr = ListDeviceIdstr.Substring(0, 2) + bz_str + ListDeviceIdstr.Substring(2, 11);
                            }
                            item.SubItems.Add(ListDeviceIdstr);
                        }
                        item.SubItems.Add(epcstr_list[index][12]);
                        item.SubItems.Add(epcstr_list[index][9]);
                        item.SubItems.Add(epcstr_list[index][14]); // 温度
                        item.SubItems.Add(epcstr_list[index][13]);

                        CurrentCacheItemsSource.Add(item);

                        listView_md_epc.VirtualListSize = CurrentCacheItemsSource.Count;
                        listView_md_epc.Invalidate();

                        this.listView_md_epc.Items[this.listView_md_epc.Items.Count - 1].EnsureVisible();
                    }
                }


                if (listView_md_epc.Items.Count != 0)
                {
                    label26_total.Text = listView_md_epc.Items.Count.ToString();
                }
            }

          //  this.listView_md_epc.EndUpdate();
        }
        //把标签EPC数据插入数据库
        private void InsertDatabase(string epc, long count, byte ant_id, string dev, short rssi, byte dir)
        {
            // string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            // sql.insert(currentTable, time, epc, dir, count, dev, rssi, ant_id);
        }


        public void Remove(object sender, EventArgs e)
        {
            button_md_clear_Click(sender, (EventArgs)e);
        }


        public void button_md_clear_Click(object sender, EventArgs e)
        {
            listView_md_epc.VirtualListSize = 0;

            this.ItemsSource.Clear();
            this.CurrentCacheItemsSource.Clear();
            this.Refresh();
           // MonitorTime = 1;
            epcstr_list.Clear();
            listView_md_epc.Items.Clear();
            EpctotalnumBack = 0;
            label26_total.Text = "0";
            if (!isRFIDTimerStart)LabelCurrentTimes.Text = "0";
            label8.Text = "0";
            if (isLogOpen)
            {
                EventLog.WriteEvent("清除数据成功", null);
            }
        }

        private delegate void mcListviewDelegate(int index, string text);
        private void mcListviewUpdate(int index, string text)
        {
            if (listView_md_addr.InvokeRequired)
            {
                mcListviewDelegate d = new mcListviewDelegate(mcListviewUpdate);
                listView_md_addr.Invoke(d, new object[] { index, text });
            }
            else
            {
                //int idx = Int32.Parse(index);
                listView_md_addr.Items[index].SubItems[listView_md_State].Text = text;
            }
        }




        private ushort calculate_pc(string str_epc)
        {
            ushort temp_pc = (ushort)str_epc.Length;
            temp_pc /= 4;
            temp_pc <<= 11;
            temp_pc &= 0xF800;

            return temp_pc;
        }


        private void hex2asc(string hexStr, byte[] ascStr, ref byte ascLen)
        {
            byte i;
            byte uc;

            if ((hexStr.Length % 2) != 0)
            {
                hexStr += "0";
            }

            for (i = 0; i < hexStr.Length; i++)
            {
                uc = (byte)hexStr[i];
                if (uc >= 0x30 && uc <= 0x39)
                    uc -= 0x30;
                else if (uc >= 0x41 && uc <= 0x46)
                    uc -= 0x37;
                else if (uc >= 0x61 && uc <= 0x66)
                    uc -= 0x57;
                else
                    break;
                if (i % 2 == 1)
                {
                    ascStr[(i - 1) / 2] = (byte)(ascStr[(i - 1) / 2] | uc);
                    ++ascLen;
                }
                else
                    ascStr[i / 2] = (byte)(uc << 4);
            }
        }

        private void HexToDec(string shex, ref uint idec)
        {
            int len = 8;
            int mid = 0;
            idec = 0;
            for (int i = 0; i < len; i++)
            {
                if (shex[i] >= '0' && shex[i] <= '9')
                    mid = shex[i] - '0';
                else if (shex[i] >= 'a' && shex[i] <= 'f')
                    mid = shex[i] - 'a' + 10;
                else if (shex[i] >= 'A' && shex[i] <= 'F')
                    mid = shex[i] - 'A' + 10;

                mid <<= ((len - i - 1) << 2);
                idec |= (uint)mid;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {


        }

        private void radioButton_device_server_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton_device_client_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void listView_net_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private int cur_pitch = 0;
        private void button_modules_search_Click(object sender, EventArgs e)
        {

        }



        private void listView_net_DoubleClick(object sender, EventArgs e)
        {

        }

        private void button_module_set_Click(object sender, EventArgs e)
        {

        }



        private void button_set_ant_Click(object sender, EventArgs e)
        {


        }



        private void set_ant_worktime()
        {

        }






        private void Get_ant_mes_Click(object sender, EventArgs e)
        {
            try
            {
                ReaderControllor.GetWorkAnt(currentclient);
                Thread.Sleep(500);
                ReaderControllor.GetWorkTime(currentclient);
            }
            catch (Exception ex)
            {
                UpdateLog(ex.ToString());
            }

        }

        private void button_power_get_Click(object sender, EventArgs e)
        {
            try
            {
                ReaderControllor.GetPower(currentclient);
            }
            catch (Exception ex)
            {
                UpdateLog(ex.ToString());
            }
        }

        private void button_power_set_Click(object sender, EventArgs e)
        {


        }

        private void button1_get_temperature_Click(object sender, EventArgs e)
        {
            try
            {
                ReaderControllor.GetTemperature(currentclient);
            }
            catch (Exception ex)
            {
                UpdateLog(ex.ToString());
            }

        }

        private void button_gpio_get_Click(object sender, EventArgs e)
        {

        }

        private void button_gpio_set_Click(object sender, EventArgs e)
        {

        }

        private void button_get_region_Click(object sender, EventArgs e)
        {
            try
            {
                ReaderControllor.GetFrequencyArea(currentclient);

            }
            catch (Exception ex)
            {
                UpdateLog(ex.ToString());
            }
        }

        private void button_set_region_Click(object sender, EventArgs e)
        {

        }

        private void button_create_fp_Click(object sender, EventArgs e)
        {

        }

        private void button_fp_example_Click(object sender, EventArgs e)
        {

        }

        private void button_fp_clear_Click(object sender, EventArgs e)
        {

        }

        private void button_get_fp_Click(object sender, EventArgs e)
        {
            try
            {
                ReaderControllor.GetFrequencyPoints(currentclient);
            }
            catch (Exception ex)
            {
                UpdateLog(ex.ToString());
            }

        }

        private void button_set_fp_Click(object sender, EventArgs e)
        {

        }



        private void button_lock_Click(object sender, EventArgs e)
        {

        }

        private void _lock_mask(ref byte mask, ref byte action)
        {

        }

        private void button_kill_Click(object sender, EventArgs e)
        {


        }

        private void radioButton_module_is_server_CheckedChanged(object sender, EventArgs e)
        {
            //textBox_connect_ip.Text = "";
            /*   textBox_md_ip.Enabled = true;
               textBox_md_ip.Text = "";
               btn_Client.Enabled = false;
               btn_connect.Enabled = true;
               button_md_start.Enabled = true;*/
            //label_connect_ip.Text = "Reader IP :";
        }

        private void radioButton_module_is_client_CheckedChanged(object sender, EventArgs e)
        {

            /* string hostName = Dns.GetHostName();//本机名   
             System.Net.IPAddress[] addressList = Dns.GetHostAddresses(hostName);//会返回所有地址，包括IPv4和IPv6
             string host_ip = addressList[1].ToString();
             textBox_md_ip.Text = host_ip;
             textBox_md_ip.Enabled = false;
             btn_Client.Enabled = true;
             btn_connect.Enabled = false;
             button_md_start.Enabled = false;*/

            //label_connect_ip.Text = "Server IP :";
        }


        //protected string GetIP()   //获取本地IP 
        //{
        //    string hostname = Dns.GetHostName();//得到本机名   
        //    //IPHostEntry localhost = Dns.GetHostByName(hostname);//方法已过期，只得到IPv4的地址  
        //    IPHostEntry localhost = Dns.GetHostEntry(hostname);
        //    IPAddress localaddr = localhost.AddressList[0];
        //    return localaddr.ToString();
        //}
        private static Socket serverSocket;





        const string CONNECT_CLIENT = "连接客户端"; //Query
        const string CLOSE_CLIENT = "断开客户端"; //Stop





        private void Close_As_Server()
        {
            byte[] send_buffer = new byte[6];
            send_buffer[0] = 0xBB;
            send_buffer[1] = 0x18;
            send_buffer[2] = 0x00;
            send_buffer[3] = 0x18;
            send_buffer[4] = 0x0D;
            send_buffer[5] = 0x0A;


        }

        private void tabScan_Click(object sender, EventArgs e)
        {

        }

        private void groupBox_multidevice_Enter(object sender, EventArgs e)
        {

        }
        private void button_data_read_Click(object sender, EventArgs e)
        {
        }


        private void button4_Click(object sender, EventArgs e)
        {

        }

        bool serverisstart = false;
        private void connect_b_Click(object sender, EventArgs e)
        {
                if (connect_b.Text == start)
                {
                    try
                    {
                        string dev_ip = comboBox1.Text.ToString();
                        int port = int.Parse(reader_port_tb.Text);
                        IPAddress ipaddress = IPAddress.Parse(dev_ip);
                        if (ReaderControllor.ServerStart(ipaddress, port))
                        {
                            connect_b.Text = stop;
                            serverisstart = true;
                            keepalive.Enabled = true;               //模块循环读取EPC时发送查询数据会使模块停止工作
                            if ((serialisstart || serverisstart) && ((_IsActiveDatabaseWork) || (_IsRfidDatabaseWork) || (_IsCommandDatabaseWork)))
                            {
                                timer_md_query_Tick.Enabled = true;
                            }
                            TimerShowID.Enabled = true;
                            show_EPC_t.Enabled = true;

                            UpdateLog(creatserver + success);
                            if (isLogOpen)
                            {
                                EventLog.WriteEvent(creatserver + success, null);
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        UpdateLog(Invalid);
                        if (isLogOpen)
                            ErrorLog.WriteError(Invalid);
                    }

                }
                else
                {

                    ReaderControllor.ServerClose();                   //关闭服务器
                    connect_b.Text = start;
                    serverisstart = false;
                    if (!serverisstart && serialisstart)
                    {
                        timer_md_query_Tick.Enabled = false;
                        TimerShowID.Enabled = false;
                        show_EPC_t.Enabled = false;

                    }
                    keepalive.Enabled = false;
                    UpdateLog(closeserver + success);
                    if (isLogOpen)
                        EventLog.WriteEvent(closeserver + success, null);
                }

        }

        private const int dev_num = 0;
        private const int dev_IP = 1;
        private const int dev_port = 2;
        private const int dev_state = 3;
        //每一秒钟刷新一次


        int count_jm = 0; // Tabcontrol更新变量
        int count_ip = 0; // Tabcontrol更新变量

        int int_tab = 0; // 同设备网口串口切换变量 ---无源
        int int_tab_hy = 0; //同设备网口串口切换变量 ---有源

        public bool IsHaveYuan = false; // 无源有源标志[默认无源]

        int StopRead = 0;//停止读标判断变量

        private  void timer_scan_Tick(object sender, EventArgs e)
        {
            listView_md_addr.Items.Clear();
            clients = ReaderControllor.GetClientInfo();
            if (clients.Count == 1)                          //只有一台连接的时候直接默认选择这一台
            {
                CustomControl.WorkingReader = currentclient = clients[0];
                if (currentclient.types == connect.net)
                {                    
                    currentDev_l.Text = "Device:" + PrivateStringFormat.shortTolongNum(currentclient.dev); // + currentclient.dev;
                }
                else
                {
                   // currentDev_l.Text = "Device:" + currentclient.com;
                    currentDev_l.Text = "Device:" + COM_DevID;
                }

            }
          //  AsyncSocketState client = ;
            //foreach (AsyncSocketState client in clients)
            for (int i = 0; i < clients.Count;i++)
            {
                
                AsyncSocketState client = clients[i];
                ListViewItem item = new ListViewItem((this.listView_md_addr.Items.Count + 1).ToString());
                if (client.types == connect.net)
                {
                    item.SubItems.Add(client.ip_addr);
                    item.SubItems.Add(client.port);
                    string devid = "";
                    if (client.dev == null)
                    {
                        item.SubItems.Add((client.dev));
                    }
                    else
                    {

                        string bz_str = "";
                         devid = PrivateStringFormat.shortTolongNum(client.dev);
                        if (devid.Length < 15)
                        {
                            int bz_len = 15 - devid.Length;

                            for (int k = 0; k < bz_len; k++)
                            {
                                bz_str += "0";
                            }

                            devid = devid.Substring(0, 2) + bz_str + devid.Substring(2, 11);
                        }


                        item.SubItems.Add(devid);
                    }
                    item.SubItems.Add(client.state);

                    //整机模块后加区分
                    if (devid == "")
                    {
                        if (this.radioButtonModuleTest.Checked != true)
                        {
                            this.radioButtonModuleTest.Checked = true;
                            ReaderControllor.cmd._CommandType = 0;
                        }
                    }
                    else
                    {
                        if (this.radioButtonMachineTest.Checked != true)
                        {
                            this.radioButtonMachineTest.Checked = true;
                            ReaderControllor.cmd._CommandType = 1;
                        }
                    }


#if Module
                    if (count_ip == 0)
                    {
                        ReaderControllor.GetFirmVersion(client);
                    }

                    if (client.state == "OK")
                    {

                        string aa = MoudleBB;

                        if (count_ip == 0)
                        {
                            if (aa != "")
                            {
                                aa = MoudleBB.Substring(1, 3);

                                Maintable.Visible = true;
                                MultiFunctionMode.Visible = true;

                                if (aa == "2.0" || aa == "2.1" || aa == "2.2")
                                {

                                    if (int_tab_hy == 0)
                                    {
                                        Maintable.TabPages[0].Parent = null;
                                        treeView1.Nodes[1].Remove();
                                        int_tab_hy++;
                                    }
                                    label11.Visible = true;
                                    LabelIDCounts.Visible = true;
                                    label9.Visible = true;
                                    LabelIDSpeed.Visible = true;
                                    label10.Visible = true;
                                    label3.Visible = true;
                                    LabelIDTime.Visible = true;
                                    label1.Visible = true;

                                    IsHaveYuan = true;  // 当前为有源设备

                                    count_ip++;
                                }
                                else 
                                {
                                    if (int_tab == 0)
                                    {
                                        Maintable.TabPages[1].Parent = null;
                                        int_tab++;
                                    }
                                    label25.Visible = true;
                                    label26_total.Visible = true;
                                    LabelCurrentTime.Visible = true;
                                    LabelCurrentTimes.Visible = true;
                                    label7.Visible = true;
                                    label8.Visible = true;
                                    label2.Visible = true;
                                    count_ip++;
                                }
                            }
                            else if (dev_version != "")
                            {

                                Maintable.Visible = true;
                                MultiFunctionMode.Visible = true;

                                if (dev_version == "F1")
                                {

                                    if (int_tab_hy == 0)
                                    {
                                        Maintable.TabPages[0].Parent = null;
                                        treeView1.Nodes[1].Remove();
                                        int_tab_hy++;
                                    }
                                    label11.Visible = true;
                                    LabelIDCounts.Visible = true;
                                    label9.Visible = true;
                                    LabelIDSpeed.Visible = true;
                                    label10.Visible = true;
                                    label3.Visible = true;
                                    LabelIDTime.Visible = true;
                                    label1.Visible = true;

                                    IsHaveYuan = true;  // 当前为有源设备

                                    count_ip++;
                                }
                                else if (dev_version == "97")
                                {
                                    if (int_tab == 0)
                                    {
                                        Maintable.TabPages[1].Parent = null;
                                        int_tab++;
                                    }
                                    label25.Visible = true;
                                    label26_total.Visible = true;
                                    LabelCurrentTime.Visible = true;
                                    LabelCurrentTimes.Visible = true;
                                    label7.Visible = true;
                                    label8.Visible = true;
                                    label2.Visible = true;
                                    count_ip++;
                                }
                            }
                        }
                    }
#endif
                    if (_clientConnecteds.Any(_=>_.ClientIP == client.ip_addr && _.Port == int.Parse(client.port)) == false) 
                    {
                        var trackingClient = new TrackingClient();
                        trackingClient.ClientIP = client.ip_addr;
                        trackingClient.Port = int.Parse(client.port);
                        trackingClient.DeviceID = devid;
                        trackingClient.Status = client.state;

                        _trackingClientDal.Insert(trackingClient);

                        _clientConnecteds.Add(trackingClient);
                    }
                    //this.listView_md_addr.Items.Add(item);
                    //this.listView_md_addr.Items[this.listView_md_addr.Items.Count - 1].EnsureVisible();
                }
                else if (client.types == connect.com)
                {
#if Module
                    if (count_jm == 0)
                    {
                        ReaderControllor.GetFirmVersion(client);
                    }
#endif
                    item.SubItems.Add(client.com);
                    item.SubItems.Add(" -- ");

                    item.SubItems.Add(COM_DevID);

                    //整机模块后加区分
                    if (COM_DevID == "")
                    {
                        if (this.radioButtonModuleTest.Checked != true)
                        {
                            this.radioButtonModuleTest.Checked = true;
                            ReaderControllor.cmd._CommandType = 0;
                        }
                    }
                    else
                    {
                        if (this.radioButtonMachineTest.Checked != true)
                        {
                            this.radioButtonMachineTest.Checked = true;
                            ReaderControllor.cmd._CommandType = 1;
                        }
                    }


                    if (client.dev == null)
                    {
                        item.SubItems.Add((""));
                    }
                    else
                    {
                        string bz_str = "";
                        string devid = PrivateStringFormat.shortTolongNum(client.dev);
                        if (devid.Length < 15)
                        {
                            int bz_len = 15 - devid.Length;

                            for (int k = 0; k < bz_len; k++)
                            {
                                bz_str += "0";
                            }

                            devid = devid.Substring(0, 2) + bz_str + devid.Substring(2, 11);
                        }


                        item.SubItems.Add(devid);
                    }
                    item.SubItems.Add(client.state);
                    this.listView_md_addr.Items.Add(item);


#if Module
                    string aa = MoudleBB;

                    if (count_jm == 0)
                    {
                        if (aa != "")
                        {
                            aa = MoudleBB.Substring(1, 3);

                            Maintable.Visible = true;
                            MultiFunctionMode.Visible = true;

                            if (aa == "2.0" || aa == "2.1" || aa == "2.2")
                            {
                                if (int_tab_hy == 0)
                                {
                                    Maintable.TabPages[0].Parent = null;
                                    treeView1.Nodes[1].Remove();
                                    int_tab_hy++;
                                }
                                label11.Visible = true;
                                LabelIDCounts.Visible = true;
                                label9.Visible = true;
                                LabelIDSpeed.Visible = true;
                                label10.Visible = true;
                                label3.Visible = true;
                                LabelIDTime.Visible = true;
                                label1.Visible = true;

                                IsHaveYuan = true;  // 当前为有源设备

                                count_jm++;
                            }
                            else
                            {
                                if (int_tab == 0)
                                {
                                    Maintable.TabPages[1].Parent = null;
                                    int_tab++;
                                }
                                label25.Visible = true;
                                label26_total.Visible = true;
                                //  label12.Visible = true;
                                //  labelReaderReportEpcCounts.Visible = true;
                                LabelCurrentTime.Visible = true;
                                LabelCurrentTimes.Visible = true;
                                label7.Visible = true;
                                label8.Visible = true;
                                label2.Visible = true;

                                count_jm++;
                            }
                        }
                        else if (dev_version != "")
                        {
                            Maintable.Visible = true;
                            MultiFunctionMode.Visible = true;

                            if (dev_version == "F1")
                            {

                                if (int_tab_hy == 0)
                                {
                                    Maintable.TabPages[0].Parent = null;
                                    treeView1.Nodes[1].Remove();
                                    int_tab_hy++;
                                }
                                label11.Visible = true;
                                LabelIDCounts.Visible = true;
                                label9.Visible = true;
                                LabelIDSpeed.Visible = true;
                                label10.Visible = true;
                                label3.Visible = true;
                                LabelIDTime.Visible = true;
                                label1.Visible = true;

                                IsHaveYuan = true;  // 当前为有源设备

                                count_jm++;
                            }
                            else if (dev_version == "97")
                            {
                                if (int_tab == 0)
                                {
                                    Maintable.TabPages[1].Parent = null;
                                    int_tab++;
                                }
                                label25.Visible = true;
                                label26_total.Visible = true;
                                LabelCurrentTime.Visible = true;
                                LabelCurrentTimes.Visible = true;
                                label7.Visible = true;
                                label8.Visible = true;
                                label2.Visible = true;
                                count_jm++;
                            }
                        }
                    }

#endif

                    this.listView_md_addr.Items[this.listView_md_addr.Items.Count - 1].EnsureVisible();
                }
            } //=========foreach结束

            if (clients.Any())
            {
                var index = 1;
                foreach (var trackingClient in _clientConnecteds)
                {
                    var listViewItem = new ListViewItem(index.ToString());
                    listViewItem.Text = index.ToString();
                    listViewItem.SubItems.Add(trackingClient.ClientNo);
                    listViewItem.SubItems.Add(trackingClient.ClientIP);
                    listViewItem.SubItems.Add(trackingClient.Port.ToString());
                    listViewItem.SubItems.Add(trackingClient.DeviceID);
                    listViewItem.SubItems.Add(trackingClient.Status);
                    this.listView_md_addr.Items.Add(listViewItem);
                    this.listView_md_addr.Items[this.listView_md_addr.Items.Count - 1].EnsureVisible();

                    index++;
                }
            }

        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabSet_Click(object sender, EventArgs e)
        {

        }

        private AsyncSocketState currentclient;
        public AsyncSocketState CurrentClient
        {
            get { return currentclient; }
            set { }
        }
        private void listView_md_addr_DoubleClick(object sender, EventArgs e)
        {

        }

        private void Hard_Version_get_b_Click(object sender, EventArgs e)
        {
            try
            {
                ReaderControllor.GetHardVersion(currentclient);
                Thread.Sleep(1000);
                ReaderControllor.GetFirmVersion(currentclient);
            }
            catch (Exception ex)
            {
                UpdateLog(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReaderControllor.model.HardVersion = "1.1.1";
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            try
            {
                ReaderControllor.GetFastID(currentclient);
            }
            catch (Exception ex)
            {
                UpdateLog(ex.ToString());
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void tabComm_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                ReaderControllor.GetGen2(currentclient);
            }
            catch (Exception ex)
            {
                UpdateLog(ex.ToString());
            }
        }

        private void groupBox_gpio_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {



        }

        private void button7_Click(object sender, EventArgs e)
        {



        }

        private void button8_Click(object sender, EventArgs e)
        {
            ReaderControllor.UpdataInformation();
            UpdateLog(fresh);
        }

        private string portname = "";
        private int baudRate = 115200;
        private int dataBits = 8;
        private Parity parity = Parity.None;
        private StopBits stopbits = StopBits.One;

        private void button9_Click(object sender, EventArgs e)
        {
            SerialPortParameter SerialPortForm = new SerialPortParameter();
            SerialPortForm.LanguagedChanged();
            SerialPortForm.ShowDialog();
            if (SerialPortForm.result == true)
            {
                comboBox7.Text = SerialPortForm.PortName;
                portname = comboBox7.Text;
                baudRate = SerialPortForm.BuadRate;
                dataBits = SerialPortForm.dataBits;
                parity = SerialPortForm.parity;
                stopbits = SerialPortForm.stopbits;
            }

        }

        bool serialisstart = false;
        private void button10_Click(object sender, EventArgs e)
        {
            if (PortOpen_b.Text == start)
            {
                portname = comboBox7.Text;
                try
                {
                    ReaderControllor.ComStart(portname, baudRate, dataBits, parity, stopbits);
                    // COM   115200   8  None   One
                    clients = ReaderControllor.GetClientInfo();                
                    foreach (AsyncSocketState client in clients)
                    {
                        ReaderControllor.GetMACDev(client);
                    }
          
                }
                catch (Exception ex)
                {
                    UpdateLog("Error:" + ex.ToString());
                    ErrorLog.WriteError(ex.ToString());
                    return;
                }
                serialisstart = true;
                if ((serialisstart || serverisstart) && ((_IsActiveDatabaseWork) || (_IsRfidDatabaseWork) || (_IsCommandDatabaseWork)))
                {
                    timer_md_query_Tick.Enabled = true;
                }
                TimerShowID.Enabled = true;
                show_EPC_t.Enabled = true;
             
                PortOpen_b.Text = stop;
                UpdateLog(openserial + success);
                EventLog.WriteEvent(openserial + success, null);
            }
            else
            {
                row = 0;
                serialisstart = false;
                ReaderControllor.SerialPortClose();
                PortOpen_b.Text = start;
                if (!serverisstart && serialisstart)
                {
                    TimerShowID.Enabled = false;
                    show_EPC_t.Enabled = false;
                
                    timer_md_query_Tick.Enabled = false;
                }
                UpdateLog(closeserial + success);
                EventLog.WriteEvent(closeserial + success, null);
            }

        }

        private void button10_Click_1(object sender, EventArgs e)
        {


        }

        private void button11_Click(object sender, EventArgs e)
        {


        }

        bool islisten = false;
/*
        private void button12_Click(object sender, EventArgs e)
        {

        }
*/
        private void keepalive_Tick(object sender, EventArgs e)
        {
            ReaderControllor.KeepAlive();
        }

        private void comboBox_mb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public static string languageType = "EN";
        private void button12_Click_1(object sender, EventArgs e)
        {
            //if (language_cb.SelectedIndex == 0)       //
            if (button12.Text == "中文")
            {
                languageType = "CN";
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CN");
                UpDataMainFormUILanguage();
                button12.Text = "English";
            }
            //else if (language_cb.SelectedIndex == 1)  //英文
            else if (button12.Text == "English")
            {
                languageType = "EN";
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                UpDataMainFormUILanguage();
                button12.Text = "中文";
            }
            if (this.treeView1.SelectedNode == null) return;
            if (treeView1.SelectedNode.Text.ToString() == lanWorkMode)
            {
                workModeView.LanguagedChanged();
            }
            else if (treeView1.SelectedNode.Text.ToString() == lanInfo)
            {
                communicationView.LanguagedChanged();
                simView.LanguagedChanged();
                wifiView.LanguagedChanged();
            }
            else if (treeView1.SelectedNode.Text.ToString() == lanMQTT)
            {
                mqtt.LanguagedChanged();
            }
            else if (treeView1.SelectedNode.Text.ToString() == lanFactory)
            {
                factory.LanguagedChanged();
            }
            else if (treeView1.SelectedNode.Text.ToString() == lanCommandTest1)
            {
                gpioView.LanguagedChanged();
                beep.LanguagedChanged();
            }
            else if (treeView1.SelectedNode.Text.ToString() == lanPower)
            {
                powerView.LanguagedChanged();
            }
            else if (treeView1.SelectedNode.Text.ToString() == lanFRequency)
            {
                frequencyAreaView.LanguagedChanged();
                frequencyPointView.LanguagedChanged();
            }
            else if (treeView1.SelectedNode.Text.ToString() == lanWorkAnt)
            {
                workAntView.LanguagedChanged();
            }
            else if (treeView1.SelectedNode.Text.ToString() == lanGen2)
            {
                gen2View.LanguagedChanged();
            }
            else if (treeView1.SelectedNode.Text.ToString() == lanFastID)
            {
                fastIDView.LanguagedChanged();
            }
            else if (treeView1.SelectedNode.Text.ToString() == lanTagfocus)
            {
                tagfocusView.LanguagedChanged();
            }
            else if (treeView1.SelectedNode.Text.ToString() == lanReadWrite)
            {
                tagAccessView.LanguagedChanged();
            }
            else if (treeView1.SelectedNode.Text.ToString() == lanQT)
            {
                qtView.LanguagedChanged();
            }
            else if (treeView1.SelectedNode.Text.ToString() == lanCommandTest2)
            {
                carrierview.LanguagedChanged();
                temperatureView.LanguagedChanged();
                ver.LanguagedChanged();
            }       
/*          else if (treeView1.SelectedNode.Text.ToString() == lanInit)
            {
                parameterInitView.LanguagedChanged();
            }
            else if (treeView1.SelectedNode.Text.ToString() == lanCommandTest3)
            {
                fliter.LanguagedChanged();
                activecarrier.LanguagedChanged();
            }
*/
            else
            {

            }
        }

        private void UpDataMainFormUILanguage()
        {
            ResourceManager rm = new ResourceManager(typeof(SrDemo));
            UpDataMainFormMenuLanguage(rm);                                 //更新界面
            UpDataInteractiveinformation(rm);                               //更新交互信息
            UpdateDisplayStyleBox();
        }

        public void UpdateDataDisplayModeBox()
        {
            ResourceManager rm = new ResourceManager(typeof(SrDemo));
            comboBoxshowIDType.Items.Clear();
            comboBoxshowIDType.Items.Add(rm.GetString("TotalDisp"));
            comboBoxshowIDType.Items.Add(rm.GetString("TimeDisp"));
            comboBoxshowIDType.SelectedIndex = 0;
        }

        private void UpDataMainFormMenuLanguage(ResourceManager rm)
        {
            refresh_b.Text = rm.GetString("Refresh");
            button9.Text = rm.GetString("Set");
            label20.Text = rm.GetString("Selectdev");
            groupBox_multidevice.Text = rm.GetString("Connect");
            label5.Text = rm.GetString("Mode_Serever");
            label6.Text = rm.GetString("Serialport");
            FilterCheckBox.Text = rm.GetString("Fliter");
            UpdateDataDisplayModeBox();
            if (serverisstart)
            {
                connect_b.Text = rm.GetString("Stop");
            }
            else
            {
                connect_b.Text = rm.GetString("Start");
            }
            if (serialisstart)
            {
                PortOpen_b.Text = rm.GetString("Stop");
            }
            else
            {
                PortOpen_b.Text = rm.GetString("Start");
            }


            //循环查询EPC界面
            button_md_start.Text = rm.GetString("OPMulti");
            allreader_cb.Text = rm.GetString("Inventory_Alldev");
            button_md_stop.Text = rm.GetString("Stop");
            button_md_clear.Text = rm.GetString("Inventory_ClearData");
            label25.Text = rm.GetString("Inventory_Count");
            singleEPC_rb.Text = rm.GetString("Inventory_Single");
            button1.Text = rm.GetString("StartReadTemp");
            button5.Text = rm.GetString("StopReadTemp");
           // LabelCurrentTime.Text = rm.GetString("Inventory_Time");
           // label7.Text = rm.GetString("Inventory_Speed");
            radioButtonModuleTest.Text = rm.GetString("Mode_Module");
            radioButtonMachineTest.Text = rm.GetString("CompleteMachine");
            testbtn.Text = rm.GetString("Test");
            buttonStartMonitor.Text = rm.GetString("StartTimer");
            button_time_fliecabinet.Text = rm.GetString("SetRefreshTime");
            label12.Text = rm.GetString("ReaderReportCount");
            label2.Text = rm.GetString("countsec");
            labletest.Text = rm.GetString("InternalTestUse");
            if(!isSimple) MultiFunctionMode.Text = rm.GetString("StreamlineMode");
            else MultiFunctionMode.Text = rm.GetString("MultiFunctionMode");
            page_quickstart.Text = rm.GetString("QuickStart");


            label7.Text = rm.GetString("Speed");
            // 多功能处(右上角语言切换)
            AntSetbutton.Text = rm.GetString("SetAnt");
            NoAnt.Text = rm.GetString("Noant");
            StartSaveExcel.Text = rm.GetString("SaveExcel");
            sourceDataSaveBt.Text = rm.GetString("SourceDataSav");
            SelectAntcheckBox1.Text = rm.GetString("Ant1");
            SelectAntcheckBox2.Text = rm.GetString("Ant2");
            SelectAntcheckBox3.Text = rm.GetString("Ant3");
            SelectAntcheckBox4.Text = rm.GetString("Ant4");


            //有源界面
            label9.Text = rm.GetString("Speed");
            label104.Text = rm.GetString("Reduce");
            label103.Text = rm.GetString("channel");
            label102.Text = rm.GetString("type");
            IsAutocheckBox.Text = rm.GetString("AutoRead");
            checkBox1.Text = rm.GetString("PoweroutagesSave");
            button31.Text = rm.GetString("Get");
            button32.Text = rm.GetString("Set");


//            NoAnt.Text = rm.GetString("Noant");
            //有源读写器盘存
            button3.Text = rm.GetString("Start");
            button4.Text = rm.GetString("Stop");
            button2.Text = rm.GetString("Inventory_ClearData");
            label4.Text = rm.GetString("DisplayMode");
            label11.Text = rm.GetString("counts");
            //label9.Text = rm.GetString("Inventory_Speed");
            label3.Text = rm.GetString("worktime");
            label10.Text = rm.GetString("countsec");
            if(!isTimerStart) buttonStartIDMonitor.Text = rm.GetString("StartTimer");
            else buttonStartIDMonitor.Text = rm.GetString("StopTimer");
            if(!isRFIDTimerStart) buttonStartMonitor.Text = rm.GetString("StartTimer");
            else buttonStartMonitor.Text = rm.GetString("StopTimer");

            //参数设置界面
            treeView1.Nodes["common"].Text = rm.GetString("GeneralParameters");
            lanWorkMode = treeView1.Nodes["common"].Nodes[0].Text = rm.GetString("WorkMode");
            lanInfo = treeView1.Nodes["common"].Nodes[1].Text = rm.GetString("CommunicationInformation");
            lanMQTT = treeView1.Nodes["common"].Nodes[2].Text = rm.GetString("mqtt");
            lanFactory = treeView1.Nodes["common"].Nodes[3].Text = rm.GetString("factoryset");
            lanCommandTest1 = treeView1.Nodes["common"].Nodes[4].Text = rm.GetString("Terminal")+rm.GetString("CommandTest");
            HEART = treeView1.Nodes["common"].Nodes[5].Text = rm.GetString("heart");
            treeView1.Nodes["rfid"].Text = rm.GetString("rfid");
            lanPower = treeView1.Nodes["rfid"].Nodes[0].Text = rm.GetString("Configure_Power");
            lanFRequency = treeView1.Nodes["rfid"].Nodes[1].Text = rm.GetString("frequency");
            lanWorkAnt = treeView1.Nodes["rfid"].Nodes[2].Text = rm.GetString("Configure_Ant");
            //lanGen2 = treeView1.Nodes["rfid"].Nodes[3].Text = rm.GetString("OPGen2");
            lanFastID = treeView1.Nodes["rfid"].Nodes[8].Text = rm.GetString("fastID");
            lanTagfocus = treeView1.Nodes["rfid"].Nodes[3].Text = rm.GetString("tagfocus");
            lanReadWrite = treeView1.Nodes["rfid"].Nodes[4].Text = rm.GetString("readwrite");
            lanQT = treeView1.Nodes["rfid"].Nodes[5].Text = rm.GetString("QTtag");
            lanCommandTest2 = treeView1.Nodes["rfid"].Nodes[6].Text = rm.GetString("Mode_Module") + rm.GetString("CommandTest");
            lanEPCAndTID = treeView1.Nodes["rfid"].Nodes[7].Text = rm.GetString("EPCAndTID");
            BatchTagAction = treeView1.Nodes["rfid"].Nodes[9].Text = rm.GetString("BatchTagAction");

            //treeView1.Nodes["rfid"].Nodes[10].Text = "Map";

//            lanInit = treeView1.Nodes["avtive"].Nodes[0].Text = rm.GetString("init");
//            lanCommandTest3 = treeView1.Nodes["avtive"].Nodes[1].Text = rm.GetString("ActiveModule") + rm.GetString("CommandTest");
//            treeView1.Nodes["avtive"].Text = rm.GetString("avtive");

         //   lanCommonTestOne = treeView1.Nodes["test"].Nodes[0].Text = rm.GetString("test1");
//            lanUHFTest = treeView1.Nodes["test"].Nodes[1].Text = rm.GetString("test2");
//            lanCommonTestTwo = treeView1.Nodes["test"].Nodes[2].Text = rm.GetString("test3");
        //    lanUHFTestTwo = treeView1.Nodes["test"].Nodes[1].Text = rm.GetString("test4");
       //     lanUHFTestThree = treeView1.Nodes["test"].Nodes[2].Text = rm.GetString("test5");
        //    lanActiveTest = treeView1.Nodes["test"].Nodes[3].Text = rm.GetString("test6");
        //    treeView1.Nodes["test"].Text = rm.GetString("ActiveTest");
            //标签操作界面
            /*    groupBox2.Text = rm.GetString("Access_Fliter");
                label11.Text = rm.GetString("Access_Fliter_FliterData");
                label17.Text = rm.GetString("Access_Fliter_FliterPWD");
                groupBox7.Text = rm.GetString("Access_Read_Write");
                label30.Text = rm.GetString("Access_Bank");
                label31.Text = rm.GetString("Access_StartAdd");
                label27.Text = rm.GetString("Access_Length");
                label26.Text = rm.GetString("Access_FliterType");
                label33.Text = rm.GetString("Access_Data");
                button_data_read.Text = rm.GetString("Access_Read");
                button4.Text = rm.GetString("Access_Write");
                groupBox12.Text = rm.GetString("Access_Lock");
                label3.Text = rm.GetString("Access_Lock_Area");
                label41.Text = rm.GetString("Access_Lock_Mode");
                radioButton_rw_unable.Text = rm.GetString("Access_Lock");
                radioButton_rw_unable_forever.Text = rm.GetString("Access_Lock_UnLock");
                radioButton_rw_able.Text = rm.GetString("Access_Lock_Forever");
                radioButton_rw_able_forever.Text = rm.GetString("Access_UnLock_Forever");
                button_lock.Text = rm.GetString("Access_Lock");
                groupBox13.Text = rm.GetString("Access_Kill");
                label4.Text = rm.GetString("Access_Kill_pwd") + "(Hex)";
                button_kill.Text = rm.GetString("Access_Kill");*/
            //参数设置界面
            /*   groupBox27.Text = rm.GetString("factory");
               groupBox16.Text = rm.GetString("Configure_Ant");
               label48.Text = rm.GetString("Configure_WaitTime");
               wait_time.Text = rm.GetString("Configure_WaitTime");
               button_set_ant.Text = rm.GetString("Set");
               Get_ant_mes.Text = rm.GetString("Get");
               button20.Text = rm.GetString("Set");
               //Gen2
               type_l.Text = rm.GetString("Configure_Gen2_Type");
               label21.Text = rm.GetString("Configure_Gen2_Start");
               label22.Text = rm.GetString("Configure_Gen2_Min");
               label23.Text = rm.GetString("Configure_Gen2_Max");
               button1.Text = rm.GetString("Get");
               button2.Text = rm.GetString("Set");
               //GPIO
               groupBox_gpio.Text = rm.GetString("Configure_Gpio_In_Out");
               gpio1_cb.Text = "GPIO1" + " " + rm.GetString("Configure_Gpio_Out");
               radioButton_gpio1_high.Text = rm.GetString("Configure_Gpio_High");
               radioButton_gpio1_low.Text = rm.GetString("Configure_Gpio_Low");
               gpio2_cb.Text = "GPIO2" + " " + rm.GetString("Configure_Gpio_Out");
               radioButton_gpio2_high.Text = rm.GetString("Configure_Gpio_High");
               radioButton_gpio2_low.Text = rm.GetString("Configure_Gpio_Low");
               gpio3_cb.Text = "GPIO3" + " " + rm.GetString("Configure_Gpio_Out");
               radioButton_gpio3_high.Text = rm.GetString("Configure_Gpio_High");
               radioButton_gpio3_low.Text = rm.GetString("Configure_Gpio_Low");
               gpio4_cb.Text = "GPIO4" + " " + rm.GetString("Configure_Gpio_Out");
               radioButton_gpio4_high.Text = rm.GetString("Configure_Gpio_High");
               radioButton_gpio4_low.Text = rm.GetString("Configure_Gpio_Low");
               button_gpio_get.Text = rm.GetString("Get");
               button_gpio_set.Text = rm.GetString("Set");
               //频率
               groupBox_frequency.Text = rm.GetString("Configure_Frequency");
               label2.Text = rm.GetString("Access_Lock_Area");
               checkBox_region_save.Text = rm.GetString("Configure_Frequency_Save");
               button_get_region.Text = rm.GetString("Get");
               button_set_region.Text = rm.GetString("Set");
               label19.Text = rm.GetString("Configure_Frequency_Points") + "  " + rm.GetString("Configure_Gen2_Min");
               label47.Text = rm.GetString("Configure_Gen2_Max");
               label53.Text = rm.GetString("Configure_Interval");
               button_create_fp.Text = rm.GetString("Configure_Frequency_Creat");
               button_fp_example.Text = rm.GetString("Configure_Frequency_Sample");
               button_fp_clear.Text = rm.GetString("Inventory_ClearData");
               button_get_fp.Text = rm.GetString("Get");
               button_set_fp.Text = rm.GetString("Set");
               //版本号 温度 功率 faseID
               groupBox1.Text = rm.GetString("Configure_Version");
               Hard_Version_get_b.Text = rm.GetString("Get");
               label14.Text = rm.GetString("Configure_HardVersion");
               label15.Text = rm.GetString("Configure_Firm_Version");
               groupBox19.Text = rm.GetString("Configure_Temputer");
               button1_get_temperature.Text = rm.GetString("Get");
               groupBox_power.Text = rm.GetString("Configure_Power");
               label16.Text = rm.GetString("Access_Read") + rm.GetString("Configure_Power");
               label18.Text = rm.GetString("Access_Write") + rm.GetString("Configure_Power");
               button_power_get.Text = rm.GetString("Get");
               button_power_set.Text = rm.GetString("Set");
               fastID_on_rb.Text = rm.GetString("Configure_On");
               fastID_off_rb.Text = rm.GetString("Configure_Off");
               button6.Text = rm.GetString("Get");
               button5.Text = rm.GetString("Set");*/
            //工作模式   
            /*  groupBox5.Text = rm.GetString("Mode");
               groupBox6.Text = rm.GetString("Mode");
               radioButton1.Text = rm.GetString("Mode_Trigger");
               label36.Text = rm.GetString("Mode_Level");
               label37.Text = rm.GetString("Mode_TimeOut") + "(0~256)";
               radioButton2.Text = rm.GetString("Mode_Auto");
               radioButton3.Text = rm.GetString("Mode_Master-slave");
               radioButton14.Text = rm.GetString("Inventory_Single");
               radioButton15.Text = rm.GetString("Mode_Multi");
               groupBox10.Text = rm.GetString("Mode_Weigend");
               radioButton6.Text = rm.GetString("Configure_On");
               radioButton7.Text = rm.GetString("Configure_Off");
               radioButton4.Text = "26" + rm.GetString("Mode_bit");
               radioButton5.Text = "34" + rm.GetString("Mode_bit");
               groupBox11.Text = rm.GetString("Access_Read_Write") + rm.GetString("Mode_Buzzer");
               radioButton8.Text = rm.GetString("Access_Read") + rm.GetString("Mode_Buzzer") + rm.GetString("Configure_On");
               radioButton9.Text = rm.GetString("Access_Read") + rm.GetString("Mode_Buzzer") + rm.GetString("Configure_Off");
               radioButton10.Text = rm.GetString("Access_Write") + rm.GetString("Mode_Buzzer") + rm.GetString("Configure_On");
               radioButton11.Text = rm.GetString("Access_Write") + rm.GetString("Mode_Buzzer") + rm.GetString("Configure_Off");
               groupBox14.Text = rm.GetString("Mode_Heart_dev");
               fliter_type.Text = rm.GetString("Mode_dev");
               radioButton12.Text = rm.GetString("Mode_HeartBeat") + rm.GetString("Configure_On");
               radioButton13.Text = rm.GetString("Mode_HeartBeat") + rm.GetString("Configure_Off");
               label24.Text = rm.GetString("Configure_Firm_Version");
               label29.Text = rm.GetString("Configure_HardVersion");
               label32.Text = rm.GetString("Mode_Module") + rm.GetString("Configure_Firm_Version");
               label34.Text = rm.GetString("Mode_Module") + rm.GetString("Configure_HardVersion");
               button3.Text = rm.GetString("Get");
               button7.Text = rm.GetString("Set");
               groupBox18.Text = rm.GetString("Fliter");
               fliter_type.Text = rm.GetString("Fliter") + rm.GetString("Configure_Gen2_Type");
               label50.Text = rm.GetString("Fliter") + rm.GetString("Inventory_Time");
               label51.Text = rm.GetString("Mode_HeartBeat") + rm.GetString("Inventory_Time");
               alm_check_one_lb.Text = rm.GetString("alm_check_one");
               alm_check_two_lb.Text = rm.GetString("alm_check_two");
               Bit_one_lb.Text = rm.GetString("Bit_one");
               Bit_two_lb.Text = rm.GetString("Bit_two");
               alm_alertMode_lb.Text = rm.GetString("alm_alertMode");
               radioButton16.Text = rm.GetString("AccessDoor");
               AetennaBranch_rb.Text = rm.GetString("AntennaBranch");
               groupBox26.Text = rm.GetString("GPIOState");
               label69.Text = rm.GetString("Auto_time");*/

            //通信方式
            /*  groupBox15.Text = rm.GetString("Mode_Communication");
              label38.Text = rm.GetString("Mode_Communication_MAC");
              label39.Text = rm.GetString("Mode_Communication_MASK");
              label40.Text = rm.GetString("Mode_Communication_GateWay");
              label44.Text = rm.GetString("Mode_Communication_Reader") + rm.GetString("Mode_Communication_IP");
              label43.Text = rm.GetString("Mode_Communication_Reader") + rm.GetString("Mode_Communication_Port");
              label45.Text = rm.GetString("Mode_Serever") + rm.GetString("Mode_Communication_IP");
              label46.Text = rm.GetString("Mode_Serever") + rm.GetString("Mode_Communication_Port");
              groupBox17.Text = rm.GetString("Mode_Extra_port");
              standard_rb.Text = rm.GetString("Mode_Communication_Standard");
              button10.Text = rm.GetString("Get");
              button11.Text = rm.GetString("Set");*/
            //功能标签
            this.tabScan.Text = rm.GetString("Inventory");
            this.tabPageArgs.Text = rm.GetString("ParameterSetting");
            this.tabPageActive.Text = rm.GetString("ActiveDeviceInventory");
            this.tabPage1.Text = rm.GetString("AntCompatibility");
            
            //天线匹配度界面
            this.label16.Text = rm.GetString("Ant1");
            this.label17.Text = rm.GetString("Ant2");
            this.label18.Text = rm.GetString("Ant3");
            this.label22.Text = rm.GetString("Ant4");
            this.groupBox2.Text = rm.GetString("AntDetection");
            this.radioButton1.Text = rm.GetString("Open");
            this.radioButton2.Text = rm.GetString("Close");
            this.button8.Text = rm.GetString("Set");

            // this.tabOp.Text = rm.GetString("Access");
            //  this.tabSet.Text = rm.GetString("Configure");
            /*   this.tabComm.Text = rm.GetString("Mode");
               this.tabPage1.Text = rm.GetString("wirelessnet");*/
            //模块参数设置
            //   groupBox2.Text = rm.GetString("Mode_dev");
            //   button13.Text = rm.GetString("Get");
            //   button8.Text = rm.GetString("Set");
            //   button14.Text = rm.GetString("visit");
            //    label59.Text = rm.GetString("Access_Fliter_FliterPWD");
            //    groupBox20.Text = rm.GetString("factory");
            //4G参数设置和获取
            /*   button16.Text = rm.GetString("Get");
               button17.Text = rm.GetString("Set");
               //wifi
               label75.Text = rm.GetString("Encryption");
               label77.Text = rm.GetString("EncryptionAlgorithm");
               label78.Text = rm.GetString("pwd");
               label80.Text = rm.GetString("Mode_Communication_MASK");
               label81.Text = rm.GetString("Mode_Communication_GateWay");
               label83.Text = rm.GetString("Mode_Communication_Port");
               button18.Text = rm.GetString("Get");
               button19.Text = rm.GetString("Set");
               groupBox24.Text = rm.GetString("Mode_Communication_Reader");
               groupBox25.Text = rm.GetString("Mode_Serever");*/
        }


        string start = "";
        string stop = "";
        string set = "";
        string get = "";
        string success = "";
        string failed = "";
        string creatserver = "";
        string closeserver = "";
        string openserial = "";
        string closeserial = "";
        string startmonitor = "";
        string stopmonitor = "";
        string multiepc = "";
        string cleardata = "";
        string readtags = "";
        string writetags = "";
        string locktags = "";
        string killtags = "";
        string Workant = "";
        string Worktime = "";
        string GEN2 = "";
        string Gpio = "";
        string fRequency = "";
        string fRequencypoint = "";
        string Version = "";
        string Tempreture = "";
        string Power = "";
        string Workmode = "";
        string communication = "";
        string Invalid = "";
        string openmoniterfirst = "";
        string pwdlength = "";
        string fresh = "";
        string Area = "";
        string MacAnddev = "";
        string moudleparameters = "";
        string SIMConfig = "";
        string CommunicationInfo = "";
        string Init = "";
        string SpecialDisplay = "";
        string TimingDisplay = "";
        string TriggerDisplay = "";
        string CumulativeDisplay = "";
        string ChannelGate = "";
        string ModuleHardVersion = "";
        string ModuleFirmVersion = "";

        // 2.4G测试及多功能处新增语言切换变量
        string NoAnt_EN = "";
        string SourceDataSav = "";
        string GModule = "";
        string GTest = "";
        string LaunchPower = "";
        string Reduce = "";
        string ChannerPower = "";
        string SetAnt_EN = "";
        string StartSaveExcel_EN = "";
        string Type = "";
        string BootAutomaticcycle = "";
        string PoweroutagesSave = "";
        string Exit = "";

        private void UpDataInteractiveinformation(ResourceManager rm)
        {
            start = rm.GetString("Start");
            stop = rm.GetString("Stop");
            set = rm.GetString("Set");
            get = rm.GetString("Get");
            success = rm.GetString("resultOK");
            failed = rm.GetString("resultfailed");
            creatserver = rm.GetString("OPOpenServer");
            closeserver = rm.GetString("OPCloseServer");
            openserial = rm.GetString("OPOpenserial");
            closeserial = rm.GetString("OPCloseserial");
            startmonitor = rm.GetString("OPStartmoniter");
            stopmonitor = rm.GetString("OPClosemoniter");
            multiepc = rm.GetString("OPMulti");
            cleardata = rm.GetString("Inventory_ClearData");
            readtags = rm.GetString("OPReadTags");
            writetags = rm.GetString("OPWriteTags");
            locktags = rm.GetString("OPlockTags");
            killtags = rm.GetString("OPKillTags");
            Workant = rm.GetString("OPWorkAnt");
            Worktime = rm.GetString("Configure_WaitTime");
            GEN2 = rm.GetString("OPGen2");
            Gpio = rm.GetString("OPGPIO");
            fRequency = rm.GetString("Configure_Frequency");
            fRequencypoint = rm.GetString("Configure_Frequency_Points");
            Version = rm.GetString("Configure_FirmVersion");
            ModuleHardVersion = rm.GetString("Configure_HardVersion");
            ModuleFirmVersion = rm.GetString("Configure_Firm_Version");
            Tempreture = rm.GetString("Configure_Temputer");
            Power = rm.GetString("Configure_Power");
            Workmode = rm.GetString("WorkMode");
            communication = rm.GetString("Mode_Communication");
            Invalid = rm.GetString("OPInvalidParameters");
            openmoniterfirst = rm.GetString("OPopenmonication");
            pwdlength = rm.GetString("OPPWDCheck");
            fresh = rm.GetString("Refresh");
            Area = rm.GetString("Configure_Frequency");
            MacAnddev = rm.GetString("MacAnddev");
            moudleparameters = rm.GetString("Mode_Module") + rm.GetString("Configure");
            SIMConfig = rm.GetString("4GConfig");
            CommunicationInfo = rm.GetString("CommunicationInformation");
            Init = rm.GetString("init");
            SpecialDisplay = rm.GetString("SpecialDisplay");
            TimingDisplay = rm.GetString("TimingDisplay");
            TriggerDisplay = rm.GetString("TriggerDisplay");
            CumulativeDisplay = rm.GetString("CumulativeDisplay");
            ChannelGate = rm.GetString("ChannelGate");

            SetAnt_EN = rm.GetString("SetAnt");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                ReaderControllor.GetMACDev(currentclient);
            }
            catch (Exception ex)
            {
                UpdateLog(ex.ToString());
            }
        }

        //设备ID转换为年 月 日
        private void UpdateDevID(string deID)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {


        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
        }

        private void button17_Click(object sender, EventArgs e)
        {
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            try
            {
                ReaderControllor.GetSIMInfo(currentclient);
            }
            catch (Exception ex)
            {
                UpdateLog(ex.ToString());
            }
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                ReaderControllor.GetWifiConfig(currentclient);
            }
            catch (Exception ex)
            {
                UpdateLog(ex.ToString());
            }

        }

        private void button19_Click(object sender, EventArgs e)
        {
        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                string ret = ReaderControllor.SetFactoty(currentclient);
                if (ret == "OK")
                {
                    UpdateLog("设置出厂默认值成功");
                }
                else
                {
                    UpdateLog("设置出厂默认值失败");
                }
            }
            catch (Exception ex)
            {
                UpdateLog(ex.ToString());
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private bool datatableState = false;
        private void button22_Click(object sender, EventArgs e)
        {
            /*   sql = new SQLDatabBase();
               string server = data_server_tb.Text;
               string name = data_name_tb.Text;
               string Usr = data_user_tb.Text;
               string password = data_PWD_tb.Text;
               string connectSource = "Server =" + server + ";" + "Database = " + name + ";" + "User ID=" + Usr + ";" + "Password =" + password;
               if (sql.connect(server, name, Usr, password))
               {

                   UpdateLog("连接数据库成功");
               }*/
        }

        private void button24_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {
            /*  sql.closesql();
              datatableState = false;*/
        }






        private void button27_Click_1(object sender, EventArgs e)
        {

        }

        private void button30_Click(object sender, EventArgs e)
        {

        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }



        private void datatype_cb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void groupBox20_Enter(object sender, EventArgs e)
        {

        }

        private void label59_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }




        //读取配置信息

        private string datasource = string.Empty;
        private bool _IsRfidDatabaseWork = true;
        private bool _IsActiveDatabaseWork = true;
        private bool _IsCommandDatabaseWork = true;
        private void InintManagement()
        {

            if (ConfigurationManager.AppSettings["InventoryTime"] != "null")               //获取数据显示时间间隔
            {
                Text_time_fliecabinet.Text = ConfigurationManager.AppSettings["InventoryTime"];
                timerTest.Interval = TimerShowID.Interval = show_EPC_t.Interval = int.Parse(Text_time_fliecabinet.Text);
            }
            if (ConfigurationManager.AppSettings["IsRfidDataBaseWork"] != "null")               //数据库是否启用
            {
                string IsDataBaseWork = ConfigurationManager.AppSettings["IsRfidDataBaseWork"];
                if (IsDataBaseWork == "yes")
                {
                    _IsRfidDatabaseWork = true;
                }
                else
                {
                    _IsRfidDatabaseWork = false;
                }
            }
            if (ConfigurationManager.AppSettings["IsAvtiveDataBaseWork"] != "null")               //数据库是否启用
            {
                string IsDataBaseWork = ConfigurationManager.AppSettings["IsAvtiveDataBaseWork"];
                if (IsDataBaseWork == "yes")
                {
                    _IsActiveDatabaseWork = true;
                }
                else
                {
                    _IsActiveDatabaseWork = false;
                }
            }
            if (ConfigurationManager.AppSettings["IsCommandDataBaseWork"] != "null")               //数据库是否启用
            {
                string IsDataBaseWork = ConfigurationManager.AppSettings["IsCommandDataBaseWork"];
                if (IsDataBaseWork == "yes")
                {
                    _IsCommandDatabaseWork = true;
                }
                else
                {
                    _IsCommandDatabaseWork = false;
                }
            }
            datasource = ConfigurationManager.AppSettings["database"];
            if (ConfigurationManager.AppSettings["CommandType"] != "null")               //数据库是否启用
            {
                byte type = byte.Parse(ConfigurationManager.AppSettings["CommandType"]);
                ReaderControllor.SetCommandType(type);
            }
            if (ConfigurationManager.AppSettings["ShowEPCStyle"] != "null")
            {
                this.ShowEPCStyle = ConfigurationManager.AppSettings["ShowEPCStyle"];
                byte ShowEPCStyle = byte.Parse(this.ShowEPCStyle);
                ComboBoxShowStyle.SelectedIndex = ShowEPCStyle;

                switch (ComboBoxShowStyle.SelectedIndex)
                { 
                    case 0:
#if CN
                         label15.Text = "(测试显示)";
#endif

#if ENGLISH
                        label15.Text = "(TestDispaly)";
#endif
                        break;
                    case 1:
#if CN
                         label15.Text = "(定时显示)";
#endif

#if ENGLISH
                        label15.Text = "(TimingDisplay)";
#endif
                         break;
                    case 2:
#if CN
                         label15.Text = "(触发定时显示)";
#endif

#if ENGLISH
                         label15.Text = "(TriggerStopDispaly)";
#endif
                         break;
                    case 3:
#if CN
                         label15.Text = "(累计显示)";
#endif

#if ENGLISH
                         label15.Text = "(CumulativeDisplay)";
#endif
                         break;
                    case 4:
#if CN
                         label15.Text = "(通道门显示)";
#endif

#if ENGLISH
                         label15.Text = "(ChannelGate)";
#endif
                         break;
                }

            }
            if (ConfigurationManager.AppSettings["ShowIDStyle"] != "null")
            {
                comboBoxshowIDType.SelectedIndex = byte.Parse(ConfigurationManager.AppSettings["ShowIDStyle"]);
                showIDType = (byte)comboBoxshowIDType.SelectedIndex;
            }
            if (ConfigurationManager.AppSettings["CommandType"] != "null")
            {
                byte commandtype = byte.Parse(ConfigurationManager.AppSettings["CommandType"]);
                if (commandtype == 0)
                {
                    radioButtonModuleTest.Checked = true;
                }
                else if (commandtype == 1)
                {
                    radioButtonMachineTest.Checked = true;
                }
                radioButtonModuleTest_CheckedChanged(null, null);
            }
            if (ConfigurationManager.AppSettings["CommandType"] != "null")
            {
                if (ConfigurationManager.AppSettings["LogIsOpen"] != "null")
                {
                    if (ConfigurationManager.AppSettings["LogIsOpen"] == "yes")
                    {
                        isLogOpen = true;
                    }
                    else
                    {
                        isLogOpen = false;
                    }
                }
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            ReaderControllor.ReadInfo(currentclient);
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click_2(object sender, EventArgs e)
        {
            try
            {
                ReaderControllor.GetCommunicationInfo(currentclient);
            }
            catch (Exception ex)
            {
                UpdateLog(ex.ToString());
            }
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
        }



        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void button33_Click(object sender, EventArgs e)
        {

        }

        private byte inventoty = 0;
        private string ShowEPCStyle = "1";
        private void button34_Click(object sender, EventArgs e)
        {

            if (ComboBoxShowStyle.SelectedIndex == 0)
            {
                monitor = false;
                show_EPC_t.Enabled = false;
                ShowEPCStyle = Types.NO_DISPLAY;
            }
            else if (ComboBoxShowStyle.SelectedIndex == 1)
            {
                monitor = true;
                show_EPC_t.Enabled = true;
                ShowEPCStyle = Types.TIMING_DISPLAY;
            }
            else if (ComboBoxShowStyle.SelectedIndex == 2)
            {
                monitor = true;
                show_EPC_t.Enabled = true;
                ShowEPCStyle = Types.TRIGGER_DISPLAY;
            }
            else if (ComboBoxShowStyle.SelectedIndex == 3)
            {
                monitor = true;
                show_EPC_t.Enabled = true;
                ShowEPCStyle = Types.TOTAL_DISPLAY;
            }
            else if (ComboBoxShowStyle.SelectedIndex == 4)
            {
                monitor = true;
                show_EPC_t.Enabled = false;
                ShowEPCStyle = Types.CHANNEL_DISPLAY;
            }
            else
            {
                return;
            }
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfa.AppSettings.Settings["ShowEPCStyle"].Value = ShowEPCStyle;
            cfa.Save();
            if (isLogOpen)
            {
                EventLog.WriteEvent("设置EPC数据显示方式" + ShowEPCStyle + "成功", null);
            }
        }

        private void listView_md_epc_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.listView_md_epc.FullRowSelect = true;
            //if (listView_md_epc.SelectedItems.Count > 0)
            //{
            //    int index = listView_md_epc.SelectedIndices[0];//获取选中行的索引
            //    string epc = listView_md_epc.Items[index].SubItems[2].Text;
            //    //string all = epc;
            //    string all = System.Text.RegularExpressions.Regex.Replace(epc, "[-]", "");
            //   // int a = listView_md_epc.Items.Count; //获取listview当前有多少行数据
            //    Clipboard.SetDataObject(all.ToString());
            //    //}
            //}
        }

        private void 数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBaseSetting DataBaseForm = new DataBaseSetting(this);
            DataBaseForm.ShowDialog();
            if (DataBaseForm.result == true)
            {
                datasource = DataBaseForm.path;
            }

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }










        private string[] GetEpcsFromDataTable(DataTable dataTable)
        {

            DataView dv = dataTable.DefaultView;

            dataTable = dv.ToTable(true, "EPC");

            string[] names = new string[dataTable.Rows.Count];

            for (int i = 0; i < names.Length; i++)
            {

                names[i] = dataTable.Rows[i]["EPC"].ToString();

            }
            return names;

        }





        private void label117_Click(object sender, EventArgs e)
        {

        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void 人员管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //     PersonnelManagement DataBaseForm = new PersonnelManagement(this);
            //    DataBaseForm.Show();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            //  db.deletedata("Epcs");
            //  db.deletedata("ID");
        }

        WifiMode wifiView;
        WorkMode workModeView;
        GPIO gpioView;
        Communication communicationView;
        MACAndDev macAndDevView;
        SIM simView;
        Power powerView;
        Power_Four powerfourView;
        FrequencyPoint frequencyPointView;
        Gen2 gen2View;
        FRequency frequencyAreaView;
        Version versionView;
        Temperaturecs temperatureView;
        TagAccess tagAccessView;
        WorkAnt workAntView;
        FastID fastIDView;
        Tagfocus tagfocusView;
        QT qtView;
        ParameterInit parameterInitView;
        MqttCommand mqtt;
        Beep beep;
        TreeNode theLastNode = null;
        Carrier carrierview;
        ActiveFliter fliter;
        ActiveCarrier activecarrier;
        RFLink rflinkView;
        Factory factory;
        ModuleVersion ver;
        AntConfig antConfigView;
        LongBM lbm;
        EPCAndTID eatView;
        ReadTagMode modeView;
        ModuleVersion_9200 moudleversionView;
        BatchTag batchtagView;
        Map mapView;
        PassThroughData throughdataView;
        Heart heartView;
        private string lanwifi = "WiFi模块参数";
        private string lanWorkMode = "工作模式";
        private string lanGpio = "GPIO状态";
        private string lanInfo = "网络参数设置";
        private string lanMacAndDev = "MAC地址和设备号";
        private string lan4G = "4G模块参数";
        private string lanFactory = "恢复出厂设置";
        private string lanCommandTest1 = "主板相关指令测试";
        private string lanCommandTest2 = "模块相关指令测试";
        private string lanCommandTest3 = "有源相关指令测试";
        private string lanEPCAndTID = "同时读取EPC和TID";
        private string lanPower = "功率";
        private string lanFRequency = "射频输出频率";
        private string lanGen2 = "Gen2参数";
        private string lanArea = "频率区域";
        private string lanTem = "温度";
        private string lanReadWrite = "标签读，写，锁，销毁";
        private string lanWorkAnt = "天线工作时间和间隔";
        private string lanFastID = "fastID功能";
        private string lanTagfocus = "Tagfocus";
        private string lanQT = "QT标签";
        private string lanInit = "参数初始化";
        private string lanMQTT = "MQTT";
        private string lanBeep = "蜂鸣器设置";
        private string lanCarrier = "载波测试";
        private string lanActivityCarrier = "有源读写器载波测试";
        private string lanFliter = "过滤设置";
        private string lanCommonTestOne = "通用测试一";
        private string lanUHFTest = "超高频测试";
        private string lanCommonTestTwo = "通用测试二";
        private string lanUHFTestTwo = "超高频测试二";
        private string lanUHFTestThree = "超高频测试三";
        private string lanActiveTest = "2.4G测试";
        private string ModuleVersion_9200 = "9200模块版本";
        private string BatchTagAction = "批量写标读标";
        private string HEART = "心跳";
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.treeView1.SelectedNode != null)
            {
                theLastNode = treeView1.SelectedNode;
            }
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Text.ToString() == lanWorkMode)
                {
                    ClearControl();
                    if (workModeView == null)
                    {
                        workModeView = new WorkMode(this);
                    }
                    workModeView.LanguagedChanged();
                    workModeView.Parent = panel11;
                }
                else if (treeView1.SelectedNode.Text.ToString() == lanCommandTest1)
                {
                    ClearControl();
                    if (gpioView == null)
                    {
                        gpioView = new GPIO(this);
                    }
                    gpioView.LanguagedChanged();
                    gpioView.Parent = panel11;
                    if (beep == null)
                    {
                        beep = new Beep(this);
                    }
                    beep.LanguagedChanged();
                    beep.Parent = panel11;
                }
                else if (treeView1.SelectedNode.Text.ToString() == lanInfo)
                {
                    ClearControl();
                    if (communicationView == null)
                    {
                        communicationView = new Communication(this);
                    }
                    communicationView.LanguagedChanged();
                    communicationView.Parent = panel11;
                    if (simView == null)
                    {
                        simView = new SIM(this);
                    }
                    simView.LanguagedChanged();
                    simView.Parent = panel11;
                    if (wifiView == null)
                    {
                        wifiView = new WifiMode(this);
                    }
                    wifiView.LanguagedChanged();
                    wifiView.Parent = panel11;
                    // 乔佳 2018-7-27 网络参数页面获取长编码
                  //  if (lbm == null)
                  //  {
                     //   lbm = new LongBM(this);
                  //  }
                   // lbm.LanguagedChanged();
                  //  lbm.Parent = panel11;
                }
                else if (treeView1.SelectedNode.Text.ToString() == lanFactory)
                {
                       ClearControl();
                       if (factory == null)
                       {
                           factory = new Factory(this);
                       }
                       factory.LanguagedChanged();
                       factory.Parent = panel11;
                       if (lbm == null)
                       {
                           lbm = new LongBM(this);
                       }
                       lbm.LanguagedChanged();
                       lbm.Parent = panel11;
                }
                else if (treeView1.SelectedNode.Text.ToString() == lanPower)
                {
                    ClearControl();
                    if (powerView == null)
                    {
                        powerView = new Power(this);
                    }
                    powerView.LanguagedChanged();
                    powerView.Parent = panel11;
                    if (powerfourView == null)
                    {
                        powerfourView = new Power_Four(this);
                    }
                    powerfourView.LanguagedChanged();
                    powerfourView.Parent = panel11;

                    //    powerView.Show();
                }
                else if (treeView1.SelectedNode.Text.ToString() == lanFRequency)
                {

                    ClearControl();
                    if (frequencyAreaView == null)
                    {
                        frequencyAreaView = new FRequency(this);
                    }
                    frequencyAreaView.LanguagedChanged();
                    frequencyAreaView.Parent = panel11;
                    if (frequencyPointView == null)
                    {
                        frequencyPointView = new FrequencyPoint(this);
                    }
                    frequencyPointView.LanguagedChanged();
                    frequencyPointView.Parent = panel11;
                    //   frequencyPointView.Show();

                }
                else if (treeView1.SelectedNode.Text.ToString() == lanGen2)
                {

                    ClearControl();
                    if (gen2View == null)
                    {
                        gen2View = new Gen2(this);
                    }
                    gen2View.LanguagedChanged();
                    gen2View.Parent = panel11;
                    //   gen2View.Show();

                }
                else if (treeView1.SelectedNode.Text.ToString() == lanArea)
                {
                    ClearControl();
                    if (frequencyAreaView == null)
                    {
                        frequencyAreaView = new FRequency(this);
                    }
                    frequencyAreaView.LanguagedChanged();
                    frequencyAreaView.Parent = panel11;
                    //   frequencyAreaView.Show();
                }
                else if (treeView1.SelectedNode.Text.ToString() == lanCommandTest2)
                {
                    ClearControl();
                    if (carrierview == null)
                    {
                        carrierview = new Carrier(this);
                    }
                    carrierview.LanguagedChanged();
                    carrierview.Parent = panel11;
                    if (temperatureView == null)
                    {
                        temperatureView = new Temperaturecs(this);
                    }
                    temperatureView.LanguagedChanged();
                    temperatureView.Parent = panel11;
                    if (ver == null)
                    {
                        ver = new ModuleVersion(this);
                    }
                    ver.Parent = panel11;
                    ver.LanguagedChanged();

                    if (modeView == null)
                    {
                        modeView = new ReadTagMode(this);
                    }
                    modeView.Parent = panel11;
                    modeView.LanguagedChanged();

                }
                else if (treeView1.SelectedNode.Text.ToString() == lanTem)
                {
                    ClearControl();
                    if (temperatureView == null)
                    {
                        temperatureView = new Temperaturecs(this);
                    }
                    temperatureView.LanguagedChanged();
                    temperatureView.Parent = panel11;
                    //   temperatureView.Show();
                }
                else if (treeView1.SelectedNode.Text.ToString() == lanReadWrite)
                {
                    ClearControl();
                    if (tagAccessView == null)
                    {
                        tagAccessView = new TagAccess(this);
                    }
                    tagAccessView.LanguagedChanged();
                    tagAccessView.Parent = panel11;
                    //   tagAccessView.Show();
                }
                else if (treeView1.SelectedNode.Text.ToString() == lanWorkAnt)
                {
                    ClearControl();
                    if (workAntView == null)
                    {
                        workAntView = new WorkAnt(this);
                    }
                    workAntView.LanguagedChanged();
                    workAntView.Parent = panel11;
                    //    workAntView.Show();
                }
                else if (treeView1.SelectedNode.Text.ToString() == lanFastID)
                {
                    ClearControl();
                    if (fastIDView == null)
                    {
                        fastIDView = new FastID(this);
                    }
                    fastIDView.LanguagedChanged();
                    fastIDView.Parent = panel11;
                    //    fastIDView.Show();
                }

                else if (treeView1.SelectedNode.Text.ToString() == lanEPCAndTID)
                {
                    ClearControl();
                    if (eatView == null)
                    {
                        eatView = new EPCAndTID(this);
                    }
                    // fastIDView.LanguagedChanged();
                    eatView.Parent = panel11;
                    eatView.LanguagedChanged();
                    //    fastIDView.Show();
                }
                else if (treeView1.SelectedNode.Text.ToString() == lanTagfocus)
                {
                    ClearControl();
                    if (tagfocusView == null)
                    {
                        tagfocusView = new Tagfocus(this);
                    }
                    tagfocusView.LanguagedChanged();
                    tagfocusView.Parent = panel11;
                    //    tagfocusView.Show();
                }
                else if (treeView1.SelectedNode.Text.ToString() == lanQT)
                {
                    ClearControl();
                    if (qtView == null)
                    {
                        qtView = new QT(this);
                    }
                    qtView.LanguagedChanged();
                    qtView.Parent = panel11;
                    //      qtView.Show();
                }
                /*                else if (treeView1.SelectedNode.Text.ToString() == lanInit)
                                {
                                    ClearControl();
                                    if (parameterInitView == null)
                                    {
                                        parameterInitView = new ParameterInit(this);
                                    }
                                    parameterInitView.LanguagedChanged();
                                    parameterInitView.Parent = panel11;
                                    //  parameterInitView.Show();
                                }
                                */
                else if (treeView1.SelectedNode.Text.ToString() == lanMQTT)
                {
                    ClearControl();
                    if (mqtt == null)
                    {
                        mqtt = new MqttCommand(this);
                    }
                    mqtt.LanguagedChanged();
                    mqtt.Parent = panel11;
                    //    mqtt.Show();
                }
                /*                else if (treeView1.SelectedNode.Text.ToString() == lanCommandTest3)
                                {
                                    ClearControl();
                                    if (fliter == null)
                                    {
                                        fliter = new ActiveFliter(this);
                                    }
                                    fliter.LanguagedChanged();
                                    fliter.Parent = panel11;
                                    if (activecarrier == null)
                                    {
                                        activecarrier = new ActiveCarrier(this);
                                    }
                                    activecarrier.LanguagedChanged();
                                    activecarrier.Parent = panel11;
                                }
                                */
                else if (treeView1.SelectedNode.Text.ToString() == lanCommonTestOne)
                {
#if Test
                    {
                        ClearControl();
                        if (macAndDevView == null)
                        {
                            macAndDevView = new MACAndDev(this);
                        }
                        macAndDevView.Parent = panel11;
                        if (communicationView == null)
                        {
                            communicationView = new Communication(this);
                        }
                        if (factory == null)
                        {
                            factory = new Factory(this);
                        }
                        communicationView.LanguagedChanged();
                        communicationView.Parent = panel11;
                        factory.LanguagedChanged();
                        factory.Parent = panel11;
                    }
#endif
                }
/*
                else if (treeView1.SelectedNode.Text.ToString() == lanUHFTest)
                {
#if Test
                    {
                        ClearControl();
                        if (workAntView == null)
                        {
                            workAntView = new WorkAnt(this);
                        }
                        workAntView.Parent = panel11;
                    }
#endif
                }
                else if (treeView1.SelectedNode.Text.ToString() == lanCommonTestTwo)
                {
#if Test
                    {
                        ClearControl();
                        if (workModeView == null)
                        {
                            workModeView = new WorkMode(this);
                        }
                        workModeView.Parent = panel11;
                    }
#endif
                }
*/
                else if (treeView1.SelectedNode.Text.ToString() == lanUHFTestTwo)
                {
#if Test
                    {
                        ClearControl();
                        if (frequencyAreaView == null)
                        {
                            frequencyAreaView = new FRequency(this);
                        }
                        frequencyAreaView.Parent = panel11;
                        if (rflinkView == null)
                        {
                            rflinkView = new RFLink(this);
                        }
                        rflinkView.Parent = panel11;
                        rflinkView.LanguagedChanged();
                        if (powerView == null)
                        {
                            powerView = new Power(this);
                        }
                        powerView.Parent = panel11;
                        powerView.LanguagedChanged();
                        if (temperatureView == null)
                        {
                            temperatureView = new Temperaturecs(this);
                        }
                        temperatureView.Parent = panel11;
                        temperatureView.LanguagedChanged();
                        if (carrierview == null)
                        {
                            carrierview = new Carrier(this);
                        }
                        carrierview.LanguagedChanged();
                        carrierview.Parent = panel11;
                    }
#endif
                }
                else if (treeView1.SelectedNode.Text.ToString() == lanUHFTestThree)
                {
#if Test
                    {
                        ClearControl();
                        if (tagAccessView == null)
                        {
                            tagAccessView = new TagAccess(this);
                        }
                        tagAccessView.Parent = panel11;
                    }
#endif
                }
                  // lanActiveTest
               // else if (treeView1.SelectedNode.Text.ToString() == "2.4GTest")
                else if (treeView1.SelectedNode.Text.ToString() == lanActiveTest)
                {
//#if Test   
                    {
                        ClearControl();
                        if (parameterInitView == null)
                        {
                            parameterInitView = new ParameterInit(this);
                        }
                        parameterInitView.Parent = panel11;
                        if (fliter == null)
                        {
                            fliter = new ActiveFliter(this);
                        }
                        fliter.Parent = panel11;
                        if (activecarrier == null)
                        {
                            activecarrier = new ActiveCarrier(this);
                        }
                        activecarrier.Parent = panel11;
                    }
//#endif
             //969696
                }
                else if (treeView1.SelectedNode.Text.ToString() == ModuleVersion_9200)
                    {
                        ClearControl();

                        if (moudleversionView == null)
                        {
                            moudleversionView = new ModuleVersion_9200(this);
                        }
                        moudleversionView.Parent = panel11;                   
                    }
                else if (treeView1.SelectedNode.Text.ToString() == BatchTagAction)
                {
                    ClearControl();

                    if (batchtagView == null)
                    {
                        batchtagView = new BatchTag(this);
                    }
                    batchtagView.Parent = panel11;
                    batchtagView.LanguagedChanged();

                }
                    
                else if (treeView1.SelectedNode.Text.ToString() == HEART)
                {
                    ClearControl();
                    if (heartView == null)
                    {
                        heartView = new Heart(this);
                    }
                    heartView.Parent = panel11;
                    heartView.LanguagedChanged();
                }
                else if (treeView1.SelectedNode.Text.ToString() == "Map")
                {
                    ClearControl();
                    if (mapView == null)
                    {
                        mapView = new Map(this);
                    }
                    mapView.Parent = panel11;
                    mapView.LanguagedChanged();
                }
                else if (treeView1.SelectedNode.Text.ToString() == "透传数据")
                {
                    ClearControl();
                    if (throughdataView == null)
                    {
                        throughdataView = new PassThroughData(this);
                    }
                    throughdataView.Parent = panel11;
                }

                else
                {

                }
            }
        }


        private void ClearControl()
        {
            /* Point p = new Point(0, 0);
             if (panel11.GetChildAtPoint(p) != null)
             {
                 panel11.GetChildAtPoint(p).Parent = null;
             }*/
            int count = this.panel11.Controls.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                this.panel11.Controls[0].Parent = null;
            }

        }

        private void button37_Click(object sender, EventArgs e)
        {

        }

        DataBase db;
        /// <summary>
        /// 创建指定格式的数据库表格
        /// </summary>
        public void CreatTables()
        {
            db = new DataBase(datasource);
            try
            {
                db.CreatTables("Command");
            }
            catch (Exception ex)
            {
                UpdateLog("数据库已存在表格Comamnd");
            }

        }



        private bool monitor = true;


        private void show_EPC_t_Tick(object sender, EventArgs e)
        {          
            if (ShowEPCStyle == Types.TIMING_DISPLAY)            //定时显示
            {
                UpdateEpc(flag);
               // ThreadPool.QueueUserWorkItem(delegate { UpdateEpc(flag); }); 
            }
            else if (ShowEPCStyle == Types.TOTAL_DISPLAY)       //累计显示
            {
                      UpdateEpcAdd(0);
            //  ThreadPool.QueueUserWorkItem(delegate { UpdateEpcAdd(0); });  // 线程异步处理，防止ListView加载大量数据卡死
               
            }

        }

        private void button_time_fliecabinet_Click(object sender, EventArgs e)
        {
            //timerTest.Interval = TimerShowID.Interval = show_EPC_t.Interval = int.Parse(Text_time_fliecabinet.Text);
            //Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //string InventoryTime = Text_time_fliecabinet.Text;
            //cfa.AppSettings.Settings["InventoryTime"].Value = InventoryTime;
            //cfa.Save();
            //if (isLogOpen)
            //{
            //    EventLog.WriteEvent("设置EPC数据显示时间间隔" + InventoryTime + "ms成功", null);
            //}
        }

        private int CuttentEPCColums = 0;
        private void listView_md_epc_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == mySorter.ColumnIndex)
            {
                mySorter.SortOrder = (
                    mySorter.SortOrder == SortOrder.Descending ?
                    SortOrder.Ascending : SortOrder.Descending);
            }
            else
            {
                mySorter.SortOrder = SortOrder.Ascending;
                mySorter.ColumnIndex = e.Column;
            }
            CurrentCacheItemsSource.Sort(mySorter);
            listView_md_epc.Invalidate();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            /*if (db != null)
            {
                db.creatTable(0);
            }*/
        }

        private void SrDemo_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            button12_Click_1(sender, e);
            UpDataMainFormUILanguage();
        }

        private void 文件管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*  ArticleManagementMainForm AMForm = new ArticleManagementMainForm(this, db);
              AMForm.Show();           //非模态
              */
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void TimerShowID_Tick(object sender, EventArgs e)
        {
            if (showIDType == 0x00)
            {
                UpdateIDAccumulate();                //以累计方式显示
            }
            else
            {
                UpdateID();
            }

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 系统功能配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppConfig ConfigForm = new AppConfig();
            ConfigForm.Show();           //非模态
        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.ForeColor = Color.Blue;
            e.Node.NodeFont = new Font("华文中宋", 9, FontStyle.Underline | FontStyle.Bold);
            if (theLastNode != null)
            {
                theLastNode.ForeColor = SystemColors.WindowText;
                theLastNode.NodeFont = new Font("华文中宋", 9, FontStyle.Regular);
            }
        }

        private void mQTTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    MqttClientForm ClientForm = new MqttClientForm();
            //     ClientForm.Show();
        }

        private void ListViewID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /*private void button1_Click_2(object sender, EventArgs e)
        {
            if (comboBoxshowIDType.Text == "累计显示")
            {
                showIDType = 0x00;
            }
            else if (comboBoxshowIDType.Text == "单位时间显示")
            {
                showIDType = 0x01;
            }
            else
            {
                ;
            }
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfa.AppSettings.Settings["ShowIDStyle"].Value = showIDType.ToString();
            cfa.Save();
        }*/

        private void button2_Click_1(object sender, EventArgs e)
        {
            ListViewID.VirtualListSize = 0;
            this.ItemsSource_ID.Clear();
            this.CurrentCacheItemsSource_ID.Clear();
            this.Refresh();

            ListViewID.Items.Clear();
            IDtr_list.Clear();

            LabelIDCounts.Text = "0";
            if (!isTimerStart) LabelIDTime.Text = "0";
            LabelIDSpeed.Text = "0";
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            Last_IDNum = HaveYuanSpeed = 0;
            try
            {
                ReaderControllor.StartMultiEPC();
                UpdateLog(start + multiepc + success);
                if (!isTimerStart) button5_Click_2(sender, (EventArgs)e);
            }
            catch (Exception ex)
            {
                UpdateLog(ex.ToString());
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                ReaderControllor.StopMultiEPC();
                UpdateLog(stop + multiepc + success);
                if (isTimerStart) button5_Click_2(sender, (EventArgs)e);
            }
            catch (Exception ex)
            {
                UpdateLog(ex.ToString());
            }
        }

        private long MonitorTime = 0;
        private bool isRFIDTimerStart = false;
        private void button5_Click_1(object sender, EventArgs e)
        {
            if (isTimerStart) button5_Click_2(sender, (EventArgs)e);
            ResourceManager rm = new ResourceManager(typeof(SrDemo));
            if ((buttonStartMonitor.Text == "开始计时")|| (buttonStartMonitor.Text == "StartTimer"))
            {
                lock (epcstr_list)
                {
                    epcstr_list.Clear();
                }
                show_EPC_t.Enabled = true;
                show_EPC_t.Start();
                timerMonitor.Enabled = true;
                MonitorTime = 1;
                timerMonitor.Start();
                EpctotalnumBack = 0;
                isRFIDTimerStart = true;
                buttonStartMonitor.Text = rm.GetString("StopTimer");
            }
            else if((buttonStartMonitor.Text == "停止计时")|| (buttonStartMonitor.Text == "StopTimer"))
            {
                show_EPC_t.Stop();
                show_EPC_t.Enabled = false;
                timerMonitor.Stop();
                timerMonitor.Enabled = false;
                isRFIDTimerStart = false;
                buttonStartMonitor.Text = rm.GetString("StartTimer");
            }
        }

        long Last_Num = 0;

        private void timerMonitor_Tick(object sender, EventArgs e)
        {     

            LabelCurrentTimes.Text = MonitorTime.ToString();
            if (label26_total.Text != listView_md_epc.Items.Count.ToString())
            {
                label26_total.Text = listView_md_epc.Items.Count.ToString();
            }
            label8.Text = (NNNum - Last_Num).ToString();
            Last_Num = NNNum;
            MonitorTime++;
            if (IsTemp == false)
            {
                if (DataMark == false && IsStart == false)
                {
                    timerMonitor.Enabled = false;
                    timerMonitor.Stop();
                }
            }

        }


        private bool isTimerStart = false;
        private void button5_Click_2(object sender, EventArgs e)
        {
            if (isRFIDTimerStart) button5_Click_1(sender, (EventArgs)e);
            ResourceManager rm = new ResourceManager(typeof(SrDemo));
            if ((buttonStartIDMonitor.Text == "开始计时")||(buttonStartIDMonitor.Text == "StartTimer"))
            {
                lock (epcstr_list)
                {
                    IDtr_list.Clear();
                }
                TimerShowID.Enabled = true;
                TimerShowID.Start();
                timerIDMonitor.Enabled = true;
                MonitorTime = 1;
                timerIDMonitor.Start();
                totalnumBack = 0;
                buttonStartIDMonitor.Text = rm.GetString("StopTimer");
                isTimerStart = true;
            }
            else if((buttonStartIDMonitor.Text == "停止计时")||(buttonStartIDMonitor.Text == "StopTimer"))
            {
                TimerShowID.Stop();
                TimerShowID.Enabled = false;
                timerIDMonitor.Stop();
                timerIDMonitor.Enabled = false;
                buttonStartIDMonitor.Text = rm.GetString("StartTimer");
                isTimerStart = false;
            }
        }

        long Last_IDNum = 0;
        private void timerIDMonitor_Tick(object sender, EventArgs e)
        {
            LabelIDTime.Text = MonitorTime.ToString();
            if (LabelIDCounts.Text != ListViewID.Items.Count.ToString())
            {
                LabelIDCounts.Text = ListViewID.Items.Count.ToString();
            }
            LabelIDSpeed.Text = (HaveYuanSpeed - Last_IDNum).ToString();
            Last_IDNum = HaveYuanSpeed;
            MonitorTime++;
        }

        private void ListViewID_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == mySorter.ColumnIndex)
            {
                mySorter.SortOrder = (
                    mySorter.SortOrder == SortOrder.Descending ?
                    SortOrder.Ascending : SortOrder.Descending);
            }
            else
            {
                mySorter.SortOrder = SortOrder.Ascending;
                mySorter.ColumnIndex = e.Column;
            }
            CurrentCacheItemsSource_ID.Sort(mySorter);
            ListViewID.Invalidate();
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Maintable.SelectedTab == this.page_quickstart)
            {
                if (powerView == null)
                {
                    powerView = new Power(this);
                }
                if (communicationView == null)
                {
                    communicationView = new Communication(this);
                }
                if (antConfigView == null)
                {
                    antConfigView = new AntConfig();
                }
                powerView.Parent = pannel_quickstart;
                communicationView.Parent = pannel_quickstart;
                antConfigView.Parent = pannel_quickstart;
                powerView.LanguagedChanged();
                antConfigView.LanguagedChanged();
                communicationView.LanguagedChanged();
            }
            else if (Maintable.SelectedTab == this.tabScan)
            {
                //隐藏有源字体
                label11.Visible = false;
                LabelIDCounts.Visible = false;
                label9.Visible = false;
                LabelIDSpeed.Visible = false;
                label10.Visible = false;
                label3.Visible = false;
                LabelIDTime.Visible = false;
                label1.Visible = false;
                //显示无源字体
                label25.Visible = true;
                label26_total.Visible = true;
                LabelCurrentTime.Visible = true;
                LabelCurrentTimes.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label2.Visible = true;

                IsHaveYuan = false;  // 当前为无源设备
            }
            else if (Maintable.SelectedTab == this.tabPageActive)
            {
                //显示有源字体
                label11.Visible = true;
                LabelIDCounts.Visible = true;
                label9.Visible = true;
                LabelIDSpeed.Visible = true;
                label10.Visible = true;
                label3.Visible = true;
                LabelIDTime.Visible = true;
                label1.Visible = true;
                //隐藏无源字体
                label25.Visible = false;
                label26_total.Visible = false;
                LabelCurrentTime.Visible = false;
                LabelCurrentTimes.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label2.Visible = false;

                IsHaveYuan = true;  // 当前为有源设备
            }


            //label26_total.Font = f;
            //label8.Font = f;
            //LabelCurrentTimes.Font = f;
            //// 有源界面
            //LabelIDTime.Font = f;
            //LabelIDCounts.Font = f;
            //LabelIDSpeed.Font = f;

        }

        private void button5_Click_3(object sender, EventArgs e)
        {
            /*  if (buttonMessageServer.Text == "创建")
              {
                  Clients = new Business.Clients(ReaderControllor);
                  string dev_ip = textBoxMessageServerIP.Text.ToString();
                  ushort port = ushort.Parse(textBoxMessageServerPort.Text);
                  IPAddress ipaddress = IPAddress.Parse(dev_ip);
                  if (Clients.CreatMessagePublisher(ipaddress, port))
                  {
                      buttonMessageServer.Text = "关闭";
                      timerMessage.Enabled = true;
                      UpdateLog("创建消息服务器成功");
                  }
                  else
                  {
                      UpdateLog("创建消息服务器失败");
                  }
              }
              else
              {
                  buttonMessageServer.Text = "创建";
                  timerMessage.Enabled = false;
                  Clients.DisposeMessagePublisher();
                  UpdateLog("释放服务器资源");
              }*/
        }

        private void button5_Click_4(object sender, EventArgs e)
        {

        }

        private void button6_Click_2(object sender, EventArgs e)
        {

        }

        private void timerMessage_Tick(object sender, EventArgs e)
        {
            /* listViewClientInfo.Items.Clear();
             List<Private.NetFrame.Net.TCP.Sock.AsyncSocketState> clientinfo = Clients.GetClientInfo();
             foreach (Private.NetFrame.Net.TCP.Sock.AsyncSocketState client in clientinfo)
             {

                 ListViewItem item = new ListViewItem((this.listViewClientInfo.Items.Count + 1).ToString());
                 item.SubItems.Add(client.ip_addr);
                 item.SubItems.Add(client.port);
                 item.SubItems.Add(client.dev);
                 item.SubItems.Add(client.state);
                 this.listViewClientInfo.Items.Add(item);
                 this.listViewClientInfo.Items[this.listViewClientInfo.Items.Count - 1].EnsureVisible();

             }*/
        }

        private System.Timers.Timer timerTest = new System.Timers.Timer(5000);


        private void button7_Click_1(object sender, EventArgs e)
        {
            NNNum = 0; //记录速度变量
            Last_Num = 0;



            button_md_clear_Click(null, null);
            button_md_start_Click(null, null);
            timerTest.Enabled = true;
            timerTest.Start();
            if (isLogOpen)
            {
                EventLog.WriteEvent("自动测试成功", null);
            }
        }

        private void timerTestclick(object sender, EventArgs e)
        {
            button_md_stop_Click(null, null);
            timerTest.Stop();
            timerTest.Close();
            timerTest.Enabled = false;
            m_SyncContext.Post(UpdateEpcAdd, 0);
            //  UpdateEpcAdd(0);
        }

        private void button8_Click_2(object sender, EventArgs e)
        {
            
        }

        private void listView_oper_log_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel11_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click_5(object sender, EventArgs e)
        {
            if ((MultiFunctionMode.Text == "多功能模式") || (MultiFunctionMode.Text == "MultiFunction"))
            {
                panel1.Visible = true;
                allreader_cb.Visible = true;
                singleEPC_rb.Visible = true;
                //radioButtonModuleTest.Visible = true;
               // radioButtonMachineTest.Visible = true;
//                this.page_quickstart.Parent = null;
//                tabPageArgs.Parent = Maintable;
                labletest.Visible = true;
                radioButtonModuleTest.Visible = true;
                radioButtonMachineTest.Visible = true;
                SelectAntcheckBox1.Visible = true;
                SelectAntcheckBox2.Visible = true;
                SelectAntcheckBox3.Visible = true;
                SelectAntcheckBox4.Visible = true;
                NoAnt.Visible = true;
                testbtn.Visible = true;
//                buttonStartMonitor.Visible = true;
                ComboBoxShowStyle.Visible = true;
                Text_time_fliecabinet.Visible = true;
                label14.Visible = true;
                button_time_fliecabinet.Visible = true;
                StartSaveExcel.Visible = true;
                AdvanceGroup.Visible = true;
                sourceDataSaveBt.Visible = true;
               // sourceDataTabSaveBt.Visible = true;
                isSimple = false;
                if (button12.Text == "English") MultiFunctionMode.Text = "精简模式";
                else MultiFunctionMode.Text = "Streamline";
            }
            else
            {
                panel1.Visible = false;
                allreader_cb.Visible = false;
                singleEPC_rb.Visible = false;
                //radioButtonModuleTest.Visible = false;
                //radioButtonMachineTest.Visible = false;
  //              this.page_quickstart.Parent = Maintable;
  //              tabPageArgs.Parent = null;
                labletest.Visible = false;
                radioButtonModuleTest.Visible = true;
                radioButtonMachineTest.Visible = true;
                SelectAntcheckBox1.Visible = false;
                SelectAntcheckBox2.Visible = false;
                SelectAntcheckBox3.Visible = false;
                SelectAntcheckBox4.Visible = false;
                NoAnt.Visible = false;
                testbtn.Visible = false;
                buttonStartMonitor.Visible = false;
                ComboBoxShowStyle.Visible = false;
                Text_time_fliecabinet.Visible = false;
                label14.Visible = false;
                button_time_fliecabinet.Visible = false;
                StartSaveExcel.Visible = false;
                AdvanceGroup.Visible = false;
                sourceDataSaveBt.Visible = false;
               // sourceDataTabSaveBt.Visible = false;
                isSimple = true;
                if (button12.Text == "English") MultiFunctionMode.Text = "多功能模式";
                else MultiFunctionMode.Text = "MultiFunction";
            }
        }

        private void button5_Click_6(object sender, EventArgs e)
        {
        }

        private void pannel_quickstart_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pannel_quickstart_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click_7(object sender, EventArgs e)
        {

        }
        //  private System.Timers.Timer timer = new System.Timers.Timer();
        private bool startWriteToTxt = false;
        ExcelEditHelper excelOperate = new ExcelEditHelper();
        private void button6_Click_3(object sender, EventArgs e)
        {
            if (StartSaveExcel.Text == "保存列表到Excel")
            {
                DataTable dt = new DataTable();
                int i, j;
                DataRow dr;
                dt.Clear();
                dt.Columns.Clear();
                //生成DataTable列头
                for (i = 0; i < listView_md_epc.Columns.Count; i++)
                {
                    dt.Columns.Add(listView_md_epc.Columns[i].Text.Trim(), typeof(String));
                }
                //每行内容
                for (i = 0; i < listView_md_epc.Items.Count; i++)
                {
                    dr = dt.NewRow();
                    for (j = 0; j < listView_md_epc.Columns.Count; j++)
                    {
                        dr[j] = listView_md_epc.Items[i].SubItems[j].Text.Trim();
                    }
                    dt.Rows.Add(dr);
                }


                SaveFileDialog sfd = new SaveFileDialog();
                sfd.DefaultExt = "xls";
                sfd.Filter = "Excel文件(*.xls)|*.xls";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                   // ExportToExcel(dt, sfd.FileName);
                    string filename = "标签信息表";
                    NPOIHelper.Export(dt, filename, sfd.FileName);                         
                }
                //excelOperate.CreatAndOpen("EPC");
                //StartSaveExcel.Text = "停止保存到Excel";
                startWriteToTxt = true;
            }
            else
            {
                //  excelOperate.Close();
                StartSaveExcel.Text = "开始保存到Excel";
                startWriteToTxt = false;
            }

            //  timer.Interval = 1000;
            // timer.Enabled = true;
            //  timer.Elapsed += InserExcelData;
        }

        private void InserExcelData(object sender, ElapsedEventArgs e)
        {
            //
        }




        private void button6_Click_4(object sender, EventArgs e)
        {
            //excelOperate.CreatAndOpen("ListData");
            //foreach (ListViewItem viewitem in this.listView_md_epc.Items)
            //{
            //    string num = viewitem.SubItems[listView_md_epc_Num].Text;
            //    string ant = viewitem.SubItems[listView_md_epc_AntID].Text;
            //    string epc = viewitem.SubItems[listView_md_epc_EPC].Text;
            //    string pc = viewitem.SubItems[listView_md_epc_PC].Text;
            //    string rssi = viewitem.SubItems[listView_md_epc_Count].Text;
            //    string count = viewitem.SubItems[listView_md_epc_Rssi].Text;
            //    string devID = viewitem.SubItems[listView_md_epc_IP].Text;
            //    string time = viewitem.SubItems[listView_md_epc_Last_Time].Text;
            //    string dir = viewitem.SubItems[listView_md_epc_Direction].Text;

            //    string CommandText = "Insert Into [Sheet1$] Values('" + num + "', '" + ant + "','" + epc + "', '" + pc + "', '" + rssi + "', '" + count + "', '" + devID + "', '" + time + "', '" + dir + "')";
            //    excelOperate.Insert(CommandText);
            //}
        }


        private bool isSourceDataSave = false;
        public static bool SetCarrierOn;
        private void button7_Click_2(object sender, EventArgs e)
        {
            if (sourceDataSaveBt.Text == "开始保存原始数据")
            {
                sourceDataSave.Enabled = true;
                sourceDataSaveBt.Text = "停止保存原始数据";
                isSourceDataSave = true;
            }
            else
            {
                sourceDataSave.Enabled = false;
                isSourceDataSave = false;
                sourceDataSaveBt.Text = "开始保存原始数据";
            }

        }

        private void sourceDataSave_Tick(object sender, EventArgs e)
        {
            lock (sourceEpcStrList)
            {
                foreach (string[] result in sourceEpcStrList)
                {
                    string epcData = epcLogNum.ToString().PadRight(10, ' ') + sourceEpcStrList.Count.ToString().PadRight(5, ' ') + result[4].PadRight(5, ' ') + result[5].PadRight(40, ' ') + result[6].PadRight(10, ' ') + result[7].PadRight(10, ' ')
                                     + result[11].PadRight(5, ' ') + result[0].PadRight(15, ' ') + result[12].PadRight(30, ' ') + result[9].PadRight(5, ' ') + result[13].PadRight(5, ' ') + result[8].PadRight(5, ' ');
                    EPCLog.WriteEvent(epcData);
                    epcLogNum++;
                }
                sourceEpcStrList.Clear();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void reader_IP_tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxshowIDType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxshowIDType.Text == "累计显示")
            {
                showIDType = 0x00;
            }
            else if (comboBoxshowIDType.Text == "单位时间显示")
            {
                showIDType = 0x01;
            }
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfa.AppSettings.Settings["ShowIDStyle"].Value = showIDType.ToString();
            cfa.Save();
        }

        private void comboBoxshowIDType_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void radioButtonModuleTest_CheckedChanged(object sender, EventArgs e)
        {
            string CommandType = "0";
            string TermnialType = "整机";
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (radioButtonModuleTest.Checked == true)                //模块测试
            {
                CommandType = "0";
                TermnialType = radioButtonModuleTest.Text;
            }
            else                                              //整机测试
            {
                CommandType = "1";
                TermnialType = radioButtonMachineTest.Text;
            }
            ReaderControllor.SetCommandType(byte.Parse(CommandType));
            cfa.AppSettings.Settings["CommandType"].Value = CommandType;
            cfa.Save();
            if(button12.Text=="English") UpdateLog("设置设备类型="+ TermnialType);
            else UpdateLog("Set Terminal Type=" + TermnialType);
            if (isLogOpen)
            {
                EventLog.WriteEvent("设置设备类型" + CommandType + "成功", null);
            }
        }

        private void ComboBoxShowStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxShowStyle.SelectedIndex == 0)
            {
                monitor = false;
                show_EPC_t.Enabled = false;
                ShowEPCStyle = Types.NO_DISPLAY;
#if CN
                label15.Text = "(测试显示)";
#endif

#if ENGLISH
                label15.Text = "(TestDispaly)";
#endif
            }
            else if (ComboBoxShowStyle.SelectedIndex == 1)
            {
                monitor = true;
                show_EPC_t.Enabled = true;
                ShowEPCStyle = Types.TIMING_DISPLAY;
#if CN
                label15.Text = "(定时显示)";
#endif

#if ENGLISH
                label15.Text = "(TimingDisplay)";
#endif
            }
            else if (ComboBoxShowStyle.SelectedIndex == 2)
            {
                monitor = true;
                show_EPC_t.Enabled = true;
                ShowEPCStyle = Types.TRIGGER_DISPLAY;
#if CN
                label15.Text = "(触发定时显示)";
#endif

#if ENGLISH
                label15.Text = "(TriggerStopDispaly)";
#endif
            }
            else if (ComboBoxShowStyle.SelectedIndex == 3)
            {
                monitor = true;
                show_EPC_t.Enabled = true;
                ShowEPCStyle = Types.TOTAL_DISPLAY;
#if CN
                label15.Text = "(累计显示)";
#endif

#if ENGLISH
                label15.Text = "(CumulativeDisplay)";
#endif
            }
            else if (ComboBoxShowStyle.SelectedIndex == 4)
            {
                monitor = true;
                show_EPC_t.Enabled = false;
                ShowEPCStyle = Types.CHANNEL_DISPLAY;
#if CN
                label15.Text = "(通道门显示)";
#endif

#if ENGLISH
                label15.Text = "(ChannelGate)";
#endif
            }
            else
            {
                return;
            }
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfa.AppSettings.Settings["ShowEPCStyle"].Value = ShowEPCStyle;
            cfa.Save();
            if (isLogOpen)
            {
                EventLog.WriteEvent("设置EPC数据显示方式" + ShowEPCStyle + "成功", null);
            }
        }

        private void listView_md_epc_DoubleClick(object sender, EventArgs e)
        {
        }

        private void AntSetbutton_Click(object sender, EventArgs e)
        {
            if (SelectAntcheckBox1.Checked == true || SelectAntcheckBox2.Checked == true || SelectAntcheckBox3.Checked == true || SelectAntcheckBox4.Checked == true)
            {
                try
                {
                    byte workant = 0;
                    if (SelectAntcheckBox1.Checked == true)
                    {
                        workant |= 0x01;
                    }
                    if (SelectAntcheckBox2.Checked == true)
                    {
                        workant |= 0x02;
                    }
                    if (SelectAntcheckBox3.Checked == true)
                    {
                        workant |= 0x04;
                    }
                    if (SelectAntcheckBox4.Checked == true)
                    {
                        workant |= 0x08;
                    }
                    string result = ReaderControllor.SetWorkAnt(currentclient, workant);
                    if (isLogOpen)
                    {
                        if (result == ErrorNum.SEND_OK)
                        {
                            EventLog.WriteEvent("设置天线工作状态命令发送成功", null);
                        }
                        else
                        {
                            EventLog.WriteEvent("设置天线工作状态命令发送失败", null);
                        }
                    }
                }
                catch (Exception ex)
                {
                    UpdateLog(ex.ToString());
                    if (isLogOpen)
                    {
                        ErrorLog.WriteError(ex.ToString());
                    }
                }
            }
        }

        private void FilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(FilterCheckBox.Checked==true) fd.Enabled = true;
            else fd.Enabled = false;
        }

        private void radioButtonMachineTest_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            string CommandType = "0";
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (radioButtonModuleTest.Checked == true)                //模块测试
            {
                CommandType = "0";
            }
            else                                              //整机测试
            {
                CommandType = "1";
            }
            ReaderControllor.SetCommandType(byte.Parse(CommandType));
            cfa.AppSettings.Settings["CommandType"].Value = CommandType;
            cfa.Save();
            UpdateLog("设置设备类型成功");
            if (isLogOpen)
            {
                EventLog.WriteEvent("设置设备类型" + CommandType + "成功", null);
            }
        }

        private void button31_Click_1(object sender, EventArgs e)
        {
            try
            {
                string result = ReaderControllor.ReadInfo(clients[row]);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("获取读写器" +"初始化参数" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("获取读写器" +"初始化参数" + "命令发送" + "失败", null);
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateLog(ex.ToString());
                if (SrDemo.isLogOpen)
                {
                    ErrorLog.WriteError(ex.ToString());
                }
            }
        }

        private void button5_Click_8(object sender, EventArgs e)
        {
            try
            {
                string result = ReaderControllor.ReadInfo(clients[row]);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("获取读写器" + "初始化参数" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("获取读写器" + "初始化参数" + "命令发送" + "失败", null);
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateLog(ex.ToString());
                if (SrDemo.isLogOpen)
                {
                    ErrorLog.WriteError(ex.ToString());
                }
            }
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            //      WorkingReader,0x55,0x02,0x00,0x07,0x01,0xa0,0x00,0x00      
          //  byte recvpower = byte.Parse(textBox1.Text);
           // ReaderControllor.Init(clients[row], 0x55, 0x02, 0x00, recvpower, 0x01, 0xa0, 0x00, 0x00);
        }


        public byte Save_cb = 0x66; // 断电保存
        public byte transpower = 0x01;  // 发射功率
        public byte SPSJ = 0x1E;    // 射频衰减
        public byte channel = 0x1E;  // 信道频率
        public byte IsAuto = 0x01; // 开机自动循环
        public byte tagtype = 0x05;     // 类型

        public bool G24_Mark = false;  // 是否获取到数据标志


        public void GetHaveYuanData(string [] data)
        {
            if (data.Length > 10)
            {
                if (data[4] == "66")         // 断电保存
                {
                    Save_cb = 0x66;
                }
                else
                {
                    Save_cb = 0x00;
                }

                transpower = Convert.ToByte(data[6]); // 发射功率

                SPSJ = Convert.ToByte(data[7]); // 射频衰减

                if (data[8] == "1")       // 开机自动循环
                {
                    IsAuto = 0x01;
                }
                else
                {
                    IsAuto = 0x00;
                }

                channel = Convert.ToByte(data[9]); // 信道频率

                tagtype = Convert.ToByte(data[10]);   // 类型

                G24_Mark = true;
            }
        }


        bool set_24G = false;

        private void button32_Click(object sender, EventArgs e)
        {
            set_24G = true;

            ReaderControllor.ReadInfo(clients[row]);

            Thread.Sleep(100);

            if (G24_Mark == true)
            {

             byte save = 0x00;
            if (checkBox1.Checked == true)
            {
                save = 0x66;
            }
            else
            {
                save = 0x55;
            }
            byte ver = 0x02;                                   //版本默认为最新
     
                byte recvpower = byte.Parse(recv_tb.Text);
                byte workstate = 0x00;
                if (IsAutocheckBox.Checked)
                {
                    workstate = 0x00;
                }
                else
                {
                    workstate = 0x01;
                }

                byte channnel = (byte)(ushort.Parse(channel_tb.Text) - 2400);
                byte tagtype = byte.Parse(tagtype_tb.Text);
                //mode值保留
                byte mode = 0x00;

                ReaderControllor.Init(clients[row], save, ver, transpower, recvpower, workstate, channnel, tagtype, mode);

                //  byte recvpower = byte.Parse(recv_tb.Text);
                //  ReaderControllor.Init(clients[row], Save_cb, 0x02, transpower, recvpower, IsAuto, channel, tagtype, 0x00);
                set_24G = false;
            }
        }

        long LastNum = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
                //if (label26_total.Text == "0")
                //{
                //    label26_total.Text = listView_md_epc.Items.Count.ToString();
                //}
                //label8.Text =NNNum.ToString();
                //NNNum = 0;
        }

        public static int TDMMode = 2; // 判断当前设备是否设置为通道门模式
        private void Maintable_Selected(object sender, TabControlEventArgs e)
        {
            ComboBoxShowStyle_SelectedIndexChanged(sender, (EventArgs)e);

            switch (TDMMode)
            {
                case 0:
                    this.ComboBoxShowStyle.SelectedIndex = 3;
                    TDMMode = 2;
                    break;
                case 1:
                    this.ComboBoxShowStyle.SelectedIndex = 4;

              listView_md_epc.VirtualListSize = 0;

            this.ItemsSource.Clear();
            this.CurrentCacheItemsSource.Clear();
            this.Refresh();

                    TDMMode = 2;
                    break;
                default:
                    break;
            }
        }


        bool IsTemp = false;
        private void button1_Click_4(object sender, EventArgs e)
        {
            IsTemp = true;
            Last_Num = NNNum = 0;

           string result = ReaderControllor.ReadTagTemp(currentclient, 0x01);
           if (result == "0")
           {
               UpdateLog("开始读取温度标签成功!");
               if (!isRFIDTimerStart) button5_Click_1(sender, (EventArgs)e);
           }
           else
           {
               UpdateLog("开始读取温度标签失败!");        
           }
        }

        private void button5_Click_9(object sender, EventArgs e)
        {
            IsTemp = false;
            string result = ReaderControllor.ReadTagTemp(currentclient, 0x00);
            if (result == "0")
            {
                UpdateLog("停止读取温度标签成功!");
                if (isRFIDTimerStart) button5_Click_1(sender, (EventArgs)e);
            }
            else
            {
                UpdateLog("停止读取温度标签失败!");
            }
        }

        private void listView_md_epc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ListView listview = (ListView)sender;
                ListViewItem lstrow = listview.GetItemAt(e.X, e.Y);
                System.Windows.Forms.ListViewItem.ListViewSubItem lstcol = lstrow.GetSubItemAt(e.X, e.Y);
                string strText = lstcol.Text;
                string all = System.Text.RegularExpressions.Regex.Replace(strText, "[-]", "");
                Clipboard.SetDataObject(all.ToString());
            }
            catch
            { 
            }
        }

        private void button6_Click_5(object sender, EventArgs e)
        {
    
          

           
        }

        public void GetAntCompatibility(string[] result)
        {
            //Value = 100;
            this.progressBar3.Value = 100;
            this.progressBar4.Value = 100;
           // try
           // {
                if (result[2] == "1")
                {
                    string antnum = result[3].Substring(1, result[3].Length - 1);  //1-3

                    string[] str_antnum = antnum.Split('-');

                    string compatibility = result[4].Substring(1, result[4].Length - 1);  //127-255

                    string[] str_compatibility = compatibility.Split('-');

                    for (int i = 0; i < str_antnum.Length; i++)
                    {

                        int antcom = Convert.ToInt32(Convert.ToDouble(str_compatibility[i]) / 2.5);  //匹配度

                        Font font;
                        PointF pt;
                        string str;


                        if (str_compatibility[i] != "255")
                        {
                            switch (str_antnum[i])
                            {

                                case "1":
                                    label19.Text = str_compatibility[i];
                                    this.progressBar1.Value = antcom;
                                    this.progressBar1.ForeColor = System.Drawing.Color.PaleGreen;
                                    label23.Text = "";
                                    break;
                                case "2":
                                    label21.Text = str_compatibility[i];
                                    this.progressBar2.Value = antcom;
                                    this.progressBar2.ForeColor = System.Drawing.Color.PaleGreen;
                                    label24.Text = "";
                                    break;
                                case "3":
                                    label28.Text = str_compatibility[i];
                                    this.progressBar3.Value = antcom;
                                    this.progressBar3.ForeColor = System.Drawing.Color.PaleGreen;
                                    label26.Text = "";
                                    break;
                                case "4":
                                    label29.Text = str_compatibility[i];
                                    this.progressBar4.Value = antcom;
                                    this.progressBar4.ForeColor = System.Drawing.Color.PaleGreen;
                                    label27.Text = "";
                                    break;
                                default:
                                    break;
                            }

                        }
                        else
                        {
                            switch (str_antnum[i])
                            {
                                case "1":
                                    label19.Text = "";
                                    this.progressBar1.ForeColor = System.Drawing.Color.Red;
                                    this.progressBar1.Value = 100;
                                    label23.Text = "天线未连接";  //" no ant connected"
                                    break;
                                case "2":
                                    label21.Text = "";
                                    this.progressBar2.Value = 100;
                                    this.progressBar2.ForeColor = System.Drawing.Color.Red;
                                    label24.Text = "天线未连接";
                                    break;
                                case "3":
                                    label28.Text = "";
                                    this.progressBar3.Value = 100;
                                    this.progressBar3.ForeColor = System.Drawing.Color.Red;
                                    label26.Text = "天线未连接";
                                    break;
                                case "4":
                                    label29.Text = "";
                                    this.progressBar4.Value = 100;
                                    this.progressBar4.ForeColor = System.Drawing.Color.Red;
                                    label27.Text = "天线未连接";
                                    break;
                            }
                        }

                    }
                }
            //}
            //catch (Exception ex)
            //{
            //    UpdateLog("Error:" + ex.ToString());
            //    ErrorLog.WriteError(ex.ToString());
            //    return;
            //}
        }


        private void timer_tagdoor_Tick(object sender, EventArgs e)
        {
        }

        public void updatedoor()
        {
            this.listView_md_epc.BeginUpdate();

            string time = DateTime.Now.ToString();
            string ListDeviceIdstr;
            lock (epcstr_list)
            {
                for (int index = 0; index < epcstr_list.Count; index++)
                {
                    if (targedoorDev == epcstr_list[index][0])
                    {
                        try
                        {
                            if ((CurrentCacheItemsSource[index].SubItems[2].Text == epcstr_list[index][5]) && (CurrentCacheItemsSource[index].SubItems[6].Text == PrivateStringFormat.shortTolongNum(epcstr_list[index][0])))
                            {
                                //   viewitem.SubItems[listView_md_epc_AntID].Text = epcstr_list[index][4];
                                CurrentCacheItemsSource[index].SubItems[5].Text = epcstr_list[index][11];
                                CurrentCacheItemsSource[index].SubItems[7].Text = epcstr_list[index][12];
                                CurrentCacheItemsSource[index].SubItems[4].Text = epcstr_list[index][7];
                                CurrentCacheItemsSource[index].SubItems[8].Text = epcstr_list[index][9];
                            }

                            label26_total.Text = listView_md_epc.Items.Count.ToString();
                        }
                        catch
                        {
                            ListViewItem item = new ListViewItem((this.listView_md_epc.Items.Count + 1).ToString("D6"));
                            item.SubItems.Add(epcstr_list[index][4]);
                            item.SubItems.Add(epcstr_list[index][5]);
                            item.SubItems.Add(epcstr_list[index][6]);
                            item.SubItems.Add(epcstr_list[index][7]);
                            item.SubItems.Add(epcstr_list[index][11]);
                            // item.SubItems.Add(epcstr_list[index][0]);
                            ListDeviceIdstr = PrivateStringFormat.shortTolongNum(epcstr_list[index][0]);
                            item.SubItems.Add(ListDeviceIdstr);
                            item.SubItems.Add(epcstr_list[index][12]);
                            item.SubItems.Add(epcstr_list[index][9]);
                            item.SubItems.Add(""); // 温度
                            item.SubItems.Add(epcstr_list[index][13]);


                            CurrentCacheItemsSource.Add(item);

                            label26_total.Text = listView_md_epc.Items.Count.ToString();
                            // this.listView_md_epc.Items[this.listView_md_epc.Items.Count - 1].Selected = true;
                            // this.listView_md_epc.Items[this.listView_md_epc.Items.Count - 1].BackColor = System.Drawing.Color.FromArgb(red, green, blue);
                        }

                        listView_md_epc.VirtualListSize = CurrentCacheItemsSource.Count;
                        listView_md_epc.Invalidate();

                        this.listView_md_epc.Items[this.listView_md_epc.Items.Count - 1].EnsureVisible();

                        // label26_total.Text = listView_md_epc.Items.Count.ToString();
                    }
                }

                label26_total.Text = listView_md_epc.Items.Count.ToString();
            }

            this.listView_md_epc.EndUpdate();
        }

        private void button8_Click_3(object sender, EventArgs e)
        {
            byte ant_state = 0x00;
            if (radioButton1.Checked == true)
            {
                ant_state = 0x01;
            }
            else if (radioButton2.Checked == true)
            {
                ant_state = 0x00;
            }
            string result = ReaderControllor.AntCheck(currentclient, ant_state);
        }

        private void Text_time_fliecabinet_TextChanged(object sender, EventArgs e)
        {
            if (Text_time_fliecabinet.Text == "")
            {
                return;
            }
            if (Text_time_fliecabinet.Text.Substring(0, 1) == "-" || Text_time_fliecabinet.Text.Substring(0, 1) == "0")
            {
                return;
            }

            try
            {
                int timenum = int.Parse(Text_time_fliecabinet.Text);

                timerTest.Interval = TimerShowID.Interval = show_EPC_t.Interval = int.Parse(Text_time_fliecabinet.Text);
                Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                string InventoryTime = Text_time_fliecabinet.Text;
                cfa.AppSettings.Settings["InventoryTime"].Value = InventoryTime;
                cfa.Save();
                if (isLogOpen)
                {
                    EventLog.WriteEvent("设置EPC数据显示时间间隔" + InventoryTime + "ms成功", null);
                }
            }
            catch
            { 
            
            }
        }

        int ClickNum = 0;
        private void button7_Click_3(object sender, EventArgs e)
        {
            //switch (ClickNum)
            //{
            //    case 0:
            //        double aa = 113.968378519626;
            //        double bb = 22.5914150869131;

            //        mapView.UpdateView_Old(aa, bb, "101218", "085807.000", "0.49", "275.74", "O");
            //        ClickNum++;
            //        break;
            //    case 1:
            //        mapView.UpdateView_Old(115.96893647422333, 24.593817189032447, "023206.002", "071218", "0.22", "12.92", "A");
            //        ClickNum++;
            //        break;
            //    case 2:
            //        mapView.UpdateView_Old(116.96893647422333, 25.593817189032447, "023206.003", "071218", "0.23", "12.93", "N");
            //        ClickNum++;
            //        break;
            //    default:
            //        break;
            //}
        }

        private void button10_Click_3(object sender, EventArgs e)
        {

        }

        private void button10_Click_4(object sender, EventArgs e)
        {
           // mapView.Delete_Local();
        }

        private void button7_Click_4(object sender, EventArgs e)
        {
            switch (ClickNum)
            {
                case 0:
                    double aa = 113.968378519626;
                    double bb = 22.5914150869131;

                    mapView.UpdateView_Old(aa, bb, "101218", "085807.000", "0.49", "275.74", "O");
                    ClickNum++;
                    break;
                case 1:
                    mapView.UpdateView_Old(115.96893647422333, 24.593817189032447, "023206.002", "071218", "0.22", "12.92", "A");
                    ClickNum++;
                    break;
                case 2:
                    mapView.UpdateView_Old(116.96893647422333, 25.593817189032447, "023206.003", "071218", "0.23", "12.93", "N");
                    ClickNum++;
                    break;
                default:
                    break;
            }
        }






        //----------------------------------------------------------------------------------------------------------------------------------


    }
}
