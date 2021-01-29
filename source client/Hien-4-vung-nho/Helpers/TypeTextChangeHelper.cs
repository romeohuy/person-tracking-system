using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrDemo.Helpers
{
   public  class TypeTextChangeHelper
    {
        public event EventHandler Idled = delegate { };
        public int WaitingMilliSeconds { get; set; }
        System.Threading.Timer waitingTimer;

        public TypeTextChangeHelper(int waitingMilliSeconds = 300)
        {
            WaitingMilliSeconds = waitingMilliSeconds;
            waitingTimer = new System.Threading.Timer(p =>
            {
                Idled(this, EventArgs.Empty);
            });
        }
        public void TextChanged()
        {
            waitingTimer.Change(WaitingMilliSeconds, System.Threading.Timeout.Infinite);
        }
    }
}
