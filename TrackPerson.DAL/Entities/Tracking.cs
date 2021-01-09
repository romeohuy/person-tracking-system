using System;

namespace TrackPerson.DAL.Entities
{
  public class Tracking
    {
        public int Id { get; set; }
        public string TrackingId { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
    }
}
