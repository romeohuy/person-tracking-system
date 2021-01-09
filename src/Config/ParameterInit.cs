using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetFrame.Net.TCP.Sock.Asynchronous;
using System.Resources;
using SrDemo.Log;


namespace SrDemo.Config
{
    public partial class ParameterInit : CustomControl
    {
        public ParameterInit()
        {
            InitializeComponent();
        }

        public ParameterInit(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            byte save = 0x00;
            if (save_cb.Checked == true)
            {
                save = 0x66;
            }
            else
            {
                save = 0x55;
            }
            byte ver = 0x02;                                   //版本默认为最新
            try
            {
                byte senddpower = byte.Parse(transpower_tb.Text);
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

                SrDemo.SetMode = 1; // 其他模式

                string result = sd.ReaderControllor.Init(WorkingReader, save, ver, senddpower, recvpower, workstate, channnel, tagtype, mode);
                //      WorkingReader,0x66,0x02,0x01,0x1E,0x01,0x1E,0x05,0x00   
                 //              断电保存 0x02  发射功率 射频衰减 是否循环  信道频率  类型 0x00
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "初始化参数" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "初始化参数" + "命令发送" + "失败", null);
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

        private void button31_Click(object sender, EventArgs e)
        {
            try
            {
                string result = sd.ReaderControllor.ReadInfo(WorkingReader);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "初始化参数" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "初始化参数" + "命令发送" + "失败", null);
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

        public void LanguagedChanged()
        {
            ResourceManager rm = new ResourceManager(typeof(SrDemo));
            groupBox36.Text = rm.GetString("ActiveDev");
            label106.Text = rm.GetString("EmissivePower");
            label104.Text = rm.GetString("attenuation");
            label103.Text = rm.GetString("channel");
            label102.Text = rm.GetString("type");
            IsAutocheckBox.Text = rm.GetString("AutoRead");
            save_cb.Text = rm.GetString("PowerCutStorage");
            button32.Text = rm.GetString("Set");
            button31.Text = rm.GetString("Get");
        }


        public void UpdateView(string[] subinfo, string type)
        {
            int offset = 2;
            if (subinfo[offset + 0] == ErrorNum.success)
            {
                if (subinfo[offset + 2] == "66")
                {
                    save_cb.Checked = true;
                }
                else
                {
                    save_cb.Checked = false;
                }
                transpower_tb.Text = subinfo[offset + 4]; //     1 
                recv_tb.Text = subinfo[offset + 5];         //   30
                if (byte.Parse(subinfo[offset + 6]) == 0x00) // 开机自动循环   1
                {
                    IsAutocheckBox.Checked = true;
                }
                else
                {
                    IsAutocheckBox.Checked = false;
                }
                channel_tb.Text = (ushort.Parse(subinfo[offset + 7]) + 2400).ToString();  // 9 2400+30
                tagtype_tb.Text = subinfo[offset + 8];        //  5
                sd.UpdateLog(GetToString() + type + OkToString());
                if (SrDemo.isLogOpen)
                {
                    EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "初始化参数" + "数据接收" + "成功", null);
                }
            }
            else
            {
                sd.UpdateLog(GetToString() + type + FailedToString());
                if (SrDemo.isLogOpen)
                {
                    EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "初始化参数" + "数据接收" + "失败", null);
                }
            }
        }

        private void save_cb_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
