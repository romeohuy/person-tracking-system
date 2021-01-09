using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace SrDemo.ArticleManagement
{
    public partial class ArticleManagementMainForm : Form
    {
        private SrDemo sd;
  //      private SQLInterdace db;
        private filesManagement FileCabinet1 = new filesManagement();
        private filesManagement FileCabinet2 = new filesManagement();
        private filesManagement FileCabinet3 = new filesManagement();
        private filesManagement FileCabinet4 = new filesManagement();

        public ArticleManagementMainForm(SrDemo sd)
        {
            this.sd = sd;

            InitializeComponent();
            InitTotalNumText();

        }

        private void InitTotalNumText()
        {

            if (ConfigurationManager.AppSettings["InventoryTime"] != "null")
            {
                QuencyDataBase_time.Interval = int.Parse(ConfigurationManager.AppSettings["InventoryTime"]);
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button_InvertotyStartStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (button_InvertotyStartStop.Text == "开始")
                {
                    sd.ReaderControllor.StartMultiEPC();
                    QuencyDataBase_time.Enabled = true;
                    //    timer_md_query_Tick.Enabled = true;                    //停止前把剩余数据插入数据库中
                    //     monitor = true;
                    //     show_EPC_t.Enabled = true;
                    button_InvertotyStartStop.Text = "停止";
                    button_InvertotyStartStop.BackColor = Color.LightGreen;
                    sd.UpdateLog("开始盘点物品");
                    //    UpdateLog(databasecount.ToString());
                }
                else if (button_InvertotyStartStop.Text == "停止")
                {
                    sd.ReaderControllor.StopMultiEPC();
                    QuencyDataBase_time.Enabled = false;
                    //       timer_md_query_Tick.Enabled = false;                    //停止前把剩余数据插入数据库中
                    //       monitor = false;
                    //      show_EPC_t.Enabled = false;
                 //   db.InsertMultiData(0);
              //      db.InsertMultiData(1);
                    button_InvertotyStartStop.Text = "开始";
                    button_InvertotyStartStop.BackColor = Color.Gainsboro;
                    sd.UpdateLog("停止盘点物品");
                    //    UpdateLog(databasecount.ToString());
                }
            }
            catch (Exception ex)
            {
                sd.UpdateLog(ex.ToString());
            }
        }

        private string[] GetEpcsFromDataTable(DataTable dataTable)
        {

            DataView dv = dataTable.DefaultView;

            dataTable = dv.ToTable(true, "EPC");

            string[] names = new string[dataTable.Rows.Count];

            for (int i = 0; i < names.Length; i++)
            {

                names[i] = dataTable.Rows[i]["EPC"].ToString();

            }
            return names;

        }


        private bool IncreaseAndDecrease(ref filesManagement FileCabinet)
        {
            FileCabinet.increment = 0;
            FileCabinet.decrement = 0;
            FileCabinet.count = FileCabinet.AntEpcNew.Length;
            bool isexit = false;
            if (FileCabinet.AntEpc == null)
            {
                FileCabinet.AntEpc = new string[FileCabinet.AntEpcNew.Length];
            }
            foreach (string newepc in FileCabinet.AntEpcNew)
            {
                isexit = false;
                foreach (string epc in FileCabinet.AntEpc)
                {
                    if (newepc == epc)
                    {
                        isexit = true;
                        break;
                    }
                }
                if (!isexit)
                {
                    FileCabinet.increment++;
                }
            }
            isexit = false;
            foreach (string epc_a in FileCabinet.AntEpc)
            {
                isexit = false;
                if (epc_a == null)
                {
                    isexit = true;
                    continue;
                }
                foreach (string epc_b in FileCabinet.AntEpcNew)
                {
                    if (epc_a == epc_b)
                    {
                        isexit = true;
                        break;
                    }
                }
                if (!isexit)
                {
                    FileCabinet.decrement++;
                }
            }
            FileCabinet.variation = (FileCabinet.increment - FileCabinet.decrement);
            FileCabinet.AntEpc = new string[FileCabinet.AntEpcNew.Length];
            FileCabinet.AntEpcNew.CopyTo(FileCabinet.AntEpc, 0);
            return true;
        }

        private string starttime = "";
        private string endtime = "";
        private void QuencyDataBase_time_Tick(object sender, EventArgs e)
        {
          endtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            /*   DataTable dt1 = db.SelectValue("1");                                 //方法一
               DataTable dt2 = db.SelectValue("2");
               DataTable dt3 = db.SelectValue("3");
               DataTable dt4 = db.SelectValue("4");*/

          //  DataTable dt1 = db.SelectByMultiContion(starttime, endtime, "1", "Epcs");             //方法二
        //    DataTable dt2 = db.SelectByMultiContion(starttime, endtime, "2", "Epcs");
         //   DataTable dt3 = db.SelectByMultiContion(starttime, endtime, "3", "Epcs");
        //    DataTable dt4 = db.SelectByMultiContion(starttime, endtime, "4", "Epcs");

            starttime = endtime;
            //      if (dt1.Rows.Count != 0)
            //       {
       //     FileCabinet1.AntEpcNew = GetEpcsFromDataTable(dt1);
            if (IncreaseAndDecrease(ref FileCabinet1))
            {
                LabelIncress1.Text = FileCabinet1.increment.ToString();
                Labeldectress1.Text = FileCabinet1.decrement.ToString();
                if (FileCabinet1.count > 0)
                {
                    LabelTotal1.ForeColor = System.Drawing.Color.Green;
                }
                else if (FileCabinet1.count == 0)
                {
                    LabelTotal1.ForeColor = System.Drawing.Color.Yellow;
                }
                else
                {
                    LabelTotal1.ForeColor = System.Drawing.Color.Red;
                }
                LabelTotal1.Text = FileCabinet1.count.ToString();
            }

          //  sd.UpdateLog(FileCabinet1.AntEpcNew.Length.ToString());
            //  }
            //     if (dt2.Rows.Count != 0)
            //    {
          //  FileCabinet2.AntEpcNew = GetEpcsFromDataTable(dt2);
            if (IncreaseAndDecrease(ref FileCabinet2))
            {
                LabelIncress2.Text = FileCabinet2.increment.ToString();
                Labeldectress2.Text = FileCabinet2.decrement.ToString();
                if (FileCabinet2.count > 0)
                {
                    LabelTotal2.ForeColor = System.Drawing.Color.Green;
                }
                else if (FileCabinet2.count == 0)
                {
                    LabelTotal2.ForeColor = System.Drawing.Color.Yellow;
                }
                else
                {
                    LabelTotal2.ForeColor = System.Drawing.Color.Red;
                }
                LabelTotal2.Text = FileCabinet2.count.ToString();
            }
          //  sd.UpdateLog(dt2.Rows.Count.ToString());
            //    }
            //    if (dt3.Rows.Count != 0)
            //    {
         //   FileCabinet3.AntEpcNew = GetEpcsFromDataTable(dt3);
            if (IncreaseAndDecrease(ref FileCabinet3))
            {
                LabelIncress3.Text = FileCabinet3.increment.ToString();
                Labeldectress3.Text = FileCabinet3.decrement.ToString();
                if (FileCabinet3.count > 0)
                {
                    LabelTotal3.ForeColor = System.Drawing.Color.Green;
                }
                else if (FileCabinet3.count == 0)
                {
                    LabelTotal3.ForeColor = System.Drawing.Color.Yellow;
                }
                else
                {
                    LabelTotal3.ForeColor = System.Drawing.Color.Red;
                }
                LabelTotal3.Text = FileCabinet3.count.ToString();
            }
         //   sd.UpdateLog(dt3.Rows.Count.ToString());
            //   }
            //   if (dt4.Rows.Count != 0)
            //    {
        //    FileCabinet4.AntEpcNew = GetEpcsFromDataTable(dt4);
            if (IncreaseAndDecrease(ref FileCabinet4))
            {
                LabelIncress4.Text = FileCabinet4.increment.ToString();
                Labeldectress4.Text = FileCabinet4.decrement.ToString();
                if (FileCabinet4.count > 0)
                {
                    LabelTotal4.ForeColor = System.Drawing.Color.Green;
                }
                else if (FileCabinet4.count == 0)
                {
                    LabelTotal4.ForeColor = System.Drawing.Color.Yellow;
                }
                else
                {
                    LabelTotal4.ForeColor = System.Drawing.Color.Red;
                }
                LabelTotal4.Text = FileCabinet4.count.ToString();
            }
           // UpdateLog(dt4.Rows.Count.ToString());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void ArticleManagementMainForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
