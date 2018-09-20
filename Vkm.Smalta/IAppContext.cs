using Vkm.Smalta.Domain;

namespace Vkm.Smalta
{
    public interface IAppContext
    {
        Student CurrentUser { get; set; }
        bool IsAuthorized { get; set; }
        bool IsDebug { get; set; }
    }
}