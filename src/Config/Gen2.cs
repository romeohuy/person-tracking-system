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
    public partial class Gen2 : CustomControl
    {
        public Gen2()
        {
            InitializeComponent();
        }

        public Gen2(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string result = sd.ReaderControllor.GetGen2(WorkingReader);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "Gen2" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "Gen2" + "命令发送" + "失败", null);
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

        public void UpdateGen2ModeBox()
        {
            ResourceManager rm = new ResourceManager(typeof(SrDemo));
            gen2_type_cb.Items.Clear();
            gen2_type_cb.Items.Add(rm.GetString("Fixed"));
            gen2_type_cb.Items.Add(rm.GetString("Dynamic"));
        }

        public void LanguagedChanged()
        {
            ResourceManager rm = new ResourceManager(typeof(SrDemo));
            groupBox3.Text = rm.GetString("OPGen2");
            type_l.Text = rm.GetString("Configure_Gen2_Type");
            label21.Text = rm.GetString("Configure_Gen2_Start");
            label22.Text = rm.GetString("Configure_Gen2_Min");
            label23.Text = rm.GetString("Configure_Gen2_Max");
            button1.Text = rm.GetString("Get");
            button2.Text = rm.GetString("Set");
            UpdateGen2ModeBox();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                byte gen2Type = (byte)gen2_type_cb.SelectedIndex;
                byte gen2Start = (byte)start_gen2_cb.SelectedIndex;
                byte gen2Min = (byte)min_gen2_cb.SelectedIndex;
                byte gen2Max = (byte)max_gen2_cb.SelectedIndex;
                byte gen2Select = (byte)select_gen2_cb.SelectedIndex;
                byte gen2Session = (byte)session_gen2_cb.SelectedIndex;
                byte gen2Target = (byte)target_gen2_cb.SelectedIndex;
                string result = sd.ReaderControllor.SetGen2(WorkingReader, gen2Type, gen2Start, gen2Min, gen2Max, gen2Select, gen2Session, gen2Target);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "Gen2" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "Gen2" + "命令发送" + "失败", null);
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
                    try
                    {
                        if (subinfo[3] == "0")
                        {
                            gen2_type_cb.SelectedIndex = 0;
                        }
                        else if (subinfo[3] == "1")
                        {
                            gen2_type_cb.SelectedIndex = 1;
                        }
                        else
                        {
                            sd.UpdateLog("Invalid values");
                        }
                        start_gen2_cb.SelectedIndex = byte.Parse(subinfo[4]);
                        min_gen2_cb.SelectedIndex = byte.Parse(subinfo[5]);
                        max_gen2_cb.SelectedIndex = byte.Parse(subinfo[6]);
                        select_gen2_cb.SelectedIndex = byte.Parse(subinfo[7]);
                        session_gen2_cb.SelectedIndex = byte.Parse(subinfo[8]);
                        target_gen2_cb.SelectedIndex = byte.Parse(subinfo[9]);
                        sd.UpdateLog(GetToString() + type + OkToString());
                        if (SrDemo.isLogOpen)
                        {
                            EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "Gen2" + "数据接收" + "成功", null);
                        }
                    }
                    catch
                    {
                        sd.UpdateLog("Invalid values");
                    }
                }
                else
                {
                    sd.UpdateLog(GetToString() + type + FailedToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "Gen2" + "数据接收" + "失败", null);
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

        private void gen2_type_cb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
