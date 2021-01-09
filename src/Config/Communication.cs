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
    public partial class Communication : CustomControl
    {

        public Communication()
        {
            InitializeComponent();
        }

        public Communication(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                string result = sd.ReaderControllor.GetCommunicationInfo(WorkingReader);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "有限网络配置" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "有限网络配置" + "命令发送" + "失败", null);
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
            groupBox15.Text = rm.GetString("Mode_Communication");
            label38.Text = rm.GetString("Mode_Communication_MAC");
            label39.Text = rm.GetString("Mode_Communication_MASK");
            label40.Text = rm.GetString("Mode_Communication_GateWay");
            label44.Text = rm.GetString("Mode_Communication_Reader") + rm.GetString("Mode_Communication_IP");
            label43.Text = rm.GetString("Mode_Communication_Reader") + rm.GetString("Mode_Communication_Port");
            label45.Text = rm.GetString("Mode_Serever") + rm.GetString("Mode_Communication_IP");
            label46.Text = rm.GetString("Mode_Serever") + rm.GetString("Mode_Communication_Port");
            groupBox17.Text = rm.GetString("Mode_Extra_port");
            standard_rb.Text = rm.GetString("Mode_Communication_Standard");
            button10.Text = rm.GetString("Get");
            button11.Text = rm.GetString("Set");
        }


        public void UpdateView(string[] subinfo, string type)
        {
            int offset = 2;
            if (subinfo[offset + 0] == ErrorNum.success)
            {
                Mac_tb.Text = subinfo[offset + 1];
                readerIP_tb.Text = subinfo[offset + 2];
                Mask_tb.Text = subinfo[offset + 3];
                Gateway_tb.Text = subinfo[offset + 4];
                dns_tb.Text = subinfo[offset + 5];
                ServerIP_tb.Text = subinfo[offset + 6];
                ReaderPort_tb.Text = subinfo[offset + 7];
                Serverport_tb.Text = subinfo[offset + 8];
                if (subinfo[offset + 9] == "2")
                {
                    wifi_rb.Checked = true;
                }
                else if (subinfo[offset + 9] == "3")
                {
                    RS485_rb.Checked = true;
                }
                else if (subinfo[offset + 9] == "0")
                {
                    standard_rb.Checked = true;
                }
                else if (subinfo[offset + 9] == "4")
                {
                    radioButton17.Checked = true;
                }
                else
                {
                    radioButton1.Checked = true;
                }
                sd.UpdateLog(GetToString() + type + OkToString());
                if (SrDemo.isLogOpen)
                {
                    EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "有限网络配置" + "数据接收" + "成功", null);
                }
            }
            else
            {
                sd.UpdateLog(GetToString() + type + FailedToString());
                if (SrDemo.isLogOpen)
                {
                    EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "有限网络配置" + "数据接收" + "失败", null);
                }
            }
        }


        public void SetParameterRespond(string[] subinfo)
        {

        }
        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                string mac = Mac_tb.Text;
                string readerIP = readerIP_tb.Text;
                string mask = Mask_tb.Text;
                string gateway = Gateway_tb.Text;
                string dns = dns_tb.Text;
                string serverIP = ServerIP_tb.Text;
                ushort readerport = ushort.Parse(ReaderPort_tb.Text);
                ushort Serverport = ushort.Parse(Serverport_tb.Text);
                byte moreport = 0x00;
                if (standard_rb.Checked == true)
                {
                    moreport = 0x00;
                }
                else if (wifi_rb.Checked == true)
                {
                    moreport = 0x02;
                }
                else if (RS485_rb.Checked == true)
                {
                    moreport = 0x03;
                }
                else if (radioButton17.Checked == true)
                {
                    moreport = 0x04;
                }
                else if (radioButton1.Checked == true)
                {
                    moreport = 0x05;
                }
                string result = sd.ReaderControllor.SetCommunicationInfo(CurrentClient, mac, readerIP, mask, gateway, dns, serverIP, readerport, Serverport, moreport);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "有限网络配置" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "有限网络配置" + "命令发送" + "失败", null);
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
