using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;

namespace SrDemo.Config
{
    public partial class Heart : CustomControl
    {
        public Heart()
        {
            
        }

        public Heart(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }

        public void LanguagedChanged()
        {
            ResourceManager rm = new ResourceManager(typeof(SrDemo));
            radioButton1.Text = rm.GetString("Open");
            radioButton2.Text = rm.GetString("Close");
            button1.Text = rm.GetString("Get");
            button2.Text = rm.GetString("Set");
            //groupBox5.Text = rm.GetString("BasicConfig");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool state = sd.ReaderControllor.cmd.HEART_STATE;
            if (state == true)
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                sd.ReaderControllor.cmd.HEART_STATE = true;
            }
            else if (radioButton2.Checked == true)
            {
                sd.ReaderControllor.cmd.HEART_STATE = false;
            }
        }
    }
}
