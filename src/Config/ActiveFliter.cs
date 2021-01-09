using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetFrame.Net.TCP.Sock.Asynchronous;
using SrDemo.Business;
using System.Resources;
using SrDemo.Log;


namespace SrDemo.Config
{
    public partial class ActiveFliter : CustomControl
    {
        byte[] fliterdata = new byte[Types.ID_LEN * 10]; 
        public ActiveFliter()
        {
            InitializeComponent();
        }

        public ActiveFliter(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }

        public void LanguagedChanged()
        {
            ResourceManager rm = new ResourceManager(typeof(SrDemo));
            groupBox1.Text = rm.GetString("Fliter");
            button19.Text = rm.GetString("Inventory_ClearData");
            button18.Text = rm.GetString("Fliter");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Fliterdata1_tb.Text = "";
            Fliterdata2_tb.Text = "";
            Fliterdata3_tb.Text = "";
            Fliterdata4_tb.Text = "";
            Fliterdata5_tb.Text = "";
            Fliterdata6_tb.Text = "";
            Fliterdata7_tb.Text = "";
            Fliterdata8_tb.Text = "";
            Fliterdata9_tb.Text = "";
            Fliterdata10_tb.Text = "";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (Fliterdata1_tb.Text.Length != 12)
            {
                if (Fliterdata1_tb.Text == "")
                {
                    byte[] fliterdata1 = new byte[Types.ID_LEN];
                    fliterdata1.CopyTo(fliterdata, 0);
                }
                else
                {
                    sd.UpdateLog("Data Fliter length error");
                    return;
                }

            }
            else
            {
                byte[] fliterdatalong1 = PrivateStringFormat.DecStrToHexByte(Fliterdata1_tb.Text);
                byte[] fliterdata1 = PrivateStringFormat.LongByteToShortByte(fliterdatalong1);
                fliterdata1.CopyTo(fliterdata, 0);
            }
            if (Fliterdata2_tb.Text.Length != 12)
            {
                if (Fliterdata2_tb.Text == "")
                {
                    byte[] fliterdata2 = new byte[Types.ID_LEN];
                    fliterdata2.CopyTo(fliterdata, Types.ID_LEN);
                }
                else
                {
                    sd.UpdateLog("Data Fliter length error");
                    return;
                }
            }
            else
            {
                byte[] fliterdatalong2 = PrivateStringFormat.DecStrToHexByte(Fliterdata2_tb.Text);
                byte[] fliterdata2 = PrivateStringFormat.LongByteToShortByte(fliterdatalong2);
                fliterdata2.CopyTo(fliterdata, Types.ID_LEN);
            }
            if (Fliterdata3_tb.Text.Length != 12)
            {
                if (Fliterdata3_tb.Text == "")
                {
                    byte[] fliterdata3 = new byte[Types.ID_LEN];
                    fliterdata3.CopyTo(fliterdata, Types.ID_LEN * 2);
                }
                else
                {
                    sd.UpdateLog("Data Fliter length error");
                    return;
                }
            }
            else
            {
                byte[] fliterdatalong3 = PrivateStringFormat.DecStrToHexByte(Fliterdata3_tb.Text);
                byte[] fliterdata3 = PrivateStringFormat.LongByteToShortByte(fliterdatalong3);
                fliterdata3.CopyTo(fliterdata, Types.ID_LEN * 2);
            }
            if (Fliterdata4_tb.Text.Length != 12)
            {
                if (Fliterdata4_tb.Text == "")
                {
                    byte[] fliterdata4 = new byte[Types.ID_LEN];
                    fliterdata4.CopyTo(fliterdata, Types.ID_LEN * 3);
                }
                else
                {
                    sd.UpdateLog("Data Fliter length error");
                    return;
                }
            }
            else
            {
                byte[] fliterdatalong4 = PrivateStringFormat.DecStrToHexByte(Fliterdata4_tb.Text);
                byte[] fliterdata4 = PrivateStringFormat.LongByteToShortByte(fliterdatalong4);
                fliterdata4.CopyTo(fliterdata, Types.ID_LEN * 3);
            }
            if (Fliterdata5_tb.Text.Length != 12)
            {
                if (Fliterdata5_tb.Text == "")
                {
                    byte[] fliterdata5 = new byte[Types.ID_LEN];
                    fliterdata5.CopyTo(fliterdata, Types.ID_LEN * 4);
                }
                else
                {
                    sd.UpdateLog("Data Fliter length error");
                    return;
                }
            }
            else
            {
                byte[] fliterdatalong5 = PrivateStringFormat.DecStrToHexByte(Fliterdata5_tb.Text);
                byte[] fliterdata5 = PrivateStringFormat.LongByteToShortByte(fliterdatalong5);
                fliterdata5.CopyTo(fliterdata, Types.ID_LEN * 4);
            }
            if (Fliterdata6_tb.Text.Length != 12)
            {
                if (Fliterdata6_tb.Text == "")
                {
                    byte[] fliterdata6 = new byte[Types.ID_LEN];
                    fliterdata6.CopyTo(fliterdata, Types.ID_LEN * 5);
                }
                else
                {
                    sd.UpdateLog("Data Fliter length error");
                    return;
                }
            }
            else
            {
                byte[] fliterdatalong6 = PrivateStringFormat.DecStrToHexByte(Fliterdata6_tb.Text);
                byte[] fliterdata6 = PrivateStringFormat.LongByteToShortByte(fliterdatalong6);
                fliterdata6.CopyTo(fliterdata, Types.ID_LEN * 5);
            }
            if (Fliterdata7_tb.Text.Length != 12)
            {
                if (Fliterdata7_tb.Text == "")
                {
                    byte[] fliterdata7 = new byte[Types.ID_LEN];
                    fliterdata7.CopyTo(fliterdata, Types.ID_LEN * 6);
                }
                else
                {
                    sd.UpdateLog("Data Fliter length error");
                    return;
                }
            }
            else
            {
                byte[] fliterdatalong7 = PrivateStringFormat.DecStrToHexByte(Fliterdata7_tb.Text);
                byte[] fliterdata7 = PrivateStringFormat.LongByteToShortByte(fliterdatalong7);
                fliterdata7.CopyTo(fliterdata, Types.ID_LEN * 6);
            }
            if (Fliterdata8_tb.Text.Length != 12)
            {
                if (Fliterdata8_tb.Text == "")
                {
                    byte[] fliterdata8 = new byte[Types.ID_LEN];
                    fliterdata8.CopyTo(fliterdata, Types.ID_LEN * 7);
                }
                else
                {
                    sd.UpdateLog("Data Fliter length error");
                    return;
                }
            }
            else
            {
                byte[] fliterdatalong8 = PrivateStringFormat.DecStrToHexByte(Fliterdata8_tb.Text);
                byte[] fliterdata8 = PrivateStringFormat.LongByteToShortByte(fliterdatalong8);
                fliterdata8.CopyTo(fliterdata, Types.ID_LEN * 7);
            }
            if (Fliterdata9_tb.Text.Length != 12)
            {
                if (Fliterdata9_tb.Text == "")
                {
                    byte[] fliterdata9 = new byte[Types.ID_LEN];
                    fliterdata9.CopyTo(fliterdata, Types.ID_LEN * 8);
                }
                else
                {
                    sd.UpdateLog("Data Fliter length error");
                    return;
                }
            }
            else
            {
                byte[] fliterdatalong9 = PrivateStringFormat.DecStrToHexByte(Fliterdata9_tb.Text);
                byte[] fliterdata9 = PrivateStringFormat.LongByteToShortByte(fliterdatalong9);
                fliterdata9.CopyTo(fliterdata, Types.ID_LEN * 8);
            }
            if (Fliterdata10_tb.Text.Length != 12)
            {
                if (Fliterdata10_tb.Text == "")
                {
                    byte[] fliterdata10 = new byte[Types.ID_LEN];
                    fliterdata10.CopyTo(fliterdata, Types.ID_LEN * 9);
                }
                else
                {
                    sd.UpdateLog("Data Fliter length error");
                    return;
                }
            }
            else
            {
                byte[] fliterdatalong10 = PrivateStringFormat.DecStrToHexByte(Fliterdata10_tb.Text);
                byte[] fliterdata10 = PrivateStringFormat.LongByteToShortByte(fliterdatalong10);
                fliterdata10.CopyTo(fliterdata, Types.ID_LEN * 9);
            }
            string result = sd.ReaderControllor.FliterData(WorkingReader, 10, fliterdata);
            if (SrDemo.isLogOpen)
            {
                if (result == ErrorNum.SEND_OK)
                {
                    EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "过滤数据" + "命令发送" + "成功", null);
                }
                else
                {
                    EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "过滤数据" + "命令发送" + "失败", null);
                }
            }
        }
    }
}
