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
    public partial class WifiMode : CustomControl
    {
        public WifiMode()
        {
            InitializeComponent();
        }

        public WifiMode(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string result = sd.ReaderControllor.GetWifiConfig(WorkingReader);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "wifi配置参数" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "wifi配置参数" + "命令发送" + "失败", null);
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
            this.label4.Text = rm.GetString("pwd");
            this.label7.Text = rm.GetString("Mode_Communication_GateWay");
            this.label11.Text = rm.GetString("Encryption");
            this.label5.Text = rm.GetString("Mode_Communication_Reader") + rm.GetString("Mode_Communication_IP");
            this.label8.Text = "Wifi"+rm.GetString("Mode_Serever") + rm.GetString("Mode_Communication_IP");
            this.label10.Text = rm.GetString("EncryptionAlgorithm");
            this.label6.Text = rm.GetString("Mode_Communication_MASK");
            this.label9.Text = "Wifi"+rm.GetString("Mode_Serever") + rm.GetString("Mode_Communication_Port");
            button1.Text = rm.GetString("Get");
            button2.Text = rm.GetString("Set");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string SSID = textBox1.Text;
                string Pwd = textBox2.Text;
                string ip = textBox4.Text;
                string mask = textBox6.Text;
                string gateway = textBox7.Text;
                string serverip = textBox8.Text;
                ushort port = ushort.Parse(textBox9.Text);
                byte mode = (byte)comboBox1.SelectedIndex;
                byte algorithm = (byte)comboBox2.SelectedIndex;
                string result = sd.ReaderControllor.SetWifiConfig(WorkingReader, SSID, Pwd, ip, mask, gateway, serverip, port, mode, algorithm);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "wifi配置参数" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "wifi配置参数" + "命令发送" + "失败", null);
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
            try
            {
                if (subinfo[offset + 0] == ErrorNum.success)
                {
                    textBox1.Text = subinfo[offset + 1];
                    textBox2.Text = subinfo[offset + 2];
                    textBox4.Text = subinfo[offset + 3];
                    textBox6.Text = subinfo[offset + 4];
                    textBox7.Text = subinfo[offset + 5];
                    textBox8.Text = subinfo[offset + 6];
                    textBox9.Text = subinfo[offset + 7];
                    comboBox1.SelectedIndex = byte.Parse(subinfo[offset + 8]);
                    comboBox2.SelectedIndex = byte.Parse(subinfo[offset + 9]);
                    sd.UpdateLog(GetToString() + type + OkToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "wifi配置参数" + "数据接收" + "成功", null);
                    }
                }
                else
                {
                    sd.UpdateLog(GetToString() + type + FailedToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "wifi配置参数" + "数据接收" + "失败", null);
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
