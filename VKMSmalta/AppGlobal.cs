using VKMSmalta.Domain;

namespace VKMSmalta
{
    public class AppGlobal
    {
        public bool IsDebug { get; set; }
        public bool IsAuthorized { get; set; }
        public Student CurrentUser { get; set; }
    }
}