#region Usings

using VKMSmalta.Domain;

#endregion

namespace VKMSmalta
{
    public class AppGlobal
    {
        public Student CurrentUser { get; set; }
        public bool IsAuthorized { get; set; }
        public bool IsDebug { get; set; }
    }
}