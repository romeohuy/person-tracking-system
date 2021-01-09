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
    public partial class MqttCommand : CustomControl
    {
        public MqttCommand()
        {
            InitializeComponent();
        }

        public MqttCommand(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
                string user = textBox17.Text;
                string pwd = textBox18.Text;
                ushort keeptime = ushort.Parse(textBox20.Text);
                sd.ReaderControllor.SetMQTTUser(WorkingReader, user, pwd, keeptime);
            }
            catch (Exception ex)
            {
                sd.UpdateLog(ex.ToString());
            }
        }

        public void LanguagedChanged()
        {
            ResourceManager rm = new ResourceManager(typeof(SrDemo));
            button25.Text = rm.GetString("Get");
            button26.Text = rm.GetString("Set");

            button27.Text = rm.GetString("Get");
            button28.Text = rm.GetString("Set");
            //wifi
            label86.Text = rm.GetString("User");
            label87.Text = rm.GetString("pwd");
            label89.Text = rm.GetString("KeepAlive");
            label88.Text = rm.GetString("Theme");
        }


        private void button25_Click(object sender, EventArgs e)
        {
            try
            {
                string result = sd.ReaderControllor.GetMQTTUser(WorkingReader);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "MQTT用户名设置" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "MQTT用户名设置" + "命令发送" + "失败", null);
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

        private void button27_Click(object sender, EventArgs e)
        {
            try
            {
                string result = sd.ReaderControllor.GetMQTTTheme(WorkingReader);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "MQTT主题" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "MQTT主题" + "命令发送" + "失败", null);
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

        private void button28_Click(object sender, EventArgs e)
        {
            try
            {
                string theme = textBox19.Text;
                string result = sd.ReaderControllor.SetMQTTTheme(WorkingReader, theme);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "MQTT主题" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "MQTT主题" + "命令发送" + "失败", null);
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

        public void UpdateViewMQTT(string[] result)
        {
            int offset = 2;
            if (result[offset + 0] == ErrorNum.success)
            {
                if (result[offset + 1] != "")
                {
                    textBox17.Text = result[offset + 1];
                }
                if (result[offset + 2] != "")
                {
                    textBox18.Text = result[offset + 2];
                }
                if (result[offset + 3] != "")
                {
                    textBox20.Text = result[offset + 3];
                }
                sd.UpdateLog("查询MQTT参数成功");
                if (SrDemo.isLogOpen)
                {
                    EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "MQTT用户名" + "数据接收" + "成功", null);
                }
            }
            else
            {
                sd.UpdateLog("查询MQTT参数失败");
                if (SrDemo.isLogOpen)
                {
                    EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "MQTT用户名" + "数据接收" + "失败", null);
                }
            }
        }

        public void UpdateViewMQTTThem(string[] result)
        {
            int offset = 2;
            if (result[offset + 0] == ErrorNum.success)
            {
                if (result[offset + 1] != "")
                {
                    textBox19.Text = result[offset + 1];
                }
                sd.UpdateLog("查询MQTT主题成功");
                if (SrDemo.isLogOpen)
                {
                    EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "MQTT主题" + "数据接收" + "成功", null);
                }
            }
            else
            {
                sd.UpdateLog("查询MQTT主题失败");
                if (SrDemo.isLogOpen)
                {
                    EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "MQTT主题" + "数据接收" + "失败", null);
                }
            }
        }
    }
}
