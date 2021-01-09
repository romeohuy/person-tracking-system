using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetFrame.Net.TCP.Sock.Asynchronous;
using SrDemo;

namespace SrDemo.Config
{
    public class MyUserControl : UserControl
    {
        protected SrDemo sd;
        protected AsyncSocketState CurrentClient;
        public AsyncSocketState Client
        {
            get { return CurrentClient; }
            set { CurrentClient = value; }
        }

        public MyUserControl(SrDemo sd, AsyncSocketState CurrentClient)
        {
            this.sd = sd;
            this.CurrentClient = CurrentClient;
        }

        virtual public void updatewiew(string[] subinfo)
        {
            sd.UpdateLog("Operate stccess");
        }

        public void SetParameterRespond(string[] result, string type)
        {
            int offset = 2;
            if (result[offset + 0] == ErrorNum.success)
            {
                sd.UpdateLog("set" + type + "success");
            }
            else
            {
                sd.UpdateLog("get" + type + "failed");
            }
        }
    }
}
