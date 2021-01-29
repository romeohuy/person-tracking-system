using System.Collections.Generic;
using System.Linq;
using TrackPerson.DAL.Entities;
using TrackPerson.Service;

namespace SrDemo.Helpers
{
    public static class ModelHelper
    {
        public static List<TrackingPerson> ToTrackingPersons(List<StudentInfoResponse> studentsResponse)
        {
            if (studentsResponse != null)
            {
                return studentsResponse.Select(st => new TrackingPerson()
                {
                    Id = st.hs_id,
                    HS_CODE = st.hs_code,
                    CLASS = st.hs_class,
                    EPC = st.card_code,
                    USER = st.hs_name
                }).OrderBy(_ => _.Id).ToList();
            }
            else
            {
                return new List<TrackingPerson>();
            }
        }
    }
}
