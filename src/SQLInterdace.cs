using System;
using System.Collections.Generic;
using System.Text;
using SrDemo;
using System.Data;
using RankOrStatisticDatum;
using System.ServiceProcess;
using Microsoft.Win32;
namespace SQL
{
    public class SQLInterdace
    {
        //插入标签数据
        private SQLDatabBase db = new SQLDatabBase();          //数据库操作对象
        private List<string> tables;          //该数据库对象下已经有的表格
        private const string readercommand = "ReaderCommand";
        private const int MaxCommandLen = 28;
        private const string EPCTablesName = "Epcs";
        private const string IDTablesName = "ID";
        private const string CommandTablesName = "Command";
        private DataTable dt = new DataTable();
        private DataTable dt_ID = new DataTable();

        public SQLInterdace()
        {
            initEPCTables();
            initIDTables();
        }

        private void initIDTables()
        {
            dt_ID.Columns.Add("ts", System.Type.GetType("System.String"));
            dt_ID.Columns.Add("devID", System.Type.GetType("System.String"));
            dt_ID.Columns.Add("types", System.Type.GetType("System.String"));
            dt_ID.Columns.Add("error", System.Type.GetType("System.String"));
            dt_ID.Columns.Add("temperature", System.Type.GetType("System.String"));
            dt_ID.Columns.Add("ID", System.Type.GetType("System.String"));
            dt_ID.Columns.Add("RSSI", System.Type.GetType("System.String"));
            dt_ID.Columns.Add("power", System.Type.GetType("System.String"));
            dt_ID.Columns.Add("remove", System.Type.GetType("System.String"));
            dt_ID.Columns.Add("intervaltime", System.Type.GetType("System.String"));
            dt_ID.Columns.Add("battery", System.Type.GetType("System.String"));
            dt_ID.Columns.Add("count", System.Type.GetType("System.String"));
            dt_ID.Columns.Add("ClientIP", System.Type.GetType("System.String"));
            dt_ID.Columns.Add("time", System.Type.GetType("System.String"));
        }

        private void initEPCTables()
        {
            dt.Columns.Add("ts", System.Type.GetType("System.String"));
            dt.Columns.Add("devID", System.Type.GetType("System.String"));
            dt.Columns.Add("types", System.Type.GetType("System.String"));
            dt.Columns.Add("error", System.Type.GetType("System.String"));
            dt.Columns.Add("sign", System.Type.GetType("System.String"));
            dt.Columns.Add("antID", System.Type.GetType("System.String"));
            dt.Columns.Add("EPC", System.Type.GetType("System.String"));
            dt.Columns.Add("PC", System.Type.GetType("System.String"));
            dt.Columns.Add("RSSI", System.Type.GetType("System.String"));
            dt.Columns.Add("intervaltime", System.Type.GetType("System.String"));
            dt.Columns.Add("direction", System.Type.GetType("System.String"));
            dt.Columns.Add("ClientIP", System.Type.GetType("System.String"));
            dt.Columns.Add("count", System.Type.GetType("System.String"));
            dt.Columns.Add("time", System.Type.GetType("System.String"));
        }

        /*  public ErrorNum.Error InsertID(string[] ID)
           {
               try
               {
                   tables = db.GetTables();
                   if ((db != null) && (db.isOpen() == true))
                   {
                       bool exist = false;
                       foreach (string tablename in tables)           //表的名字和设备号对应则写入 否则创建新的表格
                       {

                           if (tablename == ID[0])
                           {
                               db.InsertSingleData(tablename, ID);
                               exist = true;
                           }
                       }
                       if (!exist)                          //创建新的表格  并写入数据
                       {
                           string[] name = { "time", "temperature", "ID", "RSSI", "power", "remove", "intervaltime", "battery", "count", "ClientIP" };
                           string[] atttribute = { "Datetime", " Varchar(5)", " Varchar(10)", " Varchar(6)", " Varchar(3)", " Varchar(3)", " Varchar(8)", " Varchar(3)", " Varchar(5)", " Varchar(16)" };
                           string[] isnull = { "not null", "not null", "not null", "not null", "not null", "not null", "not null", "not null", "not null", "not null" };
                           if (!db.CreatTables(ID[0], db.SQLComamndFormat(name, atttribute, isnull)))
                           {
                               return ErrorNum.Error.SQL_CREAT_TABLES_FAILED;
                           }
                           db.InsertSingleData(ID[0], ID);
                       }
                       return ErrorNum.Error.SQL_OPER_SUCCESS;
                   }
                   else
                   {
                       return ErrorNum.Error.SQL_NOT_OPEN;
                   }
               }
               catch (Exception ex)
               {
                   ErrorLog.WriteError(ex.ToString());
                   throw ex;
               }

           }*/


        public ErrorNum.Error InsertEPC(string[] EPC)
        {
            try
            {
                tables = SQLDatabBase.GetTables();
                bool exist = false;
                foreach (string tablename in tables)           //表的名字和设备号对应则写入 否则创建新的表格
                {

                    if (tablename == EPCTablesName)
                    {
                        db.InsertSingleData(EPCTablesName, EPC);
                        exist = true;
                    }
                }
                if (!exist)                          //创建新的表格  并写入数据
                {
                    string[] name = { "time", "devID", "types", "error", "sign", "antID", "EPC", "PC", "RSSI", "intervaltime", "direction", "ClientIP", "count" };
                    string[] atttribute = { "Datetime", " Varchar(9)", "Varchar(3)", " Varchar(3)", "Varchar(3)", " Varchar(5)", " Varchar(50)", " Varchar(6)", " Varchar(6)", " Varchar(12)",
                                                  " Varchar(16)", " Varchar(22)", "Varchar(3)" };
                    string[] isnull = { "not null", "not null", "not null", "not null", "not null", "not null", "not null", "not null", "not null", "not null", "not null", "not null", "not null" };
                    if (!db.CreatTables(EPCTablesName, db.SQLComamndFormat(name, atttribute, isnull)))
                    {
                        return ErrorNum.Error.SQL_CREAT_TABLES_FAILED;
                    }
                    db.InsertSingleData(EPCTablesName, EPC);
                }
                return ErrorNum.Error.SQL_OPER_SUCCESS;
            }

            catch (Exception ex)
            {
                ErrorLog.WriteError(ex.ToString());
                throw ex;
            }
        }

        //根据type值创建不同样式的表格
        public ErrorNum.Error creatTable(byte type)
        {
            try
            {
                if (type == 0)
                {
                    string[] name = { "ts", "devID", "types", "error", "sign", "antID", "EPC", "PC", "RSSI", "intervaltime", "direction", "ClientIP", "count", "time" };
                    string[] atttribute = { "timestamp", " Varchar(9)", "Varchar(3)", " Varchar(3)", "Varchar(3)", " Varchar(5)", " Varchar(50)", " Varchar(6)", " Varchar(6)", " Varchar(12)",
                                     " Varchar(5)", " Varchar(22)", "Varchar(3)","Datetime" };
                    string[] isnull = { "null", "not null", "not null", "not null", "not null", "not null", "not null", "not null", "not null", "not null", "not null", "not null", "not null", "not null" };
                    if (!db.CreatTables(EPCTablesName, db.SQLComamndFormat(name, atttribute, isnull)))
                    {
                        return ErrorNum.Error.SQL_CREAT_TABLES_FAILED;
                    }
                    return ErrorNum.Error.SQL_OPER_SUCCESS;
                }
                else if (type == 1)
                {
                    string[] name = { "ts", "devID", "types", "error", "temperature", "ID", "RSSI", "power", "remove", "intervaltime", "battery", "count", "ClientIP", "time" };
                    string[] atttribute = { "timestamp", " Varchar(9)", "Varchar(3)", " Varchar(3)", " Varchar(5)", " Varchar(16)", " Varchar(6)", " Varchar(3)", " Varchar(3)", " Varchar(8)", " Varchar(3)", " Varchar(5)", " Varchar(22)", "Datetime" };
                    string[] isnull = { "null", "not null", "not null", "not null", "not null", "not null", "not null", "not null", "not null", "not null", "not null", "not null", "not null", "not null" };
                    if (!db.CreatTables(IDTablesName, db.SQLComamndFormat(name, atttribute, isnull)))
                    {
                        return ErrorNum.Error.SQL_CREAT_TABLES_FAILED;
                    }
                    return ErrorNum.Error.SQL_OPER_SUCCESS;
                }
                else if (type == 2)
                {
                    string[] name = { "ts", "devID", "types", "error", "value1", "value2", "value3", "value4", "value5", "value6", "value7", "value8", "value9", "value10",
                                            "value11", "value12", "value13", "value14", "value15", "value16", "value17", "value18", "value19", "value20", "value21", "value22", 
                                            "value23", "value24", "value25","time" };
                    string[] atttribute = { "timestamp", " Varchar(9)", " Varchar(3)"," Varchar(3)", " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)"
                                              , " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)"
                                              , " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)"
                                              , " Varchar(100)","Datetime"};
                    string[] isnull = { "null", "not null", "not null", "not null", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                    if (!db.CreatTables(CommandTablesName, db.SQLComamndFormat(name, atttribute, isnull)))
                    {
                        return ErrorNum.Error.SQL_CREAT_TABLES_FAILED;
                    }
                    return ErrorNum.Error.SQL_OPER_SUCCESS;
                }
                else
                {
                    return ErrorNum.Error.SQL_CREAT_TABLES_FAILED;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //按照方式一插入数据
        public ErrorNum.Error InsertEPC1(string[] EPC)
        {
            try
            {
                tables = SQLDatabBase.GetTables();
                bool exist = false;
                foreach (string tablename in tables)           //表的名字和设备号对应则写入 否则创建新的表格
                {

                    if (tablename == EPC[0])
                    {
                        db.InsertSingleData(tablename, EPC);
                        exist = true;
                    }
                }
                if (!exist)                          //创建新的表格  并写入数据
                {
                    string[] name = { "time", "devID", "types", "error", "antID", "EPC", "PC", "RSSI", "differentialtime", "direction", "intervaltime", "count", "ClientIP" };
                    string[] atttribute = { "Datetime", " Varchar(5)", " Varchar(12)", " Varchar(5)", " Varchar(6)", " Varchar(8)", " Varchar(8)", " Varchar(5)", " Varchar(16)" };
                    string[] isnull = { "not null", "not null", "not null", "not null", "not null", "not null", "not null", "not null", "not null", "not null" };
                    if (!db.CreatTables(EPC[0], db.SQLComamndFormat(name, atttribute, isnull)))
                    {
                        return ErrorNum.Error.SQL_CREAT_TABLES_FAILED;
                    }
                    db.InsertSingleData(EPC[0], EPC);
                }
                return ErrorNum.Error.SQL_OPER_SUCCESS;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteError(ex.ToString());
                throw ex;
            }
        }


        /*  public bool InsertCommand(string name, string[] values)
          {
 
          }*/

        //把EPC数据插入DataTables中
        public bool InsertToDataTables(string[] result, byte type)
        {
            try
            {
                if (type == 0)
                {

                    lock (dt.Rows.SyncRoot)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = null;
                        //   dr[1] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        for (int index = 0; index < result.Length; index++)              //前两列固定字段
                        {
                            dr[index + 1] = result[index];
                        }
                        dt.Rows.Add(dr);
                    }
                }
                else
                {
                    lock (dt_ID.Rows.SyncRoot)
                    {
                        DataRow dr = dt_ID.NewRow();
                        dr[0] = null;
                        //    dr[0] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        for (int index = 0; index < result.Length; index++)
                        {
                            dr[index + 1] = result[index];
                        }
                        dt_ID.Rows.Add(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteError(ex.ToString());
                throw ex;
            }
            return true;
        }



        public ErrorNum.Error InsertCommand(string[] Comamnd)
        {
            try
            {

                if (Comamnd.Length > MaxCommandLen)
                {
                    return ErrorNum.Error.SQL_INSERT_LEN_TOOLONG;
                }
                else
                {
                    string[] insubffcient = new string[MaxCommandLen];
                    Comamnd.CopyTo(insubffcient, 0);
                    bool exist = false;
                    tables = SQLDatabBase.GetTables();
                    foreach (string tablename in tables)           //表的名字和设备号对应则写入 否则创建新的表格
                    {

                        if (tablename == readercommand)
                        {
                            db.InsertSingleData(tablename, insubffcient);
                            exist = true;
                        }
                    }
                    if (!exist)                          //创建新的表格  并写入数据
                    {
                        string[] name = { "time", "devID", "types", "error", "value1", "value2", "value3", "value4", "value5", "value6", "value7", "value8", "value9", "value10",
                                            "value11", "value12", "value13", "value14", "value15", "value16", "value17", "value18", "value19", "value20", "value21", "value22", 
                                            "value23", "value24", "value25" };
                        string[] atttribute = { "Datetime", " Varchar(9)", " Varchar(3)"," Varchar(3)", " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)"
                                              , " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)"
                                              , " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)", " Varchar(100)"
                                              , " Varchar(100)"};
                        string[] isnull = { "not null", "not null", "not null", "not null", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", };
                        if (!db.CreatTables(readercommand, db.SQLComamndFormat(name, atttribute, isnull)))
                        {
                            return ErrorNum.Error.SQL_CREAT_TABLES_FAILED;
                        }
                        db.InsertSingleData(readercommand, insubffcient);
                    }
                    return ErrorNum.Error.SQL_OPER_SUCCESS;
                }


            }
            catch (Exception ex)
            {
                ErrorLog.WriteError(ex.ToString());
                throw ex;
            }
        }

        //插入多行数据  更具type值插入不同位置
        public ErrorNum.Error InsertMultiData(byte type)
        {

            if (type == 0)
            {
                if (dt != null && dt.Rows.Count != 0)
                {
                    lock (dt.Rows.SyncRoot)
                    {
                        db.InsertDataTables(dt, EPCTablesName);
                        dt.Clear();
                    }
                    return ErrorNum.Error.SQL_OPER_SUCCESS;
                }
                else
                {
                    return ErrorNum.Error.SQL_NOT_OPEN;
                }
            }
            else if (type == 1)
            {
                if (dt_ID != null && dt_ID.Rows.Count != 0)
                {

                    lock (dt_ID.Rows.SyncRoot)
                    {
                        db.InsertDataTables(dt_ID, IDTablesName);
                        dt_ID.Clear();
                    }
                    return ErrorNum.Error.SQL_OPER_SUCCESS;
                }
                else
                {
                    return ErrorNum.Error.SQL_NOT_OPEN;
                }
            }
            else
            {
                return ErrorNum.Error.SQL_INSERT_DATA_WRONG;
            }
        }

        /// <summary>
        /// 检测应用环境中数据库是否正确配置了
        /// </summary>
        /// <returns></returns>
        public bool DataBaseDetection()
        {
            /*  ServiceController[] service = ServiceController.GetServices();
              bool isexit = false;
              for (int i = 0; i < service.Length; i++)
              {
                  if (service[i].DisplayName.ToString() == "MSSQLSERVER")
                  {
                      isexit = true;
                      break;
                  }
              }*/
            try
            {
                string strCurrentVersion = "";
                RegistryKey regkey = Registry.LocalMachine.OpenSubKey("SOFTWARE", true).OpenSubKey(@"Microsoft\MSSQLServer\MSSQLServer\CurrentVersion", true);
                if (regkey == null)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
           /* List<string> TablesName = SQLDatabBase.GetTables();
            if (TablesName.Contains("Epcs") && TablesName.Contains("ID") && TablesName.Contains("Command"))
                return true;
            else
                return false;*/

        }


        //按照时间段来查询
        public DataTable Selectbytime(string startTime, string endTime, string tablename)
        {
            string cmd = string.Format("select * from Sales where time >='{0} and time<='{1}", startTime, endTime);
            return SQLDatabBase.SelectValuebyCondition(cmd, tablename);
        }

        //依据时间和天线号来查询
        public DataTable SelectByMultiContion(string startTime, string endTime, string ant, string tablename)
        {

            string cmd = string.Format("select top 10000* from {0} where time >='{1}' and time<='{2}' and antID = '{3}' order by ts desc", tablename, startTime, endTime, ant);
            return SQLDatabBase.SelectValuebyCondition(cmd, tablename);
        }

        /* public DataTable GetMaxTimeStamp()
         {

             string cmd = string.Format("select * from {0} where time >='{1}' and time<='{2}' and antID = '{3}' order by time", tablename, startTime, endTime, ant);
             return SQLDatabBase.SelectValuebyCondition(cmd, tablename);
         }*/

        //依据时间查询
        public DataTable SelectByMultiContion(string startTime, string endTime, string tablename)
        {
            string cmd = string.Format("select * from {0} where time >='{1}' and time<='{2}' order by time", tablename, startTime, endTime);
            return SQLDatabBase.SelectValuebyCondition(cmd, tablename);
        }

        public DataTable SelectValue(string cmd)
        {
            return db.SelectValue(cmd);
        }

        public bool deletedata(string tablename)
        {
            return db.DeleteAll(tablename);
        }


    }
}
