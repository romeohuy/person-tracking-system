using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using hrvv;



namespace SrDemo.Business
{
    class StringToModel
    {
        public static Message StrToModel(string[] SourceMessage)
        {
            byte type = 0xFF;
            Message GeneralInstance = new Message();
            try
            {
                type = Convert.ToByte(SourceMessage[1], 16);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            switch (type)
            {
                case Types.START_MULTI_EPC_RESPOND:
                case Types.START_SINGLE_EPC_RESPOND:
            //        GeneralInstance = (object)GenerateEPCDataModel(SourceMessage);
                    break;
                case Types.GET_POWER_RESPOND:
                    GeneralInstance = GeneratePowerDataModel(SourceMessage);
                    break;
                case Types.SET_POWER_RESPOND:
                    break;
                case Types.ERROR_FLAG:
                    break;
            }
            return GeneralInstance;
        }



       /* private static StrEPC GenerateEPCDataModel(string[] SourceMessage)
        {
            StrEPC EPCModel = new StrEPC();
            EPCModel.devID = SourceMessage[0];
            EPCModel.type = SourceMessage[4];
            EPCModel.EPC = SourceMessage[5];
            EPCModel.PC = SourceMessage[6];
            EPCModel.RSSI = SourceMessage[7];
            EPCModel.Dir = SourceMessage[9];
            EPCModel.time = SourceMessage[12];
            return EPCModel;
        }*/

        private static Message GeneratePowerDataModel(string[] SourceMessage)
        {
            Message message = new Message();
            message.type = Message.MSG.COMMAND;
            Command tmp = new Command 
            {
                type = Command.Type.SET_POWER,
                DevID = SourceMessage[0],
            };
            Power power = new Power();
            power.loop = true;
            power.readpower = int.Parse(SourceMessage[4]);
            power.writepower = int.Parse(SourceMessage[5]);
            ProtoBuf.Extensible.AppendValue<Power>(tmp,100, power);
            message.command = tmp; 
            return message;
        }
    }
}
