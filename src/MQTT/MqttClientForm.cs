using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SrDemo.MQTT
{
    public partial class MqttClientForm : Form
    {
        MqttOperation client = new MqttOperation();
        public MqttClientForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TextBoxPublishMsg.Text != "")
            {
                client.clien_MqttMsgPublic(TextBoxPublishMsg.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
