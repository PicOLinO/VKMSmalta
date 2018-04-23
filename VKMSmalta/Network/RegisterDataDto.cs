using System.Net;

namespace VKMSmalta.Network
{
    public class RegisterDataDto
    {
        public NetworkCredential Credential { get; set; }
        public int StudentId { get; set; }
    }
}