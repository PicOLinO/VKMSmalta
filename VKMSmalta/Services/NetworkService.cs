using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VKMSmalta.Dialogs.ViewModel;
using VKMSmalta.Domain;
using VKMSmalta.Network;

namespace VKMSmalta.Services
{
    public class NetworkService
    {
        private readonly AdminUri adminUri;

        private string accessToken;

        public static NetworkService Instance { get; private set; }

        public static void InitializeService(AdminUri adminUri)
        {
            if (Instance == null)
            {
                Instance = new NetworkService(adminUri);
            }
        }

        private NetworkService(AdminUri adminUri)
        {
            this.adminUri = adminUri;
        }

        public async Task<bool> Authorize(NetworkCredential credential)
        {
            var response =  await SendRequestCore(adminUri.AdminAuthorizeUri, credential);
            if (response.IsSuccessStatusCode)
            {
                //TODO: Save token
                return true;
            }

            return false;
        }

        public async Task<bool> Register(NetworkCredential credential)
        {
            var response = await SendRequestCore(adminUri.AdminRegisterUri, credential);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public void SendExamineResultToAdmin(ExamineResult examineResult)
        {
            throw new NotImplementedException();
        }

        private async Task<HttpResponseMessage> SendRequestCore(string uri, object content)
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(content);
                var body = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(uri, body);
                return response;
            }
        }
    }
}