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
    public partial class Factory : CustomControl
    {
        public Factory()
        {
            InitializeComponent();
        }

        public Factory(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }

        private void Factory_Load(object sender, EventArgs e)
        {

        }

        public void LanguagedChanged()
        {
            ResourceManager rm = new ResourceManager(typeof(SrDemo));
            button1.Text = rm.GetString("Default");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = sd.ReaderControllor.SetFactoty(WorkingReader);
            if (SrDemo.isLogOpen)
            {
                if (result == ErrorNum.SEND_OK)
                {
                    EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "fastID" + "命令发送" + "成功", null);
                    sd.UpdateLog("恢复出厂设置成功");
                }
                else
                {
                    EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "fastID" + "命令发送" + "失败", null);
                    sd.UpdateLog("恢复出厂设置失败");
                }
            }
        }
    }
}
