using System.Collections.Generic;

namespace TrackPerson.Service
{
    public class StudentInfoResponse
    {
        public int hs_id { get; set; }
        public string hs_name { get; set; }
        public string hs_code { get; set; }
        public string hs_class { get; set; }
        public string card_id { get; set; }
        public string card_code { get; set; }
        public string card_name { get; set; }
    }

    public class MetaResponse
    {
        public int total { get; set; }
        public int page { get; set; }
        public int totalPage { get; set; }
        public int pageSize { get; set; }
        public int from { get; set; }
        public int to { get; set; }
        public string next { get; set; }
        public string prev { get; set; }
    }

    public class ListStudentsResponse
    {
        public MetaResponse meta { get; set; }
        public List<StudentInfoResponse> data { get; set; }
    }
}
