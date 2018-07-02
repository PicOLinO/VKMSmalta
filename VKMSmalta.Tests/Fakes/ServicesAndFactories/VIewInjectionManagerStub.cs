using System;
using System.Collections.Generic;
using DevExpress.Mvvm;
using VKMSmalta.Services.Navigate;

namespace VKMSmalta.Tests.Fakes.ServicesAndFactories
{
    public class VIewInjectionManagerStub : IViewInjectionManager
    {
        public Dictionary<string, object> CurrentPages;

        public List<InnerRegionPage> InjectedInnerPages;
        public List<OuterRegionPages> InjectedOuterPages;

        public VIewInjectionManagerStub()
        {
            InjectedInnerPages = new List<InnerRegionPage>();
            InjectedOuterPages = new List<OuterRegionPages>();
            CurrentPages = new Dictionary<string, object>
                           {
                               {Regions.InnerRegion, null},
                               {Regions.OuterRegion, null}
                           };
        }

        public void RegisterService(IViewInjectionService service)
        {
            
        }

        public void UnregisterService(IViewInjectionService service)
        {
            
        }

        public IViewInjectionService GetService(string regionName)
        {
            return null;
        }

        public void Inject(string regionName, object key, Func<object> viewModelFactory, string viewName, Type viewType)
        {
            switch (key)
            {
                case InnerRegionPage innerPage:
                    InjectedInnerPages.Add(innerPage);
                    break;
                case OuterRegionPages outerPage:
                    InjectedOuterPages.Add(outerPage);
                    break;
            }
        }

        public void Remove(string regionName, object key)
        {
            switch (key)
            {
                case InnerRegionPage innerPage:
                    InjectedInnerPages.Remove(innerPage);
                    break;
                case OuterRegionPages outerPage:
                    InjectedOuterPages.Remove(outerPage);
                    break;
            }
        }

        public void Navigate(string regionName, object key)
        {
            CurrentPages[regionName] = key;
        }

        public void RegisterNavigatedEventHandler(object viewModel, Action eventHandler)
        {
            
        }

        public void RegisterNavigatedAwayEventHandler(object viewModel, Action eventHandler)
        {
            
        }

        public void RegisterViewModelClosingEventHandler(object viewModel, Action<ViewModelClosingEventArgs> eventHandler)
        {
            
        }

        public void UnregisterNavigatedEventHandler(object viewModel, Action eventHandler = null)
        {
            
        }

        public void UnregisterNavigatedAwayEventHandler(object viewModel, Action eventHandler = null)
        {
            
        }

        public void UnregisterViewModelClosingEventHandler(object viewModel, Action<ViewModelClosingEventArgs> eventHandler = null)
        {
            
        }

        public void RaiseNavigatedEvent(object viewModel)
        {
        }

        public void RaiseNavigatedAwayEvent(object viewModel)
        {
        }

        public void RaiseViewModelClosingEvent(ViewModelClosingEventArgs e)
        {
            
        }
    }
}