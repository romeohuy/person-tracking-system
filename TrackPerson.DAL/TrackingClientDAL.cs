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
    public class TrackingClientDAL
    {
        readonly string _connectString = ConfigurationManager.AppSettings["MySqlConnectString"];

        public async Task<List<TrackingClient>> GetAllClients()
        {
            using (var connect = new MySqlConnection(_connectString))
            {
                var trackingClients = (await connect.GetAllAsync<TrackingClient>()).ToList();
                return trackingClients;
            }
        }

        public async Task Insert(TrackingClient client)
        {
            using (var connection = new MySqlConnection())
            {
               await connection.InsertAsync(client);
            }
        }
        public async Task Update(TrackingClient client)
        {
            using (var connection = new MySqlConnection())
            {
               await connection.UpdateAsync(client);
            }
        }
        public async Task Delete(TrackingClient client)
        {
            using (var connection = new MySqlConnection())
            {
               await connection.DeleteAsync(client);
            }
        }
    }
}
