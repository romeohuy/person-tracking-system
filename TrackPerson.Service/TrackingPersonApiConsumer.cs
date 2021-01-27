using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace TrackPerson.Service
{
    public class TrackingPersonApiConsumer
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(typeof(TrackingPersonApiConsumer));
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
                _logger.Error("Lỗi kết nối api:" + result.Content);
                throw new Exception("Lỗi kết nối api:" + result.Content);
            }
        }

        public List<StudentInfoResponse> GetListStudents()
        {
            var listStudents = new List<StudentInfoResponse>();
            var token = GetToken();
            if (!string.IsNullOrEmpty(token))
            {
                var client = new RestClient();
                var page = 1;
                while (true)
                {
                     var request = new RestRequest(new Uri(Path.Combine(_rootApi, $"customer-child?page={page}")), Method.GET);
                    request.AddHeader("Authorization", $"Bearer {token}");
                    try
                    {
                        var result = client.Execute<ListStudentsResponse>(request);
                        if (result.IsSuccessful)
                        {
                            _logger.Info($"Get students page {page}: {JsonConvert.SerializeObject(request)}");
                            listStudents.AddRange(result.Data.data);
                        }
                        if (string.IsNullOrEmpty(result.Data.meta.next))
                        {
                            break;
                        }

                    }
                    catch (Exception)
                    {
                        break;
                    }
                    page++;
                }
                _logger.Info($"Get students api: Count {listStudents.Count}");
                return listStudents;
            }

            _logger.Error("Token trống");
            return new List<StudentInfoResponse>();
        }
        public BaseApiResponse PutRegisterStudentCard(string hs_code, string hs_name, string card_code, string hs_class)
        {
            var token = GetToken();
            if (!string.IsNullOrEmpty(token))
            {
                var client = new RestClient();

                var request = new RestRequest(new Uri(Path.Combine(_rootApi, "customer-child/card-new-submit")), Method.POST, DataFormat.Json);
                request.AddHeader("Authorization", $"Bearer {token}");
                request.AddJsonBody(new
                {
                    hs_code,
                    hs_name,
                    card_code,
                    hs_class
                }, "application/json; charset=utf-8");

                var result = client.Execute<BaseApiResponse>(request);
                _logger.Info($"Regist students: {JsonConvert.SerializeObject(request)}");
                return result.Data;
            }
            _logger.Error("Token trống");
            return new BaseApiResponse() { message = "Token trống" };
        }
        public BaseApiResponse XinVoTre(string epc)
        {
            var token = GetToken();
            if (!string.IsNullOrEmpty(token))
            {
                var client = new RestClient();

                var request = new RestRequest(new Uri(Path.Combine(_rootApi, "customer-child/in-request")), Method.POST, DataFormat.Json);
                request.AddHeader("Authorization", $"Bearer {token}");
                request.AddJsonBody(new
                {
                    antID = 0,
                    epc,
                    devId = 0,
                    LastTime = DateTime.Now
                }, "application/json; charset=utf-8");

                var result = client.Execute<BaseApiResponse>(request);
                _logger.Info($"Regist students: {JsonConvert.SerializeObject(request)}");
                return result.Data;
            }
            _logger.Error("Token trống");
            return new BaseApiResponse(){ message = "Token trống"};
        }

        public BaseApiResponse XinVeSom(string epc)
        {
            var token = GetToken();
            if (!string.IsNullOrEmpty(token))
            {
                var client = new RestClient();

                var request = new RestRequest(new Uri(Path.Combine(_rootApi, "customer-child/out-request")), Method.POST, DataFormat.Json);
                request.AddHeader("Authorization", $"Bearer {token}");
                request.AddJsonBody(new
                {
                    antID = 0,
                    epc,
                    devId = 0,
                    LastTime = DateTime.Now
                }, "application/json; charset=utf-8");

                var result = client.Execute<BaseApiResponse>(request);
                _logger.Info($"Regist students: {JsonConvert.SerializeObject(request)}");
                return result.Data;
            }
            _logger.Error("Token trống");
            return new BaseApiResponse() { message = "Token trống" };
        }
    }
}
