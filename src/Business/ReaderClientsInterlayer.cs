using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetFrame.Net.TCP.Sock.Asynchronous;
using AnnalyticPack;

namespace SrDemo.Business
{
    class ReaderClientsInterlayer
    {
        private Reader readerHandle;
        public ReaderClientsInterlayer(Reader reader)
        {
            this.readerHandle = reader;
        }
        
        /// <summary>
        /// 从读写器接收应答 发给所有客户
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool ReaderRespond(string[] message)
        {
            //  return clients.ReleaseNews(ProtobufFormat.ReaderCommandToProtobuf(message));
        }


        public bool ReaderControl(Message message)
        {
            switch (message.command.type)
            {
                case hrvv.Command.Type.SET_CARRIER:
                    CommandSetCarruer(message);
                    break;
                case hrvv.Command.Type.SET_POWER:
                    CommandSetPower(message);
                    break;
                case hrvv.Command.Type.GET_POWER:
                    CommandGetPower(message);
                    break;
                case hrvv.Command.Type.SET_GPIO:
                case hrvv.Command.Type.SET_FREQUENCY_POINT:
                case hrvv.Command.Type.SET_GEN2:
                case hrvv.Command.Type.SET_WORK_ANT:
                case hrvv.Command.Type.SET_FREQUENCY_AREA:
                case hrvv.Command.Type.SET_WORK_INTERRUPTED:
                case hrvv.Command.Type.SET_WORK_TIME:
                case hrvv.Command.Type.SET_TAGFOCUS:
                case hrvv.Command.Type.SET_QT:
                    break;
                default:
                    break;
            }
            return true;
        }

        private void CommandGetPower(Message message)
        {
            AsyncSocketState reader = SeaechDev(message.command.DevID);
            if (reader.com != "null")
            {
                readerHandle.GetPower(SeaechDev(message.command.DevID));
            }
        }

        private void CommandSetPower(Message message)
        {
            Power power = ProtoBuf.Extensible.GetValue<Power>(message.command, 100);
            AsyncSocketState reader = SeaechDev(message.command.DevID);
            if (reader.com != "null")
            {
                readerHandle.SetPower(SeaechDev(message.command.DevID), (byte)power.readpower, (byte)power.writepower);
            }
        }

        private AsyncSocketState SeaechDev(string devID)
        {
            List<AsyncSocketState> readers = readerHandle.GetClientInfo();
            foreach (AsyncSocketState reader in readers)
            {
                if (devID == reader.dev)
                {
                    return reader;
                }
            }
            AsyncSocketState VirtureReader = new AsyncSocketState("null");
            return VirtureReader;
        }



        private void CommandSetCarruer(Message message)
        {
            throw new NotImplementedException();
        }

    }
}
