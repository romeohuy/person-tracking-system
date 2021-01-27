using SrDemo.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO.Ports;
using System.Linq; //SerialPort
using System.Net;
using System.Threading;             //thread
using System.Windows.Forms;
using TrackPerson.Service;

namespace SrDemo
{


    public partial class SrDemo : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "";

        BindingSource sourcebinding = new BindingSource();

        public delegate void MyInvoke(multi_query_epc_t tags);

        private const int OPER_OK = 0;          // Cho biết chức năng sr api đã được thực hiện thành công chưa ( 表示sr api函数是否成功执行 )
        private int m_connect_type = transfer.CONNECT_SERIAL;
        private bool m_bConnect = false;
        private const int READ_FLAG = 1;
        private const int WRITE_FLAG = 2;

        private volatile List<tag> tags_list = new List<tag>(1000);

        private int tags_count_persecond = 0;


        // Mục hiển thị nhãn ( 标签显示项 )
        private const int listView_label_Num = 0;
        private const int listView_label_AntID = 1;
        private const int listView_label_EPC = 2;
        private const int listView_label_TID = 3;
        private const int listView_label_PC = 4;
        private const int listView_label_RSSI = 5;
        private const int listView_label_Count = 6;
        private const int listView_label_Last_Time = 7;


        // 网络模块显示项
        private const int listView_net_Num = 0;
        private const int listView_net_MAC = 1;
        private const int listView_net_IP = 2;

        //public void binding()
        //{
        //    txbid.DataBindings.Add(new Binding("Text", grvShow.DataSource, "id", true, DataSourceUpdateMode.Never));
        //    textBoxHsCode.DataBindings.Add(new Binding("Text", grvShow.DataSource, "HS_CODE", true, DataSourceUpdateMode.Never));
        //    textBoxClass.DataBindings.Add(new Binding("Text", grvShow.DataSource, "CLASS", true, DataSourceUpdateMode.Never));
        //    textBox_data_EPC.DataBindings.Add(new Binding("Text", grvShow.DataSource, "EPC", true, DataSourceUpdateMode.Never));
        //    textBox_data_TID.DataBindings.Add(new Binding("Text", grvShow.DataSource, "TID", true, DataSourceUpdateMode.Never));
        //    textBox_data_USER.DataBindings.Add(new Binding("Text", grvShow.DataSource, "USER", true, DataSourceUpdateMode.Never));
        //    textBox_data_RFU.DataBindings.Add(new Binding("Text", grvShow.DataSource, "RFU", true, DataSourceUpdateMode.Never));
        //}

        private static TrackingPersonApiConsumer _trackingPersonApiConsumer;
        private static List<StudentInfoResponse> _listStudentsResponse;
        public SrDemo()
        {
            InitializeComponent();

            _trackingPersonApiConsumer = new TrackingPersonApiConsumer();

            try
            {
                _listStudentsResponse = _trackingPersonApiConsumer.GetListStudents();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            grvShow.DataSource = sourcebinding;

            //var trackingPersonDal = new TrackingPersonPersonDAL();
            grvShow.DataSource = ModelHelper.ToTrackingPersons(_listStudentsResponse);

            //binding();

            string[] ports = SerialPort.GetPortNames();

            // Them ten cua tat ca cac cong vao muc COM Port. 
            foreach (string port in ports)
            {
                cbCOM.Items.Add(port);
            }
            cbBaute.SelectedIndex = 4;       // 115200

            //操作 log
            this.listView_oper_log.Columns.Add("Num", 50, HorizontalAlignment.Left);//序号
            this.listView_oper_log.Columns.Add("Time", 150, HorizontalAlignment.Left);//时间
            this.listView_oper_log.Columns.Add("Operation Result", 450, HorizontalAlignment.Left);//执行结果
            this.listView_oper_log.GridLines = true;
            this.listView_oper_log.FullRowSelect = true;
            this.listView_oper_log.MultiSelect = false;

            // region
            // comboBox_region.SelectedIndex = 1;          // china2

            // set baud rate
            // comboBox_set_baudrate.SelectedIndex = 4;    // 115200

            // ant
            //        checkBox_ant1.Checked = true;               // 默认ant1被选中  //2015-03-10-00

            this.listView_label.Columns.Add("Num", 30, HorizontalAlignment.Left);
            this.listView_label.Columns.Add("AntID", 30, HorizontalAlignment.Left);
            this.listView_label.Columns.Add("EPC", 250, HorizontalAlignment.Left);
            this.listView_label.Columns.Add("TID", 80, HorizontalAlignment.Left);
            this.listView_label.Columns.Add("PC", 60, HorizontalAlignment.Left);
            this.listView_label.Columns.Add("RSSI", 60, HorizontalAlignment.Left);
            this.listView_label.Columns.Add("Count", 50, HorizontalAlignment.Left);
            this.listView_label.Columns.Add("Last Time", 130, HorizontalAlignment.Left);
            this.listView_label.GridLines = true;
            this.listView_label.FullRowSelect = true;
            this.listView_label.MultiSelect = false;

            // memory bank
            //comboBox_mb.SelectedIndex = 1;      // epc   
            // filter
            //filterbox.SelectedIndex = 0;
        }

        private string add_zero(string str)
        {
            string str_buf;
            int temp = 20 - (str.Length);
            if (temp != 20)
            {
                for (int i = 0; i < temp; i++)
                {
                    str = str + "\0";
                }
            }
            str_buf = str;
            return str_buf;
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
        private void tags_list_init()
        {
            tags_list.Clear();
        }


        // 遍历列表，epc已存在，返回其在列表中的编号。不存在返回-1
        private int tags_list_traverse(string epc)
        {
            for (int index = 0; index < tags_list.Count; index++)
            {
                if (tags_list[index].epc == epc)
                {
                    return index;
                }
            }

            return -1;
        }

        // 添加对象到列表中
        private void tags_list_add(tag item)
        {
            tags_list.Add(item);
        }


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
            string str_tid = "";
            for (int index = 0; index < tid_len; index++)
            {
                str_tid += tid[index].ToString("X2");
                if (index < tid_len - 1)
                {
                    str_tid += "-";
                }
            }
            return str_tid;
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

        // 单次寻标签
        private void single_analyze_data(query_epc_t tag)
        {
            string temp_epc = epc_format(tag.epc.epc, tag.epc.epc_len);
            // 判断当前标签是会否存在列表中
            int offset = 0;
            if (-1 == (offset = tags_list_traverse(temp_epc)))
            {
                tag temp_tag = new tag();

                ++temp_tag.count;

                temp_tag.ant_id = tag.ant_id;
                temp_tag.pc = pc_calculate(tag.epc.pc_msb, tag.epc.pc_lsb);
                temp_tag.rssi = rssi_calculate(tag.rssi_msb, tag.rssi_lsb);
                temp_tag.epc = temp_epc;
                temp_tag.tid = tid_format(tag.tid, tag.tid_len);
                temp_tag.latest_time = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);

                tags_list_add(temp_tag);
            }
            else        // 标签已存在，增加count 即可
            {
                tags_list[offset].count++;
                tags_list[offset].pc = pc_calculate(tag.epc.pc_msb, tag.epc.pc_lsb);
                tags_list[offset].rssi = rssi_calculate(tag.rssi_msb, tag.rssi_lsb);
                tags_list[offset].ant_id = tag.ant_id;
                tags_list[offset].latest_time = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
            }
        }



        // 循环寻标签
        private void multi_analyze_data(multi_query_epc_t tags)
        {
            for (int index = 0; index < tags.packet_num; index++)
            {
                if ((tags.tags_epc[index].epc.epc_len > 124) || (tags.tags_epc[index].epc.epc_len <= 0))
                {
                    continue;
                }

                set_count();

                string temp_epc = epc_format(tags.tags_epc[index].epc.epc, tags.tags_epc[index].epc.epc_len);
                string temp_tid = tid_format(tags.tags_epc[index].tid, tags.tags_epc[index].tid_len);
                // 判断当前标签是会否存在列表中
                int offset = 0;
                if (-1 == (offset = tags_list_traverse(temp_epc)))
                {
                    tag temp_tag = new tag();

                    temp_tag.count = 1;
                    temp_tag.ant_id = tags.tags_epc[index].ant_id;
                    temp_tag.pc = pc_calculate(tags.tags_epc[index].epc.pc_msb, tags.tags_epc[index].epc.pc_lsb);
                    temp_tag.rssi = rssi_calculate(tags.tags_epc[index].rssi_msb, tags.tags_epc[index].rssi_lsb);
                    temp_tag.epc = temp_epc;
                    temp_tag.tid = temp_tid;
                    temp_tag.latest_time = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);

                    // 写保护
                    //          lock (tags_list)
                    {
                        tags_list_add(temp_tag);
                    }

                }
                else        // 标签已存在，增加count 即可
                {
                    // 写保护
                    {
                        tags_list[offset].count = tags_list[offset].count + 1;
                        tags_list[offset].pc = pc_calculate(tags.tags_epc[index].epc.pc_msb, tags.tags_epc[index].epc.pc_lsb);
                        tags_list[offset].rssi = rssi_calculate(tags.tags_epc[index].rssi_msb, tags.tags_epc[index].rssi_lsb);
                        tags_list[offset].ant_id = tags.tags_epc[index].ant_id;
                        tags_list[offset].latest_time = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
                    }
                }
            }
        }



        private void UpdataLabel(query_epc_t tag)
        {
            switch (tag.ant_id)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    single_analyze_data(tag);
                    updata_tags_listview();
                    break;

                default:
                    break;
            }
        }


        private void UpdataLabel(tag tag_item)
        {
            //转换成string

            string str_pc = tag_item.pc.ToString("X2");
            string str_epc = tag_item.epc;
            string str_tid = tag_item.tid;
            string str_read_cnt = tag_item.count.ToString();
            string str_ant_id = tag_item.ant_id.ToString();
            string str_rssi = tag_item.rssi.ToString("f1");
            string str_time = tag_item.latest_time;

            //       AddTagToBuf(tag);

            bool Exist = false;
            //判断标签是否被重复扫描
            foreach (ListViewItem viewitem in this.listView_label.Items)
            {
                if (viewitem.SubItems[listView_label_EPC].Text == str_epc)
                {
                    viewitem.SubItems[listView_label_AntID].Text = str_ant_id;
                    viewitem.SubItems[listView_label_PC].Text = str_pc;
                    viewitem.SubItems[listView_label_RSSI].Text = str_rssi;
                    viewitem.SubItems[listView_label_Count].Text = str_read_cnt;
                    viewitem.SubItems[listView_label_Last_Time].Text = str_time;
                    Exist = true;
                    break;
                }
            }

            if (!Exist)
            {
                ListViewItem item = new ListViewItem((this.listView_label.Items.Count + 1).ToString());
                item.SubItems.Add(str_ant_id);
                item.SubItems.Add(str_epc);
                item.SubItems.Add(str_tid);
                item.SubItems.Add(str_pc);
                item.SubItems.Add(str_rssi);
                item.SubItems.Add(str_read_cnt);
                item.SubItems.Add(str_time);
                this.listView_label.Items.Add(item);
                this.listView_label.Items[this.listView_label.Items.Count - 1].EnsureVisible();
                this.listView_label.Items[this.listView_label.Items.Count - 1].Selected = true;

                //            multi_get_tag_count_add();
            }
        }



        private void updata_tags_listview()
        {
            List<tag> temp_tags_list = new List<tag>(1000);

            //          lock (tags_list)
            {
                temp_tags_list = tags_list;
            }

            for (int index = 0; index < temp_tags_list.Count; index++)
            {
                UpdataLabel(temp_tags_list[index]);
            }
        }

        /* * */

        private void UpdateLog(string strLog)
        {
            string strDateTime = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
            ListViewItem item = new ListViewItem((this.listView_oper_log.Items.Count + 1).ToString());
            item.SubItems.Add(strDateTime);
            item.SubItems.Add(strLog);
            this.listView_oper_log.Items.Add(item);
            this.listView_oper_log.Items[this.listView_oper_log.Items.Count - 1].EnsureVisible();
            this.listView_oper_log.Items[this.listView_oper_log.Items.Count - 1].Selected = true;
        }


        private void set_connect_type(int connect_type)
        {
            m_connect_type = connect_type;
        }

        private int get_connect_type()
        {
            return m_connect_type;
        }


        private void get_version()
        {
            int ret = 0;
            byte[] hard_ware = new byte[global.PACKET_128];
            ret = sr_api.Get_hardware_version(hard_ware); // 获取硬件版本号
            string hard_str;
            if (OPER_OK == ret)
            {
                string hard_ver;
                hard_ver = System.Text.Encoding.Default.GetString(hard_ware);

                label_hardware_version.Text = "Hardware: " + hard_ver; //Hardware:硬件版本:

                hard_str = "Get hardware success.";//";获取硬件版本成功！
            }
            else
            {
                hard_str = "！Get hardware fail.";//Get hardware fail.";获取硬件版本失败
            }
            UpdateLog(hard_str);

            byte[] firm_ware = new byte[global.PACKET_128];
            ret = sr_api.Get_firmware_version(firm_ware); // 获取固件版本号
            string firm_str;
            if (OPER_OK == ret)
            {
                string firm_ver;
                firm_ver = System.Text.Encoding.Default.GetString(firm_ware);

                label_firmware_version.Text = "Firmware: " + firm_ver; //Firmware:固件版本:

                firm_str = "Get Firmware success.";//Get Firmware success.";获取固件版本成功!
            }
            else
            {
                firm_str = "Get Firmware fail.";//Get Firmware fail."获取固件版本失败!;
            }
            UpdateLog(firm_str);
        }

        //private int cur_pitch = 0;
        //private net_device_t net_device = new net_device_t();
        private void btnConnect_Click(object sender, EventArgs e)
        {
            string oper_result;
            try
            {
                int connect_type = get_connect_type();
                int ret = 0;

                switch (connect_type)
                {
                    case transfer.CONNECT_SERIAL:
                        ret = sr_api.basic_init(transfer.CONNECT_SERIAL);   //初始化为网络通信模式
                        if (m_bConnect)
                        {
                            try
                            {

                                sr_api.uart_trans_close();
                                DialogResult information = MessageBox.Show("Disconnected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                UpdateLog("Close Com successful");//Close Com successful");关闭串口成功！
                                cbCOM.Enabled = true;
                                cbBaute.Enabled = true;
                                label_firmware_version.Text = "Firmware: ";
                                label_hardware_version.Text = "Hardware: ";
                            }
                            catch
                            {
                                UpdateLog("Close Com fail");//Close Com fail");关闭 串口失败！
                            }

                        }
                        else
                        {
                            uart_open_t _open = new uart_open_t(cbCOM.Text, int.Parse(cbBaute.Text));

                            //MessageBox.Show("COM = " + cbCOM.Text + " 波特率 = " + cbBaute.Text, " 信息提示");

                            ret = transfer.transfer_open(ref _open);
                            if (OPER_OK == ret)
                            {

                                DialogResult information = MessageBox.Show("Connected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                UpdateLog("Open Com successfull");//Open Com successful");打开串口成功！
                                cbCOM.Enabled = false;
                                cbBaute.Enabled = false;

                                get_version();
                            }
                            else
                            {

                                DialogResult warning = MessageBox.Show("Wrong port, please choose again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                UpdateLog("Open Com fail");//Open Com fail");打开串口失败！
                                cbCOM.Enabled = true;
                                cbBaute.Enabled = true;
                            }
                        }
                        break;
                }

                if (OPER_OK == ret)
                {
                    m_bConnect = !m_bConnect;
                    btnConnect.Text = m_bConnect ? "Close" : "Connect"; //"Close关闭" : 打开"";                 
                }
            }
            catch (Exception ex)
            {
                oper_result = "Operation Error :" + ex.Message;
                UpdateLog(oper_result);
            }
        }

        private void rbCOM_Click(object sender, EventArgs e)
        {
            //rbNet.Checked = false;
            set_connect_type(transfer.CONNECT_SERIAL);

            //enable
            cbCOM.Enabled = true;
            cbBaute.Enabled = true;
        }

        private void single_query()
        {
            string oper_result;
            try
            {
                // 1 单次查询标签
                query_epc_t oper_type = new query_epc_t();

                byte[] epc = new byte[global.PACKET_128];
                byte[] tid = new byte[global.PACKET_128];
                ushort rssi = 0;
                byte ant_id = 0;
                byte epc_len = 0;
                byte tid_len = 0;
                ushort pc = new ushort();

                int ret = sr_api.Sigle_Query_Tags_Epc(epc, ref epc_len, tid, ref tid_len, ref rssi, ref ant_id);

                if (OPER_OK == ret)
                {
                    oper_type.epc.epc = epc;
                    oper_type.tid = tid;
                    oper_type.rssi_lsb = (byte)(rssi & 0xFF);
                    oper_type.rssi_msb = (byte)((rssi >> 8) & 0xFF);
                    oper_type.ant_id = ant_id;
                    oper_type.epc.epc_len = (char)epc_len;
                    oper_type.tid_len = tid_len;
                    pc = calculate_pc(epc.ToString());
                    oper_type.epc.pc_lsb = (byte)(pc & 0xff);
                    oper_type.epc.pc_msb = (byte)((pc >> 8) & 0xff);
                    UpdataLabel(oper_type);

                    oper_result = "Single query success.";//";单次查寻成功！
                }
                else
                {
                    oper_result = "Single query fail.";//"单次查寻失败！;
                }
                UpdateLog(oper_result);
            }
            catch (Exception ex)
            {
                oper_result = "Operation Error :" + ex.Message;
                UpdateLog(oper_result);
            }
        }

        const string MULTI_START_LABEL = "Query"; //开始寻标签
        const string MULTI_STOP_LABEL = "Stop"; //Stop停止寻标签
        private Thread multi_get_thread;

        private void _multi_get()
        {
            while (true)
            {
                multi_query_epc_t multi_epc = new multi_query_epc_t();

                if (!multi_get_thread.IsAlive)
                {
                    break;
                }

                int ret = sr_api.Get_Multi_Query_Tags_Epc_Data(ref multi_epc);

                multi_analyze_data(multi_epc);
                Thread.Sleep(0);

            }
        }


        private void _multi_stop()
        {
            string oper_result;
            try
            {
                // 1 停止循环读标签
                int ret = sr_api.Stop_Multi_Query_Tags_Epc();

                if (OPER_OK == ret)
                {
                    oper_result = "Stop Multi query success.";//";停止循环查寻成功！
                }
                else
                {
                    oper_result = "Stop Multi query fail.";//";停止循环查寻失败！
                }
                UpdateLog(oper_result);
            }
            catch (Exception ex)
            {
                oper_result = "Operation Error :" + ex.Message;
                UpdateLog(oper_result);
            }
        }


        private void multi_query()
        {

            multi_get_thread = new Thread(new ThreadStart(this._multi_get));
            if (MULTI_START_LABEL == this.button_query.Text)    //开始循环寻标签
            {

                button_query.Text = MULTI_STOP_LABEL;

                UInt32 times = 0;
                int ret = sr_api.Multi_Query_Tags_Epc(times);

                if (OPER_OK == ret)
                {
                    UpdateLog("Start Multi query success.");//"启动循环查寻标签成功！
                                                            //         multi_init();
                    multi_get_thread.Start();
                    timer_scan.Enabled = true;
                }
                else
                {
                    UpdateLog("Start Multi query fail.");//启动循环查寻标签失败！
                }
            }
            else               //停止循环寻标签
            {
                button_query.Text = MULTI_START_LABEL;
                //         this.stop_multi_config();

                _multi_stop();
                timer_scan.Enabled = false;
            }
        }
        //------------------------------------------------------------------------2015-03-11-00
        static bool start_tag = false;
        private void auto_multi_query()
        {
            multi_get_thread = new Thread(new ThreadStart(this._multi_get));

            //if (MULTI_START_LABEL == this.button_query.Text)    //开始循环寻标签

            if (start_tag)
            {

                //button_query.Text = MULTI_STOP_LABEL;

                UInt32 times = 0;
                int ret = sr_api.Multi_Query_Tags_Epc(times);

                if (OPER_OK == ret)
                {
                    UpdateLog("Start Multi query success.");//"启动循环查寻标签成功！
                    //         multi_init();
                    multi_get_thread.Start();
                    timer_scan.Enabled = true;
                }
                else
                {
                    UpdateLog("Start Multi query fail.");//Start Multi query fail.启动循环查寻标签失败！
                }
            }
            else               //停止循环寻标签
            {
                button_query.Text = MULTI_START_LABEL;
                //         this.stop_multi_config();

                _multi_stop();
                timer_scan.Enabled = false;
            }
        }


        //------------------------------------------------------------------------

        private void button_query_Click(object sender, EventArgs e)
        {
            if (true == radioButton_single.Checked) // Tìm kiếm đơn ( 单次寻标签 )
            {
                single_query();
            }
            else if (true == radioButton_multi.Checked) // Tìm thẻ nhiều lần ( 多次寻标签 )
            {
                multi_query();
            }
            else
            {
                // loi ( 异常 )
                UpdateLog("Operation Error.");
            }
        }

        // Tính giá trị PC tương ứng thông qua EPC ( 通过EPC计算出其相应的PC值 )
        private ushort calculate_pc(string str_epc)
        {
            ushort temp_pc = (ushort)str_epc.Length;
            temp_pc /= 4;
            temp_pc <<= 11;
            temp_pc &= 0xF800;

            return temp_pc;
        }

        //通过EPC计算出其相应的PC值
        private ushort calc_pc(string str_epc)
        {
            ushort temp_pc = (ushort)str_epc.Length;
            temp_pc /= 4;
            temp_pc <<= 11;
            temp_pc &= 0xF800;

            return temp_pc;
        }



        // shex 长度为8个字节
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

        //////////////////////////////////////////// Read
        private void button_data_read_Click(object sender, EventArgs e)
        {
            read_data_EPC();
            Thread.Sleep(1000);
            read_data_TID();
            Thread.Sleep(1000);
            read_RFU();
            Thread.Sleep(1000);
            //read_USER();
        }

        //tid///////////////////////////////////////
        private void read_data_TID()
        {
            string oper_result;
            this.textBox_data_TID.Text = null;
            try
            {
                // 1 nhan mat khau truy cap ( 获取访问密码 )
                uint password = 0;
                // 2 Xác định có bắt đầu lọc hay không và nhận / đặt giá trị của PC và EPC (判断是否启动过滤，并 获取/设置 PC 和 EPC 的值)
                byte[] epc = new byte[global.PACKET_128];
                byte epc_len = 0;
                //string filter_data = textBox_tag_epc.Text;
                byte filter_bak = 0;
                filter_bak = 0x00;
                // Không lọc, pc và epc đều trống ( 不过滤，pc，epc都为空 )                
                for (int index = 0; index < 12; index++)
                {
                    epc[index] = 0x00;
                }

                epc_len = 0;   // Độ dài bằng 0 mà không lọc ( 不过滤则长度为0 )
                // 3 nhan loai bo nho ( 获取 memory bank 的类型 )
                byte mem_bank_tid = 2;/*(byte)comboBox_mb.SelectedIndex;*/

                // 4 Lấy địa chỉ bắt đầu trong bộ nhớ để đọc ( 获取要读取的内存中的起始地址 )
                ushort temp_addr_tid = 0/*ushort.Parse(add_tid.Text)*/; //TID                   
                // 5 Lấy độ dài của dữ liệu cần đọc ( 获取要读取的数据的长度 )
                ushort temp_len_tid = 6/*ushort.Parse(len_tid.Text)*/;

                // 6 Lệnh truy vấn dữ liệu nhãn ( 查询标签数据 命令 )                
                byte[] recv_buffer = new byte[global.PACKET_MID];
                byte ant_id = 0;
                int ret = 0;

                ret = sr_api.read_data(password, filter_bak, epc_len, epc, mem_bank_tid, temp_addr_tid, temp_len_tid, recv_buffer, ref ant_id);
                //int ret = sr_api.read_data(password, pc, epc, epc_len, mem_bank, temp_addr, temp_len,recv_buffer,ref recv_len, ref ant_id);

                if (OPER_OK == ret)
                {
                    oper_result = "Read TID Tag data success.";//"; Đọc nhãn thành công! ( 读取标签成功！)                                
                    string recv_str = BitConverter.ToString(recv_buffer, 0, temp_len_tid * 2).ToUpper().Replace("-", "");
                    textBox_data_TID.Text = recv_str;

                }
                else
                {
                    oper_result = "Read TID Tag data fail.";//";khong the doc nhan ( 读取标签失败！)
                }
                UpdateLog(oper_result);
            }
            catch (Exception ex)
            {
                oper_result = "Operation Error :" + ex.Message;
                UpdateLog(oper_result);
            }
        }

        ////////////////////////EPC
        private void read_data_EPC()
        {
            string oper_result;
            this.textBox_data_EPC.Text = null;

            try
            {
                // 1 nhan mat khau truy cap ( 获取访问密码 )
                uint password = 0;
                // 2 Xác định có bắt đầu lọc hay không và nhận / đặt giá trị của PC và EPC (判断是否启动过滤，并 获取/设置 PC 和 EPC 的值)
                byte[] epc = new byte[global.PACKET_128];
                byte epc_len = 0;
                //string filter_data = textBox_tag_epc.Text;
                byte filter_bak = 0;
                filter_bak = 0x00;
                // Không lọc, pc và epc đều trống ( 不过滤，pc，epc都为空 )                
                for (int index = 0; index < 12; index++)
                {
                    epc[index] = 0x00;
                }

                epc_len = 0;   // Độ dài bằng 0 mà không lọc ( 不过滤则长度为0 )
                               // 3 nhan loai bo nho ( 获取 memory bank 的类型 )
                byte mem_bank_epc = 1;/*(byte)comboBox_mb.SelectedIndex;*/

                // 4 Lấy địa chỉ bắt đầu trong bộ nhớ để đọc ( 获取要读取的内存中的起始地址 )
                ushort temp_addr_epc = 2/*ushort.Parse(textBox1_data_address.Text)*/; //TID                   
                                                                                      // 5 Lấy độ dài của dữ liệu cần đọc ( 获取要读取的数据的长度 )
                ushort temp_len_epc = 6/*ushort.Parse(textBox1_data_len.Text)*/;

                // 6 Lệnh truy vấn dữ liệu nhãn ( 查询标签数据 命令 )                
                byte[] recv_buffer = new byte[global.PACKET_MID];
                byte ant_id = 0;
                int ret = 0;

                ret = sr_api.read_data(password, filter_bak, epc_len, epc, mem_bank_epc, temp_addr_epc, temp_len_epc, recv_buffer, ref ant_id);
                //int ret = sr_api.read_data(password, pc, epc, epc_len, mem_bank, temp_addr, temp_len,recv_buffer,ref recv_len, ref ant_id);

                if (OPER_OK == ret)
                {
                    oper_result = "Read EPC Tag data success.";//"; Đọc nhãn thành công! ( 读取标签成功！)                                
                    string recv_str1 = BitConverter.ToString(recv_buffer, 0, temp_len_epc * 2).ToUpper().Replace("-", "");
                    textBox_data_EPC.Text = recv_str1;
                }
                else
                {
                    oper_result = "Read Tag data EPC fail.";//";khong the doc nhan ( 读取标签失败！)
                }

                UpdateLog(oper_result);

                //Selected row
                if (textBox_data_EPC.Text != null && (radioButtonXinVeSom.Checked || radioButtonXinDiTre.Checked))
                {
                    foreach (DataGridViewRow row in grvShow.Rows)
                    {
                        if (row.Cells["EPC"].Value != null && row.Cells["EPC"].Value.ToString().ToLower().Equals(textBox_data_EPC.Text?.ToLower()))
                        {
                            row.Selected = true; break;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                oper_result = "Operation Error :" + ex.Message;
                UpdateLog(oper_result);
            }
        }

        //RFU///////////////////////////////////
        private void read_RFU()
        {
            string oper_result;
            this.textBox_data_RFU.Text = null;

            try
            {
                // 1 nhan mat khau truy cap ( 获取访问密码 )
                uint password = 0;
                // 2 Xác định có bắt đầu lọc hay không và nhận / đặt giá trị của PC và EPC (判断是否启动过滤，并 获取/设置 PC 和 EPC 的值)
                byte[] epc = new byte[global.PACKET_128];
                byte epc_len = 0;
                //string filter_data = textBox_tag_epc.Text;
                byte filter_bak = 0;
                filter_bak = 0x00;
                // Không lọc, pc và epc đều trống ( 不过滤，pc，epc都为空 )                
                for (int index = 0; index < 12; index++)
                {
                    epc[index] = 0x00;
                }

                epc_len = 0;   // Độ dài bằng 0 mà không lọc ( 不过滤则长度为0 )
                               // 3 nhan loai bo nho ( 获取 memory bank 的类型 )
                byte mem_bank_epc = 0;/*(byte)comboBox_mb.SelectedIndex;*/

                // 4 Lấy địa chỉ bắt đầu trong bộ nhớ để đọc ( 获取要读取的内存中的起始地址 )
                ushort temp_addr_epc = 0/*ushort.Parse(add_rfu.Text)*/; //TID                   
                                                                        // 5 Lấy độ dài của dữ liệu cần đọc ( 获取要读取的数据的长度 )
                ushort temp_len_epc = 4/*ushort.Parse(len_rfu.Text)*/;

                // 6 Lệnh truy vấn dữ liệu nhãn ( 查询标签数据 命令 )                
                byte[] recv_buffer = new byte[global.PACKET_MID];
                byte ant_id = 0;
                int ret = 0;

                ret = sr_api.read_data(password, filter_bak, epc_len, epc, mem_bank_epc, temp_addr_epc, temp_len_epc, recv_buffer, ref ant_id);
                //int ret = sr_api.read_data(password, pc, epc, epc_len, mem_bank, temp_addr, temp_len,recv_buffer,ref recv_len, ref ant_id);

                if (OPER_OK == ret)
                {
                    oper_result = "Read RFU Tag data success.";//"; Đọc nhãn thành công! ( 读取标签成功！)                                
                    string recv_str1 = BitConverter.ToString(recv_buffer, 0, temp_len_epc * 2).ToUpper().Replace("-", "");
                    textBox_data_RFU.Text = recv_str1;
                }
                else
                {
                    oper_result = "Read RFU Tag data  fail.";//";khong the doc nhan ( 读取标签失败！)
                }
                UpdateLog(oper_result);
            }
            catch (Exception ex)
            {
                oper_result = "Operation Error :" + ex.Message;
                UpdateLog(oper_result);
            }
        }
        //user//////////////////////////////////////////////////////

        private void read_USER()
        {
            string oper_result;
            this.textBox_data_USER.Text = null;

            try
            {
                // 1 nhan mat khau truy cap ( 获取访问密码 )
                uint password = 0;
                // 2 Xác định có bắt đầu lọc hay không và nhận / đặt giá trị của PC và EPC (判断是否启动过滤，并 获取/设置 PC 和 EPC 的值)
                byte[] epc = new byte[global.PACKET_128];
                byte epc_len = 0;
                //string filter_data = textBox_tag_epc.Text;
                byte filter_bak = 0;
                filter_bak = 0x00;
                // Không lọc, pc và epc đều trống ( 不过滤，pc，epc都为空 )                
                for (int index = 0; index < 12; index++)
                {
                    epc[index] = 0x00;
                }

                epc_len = 0;   // Độ dài bằng 0 mà không lọc ( 不过滤则长度为0 )
                               // 3 nhan loai bo nho ( 获取 memory bank 的类型 )
                byte mem_bank_epc = 3;/*(byte)comboBox_mb.SelectedIndex;*/

                // 4 Lấy địa chỉ bắt đầu trong bộ nhớ để đọc ( 获取要读取的内存中的起始地址 )
                ushort temp_addr_epc = 0/*ushort.Parse(add_user.Text)*/; //TID                   
                                                                         // 5 Lấy độ dài của dữ liệu cần đọc ( 获取要读取的数据的长度 )
                ushort temp_len_epc = 16/*ushort.Parse(len_user.Text)*/;

                // 6 Lệnh truy vấn dữ liệu nhãn ( 查询标签数据 命令 )                
                byte[] recv_buffer = new byte[global.PACKET_MID];
                byte ant_id = 0;
                int ret = 0;

                ret = sr_api.read_data(password, filter_bak, epc_len, epc, mem_bank_epc, temp_addr_epc, temp_len_epc, recv_buffer, ref ant_id);
                //int ret = sr_api.read_data(password, pc, epc, epc_len, mem_bank, temp_addr, temp_len,recv_buffer,ref recv_len, ref ant_id);

                if (OPER_OK == ret)
                {
                    oper_result = "Read USER Tag data success.";//"; Đọc nhãn thành công! ( 读取标签成功！)                                
                    string recv_str1 = BitConverter.ToString(recv_buffer, 0, temp_len_epc * 2).ToUpper().Replace("-", "");
                    textBox_data_USER.Text = recv_str1;
                }
                else
                {
                    oper_result = "Read USER Tag data  fail.";//";khong the doc nhan ( 读取标签失败！)
                }
                UpdateLog(oper_result);
            }
            catch (Exception ex)
            {
                oper_result = "Operation Error :" + ex.Message;
                UpdateLog(oper_result);
            }
        }


        //////////////////////////////////////////////

        /////////////////////////////////////////////////////////// Write
        private void button_data_write_Click_1(object sender, EventArgs e)
        {
            /*string oper_result;
            try
            {
                // 1 获取访问密码
                uint password = 0;              
                // 2 判断是否启动过滤，并 获取/设置 PC 和 EPC 的值
                //ushort pc;
                byte[] epc = new byte[global.PACKET_128];
                byte epc_len = 0;
                //string filter_data = textBox_tag_epc.Text;
                byte filter_bak = 0x0;
                
                for (int index = 0; index < 12; index++)
                {
                    epc[index] = 0x00;
                }

                epc_len = 0;   // 默认标准标签的epc为12个字节，即6个字

                // 3 Lấy loại ngân hàng bộ nhớ ( 获取 memory bank 的类型 )
                byte mem_bank = (byte)comboBox_mb.SelectedIndex;

                // 4 Lấy địa chỉ bắt đầu trong bộ nhớ để đọc ( 获取要读取的内存中的起始地址 )
                ushort temp_addr = ushort.Parse(textBox_head_address.Text);

                // 5 Lấy độ dài của dữ liệu cần đọc ( 获取要读取的数据的长度 )
                ushort temp_len = ushort.Parse(textBox_data_len.Text);

                // 6 Lệnh truy vấn dữ liệu nhãn ( 查询标签数据 命令 )        
                byte[] write_buffer = new byte[global.PACKET_MID];
                byte write_len = 0;
                //        byte[] temp = System.Text.Encoding.Default.GetBytes(textBox_data.Text);
                hex2asc(textBox_data_EPC.Text, write_buffer, ref write_len);

                byte ant_id = 0;
                // 7 Viết lệnh dữ liệu nhãn (写标签数据 命令)
                int ret = 0;

                ret = sr_api.write_data(password, filter_bak, epc_len, epc, mem_bank, temp_addr, temp_len, write_buffer, ref ant_id);

                if (OPER_OK == ret)
                {
                    oper_result = "Write Tag Data success.";//";向标签写入数据成功！
                }
                else
                {
                    oper_result = "Write Tag Data fail.";//";向标签写入数据失败!
                }
                UpdateLog(oper_result);
            }
            catch (Exception ex)
            {
                oper_result = "Operation Error :" + ex.Message;
                UpdateLog(oper_result);
            }*/
        }
        //Write EPC//////////////////////////////////////////

        private void Write_EPC_Click(object sender, EventArgs e)
        {
            string oper_result;
            try
            {
                // 1 获取访问密码
                uint password = 0;
                // 2 判断是否启动过滤，并 获取/设置 PC 和 EPC 的值
                //ushort pc;
                byte[] epc = new byte[global.PACKET_128];
                byte epc_len = 0;
                //string filter_data = textBox_tag_epc.Text;
                byte filter_bak = 0x0;

                for (int index = 0; index < 12; index++)
                {
                    epc[index] = 0x00;
                }

                epc_len = 0;   // 默认标准标签的epc为12个字节，即6个字

                // 3 Lấy loại ngân hàng bộ nhớ ( 获取 memory bank 的类型 )
                byte mem_bank = 1;//(byte)comboBox_mb.SelectedIndex;

                // 4 Lấy địa chỉ bắt đầu trong bộ nhớ để đọc ( 获取要读取的内存中的起始地址 )
                ushort temp_addr = 2 /*ushort.Parse(textBox1_data_address.Text)*/;

                // 5 Lấy độ dài của dữ liệu cần đọc ( 获取要读取的数据的长度 )
                ushort temp_len = 6 /*ushort.Parse(textBox1_data_len.Text)*/;

                // 6 Lệnh truy vấn dữ liệu nhãn ( 查询标签数据 命令 )        
                byte[] write_buffer = new byte[global.PACKET_MID];
                byte write_len = 0;
                //        byte[] temp = System.Text.Encoding.Default.GetBytes(textBox_data.Text);
                hex2asc(textBox_data_EPC.Text, write_buffer, ref write_len);

                byte ant_id = 0;
                // 7 Viết lệnh dữ liệu nhãn (写标签数据 命令)
                int ret = 0;

                ret = sr_api.write_data(password, filter_bak, epc_len, epc, mem_bank, temp_addr, temp_len, write_buffer, ref ant_id);

                if (OPER_OK == ret)
                {
                    oper_result = "Write EPC Tag Data success.";//";向标签写入数据成功！
                }
                else
                {
                    oper_result = "Write EPC Tag Data fail.";//";向标签写入数据失败!
                }

                UpdateLog(oper_result);
            }
            catch (Exception ex)
            {
                oper_result = "Operation Error :" + ex.Message;
                UpdateLog(oper_result);
            }
        }
        //write USER/////////////////////////////////////////
        private void Write_USER_Click_1(object sender, EventArgs e)
        {
            string oper_result;
            try
            {
                // 1 获取访问密码
                uint password = 0;
                // 2 判断是否启动过滤，并 获取/设置 PC 和 EPC 的值
                //ushort pc;
                byte[] epc = new byte[global.PACKET_128];
                byte epc_len = 0;
                //string filter_data = textBox_tag_epc.Text;
                byte filter_bak = 0x0;

                for (int index = 0; index < 12; index++)
                {
                    epc[index] = 0x00;
                }

                epc_len = 0;   // 默认标准标签的epc为12个字节，即6个字

                // 3 Lấy loại ngân hàng bộ nhớ ( 获取 memory bank 的类型 )
                byte mem_bank = 3;//(byte)comboBox_mb.SelectedIndex;

                // 4 Lấy địa chỉ bắt đầu trong bộ nhớ để đọc ( 获取要读取的内存中的起始地址 )
                ushort temp_addr = 0 /*ushort.Parse(textBox1_data_address.Text)*/;

                // 5 Lấy độ dài của dữ liệu cần đọc ( 获取要读取的数据的长度 )
                ushort temp_len = 16 /*ushort.Parse(textBox1_data_len.Text)*/;

                // 6 Lệnh truy vấn dữ liệu nhãn ( 查询标签数据 命令 )        
                byte[] write_buffer = new byte[global.PACKET_MID];
                byte write_len = 0;
                //        byte[] temp = System.Text.Encoding.Default.GetBytes(textBox_data.Text);
                hex2asc(textBox_data_USER.Text, write_buffer, ref write_len);

                byte ant_id = 0;
                // 7 Viết lệnh dữ liệu nhãn (写标签数据 命令)
                int ret = 0;

                ret = sr_api.write_data(password, filter_bak, epc_len, epc, mem_bank, temp_addr, temp_len, write_buffer, ref ant_id);

                if (OPER_OK == ret)
                {
                    oper_result = "Write USER Tag Data success.";//";向标签写入数据成功！
                }
                else
                {
                    oper_result = "Write USER Tag Data fail.";//";向标签写入数据失败!
                }
                UpdateLog(oper_result);


                //Post data to API
                //var result = _trackingPersonApiConsumer.PutRegisterStudentCard(comboBoxStudents.SelectedValue.ToString(), textBox_data_EPC.Text);
                //if (result.result)
                //{
                //    MessageBox.Show("Đăng ký thành công!");
                //    //Read again api get students
                //    _listStudentsResponse = _trackingPersonApiConsumer.GetListStudents();
                //    comboBoxStudents.DataSource = _listStudentsResponse.data;
                //}
            }
            catch (Exception ex)
            {
                oper_result = "Operation Error :" + ex.Message;
                UpdateLog(oper_result);
            }
        }



        /////////////////////////////////////////////// 

        private void listView_label_DoubleClick(object sender, EventArgs e)
        {
            //textBox_tag_epc.Text = listView_label.SelectedItems[0].SubItems[listView_label_EPC].Text.Replace("-", "");
        }

        private void textBox_access_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_access_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || ((e.KeyChar >= 'a') && (e.KeyChar <= 'f')) || ((e.KeyChar >= 'A') && (e.KeyChar <= 'F')))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private static int query_time = 0;
        private void timer_scan_Tick(object sender, EventArgs e)
        {

            ++query_time;

            label_tags_total.Text = tags_list.Count.ToString();
            label_query_time.Text = query_time.ToString();
            int speed = get_count() / 1;
            label_query_speed.Text = speed.ToString();
            reset_count();

            updata_tags_listview();
        }

        private void listView_net_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void rbNet_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton_module_is_server_CheckedChanged(object sender, EventArgs e)
        {
            //textBox_connect_ip.Text = "";
            //textBox_connect_ip.Enabled = true;

            //label_connect_ip.Text = "Reader IP :";
        }


        protected string GetIP()   //获取本地IP 
        {
            string hostname = Dns.GetHostName();//得到本机名   
            //IPHostEntry localhost = Dns.GetHostByName(hostname);//方法已过期，只得到IPv4的地址  
            IPHostEntry localhost = Dns.GetHostEntry(hostname);
            IPAddress localaddr = localhost.AddressList[0];
            return localaddr.ToString();
        }

        private void radioButton_module_is_client_CheckedChanged(object sender, EventArgs e)
        {
            string host_ip = GetIP();
            //textBox_connect_ip.Text = host_ip;
            //textBox_connect_ip.Enabled = false;

            //label_connect_ip.Text = "Server IP :";
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            tags_list.Clear();
            listView_label.Items.Clear();

            reset_count();
            label_tags_total.Text = "0";

            query_time = 0;
            label_query_time.Text = "0";

            label_query_speed.Text = "0";


        }

        //--------------------------------------------------------------------------------
        private bool IsRegeditKeyExit(string RegistryStr, string KeyStr)
        {
            string[] subkeyNames;

            Microsoft.Win32.RegistryKey rekey = Microsoft.Win32.Registry.LocalMachine;
            Microsoft.Win32.RegistryKey software = rekey.OpenSubKey(RegistryStr);

            if (software == null)
                return false;
            subkeyNames = software.GetValueNames();

            foreach (string keyName in subkeyNames)
            {
                if (keyName == KeyStr)  //判断键值的名称
                {
                    rekey.Close();
                    return true;
                }
            }

            rekey.Close();

            return false;
        }

        private void Create_RegistryKey()//创建注册表
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine;
            try
            {
                Microsoft.Win32.RegistryKey software = key.CreateSubKey("software\\SanRay");
                software = key.OpenSubKey("software\\SanRay", true);
                software.SetValue("Address", @"C:\Program Files\SanRayDemo\Boot.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                key.Close();
            }

        }
        private bool Read_RegistryKey() //读取注册表
        {
            string startName = "C:\\Program Files\\SanRayDemo\\Boot.xml";
            string info = string.Empty;
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine;
            try
            {
                key = key.OpenSubKey("software\\SanRay");

                if (IsRegeditKeyExit("software\\SanRay", "Address"))
                {
                    info = key.GetValue("Address").ToString();
                    MessageBox.Show("The information in the registry is:" + info);//注册表里的信息为:
                }
                else
                {
                    MessageBox.Show("The key value Address doesn't exist;");//键值Address不存在;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (key != null)
                    key.Close();
            }
            if (startName.Equals(info))
                return true;

            return false;

        }
        private void Delete_ReistryKey()//
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine;
            try
            {
                key = key.OpenSubKey("software\\SanRay", true);
                if (IsRegeditKeyExit("software\\SanRay", "Address"))
                {
                    key.DeleteValue("Address");
                    MessageBox.Show("Delete the success");//删除成功
                }
                else
                {
                    MessageBox.Show("The key value Address does not exist");//键值Address不存在;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                key.Close();
            }

        }

        //--------------------------------------------------------------------------
        static bool startOK = false;
        private void button1_Click(object sender, EventArgs e)
        {
            //2015-03-10-22

        }

        private void button1_Click_1(object sender, EventArgs e)
        {


        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void timer_auto_Tick(object sender, EventArgs e)
        {
            if (startOK)  //2015-03-12-00
            {
                startOK = false;
                this.timer_auto.Enabled = false;

                this.timer_scan.Enabled = true;

                multi_query();
            }

        }
        //--------------------------------------------------------------------------------------

        //----------------------------------------------------------------------------------------



        private void button5_Click(object sender, EventArgs e) //2015-03-11-11
        {

        }

        private void SrDemo_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            string oper_result;
            try
            {
                int ret = 0;

                byte fastid_switch = 0x0;
                ret = sr_api.Set_TagFocus(fastid_switch); // 设置FASTID

                if (OPER_OK == ret)
                {
                    oper_result = "Set  FastID success.";//";设置 TagFocus 成功！
                }
                else
                {
                    oper_result = "Set  FastID fail.";//";设置 TagFocus 失败！
                }
                UpdateLog(oper_result);
            }
            catch (Exception ex)
            {
                oper_result = "Operation Error :" + ex.Message;
                UpdateLog(oper_result);
            }

        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void ClearData()
        {
            txbid.Text = "";
            textBox_data_EPC.Text = "";
            textBox_data_RFU.Text = "";
            textBox_data_TID.Text = "";
            textBox_data_USER.Text = "";
            textBoxClass.Text = "";
            textBoxHsCode.Text = "";
            radioButtonRegistStudent.Checked = true;
            grvShow.Update();
            grvShow.Refresh();
        }

        private void btnshowDB_Click(object sender, EventArgs e)
        {
            //string sql = "select id, EPC, TID, USER_ as [USER], RFU from UHF_Desktop";
            //var trackingPersonDal = new TrackingPersonPersonDAL();
            var trackingApi = new TrackingPersonApiConsumer();
            _listStudentsResponse = trackingApi.GetListStudents();
            grvShow.DataSource = ModelHelper.ToTrackingPersons(_listStudentsResponse);
        }

        private void btnSaveDB_Click(object sender, EventArgs e)
        {
            //var trackingPersonDal = new TrackingPersonPersonDAL();
            //trackingPersonDal.Insert(new TrackingPerson()
            //{
            //    EPC = textBox_data_EPC.Text.Trim(),
            //    TID = textBox_data_TID.Text.Trim(),
            //    USER = textBox_data_USER.Text.Trim(),
            //    RFU = textBox_data_RFU.Text.Trim()
            //});
            if (string.IsNullOrEmpty(textBox_data_EPC.Text))
            {
                MessageBox.Show($"Giá trị EPC không hợp lệ","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn thực hiện?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                var trackingApi = new TrackingPersonApiConsumer();
                int.TryParse(txbid.Text, out int hs_id);
                if (radioButtonRegistStudent.Checked)
                {
                    var response = trackingApi.PutRegisterStudentCard(textBoxHsCode.Text, textBox_data_USER.Text, textBox_data_EPC.Text.Trim(), textBoxClass.Text);
                    if (response.result)
                    {
                        MessageBox.Show($"Đăng ký thẻ cho học sinh {textBox_data_USER.Text} thành công!");
                    }
                    else
                    {
                        MessageBox.Show(response.message, "Lỗi api", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (radioButtonXinVeSom.Checked)
                {
                    if (!_listStudentsResponse.Any(_=>_.card_code!= null && _.card_code.Equals(textBox_data_EPC.Text)))
                    {
                        MessageBox.Show($"Thẻ chưa được đăng ký!");
                        return;
                    }

                    var response = trackingApi.XinVeSom(textBox_data_EPC.Text);
                    if (response.result)
                    {
                        MessageBox.Show($"Đã ghi nhận học sinh {textBox_data_USER.Text} về sớm.");
                    }
                    else
                    {
                        MessageBox.Show(response.message, "Lỗi api", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (radioButtonXinDiTre.Checked)
                {
                    if (!_listStudentsResponse.Any(_ => _.card_code != null && _.card_code.Equals(textBox_data_EPC.Text)))
                    {
                        MessageBox.Show($"Thẻ chưa được đăng ký!");
                        return;
                    }

                    var response = trackingApi.XinVoTre(textBox_data_EPC.Text);
                    if (response.result)
                    {
                        MessageBox.Show($"Đã ghi nhận học sinh {textBox_data_USER.Text} vào lớp trễ.");
                    }
                    else
                    {
                        MessageBox.Show(response.message, "Lỗi api", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                _listStudentsResponse = trackingApi.GetListStudents();
                grvShow.DataSource = ModelHelper.ToTrackingPersons(_listStudentsResponse);
            }
            ClearData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //chưa xử lý
        }

        private void grvShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var row = grvShow.Rows[e.RowIndex];
                txbid.Text = row.Cells["id"].Value?.ToString();
                textBoxHsCode.Text = row.Cells["HS_CODE"].Value?.ToString();
                textBoxClass.Text = row.Cells["CLASS"].Value?.ToString();
                var epc = row.Cells["EPC"].Value?.ToString();
                if (!string.IsNullOrEmpty(epc))
                {
                    textBox_data_EPC.Text = epc;
                }
                textBox_data_USER.Text = row.Cells["USER"].Value?.ToString();
                //txbid.Text = row.Cells["id"].Value.ToString();
                //txbid.Text = row.Cells["id"].Value.ToString();
                //txbid.Text = row.Cells["id"].Value.ToString();
            }
        }

        private void grvShow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var row = grvShow.Rows[e.RowIndex];
                txbid.Text = row.Cells["id"].Value?.ToString();
                textBoxHsCode.Text = row.Cells["HS_CODE"].Value?.ToString();
                textBoxClass.Text = row.Cells["CLASS"].Value?.ToString();
                var epc = row.Cells["EPC"].Value?.ToString();
                if (!string.IsNullOrEmpty(epc))
                {
                    textBox_data_EPC.Text = epc;
                }
                textBox_data_USER.Text = row.Cells["USER"].Value?.ToString();
                //txbid.Text = row.Cells["id"].Value.ToString();
                //txbid.Text = row.Cells["id"].Value.ToString();
                //txbid.Text = row.Cells["id"].Value.ToString();
            }
        }





        //----------------------------------------------------------------------------------------------------------------------------------

    }
}
