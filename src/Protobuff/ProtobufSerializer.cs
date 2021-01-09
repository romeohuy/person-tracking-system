using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;
using System.IO;

namespace SrDemo.Protobuff
{

    class ProtobufSerializer
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string Serialize<T>(T t)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Serializer.Serialize<T>(ms, t);
                return Encoding.Unicode.GetString(ms.ToArray(), 0, ms.ToArray().Length);
                //return Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <returns></returns>
        public static T DeSerialize<T>(string content)
        {
            using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(content)))
            //using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(content)))
            {
                //ms.Position = 0;
                T t = Serializer.Deserialize<T>(ms);
                return t;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <returns></returns>
        public static T DeSerialize<T>(byte[] content)
        {
            using (MemoryStream ms = new MemoryStream(content))
            //using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(content)))
            {
                //ms.Position = 0;
                T t = Serializer.Deserialize<T>(ms);
                return t;
            }
        }
    }
}
