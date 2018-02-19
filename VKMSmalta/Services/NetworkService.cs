using System;
using VKMSmalta.Domain;

namespace VKMSmalta.Services
{
    public class NetworkService
    {
        private string user;
        private string password;

        private string adminMachineUrl;

        public static NetworkService Instance { get; protected set; }

        public static void InitializeService(string user, string password, string adminMachineUrl)
        {
            if (Instance == null)
            {
                Instance = new NetworkService(user, password, adminMachineUrl);
            }
        }

        public NetworkService(string user, string password, string adminMachineUrl)
        {
            this.user = user;
            this.password = password;
            this.adminMachineUrl = adminMachineUrl;
        }

        public void Authorize()
        {
            throw new NotImplementedException();
        }

        public void SendExamineResultToAdmin(ExamineResult examineResult)
        {
            throw new NotImplementedException();
        }
    }
}