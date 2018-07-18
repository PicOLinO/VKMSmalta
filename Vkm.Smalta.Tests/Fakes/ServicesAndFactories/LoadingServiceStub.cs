using Vkm.Smalta.Services;

namespace Vkm.Smalta.Tests.Fakes.ServicesAndFactories
{
    public class LoadingServiceStub : ILoadingService
    {
        public bool IsLoadingOn { get; private set; }

        public void LoadingOn()
        {
            IsLoadingOn = true;
        }

        public void LoadingOff()
        {
            IsLoadingOn = false;
        }
    }
}