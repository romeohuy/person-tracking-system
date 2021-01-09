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
    public partial class SIM : CustomControl
    {
        public SIM()
        {
            InitializeComponent();
        }

        public SIM(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                string result = sd.ReaderControllor.GetSIMInfo(WorkingReader);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("查询读写器" + WorkingReader.dev + "4G参数" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("查询读写器" + WorkingReader.dev + "4G参数" + "命令发送" + "失败", null);
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
            button16.Text = rm.GetString("Get");
            button17.Text = rm.GetString("Set");
            //wifi
            label67.Text = "4G"+rm.GetString("Mode_Serever") + rm.GetString("Mode_Communication_IP");
            label65.Text = rm.GetString("User");
            label68.Text = "4G"+rm.GetString("Mode_Serever") + rm.GetString("Mode_Communication_Port");
            label66.Text = rm.GetString("pwd");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                string APN = APN_tb.Text;
                string Usr = usrname_tb.Text;
                string pwd = SIM_PWD_tb.Text;
                string serverip = SIM_ServerIP_tb.Text;
                ushort port = ushort.Parse(SIM_Port_tb.Text);
                string result = sd.ReaderControllor.SetSIMConfig(WorkingReader, APN, Usr, pwd, serverip, port);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "4G参数" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "4G参数" + "命令发送" + "失败", null);
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

        public void UpdateView(string[] subinfo, string type)
        {
            int offset = 2;
            if (subinfo[offset + 0] == ErrorNum.success)
            {
                APN_tb.Text = subinfo[offset + 1];
                usrname_tb.Text = subinfo[offset + 2];
                SIM_PWD_tb.Text = subinfo[offset + 3];
                SIM_ServerIP_tb.Text = subinfo[offset + 4];
                SIM_Port_tb.Text = subinfo[offset + 5];
                sd.UpdateLog(GetToString() + type + OkToString());
                if (SrDemo.isLogOpen)
                {
                    EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "4G参数" + "数据接收" + "成功", null);
                }
            }
            else
            {
                sd.UpdateLog(GetToString() + type + FailedToString());
                if (SrDemo.isLogOpen)
                {
                    EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "4G参数" + "数据接收" + "失败", null);
                }
            }
        }

    }
}
