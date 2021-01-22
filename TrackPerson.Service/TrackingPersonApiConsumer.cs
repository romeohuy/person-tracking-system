using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Configuration;
using System.IO;

namespace TrackPerson.Service
{
    public class TrackingPersonApiConsumer
    {
        private string _rootApi;
        private string _userName;
        private string _password;
        public TrackingPersonApiConsumer()
        {
            _rootApi = ConfigurationManager.AppSettings["RootApi"];
            _userName = ConfigurationManager.AppSettings["UserNameApi"];
            _password = ConfigurationManager.AppSettings["PasswordApi"];
        }

        private string GetToken()
        {
            var client = new RestClient();
            var request = new RestRequest(new Uri(Path.Combine(_rootApi, "auth")), Method.GET);
            client.Authenticator = new HttpBasicAuthenticator(_userName, _password);
            var result = client.Execute(request);
            if (result.IsSuccessful)
            {
                var authResponse = JsonConvert.DeserializeObject<AuthenResponse>(result.Content);
                return authResponse.access_token;
            }
            else
            {
                throw new Exception("Lỗi kết nối api:" + result.Content);
            }
        }

        public ListStudentsResponse GetListStudents()
        {
            var token = GetToken();
            if (!string.IsNullOrEmpty(token))
            {
                var client = new RestClient();

                var request = new RestRequest(new Uri(Path.Combine(_rootApi, "customer-child/")), Method.GET);
                request.AddHeader("Authorization", $"Bearer {token}");
                var result = client.Execute<ListStudentsResponse>(request);
                if (result.IsSuccessful)
                {
                    return result.Data;
                }
            }

            throw new Exception("Token trống");
        }
        public RegisterStudentResponse PutRegisterStudentCard(string hs_id, string card_code)
        {
            var token = GetToken();
            if (!string.IsNullOrEmpty(token))
            {
                var client = new RestClient();

                var request = new RestRequest(new Uri(Path.Combine(_rootApi, "customer-child/card-submit")), Method.POST, DataFormat.Json);
                request.AddHeader("Authorization", $"Bearer {token}");
                request.AddJsonBody(new
                {
                    hs_id,
                    card_code
                }, "application/json; charset=utf-8");

                var result = client.Execute<RegisterStudentResponse>(request);
                if (result.IsSuccessful)
                {
                    return result.Data;
                }
            }

            throw new Exception("Token trống");
        }
    }
}
