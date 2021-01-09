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
    public partial class RFLink : CustomControl
    {
        public RFLink()
        {
            InitializeComponent();
        }

        public RFLink(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }

        private void Set_RF_link_profile_Click(object sender, EventArgs e)
        {
            byte rflink = 0x00;
            if (rf_link_profile_index.Text == "DSB_ASK / FM0 / 40KHZ")
            {
                rflink = 0x00;
            }
            else if (rf_link_profile_index.Text == "PR _ASK / Miller4 / 250KHZ")
            {
                rflink = 0x01;
            }
            else if (rf_link_profile_index.Text == "PR _ASK / Miller4 / 300KHZ")
            {
                rflink = 0x02;
            }
            else if (rf_link_profile_index.Text == "DSB_ASK / FM0 / 400KHZ")
            {
                rflink = 0x03;
            }
            byte DDSave = 0x00; //断电保存变量
            if (checkBox1.Checked == true)
            {
                DDSave = 0x01;
            }
            else
            {
                DDSave = 0x00;
            }
            sd.ReaderControllor.SetRFLink(WorkingReader, rflink,DDSave);
        }

        private void Get_RF_Link_profile_Click(object sender, EventArgs e)
        {
            try
            {
                string result = sd.ReaderControllor.GetRFLink(WorkingReader);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "RF—Link配置" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "RF—Link配置" + "命令发送" + "失败", null);
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
            label42.Text = rm.GetString("Access_Data");
            groupBox17.Text = rm.GetString("RFLInk");
            Get_RF_Link_profile.Text = rm.GetString("Get");
            Set_RF_link_profile.Text = rm.GetString("Set");
        }

        //更新视图
        public void UpdateView(string[] subinfo, string type)
        {
          try
            {
                if (subinfo[2] == ErrorNum.success)
                {
                    byte link = byte.Parse(subinfo[3]);
                    rf_link_profile_index.SelectedIndex = link;
                    sd.UpdateLog(GetToString() + type + OkToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "RF—Link配置" + "数据接收" + "成功", null);
                    }
                }
                else
                {
                    sd.UpdateLog(GetToString() + type + FailedToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "RF—Link配置" + "数据接收" + "失败", null);
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
