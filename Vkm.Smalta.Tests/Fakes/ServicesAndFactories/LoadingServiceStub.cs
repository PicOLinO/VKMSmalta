#region Usings

using Vkm.Smalta.Services;

#endregion

namespace Vkm.Smalta.Tests.Fakes.ServicesAndFactories
{
    public class LoadingServiceStub : ILoadingService
    {
        public bool IsLoadingOn { get; private set; }

        #region ILoadingService

        public void LoadingOff()
        {
            IsLoadingOn = false;
        }

        public void LoadingOn()
        {
            IsLoadingOn = true;
        }

        #endregion
    }
}