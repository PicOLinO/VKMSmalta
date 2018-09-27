#region Usings

using Vkm.Smalta.Domain;

#endregion

namespace Vkm.Smalta
{
    public class AppContext : IAppContext
    {
        #region IAppContext

        public Student CurrentUser { get; set; }
        public bool IsAuthorized { get; set; }
        public bool IsDebug { get; set; }

        #endregion
    }
}