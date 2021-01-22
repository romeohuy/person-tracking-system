using System.Collections.Generic;

namespace TrackPerson.Service
{
    public class StudentInfoResponse
    {
        public int hs_id { get; set; }
        public string hs_name { get; set; }
        public string hs_code { get; set; }
        public string hs_class { get; set; }
        public object card_id { get; set; }
        public object card_code { get; set; }
        public object card_name { get; set; }
    }

    public class MetaResponse
    {
        public int total { get; set; }
        public int page { get; set; }
        public int totalPage { get; set; }
        public int pageSize { get; set; }
        public int from { get; set; }
        public int to { get; set; }
        public object next { get; set; }
        public object prev { get; set; }
    }

    public class ListStudentsResponse
    {
        public MetaResponse MetaResponse { get; set; }
        public List<StudentInfoResponse> data { get; set; }
    }
}
