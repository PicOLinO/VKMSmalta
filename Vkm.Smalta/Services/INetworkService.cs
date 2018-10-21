#region Usings

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Vkm.ComplexSim.Domain;
using Vkm.ComplexSim.Network;

#endregion

namespace Vkm.ComplexSim.Services
{
    public interface INetworkService
    {
        Task<Student> Authorize(NetworkCredential credential);
        Task<IEnumerable<TeamWithStudentsWithoutLoginsDto>> GetTeamsAndStudentsWithoutLogin();
        Task<bool> Register(RegisterDataDto registerData);
        Task<bool> SendExamineResultToAdmin(ExamineResult examineResult);
    }
}