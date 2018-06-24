#region Usings

using System.Net;

#endregion

namespace VKMSmalta.Network
{
    public class RegisterDataDto
    {
        public NetworkCredential Credential { get; set; }
        public int StudentId { get; set; }
    }
}