using System.Windows.Input;

namespace Vkm.Smalta.Services
{
    public class LoadingService : ILoadingService
    {
        public void LoadingOn()
        {
            Mouse.OverrideCursor = Cursors.Wait;
        }

        public void LoadingOff()
        {
            Mouse.OverrideCursor = null;
        }
    }
}