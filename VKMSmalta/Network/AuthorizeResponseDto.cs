#region Usings

using Vkm.Smalta.Domain;

#endregion

namespace Vkm.Smalta.Network
{
    public class AuthorizeResponseDto
    {
        public Student Student { get; set; }
        public string token { get; set; }
    }
}