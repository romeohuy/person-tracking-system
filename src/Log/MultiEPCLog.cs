//using System.Threading.Tasks;

using System;
using System.IO;

namespace SrDemo.Log
{
    class MultiEPCLog
    {
        private static StreamWriter streamWriter; //写文件  

        public static void WriteError(string counts, string message)
        {
            try
            {
                //DateTime dt = new DateTime();
                string directPath = ConfigurationManager.AppSettings["MultiEPCLogFilePath"].ToString().Trim();    //获得文件夹路径
                if (!Directory.Exists(directPath))   //判断文件夹是否存在，如果不存在则创建
                {
                    Directory.CreateDirectory(directPath);
                }
                directPath += string.Format(@"\{0}.log", "读卡日志" + DateTime.Now.ToString("yyyy-MM-dd"));
                if (streamWriter == null)
                {
                    streamWriter = !File.Exists(directPath) ? File.CreateText(directPath) : File.AppendText(directPath);    //判断文件是否存在如果不存在则创建，如果存在则添加。
                }
                //   streamWriter.WriteLine("***********************************************************************");
                streamWriter.WriteLine(DateTime.Now.ToString("HH:mm:ss") + "            " + "数量" + "            " + counts);
                if (message != null)
                {
                    streamWriter.WriteLine("输出信息：错误信息");
                    streamWriter.WriteLine("异常信息：\r\n" + message);
                }
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
