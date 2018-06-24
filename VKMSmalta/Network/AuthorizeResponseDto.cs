#region Usings

using VKMSmalta.Domain;

#endregion

namespace VKMSmalta.Network
{
    public class AuthorizeResponseDto
    {
        public Student Student { get; set; }
        public string token { get; set; }
    }
}