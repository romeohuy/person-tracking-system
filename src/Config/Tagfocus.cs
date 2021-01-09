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
    public partial class Tagfocus : CustomControl
    {
        public Tagfocus()
        {
            InitializeComponent();
        }


        public Tagfocus(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }

        private void Tagfocus_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte tagfous = 0x00;
            if (RadioButtonTagfousOn.Checked == true)
            {
                tagfous = 0x01;
            }
            else if (RadioButtonTagfousOff.Checked == true)
            {
                tagfous = 0x00;
            }
            try
            {
                sd.ReaderControllor.SetTagfocus(WorkingReader, tagfous);
            }
            catch (Exception ex)
            {
                sd.UpdateLog(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string result = sd.ReaderControllor.GetTagfocus(WorkingReader);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "Tagfocus" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "Tagfocus" + "命令发送" + "失败", null);
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
            RadioButtonTagfousOn.Text = rm.GetString("Configure_On");
            RadioButtonTagfousOff.Text = rm.GetString("Configure_Off");
            button1.Text = rm.GetString("Get");
            button2.Text = rm.GetString("Set");
        }

        public void UpdateView(string[] subinfo, string type)
        {
            int offset = 2;
            try
            {
                if (subinfo[offset + 0] == "1")
                {
                    if (subinfo[offset + 1] == "1")
                    {
                        RadioButtonTagfousOn.Checked = true;
                    }
                    else
                    {
                        RadioButtonTagfousOff.Checked = true;
                    }
                    sd.UpdateLog(GetToString() + type + OkToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "Tagfocus" + "数据接收" + "成功", null);
                    }
                }
                else
                {
                    sd.UpdateLog(GetToString() + type + FailedToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "Tagfocus" + "数据接收" + "失败", null);
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
