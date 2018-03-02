using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View.Elements.ViewModel;
using VKMSmalta.View.InnerPages.ViewModel;

namespace VKMSmalta.View.ViewModel
{
    public class AdvancedInnerDevicePageViewModel : InnerPageViewModelBase
    {
        public AdvancedInnerDevicePageViewModel() : base(InnerRegionPages.Advanced, "View/Images/AdvancedBackground.png")
        {
            InitializeElements(); //TODO: ВЫШЕ!
        }

        private void InitializeElements()
        {
            //TODO: Добавить начальное состояние элементам из CurrentAlgorithm.StartStateOfElements
            Elements = new ObservableCollection<ElementViewModelBase>
                       {
                           //Тумблеры в середине
                           new VkmThumblerViewModel(0, "OLOLO") { PosTop = 500, PosLeft = 500, StartupRotation = 30 },
                       };
        }
    }
}