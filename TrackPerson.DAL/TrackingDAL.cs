using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using TrackPerson.DAL.Entities;

namespace TrackPerson.DAL
{
    public class TrackingDAL
    {
        string connectString = ConfigurationManager.AppSettings["MySqlConnectString"];

        public async void Insert(Tracking tracking)
        {
            using (var connection = new MySqlConnection(connectString))
            {
               await connection.OpenAsync();
               await connection.InsertAsync(tracking);
            }
        }
        public async void Inserts(List<Tracking> trackings)
        {
            using (var connection = new MySqlConnection(connectString))
            {
               await connection.OpenAsync();
               await connection.InsertAsync(trackings);
            }
        }

        public async void Update(Tracking tracking)
        {
            using (var connection = new MySqlConnection(connectString))
            {
               await connection.OpenAsync();
               await connection.UpdateAsync(tracking);
            }
        }

        public async Task Updates(List<Tracking> trackings)
        {
            using (var connection = new MySqlConnection(connectString))
            {
               await connection.OpenAsync();
               await connection.UpdateAsync(trackings);
            }
        }

        public async Task Delete(Tracking tracking)
        {
            using (var connection = new MySqlConnection(connectString))
            {
               await connection.OpenAsync();
               await connection.DeleteAsync(tracking);
            }
        }

    }
}
