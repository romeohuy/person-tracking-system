#define CN

//#define EN


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using SrDemo.Log;
using System.Threading;

namespace SrDemo.Config
{

    public delegate void InformHandleWorkMode(object sender,EventArgs e);


    public partial class WorkMode : CustomControl
    {
        public WorkMode()
        {
            InitializeComponent();
        }

        public WorkMode(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();

           // ThreadPool.QueueUserWorkItem(new WaitCallback(LanguagedChanged));

           // ThreadPool.QueueUserWorkItem(delegate { LanguagedChanged(); });
        }

        public static event InformHandleWorkMode AutoReadTags_Event;

        public void AutoReadTags(EventArgs e)
        {
            if (AutoReadTags_Event != null)
            {
                AutoReadTags_Event(this,e);
            }
        }


    
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string result = sd.ReaderControllor.GetWorkMode(WorkingReader);      //错误码 触发模式超时时间  韦根 26/34  模式 触发 循环  读卡 写卡  心跳 延时模式 设备地址 产品系列号 版本号    
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "工作模式" + "命令发送" + "成功",null);
                    }
                    else
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "工作模式" + "命令发送" + "失败",null);
                    }
                }
            }
            catch (Exception ex)
            {
                sd.UpdateLog(ex.ToString());
                if (SrDemo.isLogOpen)
                {
                    ErrorLog.WriteError(ex.ToString());
                }
            }
        }


        public void UpdateAlarmModeBox()
        {
            ResourceManager rm = new ResourceManager(typeof(SrDemo));
            comboBox2.Items.Clear();
            comboBox2.Items.Add(rm.GetString("Alarm1"));
            comboBox2.Items.Add(rm.GetString("Alarm2"));
            comboBox2.Items.Add(rm.GetString("Alarm3"));
            comboBox2.Items.Add(rm.GetString("Alarm4"));
            comboBox2.Items.Add(rm.GetString("Alarm5"));
            comboBox2.Items.Add(rm.GetString("Alarm6"));
            comboBox2.Items.Add(rm.GetString("Alarm7"));
            comboBox2.Items.Add(rm.GetString("Alarm8"));
            comboBox2.Items.Add(rm.GetString("Alarm9"));
            comboBox2.Items.Add(rm.GetString("Alarm10"));
        }

        public void UpdateFilterModeBox()
        {
            ResourceManager rm = new ResourceManager(typeof(SrDemo));
            fliter_type_cb.Items.Clear();
            fliter_type_cb.Items.Add("None");
            fliter_type_cb.Items.Add(rm.GetString("TimerFilter"));
            fliter_type_cb.Items.Add(rm.GetString("CounterFilter"));
            fliter_type_cb.Items.Add(rm.GetString("StorageFilter"));
        }

        public void UpdateLevelModeBox()
        {
            ResourceManager rm = new ResourceManager(typeof(SrDemo));
            comboBox1.Items.Clear();
            comboBox1.Items.Add(rm.GetString("LowLevel"));
            comboBox1.Items.Add(rm.GetString("HighLevel"));
        }




        public void LanguagedChanged()
        {
            ResourceManager rm = new ResourceManager(typeof(SrDemo));
            groupBox5.Text = rm.GetString("BasicConfig");
            groupBox6.Text = rm.GetString("Mode");
            radioButton1.Text = rm.GetString("Mode_Trigger");
            label36.Text = rm.GetString("Mode_Level");
            label37.Text = rm.GetString("Mode_TimeOut");
            radioButton2.Text = rm.GetString("Mode_Auto");
            radioButton3.Text = rm.GetString("ModeMasterslave");
            radioButton14.Text = rm.GetString("Inventory_Single");
            radioButton15.Text = rm.GetString("Mode_Multi");
            groupBox10.Text = rm.GetString("Mode_Weigend");
            radioButton6.Text = rm.GetString("Configure_On");
            radioButton7.Text = rm.GetString("Configure_Off");
            radioButton4.Text = "26" + rm.GetString("Mode_bit");
            radioButton5.Text = "34" + rm.GetString("Mode_bit");
            groupBox11.Text = rm.GetString("Access_Read_Write") + rm.GetString("Mode_Buzzer");
            groupBox9.Text = rm.GetString("Access_Read");
            groupBox12.Text = rm.GetString("Access_Write");
            radioButton8.Text = rm.GetString("Mode_Buzzer") + rm.GetString("Configure_On");
            radioButton9.Text = rm.GetString("Mode_Buzzer") + rm.GetString("Configure_Off");
            radioButton10.Text = rm.GetString("Mode_Buzzer") + rm.GetString("Configure_On");
            radioButton11.Text = rm.GetString("Mode_Buzzer") + rm.GetString("Configure_Off");
            groupBox14.Text = rm.GetString("Mode_Heart_dev");
            fliter_type.Text = rm.GetString("Mode_dev");
            radioButton12.Text = rm.GetString("HeartBeat")+rm.GetString("Configure_On");
            radioButton13.Text = rm.GetString("HeartBeat")+rm.GetString("Configure_Off");
            groupBox2.Text = rm.GetString("MainBoard");
            groupBox3.Text = rm.GetString("Mode_Module");
            label24.Text = rm.GetString("Configure_Firm_Version");
            label29.Text = rm.GetString("Configure_HardVersion");
            label32.Text = rm.GetString("Configure_Firm_Version");
            label34.Text = rm.GetString("Configure_HardVersion");
            button3.Text = rm.GetString("Get");
            button7.Text = rm.GetString("Set");
            groupBox18.Text = rm.GetString("Fliter");
            fliter_type.Text = rm.GetString("Fliter") + rm.GetString("Configure_Gen2_Type");
            label50.Text = rm.GetString("Fliter") + rm.GetString("Inventory_Time");
            label51.Text = rm.GetString("HeartBeat")+rm.GetString("Configure_Interval");
            alm_check_one_lb.Text = rm.GetString("alm_check_one");
            alm_check_two_lb.Text = rm.GetString("alm_check_two");
            Bit_one_lb.Text = rm.GetString("Bit_one");
            Bit_two_lb.Text = rm.GetString("Bit_two");
            alm_alertMode_lb.Text = rm.GetString("alm_alertMode");
            radioButton16.Text = rm.GetString("AccessDoor");
            AetennaBranch_rb.Text = rm.GetString("InvCounter");
            EPCContrastRB.Text = "EPC" + rm.GetString("Compare");
            GetEPCBT.Text = rm.GetString("Getepc");
            SetEPCBT.Text = rm.GetString("Setepc");
            VendingMachineModeRb.Text = rm.GetString("VendingMachineMode");
            groupBox26.Text = rm.GetString("GPIOState");
            label69.Text = rm.GetString("Auto_time");
            label2.Text = rm.GetString("AlarmCount");
            label3.Text = rm.GetString("AlarmTime");
            label4.Text = rm.GetString("StopTime");
            groupBox37.Text = rm.GetString("Configure_Version");
            authorymoderadiobutton.Text = rm.GetString("AuthorizationmMode");
            label107.Text = rm.GetString("WorkingStateAfterTriggering");


            // 上报GPIO输入使能语言切换
            groupBox13.Text = rm.GetString("GPIOInputMake");
            radioButton17.Text = rm.GetString("OpentheReport");
            radioButton18.Text = rm.GetString("ClosetheReport");
            //2018-12-11之后新增
            radioButton21.Text = rm.GetString("Toolkit");
            groupBox15.Text = rm.GetString("GPIO0Synchronous");
            radioButton20.Text = rm.GetString("Open");
            radioButton19.Text = rm.GetString("Close");
            checkBox7.Text = rm.GetString("StateVoiceOpen");

            UpdateAlarmModeBox();
            UpdateFilterModeBox();
            UpdateLevelModeBox();
        }
    
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                ushort faliter_time = ushort.Parse(filtertime_tb.Text);
                byte delay = Convert.ToByte(delay_rb.Text);
                byte wengind_en = 0x00;
                if (radioButton6.Checked == true)
                {
                    wengind_en = 0x01;
                }
                else
                {
                    wengind_en = 0x00;
                }
                byte wengind = 0x00;
                if (radioButton4.Checked == true)
                {
                    wengind = 0x00;
                }
                else
                {
                    wengind = 0x01;
                }
                byte work_mode = 0x00;
                if (radioButton1.Checked == true)
                {
                    work_mode = 0x01;
                }
                else if (radioButton2.Checked == true)
                {
                    work_mode = 0x02;
                    SrDemo.DataMark = true;
                    SrDemo.IsStart = false;
                }
                else if (radioButton3.Checked == true)
                {
                    work_mode = 0x00;
                }
                else if (radioButton16.Checked == true) // 通道门模式
                {
                    work_mode = 0x03;
                }
                else if (AetennaBranch_rb.Checked == true)
                {
                    work_mode = 0x04;
                }
                else if (authorymoderadiobutton.Checked == true)
                {
                    work_mode = 0x05;
                }
                else if (EPCContrastRB.Checked == true)
                {
                    work_mode = 0x06;
                }
                else if (VendingMachineModeRb.Checked == true)
                {
                    work_mode = 0x08;
                }
                else if (radioButton21.Checked == true)
                {
                    work_mode = 0x07;
                }

                byte trigger = 0x00;

#if CN
                if (comboBox1.Text == "低电平")
                {
                    trigger = 0x00;
                }
                else if (comboBox1.Text == "高电平")
                {
                    trigger = 0x01;
                }
#endif

#if EN
                if (comboBox1.Text == "Low")
                {
                    trigger = 0x00;
                }
                else if (comboBox1.Text == "High")
                {
                    trigger = 0x01;
                }

#endif


                byte single_loop = 0x01;
                if (radioButton14.Checked == true)
                {
                    single_loop = 0x00;
                }
                else if (radioButton9.Checked == true)
                {
                    single_loop = 0x01;
                }
                byte read_buzzer = 0x00;


                if (radioButton8.Checked == true)
                {
                    //read_buzzer = 0x01;
                    if (radioButton20.Checked == true)
                    {
                        read_buzzer = 0x81;
                    }
                    else if (radioButton19.Checked == true)
                    {
                        read_buzzer = 0x01;
                    }
                }
                else if (radioButton9.Checked == true)
                {
                   // read_buzzer = 0x00;
                    if (radioButton20.Checked == true)
                    {
                        read_buzzer = 0x80;
                    }
                    else if (radioButton19.Checked == true)
                    {
                        read_buzzer = 0x00;
                    }
                }


                byte write_buzzer = 0x00;
                if (radioButton10.Checked == true)
                {
                    if (checkBox7.Checked == true)
                    {
                        write_buzzer = 0x01;
                    }
                    else
                    {
                        write_buzzer = 0x81;
                    }
                }
                else if (radioButton11.Checked == true)
                {
                    if (checkBox7.Checked == true)
                    {
                        write_buzzer = 0x00;
                    }
                    else
                    {
                        write_buzzer = 0x80;
                    }
                }

                byte heart_beat = 0x00;
                if (radioButton12.Checked == true)             //心跳开关
                {
                    if (radioButton17.Checked == true)          // 上报GPIO输入使能
                    {
                        heart_beat = 0x81;
                    }
                    else
                    {
                        heart_beat = 0x01;
                    }
                }
                else if (radioButton13.Checked == true)
                {
                    if (radioButton17.Checked == true)
                    {
                        heart_beat = 0x80;
                    }
                    else
                    {
                        heart_beat = 0x00;
                    }
                }
                byte MQTT_en = 0x00;

                byte send_duty = byte.Parse(textBox3.Text);

                byte fliter_type = 0;
#if CN
                switch (fliter_type_cb.Text)
                {
                    case "None":
                        fliter_type = 0x00;
                        break;
                    case "定时过滤":
                        fliter_type = 0x01;
                        break;
                    case "盘点过滤":
                        fliter_type = 0x02;
                        break;
                    case "存储过滤":
                        fliter_type = 0x03;
                        break;
                    default:
                        break;
                }
#endif

#if EN
                switch (fliter_type_cb.Text)
                {
                    case "None":
                        fliter_type = 0x00;
                        break;
                    case "Timer":
                        fliter_type = 0x01;
                        break;
                    case "Counter":
                        fliter_type = 0x02;
                        break;
                    case "StorageFilter":
                        fliter_type = 0x03;
                        break;
                    default:
                        break;
                }
#endif


                byte heartbeattime = byte.Parse(heartbeattime_tb.Text);
                byte check = (byte)((byte.Parse(textBox4.Text) << 4) | byte.Parse(textBox7.Text));
                byte checkdata1 = Convert.ToByte(textBox5.Text.Substring(0, 2), 16);
                byte checkdata2 = Convert.ToByte(textBox6.Text.Substring(0, 2), 16);
                byte AlarmMode = 0;


#if CN
                switch (comboBox2.Text) // 报警方式
                {
                    case "不报警，GPIO输出低电平":
                        AlarmMode = 0x00;
                        break;
                    case "不报警，GPIO输出高电平":
                        AlarmMode = 0x01;
                        break;
                    case "一类报警：报警打开，EPC校验结果相同,输出低电平,报警持续300ms":
                        AlarmMode = 0x10;
                        break;
                    case "一类报警：报警打开，EPC校验结果相同,输出高电平,报警持续300ms":
                        AlarmMode = 0x11;
                        break;
                    case "二类报警：报警打开，EPC校验结果不相同及无卡时报警,输出低电平,报警持续300ms":
                        AlarmMode = 0x20;
                        break;
                    case "二类报警：报警打开，EPC校验结果不相同及无卡时报警,输出高电平,报警持续300ms":
                        AlarmMode = 0x21;
                        break;
                    case "三类报警：报警打开，仅在无卡通过时，GPIO输出低电平，报警持续300ms":
                        AlarmMode = 0x30;
                        break;
                    case "三类报警：报警打开，仅在无卡通过时，GPIO输出高电平，报警持续300ms":
                        AlarmMode = 0x31;
                        break;
                    case "四类报警：报警打开,仅在EPC数据不同时报警，输出低电平，可设置报警次数":
                        AlarmMode = 0x40;
                        break;
                    case "四类报警：报警打开,仅在EPC数据不同时报警，输出高电平，可设置报警次数":
                        AlarmMode = 0x41;
                        break;
                    default:
                        break;
                }
#endif

#if EN
                switch (comboBox2.Text) // 报警方式
                {
                    case "No alarm, GPIO output low level":
                        AlarmMode = 0x00;
                        break;
                    case "No alarm, GPIO output high level":
                        AlarmMode = 0x01;
                        break;
                    case "alarm1: alarm opened, the EPC check result is the same, the output is low, the alarm continues the 300ms":
                        AlarmMode = 0x10;
                        break;
                    case "alarm2: alarm opened, the EPC check result is the same, the output is high, the alarm continues the 300ms":
                        AlarmMode = 0x11;
                        break;
                    case "alarm3: alarm open, EPC check results are not the same and no card alarm, output low level, alarm continuous 300ms":
                        AlarmMode = 0x20;
                        break;
                    case "alarm4: alarm open, EPC check results are not the same and no card alarm, output high level, alarm continuous 300ms":
                        AlarmMode = 0x21;
                        break;
                    case "alarm5: alarm open, only in non - cartoon out of date, GPIO output low level, alarm continuous 300ms":
                        AlarmMode = 0x30;
                        break;
                    case "alarm6: alarm open, only in non - cartoon out of date, GPIO output high level, alarm continuous 300ms":
                        AlarmMode = 0x31;
                        break;
                    case "alarm7: alarm opened, only the EPC data is not reported at the same time, the output is low, and the number of alarm can be set.":
                        AlarmMode = 0x40;
                        break;
                    case "alarm8: alarm opened, only the EPC data is not reported at the same time, the high level is output, and the number of alarm can be set.":
                        AlarmMode = 0x41;
                        break;
                    default:
                        break;
                }
#endif


                if (checkBox1.Checked == true)
                {
                    trigger |= 0x04;
                }
                if (checkBox2.Checked == true)
                {
                    trigger |= 0x08;
                }
                if (checkBox3.Checked == true)
                {
                    trigger |= 0x10;
                }
                if (checkBox4.Checked == true)
                {
                    trigger |= 0x20;
                }
                if (checkBox5.Checked == true)
                {
                    trigger |= 0x40;
                }
                if (checkBox6.Checked == true)
                {
                    trigger |= 0x80;
                }
                byte count = byte.Parse(FourAlerttexCounttBox.Text);
                byte time = (byte)((byte.Parse(FourAlerttextStartTimeBox.Text) << 4) | byte.Parse(FourAlerttextStopTimeBox.Text));

                if (radioButton16.Checked == true) // 通道门模式 --此处用来切换界面显示模式
                {
                    SrDemo.TDMMode = 1;  // 通道门
                }
                else
                {
                    SrDemo.TDMMode = 0; //主从
                }


                string result = sd.ReaderControllor.SetWorkMode(WorkingReader, delay, wengind_en, wengind, work_mode, trigger, single_loop, read_buzzer, write_buzzer, heart_beat, send_duty, heartbeattime, fliter_type, faliter_time, check, checkdata1, checkdata2, AlarmMode, count, time);


                if (radioButton2.Checked == true)
                {

                    AutoReadTags(EventArgs.Empty);
                    SrDemo.IsAutoMode = true;       // 自动模式
                    SrDemo.DataMark = true;
                    SrDemo.IsStart = false;
                    SrDemo.IsStop = false;
                }
                else
                {

                    SrDemo.SetMode = 1;    // 其他模式
                    SrDemo.IsAutoMode = false;   
                    SrDemo.DataMark = false;
                    SrDemo.IsStart = true;
                    SrDemo.IsStop = false;
                }



                if (SrDemo.isLogOpen)
                {
                    string info = delay.ToString() + " " + wengind_en.ToString() + " " + wengind.ToString() + " " + work_mode.ToString() + " " + trigger.ToString() + " " + single_loop.ToString() +
                                    " " + read_buzzer.ToString() + " " + write_buzzer.ToString() + " " + heart_beat.ToString() + " " + send_duty.ToString() + " " + heartbeattime.ToString() + " " + fliter_type.ToString() +
                                    " " + faliter_time.ToString() + " " + check.ToString() + " " + checkdata1.ToString() + " " + checkdata2.ToString() + " " + AlarmMode.ToString() + " " + count.ToString() + " " + time.ToString();
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "工作模式" + "命令发送" + "成功", info);
                    }
                    else
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "工作模式" + "命令发送" + "失败", info);
                    }
                }
            }
            catch (Exception ex)
            {
                sd.UpdateLog(ex.ToString());
                if (SrDemo.isLogOpen)
                {
                    ErrorLog.WriteError(ex.ToString());
                }
            }
        }

        internal void UpdateEPCView(string[] result)
        {
            int offset = 2;
            if (result[offset] == ErrorNum.success)
            {
                EPCContrastTB.Text = result[offset+1];
                sd.UpdateLog("获取EPC对比参数成功");
            }
            else
            {
                sd.UpdateLog("获取EPC对比参数失败");
            }
        }

        public void UpdateView(string[] submode, string type)
        {
            int offset = 2;
            try
            {
                if (submode[offset] == ErrorNum.success)
                {

                    delay_rb.Text = submode[offset + 1];
                    if (submode[offset + 2] == "0")                       //韦根        0 关闭  1 开
                    {
                        radioButton7.Checked = true;
                    }
                    else if (submode[offset + 2] == "1")
                    {
                        radioButton6.Checked = true;
                    }
                    if (submode[offset + 3] == "0")                        //26/34
                    {
                        radioButton4.Checked = true;
                    }
                    else if (submode[offset + 3] == "1")
                    {
                        radioButton5.Checked = true;
                    }

                    if (submode[offset + 4] == "0")                    //模式 0 主从  1 触发 2 延时
                    {
                        radioButton3.Checked = true;
                    }
                    else if (submode[offset + 4] == "1")
                    {
                        radioButton1.Checked = true;
                    }
                    else if (submode[offset + 4] == "2")
                    {
                        radioButton2.Checked = true;
                    }
                    else if (submode[offset + 4] == "3")
                    {
                        radioButton16.Checked = true;
                    }
                    else if (submode[offset + 4] == "4")
                    {
                        AetennaBranch_rb.Checked = true;
                    }
                    else if (submode[offset + 4] == "5")
                    {
                        authorymoderadiobutton.Checked = true;
                    }
                    else if (submode[offset + 4] == "6")
                    {
                        EPCContrastRB.Checked = true;
                    }
                    else if (submode[offset + 4] == "7")
                    {
                        radioButton21.Checked = true;
                    }
                    else if (submode[offset + 4] == "8")
                    {
                        VendingMachineModeRb.Checked = true;
                    }
                    byte gpio = byte.Parse(submode[offset + 5]);
                    if ((gpio & 0x01) != 0)
                    {
                        comboBox1.SelectedIndex = 1;
                    }
                    else
                    {
                        comboBox1.SelectedIndex = 0;
                    }
                    if ((gpio & 0x04) != 0)
                    {
                        checkBox1.Checked = true;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                    }
                    if ((gpio & 0x08) != 0)
                    {
                        checkBox2.Checked = true;
                    }
                    else
                    {
                        checkBox2.Checked = false;
                    }
                    if ((gpio & 0x10) != 0)
                    {
                        checkBox3.Checked = true;
                    }
                    else
                    {
                        checkBox3.Checked = false;
                    }
                    if ((gpio & 0x20) != 0)
                    {
                        checkBox4.Checked = true;
                    }
                    else
                    {
                        checkBox4.Checked = false;
                    }
                    if ((gpio & 0x40) != 0)
                    {
                        checkBox5.Checked = true;
                    }
                    else
                    {
                        checkBox5.Checked = false;
                    }
                    if ((gpio & 0x80) != 0)
                    {
                        checkBox6.Checked = true;
                    }
                    else
                    {
                        checkBox6.Checked = false;
                    }
                    if (submode[offset + 6] == "0")                    //单次 循环  主从模式
                    {
                        radioButton14.Checked = true;
                    }
                    else if (submode[offset + 6] == "1")
                    {
                        radioButton15.Checked = true;
                    }

                    if (submode[offset + 7] == "0")                    //读卡蜂鸣器
                    {
                        radioButton9.Checked = true;
                        radioButton19.Checked = true;
                    }
                    else if (submode[offset + 7] == "1")
                    {
                        radioButton8.Checked = true;
                        radioButton19.Checked = true;
                    }
                    else if (submode[offset + 7] == "128")
                    {
                        radioButton9.Checked = true;
                        radioButton20.Checked = true;
                    }
                    else if (submode[offset + 7] == "129")
                    {
                        radioButton8.Checked = true;
                        radioButton20.Checked = true;
                    }


                    if (submode[offset + 8] == "0")                    //写卡蜂鸣器
                    {
                        radioButton11.Checked = true;
                        checkBox7.Checked = true;
                    }
                    else if (submode[offset + 8] == "1")
                    {
                        radioButton10.Checked = true;
                        checkBox7.Checked = true;
                    }

                    else if (submode[offset + 8] == "128")
                    {
                        radioButton11.Checked = true;
                        checkBox7.Checked = false;
                    }
                    else if (submode[offset + 8] == "129")
                    {
                        radioButton10.Checked = true;
                        checkBox7.Checked = false;
                    }



                    if (submode[offset + 9] == "0")                    //心跳
                    {
                        radioButton13.Checked = true;
                        radioButton18.Checked = true;
                    }
                    else if (submode[offset + 9] == "1")
                    {
                        radioButton12.Checked = true;
                        radioButton18.Checked = true;
                    }
                    else if (submode[offset + 9] == "129")
                    {
                        radioButton12.Checked = true;
                        radioButton17.Checked = true;
                    
                    }
                    else if (submode[offset + 9] == "128")
                    {
                        radioButton13.Checked = true;
                        radioButton17.Checked = true;
                    }


                    textBox3.Text = submode[offset + 10];              //延时时长
                    heartbeattime_tb.Text = submode[offset + 11];
                    fliter_type_cb.SelectedIndex = byte.Parse(submode[offset + 12]);
                    filtertime_tb.Text = submode[offset + 13];
                    //  dev_add_tb.Text = submode[11];//设备号  取消
                    switch (byte.Parse(submode[offset + 14]))
                    {
                        case 0x00:
                            comboBox2.SelectedIndex = 0x00;
                            break;
                        case 0x01:
                            comboBox2.SelectedIndex = 0x01;
                            break;
                        case 0x10:
                            comboBox2.SelectedIndex = 0x02;
                            break;
                        case 0x11:
                            comboBox2.SelectedIndex = 0x03;
                            break;
                        case 0x20:
                            comboBox2.SelectedIndex = 0x04;
                            break;
                        case 0x21:
                            comboBox2.SelectedIndex = 0x05;
                            break;
                        case 0x30:
                            comboBox2.SelectedIndex = 0x06;
                            break;
                        case 0x31:
                            comboBox2.SelectedIndex = 0x07;
                            break;
                        case 0x40:
                            comboBox2.SelectedIndex = 0x08;
                            break;
                        case 0x41:
                            comboBox2.SelectedIndex = 0x09;
                            break;
                        default:
                            break;
                    }
                    byte check = byte.Parse(submode[offset + 15]);
                    textBox4.Text = (check >> 4).ToString();
                    textBox7.Text = (check & 0x0F).ToString();
                    textBox5.Text = submode[offset + 16];
                    textBox6.Text = submode[offset + 17];
                    S_Hard_Version.Text = submode[offset + 18];
                    S_Firm_Version.Text = submode[offset + 19];
                    M_Hard_Version.Text = submode[offset + 20];
                    M_Firm_Version.Text = submode[offset + 21];
                    FourAlerttexCounttBox.Text = submode[offset + 22];
                    byte alertv = byte.Parse(submode[offset + 23]);
                    FourAlerttextStartTimeBox.Text = (alertv >> 4).ToString();
                    FourAlerttextStopTimeBox.Text = (alertv & 0x0F).ToString();
                    sd.UpdateLog(GetToString() + type + OkToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "工作模式" + "数据接收" + "成功",null);
                    }
                }
                else
                {
                    sd.UpdateLog(GetToString() + type + FailedToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "工作模式" + "数据接收" + "失败", null);
                    }
                }
            }
            catch (Exception ex)
            {
                sd.UpdateLog(ex.ToString());
                ErrorLog.WriteError(ex.ToString());
            }
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SetEPCBT_Click(object sender, EventArgs e)
        {
            if (EPCContrastTB.Text != null)
            {
                try
                {
                    sd.ReaderControllor.SetEPC(WorkingReader,EPCContrastTB.Text);
                }
                catch (Exception ex)
                {
                    sd.UpdateLog(ex.ToString());
                }
            }
        }

        private void GetEPCBT_Click(object sender, EventArgs e)
        {
            if (EPCContrastTB.Text != null)
            {
                try
                {
                    sd.ReaderControllor.GetEPC(WorkingReader);
                }
                catch (Exception ex)
                {
                    sd.UpdateLog(ex.ToString());
                }
            }
        }

        private void radioButton20_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
