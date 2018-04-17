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
            return await SendRequestCore(adminUri.AdminAuthorizeUri, credential);
        }

        public async Task<bool> Register(NetworkCredential credential)
        {
            return await SendRequestCore(adminUri.AdminRegisterUri, credential);
        }

        public void SendExamineResultToAdmin(ExamineResult examineResult)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> SendRequestCore(string uri, object content)
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(content);
                var body = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(uri, body);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
        }
    }
}