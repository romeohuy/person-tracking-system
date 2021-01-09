using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetFrame.Net.TCP.Sock.Asynchronous;
using System.Resources;


namespace SrDemo.Config
{
    //自定义的控件通过继承此类生成
    public class CustomControl:UserControl
    {
        public  SrDemo sd;
        protected static AsyncSocketState CurrentClient;
     //   public byte currentLanguaged = 0;                 
        public static AsyncSocketState WorkingReader
        {
            get { return CurrentClient; }
            set { CurrentClient = value; }
        }
        public CustomControl()
        {
 
        }


        public CustomControl(SrDemo sd)
        {
            this.sd = sd;
        }


        virtual public void LanguagedChanged()
        {
            ;
        }

        public static string GetToString()
        {
            if (SrDemo.languageType == "CN")
            {
                return "获取";
            }
            else
            {
                return "Get ";
            }
        }

        public static string SetToString()
        {
            if (SrDemo.languageType == "CN")
            {
                return "设置";
            }
            else
            {
                return "Set";
            }
        }

        public static string OkToString()
        {
            if (SrDemo.languageType == "CN")
            {
                return "成功";
            }
            else
            {
                return "Successful";
            }
        }

        public static string FailedToString()
        {
            if (SrDemo.languageType == "CN")
            {
                return "失败";
            }
            else
            {
                return "Fail";
            }
        }

        public void SetParameterRespond(string type, string result)
        {
            ResourceManager rm = new ResourceManager(typeof(SrDemo));
            string set = rm.GetString("Set");
            if (result == "1")
            {
                string oper = rm.GetString("resultOK");
                sd.UpdateLog(set + type + oper);
            }
            else
            {
                string oper = rm.GetString("resultfailed");
                sd.UpdateLog(set + type + oper);
            }

        }
        //更新视图
        virtual public void  UpdateView(string[] subinfo,string type)
        {
            ;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CustomControl
            // 
            this.Name = "CustomControl";
            this.Size = new System.Drawing.Size(121, 146);
            this.Load += new System.EventHandler(this.CustomControl_Load);
            this.ResumeLayout(false);

        }

        private void CustomControl_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
