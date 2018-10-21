#region Usings

using Vkm.ComplexSim.Domain;

#endregion

namespace Vkm.ComplexSim.Network
{
    public class AuthorizeResponseDto
    {
        public Student Student { get; set; }
        public string token { get; set; }
    }
}