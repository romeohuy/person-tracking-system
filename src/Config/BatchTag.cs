using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SrDemo.Log;
using System.Resources;

namespace SrDemo.Config
{
    public partial class BatchTag : CustomControl
    {
        public BatchTag(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
        }
        public BatchTag()
        {

        }

        public void LanguagedChanged()
        {
            ResourceManager rm = new ResourceManager(typeof(SrDemo));
            label1.Text = rm.GetString("EPCTotalNumber");
            button2.Text = rm.GetString("Access_Read");
            button1.Text = rm.GetString("Access_Write");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            try
            {
                sd.ReaderControllor.ReadBatchTag(WorkingReader);
            }
            catch
            { 
            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string[] striparr = textBox1.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                striparr = striparr.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                for (int i = 0; i < striparr.Length; i++)
                {
                    if (striparr[i].Length > 24)
                    {
                        striparr[i] = striparr[i].Substring(0, 24);
                    }
                    else if (striparr[i].Length < 24)
                    {
                        int bz_len = 24 - striparr[i].Length;
                        string bz_str = "";
                        for (int j = 0; j < bz_len; j++)
                        {
                            bz_str += "0";
                        }
                        striparr[i] += bz_str;
                    }
                }

                if (striparr.Length > 100)
                {
                    Array.Copy(striparr, 0, striparr, 0, 100);
                }

                sd.ReaderControllor.WriteBatchTag(WorkingReader, striparr);
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


        public void UpdateView(string[] subinfo)
        {
            try
            {
                int offset = 2;
                if (subinfo[offset + 0] == ErrorNum.success)
                {
                    if (subinfo[4] != "")
                    {
                        textBox1.AppendText(subinfo[4] + "\r\n");
                    }
                    sd.UpdateLog("批量读取标签成功");
                }
                else
                {
                    sd.UpdateLog("批量读取标签失败");
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string[] striparr = textBox1.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            striparr = striparr.Where(s => !string.IsNullOrEmpty(s)).ToArray();
            label2.Text = striparr.Length.ToString();
            //this.textBox1.SelectionStart = this.textBox1.Text.Length;
            //this.textBox1.SelectionLength = 0;
            //this.textBox1.ScrollToCaret();
        }



    }
}
