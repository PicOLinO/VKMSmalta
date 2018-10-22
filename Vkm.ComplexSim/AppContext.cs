#region Usings

using Vkm.ComplexSim.Domain;

#endregion

namespace Vkm.ComplexSim
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