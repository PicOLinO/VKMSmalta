using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Network;

namespace Vkm.Smalta.Services
{
    public interface INetworkService
    {
        Task<Student> Authorize(NetworkCredential credential);
        Task<IEnumerable<TeamWithStudentsWithoutLoginsDto>> GetTeamsAndStudentsWithoutLogin();
        Task<bool> Register(RegisterDataDto registerData);
        Task<bool> SendExamineResultToAdmin(ExamineResult examineResult);
    }
}