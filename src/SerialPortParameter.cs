using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.IO.Ports;


namespace SrDemo
{
    public partial class SerialPortParameter : Form
    {
        public string PortName = "";              //串口号
        public int BuadRate = 0;   
        public int dataBits = 0;               //数据位
        public Parity parity = 0;             //校验位
        public StopBits stopbits = 0;         //停止位
        public bool result = false;

        public SerialPortParameter()
        {
            InitializeComponent();
            string[] names = SerialPort.GetPortNames();
            foreach (string name in names)
            {
                comboBox1.Items.Add(name);
            }
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 7;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 3;
            comboBox5.SelectedIndex = 1;
        }

        public void LanguagedChanged()
        {
            ResourceManager rm = new ResourceManager(typeof(SrDemo));
            label1.Text = rm.GetString("Serialport");
            label2.Text = rm.GetString("baudrate");
            label3.Text = rm.GetString("check");
            label4.Text = rm.GetString("databits");
            label5.Text = rm.GetString("stopbit");
            button1.Text = rm.GetString("Confirm");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SerialPort_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PortName = comboBox1.Text;
            BuadRate = int.Parse(comboBox2.Text);
            dataBits = int.Parse(comboBox4.Text);
            parity = (Parity)comboBox3.SelectedIndex;
            stopbits = (StopBits)comboBox5.SelectedIndex;
            result = true;
            this.Close();
        }

 
    }
}
