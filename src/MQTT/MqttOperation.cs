using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using System.Net;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Net.Security; 

namespace SrDemo.MQTT
{
    class MqttOperation
    {
        MqttClient client = new MqttClient(IPAddress.Parse("192.168.1.221"), 61613, false, new System.Security.Cryptography.X509Certificates.X509Certificate());
        public MqttOperation()
        {
            //注册消息发布处理函数
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            //生成ID 连接服务器
            string clientId = Guid.NewGuid().ToString();
            try
            {
                client.Connect(clientId,"admin","password");
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
            }

            //订阅主题
            client.Subscribe(new string[] { "test" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        }


        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            //处理接收到的消息
            string msg = System.Text.Encoding.Default.GetString(e.Message);
           // textBox1.AppendText("收到消息:" + msg + "\r\n");
        }

        /// <summary>
        ///发布消息
        /// </summary>
        /// <param name="Msg"></param>
        public void clien_MqttMsgPublic(string Msg)
        {
            client.Publish("test", Encoding.UTF8.GetBytes(Msg), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
        }


    }
}
