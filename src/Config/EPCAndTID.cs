using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SrDemo.Log;
using System.Resources;

namespace SrDemo.Config
{
    public partial class EPCAndTID : CustomControl
    {
        public EPCAndTID()
        {
            InitializeComponent();
        }

        public EPCAndTID(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }

        public void LanguagedChanged()
        {
            ResourceManager rm = new ResourceManager(typeof(SrDemo));
            radioButton1.Text = rm.GetString("Open");
            radioButton2.Text = rm.GetString("Close");
            button1.Text = rm.GetString("Get");
            button2.Text = rm.GetString("Set");
            //groupBox5.Text = rm.GetString("BasicConfig");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string result = sd.ReaderControllor.GetEAT(WorkingReader);
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                byte eatID = 0;
                if (radioButton1.Checked == true)
                {
                    eatID = 0x01;
                }
                else
                {
                    eatID = 0x00;
                }

                byte SaveMark = 0x01;

                string result = sd.ReaderControllor.SetEAT(WorkingReader, eatID, SaveMark);
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
                if (subinfo[0] == "1")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
                sd.UpdateLog(GetToString() + type + OkToString());
                if (SrDemo.isLogOpen)
                {
                    EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "EPCAndTID" + "数据接收" + "成功", null);
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
