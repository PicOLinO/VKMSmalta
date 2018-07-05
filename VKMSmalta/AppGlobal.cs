#region Usings

using Vkm.Smalta.Domain;

#endregion

namespace Vkm.Smalta
{
    public class AppGlobal
    {
        public Student CurrentUser { get; set; }
        public bool IsAuthorized { get; set; }
        public bool IsDebug { get; set; }
    }
}