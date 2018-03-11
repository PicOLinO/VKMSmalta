using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using VKMSmalta.Domain;
using VKMSmalta.Services;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View.DSL;
using VKMSmalta.View.DSL.Other;
using VKMSmalta.View.Elements.ViewModel;
using VKMSmalta.View.InnerPages.ViewModel;

namespace VKMSmalta.View.ViewModel
{
    public class MainInnerDevicePageViewModel : InnerPageViewModelBase
    {
        private readonly HistoryService historyService;

        public MainInnerDevicePageViewModel(HistoryService historyService, InnerRegionPage pageKey, string background) : base(pageKey, background)
        {
            this.historyService = historyService;
            InitializeElements();  //TODO: ВЫШЕ!
        }

        private void InitializeElements()
        {
            //TODO: Добавить начальное состояние элементам из CurrentAlgorithm.StartStateOfElements
            if (PageKey == InnerRegionPage.L001P)
            {
                Elements = new ObservableCollection<ElementViewModelBase>
                       {
                           //Тумблеры в середине
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_thumbler_1channel").WithStartupRotation(90).At(280,341).Thumbler(historyService).WithDependencyAction(GiveMe.DependencyAction().WithDependencyElementName("l001p_reciever_1channel").WithDefaultDependencyValues(DependencyActionsDefaultValues.OneToOneEqualsTwoCount).Please()).Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_thumbler_2channel").WithStartupRotation(90).At(323,340).Thumbler(historyService).Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_thumbler_3channel").WithStartupRotation(90).At(367,341).Thumbler(historyService).Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_thumbler_4channel").WithStartupRotation(90).At(411,341).Thumbler(historyService).Please(),

                           //Подсветка в середине
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_reciever_1channel").At(309,540).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_reciever_2channel").At(353,540).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_reciever_3channel").At(396,540).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_reciever_4channel").At(441,541).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_antenna_leftside").At(483,540).LightBox().Please(),

                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_transmitter_1channel").At(309,628).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_transmitter_2channel").At(353,628).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_transmitter_3channel").At(396,628).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_transmitter_4channel").At(441,627).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_antenna_rightside").At(484,627).LightBox().Please(),

                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_defect_1channel").At(311,715).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_defect_2channel").At(354,715).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_defect_3channel").At(396,714).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_defect_4channel").At(441,714).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_1cooler").At(484,714).LightBox().Please(),

                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_glow_on").At(310,802).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_simulator").At(353,802).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_modulation").At(441,801).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_2cooler").At(484,801).LightBox().Please(),

                           //Тумблеры снизу
                           GiveMe.Element().On(PageKey).WithValue(1).WithName("l001p_thumbler_simulator").At(582,385).Thumbler(historyService).Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_thumbler_antenna_leftside").At(584,662).Thumbler(historyService).Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_thumbler_antenna_rightside").At(586,752).Thumbler(historyService).Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_thumbler_light").At(656,753).Thumbler(historyService).Please(),
                           
                           //Тумблеры справа сверху
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_thumbler_power").At(68,1178).Thumbler(historyService).Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_thumbler_cold").At(67,1226).Thumbler(historyService).Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_thumbler_autosarpp").At(69,1278).Thumbler(historyService).Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_thumbler_aircontrol").At(70,1329).Thumbler(historyService).Please(),
                           
                           //Тумблеры справа снизу
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_thumbler_cooler").At(636,1170).Thumbler(historyService).Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_thumbler_light_maintance").At(637,1217).Thumbler(historyService).Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_thumbler_light_advanced").At(635,1262).Thumbler(historyService).Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_thumbler_light_table").At(636,1308).Thumbler(historyService).Please(),

                           //Стрелки слева
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_reception_1channel_arrow").WithStartupRotation(35).At(96,127).LittleArrow().Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_reception_2channel_arrow").WithStartupRotation(35).At(288,127).LittleArrow().Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_reception_3channel_arrow").WithStartupRotation(35).At(478,128).LittleArrow().Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_reception_4channel_arrow").WithStartupRotation(35).At(665,128).LittleArrow().Please(),

                           //Стрелки справа
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_transmitter_1channel_arrow").WithStartupRotation(35).At(103,1004).LittleArrow().Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_transmitter_2channel_arrow").WithStartupRotation(35).At(294,1004).LittleArrow().Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_transmitter_3channel_arrow").WithStartupRotation(35).At(479,1003).LittleArrow().Please(),
                           GiveMe.Element().On(PageKey).WithValue(0).WithName("l001p_transmitter_4channel_arrow").WithStartupRotation(35).At(667,1001).LittleArrow().Please(),
                       };
            }

            if (PageKey == InnerRegionPage.L001R)
            {
                Elements = new ObservableCollection<ElementViewModelBase>
                           {
                               //Тумблеры приемника-передатчика
                               GiveMe.Element().On(PageKey).WithValue(0).WithName("l001r_reciever_1channel").At(400,104).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithValue(0).WithName("l001r_reciever_2channel").At(400,168).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithValue(0).WithName("l001r_reciever_3channel").At(398,236).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithValue(0).WithName("l001r_reciever_4channel").At(395,303).Thumbler(historyService).Please(),

                               GiveMe.Element().On(PageKey).WithValue(0).WithName("l001r_transmitter_1channel").At(394,366).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithValue(0).WithName("l001r_transmitter_2channel").At(396,435).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithValue(0).WithName("l001r_transmitter_3channel").At(394,507).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithValue(0).WithName("l001r_transmitter_4channel").At(393,576).Thumbler(historyService).Please(),

                               //Контролы управления в середине устройства
                               GiveMe.Element().On(PageKey).WithValue(0).WithName("l001r_antenna_equal").At(309,788).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithValue(1).WithName("l001r_modulation").At(430,806).WithStartupRotation(30).RotateWheel(historyService)
                                     .WithMaxValue(5).WithRotationStepDegrees(30).Please(),
                           };
            }

            if (PageKey == InnerRegionPage.L001K)
            {
                Elements = new ObservableCollection<ElementViewModelBase>
                           {
                               GiveMe.Element().On(PageKey).WithValue(0).WithName("l001k_modulation_13channel").At(232,725).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithValue(0).WithName("l001k_modulation_24channel").At(232,850).Thumbler(historyService).Please(),
                           };
            }
        }
    }
}