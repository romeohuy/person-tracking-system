using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Configuration;
using System.Xml;
using System.Windows.Forms;
using System.Configuration;
using SrDemo.Log;

namespace SrDemo
{
    public partial class DataBaseSetting : Form
    {
        public bool result = false;
        public string  path = "";
        private SrDemo sd;
        public DataBaseSetting(SrDemo sd)
        {
            InitializeComponent();
            InitDataBaseConnect();                     
            this.sd = sd;
        }

        public DataBaseSetting()
        {
            InitializeComponent();
        }
        /// <summary>
        ///更新数据库配置信息
        /// </summary>
        private void InitDataBaseConnect()
        {
            if (ConfigurationManager.AppSettings["database"] != "null")               //获取数据显示时间间隔
            {
                string datasource = ConfigurationManager.AppSettings["database"];
                string[] ds = datasource.Split(';');
                string[] dsItems = new string[ds.Length];
                int index = 0;
                foreach (string dsItem in ds)
                {
                    dsItems[index] = dsItem.Split('=')[1];
                    index++;
                }
                try
                {
                    data_server_tb.Text = dsItems[0];
                    data_name_tb.Text = dsItems[1];
                    data_user_tb.Text = dsItems[2];
                    data_PWD_tb.Text = dsItems[3];
                }
                catch(Exception ex)
                {

                }
            }
        }

        private void button22_Click(object sender, EventArgs e)       //为数据存贮建立对应的数据库
        {
            try
            {
                string server = data_server_tb.Text;
                string database = data_name_tb.Text;
                string usr = data_user_tb.Text;
                string pwd = data_PWD_tb.Text;

                    MessageBox.Show("数据库信息配置成功");
                    Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    path = "Server =" + server + ";" + "Database = " + database + ";" + "User ID=" + usr + ";" + "Password =" + pwd;
                    cfa.AppSettings.Settings["database"].Value = path;
                    cfa.Save();
                    result = true;
                    if (checkBoxCreatTables.Checked == true)
                    {
                        sd.CreatTables();
                    }
            }
            catch(Exception ex)
            {
                ErrorLog.WriteError(ex.ToString());
                throw ex;
            }
        }
    }
}
