﻿namespace TrackPerson.DAL.Entities
{
   public class TrackingPerson
    {
        public int Id { get; set; }
        public string HS_CODE { get; set; }
        public string CLASS { get; set; }
        public string EPC { get; set; }
        public string TID { get; set; }
        public string USER { get; set; }
        public string RFU { get; set; }
    }
}