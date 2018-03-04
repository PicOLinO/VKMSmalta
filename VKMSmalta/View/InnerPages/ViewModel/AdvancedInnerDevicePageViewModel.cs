using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using VKMSmalta.Services;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View.Elements.ViewModel;
using VKMSmalta.View.InnerPages.ViewModel;

namespace VKMSmalta.View.ViewModel
{
    public class AdvancedInnerDevicePageViewModel : InnerPageViewModelBase //TODO: Убрать этот класс. Они одинаковые с MainInner...VM. Определить идентификатор для VM и навигироваться по нему.
    {
        private readonly HistoryService historyService;

        public AdvancedInnerDevicePageViewModel(HistoryService historyService) : base(InnerRegionPages.Advanced, "/VKMSmalta;component/View/Images/Backgrounds/L001R.png")
        {
            this.historyService = historyService;
            InitializeElements();
        }

        private void InitializeElements()
        {
            //TODO: Добавить начальное состояние элементам из CurrentAlgorithm.StartStateOfElements
            Elements = new ObservableCollection<ElementViewModelBase>
                       {
                           //Настроить позиционирование
                           GiveMe.Element().WithValue(0).WithName("adv_reciever_1channel").At(315,535).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("adv_reciever_2channel").At(360,535).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("adv_reciever_3channel").At(405,535).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("adv_reciever_4channel").At(449,535).Thumbler(historyService).Please(),

                           GiveMe.Element().WithValue(0).WithName("adv_transmitter_1channel").At(315,535).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("adv_transmitter_2channel").At(360,535).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("adv_transmitter_3channel").At(405,535).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("adv_transmitter_4channel").At(449,535).Thumbler(historyService).Please(),

                           GiveMe.Element().WithValue(0).WithName("adv_antenna_equal").At(449,535).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("adv_modulation").At(449,535).WithStartupRotation(35).RotateWheel(historyService)
                                 .WithMaxValue(5).WithRotationStepDegrees(35).Please(),
                       };
        }
    }
}