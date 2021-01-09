using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetFrame.Net.TCP.Sock.Asynchronous;
using Currency.ADO.DataBaseOperation;
using System.Resources;
using SrDemo.Log;
using System.Threading;
using System.Collections;
using System.Text.RegularExpressions;
using System.Globalization;

namespace SrDemo.Config
{
    public partial class TagAccess : CustomControl
    {
        private writeTagComand wtc = new writeTagComand();

        struct UInt96
          {
            ulong hi;
            uint lo;

                       
            // 构造函数
            public UInt96(ulong h, uint l)
            {
                hi = h;
                lo = l;
            }
    
            // 返回加1后的结果
            public UInt96 Inc(int dz)
            {
                if (lo < 0xFFFFFFFF) return new UInt96(hi, lo + (uint)dz);
                return new UInt96(hi + (ulong)dz, 0);
            }

            // 自增运算符
           // public static UInt96 operator ++(UInt96 x)
        //    {
          //      return x.Inc(int dz);
         //   }

            // 十六进制字符串表示
            public override string ToString()
            {
                return string.Join(" ", Regex.Split(string.Format("{0:X16}{1:X8}", hi, lo), "(?!^)(?=(?:.{4})+$)"));
            }
        }
 


        public TagAccess()
        {
            InitializeComponent();
        }


        public TagAccess(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }


        private void button_kill_Click(object sender, EventArgs e)
        {
            string killpwd = "";
            if (textBox_kill_password.Text.Length > 0)
            {
                if (textBox_kill_password.Text.Length != 8)
                {
                    sd.UpdateLog("密码长度不正确");
                    return;
                }
                else
                {
                    killpwd = textBox_kill_password.Text;
                }
            }
            byte fliter = (byte)(filterbox.SelectedIndex - 1);
            string fliterdata = Fliter_data_tb.Text;
            string result = sd.ReaderControllor.KillTags(WorkingReader, killpwd, fliter, fliterdata);
            if (SrDemo.isLogOpen)
            {
                if (result == ErrorNum.SEND_OK)
                {
                    EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "销毁标签" + "命令发送" + "成功", null);
                }
                else
                {
                    EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "销毁标签" + "命令发送" + "失败", null);
                }
            }
        }

        public void LanguagedChanged()
        {
            ResourceManager rm = new ResourceManager(typeof(SrDemo));
            groupBox2.Text = rm.GetString("Access_Fliter");
            label11.Text = rm.GetString("Access_Fliter_FliterData");
            label17.Text = rm.GetString("Access_Fliter_FliterPWD");
            groupBox7.Text = rm.GetString("Access_Read_Write");
            label30.Text = rm.GetString("Access_Bank");
            label31.Text = rm.GetString("Access_StartAdd");
            label27.Text = rm.GetString("Access_Length");
            label26.Text = rm.GetString("Access_FliterType");
            label33.Text = rm.GetString("Access_Data");
            button_data_read.Text = rm.GetString("Access_Read");
            button4.Text = rm.GetString("Access_Write");
            groupBox12.Text = rm.GetString("Access_Lock");
            label3.Text = rm.GetString("Access_Lock_Area");
            label41.Text = rm.GetString("Access_Lock_Mode");
            radioButton_rw_unable.Text = rm.GetString("Access_Lock");
            radioButton_rw_unable_forever.Text = rm.GetString("Access_Lock_UnLock");
            radioButton_rw_able.Text = rm.GetString("Access_Lock_Forever");
            radioButton_rw_able_forever.Text = rm.GetString("Access_UnLock_Forever");
            button_lock.Text = rm.GetString("Access_Lock");
            groupBox13.Text = rm.GetString("Access_Kill");
            label4.Text = rm.GetString("Access_Kill_pwd") + "(Hex)";
            button_kill.Text = rm.GetString("Access_Kill");

            groupBox1.Text = rm.GetString("SensorTagRead");
            groupBox3.Text = rm.GetString("SensorTagDisp");
            label1.Text = rm.GetString("Inventory_Time");
            label9.Text = rm.GetString("Inventory_Time");
            label10.Text = rm.GetString("Configure_Interval");
            StartSensonoOneBt.Text = rm.GetString("SensorStart1");
            StartSensonoTwoBt.Text = rm.GetString("SensorStart2");

            label8.Text = rm.GetString("humidity");
            label2.Text = rm.GetString("temper");
            NormalStateBt.Text = rm.GetString("Normal");
            SpeciaWorkStateRb.Text = rm.GetString("Special");
            button1.Text = rm.GetString("Set");

            groupBox4.Text = rm.GetString("NoFilterWrite");
            label24.Text = "(" + rm.GetString("Hex") + "):";
            label23.Text = rm.GetString("Incremental");
            button2.Text = rm.GetString("Write");

        }



        public void ReadTag()
        {
            this.button_data_read_Click(null, null);
        }

        private void button_data_read_Click(object sender, EventArgs e)
        {
            string readdata = "";
            if (filterbox.SelectedIndex == 1 || filterbox.SelectedIndex == 2)                 //有过滤
            {

                string pwd = "";
                if (pwd_tb.Text.Length > 0)
                {
                    if (pwd_tb.Text.Length != 8)
                    {
                        sd.UpdateLog("密码长度不正确");
                        return;
                    }
                    else
                    {
                        pwd = pwd_tb.Text;
                    }
                }
                byte bank = (byte)comboBox_mb.SelectedIndex;
                ushort startadd = ushort.Parse(textBox_head_address.Text);
                ushort readlen = ushort.Parse(textBox_data_len.Text);
                byte fliter = (byte)(filterbox.SelectedIndex - 1);
                string fliterdata = Fliter_data_tb.Text;
                string result = sd.ReaderControllor.ReadTags(WorkingReader, pwd, fliter, fliterdata, bank, startadd, readlen);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "读标签" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "读标签" + "命令发送" + "失败", null);
                    }
                }
            }
            else                                                                             //无过滤
            {
                string pwd = "";
                if (pwd_tb.Text.Length > 0)
                {
                    if (pwd_tb.Text.Length != 8)
                    {
                        sd.UpdateLog("密码长度不正确");
                        return;
                    }
                    else
                    {
                        pwd = pwd_tb.Text;
                    }
                }
                byte bank = (byte)comboBox_mb.SelectedIndex;
                ushort startadd = ushort.Parse(textBox_head_address.Text);
                ushort readlen = ushort.Parse(textBox_data_len.Text);
                byte fliter = 0x00;                                                //不过滤时无效
                string fliterdata = "";
                string result = sd.ReaderControllor.ReadTags(WorkingReader, pwd, fliter, fliterdata, bank, startadd, readlen);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "读标签" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "读标签" + "命令发送" + "失败", null);
                    }
                }
            }

        }


        /// 字节数组转16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            string ant = "";
            if (filterbox.SelectedIndex == 1 || filterbox.SelectedIndex == 2)                 //过滤
            {
                string pwd = "";
                if (pwd_tb.Text.Length > 0)
                {
                    if (pwd_tb.Text.Length != 8)
                    {
                        sd.UpdateLog("密码长度不正确");
                        return;
                    }
                    else
                    {
                        pwd = pwd_tb.Text;
                    }
                }
                byte bank = (byte)comboBox_mb.SelectedIndex;
                ushort startadd = ushort.Parse(textBox_head_address.Text);
                ushort readlen = ushort.Parse(textBox_data_len.Text);
                byte fliter = (byte)(filterbox.SelectedIndex - 1);
                string fliterdata = Fliter_data_tb.Text;

                string writedata = "";


                writedata = textBox_data.Text;
                //if (checkBox2.Checked == false)
                //{
                //    writedata = textBox_data.Text;
                //}
                //else
                //{
                //    try
                //    {
                //        byte[] byt_writedata = System.Text.ASCIIEncoding.Default.GetBytes(textBox_data.Text);
                //        byte[] New_writedata = new byte[readlen * 2];

                //        if (New_writedata.Length <= byt_writedata.Length)
                //        {
                //            Array.Copy(byt_writedata, 0, New_writedata, 0, readlen * 2);
                //        }
                //        else
                //        {
                //            Array.Copy(byt_writedata, 0, New_writedata, 0, byt_writedata.Length);
                //        }

                //        writedata = byteToHexStr(New_writedata);
                //    }
                //    catch (Exception ex)
                //    {
                //        sd.UpdateLog(ex.ToString());
                //    }
                //}


                string result = sd.ReaderControllor.WriteTags(WorkingReader, pwd, fliter, fliterdata, bank, startadd, readlen, writedata);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "写标签" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "写标签" + "命令发送" + "失败", null);
                    }
                }
            }
            else                                                                             //有过滤
            {
                string pwd = "";
                if (pwd_tb.Text.Length > 0)
                {
                    if (pwd_tb.Text.Length != 8)
                    {
                        sd.UpdateLog("密码长度不正确");
                        return;
                    }
                    else
                    {
                        pwd = pwd_tb.Text;
                    }
                }
                byte bank = (byte)comboBox_mb.SelectedIndex;
                ushort startadd = ushort.Parse(textBox_head_address.Text);
                ushort readlen = ushort.Parse(textBox_data_len.Text);
                byte fliter = 0x00;                                                //不过滤时无效
                string fliterdata = "";

                string writedata = "";



                writedata = textBox_data.Text;
                //if (checkBox2.Checked == false)
                //{
                //    writedata = textBox_data.Text;
                //}
                //else
                //{
                //    try
                //    {
                //        byte[] byt_writedata = System.Text.ASCIIEncoding.Default.GetBytes(textBox_data.Text);
                //        byte[] New_writedata = new byte[readlen * 2];

                //        if (New_writedata.Length <= byt_writedata.Length)
                //        {
                //            Array.Copy(byt_writedata, 0, New_writedata, 0, readlen * 2);
                //        }
                //        else
                //        {
                //            Array.Copy(byt_writedata, 0, New_writedata, 0, byt_writedata.Length);
                //        }

                //        writedata = byteToHexStr(New_writedata);
                //    }
                //    catch (Exception ex)
                //    {
                //        sd.UpdateLog(ex.ToString());
                //    }
                //}


                string result = sd.ReaderControllor.WriteTags(WorkingReader, pwd, fliter, fliterdata, bank, startadd, readlen, writedata);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "写标签" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "写标签" + "命令发送" + "失败", null);
                    }
                }
            }
            wtc.bank = comboBox_mb.Text;
            wtc.data = textBox_data.Text;
            wtc.type = "1A";
        }

        private void button_lock_Click(object sender, EventArgs e)
        {
            string pwd = "";
            if (pwd_tb.Text.Length > 0)
            {
                if (pwd_tb.Text.Length != 8)
                {
                    sd.UpdateLog("密码长度不正确");
                    return;
                }
                else
                {
                    pwd = pwd_tb.Text;
                }
            }
            byte fliter = (byte)(filterbox.SelectedIndex - 1);
            string fliterdata = Fliter_data_tb.Text;
            byte lock_mask = 0;
            byte lock_action = 0;
            int Shdata = _lock_mask_1();
            byte[] lockdata = { (byte)(Shdata >> 16), (byte)(Shdata >> 8), (byte)Shdata };
            string result = sd.ReaderControllor.LockTags(WorkingReader, pwd, fliter, fliterdata, lockdata);
            if (SrDemo.isLogOpen)
            {
                if (result == ErrorNum.SEND_OK)
                {
                    EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "锁标签" + "命令发送" + "成功", null);
                }
                else
                {
                    EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "锁标签" + "命令发送" + "失败", null);
                }
            }
        }

        private int _lock_mask_1()
        {
            int tmp_mask = 0;
            int tmp_action = 0;
            int Shdata = 0;
            ushort tmp = 0x3;

            CheckBox[] array_bank = { checkBox_user, checkBox_tid, checkBox_epc, checkBox_access, checkBox_kill };
            RadioButton[] array_action = { radioButton_rw_unable_forever, radioButton_rw_able_forever, radioButton_rw_unable, radioButton_rw_able };

            for (int index = 0; index < array_bank.Length; index++)
            {
                if (array_bank[index].Checked == true)
                {
                    tmp_mask += (tmp << (index * 2));

                    for (int j = 0; j < array_action.Length; j++)
                    {
                        if (array_action[j].Checked == true)
                        {
                            tmp_action += (j << (index * 2));
                        }
                    }
                }
            }

            Shdata = tmp_action + (tmp_mask << 10);

            return Shdata;
        }

        /// <summary>
        /// 字符串转16进制字节数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        private static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }


        public void UpdateViewReadTag(string[] subreaddate, string databasesource, bool isCommandDataBaseWork, string type)
        {
            try
            {
                if (subreaddate[2] == ErrorNum.success)
                {
                    if (checkBox2.Checked == false)
                    {
                        textBox_data.Text = subreaddate[3];
                    }
                    else
                    {
                        byte[] byt_hex = strToToHexByte(subreaddate[3]);
                        string str_ascii = System.Text.Encoding.Default.GetString(byt_hex);
                        textBox_data.Text = str_ascii;
                    }

                    if (comboBox_mb.Text == "EPC")
                    {
                        textBox1.Text = subreaddate[3];
                    }

                    sd.UpdateLog("读取标签成功");
                    /*   if (isCommandDataBaseWork)
                       {
                           string[] str_ret = new string[Types.MAX_DATABASE_LEN];
                           str_ret[0] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                           subreaddate.CopyTo(str_ret, 1);
                           DatabBaseHelp.InsertSingleData(databasesource, "Command", str_ret);
                       }*/
                    if ((subreaddate[3].Substring(subreaddate[3].Length - 2, 2) == "FF" || subreaddate[3].Substring(subreaddate[3].Length - 2, 2) == "EE") && subreaddate[3].Substring(0, 2) == "AA")
                    {
                        if (subreaddate[3].Length == 24)
                        {
                            humidityTB.Text = strConvertTemperature(subreaddate[3].Substring(4, 8));
                            TagUserTemTB.Text = strConvertTemperature(subreaddate[3].Substring(12, 8));
                        }
                        else if (subreaddate[3].Length == 20)
                        {
                            TagACC_XTB.Text = ConvertStr(subreaddate[3].Substring(6, 2) + subreaddate[3].Substring(4, 2));
                            TagACC_YTB.Text = ConvertStr(subreaddate[3].Substring(10,2) + subreaddate[3].Substring(8, 2));
                            TagACC_ZTB.Text = ConvertStr(subreaddate[3].Substring(14, 2) + subreaddate[3].Substring(12, 2));
                        }
                        else if (subreaddate[3].Length == 16)
                        {
                            TagUserTemTB.Text = strConvertTemperature(subreaddate[3].Substring(12, 8));
                        }
                    }

                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "读标签" + "数据接收" + "成功", null);
                    }
                }
                else
                {
                    sd.UpdateLog("读取标签失败");
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "读标签" + "数据接收" + "失败", null);
                    }
                }
                if (SrDemo.WorkState == "特殊标签工作状态")
                {
                    if (isMultiEPCReadTagStart)
                    {
                        int delayCircle = int.Parse(CycleTimeTb.Text);
                        sd.ReaderControllor.StartMultiEPC(WorkingReader);
                        Thread.Sleep(delayCircle);
                        sd.ReaderControllor.StopMultiEPC(WorkingReader);
                    }
                    if (isCarrierReadTagStart)
                    {
                        ThreadPool.QueueUserWorkItem(state =>
                        {
                            //sd.ReaderControllor.UpdateFirst(WorkingReader);
                            //SrDemo.SetCarrierOn = true;
                            //int delayCarrier = int.Parse(CycleTimeTb.Text);
                            //sd.ReaderControllor.UpdateEnd(WorkingReader, delayCarrier);
                            //SrDemo.SetCarrierOn = false;

                            sd.ReaderControllor.GetCarrier(WorkingReader);
                            Thread.Sleep(100);
                            sd.ReaderControllor.SetCarrier(WorkingReader, 0x01);
                            SrDemo.SetCarrierOn = true;
                            int delayCarrier = int.Parse(CycleTimeTb.Text);
                            Thread.Sleep(delayCarrier);
                            sd.ReaderControllor.GetCarrier(WorkingReader);
                            Thread.Sleep(100);
                            sd.ReaderControllor.SetCarrier(WorkingReader, 0x00);
                            SrDemo.SetCarrierOn = false;
                        }, null);
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



        public byte[] StrToHexByte(string hexString)
        {
            if (hexString != null)
            {
                hexString = hexString.Replace("\0", "");
                if ((hexString.Length % 2) != 0)
                    hexString += " ";
                byte[] returnBytes = new byte[hexString.Length / 2];
                try
                {
                    for (int i = 0; i < returnBytes.Length; i++)
                        returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
                }
                catch
                {

                }
                return returnBytes;
            }
            else
            {
                byte[] result = new byte[0];
                return result;
            }
        }

        private string strConvertTemperature(string source)
        {
            byte[] x = StrToHexByte(source);
            byte sign = (byte)(x[3] >> 7);
            int index = (int)(Math.Pow(2, (byte)((x[3] << 1) + (x[2] >> 7) - 127)));
            double temperature = (sign == 0 ? index : ~index + 1) * (1.0 + GetDecimal(x));
            return temperature.ToString();
        }

        private double GetDecimal(byte[] x)
        {
            double point = 0x00;
            for (int index = 0; index < 6; index++)
            {
                point += ((x[2] >> (6 - index)) & 0x01) * Math.Pow(2, (index + 1) * -1);
            }
            for (int i = 0; i < 7; i++)
            {
                point += ((x[1] >> (7 - i)) & 0x01) * Math.Pow(2, (i + 7) * -1);
            }
            return point;
        }

        private string ConvertStr(string source)
        {
            byte[] x = StrToHexByte(source);
            short ux = (short)((x[0] << 8) + x[1]);
            ux = (short)((ux >= 0) ? ux : (~ux + 0x01) * -1);
            return ux.ToString();
        }

        public void UpdateViewWriteTag(string[] subreaddate, string databasesource, bool isCommandDataBaseWork, string type)
        {
            try
            {
                int offset = 2;
                if (subreaddate[offset + 0] == ErrorNum.success)
                {
                    sd.UpdateLog("写标成功");
                   // textBox1.Text = writedata;
                    /*  if (isCommandDataBaseWork)
                      {
                          string[] str_ret = new string[Types.MAX_DATABASE_LEN];
                          str_ret[0] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                          str_ret[1] = subreaddate[0];
                          str_ret[2] = wtc.type;
                          str_ret[3] = "1";
                          str_ret[4] = wtc.data;
                          DatabBaseHelp.InsertSingleData(databasesource, "Command", str_ret);
                      }*/
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "写标签" + "数据接收" + "成功", null);
                    }
                }
                else
                {
                    sd.UpdateLog("写标失败");
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "写标签" + "数据接收" + "失败", null);
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

        public void UpdateViewKLockTag(string[] subreaddate, string type)
        {
            try
            {
                int offset = 2;
                if (subreaddate[offset + 0] == ErrorNum.success)
                {
                    sd.UpdateLog("锁定成功");
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "锁标签" + "数据接收" + "成功", null);
                    }
                }
                else
                {
                    sd.UpdateLog("锁定失败");
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "锁标签" + "数据接收" + "失败", null);
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

        public void UpdateViewKillTag(string[] subreaddate, string type)
        {
            int offset = 2;
            try
            {
                if (subreaddate[offset + 0] == ErrorNum.success)
                {
                    sd.UpdateLog("销毁成功");
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "销毁标签" + "数据接收" + "成功", null);
                    }
                }
                else
                {
                    sd.UpdateLog("销毁失败");
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "销毁标签" + "数据接收" + "失败", null);
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

        private bool isMultiEPCReadTagStart = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (StartSensonoOneBt.Text == "传感器开始1")
            {
                /*   try
                   {
                       StartSensonoOneBt.Text = "传感器停止1";
                       sd.ReaderControllor.SatrtMultiEPC();
                       int delay = int.Parse(delayTB.Text);
                       int delayCircle = int.Parse(CycleTimeTb.Text);
                       int Interval = int.Parse(CommandInterval.Text);
                       Thread.Sleep(delay);
                       sd.ReaderControllor.StopMultiEPC();                   
                       Thread.Sleep(delayCircle);                    
                       isReadTagStart = true;
                       ThreadPool.QueueUserWorkItem(state =>
                           {
                               while (isReadTagStart)
                               {
                                   this.button_data_read_Click(null, null);
                                   Thread.Sleep(Interval); 
                                   sd.ReaderControllor.SatrtMultiEPC();
                                   Thread.Sleep(delayCircle);
                                   sd.ReaderControllor.StopMultiEPC();
                                   Thread.Sleep(Interval); 
                               }

                           }, null);
                   }
                   catch
                   {
                       sd.UpdateLog("操作步骤有误");
                   }*/
                isMultiEPCReadTagStart = true; ;
                StartSensonoOneBt.Text = "传感器停止1";
                sd.ReaderControllor.StartMultiEPC(WorkingReader);
                int delay = int.Parse(delayTB.Text);
                Thread.Sleep(delay);
                sd.ReaderControllor.StopMultiEPC(WorkingReader);
            }
            else
            {
                isMultiEPCReadTagStart = false;
                StartSensonoOneBt.Text = "传感器开始1";
            }
        }


        private bool isCarrierReadTagStart = false;
        private void button2_Click(object sender, EventArgs e)
        {
            if (StartSensonoTwoBt.Text == "传感器开始2")
            {
                /*   try
                   {
                       StartSensonoOneBt.Text = "传感器停止2";
                       sd.ReaderControllor.SetCarrier(WorkingReader,0x01);
                       int delay = int.Parse(delayTB.Text);
                       int delayCircle = int.Parse(CycleTimeTb.Text);
                       int Interval = int.Parse(CommandInterval.Text);
                       Thread.Sleep(delay);
                       sd.ReaderControllor.SetCarrier(WorkingReader, 0x00);
                       isReadTagStart = true;
                       ThreadPool.QueueUserWorkItem(state =>
                       {
                           while (isReadTagStart)
                           {
                               this.button_data_read_Click(null, null);
                               Thread.Sleep(Interval); 
                               sd.ReaderControllor.SetCarrier(WorkingReader, 0x01);
                               Thread.Sleep(delayCircle);
                               sd.ReaderControllor.SetCarrier(WorkingReader, 0x00);
                               Thread.Sleep(Interval); 
                           }

                   }
                       }, null);
                   catch
                   {
                       sd.UpdateLog("操作步骤有误");
                   }*/
                ThreadPool.QueueUserWorkItem(state =>
               {
                   //isCarrierReadTagStart = true;
                   //StartSensonoTwoBt.Text = "传感器停止2";
                   //int delay = int.Parse(delayTB.Text);

                   //sd.ReaderControllor.C2First(WorkingReader);
                   //SrDemo.SetCarrierOn = true;
                   //sd.ReaderControllor.C2End(WorkingReader, delay);
                   //SrDemo.SetCarrierOn = false;
                    isCarrierReadTagStart = true;
                    StartSensonoTwoBt.Text = "传感器停止2";
                    sd.ReaderControllor.GetCarrier(WorkingReader);
                    Thread.Sleep(100);
                    sd.ReaderControllor.SetCarrier(WorkingReader, (byte)0x01);
                    SrDemo.SetCarrierOn = true;
                    int delay = int.Parse(delayTB.Text);
                    Thread.Sleep(delay);
                    sd.ReaderControllor.GetCarrier(WorkingReader);
                    Thread.Sleep(100);
                    sd.ReaderControllor.SetCarrier(WorkingReader, (byte)0x00);
                    SrDemo.SetCarrierOn = false;
                }, null);
            }
            else
            {
                isCarrierReadTagStart = false;
                StartSensonoTwoBt.Text = "传感器开始2";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (NormalStateBt.Checked == true)
            {
                SrDemo.WorkState = "正常状态";
            }
            else
            {
                SrDemo.WorkState = "特殊标签工作状态";
            }
        }

 

        int success = 0;
        int fail = 0;
        ulong hi;
        uint lo;
        public string writedata = "";
        private void button2_Click_1(object sender, EventArgs e)
        {

            writedata = textBox1.Text;
            string DiZeng = textBox2.Text;

            int Tag_DZ = int.Parse(DiZeng);

            writedata = writedata.Replace(" ", "");

            ulong h = 0;
            uint l = 0;
            if (writedata.Length <= 8) uint.TryParse(writedata, NumberStyles.HexNumber, null, out l);
            else
            {
                ulong.TryParse(writedata.Substring(0, writedata.Length - 8), NumberStyles.HexNumber, null, out h);
                uint.TryParse(writedata.Substring(writedata.Length - 8, 8), NumberStyles.HexNumber, null, out l);
            }
            UInt96 a = new UInt96(h, l);//将输入的EPC号原封不动的转化为 UInt96类型


            UInt96 b = a.Inc(Tag_DZ);  

            writedata = a.ToString();

            writedata = writedata.Replace(" ", "");

            string result = sd.ReaderControllor.WriteTags(WorkingReader, "00000000", 0x00, "", 0x01, 0x02, 0x06, writedata);

            if (result == "0")
            {
                success++;

                writedata = b.ToString();

                textBox1.Text = writedata;
            }
            else
            {
                fail++;
            }

           
      
        }






         
     //------------------------------------------------------------------------------------------

    }
}
