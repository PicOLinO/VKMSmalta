#region Usings

using Vkm.Smalta.Domain;

#endregion

namespace Vkm.Smalta
{
    public interface IAppContext
    {
        Student CurrentUser { get; set; }
        bool IsAuthorized { get; set; }
        bool IsDebug { get; set; }
    }
}