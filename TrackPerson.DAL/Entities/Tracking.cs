using System;

namespace TrackPerson.DAL.Entities
{
  public class Tracking
    {
        public int Id { get; set; }
        public string Num { get; set; }
        public string AntID { get; set; }
        public string EPC { get; set; }
        public string PC { get; set; }
        public string RSSI { get; set; }
        public string Count { get; set; }
        public string DevID { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string Dir { get; set; }
        public string IsSame { get; set; }
        public string TID { get; set; }
    }
}
