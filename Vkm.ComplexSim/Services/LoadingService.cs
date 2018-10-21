#region Usings

using System.Windows.Input;

#endregion

namespace Vkm.ComplexSim.Services
{
    public class LoadingService : ILoadingService
    {
        #region ILoadingService

        public void LoadingOff()
        {
            Mouse.OverrideCursor = null;
        }

        public void LoadingOn()
        {
            Mouse.OverrideCursor = Cursors.Wait;
        }

        #endregion
    }
}