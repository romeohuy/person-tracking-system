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
    public partial class FastID : CustomControl
    {
        public FastID()
        {
            InitializeComponent();
        }

        public FastID(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string result = sd.ReaderControllor.GetFastID(WorkingReader);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "fastID" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "fastID" + "命令发送" + "失败", null);
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
            fastID_on_rb.Text = rm.GetString("Configure_On");
            fastID_off_rb.Text = rm.GetString("Configure_Off");
            button6.Text = rm.GetString("Get");
            button5.Text = rm.GetString("Set");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                byte fastID = 0;
                if (fastID_on_rb.Checked == true)
                {
                    fastID = 0x01;
                }
                else
                {
                    fastID = 0x00;
                }
                string result = sd.ReaderControllor.SetfastID(WorkingReader, fastID);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "fastID" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "fastID" + "命令发送" + "失败", null);
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
            try
            {
                byte offset = 2;
                if (subinfo[offset] == ErrorNum.success)
                {
                    if (subinfo[offset + 1] == "ON")
                    {
                        fastID_on_rb.Checked = true;
                    }
                    else
                    {
                        fastID_off_rb.Checked = true;
                    }
                    sd.UpdateLog(GetToString() + type + OkToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "fastID" + "数据接收" + "成功", null);
                    }
                }
                else
                {
                    sd.UpdateLog(GetToString() + type + FailedToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "fastID" + "数据接收" + "失败", null);
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
    }
}
