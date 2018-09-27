#region Usings

using System;
using System.Collections.Generic;
using DevExpress.Mvvm;
using Vkm.Smalta.Services.Navigate;
using Vkm.Smalta.View.InnerPages.ViewModel;
using Vkm.Smalta.View.ViewModel;

#endregion

namespace Vkm.Smalta.Tests.Fakes.ServicesAndFactories
{
    public class ViewInjectionManagerStub : IViewInjectionManager
    {
        public readonly Dictionary<string, object> CurrentPages;

        public readonly Dictionary<SmaltaInnerRegionPage, InnerPageViewModelBase> InjectedInnerPages;
        public readonly Dictionary<OuterRegionPages, DevicePageViewModel> InjectedOuterPages;

        public ViewInjectionManagerStub()
        {
            InjectedInnerPages = new Dictionary<SmaltaInnerRegionPage, InnerPageViewModelBase>();
            InjectedOuterPages = new Dictionary<OuterRegionPages, DevicePageViewModel>();
            CurrentPages = new Dictionary<string, object>
                           {
                               {Regions.InnerRegion, null},
                               {Regions.OuterRegion, null}
                           };
        }

        #region IViewInjectionManager

        public IViewInjectionService GetService(string regionName)
        {
            return null;
        }

        public void Inject(string regionName, object key, Func<object> viewModelFactory, string viewName, Type viewType)
        {
            switch (key)
            {
                case SmaltaInnerRegionPage innerPage:
                    if (!InjectedInnerPages.ContainsKey(innerPage))
                    {
                        InjectedInnerPages.Add(innerPage, (InnerPageViewModelBase) viewModelFactory.Invoke());
                    }

                    break;
                case OuterRegionPages outerPage:
                    if (!InjectedOuterPages.ContainsKey(outerPage))
                    {
                        InjectedOuterPages.Add(outerPage, (DevicePageViewModel) viewModelFactory.Invoke());
                    }

                    break;
            }
        }

        public void Navigate(string regionName, object key)
        {
            CurrentPages[regionName] = key;
        }

        public void RaiseNavigatedAwayEvent(object viewModel)
        {
        }

        public void RaiseNavigatedEvent(object viewModel)
        {
        }

        public void RaiseViewModelClosingEvent(ViewModelClosingEventArgs e)
        {
        }

        public void RegisterNavigatedAwayEventHandler(object viewModel, Action eventHandler)
        {
        }

        public void RegisterNavigatedEventHandler(object viewModel, Action eventHandler)
        {
        }

        public void RegisterService(IViewInjectionService service)
        {
        }

        public void RegisterViewModelClosingEventHandler(object viewModel, Action<ViewModelClosingEventArgs> eventHandler)
        {
        }

        public void Remove(string regionName, object key)
        {
            switch (key)
            {
                case SmaltaInnerRegionPage innerPage:
                    InjectedInnerPages.Remove(innerPage);
                    break;
                case OuterRegionPages outerPage:
                    InjectedOuterPages.Remove(outerPage);
                    break;
            }
        }

        public void UnregisterNavigatedAwayEventHandler(object viewModel, Action eventHandler = null)
        {
        }

        public void UnregisterNavigatedEventHandler(object viewModel, Action eventHandler = null)
        {
        }

        public void UnregisterService(IViewInjectionService service)
        {
        }

        public void UnregisterViewModelClosingEventHandler(object viewModel, Action<ViewModelClosingEventArgs> eventHandler = null)
        {
        }

        #endregion
    }
}