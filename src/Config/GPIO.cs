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
    public partial class GPIO : CustomControl
    {
        public GPIO()
        {
            InitializeComponent();
        }

        public GPIO(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }

        private void button_gpio_get_Click(object sender, EventArgs e)
        {
            try
            {
                byte selectGpio = 0x00;
                if (gpio1_cb.Checked == true)
                {
                    selectGpio |= 0x01;
                }
                if (gpio2_cb.Checked == true)
                {
                    selectGpio |= 0x02;
                }
                if (gpio3_cb.Checked == true)
                {
                    selectGpio |= 0x04;
                }
                if (gpio4_cb.Checked == true)
                {
                    selectGpio |= 0x08;
                }
                string result = sd.ReaderControllor.GetGpio(WorkingReader, selectGpio);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "GPIO配置" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "GPIO配置" + "命令发送" + "失败", null);
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
            groupBox_gpio.Text = rm.GetString("Configure_Gpio_In_Out");
            gpio1_cb.Text = "GPIO1" + " " + rm.GetString("Configure_Gpio_Out");
            radioButton_gpio1_high.Text = rm.GetString("Configure_Gpio_High");
            radioButton_gpio1_low.Text = rm.GetString("Configure_Gpio_Low");
            gpio2_cb.Text = "GPIO2" + " " + rm.GetString("Configure_Gpio_Out");
            radioButton_gpio2_high.Text = rm.GetString("Configure_Gpio_High");
            radioButton_gpio2_low.Text = rm.GetString("Configure_Gpio_Low");
            gpio3_cb.Text = "GPIO3" + " " + rm.GetString("Configure_Gpio_Out");
            radioButton_gpio3_high.Text = rm.GetString("Configure_Gpio_High");
            radioButton_gpio3_low.Text = rm.GetString("Configure_Gpio_Low");
            gpio4_cb.Text = "GPIO4" + " " + rm.GetString("Configure_Gpio_Out");
            radioButton_gpio4_high.Text = rm.GetString("Configure_Gpio_High");
            radioButton_gpio4_low.Text = rm.GetString("Configure_Gpio_Low");
            button_gpio_get.Text = rm.GetString("Get");
            button_gpio_set.Text = rm.GetString("Set");
        }


        private void button_gpio_set_Click(object sender, EventArgs e)
        {
            try
            {
                byte gpio = 0;
                byte gpio_state = 0;
                if (gpio1_cb.Checked == true)
                {
                    gpio |= 0x01;
                    if (radioButton_gpio1_high.Checked == true)
                    {
                        gpio_state |= 0x01;
                    }
                    else
                    {
                        gpio_state |= 0x00;
                    }
                }
                if (gpio2_cb.Checked == true)
                {
                    gpio |= 0x02;
                    if (radioButton_gpio2_high.Checked == true)
                    {
                        gpio_state |= 0x02;
                    }
                    else
                    {
                        gpio_state |= 0x00;
                    }
                }
                if (gpio3_cb.Checked == true)
                {
                    gpio |= 0x04;
                    if (radioButton_gpio3_high.Checked == true)
                    {
                        gpio_state |= 0x04;
                    }
                    else
                    {
                        gpio_state |= 0x00;
                    }
                }
                if (gpio4_cb.Checked == true)
                {
                    gpio |= 0x08;
                    if (radioButton_gpio4_high.Checked == true)
                    {
                        gpio_state |= 0x08;
                    }
                    else
                    {
                        gpio_state |= 0x00;
                    }
                }
                string result = sd.ReaderControllor.SetGpio(WorkingReader, gpio, gpio_state);
                if (SrDemo.isLogOpen)
                {
                    if (result == ErrorNum.SEND_OK)
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "GPIO配置" + "命令发送" + "成功", null);
                    }
                    else
                    {
                        EventLog.WriteEvent("设置读写器" + WorkingReader.dev + "GPIO配置" + "命令发送" + "失败", null);
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
                    byte[] by_gpio = { byte.Parse(subinfo[3]), byte.Parse(subinfo[4]) };
                    if ((by_gpio[0] & 0x01) != 0x00)
                    {
                        if ((by_gpio[1] & 0x01) != 0x00)
                        {
                            radioButton_gpio1_high.Checked = true;
                            radioButton_gpio1_low.Checked = false;
                        }
                        else
                        {
                            radioButton_gpio1_high.Checked = false;
                            radioButton_gpio1_low.Checked = true;
                        }
                    }
                    if ((by_gpio[0] & 0x02) != 0x00)
                    {
                        if ((by_gpio[1] & 0x02) != 0x00)
                        {
                            radioButton_gpio2_high.Checked = true;
                            radioButton_gpio2_low.Checked = false;
                        }
                        else
                        {
                            radioButton_gpio2_high.Checked = false;
                            radioButton_gpio2_low.Checked = true;
                        }
                    }
                    if ((by_gpio[0] & 0x04) != 0x00)
                    {
                        if ((by_gpio[1] & 0x04) != 0x00)
                        {
                            radioButton_gpio3_high.Checked = true;
                            radioButton_gpio3_low.Checked = false;
                        }
                        else
                        {
                            radioButton_gpio3_high.Checked = false;
                            radioButton_gpio3_low.Checked = true;
                        }
                    }
                    if ((by_gpio[0] & 0x08) != 0x00)
                    {
                        if ((by_gpio[1] & 0x08) != 0x00)
                        {
                            radioButton_gpio4_high.Checked = true;
                            radioButton_gpio4_low.Checked = false;
                        }
                        else
                        {
                            radioButton_gpio4_high.Checked = false;
                            radioButton_gpio4_low.Checked = true;
                        }
                    }

                    sd.UpdateLog(GetToString() + type + OkToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "GPIO配置" + "数据接收" + "成功", null);
                    }
                }
                else
                {
                    sd.UpdateLog(GetToString() + type + FailedToString());
                    if (SrDemo.isLogOpen)
                    {
                        EventLog.WriteEvent("获取读写器" + WorkingReader.dev + "GPIO配置" + "数据接收" + "失败", null);
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
