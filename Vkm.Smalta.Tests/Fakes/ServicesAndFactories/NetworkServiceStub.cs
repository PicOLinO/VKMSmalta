using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Network;
using Vkm.Smalta.Services;

namespace Vkm.Smalta.Tests.Fakes.ServicesAndFactories
{
    public class NetworkServiceStub : INetworkService
    {
        public bool BoolDialogResult { get; set; }
        public bool ExamineResultSendedToAdmin { get; private set; }

        public Task<Student> Authorize(NetworkCredential credential)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<TeamWithStudentsWithoutLoginsDto>> GetTeamsAndStudentsWithoutLogin()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Register(RegisterDataDto registerData)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SendExamineResultToAdmin(ExamineResult examineResult)
        {
            ExamineResultSendedToAdmin = true;
            return Task.FromResult(BoolDialogResult);
        }
    }
}