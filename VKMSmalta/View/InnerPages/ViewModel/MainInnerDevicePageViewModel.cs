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

        public MainInnerDevicePageViewModel(HistoryService historyService) : base(InnerRegionPages.Main, "View/Images/Background.png")
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
                           GiveMe.Element().WithValue(0)
                                        .WithName("thumbler_1channel")
                                        .WithStartupRotation(90)
                                        .At(285,330)
                                        .Thumbler(historyService)
                                            .WithDependencyAction(new DependencyAction("reciever_1channel", new Dictionary<int, int>
                                                                                                            {
                                                                                                                { 0, 0 },
                                                                                                                { 1, 1 }
                                                                                                            }))
                                        .Please(),
                           GiveMe.Element().WithValue(0).WithName("thumbler_2channel").WithStartupRotation(90).At(330,330).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("thumbler_3channel").WithStartupRotation(90).At(375,330).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("thumbler_4channel").WithStartupRotation(90).At(420,330).Thumbler(historyService).Please(),

                           //Подсветка в середине
                           GiveMe.Element().WithValue(0).WithName("reciever_1channel").At(315,535).LightBox().Please(),
                           GiveMe.Element().WithValue(0).WithName("reciever_2channel").At(360,535).LightBox().Please(),
                           GiveMe.Element().WithValue(0).WithName("reciever_3channel").At(405,535).LightBox().Please(),
                           GiveMe.Element().WithValue(0).WithName("reciever_4channel").At(449,535).LightBox().Please(),
                           GiveMe.Element().WithValue(0).WithName("antenna_leftside").At(494,535).LightBox().Please(),

                           GiveMe.Element().WithValue(0).WithName("transmitter_1channel").At(315,625).LightBox().Please(),
                           GiveMe.Element().WithValue(0).WithName("transmitter_2channel").At(360,625).LightBox().Please(),
                           GiveMe.Element().WithValue(0).WithName("transmitter_3channel").At(405,625).LightBox().Please(),
                           GiveMe.Element().WithValue(0).WithName("transmitter_4channel").At(449,625).LightBox().Please(),
                           GiveMe.Element().WithValue(0).WithName("antenna_rightside").At(494,625).LightBox().Please(),

                           GiveMe.Element().WithValue(0).WithName("defect_1channel").At(315,715).LightBox().Please(),
                           GiveMe.Element().WithValue(0).WithName("defect_2channel").At(360,715).LightBox().Please(),
                           GiveMe.Element().WithValue(0).WithName("defect_3channel").At(405,713).LightBox().Please(),
                           GiveMe.Element().WithValue(0).WithName("defect_4channel").At(449,713).LightBox().Please(),
                           GiveMe.Element().WithValue(0).WithName("1cooler").At(494,713).LightBox().Please(),

                           GiveMe.Element().WithValue(0).WithName("glow_on").At(315,803).LightBox().Please(),
                           GiveMe.Element().WithValue(0).WithName("simulator").At(360,803).LightBox().Please(),
                           GiveMe.Element().WithValue(0).WithName("modulation").At(449,803).LightBox().Please(),
                           GiveMe.Element().WithValue(0).WithName("2cooler").At(494,803).LightBox().Please(),

                           //Тумблеры снизу
                           GiveMe.Element().WithValue(1).WithName("thumbler_simulator").At(595,375).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("thumbler_antenna_leftside").At(600,660).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("thumbler_antenna_rightside").At(600,750).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("thumbler_light").At(670,750).Thumbler(historyService).Please(),
                           
                           //Тумблеры справа сверху
                           GiveMe.Element().WithValue(0).WithName("thumbler_power").At(70,1189).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("thumbler_cold").At(70,1235).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("thumbler_autosarpp").At(70,1287).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("thumbler_aircontrol").At(70,1340).Thumbler(historyService).Please(),
                           
                           //Тумблеры справа снизу
                           GiveMe.Element().WithValue(0).WithName("thumbler_cooler").At(660,1180).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("thumbler_light_maintance").At(660,1223).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("thumbler_light_advanced").At(660,1270).Thumbler(historyService).Please(),
                           GiveMe.Element().WithValue(0).WithName("thumbler_light_table").At(660,1317).Thumbler(historyService).Please(),

                           //Стрелки слева
                           GiveMe.Element().WithValue(0).WithName("reception_1channel_arrow").WithStartupRotation(35).At(98,115).LittleArrow().Please(),
                           GiveMe.Element().WithValue(0).WithName("reception_2channel_arrow").WithStartupRotation(35).At(294,115).LittleArrow().Please(),
                           GiveMe.Element().WithValue(0).WithName("reception_3channel_arrow").WithStartupRotation(35).At(488,115).LittleArrow().Please(),
                           GiveMe.Element().WithValue(0).WithName("reception_4channel_arrow").WithStartupRotation(35).At(680,115).LittleArrow().Please(),

                           //Стрелки справа
                           GiveMe.Element().WithValue(0).WithName("transmitter_1channel_arrow").WithStartupRotation(35).At(98,1005).LittleArrow().Please(),
                           GiveMe.Element().WithValue(0).WithName("transmitter_2channel_arrow").WithStartupRotation(35).At(294,1005).LittleArrow().Please(),
                           GiveMe.Element().WithValue(0).WithName("transmitter_3channel_arrow").WithStartupRotation(35).At(488,1005).LittleArrow().Please(),
                           GiveMe.Element().WithValue(0).WithName("transmitter_4channel_arrow").WithStartupRotation(35).At(680,1005).LittleArrow().Please(),
                       };
        }
    }
}