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
    public partial class Beep : CustomControl
    {
        public Beep()
        {
            InitializeComponent();
        }

        public Beep(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        /*    try
            {
                sd.ReaderControllor.GetBeep(WorkingReader);
            }
            catch (Exception ex)
            {
                sd.UpdateLog(ex.ToString());
            }*/
        }

        public void LanguagedChanged()
        {
            ResourceManager rm = new ResourceManager(typeof(SrDemo));
            label1.Text = rm.GetString("BuzzerSoundFrequency");
            label2.Text = rm.GetString("TheLengthOftheBuzze");
            button2.Text = rm.GetString("Set");
            groupBox1.Text = rm.GetString("BeepTest");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                byte count = byte.Parse(TextBoxBeepCount.Text);
                ushort length = ushort.Parse(TextBoxBeepLength.Text);
                string result = sd.ReaderControllor.SetBeep(WorkingReader, count,length);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "蜂鸣器" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "蜂鸣器" + "命令发送" + "失败", null);
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
                int offset = 2;
                TextBoxBeepCount.Text = subinfo[offset + 0];
                TextBoxBeepLength.Text = subinfo[offset + 1];
            }
            catch (Exception ex)
            {
                sd.UpdateLog(ex.ToString());
            }

        }
    }
}
