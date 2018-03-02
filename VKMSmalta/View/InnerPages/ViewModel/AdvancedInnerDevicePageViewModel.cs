using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using VKMSmalta.Services;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View.Elements.ViewModel;
using VKMSmalta.View.InnerPages.ViewModel;

namespace VKMSmalta.View.ViewModel
{
    public class AdvancedInnerDevicePageViewModel : InnerPageViewModelBase
    {
        private readonly HistoryService historyService;

        public AdvancedInnerDevicePageViewModel(HistoryService historyService) : base(InnerRegionPages.Advanced, "View/Images/AdvancedBackground.png")
        {
            this.historyService = historyService;
            InitializeElements(); //TODO: ВЫШЕ!
        }

        private void InitializeElements()
        {
            //TODO: Добавить начальное состояние элементам из CurrentAlgorithm.StartStateOfElements
            Elements = new ObservableCollection<ElementViewModelBase>
                       {
                           //Тумблеры в середине
                           new VkmThumblerViewModel(0, "OLOLO", historyService) { PosTop = 500, PosLeft = 500, StartupRotation = 30 },
                       };
        }
    }
}