using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace SrDemo.Log
{
    class EPCLog
    {
        private static StreamWriter streamWriter; //写文件  

        public static void WriteEvent(string message)
        {
            try
            {
                //DateTime dt = new DateTime();
                string directPath = AppDomain.CurrentDomain.BaseDirectory + "Data\\";    //获得文件夹路径
                if (!Directory.Exists(directPath))   //判断文件夹是否存在，如果不存在则创建
                {
                    directPath = AppDomain.CurrentDomain.BaseDirectory + "Data\\";
                    Directory.CreateDirectory(directPath);
                }
                directPath += string.Format(@"\{0}.log", "EPC数据" + DateTime.Now.ToString("yyyy-MM-dd-HH"));
                if (streamWriter == null)
                {
                    streamWriter = !File.Exists(directPath) ? File.CreateText(directPath) : File.AppendText(directPath);    //判断文件是否存在如果不存在则创建，如果存在则添加。
                }
                streamWriter.WriteLine(message);
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Flush();
                    streamWriter.Dispose();
                    streamWriter = null;
                }
            }

        }
    }
}
