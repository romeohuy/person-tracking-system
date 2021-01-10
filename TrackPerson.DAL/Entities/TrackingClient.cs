using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackPerson.DAL.Entities
{
    public class TrackingClient
    {
        public int Id { get; set; }
        public string ClientNo { get; set; }
        public string ClientIP { get; set; }
        public int Port { get; set; }
        public string DeviceID { get; set; }
        public string Status { get; set; }
    }
}
