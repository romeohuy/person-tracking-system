using SrDemo.Log;
using System;
using System.Resources;

namespace SrDemo.Config
{
    public partial class Carrier : CustomControl
    {
        public Carrier()
        {
            InitializeComponent();
        }

        public Carrier(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string result = sd.ReaderControllor.GetCarrier(WorkingReader);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "载波测试开关状态" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "载波测试开关状态" + "命令发送" + "失败", null);
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
            groupBox1.Text = rm.GetString("Carrier");
            radioButtonCattierOn.Text = rm.GetString("Configure_On");
            radioButtonCattierOff.Text = rm.GetString("Configure_Off");
            button2.Text = rm.GetString("Set");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                byte carrier;
                if (radioButtonCattierOn.Checked == true)
                {
                    carrier = 0x01;
                }
                else
                {
                    carrier = 0x00;
                }
                string result = sd.ReaderControllor.SetCarrier(WorkingReader,carrier);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "载波测试开关状态" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "载波测试开关状态" + "命令发送" + "失败", null);
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
                    if (subinfo[3] == "1")
                    {
                        radioButtonCattierOn.Checked = true;
                    }
                    else
                    {
                        radioButtonCattierOff.Checked = true;
                    }
                    sd.UpdateLog(GetToString() + type + OkToString());

                }
                else
                {
                    sd.UpdateLog(GetToString() + type + FailedToString());
                }
            }
            catch (Exception ex)
            {
                sd.UpdateLog(ex.ToString());
            }
        }


    }
}
