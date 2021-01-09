using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using SrDemo.Log;
using System.Threading;
using System.Configuration;
using System.Resources;

namespace SrDemo.Config
{

    public partial class Map : CustomControl
    {
        public Map(SrDemo sd)
            : base(sd)
        {
            InitializeComponent();
            load();
        }
        public Map()
        {

        }

        public void LanguagedChanged()
        {
            ResourceManager rm = new ResourceManager(typeof(SrDemo));
            button2.Text = rm.GetString("CheckBoxTag");
            button1.Text = rm.GetString("Access_Write");
        }


        public void load()
        {
            try
            {
                //这个文件于可执行文件放在同一目录
                webBrowser1.Url = new Uri(Path.Combine(Application.StartupPath, "test.html"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }       
        }


        string[,] str_two = new string[100000, 7];
        int str_num = 0;//二位数组索引

        public void UpdateView(string[] result)
        {
            try
            {
                if (result[4] == "无效定位")
                {
                    WriteEvent("无效定位," + "无效数据:" + result[5], null);
                    return;
                }

                //新增到二维数组保存
                for (int j = 0; j < 7; j++)
                {
                    str_two[str_num, j] = result[j + 4];
                }
                //计算GPS经度纬度
                string strS = ".";
                char[] strSplit = strS.ToCharArray();
                string[] str_lon = result[6].Split(strSplit);

                string[] str_lat = result[7].Split(strSplit);

                string str_double_lon = str_lon[0].Substring(str_lon[0].Length - 2, 2) + "." + str_lon[1];
                string str_double_lat = str_lat[0].Substring(str_lat[0].Length - 2, 2) + "." + str_lat[1];

                double get_lon = (Convert.ToDouble(str_double_lon)) / 60;
                double get_lat = (Convert.ToDouble(str_double_lat)) / 60;

                string real_lon = str_lon[0].Substring(0, str_lon[0].Length - 2) + get_lon.ToString().Substring(1, get_lon.ToString().Length - 1);
                string real_lat = str_lat[0].Substring(0, str_lat[0].Length - 2) + get_lat.ToString().Substring(1, get_lat.ToString().Length - 1);

                string get_url = "http://api.map.baidu.com/geoconv/v1/?coords=" + real_lon + "," + real_lat + "&from=1&to=5&ak=G6X4BnlP0bpPd15KFAR56l2nE6yyiVzP";
                string results = GetFunction(get_url);
               // [{\"x\":113.96788900329546,\"y\":22.603252401330854}]
                //   {\"x\":113.96788900329546,\"y\":22.603252401330854}


                //results = GetRealStr(results, "[", "]");

                //string strSS = ",,";
                //char[] strSplitS = strSS.ToCharArray();
                //string[] strValue = results.Split(strSplitS);

                //string ss = strValue[0].Substring(0, strValue[0].IndexOf(":"));
                //string string_lon = strValue[0].Substring(ss.Length+1, strValue[0].Length - ss.Length-1);
                //string string_lat = GetRealStr(strValue[1],":","}");

                //double lon = Convert.ToDouble(string_lon);
                //double lat = Convert.ToDouble(string_lat);

                Root rb = JsonConvert.DeserializeObject<Root>(results);
                double lon = rb.result[0].x;
                double lat = rb.result[0].y;

                //得到UTC日期、UTC时间、地面速率、地面航向
                string utc_date = result[4];

                string date_y = "20"+utc_date.Substring(4,2);
                string date_m = utc_date.Substring(2, 2);
                string date_d =utc_date.Substring(0, 2);

                string utc_time = result[5];
                utc_time = utc_time.Substring(0,6);
                string time_h = utc_time.Substring(0, 2);
                int int_h = int.Parse(time_h)+8;
                if (int_h < 24)
                {                 
                }
                else if (int_h == 24)
                {
                    int_h = 0;
                }
                else
                {
                    int_h = int_h - 24;
                    int int_d = int.Parse(date_d);
                    int_d = int_d + 1;

                    if (int_d <= GetDay())
                    {
                        date_d = int_d.ToString();
                    }
                    else
                    {
                        int_d = int_d - GetDay();
                        date_d = int_d.ToString();

                        int int_m = int.Parse(date_m);
                        int_m = int_m + 1;
                        date_m = int_m.ToString();
                    }
                }
                time_h = int_h.ToString();
                if (time_h.Length != 2)
                {
                    time_h = "0" + time_h;
                }
                string time_m = utc_time.Substring(2, 2);
                string time_s = utc_time.Substring(4, 2);
                utc_time = time_h + ":" + time_m + ":" + time_s;

                utc_date = date_y + "/" + date_m + "/" + date_d;

               // string ground_speed = result[8];
                double int_speed = Convert.ToDouble(result[8]);
                double real_speed = int_speed * 1.854;
                string ground_speed = real_speed.ToString()+"公里/h";

                string ground_dir = result[9]+"度";
                string local_type = result[10];             
                UpdateView_Old(lon, lat, utc_date, utc_time, ground_speed, ground_dir, local_type);
                str_num++;
                string Results = "经度:" + lon.ToString() +"," + "纬度:" + lat.ToString()+"," + "UTC_日期:" + utc_date + "," + "UTC_时间:" + utc_time + "," + "地面速率:" + ground_speed + "," + "地面航向" + ground_dir + "," + "标注类型:" + local_type;
                WriteEvent(Results,null);
            }
            catch (Exception ex)
            {
                WriteEvent(ex.ToString(), null);
                sd.UpdateLog(ex.ToString());
                if (SrDemo.isLogOpen)
                {
                    ErrorLog.WriteError(ex.ToString());
                }
            }
        }


         public int GetDay()
        {
            DateTime dt = DateTime.Now;
            int day = DateTime.DaysInMonth(dt.Year, dt.Month);
            return day;
        }

        public void UpdateView_Old(double lon, double lat, string utc_date, string utc_time, string ground_speed, string ground_dir,string local_type)
        {
            try
            {
                  this.Invoke(new Action(() =>
                  {
                      Thread.Sleep(300);
                      Application.DoEvents(); // 防止卡死
                    webBrowser1.Document.InvokeScript("setLocation", new object[] { lon, lat, utc_date, utc_time, ground_speed, ground_dir,local_type });
                  }));
                  }
            catch (Exception ex)
            {
                 string Results = "经度:" + lon.ToString() +"," + "纬度:" + lat.ToString()+"," + "UTC_日期:" + utc_date + "," + "UTC_时间:" + utc_time + "," + "地面速率:" + ground_speed + "," + "地面航向" + ground_dir + "," + "标注类型:" + local_type;
                 WriteEvent(ex.ToString() + "," + "\r\n" + "错误数据:" + Results, null);
                sd.UpdateLog(ex.ToString());
                if (SrDemo.isLogOpen)
                {
                    ErrorLog.WriteError(ex.ToString());
                }
            }
        }



        public void Delete_Local()
        {
            try
            {
                webBrowser1.Document.InvokeScript("DeleteLocation", new object[] { });
            }
            catch (Exception ex)
            {
                sd.UpdateLog(ex.ToString());
                if (SrDemo.isLogOpen)
                {
                    ErrorLog.WriteError(ex.ToString());
                }
            }
        }

        public string GetRealStr(string data, string start, string end)
        {
            //求得strtempa 和 strtempb 出现的位置:
            int IndexofA = data.IndexOf(start);
            int IndexofB = data.IndexOf(end);
            string Ru = data.Substring(IndexofA + 1, IndexofB - IndexofA - 1);
            return Ru;
        }

        private static StreamWriter streamWriter; //写文件  

        public void WriteEvent(string message, string info)
        {
            lock (this)
            {
                Monitor.Enter(this);

                try
                {
                    //DateTime dt = new DateTime();
                    string directPath = ConfigurationManager.AppSettings["EventLogFilePath"].ToString().Trim();    //获得文件夹路径
                    if (!Directory.Exists(directPath))   //判断文件夹是否存在，如果不存在则创建
                    {
                        directPath = AppDomain.CurrentDomain.BaseDirectory + "Data\\";
                        Directory.CreateDirectory(directPath);
                    }
                    directPath += string.Format(@"\{0}.log", "事件日志" + DateTime.Now.ToString("yyyy-MM-dd HH"));
                    if (streamWriter == null)
                    {
                        streamWriter = !File.Exists(directPath) ? File.CreateText(directPath) : File.AppendText(directPath);    //判断文件是否存在如果不存在则创建，如果存在则添加。
                    }
                    streamWriter.WriteLine("***********************************************************************");
                    streamWriter.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                    streamWriter.WriteLine("输出信息：事件");
                    if (message != null)
                    {
                        streamWriter.WriteLine("事件信息：\r\n" + message);
                    }
                    if (info != null)
                    {
                        streamWriter.WriteLine("备注：\r\n" + info);
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
                Monitor.Exit(this);
            }

        }


        public string GetFunction(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                return retString;
            }
            catch (Exception ex)
            {
                sd.UpdateLog(ex.ToString());
                if (SrDemo.isLogOpen)
                {
                    ErrorLog.WriteError(ex.ToString());
                }
                return "";
            }
        }


        private void Map_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Delete_Local();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] command = { 0xBB, 0x54, 0x04, 0x59, 0x95, 0x77, 0xC3, 0x80, 0x0D, 0x0A };
                string result = sd.ReaderControllor.GoToByte(WorkingReader, command);
            }
            catch
            { 
            
            }
        }
    }

    public class ResultItem
    {
        public double x { get; set; }

        public double y { get; set; }
    }

    public class Root
    {
        public int status { get; set; }

        public List<ResultItem> result { get; set; }
    }


}
