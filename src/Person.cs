using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;


namespace SrDemo
{
    public class Person
    {
        public Person(string ID)
        {
            this.id = ID;
            state = 0x00;
        }
       
        private byte state;   //人员状态    01:单位时间内(1s)只是被D1读到认为 人员在外面     
                                  //        02:单位时间内(1s)被D1和D2同时读到 人员在进入或出去的过程中
                                  //        03:单位时间内(1s)只是被D2读到认为 人员在展厅内
        //                                  00:   单位时间内没有被任何读写器读到 可能在展厅内或外面  根据历史记录做出做最优判断
       
        public byte State
        {
            get { return state; }
            set 
            { 
                state = value;
            }
        }
        private string id;
        public string ID 
        {
            get{return id;}
            set{}
        }
        public byte flag = 0x00;                //先读到和后读到的标志  0x00 初始位   0x01 DOOR1先读到    DOOR2 先读到

        public byte privatelock = 0x00;           //01锁住标志位         
        
        private string  lastDoorTime1 = string.Empty;
        public string LastDoorTime1
        {
            get { return lastDoorTime1; }
            set { lastDoorTime1 = value; }
        }
        private string lastDoorTime2 = string.Empty;
        public string LastDoorTime2
        {
            get { return lastDoorTime2; }
            set { lastDoorTime2 = value; }
        }

        public System.Timers.Timer  PrivateTimer = new System.Timers.Timer(5000);      //内部私有定时器  2800ms


        private int record;                                   //当前 历史记录存储的索引 只保存100条
        public int Record
        {
            get { return record;}
            set { }
        }
        public List<byte> HistoricalState = new List<byte>(20);

        public bool AddHistoricalState()
        {
            if (HistoricalState.Count >= 20)
            {
                HistoricalState.RemoveAt(0);
            }
            HistoricalState.Add(state);
            record = HistoricalState.Count;
            return true;
        }
    }
}
