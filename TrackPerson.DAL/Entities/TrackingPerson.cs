using System.ComponentModel;

namespace TrackPerson.DAL.Entities
{
   public class TrackingPerson
    {
        [DisplayName("STT")]
        public int Id { get; set; }
        [DisplayName("Mã HS")]
        public string HS_CODE { get; set; }
        [DisplayName("Tên HS")]
        public string USER { get; set; }
        [DisplayName("Lớp")]
        public string CLASS { get; set; }
        [DisplayName("Mã HS")]
        public string EPC { get; set; }
        //public string TID { get; set; }
        //public string RFU { get; set; }
    }
}
