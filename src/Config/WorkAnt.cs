using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetFrame.Net.TCP.Sock.Asynchronous;
using System.Threading;
using System.Resources;
using SrDemo.Log;



namespace SrDemo.Config
{
    public partial class WorkAnt : CustomControl
    {

        CheckBox[] CheckBoxAggregate = new CheckBox[64];
        public WorkAnt()
        {
            InitializeComponent();
        }

        public WorkAnt(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
            InitWorkAntConfig();
        }

        private void InitWorkAntConfig()
        {
            CheckBoxAggregate[0] = CheckAnt1; CheckBoxAggregate[1] = CheckAnt2; CheckBoxAggregate[2] = CheckAnt3;
            CheckBoxAggregate[3] = CheckAnt4; CheckBoxAggregate[4] = CheckAnt5; CheckBoxAggregate[5] = CheckAnt6;
            CheckBoxAggregate[6] = CheckAnt7; CheckBoxAggregate[7] = CheckAnt8; CheckBoxAggregate[8] = CheckAnt9;
            CheckBoxAggregate[9] = CheckAnt10; CheckBoxAggregate[10] = CheckAnt11; CheckBoxAggregate[11] = CheckAnt12;
            CheckBoxAggregate[12] = CheckAnt13; CheckBoxAggregate[13] = CheckAnt14; CheckBoxAggregate[14] = CheckAnt15;
            CheckBoxAggregate[15] = CheckAnt16; CheckBoxAggregate[16] = CheckAnt17; CheckBoxAggregate[17] = CheckAnt18;
            CheckBoxAggregate[18] = CheckAnt19; CheckBoxAggregate[19] = CheckAnt20; CheckBoxAggregate[20] = CheckAnt21;
            CheckBoxAggregate[21] = CheckAnt22; CheckBoxAggregate[22] = CheckAnt23; CheckBoxAggregate[23] = CheckAnt24;
            CheckBoxAggregate[24] = CheckAnt25; CheckBoxAggregate[25] = CheckAnt26; CheckBoxAggregate[26] = CheckAnt27;
            CheckBoxAggregate[27] = CheckAnt28; CheckBoxAggregate[28] = CheckAnt29; CheckBoxAggregate[29] = CheckAnt30;
            CheckBoxAggregate[30] = CheckAnt31; CheckBoxAggregate[31] = CheckAnt32; CheckBoxAggregate[32] = CheckAnt33;
            CheckBoxAggregate[33] = CheckAnt34; CheckBoxAggregate[34] = CheckAnt35; CheckBoxAggregate[35] = CheckAnt36;
            CheckBoxAggregate[36] = CheckAnt37; CheckBoxAggregate[37] = CheckAnt38; CheckBoxAggregate[38] = CheckAnt39;
            CheckBoxAggregate[39] = CheckAnt40; CheckBoxAggregate[40] = CheckAnt41; CheckBoxAggregate[41] = CheckAnt42;
            CheckBoxAggregate[42] = CheckAnt43; CheckBoxAggregate[43] = CheckAnt44; CheckBoxAggregate[44] = CheckAnt45;
            CheckBoxAggregate[45] = CheckAnt46; CheckBoxAggregate[46] = CheckAnt47; CheckBoxAggregate[47] = CheckAnt48;
            CheckBoxAggregate[48] = CheckAnt49; CheckBoxAggregate[49] = CheckAnt50; CheckBoxAggregate[50] = CheckAnt51;
            CheckBoxAggregate[51] = CheckAnt52; CheckBoxAggregate[52] = CheckAnt53; CheckBoxAggregate[53] = CheckAnt54;
            CheckBoxAggregate[54] = CheckAnt55; CheckBoxAggregate[55] = CheckAnt56; CheckBoxAggregate[56] = CheckAnt57;
            CheckBoxAggregate[57] = CheckAnt58; CheckBoxAggregate[58] = CheckAnt59; CheckBoxAggregate[59] = CheckAnt60;
            CheckBoxAggregate[60] = CheckAnt61; CheckBoxAggregate[61] = CheckAnt62; CheckBoxAggregate[62] = CheckAnt63;
            CheckBoxAggregate[63] = CheckAnt64;
        }

        private void button_set_ant_Click(object sender, EventArgs e)
        {
            try
            {
                byte workant = 0;
                if (checkBox_ant1.Checked == true)
                {
                    workant |= 0x01;
                }
                if (checkBox_ant2.Checked == true)
                {
                    workant |= 0x02;
                }
                if (checkBox_ant3.Checked == true)
                {
                    workant |= 0x04;
                }
                if (checkBox_ant4.Checked == true)
                {
                    workant |= 0x08;
                }
                sd.ReaderControllor.SetWorkAnt(WorkingReader, workant);
                Thread.Sleep(500);
                ushort worktime1 = ushort.Parse(textBox_ant1_worktime.Text);
                ushort worktime2 = ushort.Parse(textBox_ant2_worktime.Text);
                ushort worktime3 = ushort.Parse(textBox_ant3_worktime.Text);
                ushort worktime4 = ushort.Parse(textBox_ant4_worktime.Text);
                ushort waittime = ushort.Parse(textBox_waittime.Text);
                string result = sd.ReaderControllor.SetWorkTime(WorkingReader, worktime1, worktime2, worktime3, worktime4, waittime);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("设置4通道读写器" + WorkingReader.dev + "工作天线" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("设置4通道读写器" + WorkingReader.dev + "工作天线" + "命令发送" + "成功", null);
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

        private void Get_ant_mes_Click(object sender, EventArgs e)
        {
            try
            {
                string result = sd.ReaderControllor.GetWorkAnt(WorkingReader);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("获取四通道读写器" + WorkingReader.dev + "工作天线" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("获取四通道读写器" + WorkingReader.dev + "工作天线" + "命令发送" + "失败", null);
                    }
                }
                Thread.Sleep(500);
                result = sd.ReaderControllor.GetWorkTime(WorkingReader);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("获取四通道读写器" + WorkingReader.dev + "工作天线时间间隔" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("获取四通道读写器" + WorkingReader.dev + "工作天线时间间隔" + "命令发送" + "失败", null);
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

        public void UpdateViewAnt(string[] subinfo,string type)
        {
            int offset = 3;
            try
            {
                if (subinfo[2] == ErrorNum.success)
                {
                    int check = 0;
                    byte b_ant = byte.Parse(subinfo[offset + 1]);
                    check = b_ant & 0x01;
                    if (check != 0)
                    {
                        checkBox_ant1.Checked = true;
                    }
                    else
                    {
                        checkBox_ant1.Checked = false;
                    }
                    check = b_ant & 0x02;
                    if (check != 0)
                    {
                        checkBox_ant2.Checked = true;
                    }
                    else
                    {
                        checkBox_ant2.Checked = false;
                    }
                    check = b_ant & 0x04;
                    if (check != 0)
                    {
                        checkBox_ant3.Checked = true;
                    }
                    else
                    {
                        checkBox_ant3.Checked = false;
                    }
                    check = b_ant & 0x08;
                    if (check != 0)
                    {
                        checkBox_ant4.Checked = true;
                    }
                    else
                    {
                        checkBox_ant4.Checked = false;
                    }
                    sd.UpdateLog(GetToString() + type + OkToString());
                    if (SrDemo.isLogOpen)
                    {
                          EventLog.WriteEvent("获取四通道读写器" + WorkingReader.dev + "工作天线" + "数据接收" + "成功", null);
                    }
                }
                else
                {
                    sd.UpdateLog(GetToString() + type + FailedToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取四通道读写器" + WorkingReader.dev + "工作天线" + "数据接收" + "失败", null);
                    }
                }
            }
            catch (Exception ex)
            {
                sd.UpdateLog(ex.ToString());
                ErrorLog.WriteError(ex.ToString());
            }
        }

        public void UpdateViewWorkTime(string[] result,string type)
        {
            try
            {
                if (result[2] == ErrorNum.success)
                {
                    textBox_ant1_worktime.Text = result[3];
                    textBox_ant2_worktime.Text = result[4];
                    textBox_ant3_worktime.Text = result[5];
                    textBox_ant4_worktime.Text = result[6];
                    textBox_waittime.Text = result[7];
                    sd.UpdateLog(GetToString() + type + OkToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取四通道读写器" + WorkingReader.dev + "工作天线时间间隔" + "数据接收" + "成功", null);
                    }
                }
                else
                {
                    sd.UpdateLog(GetToString() + type + FailedToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取四通道读写器" + WorkingReader.dev + "工作天线时间间隔" + "数据接收" + "失败", null);
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

        /// <summary>
        /// 设置单通道读写器天线工作时间和间断时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string result = sd.ReaderControllor.GetSingleChannelAnt(WorkingReader);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("获取单通道读写器" + WorkingReader.dev + "工作天线时间及间隔" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("获取单通道读写器" + WorkingReader.dev + "工作天线时间及间隔" + "命令发送" + "失败", null);
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

        public void UpdateViewWorkInterrupted(string[] result,string type)
        {
            try
            {
                if (result[2] == ErrorNum.success)
                {
                    textBoxSingleWorkTime.Text = result[3];
                    textBoxSingleWaitTime.Text = result[4];
                    sd.UpdateLog(GetToString() + type + OkToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取单通道读写器" + WorkingReader.dev + "工作天线时间及间隔" + "数据接收" + "成功", null);
                    }
                }
                else
                {
                    sd.UpdateLog(GetToString() + type + FailedToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取单通道读写器" + WorkingReader.dev + "工作天线时间及间隔" + "数据接收" + "失败", null);
                    }
                }
            }
            catch (Exception ex)
            {
                sd.UpdateLog(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                ushort worktime = ushort.Parse(textBoxSingleWorkTime.Text);
                ushort waittime = ushort.Parse(textBoxSingleWaitTime.Text);
                string result = sd.ReaderControllor.SetSingleChannelAnt(WorkingReader, worktime, waittime);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("设置单通道读写器" + WorkingReader.dev + "工作天线时间及间隔" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("设置单通道读写器" + WorkingReader.dev + "工作天线时间及间隔" + "命令发送" + "失败", null);
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
            this.button_set_ant.Text = rm.GetString("Set");
            this.Get_ant_mes.Text = rm.GetString("Get");
            this.button3.Text = rm.GetString("Get");
            this.button4.Text = rm.GetString("Set");
            this.button6.Text = rm.GetString("Set");
            this.button5.Text = rm.GetString("Get");
            this.button1.Text = rm.GetString("Set");
            this.button2.Text = rm.GetString("Get");
            this.AllAntCheck1.Text = rm.GetString("All");
            this.AllAntCheck2.Text = rm.GetString("All");
            this.AllAntCheck3.Text = rm.GetString("All");
            this.AllAntCheck4.Text = rm.GetString("All");
            this.AllAntCheck5.Text = rm.GetString("All");
            this.AllAntCheck6.Text = rm.GetString("All");
            this.AllAntCheck7.Text = rm.GetString("All");
            this.AllAntCheck8.Text = rm.GetString("All");
            groupBox16.Text = rm.GetString("FourChannelReader");
            groupBox1.Text = rm.GetString("OneChannelReader");
            groupBox3.Text = rm.GetString("SixteenChannelReader");
            groupBox2.Text = rm.GetString("SixtyfourChannelReader");
            label48.Text = rm.GetString("Configure_WaitTime");
            label1.Text = rm.GetString("worktime") ;
            label2.Text = rm.GetString("Configure_WaitTime");
            checkBoxSave.Text = rm.GetString("Configure_Frequency_Save");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            byte[] AntState = new byte[9];
            try
            {
                for (int index = 0; index < 8; index++)
                {
                    int cube = 0;
                    for (int i = index * 8; i < (index + 1) * 8; i++)
                    {
                        if (CheckBoxAggregate[i].Checked)
                        {
                            AntState[index] |= (byte)Math.Pow(2, cube);
                        }
                        cube++;
                    }
                }
                if (checkBoxSave.Checked == true)
                {
                    AntState[8] = 0x01;
                }
                else
                {
                    AntState[8] = 0x00;
                }
                sd.ReaderControllor.SetBranchAnt(WorkingReader, AntState);
            }
            catch (Exception ex)
            {
                sd.UpdateLog(ex.ToString());
            }

            /*   try 
               {
                   ushort AntCheck = 0x0000;
                   if (CheckAnt1.Checked == true)
                   {
                       AntCheck |= 0x0100;
                   }
                   if (CheckAnt2.Checked == true)
                   {
                       AntCheck |= 0x0200;
                   }
                   if (CheckAnt3.Checked == true)
                   {
                       AntCheck |= 0x0400;
                   }
                   if (CheckAnt4.Checked == true)
                   {
                       AntCheck |= 0x0800;
                   }
                   if (CheckAnt5.Checked == true)
                   {
                       AntCheck |= 0x1000;
                   }
                   if (CheckAnt6.Checked == true)
                   {
                       AntCheck |= 0x2000;
                   }
                   if (CheckAnt7.Checked == true)
                   {
                       AntCheck |= 0x4000;
                   }
                   if (CheckAnt8.Checked == true)
                   {
                       AntCheck |= 0x8000;
                   }
                   if (CheckAnt9.Checked == true)
                   {
                       AntCheck |= 0x0001;
                   }
                   if (CheckAnt12.Checked == true)
                   {
                       AntCheck |= 0x0002;
                   }
                   if (CheckAnt10.Checked == true)
                   {
                       AntCheck |= 0x0004;
                   }
                   if (CheckAnt13.Checked == true)
                   {
                       AntCheck |= 0x0008;
                   }
                   if (CheckAnt15.Checked == true)
                   {
                       AntCheck |= 0x0010;
                   }
                   if (CheckAnt11.Checked == true)
                   {
                       AntCheck |= 0x0020;
                   }
                   if (CheckAnt14.Checked == true)
                   {
                       AntCheck |= 0x0040;
                   }
                   if (CheckAnt16.Checked == true)
                   {
                       AntCheck |= 0x0080;
                   }
                   sd.ReaderControllor.SetMultiChannelAnt(WorkingReader, AntCheck);
               }
               catch (Exception ex)
               {
                   sd.UpdateLog(ex.ToString());
               }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string result = sd.ReaderControllor.GetMultiChannelAnt(WorkingReader);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("获取64通道读写器" + WorkingReader.dev + "天线工作状态" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("获取64通道读写器" + WorkingReader.dev + "天线工作状态" + "命令发送" + "失败", null);
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
            int offset = 0x04;

            try
            {
                int antindex = 0;
                for (int index = offset; index < offset + 8; index++)
                {

                    byte antstate = byte.Parse(subinfo[index]);
                    if ((antstate & 0x01) != 0x00)
                    {
                        CheckBoxAggregate[antindex * 8].Checked = true;
                    }
                    else
                    {
                        CheckBoxAggregate[antindex * 8].Checked = false;
                    }
                    if ((antstate & 0x02) != 0x00)
                    {
                        CheckBoxAggregate[antindex * 8 + 1].Checked = true;
                    }
                    else
                    {
                        CheckBoxAggregate[antindex * 8 + 1].Checked = false;
                    }
                    if ((antstate & 0x04) != 0x00)
                    {
                        CheckBoxAggregate[antindex * 8 + 2].Checked = true;
                    }
                    else
                    {
                        CheckBoxAggregate[antindex * 8 + 2].Checked = false;
                    }
                    if ((antstate & 0x08) != 0x00)
                    {
                        CheckBoxAggregate[antindex * 8 + 3].Checked = true;
                    }
                    else
                    {
                        CheckBoxAggregate[antindex * 8 + 3].Checked = false;
                    }
                    if ((antstate & 0x10) != 0x00)
                    {
                        CheckBoxAggregate[antindex * 8 + 4].Checked = true;
                    }
                    else
                    {
                        CheckBoxAggregate[antindex * 8 + 4].Checked = false;
                    }
                    if ((antstate & 0x20) != 0x00)
                    {
                        CheckBoxAggregate[antindex * 8 + 5].Checked = true;
                    }
                    else
                    {
                        CheckBoxAggregate[antindex * 8 + 5].Checked = false;
                    }
                    if ((antstate & 0x40) != 0x00)
                    {
                        CheckBoxAggregate[antindex * 8 + 6].Checked = true;
                    }
                    else
                    {
                        CheckBoxAggregate[antindex * 8 + 6].Checked = false;
                    }
                    if ((antstate & 0x80) != 0x00)
                    {
                        CheckBoxAggregate[antindex * 8 + 7].Checked = true;
                    }
                    else
                    {
                        CheckBoxAggregate[antindex * 8 + 7].Checked = false;
                    }
                    antindex++;
                }
                if (subinfo[offset + 8] == "1")
                {
                    checkBoxSave.Checked = true;
                }
                else
                {
                    checkBoxSave.Checked = false;
                }
                sd.UpdateLog(GetToString() + type + OkToString());
            }
            catch (Exception ex)
            {
                sd.UpdateLog(GetToString() + type + FailedToString());
            }
        }



        private void checkBox65_CheckedChanged(object sender, EventArgs e)
        {
            if (AllAntCheck1.Checked == true)
            {
                for (int index = 0; index < 8; index++)
                {
                    CheckBoxAggregate[index].Checked = true;
                }
            }
            else
            {
                for (int index = 0; index < 8; index++)
                {
                    CheckBoxAggregate[index].Checked = false;
                }
            }
        }

        private void AllAntCheck2_CheckedChanged(object sender, EventArgs e)
        {
            if (AllAntCheck2.Checked == true)
            {
                for (int index = 8; index < 16; index++)
                {
                    CheckBoxAggregate[index].Checked = true;
                }
            }
            else
            {
                for (int index = 8; index < 16; index++)
                {
                    CheckBoxAggregate[index].Checked = false;
                }
            }
        }

        private void AllAntCheck3_CheckedChanged(object sender, EventArgs e)
        {
            if (AllAntCheck3.Checked == true)
            {
                for (int index = 16; index < 24; index++)
                {
                    CheckBoxAggregate[index].Checked = true;
                }
            }
            else
            {
                for (int index = 16; index < 24; index++)
                {
                    CheckBoxAggregate[index].Checked = false;
                }
            }
        }

        private void AllAntCheck4_CheckedChanged(object sender, EventArgs e)
        {
            if (AllAntCheck4.Checked == true)
            {
                for (int index = 24; index < 32; index++)
                {
                    CheckBoxAggregate[index].Checked = true;
                }
            }
            else
            {
                for (int index = 24; index < 32; index++)
                {
                    CheckBoxAggregate[index].Checked = false;
                }
            }
        }

        private void AllAntCheck5_CheckedChanged(object sender, EventArgs e)
        {
            if (AllAntCheck5.Checked == true)
            {
                for (int index = 32; index < 40; index++)
                {
                    CheckBoxAggregate[index].Checked = true;
                }
            }
            else
            {
                for (int index = 32; index < 40; index++)
                {
                    CheckBoxAggregate[index].Checked = false;
                }
            }
        }

        private void AllAntCheck6_CheckedChanged(object sender, EventArgs e)
        {
            if (AllAntCheck6.Checked == true)
            {
                for (int index = 40; index < 48; index++)
                {
                    CheckBoxAggregate[index].Checked = true;
                }
            }
            else
            {
                for (int index = 40; index < 48; index++)
                {
                    CheckBoxAggregate[index].Checked = false;
                }
            }
        }

        private void AllAntCheck7_CheckedChanged(object sender, EventArgs e)
        {
            if (AllAntCheck7.Checked == true)
            {
                for (int index = 48; index < 56; index++)
                {
                    CheckBoxAggregate[index].Checked = true;
                }
            }
            else
            {
                for (int index = 48; index < 56; index++)
                {
                    CheckBoxAggregate[index].Checked = false;
                }
            }
        }

        private void AllAntCheck8_CheckedChanged(object sender, EventArgs e)
        {
            if (AllAntCheck8.Checked == true)
            {
                for (int index = 56; index < 64; index++)
                {
                    CheckBoxAggregate[index].Checked = true;
                }
            }
            else
            {
                for (int index = 56; index < 64; index++)
                {
                    CheckBoxAggregate[index].Checked = false;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string result = sd.ReaderControllor.GetMultiChannelAnt(WorkingReader);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("获取16通道读写器" + WorkingReader.dev + "天线工作状态" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("获取16通道读写器" + WorkingReader.dev + "天线工作状态" + "命令发送" + "失败", null);
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

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                ushort AntCheck = 0x0000;
                if (checkBox1.Checked == true)
                {
                    AntCheck |= 0x0100;
                }
                if (checkBox2.Checked == true)
                {
                    AntCheck |= 0x0200;
                }
                if (checkBox3.Checked == true)
                {
                    AntCheck |= 0x0400;
                }
                if (checkBox4.Checked == true)
                {
                    AntCheck |= 0x0800;
                }
                if (checkBox5.Checked == true)
                {
                    AntCheck |= 0x1000;
                }
                if (checkBox6.Checked == true)
                {
                    AntCheck |= 0x2000;
                }
                if (checkBox7.Checked == true)
                {
                    AntCheck |= 0x4000;
                }
                if (checkBox8.Checked == true)
                {
                    AntCheck |= 0x8000;
                }
                if (checkBox9.Checked == true)
                {
                    AntCheck |= 0x0001;
                }
                if (checkBox10.Checked == true)
                {
                    AntCheck |= 0x0002;
                }
                if (checkBox11.Checked == true)
                {
                    AntCheck |= 0x0004;
                }
                if (checkBox12.Checked == true)
                {
                    AntCheck |= 0x0008;
                }
                if (checkBox13.Checked == true)
                {
                    AntCheck |= 0x0010;
                }
                if (checkBox14.Checked == true)
                {
                    AntCheck |= 0x0020;
                }
                if (checkBox15.Checked == true)
                {
                    AntCheck |= 0x0040;
                }
                if (checkBox16.Checked == true)
                {
                    AntCheck |= 0x0080;
                }
                sd.ReaderControllor.SetMultiChannelAnt(WorkingReader, AntCheck);
            }
            catch (Exception ex)
            {
                sd.UpdateLog(ex.ToString());
            }
        }



        internal void UpdateView16(string[] result, string type)
        {
            int offset = 0x03;
            try
            {
                ushort SelectAntID = ushort.Parse(result[offset + 1]);
                if ((SelectAntID & 0x0100) != 0x00)
                {
                    checkBox1.Checked = true;
                }
                if ((SelectAntID & 0x0200) != 0x00)
                {
                    checkBox2.Checked = true;
                }
                if ((SelectAntID & 0x0400) != 0x00)
                {
                    checkBox3.Checked = true;
                }
                if ((SelectAntID & 0x0800) != 0x00)
                {
                    checkBox4.Checked = true;
                }
                if ((SelectAntID & 0x1000) != 0x00)
                {
                    checkBox5.Checked = true;
                }
                if ((SelectAntID & 0x2000) != 0x00)
                {
                    checkBox6.Checked = true;
                }
                if ((SelectAntID & 0x4000) != 0x00)
                {
                    checkBox7.Checked = true;
                }
                if ((SelectAntID & 0x8000) != 0x00)
                {
                    checkBox8.Checked = true;
                }
                if ((SelectAntID & 0x0001) != 0x00)
                {
                    checkBox9.Checked = true;
                }
                if ((SelectAntID & 0x0002) != 0x00)
                {
                    checkBox10.Checked = true;
                }
                if ((SelectAntID & 0x0004) != 0x00)
                {
                    checkBox11.Checked = true;
                }
                if ((SelectAntID & 0x0008) != 0x00)
                {
                    checkBox12.Checked = true;
                }
                if ((SelectAntID & 0x0010) != 0x00)
                {
                    checkBox13.Checked = true;
                }
                if ((SelectAntID & 0x0020) != 0x00)
                {
                    checkBox14.Checked = true;
                }
                if ((SelectAntID & 0x0040) != 0x00)
                {
                    checkBox15.Checked = true;
                }
                if ((SelectAntID & 0x0080) != 0x00)
                {
                    checkBox16.Checked = true;
                }
                sd.UpdateLog(GetToString()+type+OkToString());
            }
            catch
            {
                sd.UpdateLog(GetToString() + type + FailedToString());
            }
        }
    }
}
