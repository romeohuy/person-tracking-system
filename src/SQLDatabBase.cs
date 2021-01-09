using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using SrDemo;
using System.Configuration;

namespace SQL
{
    class SQLDatabBase
    {
        //  private SqlConnection sqlCnt;
        //  private bool SqlOpenState = false;
        // SqlBulkCopy bulkCopy;
        private  static string sourecstr = ConfigurationManager.AppSettings["database"];


        /*public bool isOpen()
        {
            return SqlOpenState;
        }*/
        //连接服务器
        /*   public bool connect(string Server,string DataName,string User,string PassWord)
           {
               try
               {
                
                   string dataSource = "Server =" + Server + ";" + "Database = " + DataName + ";" + "User ID=" + User + ";" + "Password =" + PassWord;
                   using (sqlCnt = new SqlConnection(dataSource))
                   {
                       sqlCnt.Open();
                       bulkCopy = new SqlBulkCopy(sqlCnt);
                       SqlOpenState = true;
                   }
               }
               catch (Exception ex)
               {
                   ErrorLog.WriteError(ex.ToString());
                   throw ex;
               }
               return true; 
           }*/

        /* public bool InsertDataTable(DataTable dt)
         {
             try
             {
                 bulkCopy.DestinationTableName = "Epcs";
                 bulkCopy.BatchSize = dt.Rows.Count;
                 bulkCopy.WriteToServer(dt);
             }
             catch (Exception ex)
             {
                 ErrorLog.WriteError(ex.ToString());
                 throw ex;
             }
             return true;
         }*/

        public DataTable SelectValue(string antID)
        {
            using (SqlConnection connection = new SqlConnection(sourecstr))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter myDataAdapter = new SqlDataAdapter("select distinct  * from Epcs where antID=" + antID, connection);
                    DataSet myDataSet = new DataSet();
                    myDataAdapter.Fill(myDataSet, "Epcs");
                    DataTable myTable = myDataSet.Tables["Epcs"];
                    connection.Close();
                  //  myDataAdapter.Dispose();
                    return myTable;
                }
                catch (Exception ex)
                {
                    ErrorLog.WriteError(ex.ToString());
                    connection.Close();
                    throw ex;
                }

            }

        }

        //通用查询方法
        /*
         * cmd：查询命令
         * type：表格名称
         * */
        public static DataTable SelectValuebyCondition(string cmd,string name)
        {
            using (SqlConnection connection = new SqlConnection(sourecstr))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter myDataAdapter = new SqlDataAdapter(cmd, connection);
                    DataSet myDataSet = new DataSet();
                    myDataAdapter.Fill(myDataSet, name);
                    DataTable myTable = myDataSet.Tables[name];
                    connection.Close();
                    return myTable;
                }
                    //  myDataAdapter.Dispose();
                catch (Exception ex)
                {
                    ErrorLog.WriteError(ex.ToString());
                    connection.Close();
                    throw ex;
                }

            }
             
        }

        /*  public bool connect(string dataSource)
          {
              try
              {
                  sqlCnt = new SqlConnection(dataSource);
                  sqlCnt.Open();
                  SqlOpenState = true;
              }
              catch (Exception ex)
              {
                  return false;
              }
              return true;
          }*/
        //创建表格  第一个参数为主键
        public bool CreatTables(string tableName, string[] columnHeader)
        {
            /* if (sqlCnt == null || SqlOpenState == false)
             {
                 return false;
             }*/



            string createTablestring = "create table " + tableName + "(";
            for (int index = 0; index < columnHeader.Length; index++)
            {
                createTablestring += columnHeader[index];
                if (index == columnHeader.Length - 1)
                {
                    continue;
                }
                createTablestring += ",";
            }
            createTablestring += ")";
            using (SqlConnection connection = new SqlConnection(sourecstr))
            {
                using (SqlCommand cmd = new SqlCommand(tableName, connection))
                {
                    connection.Open();
                    cmd.CommandText = createTablestring;
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return true;
        }

        //获取指定服务器数据库内所有表格名称
        public static List<string> GetTables()
        {
            using (SqlConnection connection = new SqlConnection(sourecstr))
            {
                List<string> Tables = new List<string>();
                try
                {
                    connection.Open();
                    DataTable dt = connection.GetSchema("Tables");
                    foreach (DataRow row in dt.Rows)
                    {
                        string tableType = (string)row["TABLE_TYPE"];
                        if (tableType.Contains("TABLE"))
                        { Tables.Add(row["TABLE_NAME"].ToString()); }
                    }
                    connection.Close();
                    return Tables;
                }
                catch (Exception ex)
                {
                    ErrorLog.WriteError(ex.ToString());
                    connection.Close();
                    return Tables;
                }


            }

        }

        public bool InsertDataTables(DataTable dt,string tables)
        {
            SqlTransaction tran = null;
            dt.DefaultView.Sort = "time ASC";
            using (SqlConnection connection = new SqlConnection(sourecstr))
            {

                    SqlBulkCopy bulkCopy = new SqlBulkCopy(connection);
                    bulkCopy.DestinationTableName = tables;
                    bulkCopy.BatchSize = dt.Rows.Count;
                    try
                    {
                        connection.Open();
                        bulkCopy.WriteToServer(dt);
                       // tran.Commit();
                        connection.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.WriteError(ex.ToString());
                        connection.Close();
                        return false;
                    }
               
            }
            return true;
        }

        //插入单条数据
        /*  public bool insert(string name, string time, string epc, byte dir, long count, string ip, short rssi, byte antid)
          {
              try
              {
                  using (SqlCommand command = sqlCnt.CreateCommand())
                  {
                      string commandtext = "insert into ";
                      commandtext += name;
                      commandtext += " values ('" + time + "','" + epc + "'," + dir + "," + count.ToString() + ",'" + ip + "'," + rssi + "," + antid + ")";
                      command.CommandText = commandtext;
                      command.ExecuteNonQuery();
                  }
              }
              catch (Exception ex)
              {
                  ErrorLog.WriteError(ex.ToString());
                  throw ex;
              }
              return true;
          }*/

        //插入单条ID数据
        public bool InsertSingleData(string name, string[] values)
        {
            using (SqlConnection connection = new SqlConnection(sourecstr))
            {
                using (SqlCommand cmd = new SqlCommand("Epcs", connection))
                {
                 //   cmd.CommandType = CommandType.StoredProcedure;
                    string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string commandtext = "insert into ";
                    commandtext += name;
                    commandtext += " values ('" + time + "','" + values[0] + "','" + values[1] + "','" + values[2] + "','" + values[3] + "','" + values[4] + "','" + values[5] +
                        "','" + values[6] + "','" + values[7] + "','" + values[8] + "','" + values[9] + "','" + values[10] + "','" + values[11] + "')";
                    cmd.CommandText = commandtext;
                    
                /*    cmd.Parameters.Add("@time", time);
                    cmd.Parameters.Add("@devID", values[0]);
                    cmd.Parameters.Add("@types", values[1]);
                    cmd.Parameters.Add("@error", values[2]);
                    cmd.Parameters.Add("@sign", values[3]);
                    cmd.Parameters.Add("@antID", values[4]);
                    cmd.Parameters.Add("@EPC", values[5]);
                    cmd.Parameters.Add("@PC", values[6]);
                    cmd.Parameters.Add("@RSSI", values[7]);
                    cmd.Parameters.Add("@intervaltime", values[8]);
                    cmd.Parameters.Add("@direction", values[9]);
                    cmd.Parameters.Add("@ClientIP", values[10]);
                    cmd.Parameters.Add("@count", values[11]);*/
                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.WriteError(ex.ToString());
                        connection.Close();
                        throw ex;
                        return false;
                    }
                }
            }

        }
        /// <summary>
        /// 插入Command
        /// </summary>
        /// <param name="name"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool InsertCommand(string name, string[] values)
        {
            using (SqlConnection connection = new SqlConnection(sourecstr))
            {
                using (SqlCommand cmd = new SqlCommand("Epcs", connection))
                {
                    string commandtext = "insert into ";
                    commandtext += (name+"('");
                    for (int index = 0; index < values.Length; index++)
                    {
                        if (index != (values.Length - 1))
                        {
                            commandtext += values[index] + "','";
                        }
                        else
                        {
                            commandtext += (values[index]+"')");
                        }
                    }
                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.WriteError(ex.ToString());
                        connection.Close();
                        throw ex;
                        return false;
                    }

                }
            }
        }

        public string[] SQLComamndFormat(string[] headname, string[] attribute, string[] isnull)
        {
            string[] fixColums = new string[headname.Length];
            if ((headname.Length == attribute.Length) && (headname.Length == isnull.Length))         //元素个数要要一致 第一个元素做为主键
            {

                for (int index = 0; index < fixColums.Length; index++)
                {
                    fixColums[index] = headname[index] + " " + attribute[index] + " " + isnull[index];
                }
            }
            return fixColums;
        }

        //删除表中所有数据
        public bool DeleteAll(string tablename)
        {
            using (SqlConnection connection = new SqlConnection(sourecstr))
            {
                using (SqlCommand cmd = new SqlCommand(tablename, connection))
                {
                    try
                    {
                        connection.Open();
                        string commandtext = "delete " + tablename;
                        cmd.CommandText = commandtext;
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.WriteError(ex.ToString());
                        connection.Close();
                        throw ex;
                        return false;
                    }
                }
            }
        }
        //关闭连接 销毁资源
        /*   public bool closesql()
           {
               sqlCnt.Close();
               SqlOpenState = false;
               return true;
           }*/



    }
}
