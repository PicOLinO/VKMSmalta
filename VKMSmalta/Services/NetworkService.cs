using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
            var response =  await SendPostRequestCore(adminUri.AdminAuthorizeUri, credential);
            if (response.IsSuccessStatusCode)
            {
                var responseContentJson = await response.Content.ReadAsStringAsync();
                var responseContent = JsonConvert.DeserializeObject<AuthorizeResponseDto>(responseContentJson);
                accessToken = responseContent.token;
                return true;
            }

            return false;
        }

        public async Task<bool> Register(RegisterDataDto registerData)
        {
            var response = await SendPostRequestCore(adminUri.AdminRegisterUri, registerData);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            
            return false;
        }

        public async Task SendExamineResultToAdmin(ExamineResult examineResult)
        {
            await SendPostRequestCore(adminUri.AdminAddHistoryUri, examineResult, true);
        }

        public async Task<IEnumerable<TeamWithStudentsWithoutLoginsDto>> GetTeamsAndStudentsWithoutLogin()
        {
            var response = await SendGetRequestCore(adminUri.AdminGetFreeStudentsUri);
            if (response.IsSuccessStatusCode)
            {
                var responseContentJson = await response.Content.ReadAsStringAsync();
                var responseContent = JsonConvert.DeserializeObject<IEnumerable<TeamWithStudentsWithoutLoginsDto>>(responseContentJson);
                return responseContent;
            }

            throw new Exception("Ошибка на сервере");
        }

        private async Task<HttpResponseMessage> SendGetRequestCore(string uri, bool authorize = false)
        {
            using (var httpClient = new HttpClient())
            {
                if (authorize)
                {
                    if (string.IsNullOrEmpty(accessToken))
                    {
                        throw new Exception("Вы не авторизованы в системе");
                    }

                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }

                httpClient.Timeout = TimeSpan.FromSeconds(10);

                var response = await httpClient.GetAsync(uri);
                return response;
            }
        }

        private async Task<HttpResponseMessage> SendPostRequestCore(string uri, object content, bool authorize = false)
        {
            using (var httpClient = new HttpClient())
            {
                if (authorize)
                {
                    if (string.IsNullOrEmpty(accessToken))
                    {
                        throw new Exception("Вы не авторизованы в системе");
                    }

                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }

                httpClient.Timeout = TimeSpan.FromSeconds(10);

                var json = JsonConvert.SerializeObject(content);
                var body = new StringContent(json, Encoding.UTF8, "application/json");
                
                var response = await httpClient.PostAsync(uri, body);
                return response;
                
            }
        }
    }
}