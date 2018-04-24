using VKMSmalta.Domain;

namespace VKMSmalta.Network
{
    public class AuthorizeResponseDto
    {
        public string token { get; set; }
        public Student Student { get; set; }
    }
}