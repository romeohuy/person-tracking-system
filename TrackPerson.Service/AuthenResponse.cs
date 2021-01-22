namespace TrackPerson.Service
{
    public class AuthenResponse
    {
        public string id_user { get; set; }
        public string username { get; set; }
        public string access_token { get; set; }
        public string email { get; set; }
    }
}
