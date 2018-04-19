using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VKMSmalta.Dialogs.Factories;
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
                var responseContentJson = await response.Content.ReadAsStringAsync();
                var responseContent = JsonConvert.DeserializeObject<AuthorizeResponseDto>(responseContentJson);
                accessToken = responseContent.token;
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

        public async Task SendExamineResultToAdmin(ExamineResult examineResult)
        {
            await SendRequestCore(adminUri.AdminAddHistoryUri, examineResult, true, false);
        }

        private async Task<HttpResponseMessage> SendRequestCore(string uri, object content, bool authorize = false, bool showError = true)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    if (authorize)
                    {
                        if (string.IsNullOrEmpty(accessToken))
                        {
                            throw new Exception("Вы не авторизованы в системе");
                        }

                        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
                    }

                    httpClient.Timeout = TimeSpan.FromSeconds(10);

                    var json = JsonConvert.SerializeObject(content);
                    var body = new StringContent(json, Encoding.UTF8, "application/json");
                
                    var response = await httpClient.PostAsync(uri, body);
                    return response;
                }
                catch (Exception e)
                {
                    if (showError)
                    {
                        DialogFactory.ShowErrorMessage(e);
                    }
                    throw;
                }
            }
        }
    }
}