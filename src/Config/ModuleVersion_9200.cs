using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SrDemo.Log;


namespace SrDemo.Config
{
    public partial class ModuleVersion_9200 : CustomControl
    {
        public ModuleVersion_9200(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }

        public ModuleVersion_9200()
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string result = sd.ReaderControllor.GetModuleVersion_9200(WorkingReader);
            }
            catch (Exception ex)
            {
                sd.UpdateLog(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte Data5 = 0x00;
            byte Data6 = 0x00;
            byte Data7 = 0x00;

            if (comboBox1.SelectedIndex == 0)
            {
                Data5 = 0xA6;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                Data5 = 0x00;
            }

            if (comboBox2.SelectedIndex == 0)
            {
                Data6 = 0xA7;
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                Data6 = 0x00;
            }

            if (comboBox3.SelectedIndex == 0)
            {
                Data7 = 0x25;
            }
            else if (comboBox3.SelectedIndex == 1)
            {
                Data7 = 0x30;
            }

            try
            {
                string result = sd.ReaderControllor.SetModuleVersion_9200(WorkingReader,Data5, Data6, Data7);
            }
            catch (Exception ex)
            {
                sd.UpdateLog(ex.ToString());
            }


        }


        public void UpdateView(string[] subinfo)
        {
            int offset = 2;
            try
            {
                if (subinfo[2] == "1")
                {
                    if (subinfo[3] == "A6")
                    {
                        comboBox1.SelectedIndex =0;
                    }
                    else if (subinfo[3] == "0")
                    {
                        comboBox1.SelectedIndex = 1;
                    }

                    if (subinfo[4] == "A7")
                    {
                        comboBox2.SelectedIndex = 0;
                    }
                    else if (subinfo[4] == "0")
                    {
                        comboBox2.SelectedIndex = 1;
                    }

                    if (subinfo[5] == "25")
                    {
                        comboBox3.SelectedIndex = 0;
                    }
                    else if (subinfo[5] == "30")
                    {
                        comboBox3.SelectedIndex = 1;
                    }
                    sd.UpdateLog("获取9200模块版本成功!");
                }
                else
                {
                    sd.UpdateLog(GetToString() + "9200模块版本" + FailedToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取9200模块版本" + WorkingReader.dev + "失败", null);
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
