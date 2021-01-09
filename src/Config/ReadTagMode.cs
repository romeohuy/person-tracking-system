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
    public partial class ReadTagMode : CustomControl
    {
        public ReadTagMode()
        {
            InitializeComponent();
        }

        public ReadTagMode(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }

        public void LanguagedChanged()
        {
             ResourceManager rm = new ResourceManager(typeof(SrDemo));
             groupBox1.Text = rm.GetString("ReadTagMode");
             radioButton1.Text = rm.GetString("AtFullSpeed");
             radioButton2.Text = rm.GetString("Equilibrium");
             button1.Text = rm.GetString("Set");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                string result = sd.ReaderControllor.SetReadTagMode(WorkingReader, 0xA5);
            }
            else
            {
                string result = sd.ReaderControllor.SetReadTagMode(WorkingReader, 0xA8);
            }
        }
    }
}
