using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SrDemo.Protobuff;

using NetFrame.Net.TCP.Sock.Asynchronous;

namespace SrDemo.Business
{
    /// <summary>
    /// proto格式的数据层与读写器基础引用高层协议转换
    /// </summary>
    class ProtobufFormat
    {
                       //读写器操作句柄

        private ReaderClientsInterlayer Proxy;
        public ProtobufFormat(Reader reader)
        {
            Proxy = new ReaderClientsInterlayer(reader);
        }
        /// <summary>
        /// 读写器层协议转换为protoBuf格式
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static byte[] ReaderCommandToProtobuf(string[] message)
        {
            string ms = string.Empty;
            Message ob = StringToModel.StrToModel(message);
         //   ms = ProtobufSerializer.Serialize<Message>(ob);
            ms = ProtobufSerializer.Serialize<Message>(ob);
            return System.Text.Encoding.Unicode.GetBytes(ms);
         //   return ms;
        }
        /// <summary>
        /// 解析proto数据
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public  void ProtobufToReaderCommand(byte[] ms)
        {
            Message message = ProtobufSerializer.DeSerialize<Message>(ms);
            switch (message.type)
            {
                case Message.MSG.COMMAND:
                    CommndProcess(message);
                    break;
                case Message.MSG.REQUEST:
                    RequestProcess(message);
                    break;
                case Message.MSG.RESPOND:
                    RespondProcess(message);
                    break;
                case Message.MSG.OTHER:
                    OtherProcess(message);
                    break;
                default:
                    break;
            }

        }

        private void OtherProcess(Message message)
        {
            throw new NotImplementedException();
        }

        private void RespondProcess(Message message)
        {
            throw new NotImplementedException();
        }

        private void RequestProcess(Message message)
        {
            throw new NotImplementedException();
        }

        private void CommndProcess(Message message)
        {
            if (Proxy != null)
            {
                Proxy.ReaderControl(message);
            }
        }



        public void GetReaderRespond(string[] result)
        {
            Proxy.ReaderRespond(result);
            
        }
    }
}
