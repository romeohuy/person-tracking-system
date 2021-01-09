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

namespace SrDemo.Config
{
    public partial class Power_Four : CustomControl
    {
        public Power_Four(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }
        public Power_Four()
        {
        
        }

        public void LanguagedChanged()
        {
            ResourceManager rm = new ResourceManager(typeof(SrDemo));
            groupBox1.Text = rm.GetString("Configure_Power_Four");
            label2.Text = label3.Text = label5.Text = label7.Text = rm.GetString("Access_Read") + rm.GetString("Tag");
            label1.Text = label4.Text = label6.Text = label8.Text = rm.GetString("Access_Write") + rm.GetString("Tag");
            button2.Text = rm.GetString("Get");
            button1.Text = rm.GetString("Set");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string result = sd.ReaderControllor.GetPower(WorkingReader);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("获取四通道读写器" + WorkingReader.dev + "功率" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("获取四通道读写器" + WorkingReader.dev + "功率" + "命令发送" + "失败", null);
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

        private void button1_Click(object sender, EventArgs e)
        {           
            try
            {
                byte ant1_power = byte.Parse(comboBox2.Text);
                byte ant2_power = byte.Parse(comboBox4.Text);
                byte ant3_power = byte.Parse(comboBox6.Text);
                byte ant4_power = byte.Parse(comboBox8.Text);
                string result = sd.ReaderControllor.SetPower(WorkingReader, ant1_power, ant2_power, ant3_power, ant4_power);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("设置四通道读写器" + WorkingReader.dev + "功率" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("设置四通道读写器" + WorkingReader.dev + "功率" + "命令发送" + "失败", null);
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
                int offset = 2;
                if (subinfo[offset + 0] == ErrorNum.success)
                {
                    comboBox2.Text = subinfo[offset + 3];
                    comboBox4.Text = subinfo[offset + 4];
                    comboBox6.Text = subinfo[offset + 5];
                    comboBox8.Text = subinfo[offset + 6];
                    sd.UpdateLog(GetToString() + type + OkToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取四通道读写器" + WorkingReader.dev + "功率" + "数据接收" + "成功", null);
                    }
                }
                else
                {
                    sd.UpdateLog(GetToString() + type + FailedToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取四通道读写器" + WorkingReader.dev + "功率" + "数据接收" + "失败", null);
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
