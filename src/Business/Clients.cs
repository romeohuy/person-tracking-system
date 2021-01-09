using System;
using System.Collections.Generic;
using System.Text;
using Private.NetFrame.Net.TCP.Sock;
using System.Net;
using NetFrame.Net.TCP.Sock.Asynchronous;

namespace SrDemo.Business
{
    public class Clients
    {
        private UserInterfaceOperation Client = new UserInterfaceOperation();
        private ProtobufFormat pf;
        private Reader readerHandle;
        public Clients(Reader readerHandle)
        {
            this.readerHandle = readerHandle;
            Client.cmd.ClientConnect_Event += ClientConnect; 
            Client.cmd.MultiEPC_Event += RecvData;
        }



        List<Private.NetFrame.Net.TCP.Sock.AsyncSocketState> MessageSubscription = new List<Private.NetFrame.Net.TCP.Sock.AsyncSocketState>(10);
        /// <summary>
        /// 创建消息发布者
        /// </summary>
        /// <param name="IP"></param>
        /// <param name="Port"></param>
        /// <returns></returns>
        public bool CreatMessagePublisher(IPAddress IP,ushort Port)
        {
            if (Client.ServerStart(IP, Port))
            {
                pf = new ProtobufFormat(this.readerHandle, this);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        /// <summary>
        /// 销毁服务器
        /// </summary>
        /// <returns></returns>
        public bool DisposeMessagePublisher()
        {
             Client.ServerClose();
             return true;
        }

        /// <summary>
        /// 发布消息
        /// </summary>
        /// <param name="Message"></param>
        public bool  ReleaseNews(byte[] Message)
        {
            return Client.Send(Message);
  
        }

       /// <summary>
       /// 接收消息 用自定义类型自动解析数据
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void RecvData(object sender, Private.NetFrame.Net.TCP.Sock.Command.ShowEPCEventArgs e)
      {
          if (pf != null)
          {
              pf.ProtobufToReaderCommand(e.CommandRespond);
          }
      }

        /// <summary>
        /// 处理消息接收者连接 断开 等事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
     private void ClientConnect(object sender, Private.NetFrame.Net.TCP.Sock.Command.ClientConnectEventArgs e)
     {
         Private.NetFrame.Net.TCP.Sock.AsyncSocketState clientstate = (Private.NetFrame.Net.TCP.Sock.AsyncSocketState)e.state;
         lock (MessageSubscription)
         {
             bool isexit = false;
             foreach (Private.NetFrame.Net.TCP.Sock.AsyncSocketState state in MessageSubscription)
             {
                 if (clientstate.dev == state.dev)
                 {
                     if (clientstate.state == "OK")
                     {
                         MessageSubscription.Remove(state);
                         MessageSubscription.Add(clientstate);
                     }
                     else
                     {
                         MessageSubscription.Remove(state);
                     }
                     isexit = true;
                     break;
                 }
             }
             if (!isexit)
             {
                 MessageSubscription.Add(clientstate);
             }
         }
     }

  //    public bool Send<T>()


     public void GetReaderRespond(string[] result)
     {
         pf.GetReaderRespond(result);
     }

     public  List<Private.NetFrame.Net.TCP.Sock.AsyncSocketState> GetClientInfo()
     {
         return MessageSubscription;
     }
    }
}
