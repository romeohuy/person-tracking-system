using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetFrame.Net.TCP.Sock.Asynchronous;
using System.Configuration;
using SrDemo.Business;
using System.Resources;
using SrDemo.Log;


namespace SrDemo.Config
{
    public partial class MACAndDev : CustomControl
    {
        public MACAndDev()
        {
            InitializeComponent();
        }

        public MACAndDev(SrDemo sd)
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

        public void UpdateView(string[] result, string type)
        {
            int offset = 2;
            if (result[offset + 0] == ErrorNum.success)
            {
                new_mac_tb.Text = result[offset + 1];
                new_dev_tb.Text = result[offset + 2];
                textBox15.Text = result[offset + 3];
                try
                {
                    comboBox5.SelectedIndex = byte.Parse(result[offset + 4]);
                    comboBox6.SelectedIndex = byte.Parse(result[offset + 5]);
                }
                catch (Exception ex)
                {
                  //  sd.UpdateLog(ex.ToString());
                }
                UpdateDevID(result[offset + 2]);

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
                sd.UpdateLog("查询MAC地址和设备号成功");
                if (SrDemo.isLogOpen)
                {
                    EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "MAC和设备号" + "数据接收" + "成功", null);
                }
            }
            else
            {
                sd.UpdateLog("查询MAC地址和设备号失败");
                if (SrDemo.isLogOpen)
                {
                    EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "MAC和设备号" + "数据接收" + "失败", null);
                }
            }
        }

        private void UpdateDevID(string deID)
        {
            try
            {
                byte[] id = PrivateStringFormat.StrToHexByte(deID);
                devtype_tb.Text = (id[0] >> 2).ToString();
                year.SelectedIndex = ((id[0] & 0x03) << 4) | (id[1] >> 4);
                month.SelectedIndex = (id[1] & 0x0F) - 1;
               // product_nun_tb.Text = ((ushort)((id[2] << 8) | id[3])).ToString();
                product_nun_tb.Text = "0" + ((ushort)((id[2] << 8) | id[3])).ToString();  //乔佳 2018-7-26 长编码后多加0
                if (SrDemo.isLogOpen)
                {
                    EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "MAC和设备号" + "数据接收" + "成功", null);
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

        private void creatdev()
        {
            if (devtype_tb.Text == "") return;
            if (product_nun_tb.Text == "") return;
            byte type = byte.Parse(devtype_tb.Text);
            byte Year = (byte)year.SelectedIndex;
            byte Month = (byte)(month.SelectedIndex + 1);
            ushort nun = ushort.Parse(product_nun_tb.Text);
            byte[] id = new byte[4];
            id[0] = (byte)((type << 2) | (Year & 0x30) >> 4);
            id[1] = (byte)((Year << 4) | (Month & 0x0F));
            id[2] = (byte)(nun >> 8);
            id[3] = (byte)nun;
            new_dev_tb.Text = id[0].ToString("X2") + id[1].ToString("X2") + id[2].ToString("X2") + id[3].ToString("X2");
        }   

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                creatdev();
                string mac = new_mac_tb.Text;
                string dev = new_dev_tb.Text;
                ushort deviceType = ushort.Parse(textBox15.Text);
                string result = sd.ReaderControllor.SetMACDev(WorkingReader, mac, dev, deviceType);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "MAC和设备号" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "MAC和设备号" + "命令发送" + "失败", null);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void LanguagedChanged()
        {
            ResourceManager rm = new ResourceManager(typeof(SrDemo));

        }


        private void ButtonFactoryAccess_Click(object sender, EventArgs e)
        {
            if (textBoxButtonFactoryAccess.Text == "sy123")
            {
                devtype_tb.Enabled = true;
                textBox15.Enabled = true;
                new_mac_tb.Enabled = true;
                comboBox5.Enabled = true;
                comboBox6.Enabled = true;
                button1.Enabled = true;
                button33.Enabled = true;
            }
            else
            {
                sd.UpdateLog("访问密码错误");
            }

        }

        private void button33_Click(object sender, EventArgs e)
        {
            try
            {
                byte dataMode = (byte)comboBox5.SelectedIndex;
                byte baudRate = 0;
                if (comboBox6.Text == "115200")
                {
                    baudRate = 0;
                }
                else if (comboBox6.Text == "230400")
                {
                    baudRate = 0x55;
                }
                string result =  sd.ReaderControllor.SetDataMode(WorkingReader, dataMode, baudRate);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "串口波特率" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "串口波特率" + "命令发送" + "失败", null);
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

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (radioButton1.Checked == true)
            {
                cfa.AppSettings.Settings["LogIsOpen"].Value = "yes";
                SrDemo.isLogOpen = true;
            }
            else
            {
                cfa.AppSettings.Settings["LogIsOpen"].Value = "no";
                SrDemo.isLogOpen = false;
            }
            cfa.Save();
            sd.UpdateLog("日志的开启关闭状态设置成功");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["LogIsOpen"] != "null")
            {
                if (ConfigurationManager.AppSettings["LogIsOpen"] == "yes")
                {
                     radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;                   
                }
            }
            else
            {
                sd.UpdateLog("请先设置日志的开启关闭状态");
            }
        }

        private void devtype_tb_TextChanged(object sender, EventArgs e)
        {
            creatdev();
        }

        private void year_SelectedIndexChanged(object sender, EventArgs e)
        {
            creatdev();
        }

        private void month_SelectedIndexChanged(object sender, EventArgs e)
        {
            creatdev();
        }

        private void product_nun_tb_TextChanged(object sender, EventArgs e)
        {
            creatdev();
        }
    }
}
