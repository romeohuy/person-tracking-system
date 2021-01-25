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
    public class TrackingPersonPersonDAL
    {
        string connectString = ConfigurationManager.AppSettings["MySqlConnectString"];

        public async Task<List<TrackingPerson>> GetAll()
        {
            using (var connection = new MySqlConnection(connectString))
            {
               var trackingPersons = await connection.GetAllAsync<TrackingPerson>();
               return trackingPersons.ToList();
            }
        }
        public async void Insert(TrackingPerson trackingPerson)
        {
            using (var connection = new MySqlConnection(connectString))
            {
               await connection.InsertAsync(trackingPerson);
            }
        }
        public async void Inserts(List<TrackingPerson> trackingPersons)
        {
            using (var connection = new MySqlConnection(connectString))
            {
               await connection.InsertAsync(trackingPersons);
            }
        }

        public async void Update(TrackingPerson trackingPerson)
        {
            using (var connection = new MySqlConnection(connectString))
            {
               await connection.UpdateAsync(trackingPerson);
            }
        }

        public async Task Updates(List<TrackingPerson> trackingPersons)
        {
            using (var connection = new MySqlConnection(connectString))
            {
               await connection.UpdateAsync(trackingPersons);
            }
        }

        public async Task Delete(TrackingPerson trackingPerson)
        {
            using (var connection = new MySqlConnection(connectString))
            {
               await connection.DeleteAsync(trackingPerson);
            }
        }

    }
}
