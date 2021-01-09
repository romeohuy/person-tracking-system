using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace SrDemo
{
    public partial class AppConfig : Form
    {
        public AppConfig()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string databaseiswork = "yes";
            if (RadioButtonRfidDataBaseIsWork.Checked == true)
            {
                databaseiswork = "yes";
            }
            else
            {
                databaseiswork = "no";
            }
            cfa.AppSettings.Settings["IsRfidDataBaseWork"].Value = databaseiswork;
            cfa.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string databaseiswork = "yes";
            if (RadioButtonDataBaseIsWork.Checked == true)
            {
                databaseiswork = "yes";
            }
            else
            {
                databaseiswork = "no";
            }
            cfa.AppSettings.Settings["IsAvtiveDataBaseWork"].Value = databaseiswork;
            cfa.Save();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string databaseiswork = "yes";
            if (RadioButtonDataBaseIsWork.Checked == true)
            {
                databaseiswork = "yes";
            }
            else
            {
                databaseiswork = "no";
            }
            cfa.AppSettings.Settings["IsCommandDataBaseWork"].Value = databaseiswork;
            cfa.Save();
        }
    }
}
