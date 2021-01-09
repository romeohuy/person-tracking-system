using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using SrDemo.Log;
using System.Resources;

namespace SrDemo.Config
{
    public partial class AntConfig : CustomControl
    {
        public AntConfig()
        {
            InitializeComponent();
        }

        public AntConfig(SrDemo sd)
        : base(sd)
        {
            InitializeComponent();
        }

        private void AntConfig_Load(object sender, EventArgs e)
        {

        }

        private void Get_ant_mes_Click(object sender, EventArgs e)
        {
            try
            {
                string result = sd.ReaderControllor.GetWorkAnt(WorkingReader);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("获取四通道读写器" + WorkingReader.dev + "工作天线" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("获取四通道读写器" + WorkingReader.dev + "工作天线" + "命令发送" + "失败", null);
                    }
                }
                Thread.Sleep(500);
                result = sd.ReaderControllor.GetWorkTime(WorkingReader);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("获取四通道读写器" + WorkingReader.dev + "工作天线时间间隔" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("获取四通道读写器" + WorkingReader.dev + "工作天线时间间隔" + "命令发送" + "失败", null);
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

        private void button_set_ant_Click(object sender, EventArgs e)
        {
            try
            {
                byte workant = 0;
                if (checkBox_ant1.Checked == true)
                {
                    workant |= 0x01;
                }
                if (checkBox_ant2.Checked == true)
                {
                    workant |= 0x02;
                }
                if (checkBox_ant3.Checked == true)
                {
                    workant |= 0x04;
                }
                if (checkBox_ant4.Checked == true)
                {
                    workant |= 0x08;
                }
                sd.ReaderControllor.SetWorkAnt(WorkingReader, workant);
                Thread.Sleep(500);
                ushort worktime1 = ushort.Parse(textBox_ant1_worktime.Text);
                ushort worktime2 = ushort.Parse(textBox_ant2_worktime.Text);
                ushort worktime3 = ushort.Parse(textBox_ant3_worktime.Text);
                ushort worktime4 = ushort.Parse(textBox_ant4_worktime.Text);
                ushort waittime = ushort.Parse(textBox_waittime.Text);
                string result = sd.ReaderControllor.SetWorkTime(WorkingReader, worktime1, worktime2, worktime3, worktime4, waittime);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("设置4通道读写器" + WorkingReader.dev + "工作天线" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("设置4通道读写器" + WorkingReader.dev + "工作天线" + "命令发送" + "成功", null);
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
            this.button_set_ant.Text = rm.GetString("Set");
            this.Get_ant_mes.Text = rm.GetString("Get");
            groupBox16.Text = rm.GetString("FourChannelReader");
            label48.Text = rm.GetString("Configure_WaitTime");
        }

        public void UpdateViewAnt(string[] subinfo, string type)
        {
            int offset = 3;
            try
            {
                if (subinfo[2] == ErrorNum.success)
                {
                    int check = 0;
                    byte b_ant = byte.Parse(subinfo[offset + 1]);
                    check = b_ant & 0x01;
                    if (check != 0)
                    {
                        checkBox_ant1.Checked = true;
                    }
                    else
                    {
                        checkBox_ant1.Checked = false;
                    }
                    check = b_ant & 0x02;
                    if (check != 0)
                    {
                        checkBox_ant2.Checked = true;
                    }
                    else
                    {
                        checkBox_ant2.Checked = false;
                    }
                    check = b_ant & 0x04;
                    if (check != 0)
                    {
                        checkBox_ant3.Checked = true;
                    }
                    else
                    {
                        checkBox_ant3.Checked = false;
                    }
                    check = b_ant & 0x08;
                    if (check != 0)
                    {
                        checkBox_ant4.Checked = true;
                    }
                    else
                    {
                        checkBox_ant4.Checked = false;
                    }
                    sd.UpdateLog(GetToString() + type + OkToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取四通道读写器" + WorkingReader.dev + "工作天线" + "数据接收" + "成功", null);
                    }
                }
                else
                {
                    sd.UpdateLog(GetToString() + type + FailedToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取四通道读写器" + WorkingReader.dev + "工作天线" + "数据接收" + "失败", null);
                    }
                }
            }
            catch (Exception ex)
            {
                sd.UpdateLog(ex.ToString());
                ErrorLog.WriteError(ex.ToString());
            }
        }

        private void groupBox16_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox_ant1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
