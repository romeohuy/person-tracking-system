using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetFrame.Net.TCP.Sock.Asynchronous;
using SrDemo;
using System.Resources;
using SrDemo.Log;

namespace SrDemo.Config
{
    public partial class Power : CustomControl
    {
        public Power(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }
        public Power()
        {
 
        }

        private void button_power_get_Click(object sender, EventArgs e)
        {
            try
            {
                string result = sd.ReaderControllor.GetPower(WorkingReader);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "功率" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "功率" + "命令发送" + "失败", null);
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
            groupBox_power.Text = rm.GetString("Configure_Power_One");
            label16.Text = rm.GetString("Access_Read") + rm.GetString("Tag");
            label18.Text = rm.GetString("Access_Write") + rm.GetString("Tag");
            button_power_get.Text = rm.GetString("Get");
            button_power_set.Text = rm.GetString("Set");
        }


        public void UpdateView(string[] subinfo, string type)
        {
            try
            {
                int offset = 2;
                if (subinfo[offset + 0] == ErrorNum.success)
                {
                    comboBox_read_power.Text = subinfo[offset + 2];
                    comboBox_write_power.Text = subinfo[offset + 3];
                    sd.UpdateLog(GetToString() + type + OkToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "功率" + "数据接收" + "成功", null);
                    }
                }
                else
                {
                    sd.UpdateLog(GetToString() + type + FailedToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "功率" + "数据接收" + "失败", null);
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


        private void button_power_set_Click(object sender, EventArgs e)
        {
            try
            {
                byte read = byte.Parse(comboBox_read_power.Text);
                byte write = byte.Parse(comboBox_write_power.Text);
                string result = sd.ReaderControllor.SetPower(WorkingReader, read, write);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "功率" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "功率" + "命令发送" + "失败", null);
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
