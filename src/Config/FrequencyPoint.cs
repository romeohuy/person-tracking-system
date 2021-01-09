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
    public partial class FrequencyPoint : CustomControl
    {
        public FrequencyPoint()
        {
            InitializeComponent();
        }

        public FrequencyPoint(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }

        private void button_get_fp_Click(object sender, EventArgs e)
        {
            try
            {
                string result = sd.ReaderControllor.GetFrequencyPoints(WorkingReader);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("查询读写器" + WorkingReader.dev + "频点" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("查询读写器" + WorkingReader.dev + "频点" + "命令发送" + "失败", null);
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

        private void button_set_fp_Click(object sender, EventArgs e)
        {
            string strfp = richTextBox_frequency_point.Text.Remove(richTextBox_frequency_point.Text.Length - 1, 1);
            string[] str_fp = strfp.Split(';');
            string result = sd.ReaderControllor.SetFRequencyPoint(WorkingReader, (byte)str_fp.Length, str_fp);
            if (SrDemo.isLogOpen)
            {
                if (result == ErrorNum.SEND_OK)
                {
                    EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "频点" + "命令发送" + "成功", null);
                }
                else
                {
                    EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "频点" + "命令发送" + "失败", null);
                }
            }
        }

        private void button_create_fp_Click(object sender, EventArgs e)
        {
            try
            {
                int fp_min = int.Parse(textBox_fp_min.Text);
                int fp_max = int.Parse(textBox_fp_max.Text);
                int fp_int = int.Parse(textBox_fp_interval.Text);

                if (fp_int > 0.1)
                {
                    if (fp_min < fp_max)
                    {
                        float temp;
                        string fp_str = "";

                        temp = fp_min;
                        while (temp <= fp_max)
                        {
                            fp_str += temp.ToString() + ";";
                            temp += fp_int;
                        }

                        richTextBox_frequency_point.Text = fp_str;
                    }
                }
            }
            catch
            {
                MessageBox.Show("您未输入字符!","提示");
            }
        }


        public void LanguagedChanged()
        {
            ResourceManager rm = new ResourceManager(typeof(SrDemo));
            groupBox1.Text = rm.GetString("Configure_Frequency_Points");
            label19.Text = rm.GetString("Configure_Gen2_Min");
            label47.Text = rm.GetString("Configure_Gen2_Max");
            label53.Text = rm.GetString("ChannelSpace");
            button_create_fp.Text = rm.GetString("Configure_Frequency_Creat");
            button_fp_example.Text = rm.GetString("Configure_Frequency_Sample");
            button_fp_clear.Text = rm.GetString("Inventory_ClearData");
            button_get_fp.Text = rm.GetString("Get");
            button_set_fp.Text = rm.GetString("Set");
        }


        private void button_fp_example_Click(object sender, EventArgs e)
        {
            textBox_fp_min.Text = "920000";
            textBox_fp_max.Text = "925000";
            textBox_fp_interval.Text = "250";

            button_create_fp_Click(sender, e);
        }

        private void button_fp_clear_Click(object sender, EventArgs e)
        {
            richTextBox_frequency_point.Text = "";
            textBox_fp_min.Text = "";
            textBox_fp_max.Text = "";
            textBox_fp_interval.Text = "";
        }

        public void UpdateView(string[] subinfo, string type)
        {
            try
            {
                int offset = 2;
                if (subinfo[offset + 0] == ErrorNum.success)
                {
                    richTextBox_frequency_point.Text = subinfo[offset + 1];
                    sd.UpdateLog(GetToString() + type + OkToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "频点" + "数据接收" + "成功", null);
                    }
                }
                else
                {
                    sd.UpdateLog(GetToString() + type + FailedToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "频点" + "数据接收" + "失败", null);
                    }
                }
            }
            catch (Exception ex)
            {
                sd.UpdateLog(ex.ToString());
            }
        }
    }
}
