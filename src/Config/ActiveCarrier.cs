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
    public partial class ActiveCarrier : CustomControl
    {
        public ActiveCarrier()
        {
            InitializeComponent();
        }

        public ActiveCarrier(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }

        public void LanguagedChanged()
        {
            ResourceManager rm = new ResourceManager(typeof(SrDemo));
            groupBox12.Text = rm.GetString("Carrier");
            button12.Text = rm.GetString("CarrierOn");
            button5.Text = rm.GetString("CarrierOff");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                string result = sd.ReaderControllor.StartCarrier(WorkingReader);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("读写器" + WorkingReader.dev + "开始载波测试" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "开始载波测试" + "命令发送" + "失败", null);
                    }
                }
            }
            catch(Exception ex)
            {
                sd.UpdateLog(ex.ToString());
                if (SrDemo.isLogOpen)
                {
                    ErrorLog.WriteError(ex.ToString());
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string result = sd.ReaderControllor.StopCarrier(WorkingReader);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("读写器" + WorkingReader.dev + "停止载波测试" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "停止载波测试" + "命令发送" + "失败", null);
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
