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
    public partial class PassThroughData : CustomControl
    {
        public PassThroughData(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }
        public PassThroughData()
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //端口选择
                byte port = 0x00;
                if (comboBox1.SelectedIndex == 0)//指纹端口
                {
                    port = 0x01;
                    byte[] byt_hex = strToToHexByte(textBox1.Text);
                    string result = sd.ReaderControllor.Send_ThroughData(WorkingReader, port, byt_hex);
                }
                else if (comboBox1.SelectedIndex == 1)//NFC端口
                {
                    port = 0x04;
                    byte[] byt_hex = strToToHexByte(textBox1.Text);
                    string result = sd.ReaderControllor.Send_ThroughData(WorkingReader, port, byt_hex);
                }
                else if (comboBox1.SelectedIndex == 2)//GPIO控制
                {
                    port = 0x10;
                    //GPIO口选择
                    byte gpio_num = 0x00;
                    gpio_num = (byte)(comboBox2.SelectedIndex);
                    //开始状态
                    byte start_state = 0x00;
                    start_state = (byte)(comboBox3.SelectedIndex);
                    //结束状态comboBox4
                    byte end_state = 0x00;
                    end_state = (byte)(comboBox4.SelectedIndex);
                    //次数
                    byte num = 0x00;
                    int int_num = int.Parse(textBox2.Text);
                    num = (byte)(int_num);
                    //开始状态保持时间
                    byte[] start_keeptime = new byte[2];
                    int int_time = int.Parse(textBox3.Text);
                    byte[] intBuff = intToBytes(int_time);
                    start_keeptime[0] = intBuff[1];
                    start_keeptime[1] = intBuff[0];
                    //结束状态保持时间
                    byte[] end_keeptime = new byte[2];
                    if (int_num != 1)
                    {
                        int int_endtime = int.Parse(textBox4.Text);
                        byte[] intBuff_end = intToBytes(int_endtime);
                        end_keeptime[0] = intBuff_end[1];
                        end_keeptime[1] = intBuff_end[0];
                    }
                    else
                    {
                        end_keeptime[0] = 0x00;
                        end_keeptime[1] = 0x00;
                    }
                    string result = sd.ReaderControllor.Send_ThroughData(WorkingReader, port, gpio_num, start_state, end_state, num, start_keeptime, end_keeptime);
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
        /// int转byte
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] intToBytes(int value)
        {
            byte[] src = new byte[4];
            src[3] = (byte)((value >> 24) & 0xFF);
            src[2] = (byte)((value >> 16) & 0xFF);
            src[1] = (byte)((value >> 8) & 0xFF);
            src[0] = (byte)(value & 0xFF);
            return src;
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //主板是否复位
                byte Main_Board = 0x00;
                Main_Board = (byte)(comboBox5.SelectedIndex);
                //  指纹设备/UART1设备是否复位
                byte uart1 = 0x00;
                if (comboBox6.SelectedIndex == 0)
                {
                    uart1 = 0x01;
                }
                //  RFID/UART4设备是否复位
                byte uart4 = 0x00;
                if (comboBox7.SelectedIndex == 0)
                {
                    uart4 = 0x4;
                }
                //复位时间
                byte[] time = new byte[2];
                int int_time = int.Parse(textBox5.Text);
                byte[] intBuff = intToBytes(int_time);
                time[0] = intBuff[1];
                time[1] = intBuff[0];
              //  string result = sd.ReaderControllor.ResetDev(WorkingReader, Main_Board, uart1, uart4,time);
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

        //===============================================================================
    }
}
