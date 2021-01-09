using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SrDemo.Log;
using SrDemo.Business;
using System.Resources;

namespace SrDemo.Config
{
    public partial class LongBM : CustomControl
    {
        public LongBM()
        {
            InitializeComponent();
        }
        public LongBM(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                string result = sd.ReaderControllor.GetMACDev(WorkingReader);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "MAC和设备号" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "MAC和设备号" + "命令发送" + "失败", null);
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
            groupBox2.Text = rm.GetString("StartContent");
            LongDevIDlabel.Text = rm.GetString("Lengthcoding");
            label97.Text = rm.GetString("Readermodel");
            button13.Text = rm.GetString("Get");
        }


        public void UpdateView(string[] result, string type)
        {
            int offset = 2;
            if (result[offset + 0] == ErrorNum.success)
            {
                new_mac_tb.Text = result[offset + 1];
                textBox15.Text = result[offset + 3];

                string devid = PrivateStringFormat.shortTolongNum(result[offset + 2]);

                string bz_str = "";
                if (devid.Length < 15)
                {
                    int bz_len = 15 - devid.Length;

                    for (int i = 0; i < bz_len; i++)
                    {
                        bz_str += "0";
                    }

                    devid = devid.Substring(0, 2) + bz_str + devid.Substring(2, 11);
                }


                LongDevIDlabel.Text = "长编码： " + devid;
                sd.UpdateLog("查询长编码成功");
                if (SrDemo.isLogOpen)
                {
                    EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "长编码" + "数据接收" + "成功", null);
                }
            }
            else
            {
                sd.UpdateLog("查询长编码失败");
                if (SrDemo.isLogOpen)
                {
                    EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "长编码" + "数据接收" + "失败", null);
                }
            }
        }

        private void LongDevIDlabel_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            //try
            //{
            //    string result = sd.ReaderControllor.GetMACDev(WorkingReader);
            //    if (SrDemo.isLogOpen)
            //    {
            //        if (result == ErrorNum.SEND_OK)
            //        {
            //            EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "MAC和设备号" + "命令发送" + "成功", null);
            //        }
            //        else
            //        {
            //            EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "MAC和设备号" + "命令发送" + "失败", null);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    sd.UpdateLog(ex.ToString());
            //    if (SrDemo.isLogOpen)
            //    {
            //        ErrorLog.WriteError(ex.ToString());
            //    }
            //}
        }


    }
}
