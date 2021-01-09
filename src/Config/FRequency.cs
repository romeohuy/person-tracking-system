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
    public partial class FRequency : CustomControl
    {
        public FRequency()
        {
            InitializeComponent();
        }

        public FRequency(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }

        private void button_get_region_Click(object sender, EventArgs e)
        {
            try
            {
                string result = sd.ReaderControllor.GetFrequencyArea(WorkingReader);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "频率区域" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "频率区域" + "命令发送" + "失败", null);
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
            groupBox1.Text = rm.GetString("RF_Area");
            checkBox_region_save.Text = rm.GetString("Configure_Frequency_Save");
            button_get_region.Text = rm.GetString("Get");
            button_set_region.Text = rm.GetString("Set");
        }

        private void button_set_region_Click(object sender, EventArgs e)
        {
            try
            {
                byte area = (byte)(comboBox_region.SelectedIndex + 1);
                byte save = 0x00;
                if (checkBox_region_save.Checked == true)
                {
                    save = 0x01;
                }
                else
                {
                    save = 0x00;
                }
                string result = sd.ReaderControllor.SetFrequencyArea(WorkingReader, area, save);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "频率区域" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "频率区域" + "命令发送" + "失败", null);
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
                if (subinfo[2] == ErrorNum.success)
                {
                    byte b_area = byte.Parse(subinfo[3]);
                    comboBox_region.SelectedIndex = b_area - 1;
                    sd.UpdateLog(GetToString() + type + OkToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "频率区域" + "数据接收" + "成功", null);
                    }
                }
                else
                {
                    sd.UpdateLog(GetToString() + type + FailedToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "频率区域" + "数据接收" + "失败", null);
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
