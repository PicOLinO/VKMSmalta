using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using VKMSmalta.Domain;
using VKMSmalta.Services;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View.DSL;
using VKMSmalta.View.Elements.ViewModel;
using VKMSmalta.View.InnerPages.ViewModel;

namespace VKMSmalta.View.ViewModel
{
    public class MainInnerDevicePageViewModel : InnerPageViewModelBase
    {
        private readonly HistoryService historyService;

        public MainInnerDevicePageViewModel(HistoryService historyService) : base(InnerRegionPages.Main, "/VKMSmalta;component/View/Images/Backgrounds/L001P.png")
        {
            this.historyService = historyService;
            InitializeElements();  //TODO: ВЫШЕ!
        }

        private void InitializeElements()
        {
            //TODO: Добавить начальное состояние элементам из CurrentAlgorithm.StartStateOfElements
            Elements = new ObservableCollection<ElementViewModelBase>
                       {
                           //Тумблеры в середине
                           GiveMe.Element().WithValue(0)
                                        .WithName("main_thumbler_1channel")
                                        .WithStartupRotation(90)
                                        .At(280,341)
                                        .Thumbler(historyService)
                                            .WithDependencyAction(new DependencyAction("main_reciever_1channel", new Dictionary<int, int>
                                                                                                            {
                                                                                                                { 0, 0 },
                                                                                                                { 1, 1 }
                                                                                                            }))
                                        .Please(),
                           GiveMe.Element().WithValue(0).WithName("main_thumbler_2channel").WithStartupRotation(90).At(323,340).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("main_thumbler_3channel").WithStartupRotation(90).At(367,341).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("main_thumbler_4channel").WithStartupRotation(90).At(411,341).Thumbler(historyService).Please(),

                           //Подсветка в середине
                           GiveMe.Element().WithValue(1).WithName("main_reciever_1channel").At(309,540).LightBox().Please(),
                           GiveMe.Element().WithValue(1).WithName("main_reciever_2channel").At(353,540).LightBox().Please(),
                           GiveMe.Element().WithValue(1).WithName("main_reciever_3channel").At(396,540).LightBox().Please(),
                           GiveMe.Element().WithValue(1).WithName("main_reciever_4channel").At(441,541).LightBox().Please(),
                           GiveMe.Element().WithValue(1).WithName("main_antenna_leftside").At(483,540).LightBox().Please(),

                           GiveMe.Element().WithValue(1).WithName("main_transmitter_1channel").At(309,628).LightBox().Please(),
                           GiveMe.Element().WithValue(1).WithName("main_transmitter_2channel").At(353,628).LightBox().Please(),
                           GiveMe.Element().WithValue(1).WithName("main_transmitter_3channel").At(396,628).LightBox().Please(),
                           GiveMe.Element().WithValue(1).WithName("main_transmitter_4channel").At(441,627).LightBox().Please(),
                           GiveMe.Element().WithValue(1).WithName("main_antenna_rightside").At(484,627).LightBox().Please(),

                           GiveMe.Element().WithValue(1).WithName("main_defect_1channel").At(311,715).LightBox().Please(),
                           GiveMe.Element().WithValue(1).WithName("main_defect_2channel").At(354,715).LightBox().Please(),
                           GiveMe.Element().WithValue(1).WithName("main_defect_3channel").At(396,714).LightBox().Please(),
                           GiveMe.Element().WithValue(1).WithName("main_defect_4channel").At(441,714).LightBox().Please(),
                           GiveMe.Element().WithValue(1).WithName("main_1cooler").At(484,714).LightBox().Please(),

                           GiveMe.Element().WithValue(1).WithName("main_glow_on").At(310,802).LightBox().Please(),
                           GiveMe.Element().WithValue(1).WithName("main_simulator").At(353,802).LightBox().Please(),
                           GiveMe.Element().WithValue(1).WithName("main_modulation").At(441,801).LightBox().Please(),
                           GiveMe.Element().WithValue(1).WithName("main_2cooler").At(484,801).LightBox().Please(),

                           //Тумблеры снизу
                           GiveMe.Element().WithValue(1).WithName("main_thumbler_simulator").At(582,385).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("main_thumbler_antenna_leftside").At(584,662).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("main_thumbler_antenna_rightside").At(586,752).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("main_thumbler_light").At(656,753).Thumbler(historyService).Please(),
                           
                           //Тумблеры справа сверху
                           GiveMe.Element().WithValue(0).WithName("main_thumbler_power").At(68,1178).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("main_thumbler_cold").At(67,1226).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("main_thumbler_autosarpp").At(69,1278).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("main_thumbler_aircontrol").At(70,1329).Thumbler(historyService).Please(),
                           
                           //Тумблеры справа снизу
                           GiveMe.Element().WithValue(0).WithName("main_thumbler_cooler").At(636,1170).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("main_thumbler_light_maintance").At(637,1217).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("main_thumbler_light_advanced").At(635,1262).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("main_thumbler_light_table").At(636,1308).Thumbler(historyService).Please(),

                           //Стрелки слева
                           GiveMe.Element().WithValue(0).WithName("main_reception_1channel_arrow").WithStartupRotation(35).At(96,127).LittleArrow().Please(),
                           GiveMe.Element().WithValue(0).WithName("main_reception_2channel_arrow").WithStartupRotation(35).At(288,127).LittleArrow().Please(),
                           GiveMe.Element().WithValue(0).WithName("main_reception_3channel_arrow").WithStartupRotation(35).At(478,128).LittleArrow().Please(),
                           GiveMe.Element().WithValue(0).WithName("main_reception_4channel_arrow").WithStartupRotation(35).At(665,128).LittleArrow().Please(),

                           //Стрелки справа
                           GiveMe.Element().WithValue(0).WithName("main_transmitter_1channel_arrow").WithStartupRotation(35).At(103,1004).LittleArrow().Please(),
                           GiveMe.Element().WithValue(0).WithName("main_transmitter_2channel_arrow").WithStartupRotation(35).At(294,1004).LittleArrow().Please(),
                           GiveMe.Element().WithValue(0).WithName("main_transmitter_3channel_arrow").WithStartupRotation(35).At(479,1003).LittleArrow().Please(),
                           GiveMe.Element().WithValue(0).WithName("main_transmitter_4channel_arrow").WithStartupRotation(35).At(667,1001).LittleArrow().Please(),
                       };
        }
    }
}