using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SrDemo.Log;
using System.Resources;
using System.Threading;

namespace SrDemo.Config
{
    public partial class ModuleVersion : CustomControl
    {
        public ModuleVersion()
        {
            InitializeComponent();
        }

        private void ModuleVersion_Load(object sender, EventArgs e)
        {

        }

        public ModuleVersion(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }



        public void LanguagedChanged()
        {
            ResourceManager rm = new ResourceManager(typeof(SrDemo));
            ModuleVersiongb.Text = rm.GetString("Configure_FirmVersion");         
            label1.Text = rm.GetString("Configure_Firm_Version");
            label3.Text = rm.GetString("Configure_HardVersion");
            button1.Text = rm.GetString("Get");
        }

        private void button1_Click(object sender, EventArgs e)
        {
           string result =  sd.ReaderControllor.GetHardVersion(WorkingReader);
           if (SrDemo.isLogOpen)
           {
               if (result == ErrorNum.SEND_OK)
               {
                   EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "模块硬件版本" + "命令发送" + "成功", null);
               }
               else
               {
                   EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "模块硬件版本" + "命令发送" + "失败", null);
               }
           }
           Thread.Sleep(1000);
            result = sd.ReaderControllor.GetFirmVersion(WorkingReader);
           if (SrDemo.isLogOpen)
           {
               if (result == ErrorNum.SEND_OK)
               {
                   EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "模块固件版本" + "命令发送" + "成功", null);
               }
               else
               {
                   EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "模块固件版本" + "命令发送" + "失败", null);
               }
           }
        }

        internal void UpdateHardVersionView(string[] result,string type)
        {
            try
            {
                if (result[2] == ErrorNum.success)
                {
                    label4.Text = result[3];
                    sd.UpdateLog(GetToString() + type + OkToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + type + "数据接收" + "成功", null);
                    }
                }
                else
                {
                    sd.UpdateLog(GetToString() + type + FailedToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + type + "数据接收" + "失败", null);
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

        internal void UpdateFirmVersionView(string[] result, string type)
        {
            try
            {
                if (result[2] == ErrorNum.success)
                {
                    label2.Text = result[3];
                    sd.UpdateLog(GetToString() + type + OkToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + type + "数据接收" + "成功", null);
                    }
                }
                else
                {
                    sd.UpdateLog(GetToString() + type + FailedToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + type + "数据接收" + "失败", null);
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
