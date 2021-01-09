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
    public partial class QT : CustomControl
    {


        public QT()
        {
            InitializeComponent();
        }

        public QT(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 设置QT参数 读取QT标签数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            QTParameter qt = new QTParameter();
            try
            {
                qt.password = textBoxQTPassword.Text;
                qt.flitertype = (byte)comboBoxQTFlitertype.SelectedIndex;
                if (qt.flitertype != 2)
                {
                    qt.data = textBoxQTFliterData.Text;
                }
                qt.flag = 1;   //设置完后执行读操作
                if (radioButtonlitterdistance.Checked == true)
                {
                    qt.distance = 0;
                }
                else
                {
                    qt.distance = 1;
                }
                if (radioButtonQTPublic.Checked == true)
                {
                    qt.memorymap = 1;
                }
                else
                {
                    qt.memorymap = 0;
                }
                qt.bank = (byte)comboBoxQTBank.SelectedIndex;
                qt.startadd = ushort.Parse(textBoxQTStartAdd.Text);
                qt.len = ushort.Parse(textBoxQtDataLen.Text);
                qt.save = 1;
                if (qt.flag == 2)
                {
                    qt.writedata = textBoxQTData.Text;
                }
            }   
            catch(Exception ex)
            {
                sd.UpdateLog(ex.ToString());
            }
            string result = sd.ReaderControllor.SetQT(WorkingReader, qt);
            if (SrDemo.isLogOpen)
            {
                if (result == ErrorNum.SEND_OK)
                {
                    EventLog.WriteEvent("读写器" + WorkingReader.dev + "QT读标签" + "命令发送" + "成功", null);
                }
                else
                {
                    EventLog.WriteEvent("读写器" + WorkingReader.dev + "QT读标签" + "命令发送" + "失败", null);
                }
            }
        }


        public void LanguagedChanged()
        {
            ResourceManager rm = new ResourceManager(typeof(SrDemo));
            groupBox1.Text = rm.GetString("Access_Fliter");
            label3.Text = rm.GetString("Access_FliterType");
            label1.Text = rm.GetString("Access_Fliter_FliterData");
            label2.Text = rm.GetString("Access_Fliter_FliterPWD");
            groupBox2.Text ="QT"+ rm.GetString("Access_Read_Write");
            label4.Text = rm.GetString("Access_Bank");
            label5.Text = rm.GetString("Access_StartAdd");
            label6.Text = rm.GetString("Access_Length");
            button1.Text = rm.GetString("Access_Read");
            button2.Text = rm.GetString("Access_Write");
            button3.Text = rm.GetString("Get");
            button4.Text = rm.GetString("Set");
            groupBox3.Text = rm.GetString("QTtag") + rm.GetString("ParameterSetting");
            radioButtonlitterdistance.Text = rm.GetString("CloseRangeControlOff");
            radioButtonRemote.Text = rm.GetString("CloseRangeControlOn");
            radioButtonQTPublic.Text = rm.GetString("PublicArea");
            radioButtonQTPrivate.Text = rm.GetString("PrivateArea");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QTParameter qt = new QTParameter();
            try
            {
                qt.password = textBoxQTPassword.Text;
                qt.flitertype = (byte)comboBoxQTFlitertype.SelectedIndex;
                if (qt.flitertype != 0)
                {
                    qt.data = textBoxQTFliterData.Text;
                }
                qt.flag = 2;   //设置完后执行写操作
                if (radioButtonlitterdistance.Checked == true)
                {
                    qt.memorymap = 0;
                }
                else
                {
                    qt.memorymap = 1;
                }
                qt.bank = (byte)comboBoxQTBank.SelectedIndex;
                qt.startadd = ushort.Parse(textBoxQTStartAdd.Text);
                qt.len = ushort.Parse(textBoxQtDataLen.Text);
                qt.save = 1;
                if (qt.flag == 2)
                {
                    qt.writedata = textBoxQTData.Text;
                }
            }

            catch(Exception ex)
            {
                sd.UpdateLog(ex.ToString());
            }
            string result = sd.ReaderControllor.SetQT(WorkingReader, qt);
            if (SrDemo.isLogOpen)
            {
                if (result == ErrorNum.SEND_OK)
                {
                    EventLog.WriteEvent("读写器" + WorkingReader.dev + "QT写标签" + "命令发送" + "成功", null);
                }
                else
                {
                    EventLog.WriteEvent("读写器" + WorkingReader.dev + "QT写标签" + "命令发送" + "失败", null);
                }
            }
        }

        public void UpdateView(string[] subinfo, string type)
        {
            int offset = 2;
            if (subinfo[offset] == "1")
            {
                sd.UpdateLog(SetToString() + type + OkToString());
                if (subinfo[offset + 1] == "1")
                {
                    textBoxQTData.Text = subinfo[offset + 2];
                }
                if (SrDemo.isLogOpen)
                {
                    EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "QT参数" + "数据接收" + "成功", null);
                }
            }
            else
            {
                sd.UpdateLog(SetToString() + type + FailedToString());
                if (SrDemo.isLogOpen)
                {
                    EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "QT参数" + "数据接收" + "失败", null);
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            QTParameter qt = new QTParameter();
            try
            {
                qt.password = textBoxQTPassword.Text;
                qt.flitertype = (byte)comboBoxQTFlitertype.SelectedIndex;
                if (qt.flitertype != 0)
                {
                    qt.data = textBoxQTFliterData.Text;
                }
                qt.flag = 0;   //获取参数不做任何操作
                if (radioButtonlitterdistance.Checked == true)
                {
                    qt.memorymap = 0;
                }
                else
                {
                    qt.memorymap = 1;
                }
                qt.bank = (byte)comboBoxQTBank.SelectedIndex;
                qt.startadd = ushort.Parse(textBoxQTStartAdd.Text);
                qt.len = ushort.Parse(textBoxQtDataLen.Text);
                qt.save = 1;
                if (qt.flag == 2)
                {
                    qt.writedata = textBoxQTData.Text;
                }
            }

            catch (Exception ex)
            {
                sd.UpdateLog(ex.ToString());
            }
            string result = sd.ReaderControllor.SetQT(WorkingReader, qt);
            if (SrDemo.isLogOpen)
            {
                if (result == ErrorNum.SEND_OK)
                {
                    EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "QT标签参数" + "命令发送" + "成功", null);
                }
                else
                {
                    EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "QT标签参数" + "命令发送" + "失败", null);
                }
            }
        }
    }
}
