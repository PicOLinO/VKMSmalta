#region Usings

using Vkm.ComplexSim.Domain;

#endregion

namespace Vkm.ComplexSim
{
    public interface IAppContext
    {
        Student CurrentUser { get; set; }
        bool IsAuthorized { get; set; }
        bool IsDebug { get; set; }
    }
}