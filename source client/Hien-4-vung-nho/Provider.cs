using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SrDemo
{
    public class Provider
    {
        private string connectionSTR = "Data Source=.\\;Initial Catalog=Demo_UHF;Integrated Security=True";

        private static Provider instance;

        public static Provider Instance
        {
            get { if (instance == null) instance = new Provider(); return Provider.instance; }
            private set { Provider.instance = value; }
        }

        private Provider() { }

        public DataTable ExecuteQuery(string sql, object[] paramater = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(sql, connection);

                if (paramater != null)
                {
                    string[] listPara = sql.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(item, paramater[i]);
                            i++;
                        }

                    }
                }


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        public int ExecuteNonQuery(string sql, object[] paramater = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(sql, connection);

                if (paramater != null)
                {
                    string[] listPara = sql.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(item, paramater[i]);
                            i++;
                        }

                    }
                }

                data = cmd.ExecuteNonQuery();
                connection.Close();
            }

            return data;
        }

        public object ExecuteScalar(string sql, object[] paramater = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(sql, connection);

                if (paramater != null)
                {
                    string[] listPara = sql.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(item, paramater[i]);
                            i++;
                        }

                    }
                }

                data = cmd.ExecuteScalar();
                connection.Close();
            }

            return data;
        }
    }
}
